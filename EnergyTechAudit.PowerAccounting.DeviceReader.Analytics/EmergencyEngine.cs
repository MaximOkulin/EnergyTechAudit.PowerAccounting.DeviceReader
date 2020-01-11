using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Collectors;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.EqualityComparers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.SystemSettings;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using IronPython.Hosting;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Scripting.Hosting;
using Newtonsoft.Json;
using PeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.PeriodType;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Rules;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.EnumTypes;


namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics
{
    public class EmergencyEngine
    {
        public MeasurementDevice MeasurementDevice;
        public AccessPoint AccessPoint;
        public DeviceSnip DeviceSnip;
        public readonly List<ChannelEmergencyInfo> ChannelsEmergencyInfo;
        private readonly DeviceReaderCache _deviceReaderCache;
        private readonly BaseCollector _baseCollector;
        private SeasonType _currentSeasonType;
        private LogHelper _logHelper;

        public List<DeviceArchiveTimeConverter> DeviceArchiveTimeConverters
        {
            get
            {
                return _deviceReaderCache.DeviceArchiveTimeConverters.Where(p => p.DeviceId == DeviceSnip.Id).ToList();
            }
        }

        public DateTime DeviceTime
        {
            set
            {
                if (_baseCollector != null)
                {
                    _baseCollector.DeviceTime = value;
                }
            }
        }

        public TimeSignature TimeSignature
        {
            set
            {
                if (_baseCollector != null)
                {
                    _baseCollector.TimeSignature = value;
                }
            }
        }

        public DeviceReaderCache DeviceReaderCache
        {
            get
            {
                return _deviceReaderCache;
            }
        }

        /// <summary>
        /// Определяет какой в данных момент сезон (Летний или Зимний)
        /// </summary>
        /// <param name="heatingSeason">Даты отопительного сезона</param>
        private void InitCurrentSeasonType(HeatingSeason heatingSeason)
        {
            var now = DateTime.Now;

            _currentSeasonType = now >= heatingSeason.Start && now <= heatingSeason.End
                ? SeasonType.Winter
                : SeasonType.Summer;
        }

        public EmergencyEngine(MeasurementDevice measurementDevice, AccessPoint accessPoint, DeviceReaderCache deviceReaderCache, 
            LogHelper logHelper, System.Linq.Expressions.Expression<Func<EmergencySituationParameter, bool>> extraCondition = null)
        {
            MeasurementDevice = measurementDevice;
            AccessPoint = accessPoint;
            _deviceReaderCache = deviceReaderCache;
            DeviceSnip = deviceReaderCache.GetDeviceSnip(measurementDevice.DeviceId);
            _logHelper = logHelper;

            InitCurrentSeasonType(deviceReaderCache.HeatingSeason);

            var channels = measurementDevice.Channels;
            if (channels != null && channels.Count > 0 && _deviceReaderCache != null &&
                _deviceReaderCache.ChannelTemplates != null)
            {
                ChannelsEmergencyInfo = new List<ChannelEmergencyInfo>();
                foreach (var channel in channels)
                {
                    // 1. Получение шаблона канала из кэша; получение связанных параметров нештатных ситуаций
                    var lstMapParameters =
                        _deviceReaderCache.ChannelTemplates.Where(p => p.ChannelTemplateId == channel.ChannelTemplateId)
                            .ToList();
                    var channelEmergencyInfo = new ChannelEmergencyInfo
                    {
                        Channel = channel,
                        ParameterMapsDeviceParameter = lstMapParameters,
                        EmergencySituationParameters = LoadEmergencySituationParameters(channel.Id, extraCondition)
                    };

                    // заполняем адрес канала, для мобильных сообщений
                    var placement = _deviceReaderCache.Placements.FirstOrDefault(p => p.Id == channel.PlacementId);
                    if (placement != null)
                    {
                        // если это "Узел учета" или "Котельная"
                        if (placement.PlacementPurposeId == 2 || placement.PlacementPurposeId == 4)
                        {
                            var building = _deviceReaderCache.Buildings.FirstOrDefault(p => p.Id == placement.BuildingId);
                            if (building != null)
                            {
                                channelEmergencyInfo.Address = string.Format("{0} ({1})", building.Description, channel.Description);
                            }
                            else
                            {
                                channelEmergencyInfo.Address = placement.Description;
                            }
                        }
                        // если это "Квартира"
                        else if (placement.PlacementPurposeId == 1)
                        {
                            channelEmergencyInfo.Address = placement.Description;
                        }
                    }

                    // обрабатываем только параметры нештатных ситуаций, которые "Без сезона" или соответствуют текущему сезону (Летний или Зимний) и "Включены" (TurnOn)
                    var filteredEmergencySituationParameters = channelEmergencyInfo.EmergencySituationParameters.Where(
                        p =>
                            (p.SeasonTypeId == (int) SeasonType.NoSeason || p.SeasonTypeId == (int) _currentSeasonType) &&
                            p.TurnOn).ToList();
                    channelEmergencyInfo.EmergencySituationParameters = filteredEmergencySituationParameters;

                    if (channelEmergencyInfo.EmergencySituationParameters.Count > 0)
                    {
                        // инициализация сборщика анализируемых параметров
                        var collectorType =
                            Type.GetType(string.Format(DeviceMessages.EmergencyCollectorAssemblyPattern,
                                DeviceSnip.Code));
                        if (collectorType != null)
                        {
                            _baseCollector = (BaseCollector) Activator.CreateInstance(collectorType, this);
                        }
                        else
                        {
                            _baseCollector = new BaseCollector(this);
                        }

                        // текущая ресурсная система канала (HeatSys, Hws, Cws)
                        string resourceSystemType =
                            ((ResourceSystemType) channel.ResourceSystemTypeId).ToString();

                        // 2. Перебор всех связанных нештатных ситуаций, для получения информации о том, из какого
                        // девайсового параметра брать значение и как оно обозначается в выражениях для питона
                        foreach (var emergencySituationParameter in channelEmergencyInfo.EmergencySituationParameters)
                        {
                            var emergencyCondition =
                                JsonConvert.DeserializeObject<EmergencyCondition>(
                                    emergencySituationParameter.PredicateExpression);

                            // проверяем удовлетворяет ли текущий канал необходимым требованиям для выполнения анализа
                            var requirementHelper = new RequirementHelper(emergencyCondition, channel, MeasurementDevice, emergencySituationParameter.Id, _deviceReaderCache);
                            if(!requirementHelper.AnalyzeRequirements())
                                continue;
                            
                            Expression actualExpression = null;

                            // выбираем нужную ветку Expression, если нештатная ситуация зависит от того, 
                            // каким образом прибор сохраняет архивы: интегрально или дифференциально
                            if (emergencyCondition.IsArchiveIntegralityDepends)
                            {
                                actualExpression =
                                    emergencyCondition.Expressions.FirstOrDefault(
                                        p =>
                                            p.IsIntegralArchiveValue ==
                                            DeviceSnip.IsIntegralArchiveValue);
                            }
                            else
                            {
                                if (emergencyCondition.Expressions != null && emergencyCondition.Expressions.Count > 0)
                                {
                                    actualExpression = emergencyCondition.Expressions.First();
                                }
                            }

                            if (actualExpression != null)
                            {
                                channelEmergencyInfo.PreparedEmergencyConditions.Add(new PreparedEmergencyCondition
                                {
                                    Expression = actualExpression,
                                    EmergencySituationParameter = emergencySituationParameter,
                                    EntityName = emergencySituationParameter.EntityTypeName
                                });

                                PrepareEmergencyCondition(actualExpression, emergencyCondition.UserInputValues);

                                foreach (var arg in actualExpression.Arguments)
                                {
                                    if (!arg.HasIdenticalInList(
                                        channelEmergencyInfo.ScopeValues.Select(p => p.Argument).ToList()))
                                    {
                                        var scopeValue = new ScopeValue();
                                        scopeValue.UserInputValues = emergencyCondition.UserInputValues;

                                        // поиск в шаблоне канала девайсового параметра из которого будем брать значение
                                        var channelTemplateParameter = lstMapParameters.FirstOrDefault(
                                            p =>
                                                p.Parameter.Code.Equals(string.Format(Resources.Common.TwoSimplePartsDividePointStringFormat, resourceSystemType,
                                                    arg.ParameterName)) &&
                                                p.PeriodTypeId == (int)arg.PeriodType);

                                        if(channelTemplateParameter != null)
                                        {
                                            scopeValue.DeviceParameterId = channelTemplateParameter.DeviceParameterId;
                                            scopeValue.DeviceParameterDimension = channelTemplateParameter.Dimension;
                                            scopeValue.DeviceParameterUnit = channelTemplateParameter.MeasurementUnit;
                                            scopeValue.ParameterDictionaryId = channelTemplateParameter.ParameterDictionaryId;

                                            // проверяем нужна ли конвертация единицы измерения шаблона в единицы измерения нештатки (например, литры в кубометры)
                                            if(arg.TargetMeasurementUnit != null && !scopeValue.DeviceParameterUnit.Description.Equals(arg.TargetMeasurementUnit, StringComparison.Ordinal))
                                            {
                                                scopeValue.IsNeedToConvertUnit = true;
                                                var convertRule = _deviceReaderCache.MeasurementUnitConverters
                                                    .FirstOrDefault(p => p.MeasurementUnit1.Description.Equals(scopeValue.DeviceParameterUnit.Description, StringComparison.Ordinal) &&
                                                                         p.MeasurementUnit2.Description.Equals(arg.TargetMeasurementUnit, StringComparison.Ordinal)); 
                                                if(convertRule != null)
                                                {
                                                    scopeValue.MeasurementUnitConverter = convertRule;
                                                }
                                                else
                                                {
                                                    _logHelper.CreateLog(string.Format(DeviceMessages.EmergencySituationUnitConverterNotFound,
                                                        emergencySituationParameter.Description, scopeValue.DeviceParameterUnit.Description, arg.TargetMeasurementUnit),
                                                        ErrorType.MissingUnitConverter);
                                                }
                                            }

                                            // проверяем нужна ли конвертация размерности шаблона в размерность нештатки (например, кило в мега)
                                            if(arg.TargetDimension != null && !scopeValue.DeviceParameterDimension.Description.Equals(arg.TargetDimension, StringComparison.Ordinal))
                                            {
                                                scopeValue.IsNeedToConvertDimension = true;
                                                arg.TargetDimensionCoef = _deviceReaderCache.GetDimensionCoef(arg.TargetDimension);
                                                scopeValue.DeviceParameterDimensionCoef = _deviceReaderCache.GetDimensionCoef(scopeValue.DeviceParameterDimension.Description);
                                            }
                                        }
                                        else
                                        {
                                            scopeValue.DeviceParameterId = 0;
                                        }
                                        
                                        scopeValue.Argument = arg;
                                        scopeValue.ParentChannelEmergencyInfo = channelEmergencyInfo;
                                        channelEmergencyInfo.ScopeValues.Add(scopeValue);
                                    }
                                }
                            }
                        }
                    }

                    ChannelsEmergencyInfo.Add(channelEmergencyInfo);
                }
            }
        }

        private int? GetLastNotRecoveryEmergencyLog(int emergencySituationParameterId)
        {
            int? emergencyLogId = null;
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var emergencyLogs = context.Set<EmergencyLog>()
                            .OrderByDescending(p => p.Id)
                            .Where(p => p.EmergencySituationParameterId == emergencySituationParameterId)
                            .Take(10).ToList();

                        var emergencyLog = emergencyLogs.OrderByDescending(p => p.Id).FirstOrDefault();

                        if (emergencyLog != null && emergencyLog.RecoveryTime == null)
                        {
                            emergencyLogId = emergencyLog.Id;
                        }                            

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }
            return emergencyLogId;
        }

        /// <summary>
        /// Подставляет в условие нештатной ситуации граничные аварийные значения, которые ввел пользователь 
        /// </summary>
        /// <param name="expression">Шаблон условия нештатной ситуации</param>
        /// <param name="userInputValues">Граничные аварийные значения</param>
        private void PrepareEmergencyCondition(Expression expression, List<UserInputValue> userInputValues)
        {
            expression.Condition = PrepareEmergencyConditionPart(expression.Condition, userInputValues);
            expression.NullArgumentsCheck = PrepareEmergencyConditionPart(expression.NullArgumentsCheck, userInputValues);

            foreach(var conditionPart in expression.ConditionParts)
            {
                if (!string.IsNullOrEmpty(conditionPart.Check))
                {
                    conditionPart.Check = PrepareEmergencyConditionPart(conditionPart.Check, userInputValues);

                    if (conditionPart.MultipleTitle != null && conditionPart.MultipleTitle.StringFormatParts != null)
                    {
                        foreach (var stringFormatPart in conditionPart.MultipleTitle.StringFormatParts)
                        {
                            stringFormatPart.Expression = PrepareEmergencyConditionPart(stringFormatPart.Expression, userInputValues);
                        }
                    }
                }
            }

            foreach (var argument in expression.Arguments)
            {
                if (!string.IsNullOrEmpty(argument.ParameterName))
                {
                    argument.ParameterName = PrepareEmergencyConditionPart(argument.ParameterName, userInputValues);
                }

                if (!string.IsNullOrEmpty((argument.ScopeParameterName)))
                {
                    argument.ScopeParameterName = PrepareEmergencyConditionPart(argument.ScopeParameterName,
                        userInputValues);
                }

                if (argument.SurrogateArguments != null)
                {
                    foreach (var surrogateArgument in argument.SurrogateArguments)
                    {
                        if (!string.IsNullOrEmpty(surrogateArgument.ScopeParameterName))
                        {
                            surrogateArgument.ScopeParameterName =
                                PrepareEmergencyConditionPart(surrogateArgument.ScopeParameterName, userInputValues);
                        }
                    }
                }
            }
        }

        private string PrepareEmergencyConditionPart(string preparingPart, List<UserInputValue> userInputValues)
        {
            var searchPattern = @"\{(.*?)\}";

            var matches = Regex.Matches(preparingPart, searchPattern);

            foreach (Match match in matches)
            {
                var inputValueCode = match.Groups[1].Value;

                var userInputValue = userInputValues.FirstOrDefault(p => p.Name.Equals(inputValueCode) && p.Value != null);

                if (userInputValue != null)
                {
                    preparingPart = preparingPart.Replace(string.Format("{{{0}}}", inputValueCode), userInputValue.Value);
                }
                else
                {
                    // TODO: пользователь должен ввести все необходимые значения
                }
            }
            return preparingPart;
        }

        private List<EmergencySituationParameter> LoadEmergencySituationParameters(int channelId, 
            System.Linq.Expressions.Expression<Func<EmergencySituationParameter, bool>> extraCondition = null)
        {
            List<EmergencySituationParameter> result = null;
            
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        if (extraCondition == null)
                        {
                            result = context.Set<EmergencySituationParameter>().Where(p => p.ChannelId == channelId && p.TurnOn).ToList();
                        }
                        else
                        {
                            result = context.Set<EmergencySituationParameter>()
                                .Where(p => p.ChannelId == channelId && p.TurnOn)
                                .Where(extraCondition).ToList();
                        }
                       
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }
            
            return result;
        }

        public void CollectValuesFromInstantArchives(List<Archive> instantArchives)
        {
            foreach (var channelEmergencyInfo in ChannelsEmergencyInfo)
            {
                if (channelEmergencyInfo.ScopeValues != null && channelEmergencyInfo.ScopeValues.Count > 0)
                {
                    var scopeValues =
                        channelEmergencyInfo.ScopeValues.Where(
                            p =>
                                (int)p.Argument.PeriodType == (int)PeriodType.Instant &&
                                p.Argument.Interval == null && p.Argument.Operation == Operation.None);

                    foreach (var scopeValue in scopeValues)
                    {
                        var archiveValue = instantArchives.FirstOrDefault(p => p.DeviceParameterId == scopeValue.DeviceParameterId &&
                                                                               p.PeriodTypeId == 1);
                        if (archiveValue != null)
                        {
                            scopeValue.Value = archiveValue.Value;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Проверяет нужно ли данный параметр вычислять для анализа
        /// </summary>
        /// <param name="paramName">Имя параметра</param>
        public bool IsNeedToCollectParam(string paramName)
        {
            return ChannelsEmergencyInfo.SelectMany(channelEmergencyInfo => channelEmergencyInfo.ScopeValues)
                                         .Any(scopeValue => scopeValue.Argument.ScopeParameterName.Equals(paramName));
        }

        /// <summary>
        /// Сбор значений параметров, вычисленных косвенным способом
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="channelEmergencyInfoCondition">Фильтр каналов</param>
        /// <param name="scopeValueCondition">Фильтр текущих значений, которые нужно установить</param>
        public void CollectIndirectValue(decimal value,
            Func<ChannelEmergencyInfo, bool> channelEmergencyInfoCondition,
            Func<ScopeValue, bool> scopeValueCondition)
        {
            var filteredEmergencyInfos = ChannelsEmergencyInfo.Where(channelEmergencyInfoCondition).ToList();

            foreach (var filteredEmergencyInfo in filteredEmergencyInfos)
            {
                var filteredScopeValues = filteredEmergencyInfo.ScopeValues.Where(scopeValueCondition).ToList();
                foreach (var scopeValue in filteredScopeValues)
                {
                    scopeValue.Value = value;
                }
            }
        }

        /// <summary>
        /// Записывает собранные мгновенные и текущие итоговые значения в аналитическую машину
        /// </summary>
        /// <param name="valueInfos">Список "сырых" valueInfo</param>
        public void SetInstantAndFinalInstantArchiveValues(List<ValueInfo> valueInfos)
        {
            var archives = valueInfos.Select(p => (Archive)p).Where(p => p.PeriodTypeId == (int)PeriodType.Instant ||
            p.PeriodTypeId == (int)PeriodType.FinalInstant).ToList();
            SetInstantAndFinalInstantArchiveValues(archives);
        }

        /// <summary>
        /// Записывает собранные мгновенные и текущие итоговые значения в аналитическую машину
        /// </summary>
        /// <param name="values">Список готовых значений Archive</param>
        public void SetInstantAndFinalInstantArchiveValues(List<Archive> archives)
        {
            archives = archives.Where(p => p.PeriodTypeId == (int)PeriodType.Instant ||
            p.PeriodTypeId == (int)PeriodType.FinalInstant).ToList();
            if (_baseCollector != null)
            {
                _baseCollector.SetInstantAndFinalInstantArchiveValues(archives);
            }
        }

        /// <summary>
        /// Очищает коллекцию собранных мгновенных и текущих итоговых значений
        /// </summary>
        public void ClearInstantAndFinalInstantArchiveValues()
        {
            if (_baseCollector != null)
            {
                _baseCollector.ClearInstantAndFinalInstantArchiveValues();
            }
        }

        /// <summary>
        /// Записывает предыдущие мгновенные значения в аналитическую машину
        /// </summary>
        /// <param name="archives">Список готовых предыдущих значений Archive</param>
        public void SetPreviousInstantArchiveValues(List<Archive> archives)
        {
            archives = archives.Where(p => p.PeriodTypeId == (int)PeriodType.Instant).ToList();
            if (_baseCollector != null)
            {
                _baseCollector.SetPreviousArchiveValues(archives);
            }
        }

        /// <summary>
        /// Очищает коллекцию предыдущих мгновенных значений
        /// </summary>
        public void ClearPreviousInstantArchiveValues()
        {
            if (_baseCollector != null)
            {
                _baseCollector.ClearPreviousArchiveValues();
            }
        }

        public void CollectValuesForScope()
        {
            if (_baseCollector != null)
            {
                foreach (var channelEmergencyInfo in ChannelsEmergencyInfo)
                {
                    foreach(var sc in channelEmergencyInfo.ScopeValues)
                    {
                        sc.Value = null;
                    }
                }

                _baseCollector.CollectValuesForScope();
            }
        }

        public void Analyze()
        {
            if (ChannelsEmergencyInfo != null)
            {
                foreach (var channelEmergencyInfo in ChannelsEmergencyInfo)
                {
                    AnalyzeByChannel(channelEmergencyInfo);
                }
            }
        }

        private void AnalyzeByChannel(ChannelEmergencyInfo channelEmergencyInfo)
        {
            var emergencyLogHelper = new EmergencyLogHelper(channelEmergencyInfo.Channel, _deviceReaderCache);

            var scriptScope = CreateScriptEngineScope(channelEmergencyInfo.ScopeValues);

            // подготовленные условия нештатных ситуаций каналов
            var channelPrepatedEmergencyConditions = channelEmergencyInfo.PreparedEmergencyConditions.Where(
                p => p.EntityName.Equals(Resources.Common.ChannelEntityName));

            // подготовленные условия нештатных ситуаций приборов и точек доступа, удаление дубликатов по шаблону нештатной ситуации
            var measurementDeviceEmergencyConditions = channelEmergencyInfo.PreparedEmergencyConditions.Where(
                p => p.EntityName.Equals(Resources.Common.MeasurementDeviceEntityName, StringComparison.Ordinal) ||
                     p.EntityName.Equals(Resources.Common.AccessPointEntityName, StringComparison.Ordinal))
                .Distinct(new PreparedEmergencyConditionByTemplateComparer());

            // объединение условий нештатных ситуаций
            var unionPreparedEmergencyConditions =
                channelPrepatedEmergencyConditions.Union(measurementDeviceEmergencyConditions);

            List<int> recoveryEmergencyLogs = new List<int>();

            foreach (var preparedEmergencyCondition in unionPreparedEmergencyConditions)
            {
                try
                {
                    // предварительно проверяем все ли аргументы условия были собраны
                    var nullArgumentsCheckSource = scriptScope.Engine.CreateScriptSourceFromString(preparedEmergencyCondition.Expression.NullArgumentsCheck);
                    var nullArgumentsCheckResult = nullArgumentsCheckSource.Execute<bool>(scriptScope);

                    // если все аргументы собраны, то есть смысл заниматься анализом
                    if (nullArgumentsCheckResult)
                    {
                        // сначала проанализируем предварительные условия, если они имеются
                        bool preConditionAnalyzeResult = true;
                        if(preparedEmergencyCondition.Expression.PreConditions != null)
                        {
                            var preConditions = preparedEmergencyCondition.Expression.PreConditions.OrderBy(p => p.Order).ToList();

                            foreach(var preCondition in preConditions)
                            {
                                var preConditionSource = scriptScope.Engine.CreateScriptSourceFromString(preCondition.Expression);
                                var preConditionResult = preConditionSource.Execute<bool>(scriptScope);

                                if(preConditionResult)
                                {
                                    // создаем лог нештатной ситуации
                                    emergencyLogHelper.AddEmergencyLog(new EmergencyLog
                                    {
                                        EmergencySituationParameterId = preparedEmergencyCondition.EmergencySituationParameter.Id,
                                        Value = preCondition.Title
                                    });

                                    // создаем мобильное сообщение
                                    emergencyLogHelper.AddMobileEmergencyMessage(new MobileEmergencyMessage
                                    {
                                        Address = channelEmergencyInfo.Address,
                                        EmergencySituationParameterId = preparedEmergencyCondition.EmergencySituationParameter.Id,
                                        EmergencyDescription = preparedEmergencyCondition.EmergencySituationParameter.Description,
                                        EmergencyValue = preCondition.Title
                                    });

                                    preConditionAnalyzeResult = false;
                                    break;
                                }
                            }
                        }

                        if (preConditionAnalyzeResult)
                        {
                            var conditionSource = scriptScope.Engine.CreateScriptSourceFromString(preparedEmergencyCondition.Expression.Condition);
                            var predicateExpressionResult = conditionSource.Execute<bool>(scriptScope);

                            // если возникла нештатная ситуация
                            if (!predicateExpressionResult)
                            {
                                var results = new EmergencyResultValueHelper().GetEmergencyResultString(preparedEmergencyCondition, scriptScope, _logHelper);

                                // создаем лог нештатной ситуации
                                emergencyLogHelper.AddEmergencyLog(new EmergencyLog
                                {
                                    EmergencySituationParameterId = preparedEmergencyCondition.EmergencySituationParameter.Id,
                                    Value = results.Item1,
                                    ShortTitle = results.Item2
                                });

                                // создаем мобильное сообщение
                                emergencyLogHelper.AddMobileEmergencyMessage(new MobileEmergencyMessage
                                {
                                    Address = channelEmergencyInfo.Address,
                                    EmergencySituationParameterId = preparedEmergencyCondition.EmergencySituationParameter.Id,
                                    EmergencyDescription = preparedEmergencyCondition.EmergencySituationParameter.Description,
                                    EmergencyValue = results.Item1,
                                    ChannelId = channelEmergencyInfo.Channel.Id,
                                    MeasurementDeviceId = MeasurementDevice.Id
                                });
                            }
                            else
                            {
                                preparedEmergencyCondition.PreviousEmergencyLogId = 
                                    GetLastNotRecoveryEmergencyLog(preparedEmergencyCondition.EmergencySituationParameter.Id);

                                // нештатная ситуация исчезла, отмечаем время восстановления в предыдущей нештатке
                                if (preparedEmergencyCondition.PreviousEmergencyLogId != null)
                                {
                                    recoveryEmergencyLogs.Add(preparedEmergencyCondition.PreviousEmergencyLogId.Value);
                                }                                
                            }
                        }
                    }
                }
                catch
                {
                    // не удалось проанализировать
                }
            }

            // добавляем ещё в коллекцию логи, полученные на этапе сбора значений аргументов
            foreach(var scopeValue in channelEmergencyInfo.ScopeValues)
            {
                if(scopeValue.EmergencyLogs != null && scopeValue.EmergencyLogs.Count > 0)
                {
                    emergencyLogHelper.AddEmergencyLogs(scopeValue.EmergencyLogs);
                }
            }

            emergencyLogHelper.SetTimeToRecoveryEmergencyLogs(recoveryEmergencyLogs);
            emergencyLogHelper.SaveEmergencyLogs();

            if (emergencyLogHelper.HasEmergencyLogs)
            {
                SendMessagesViaDeliveryService(channelEmergencyInfo);
            }

            if (emergencyLogHelper.SaveMobileEmergencyMessages())
            {
#if DEBUG
                Console.WriteLine("Отправка мобильных сообщений");
#endif
                SendMessagesViaMobileClientService(emergencyLogHelper.MobileEmergencyMessages);
            }
        }

        private async void SendMessagesViaMobileClientService(List<MobileEmergencyMessage> messages)
        {
            if (_deviceReaderCache.MobileMessagingSignalrInfo != null)
            {
                var connection = new HubConnection(_deviceReaderCache.MobileMessagingSignalrInfo.Uri);
                var hubProxy = connection.CreateHubProxy(_deviceReaderCache.MobileMessagingSignalrInfo.TraceHub);

                bool connectionStartResult = true;

                try
                {
                    await connection.Start();
                }
                catch (TimeoutException ex)
                {
                    connectionStartResult = false;
                }
                catch (HttpRequestException ex)
                {
                    connectionStartResult = false;
                }
                catch(Exception ex)
                {
                    connectionStartResult = false;
                }

                if (connectionStartResult)
                {
                    try
                    {
                        await hubProxy.Invoke(DeviceMessages.SendMessagesToPoolCommand, messages);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        private async void SendMessagesViaDeliveryService(ChannelEmergencyInfo channelEmergencyInfo)
        {
            if (_deviceReaderCache.SignalrInfo != null)
            {
                var connection = new HubConnection(_deviceReaderCache.SignalrInfo.Uri);
                var hubProxy = connection.CreateHubProxy(_deviceReaderCache.SignalrInfo.TraceHub);

                bool connectionStartResult = true;

                try
                {
                    await connection.Start();
                }
                catch(TimeoutException ex)
                {
                    connectionStartResult = false;
                }
                catch (HttpRequestException ex)
                {
                    connectionStartResult = false;
                }
               catch(Exception ex)
                {
                    connectionStartResult = false;
                }

                if (connectionStartResult)
                {
                    try
                    {
                        if (channelEmergencyInfo.Channel.LastEmergencyTimeSignatureId != null)
                        {
                            await hubProxy.Invoke(DeviceMessages.SendMessagesByEmergencyChannelCommand, new EmergencyChannelInfo
                            {
                                ChannelId = channelEmergencyInfo.Channel.Id,
                                LastEmergencyTimeSignatureId =
                                    channelEmergencyInfo.Channel.LastEmergencyTimeSignatureId.Value
                            });
                        }
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        private ScriptScope CreateScriptEngineScope(List<ScopeValue> scopeValues)
        {
            var scriptEngine = Python.CreateEngine();
            var scriptScope = scriptEngine.CreateScope();
            ScriptSource source = null;

            source = scriptEngine.CreateScriptSourceFromString(Resources.Common.ScriptEngineInit);
            source.Execute(scriptScope);

            scopeValues.ForEach(p => scriptScope.SetVariable(p.Argument.ScopeParameterName, p.Value));
            
            // добавляем суррогатные аргументы в общую коллекцию вычисленных значений
            scopeValues.Where(p => p.Argument.SurrogateArguments != null && p.Argument.SurrogateArguments.Any())
                       .Select(p => p.Argument.SurrogateArguments).ToList().ForEach(p => p.ForEach(t => scriptScope.SetVariable(t.ScopeParameterName, t.Value)));

            return scriptScope;
        }
    }
}

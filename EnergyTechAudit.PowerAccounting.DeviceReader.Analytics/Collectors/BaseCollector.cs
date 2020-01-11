using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using PeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.PeriodType;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.EnumTypes;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Collectors
{
    public class BaseCollector
    {
        protected readonly EmergencyEngine EmergencyEngine;
        public DateTime DeviceTime = default(DateTime);
        private readonly List<Archive> _instantArchives;
        private readonly List<Archive> _previousInstantArchives;
        private readonly HeatCurveHelper _heatCurveHelper;

        private TimeSignature _timeSignature;

        public TimeSignature TimeSignature
        {
            set
            {
                _timeSignature = value;
            }
        }

        public BaseCollector(EmergencyEngine emergencyEngine)
        {
            EmergencyEngine = emergencyEngine;
            _instantArchives = new List<Archive>();
            _previousInstantArchives = new List<Archive>();

            if (emergencyEngine.AccessPoint != null)
            {
                _heatCurveHelper = new HeatCurveHelper(emergencyEngine.DeviceReaderCache, emergencyEngine.AccessPoint.Id);
            }
        }

        /// <summary>
        /// Установка мгновенных значений (и текущих итоговых)
        /// </summary>
        /// <param name="values">Значения</param>
        public void SetInstantAndFinalInstantArchiveValues(List<Archive> values)
        {
            if (_instantArchives != null)
            {
                _instantArchives.Clear();
                _instantArchives.AddRange(values);
            }
        }

        public void ClearInstantAndFinalInstantArchiveValues()
        {
            if (_instantArchives != null)
            {
                _instantArchives.Clear();
            }
        }

        /// <summary>
        /// Установка предыдущих мгновенных значений
        /// </summary>
        /// <param name="values">Значения</param>
        public void SetPreviousArchiveValues(List<Archive> values)
        {
            if (_previousInstantArchives != null)
            {
                _previousInstantArchives.Clear();
                _previousInstantArchives.AddRange(values);
            }
        }

        public void ClearPreviousArchiveValues()
        {
            if (_previousInstantArchives != null)
            {
                _previousInstantArchives.Clear();
            }
        }


        public virtual void CollectValuesForScope()
        {
            foreach (var channelEmergencyInfo in EmergencyEngine.ChannelsEmergencyInfo)
            {
                // расчет параметров, определяемых суммой или средним
                var calcScopeValues = channelEmergencyInfo.ScopeValues
                    .Where(p => (p.Argument.Operation == Operation.Sum || p.Argument.Operation == Operation.Avg) &&
                                p.Argument.Interval != null &&
                                p.DeviceParameterId != null && p.Value == null);
                foreach (var scopeValue in calcScopeValues)
                {
                    CalculateParam(scopeValue);
                }

                // расчет параметров, определяемых разностью
                var diffScopeValues = channelEmergencyInfo.ScopeValues
                    .Where(p => p.Argument.Operation == Operation.Difference && p.Argument.Interval != null && p.DeviceParameterId != null && p.Value == null);

                foreach(var scopeValue in diffScopeValues)
                {
                    CalculateDifferenceParam(scopeValue);
                }

                // поиск одиночных параметров, найденных по критерию, описанному в ScopeValue (часовые, суточные)
                var singleScopeValues = channelEmergencyInfo.ScopeValues
                    .Where(p => (p.Argument.Operation == Operation.Single) &&
                                p.Argument.Interval != null && 
                                p.DeviceParameterId != null && p.Value == null);

                foreach (var singleScopeValue in singleScopeValues)
                {
                    SearchSingleParam(singleScopeValue);
                }

                // поиск одиночных параметров берущихся из мгновенных значений
                var singleInstantScopeValues = channelEmergencyInfo.ScopeValues
                    .Where(p => (p.Argument.Operation == Operation.Single) &&
                                 p.Argument.Interval == null && 
                                 p.Argument.PeriodType == LightDataAccess.EnumTypes.PeriodType.Instant &&
                                 p.DeviceParameterId != null && p.Value == null);

                foreach(var singleInstantScopeValue in singleInstantScopeValues)
                {
                    SearchInstantParam(singleInstantScopeValue);
                }

                // поиск одиночных параметров берущихся из текущих итоговых значений
                var singleFinalInstantScopeValues = channelEmergencyInfo.ScopeValues
                    .Where(p => (p.Argument.Operation == Operation.Single) &&
                                 p.Argument.Interval == null &&
                                 p.Argument.PeriodType == LightDataAccess.EnumTypes.PeriodType.FinalInstant &&
                                 p.DeviceParameterId != null && p.Value == null);

                foreach (var singleFinalInstantScopeValue in singleFinalInstantScopeValues)
                {
                    SearchFinalInstantParam(singleFinalInstantScopeValue);
                }

                // поиск одиночных параметров берущихся из предыдущих мгновенных значений
                var singlePreviousInstantScopeValues = channelEmergencyInfo.ScopeValues
                    .Where(p => (p.Argument.Operation == Operation.SinglePrevious) &&
                                 p.Argument.Interval == null &&
                                 p.Argument.PeriodType == LightDataAccess.EnumTypes.PeriodType.Instant &&
                                 p.DeviceParameterId != null && p.Value == null);

                foreach (var singlePreviousInstantScopeValue in singlePreviousInstantScopeValues)
                {
                    SearchPreviousInstantParam(singlePreviousInstantScopeValue);
                }

                // параметры вычисляемые по особым алгоритмам
                var customScopeValues =
                    channelEmergencyInfo.ScopeValues.Where(p => p.Argument.Operation == Operation.Custom);

                foreach (var customScopeValue in customScopeValues)
                {
                    var parameterName = customScopeValue.Argument.ScopeParameterName;
                    
                    var calculateMethod = GetType().GetMethod(string.Format("Calculate{0}", parameterName));

                    if (calculateMethod != null)
                    {
                        calculateMethod.Invoke(this, new object[] {customScopeValue});
                    }
                }

                // расчет суррогатных аргументов, которые используют словарное значение
                var dictionaryScopeValues = channelEmergencyInfo.ScopeValues.Where(p => p.Argument.UseParameterDictionary);

                foreach (var dictionaryScopeValue in dictionaryScopeValues)
                {
                    DictionaryValueSubstitution(dictionaryScopeValue);
                }

                var valueConverter = new ValueConverter();
                foreach(var scopeValue in channelEmergencyInfo.ScopeValues)
                {
                    valueConverter.ConvertValue(scopeValue);
                }
            }
        }

        /// <summary>
        /// Делает расшифровку словарного значения и записывает его в суррогатный аргумент
        /// </summary>
        /// <param name="scopeValue"></param>
        private void DictionaryValueSubstitution(ScopeValue scopeValue)
        {
            foreach (var surrogateArgument in scopeValue.Argument.SurrogateArguments)
            {
                if (scopeValue.ParameterDictionaryId != null && scopeValue.Value != null)
                {
                    var parameterDictionaryValue = EmergencyEngine.DeviceReaderCache
                                   .ParameterDictionaryValues
                                   .FirstOrDefault(p => p.ParameterDictionaryId == scopeValue.ParameterDictionaryId.Value && p.Value == scopeValue.Value.Value);
                    
                    if(parameterDictionaryValue != null)
                    {
                        surrogateArgument.Value = parameterDictionaryValue.Description;
                    }
                }
            }
        }

        /// <summary>
        /// Ищет мгновенное значение заданного параметра
        /// </summary>
        /// <param name="scopeValue">Параметр</param>
        private void SearchInstantParam(ScopeValue scopeValue)
        {
            if (scopeValue.Value == null)
            {
                var archive = _instantArchives.FirstOrDefault(p => p.DeviceParameterId == scopeValue.DeviceParameterId && p.IsValid && p.PeriodTypeId == (int)PeriodType.Instant);

                if (archive != null)
                {
                    scopeValue.Value = archive.Value;
                }
            }
        }

        /// <summary>
        /// Ищет текущее итоговое значение заданного параметра
        /// </summary>
        /// <param name="scopeValue">Параметр</param>
        private void SearchFinalInstantParam(ScopeValue scopeValue)
        {
            if (scopeValue.Value == null)
            {
                var archive = _instantArchives.FirstOrDefault(p => p.DeviceParameterId == scopeValue.DeviceParameterId && p.IsValid && p.PeriodTypeId == (int)PeriodType.FinalInstant);

                if (archive != null)
                {
                    scopeValue.Value = archive.Value;
                }
            }
        }

        /// <summary>
        /// Ищет предыдущее мгновеннео значение заданного параметра
        /// </summary>
        /// <param name="scopeValue">Параметр</param>
        private void SearchPreviousInstantParam(ScopeValue scopeValue)
        {
            if (scopeValue.Value == null && _previousInstantArchives != null && _previousInstantArchives.Count > 0)
            {
                var archive = _previousInstantArchives.FirstOrDefault(p => p.DeviceParameterId == scopeValue.DeviceParameterId && p.IsValid && p.PeriodTypeId == (int)PeriodType.Instant);

                if (archive != null)
                {
                    scopeValue.Value = archive.Value;
                }
            }
        }

        /// <summary>
        /// Поиск текущего итогового, которое было заданное количество часов назад
        /// (для нештатки "Контроль накопления объема потребленной холодной воды")
        /// </summary>
        /// <param name="scopeValue"></param>
        public void CalculateVolume_FinalInstant_Custom(ScopeValue scopeValue)
        {
            var analyzeTimeSpanInputValue = scopeValue.UserInputValues.FirstOrDefault(p => p.Name.Equals(Resources.Common.AnalyzeTimeSpan, StringComparison.Ordinal));

            if (analyzeTimeSpanInputValue != null)
            {
                int analyzeTimeSpan = Convert.ToInt32(analyzeTimeSpanInputValue.Value);

                Archive archive = null;

                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            var timeEnd = DateTime.Now.AddHours(-analyzeTimeSpan);
                            var timeBegin = timeEnd.AddHours(-2);

                            var archives = context.Set<Archive>().Where(p =>
                            p.PeriodTypeId == (int)PeriodType.FinalInstant &&
                            p.MeasurementDeviceId == EmergencyEngine.MeasurementDevice.Id &&
                            p.DeviceParameterId == scopeValue.DeviceParameterId &&
                            p.Time <= timeEnd && p.Time >= timeBegin).Take(5).ToList();

                            var searchedTime = archives.Select(p => p.Time).Max();

                            archive = archives.First(p => p.Time == searchedTime);
                        }
                        catch
                        {
                            tran.Rollback();
                        }
                    }
                }

                if (archive != null)
                {
                    scopeValue.Value = archive.Value;
                }
            }
        }

        /// <summary>
        /// Рассчитывает количество минут, в течение которых модем Барс не выходил на связь
        /// </summary>
        /// <param name="scopeValue">Контролируемый параметр</param>
        public void CalculateNoBarsConnectionMinutes(ScopeValue scopeValue)
        {
            if(EmergencyEngine.AccessPoint.TransportServerModel != null &&
                EmergencyEngine.AccessPoint.TransportServerModel.Code.Contains("Bars"))
            {
                var lastConnectionTime = EmergencyEngine.MeasurementDevice.AccessPoint.LastConnectionTime;
                if (lastConnectionTime.Year != 1900)
                {
                    var now = DateTime.Now;
                    var ts = now - lastConnectionTime;

                    scopeValue.Value = (int)ts.TotalMinutes;
                }
                else
                {
                    scopeValue.Value = null;
                }
            }
            else
            {
                scopeValue.Value = null;
            }
        }


        /// <summary>
        /// Рассчитывает температуру в подающем трубопроводе, используя температурный график ресурсоснабжающей организации
        /// </summary>
        /// <param name="scopeValue">Рассчитываемый параметр</param>
        public void CalculateHeatSysSupplyTemperatureByHeatCurve(ScopeValue scopeValue)
        {
            _heatCurveHelper.CalculateHeatSysTemperatureByHeatCurve(scopeValue, Common.Types.HeatCurve.HeatCurveType.SupplyPipe);
        }

        /// <summary>
        /// Рассчитывает температуру в обратном трубопроводе, используя температурный график ресурсоснабжающей организации
        /// </summary>
        /// <param name="scopeValue">Рассчитываемый параметр</param>
        public void CalculateHeatSysReturnTemperatureByHeatCurve(ScopeValue scopeValue)
        {
            _heatCurveHelper.CalculateHeatSysTemperatureByHeatCurve(scopeValue, Common.Types.HeatCurve.HeatCurveType.ReturnPipe);
        }

        /// <summary>
        /// Рассчитывает температуру наружного воздуха с учетом корректировки относительно здания, в котором находится прибор учета
        /// </summary>
        /// <param name="scopeValue">Рассчитываемый параметр</param>
        public void CalculateBuildingCorrectionOutdoorTemperature(ScopeValue scopeValue)
        {
            scopeValue.Value = _heatCurveHelper.OutdoorTemperature;
        }

        /// <summary>
        /// Рассчитывает количество минут, в течение которых с прибором была плохая связь
        /// </summary>
        /// <param name="scopeValue">Контролируемый параметр</param>
        public void CalculateNoSuccessConnectionMinutes(ScopeValue scopeValue)
        {
            if ((StatusConnection)EmergencyEngine.MeasurementDevice.LastStatusConnectionId == StatusConnection.Success)
            {
                scopeValue.Value = 0;
            }
            else
            {
                var lastSuccessConnectionTime = EmergencyEngine.MeasurementDevice.LastSuccessConnectionTime;

                if (lastSuccessConnectionTime == null)
                {
                    scopeValue.Value = null;
                }
                else if (lastSuccessConnectionTime < new DateTime(2000, 1, 1))
                {
                    scopeValue.Value = null;
                }
                else
                {
                    var now = DateTime.Now;
                    var ts = now - lastSuccessConnectionTime.Value;

                    scopeValue.Value = (int)ts.TotalMinutes;
                }
            }
        }

        /// <summary>
        /// Рассчитывает количество секунд, на которое отличается время прибора от серверного времени
        /// </summary>
        /// <param name="scopeValue">Контролируемый параметр</param>
        public void CalculateDeviceTimeDifference(ScopeValue scopeValue)
        {
            if(_timeSignature != null)
            {
                if (EmergencyEngine.DeviceSnip.Code.Equals(DeviceMessages.Vkt7DeviceCode, StringComparison.Ordinal))
                {
                    scopeValue.Value = _timeSignature.DeviceTime.CalculateVkt7DeviceTimeDifference(_timeSignature.Time);
                }
                else if (EmergencyEngine.DeviceSnip.Code.Equals(DeviceMessages.Tv7DeviceCode, StringComparison.Ordinal))
                {
                    if (EmergencyEngine.MeasurementDevice.LastStatusConnectionId == (int)StatusConnection.Success)
                    {
                        scopeValue.Value = (int)(_timeSignature.DeviceTime - _timeSignature.Time).TotalSeconds;
                    }
                    else
                    {
                        scopeValue.Value = 0;
                    }
                }
                else
                {
                    scopeValue.Value = (int)(_timeSignature.DeviceTime - _timeSignature.Time).TotalSeconds;
                }
            }
        }

        private void SearchSingleParam(ScopeValue scopeValue)
        {
            var archiveTime = GetLastArchiveTime(scopeValue);

            var argument = scopeValue.Argument;

            Expression<Func<Archive, bool>> predicate = a => a.PeriodTypeId == (int) argument.PeriodType &&
                                                             a.MeasurementDeviceId ==
                                                             EmergencyEngine.MeasurementDevice.Id &&
                                                             a.DeviceParameterId == scopeValue.DeviceParameterId.Value &&
                                                             a.Time == archiveTime;

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var archive = context.Set<Archive>().FirstOrDefault(predicate);
                        if (archive != null)
                        {
                            scopeValue.Value = archive.Value;
                        }

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }
        }

        private DateTime GetLastArchiveTime(ScopeValue scopeValue)
        {
            var periodType = scopeValue.Argument.PeriodType;

            if (scopeValue.Argument.Interval != null)
            {
                var interval = scopeValue.Argument.Interval.Value;
                // корректирующий интервал (в секундах), для приведения к времени архива прибора
                var correctInterval = 0;
                
                var archiveTimeConverter =
                    EmergencyEngine.DeviceArchiveTimeConverters.FirstOrDefault(
                        p => p.PeriodTypeId == (int) periodType);

                if (archiveTimeConverter != null)
                {
                    correctInterval = archiveTimeConverter.Interval;
                }

                if (DeviceTime != default(DateTime))
                {
                    if ((int)periodType == (int)PeriodType.Hour)
                    {
                        return new DateTime(DeviceTime.Year, DeviceTime.Month, DeviceTime.Day, DeviceTime.Hour, 0, 0).AddHours(-1 * interval).AddSeconds(correctInterval);
                    }
                    if ((int)periodType == (int)PeriodType.Day)
                    {
                        return new DateTime(DeviceTime.Year, DeviceTime.Month, DeviceTime.Day, 0, 0, 0).AddDays(-1 * interval).AddSeconds(correctInterval);
                    }
                }
            }
            return default(DateTime);
        }

        /// <summary>
        /// Рассчитывает значения, которые вычисляются на основе разности
        /// </summary>
        /// <param name="scopeValue">Значение для расчета</param>
        private void CalculateDifferenceParam(ScopeValue scopeValue)
        {
            var argument = scopeValue.Argument;

            Expression<Func<Archive, bool>> firstArchiveCondition = a => a.DeviceParameterId == scopeValue.DeviceParameterId.Value;
            var firstArchive = GetLastArchiveByPeriod((PeriodType)((int)argument.PeriodType), firstArchiveCondition);

            if(firstArchive != null && argument.Interval != null)
            {
                // если у аргумента указано допустимое отклонение от приборного времени
                if(argument.DeviceTimeTolerance != null)
                {
                    var ts = DeviceTime - firstArchive.Time;
                    if(Math.Abs(ts.TotalMinutes) > argument.DeviceTimeTolerance.Value)
                    {
                        scopeValue.Value = null;
                        return;
                    }
                }

                var secondArchiveTime = firstArchive.Time.SubstractIntervalByPeriod((PeriodType)((int)argument.PeriodType), argument.Interval.Value);

                Expression<Func<Archive, bool>> secondArchiveCondition = a => a.DeviceParameterId == scopeValue.DeviceParameterId.Value && a.Time == secondArchiveTime;

                var secondArchive = GetLastArchiveByPeriod((PeriodType)((int)argument.PeriodType), secondArchiveCondition);

                if(secondArchive != null)
                {
                    scopeValue.Value = firstArchive.Value - secondArchive.Value;

                    if (scopeValue.Argument.SurrogateArguments != null && scopeValue.Argument.SurrogateArguments.Any())
                    {
                        foreach (var surrogateArgument in scopeValue.Argument.SurrogateArguments)
                        {
                            if (surrogateArgument.Expression.Equals(Resources.Common.PeriodBegin, StringComparison.Ordinal))
                            {
                                surrogateArgument.Value = firstArchive.Time.ToString();
                            }
                            else if (surrogateArgument.Expression.Equals(Resources.Common.PeriodEnd, StringComparison.Ordinal))
                            {
                                surrogateArgument.Value = secondArchive.Time.ToString();
                            }
                        }
                    }

                    return;
                }
                else
                {
                    scopeValue.Value = null;
                }
            }
            scopeValue.Value = null;
        }

        /// <summary>
        /// Рассчитывает сколько времени назад сработал триггер открытия подвальной двери
        /// </summary>
        /// <param name="scopeValue"></param>
        public void CalculateBasementOpenTriggerDiff(ScopeValue scopeValue)
        {
            CalculateOpenTriggerDiff(scopeValue);
        }

        /// <summary>
        /// Рассчитывает сколько времени назад сработал триггер открытия чердачной двери
        /// </summary>
        /// <param name="scopeValue"></param>
        public void CalculateAtticOpenTriggerDiff(ScopeValue scopeValue)
        {
            CalculateOpenTriggerDiff(scopeValue);
        }

        public void CalculateOpenTriggerDiff(ScopeValue scopeValue)
        {
            var dateOpenTrigger = _instantArchives.FirstOrDefault(p => p.DeviceParameterId == scopeValue.DeviceParameterId);

            if (dateOpenTrigger != null)
            {
                var triggerTime = DateTime.FromOADate((double)dateOpenTrigger.Value);
                scopeValue.Value = (int)(DateTime.Now - triggerTime).TotalSeconds;
            }
        }

        private void CalculateParam(ScopeValue scopeValue)
        {
            var argument = scopeValue.Argument;
            var periodBegin = CalculatePeriodBegin((int)argument.PeriodType, argument.Interval.Value);
            var periodEnd = DeviceTime;

            // если у параметра задано разрешенное отклонение времени относительно времени прибора
            if(argument.DeviceTimeTolerance != null && argument.Interval != null)
            {
                Expression<Func<Archive, bool>> firstArchiveCondition = a => a.DeviceParameterId == scopeValue.DeviceParameterId.Value;
                var firstArchive = GetLastArchiveByPeriod((PeriodType)((int)argument.PeriodType), firstArchiveCondition);

                if (firstArchive != null)
                {
                    var ts = DeviceTime - firstArchive.Time;
                    if (Math.Abs(ts.TotalMinutes) > argument.DeviceTimeTolerance.Value)
                    {
                        scopeValue.Value = null;
                        return;
                    }
                    var secondArchiveTime = firstArchive.Time.SubstractIntervalByPeriod((PeriodType)((int)argument.PeriodType), argument.Interval.Value);

                    Expression<Func<Archive, bool>> secondArchiveCondition = a => a.DeviceParameterId == scopeValue.DeviceParameterId.Value && a.Time == secondArchiveTime;

                    var secondArchive = GetLastArchiveByPeriod((PeriodType)((int)argument.PeriodType), secondArchiveCondition);

                    if(secondArchive != null)
                    {
                        periodBegin = secondArchive.Time;
                        periodEnd = firstArchive.Time;
                    }
                }
                else
                {
                    scopeValue.Value = null;
                    return;
                }
            }

            Expression<Func<Archive, bool>> predicate = a => a.PeriodTypeId == (int) argument.PeriodType &&
                                                             a.MeasurementDeviceId == EmergencyEngine.MeasurementDevice.Id &&
                                                             a.DeviceParameterId == scopeValue.DeviceParameterId.Value &&
                                                             a.Time <= periodEnd && a.Time >= periodBegin;

            if (scopeValue.Argument.SurrogateArguments != null && scopeValue.Argument.SurrogateArguments.Any())
            {
                foreach (var surrogateArgument in scopeValue.Argument.SurrogateArguments)
                {
                    if(surrogateArgument.Expression.Equals(Resources.Common.PeriodBegin, StringComparison.Ordinal))
                    {
                        surrogateArgument.Value = periodBegin.ToString();
                    }
                    else if (surrogateArgument.Expression.Equals(Resources.Common.PeriodEnd, StringComparison.Ordinal))
                    {
                        surrogateArgument.Value = periodEnd.ToString();
                    }
                }
            }

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        if (argument.Operation == Operation.Sum)
                        {
                            scopeValue.Value = context.Set<Archive>().Where(predicate).Select(p => p.Value).Sum();
                        }
                        else if (argument.Operation == Operation.Avg)
                        {
                            scopeValue.Value = context.Set<Archive>().Where(predicate).Select(p => p.Value).Average();
                        }

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }

            /*
            if(scopeValue.DeviceParameterId == 83)
            {
                scopeValue.Value = 270;
            }
            */
        }

        private DateTime CalculatePeriodBegin(int periodType, int interval)
        {
            if (DeviceTime != default(DateTime))
            {
                if (periodType == (int)PeriodType.Hour || periodType == (int)PeriodType.Instant)
                {
                    return DeviceTime.AddHours(-1 * interval);
                }
                if (periodType == (int)PeriodType.Day)
                {
                    return DeviceTime.AddDays(-1 * interval);
                }
                if (periodType == (int)PeriodType.Month)
                {
                    return DeviceTime.AddMonths(-1 * interval);
                }
            }
            return DeviceTime;
        }

        /// <summary>
        /// Возвращает последнюю архивную запись за период с использованием дополнительного условия
        /// </summary>
        /// <param name="periodType">Тип периода (часовой, суточный, месячный)</param>
        /// <param name="extraCondition">Дополнительное условие</param>
        protected Archive GetLastArchiveByPeriod(PeriodType periodType, Expression<Func<Archive, bool>> extraCondition)
        {
            Archive archive = null;
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        archive = context.Set<Archive>().OrderByDescending(p => p.Time)
                                                  .Where(extraCondition)
                                                  .FirstOrDefault(p => p.MeasurementDeviceId == EmergencyEngine.MeasurementDevice.Id && p.PeriodTypeId == (int)periodType);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }
            return archive;
        }       
    }
}

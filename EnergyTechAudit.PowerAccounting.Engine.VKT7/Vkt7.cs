using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes;
using Parameter = EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections.Parameter;
using Device = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.CustomFormatters;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using Newtonsoft.Json;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7
{
    /// <summary>
    /// Поток выполнения операций обмена информацией с ВКТ-7
    /// </summary>
    [Device("VKT7")]
    public partial class Vkt7 : Device
    {
        private ActionSteps _actionSteps;

        // версия сервера
        private int _serverType = -1;

        // флаги активности каналов
        private bool _isFirstChannelActive;
        private bool _isSecondChannelActive;

        private List<StartParamValue> _startParamValues;

        // возможности ПО прибора
        private DeviceFeatures _deviceFeatures;

        private DeviceTime _deviceTime;

        // список параметров текущей измерительной схемы
        private Dictionary<Parameter, int> _parameters = new Dictionary<Parameter, int>();

        protected override void InitTransport()
        {
            ManualResetEvent = new ManualResetEvent(false);
            Transport = new VktConnection(MeasurementDevice, ApI, ManualResetEvent, LogHelper);
            
            if (DynamicParameterHelper != null)
            {
                DynamicParameterHelper.CheckExistDynamicDataValues();

                DynamicParameterHelper.InitDynamicDataValues(new[]
                {
                (int) DynamicParameter.DeviceVkt7SchemeTv1,
                (int) DynamicParameter.DeviceVkt7SchemeTv2,
                (int) DynamicParameter.DeviceVkt7Pipe3TargetTv1,
                (int) DynamicParameter.DeviceVkt7Pipe3TargetTv2,
                (int) DynamicParameter.DeviceVkt7t5TargetTv1,
                (int) DynamicParameter.DeviceVkt7t5TargetTv2,
                (int) DynamicParameter.DeviceStartValuesDescription,
                (int) DynamicParameter.DeviceDelayBeforePolling,
                (int) DynamicParameter.DeviceTimeOutBeforeSend
            });
            }

            var timeOutBeforeSend = DynamicParameterHelper.GetDynamicValue<int>(DynamicParameter.DeviceTimeOutBeforeSend);
            _actionSteps = new ActionSteps(Transport, ManualResetEvent, MeasurementDevice.NetworkAddress, timeOutBeforeSend);
        }

        public Vkt7(int deviceId, DeviceReaderCache deviceReaderCache, TcpClient preparedTcpClient) : base(deviceId, deviceReaderCache, preparedTcpClient) { }

        public Vkt7(int deviceId, DeviceReaderCache deviceReaderCache = null) : base(deviceId, deviceReaderCache) { }

        public Vkt7(MeasurementDevice device) : base(device) { }

        public Vkt7(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings) : base(device, preparedTcpClient, serverCommunicatorSettings) { }

        public Vkt7(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings, int deviceReaderId) : base(device, preparedTcpClient, serverCommunicatorSettings, deviceReaderId) { }

        protected override Dictionary<string, string> GetCurrents()
        {
            var result = new Dictionary<string, string>();

            InitStartValuesFromDynamicParameter();

            _actionSteps.StartSession();

            // если версия ПО еще не была считана, то надо считать
            if (string.IsNullOrEmpty(MeasurementDevice.Firmware))
            {
                _actionSteps.GetServiceInformation();
                int serviceInfoLength = Transport.Buffer[2];

                byte[] serviceInfoBuf = null;
                // Получаем номер версии ПО прибора
                // если длина данных больше 1 байта - имеем дело с версией ПО 1.5 и более
                if (serviceInfoLength > 1)
                {
                    serviceInfoBuf = Transport.Buffer;
                    byte firmware = Transport.Buffer[3];
                    Firmware = new Firmware(firmware >> 4, firmware & ((1 << 4) - 1));
                    MeasurementDevice.Firmware = Firmware.ToString();
                }
            }

            string[] firmwareParts = MeasurementDevice.Firmware.Split(new char[] { '.' });

            _deviceFeatures = new DeviceFeatures(
                new Firmware(Convert.ToInt32(firmwareParts[0]), Convert.ToInt32(firmwareParts[1])));

            // Получаем даты
            if (_deviceFeatures.IsGetDateIntervalSupports)
            {
                _actionSteps.GetDateInterval();

                if (Transport.CurrentErrorCode != ErrorCode.VKT_GetDateIntervalError)
                {
                    _deviceTime = new DeviceTime
                    {
                        HourArchiveStart = Transport.Buffer.GetDateTimeFromBytes(3),
                        Current = Transport.Buffer.GetDateTimeFromBytes(7),
                        DailyArchiveStart = Transport.Buffer.GetDateTimeFromBytes(11)
                    };
                }
            }

            DeviceTime = _deviceFeatures.IsGetDateIntervalSupports && _deviceTime != null
                ? _deviceTime.Current
                : DateTime.Now;

            ArchiveCollector = new ArchiveCollector(DeviceTime, MeasurementDevice, _startParamValues);

            // Получаем тип сервера
            _actionSteps.GetData(DataType.ServerType);
            _serverType =
                (int)CallbackFunctions.GetDataCallback(Transport.Buffer, GetDataMode.ServerType);

            if (_serverType != 1 && _serverType != 0)
            {
                List<KeyValuePair<string, string>> resList = result.ToList();

                resList.Insert(0, new KeyValuePair<string, string>(CommandsKeys.Vkt7WrongServerTypeKey,
                string.Format(StringFormat.ErrorResponseHtml, string.Format(DeviceMessages.Vkt7WrongServerType, _serverType))));

                return resList.ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                // Получаем список доступных измеряемых параметров
                _parameters =
                    _actionSteps.GetReadParameters(
                        (ArchiveCollector as ArchiveCollector).ParametersCollection);

                // Получаем список единиц измерений и кол-ва точек после запятой
                _actionSteps.GetProperties();

                object tuple = CallbackFunctions.GetDataCallback(Transport.Buffer,
                    GetDataMode.Properties, _serverType);

                (ArchiveCollector as ArchiveCollector).InitUnitNamesAndDecimals(tuple);

                // Анализируем какие тепловые вводы прибора активны в данной схеме
                _isFirstChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.OneHeatInput, StringComparison.Ordinal)) > 0;
                _isSecondChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.TwoHeatInput, StringComparison.Ordinal)) > 0;

                if (_isFirstChannelActive || _isSecondChannelActive)
                {
                    ReadInstantArchives(true);
                    ArchiveCollector.SaveArchives();

                    UpdateLastTimeSignatureId();

                    List<KeyValuePair<string, string>> resList = result.ToList();

                    resList.Insert(0, new KeyValuePair<string, string>(CommandsKeys.ReadCurrentsSuccessfullyKey,
                       DeviceMessages.ReadCurrentsSuccessfullyHtml));
                    return resList.ToDictionary(x => x.Key, x => x.Value);
                }
            }

            return result;
        }

        protected override Dictionary<string, string> GetConnectionExistence()
        {
            var result = new Dictionary<string, string>();

            _actionSteps.StartSession();
            int currentDeviceNumber = GetDeviceIdentifier();

            result.Add(DeviceMessages.RealFactoryNumberKey,
                string.Format(DeviceMessages.RealFactoryNumber, currentDeviceNumber));
            if (currentDeviceNumber == MeasurementDevice.FactoryNumber)
            {
                _parameters =
                    _actionSteps.GetReadParameters(ParametersCollection.GetParametersCollection());

                bool isFirstChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.OneHeatInput, StringComparison.Ordinal)) > 0;
                bool isSecondChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.TwoHeatInput, StringComparison.Ordinal)) > 0;

                result.Add(DeviceMessages.Vkt7ChannelActivitiesKey,
                    string.Format(TraceMessages.Vkt7ChannelActivities, isFirstChannelActive.ToActiveString(),
                        isSecondChannelActive.ToActiveString()));

                // Получаем номер версии ПО прибора
                // если длина данных больше 1 байта - имеем дело с версией ПО 1.5 и более
                _actionSteps.GetServiceInformation();
                int serviceInfoLength = Transport.Buffer[2];

                if (serviceInfoLength > 1)
                {
                    byte firmware = Transport.Buffer[3];
                    Firmware = new Firmware(firmware >> 4, firmware & ((1 << 4) - 1));
                    result.Add(CommandsKeys.FirmwareKey, string.Format(DeviceMessages.Firmware, Firmware.ToString()));

                    var schemeInfoHelper = new SchemeInfoHelper();

                    var schemeTv1 = schemeInfoHelper.ParseSchemeInfo(Transport.Buffer);
                    var schemeTv2 = schemeInfoHelper.ParseSchemeInfo(Transport.Buffer, 2);

                    result.Add(CommandsKeys.SchemeTv1Key, string.Format(Vkt7Resources.SchemeTv1StringFormat, schemeTv1.SchemeNumber, schemeTv1.T3, schemeTv1.t5));
                    result.Add(CommandsKeys.SchemeTv2Key, string.Format(Vkt7Resources.SchemeTv2StringFormat, schemeTv2.SchemeNumber, schemeTv2.T3, schemeTv2.t5));

                    var reportingMonthDay = serviceInfoLength > 10
                        ? Transport.Buffer[17]
                        : Transport.Buffer[3];

                    result.Add(Vkt7Resources.Vkt7ReportingDayKey, string.Format(DeviceMessages.Vkt7ReportingDay, reportingMonthDay));

                    _deviceFeatures = new DeviceFeatures(Firmware);

                    if (_deviceFeatures.IsGetDateIntervalSupports)
                    {
                        _actionSteps.GetDateInterval();

                        if (Transport.CurrentErrorCode != ErrorCode.VKT_GetDateIntervalError)
                        {
                            _deviceTime = new DeviceTime
                            {
                                HourArchiveStart = Transport.Buffer.GetDateTimeFromBytes(3),
                                Current = Transport.Buffer.GetDateTimeFromBytes(7),
                                DailyArchiveStart = Transport.Buffer.GetDateTimeFromBytes(11)
                            };
                        }

                    }

                    DeviceTime = _deviceFeatures.IsGetDateIntervalSupports && _deviceTime != null
                        ? _deviceTime.Current
                        : DateTime.Now;

                    result.Add(CommandsKeys.DeviceTimeDifferenceKey, string.Format(new DeviceTimeDifferenceFormat(), Resources.Common.DeviceTimeDifferenceStringFormat, DeviceTime.CalculateVkt7DeviceTimeDifference(DateTime.Now)));

                    result.Add(CommandsKeys.DeviceTimeKey, string.Format(DeviceMessages.DeviceTime, DeviceTime));
                }
                else
                {
                    result.Add(CommandsKeys.FirmwareKey, string.Format(DeviceMessages.Firmware, Vkt7Resources.FirmwareLess1_5));
                }

                List<KeyValuePair<string, string>> resList = result.ToList();
                resList.Insert(0, new KeyValuePair<string, string>(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionHtml));

                return resList.ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                List<KeyValuePair<string, string>> resList = result.ToList();

                resList.Insert(0, new KeyValuePair<string, string>(DeviceMessages.ConnectionStatusKey, 
                    DeviceMessages.SuccessConnectionWrongFactoryNumberHtml));
                return resList.ToDictionary(x => x.Key, x => x.Value);
            }            
        }

        /// <summary>
        /// Возвращает заводской номер прибора
        /// </summary>
        private int GetDeviceIdentifier()
        {
            int currentDeviceNumber = default(int);

            RaiseTraceInfoPassedEvent(TraceMessages.GetDeviceIdentifier);

            // если версия прошивки ниже 1.9, то команда запрос идентификатора прибора не пройдёт
            _actionSteps.GetServiceInformation();
            int serviceInfoLength = Transport.Buffer[2];

            // если длина данных больше 1 байта - имеем дело с версией ПО 1.5 и более
            if (serviceInfoLength > 1)
            {
                currentDeviceNumber = Parser.ParseDeviceIdentifierOldFirmware(Transport.Buffer);
            }
            // для очень старых прошивок нет возможности получить заводской номер, поэтому просто присваиваем текущий, указанный в настройках
            else
            {
                currentDeviceNumber = (int)MeasurementDevice.FactoryNumber;
            }

            RaiseTraceInfoPassedEvent(string.Format(TraceMessages.DeviceIdentifier, currentDeviceNumber));

            return currentDeviceNumber; 
        }

        private void InitStartValuesFromDynamicParameter()
        {
            // инициализируем стартовые значения из динамического параметра (если они имеются)
            var startValuesStr = DynamicParameterHelper.GetDynamicValue<string>(DynamicParameter.DeviceStartValuesDescription);

            if (!startValuesStr.Equals(Resources.Common.UnderscoreSymbol, StringComparison.Ordinal))
            {
                try
                {
                    _startParamValues = JsonConvert.DeserializeObject<List<StartParamValue>>(startValuesStr);
                }
                catch
                {
                    throw new Exception(DeviceMessages.CannotDeserializeStartValues);
                }
            }
        }

        protected override void ReadRealTimeData()
        {
            LocalArchives.Clear();
            InitStartValuesFromDynamicParameter();

            // Начинаем опрос
            _actionSteps.StartSession();
            ArchiveCollector = new ArchiveCollector(DateTime.Now, MeasurementDevice, _startParamValues);

            // Получаем тип сервера
            _actionSteps.GetData(DataType.ServerType);
            _serverType =
                (int)CallbackFunctions.GetDataCallback(Transport.Buffer, GetDataMode.ServerType);

            if (_serverType != 1 && _serverType != 0)
            {
                throw new Exception(string.Format(DeviceMessages.Vkt7WrongServerType, _serverType));
            }

            // Получаем список доступных измеряемых параметров
            _parameters =
                _actionSteps.GetReadParameters(
                    (ArchiveCollector as ArchiveCollector).ParametersCollection);

            // Получаем список единиц измерений и кол-ва точек после запятой
            RaiseTraceInfoPassedEvent(TraceMessages.GetProperties);
            _actionSteps.GetProperties();

            object tuple = CallbackFunctions.GetDataCallback(Transport.Buffer,
                GetDataMode.Properties, _serverType);

            (ArchiveCollector as ArchiveCollector).InitUnitNamesAndDecimals(tuple);

            // Анализируем какие тепловые вводы прибора активны в данной схеме
            _isFirstChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.OneHeatInput, StringComparison.Ordinal)) > 0;
            _isSecondChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.TwoHeatInput, StringComparison.Ordinal)) > 0;

            // ЧТЕНИЕ МГНОВЕННЫХ И ТЕКУЩИХ ИТОГОВЫХ
            ReadInstantArchives(false);

            var archives = ArchiveCollector.Archives;

            foreach(var a in archives)
            {
                LocalArchives.Add(a);
            }
            SendUpdateSignal(true);
        }

        protected override void Polling()
        {
            InitStartValuesFromDynamicParameter();
            // 1. Начинаем сессию
            RaiseTraceInfoPassedEvent(TraceMessages.Vkt7StartSession);
            _actionSteps.StartSession();

            // 2. Получаем заводской номер устройства
            int currentDeviceNumber = GetDeviceIdentifier();

            if (CheckFactoryNumber(currentDeviceNumber))
            {
                RaiseTraceInfoPassedEvent(TraceMessages.Vkt7GetServiceInformation);
                _actionSteps.GetServiceInformation();
                int serviceInfoLength = Transport.Buffer[2];

                byte[] serviceInfoBuf = null;
                // 3. Получаем номер версии ПО прибора
                // если длина данных больше 1 байта - имеем дело с версией ПО 1.5 и более
                if (serviceInfoLength > 1)
                {
                    serviceInfoBuf = Transport.Buffer;
                    byte firmware = Transport.Buffer[3];
                    Firmware = new Firmware(firmware >> 4, firmware & ((1 << 4) - 1));
                    MeasurementDevice.Firmware = Firmware.ToString();
                    RaiseTraceInfoPassedEvent(string.Format(TraceMessages.ActualFirmware, MeasurementDevice.Firmware));
                }
            
                // если нужно получить хотя бы один из типов архивов
                if (MeasurementDevice.GiveCurrData || MeasurementDevice.GiveDArcData ||
                    MeasurementDevice.GiveHArcData || MeasurementDevice.GiveMArcData)
                {
                    _deviceFeatures = new DeviceFeatures(Firmware);

                    // 4. Получаем отчетный день месяца для итоговых архивов
                    // если пришёл длинный ответ, значит версия ПО 1.5 и более
                    var reportingMonthDay = serviceInfoLength > 10
                        ? Transport.Buffer[17]
                        : Transport.Buffer[3];

                    MeasurementDevice.SubModel = serviceInfoLength > 10 ? Convert.ToString(Transport.Buffer[18]) : null;

                    // 5. Получаем даты
                    if (_deviceFeatures.IsGetDateIntervalSupports)
                    {
                        RaiseTraceInfoPassedEvent(TraceMessages.Vkt7GetDateInterval);
                        _actionSteps.GetDateInterval();

                        if (Transport.CurrentErrorCode != ErrorCode.VKT_GetDateIntervalError)
                        {
                            _deviceTime = new DeviceTime
                            {
                                HourArchiveStart = Transport.Buffer.GetDateTimeFromBytes(3),
                                Current = Transport.Buffer.GetDateTimeFromBytes(7),
                                DailyArchiveStart = Transport.Buffer.GetDateTimeFromBytes(11)
                            };

                            if ((_deviceTime.Current - _deviceTime.HourArchiveStart).TotalDays > 45)
                            {
                                var dt = _deviceTime.Current.AddDays(-45);
                                _deviceTime.HourArchiveStart = dt.Date;
                            }
                        }
                    }

                    DeviceTime = _deviceFeatures.IsGetDateIntervalSupports && _deviceTime != null 
                        ? _deviceTime.Current
                        : DateTime.Now;

                    ArchiveCollector = new ArchiveCollector(DeviceTime, MeasurementDevice, _startParamValues);

                    if (serviceInfoBuf != null)
                    {
                        CheckSchemes(serviceInfoBuf);
                    }

                    RaiseTraceInfoPassedEvent(TraceMessages.Vkt7GetServerType);
                    // 6. Получаем тип сервера
                    _actionSteps.GetData(DataType.ServerType);
                    _serverType =
                        (int) CallbackFunctions.GetDataCallback(Transport.Buffer, GetDataMode.ServerType);

                    RaiseTraceInfoPassedEvent(string.Format(TraceMessages.Vkt7ServerType, _serverType));

                    if (_serverType != 1 && _serverType != 0)
                    {
                        throw new Exception(string.Format(DeviceMessages.Vkt7WrongServerType, _serverType));
                    }

                    // 7. Получаем список доступных измеряемых параметров
                    _parameters =
                        _actionSteps.GetReadParameters(
                            (ArchiveCollector as ArchiveCollector).ParametersCollection);

                    // 8. Получаем список единиц измерений и кол-ва точек после запятой
                    RaiseTraceInfoPassedEvent(TraceMessages.GetProperties);
                    _actionSteps.GetProperties();

                    object tuple = CallbackFunctions.GetDataCallback(Transport.Buffer,
                        GetDataMode.Properties, _serverType);
                    
                    (ArchiveCollector as ArchiveCollector).InitUnitNamesAndDecimals(tuple);

                    // 9. Анализируем какие тепловые вводы прибора активны в данной схеме
                    _isFirstChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.OneHeatInput, StringComparison.Ordinal)) > 0;
                    _isSecondChannelActive = _parameters.Keys.Count(p => p.HeatInput.Equals(Vkt7Resources.TwoHeatInput, StringComparison.Ordinal)) > 0;

                    RaiseTraceInfoPassedEvent(string.Format(TraceMessages.Vkt7ChannelActivities, _isFirstChannelActive, _isSecondChannelActive));

                    if (_isFirstChannelActive || _isSecondChannelActive)
                    {
                        if (MeasurementDevice.GiveCurrData)
                        {
                            ReadInstantArchives(true);
                            ArchiveCollector.SaveArchives();

                            UpdateLastTimeSignatureId();
                        }

                        ReadFinalArchives(reportingMonthDay);

                        if (IsOutOfGeneratingFinalArchiveTime(reportingMonthDay))
                        {
                            ReadDayArchives();
                            ReadHourArchives();
                        }
                    }                    
                }
            }
        }

        private void CheckSchemes(byte[] buf)
        {
            var schemeInfoHelper = new SchemeInfoHelper();

            var schemeTv1 = schemeInfoHelper.ParseSchemeInfo(buf);
            var schemeTv2 = schemeInfoHelper.ParseSchemeInfo(buf, 2);

            // СИ ТВ1
            var scheme1 = DynamicParameterHelper.GetDynamicValue<int>(DynamicParameter.DeviceVkt7SchemeTv1);

            if (scheme1 != schemeTv1.SchemeNumber)
            {
                var dynParameter = DynamicParameter.DeviceVkt7SchemeTv1;
                DynamicParameterHelper.SetDynamicParameter(dynParameter, schemeTv1.SchemeNumber);

                ArchiveCollector.CreateMeasurementDeviceJournal(DateTime.Now, DynamicParameterHelper.GetDynamicParameterDescription(dynParameter),
                    scheme1 == -1 ? "" : scheme1.ToString(), schemeTv1.SchemeNumber.ToString(), InternalDeviceEvent.SchemeTv1);
            }

            // СИ ТВ2
            var scheme2 = DynamicParameterHelper.GetDynamicValue<int>(DynamicParameter.DeviceVkt7SchemeTv2);

            if (scheme2 != schemeTv2.SchemeNumber)
            {
                var dynParameter = DynamicParameter.DeviceVkt7SchemeTv2;
                DynamicParameterHelper.SetDynamicParameter(dynParameter, schemeTv2.SchemeNumber);

                ArchiveCollector.CreateMeasurementDeviceJournal(DateTime.Now, DynamicParameterHelper.GetDynamicParameterDescription(dynParameter),
                    scheme2 == -1 ? "" : scheme2.ToString(), schemeTv2.SchemeNumber.ToString(), InternalDeviceEvent.SchemeTv2);
            }

            // Т3 ТВ1
            var t3Tv1 = DynamicParameterHelper.GetDynamicValue<int>(DynamicParameter.DeviceVkt7Pipe3TargetTv1);

            if (t3Tv1 != schemeTv1.T3)
            {
                var dynParameter = DynamicParameter.DeviceVkt7Pipe3TargetTv1;
                DynamicParameterHelper.SetDynamicParameter(dynParameter, schemeTv1.T3);

                ArchiveCollector.CreateMeasurementDeviceJournal(DateTime.Now, DynamicParameterHelper.GetDynamicParameterDescription(dynParameter),
                    t3Tv1 == -1 ? "" : t3Tv1.ToString(), schemeTv1.T3.ToString(), InternalDeviceEvent.Pipe3TargetTv1);
            }

            // Т3 ТВ2
            var t3Tv2 = DynamicParameterHelper.GetDynamicValue<int>(DynamicParameter.DeviceVkt7Pipe3TargetTv2);

            if (t3Tv2 != schemeTv2.T3)
            {
                var dynParameter = DynamicParameter.DeviceVkt7Pipe3TargetTv2;
                DynamicParameterHelper.SetDynamicParameter(dynParameter, schemeTv2.T3);

                ArchiveCollector.CreateMeasurementDeviceJournal(DateTime.Now, DynamicParameterHelper.GetDynamicParameterDescription(dynParameter),
                    t3Tv2 == -1 ? "" : t3Tv2.ToString(), schemeTv2.T3.ToString(), InternalDeviceEvent.Pipe3TargetTv2);
            }

            // t5 ТВ1
            var t5Tv1 = DynamicParameterHelper.GetDynamicValue<int>(DynamicParameter.DeviceVkt7t5TargetTv1);

            if (t5Tv1 != schemeTv1.t5)
            {
                var dynParameter = DynamicParameter.DeviceVkt7t5TargetTv1;
                DynamicParameterHelper.SetDynamicParameter(dynParameter, schemeTv1.t5);

                ArchiveCollector.CreateMeasurementDeviceJournal(DateTime.Now, DynamicParameterHelper.GetDynamicParameterDescription(dynParameter),
                   t5Tv1 == -1 ? "" : t5Tv1.ToString(), schemeTv1.t5.ToString(), InternalDeviceEvent.t5TargetTv1);
            }

            // t5 ТВ2
            var t5Tv2 = DynamicParameterHelper.GetDynamicValue<int>(DynamicParameter.DeviceVkt7t5TargetTv2);

            if (t5Tv2 != schemeTv2.t5)
            {
                var dynParameter = DynamicParameter.DeviceVkt7t5TargetTv2;
                DynamicParameterHelper.SetDynamicParameter(dynParameter, schemeTv2.t5);

                ArchiveCollector.CreateMeasurementDeviceJournal(DateTime.Now, DynamicParameterHelper.GetDynamicParameterDescription(dynParameter),
                   t5Tv2 == -1 ? "" : t5Tv2.ToString(), schemeTv2.t5.ToString(), InternalDeviceEvent.t5TargetTv2);
            }

            if (ArchiveCollector.MeasurementDeviceJournals.Any())
            {
                ArchiveCollector.SaveArchives();
            }
        }

        /// <summary>
        /// Определяет нахождение текущего приборного времени за пределами диапазона времени генерации итогового месячного отчета
        /// (например, 30.06.2015 23:00 - 01.07.2015 01:00)
        /// </summary>
        /// <param name="reportingMonthDay">Отчетный день</param>
        private bool IsOutOfGeneratingFinalArchiveTime(int reportingMonthDay)
        {
            var nearestFinalDate = ArchiveReadConditionHelper.CalculateFinalArchiveDate(DeviceTime, reportingMonthDay);
            var deadDateBegin = nearestFinalDate.AddHours(23);
            var deadDateEnd = nearestFinalDate.AddDays(1).AddHours(1);

            return !(DeviceTime >= deadDateBegin && DeviceTime <= deadDateEnd);
        }
    }
}



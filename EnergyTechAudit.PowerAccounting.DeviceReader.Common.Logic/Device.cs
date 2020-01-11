using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Data.Entity;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.EventArgs;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Csd;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using PeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.PeriodType;
using TypeConnection = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.TypeConnection;
using DynamicParameter = EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries.DynamicParameter;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using EnergyTechAudit.PowerAccounting.LightDataAccess;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    /// <summary>
    /// Базовый класс измерительных устройств
    /// </summary>
    public partial class Device : IDevice, IDisposable, ICheckConnectionExistence, IReadCurrents, IExecuteExtension
    {
        public MeasurementDevice MeasurementDevice;

        protected ArchiveCollectorBase ArchiveCollector;

        public ArchiveCollectorBase GetArchiveCollector()
        {
            return ArchiveCollector;
        }

        protected readonly List<ValueInfo> LocalArchives;
        protected List<DynamicParameterValue> DynamicDataValues;
        protected string EntityTypeName;
        protected ManualResetEvent ManualResetEvent;
        protected DeviceTransport Transport;
        protected DeviceModel DeviceModel;
        protected PortType PortType;
        protected TypeConnection MeasurementDeviceTypeConnection;
        private List<ScheduleItem> _scheduleItems;

        // Слепок модели устройства
        public DeviceSnip DeviceSnip;

        private TcpClient _preparedTcpClient;
        
        protected LightDatabaseContext Context;
        public LightDatabaseContext GetContext()
        {
            return Context;
        }

        protected LogHelper LogHelper;
        public LogHelper GetLogHelper()
        {
            return LogHelper;
        }

        private readonly ServerCommunicatorHelper _serverCommunicatorHelper;

        private readonly ConnectionQualityHelper _conQualHelper;
        private readonly DeviceReaderCache _deviceReaderCache;
        private List<MeasurementDeviceStatusConnectionLog> MeasurementDeviceStatusConnectionLogs;

        protected DateTime DeviceTime = default(DateTime);

        /// <summary>
        /// Вспомогательный класс для работы с динамическими параметрами
        /// </summary>
        protected DynamicParameterHelper DynamicParameterHelper;

        /// <summary>
        /// Флаг инициации сброса опроса
        /// </summary>
        public bool IsManualReset
        {
            set
            {
                if (Transport != null)
                {
                    Transport.IsManualReset = value;
                }
            }
        }

        // текущая версия ПО прибора
        protected Firmware Firmware;

        private readonly ConfigureActionSteps _configureActionSteps;

        // по умолчанию считаем, что транспортный сервер не сконфигурирован
        protected TransportServerConfigurationStatus ConfigurationStatus = TransportServerConfigurationStatus.FailureConfiguration;

        // были ли фатальные ошибки инициализации устройства
        private readonly bool _hasFaultInitErrors;

        // событие возникновения трейсовой информации
        public delegate void TraceInfoPassHandler(object sender, TraceEventArgs e);

        public event TraceInfoPassHandler TraceInfoPassed;

        private DateTime _traceDateTime;
        protected void RaiseTraceInfoPassedEvent(string text, TraceCommand traceCommand = TraceCommand.CurrentStatus)
        {
#if DEBUG   
            try
            {
                string path = string.Format(@"C:\Dump\{0}_{1}_{2}.txt", _traceDateTime.ToString("s").Replace(":", "-"),
                    MeasurementDevice.Id,
                    MeasurementDevice.Description);
                File.AppendAllText(path,
                    string.Format("{0}: {1}{2}", DateTime.Now, text, Environment.NewLine));
            }
            catch { }
#endif

            if (TraceInfoPassed != null)
            {
                TraceInfoPassed(this, new TraceEventArgs
                {
                    Command = traceCommand,
                    DeviceId = MeasurementDevice.Id,
                    Text = text,
                    Time = DateTime.Now
                });
            }
        }

        public Device(int deviceId, DeviceReaderCache deviceReaderCache, TcpClient preparedTcpClient) : this(deviceId, deviceReaderCache)
        {
            _preparedTcpClient = preparedTcpClient;
        }

        public Device(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings, int deviceReaderId) :
            this (device, preparedTcpClient, serverCommunicatorSettings)
        {
            if (device != null)
            {
                var deviceReaderCache = new DeviceReaderCache(deviceReaderId);
                DynamicParameterHelper = new DynamicParameterHelper(MeasurementDevice, deviceReaderCache.DynamicParameters);

                InitTransport();
            }
        }

        public Device(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings) : this(device)
        {
            if (serverCommunicatorSettings != null)
            {
                _serverCommunicatorHelper = new ServerCommunicatorHelper(serverCommunicatorSettings);
            }

            _preparedTcpClient = preparedTcpClient;
        }

        protected readonly EmergencyEngine EmergencyEngine;

        protected AccessPointInfo ApI;

        private void InitMeasurementDeviceTypeConnection(int? deviceReaderId)
        {
            if (deviceReaderId != null)
            {
                var deviceReader = Context.Set<LightDataAccess.Business.DeviceReader>().FirstOrDefault(p => p.Id == deviceReaderId);
                if (deviceReader == null || (deviceReader != null && deviceReader.DeviceReaderTypeId == (int)DeviceReaderType.Client))
                {
                    MeasurementDeviceTypeConnection = TypeConnection.Client;
                }
                else
                {
                    MeasurementDeviceTypeConnection = TypeConnection.Server;
                }
            }
            else
            {
                MeasurementDeviceTypeConnection = TypeConnection.Client;
            }
        }

        public Device(int deviceId, DeviceReaderCache deviceReaderCache = null)
        {
            _traceDateTime = DateTime.Now;
            _deviceReaderCache = deviceReaderCache;
            Console.OutputEncoding = Encoding.Unicode;
            LocalArchives = new List<ValueInfo>();

            Context = new LightDatabaseContext();

            using (var transaction = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            { 
                try
                {
                    MeasurementDevice = Context.Set<MeasurementDevice>().FirstOrDefault(y => y.Id == deviceId);

                    // подгрузка каналов прибора
                    Context.Set<Channel>().Where(p => p.MeasurementDeviceId == deviceId).Load();

                    if (MeasurementDevice != null && MeasurementDevice.AccessPointId != null)
                    {
                        var accessPoint = Context.Set<AccessPoint>().First(p => p.Id == MeasurementDevice.AccessPointId.Value);

                        // подгружаем элементы расписания для опроса прибора по заданному интервалу
                        var measurementDeviceLinkScheduleItems = Context.Set<MeasurementDeviceLinkScheduleItem>().Where(p => p.MeasurementDeviceId == deviceId).ToList();

                        if (measurementDeviceLinkScheduleItems.Count > 0)
                        {
                            var scheduleItemIds = measurementDeviceLinkScheduleItems.Select(p => p.ScheduleItemId).ToList();
                            Context.Set<LightDataAccess.Dictionaries.ScheduleType>().Load();
                            _scheduleItems = Context.Set<ScheduleItem>().Where(p => scheduleItemIds.Contains(p.Id)).ToList();
                        }

                        InitMeasurementDeviceTypeConnection(accessPoint.DeviceReaderId);

                        ApI = new AccessPointInfo();
                        ApI.AccessPoint = accessPoint;

                        if (accessPoint.CsdModemId != null)
                        {
                            ApI.CsdModem = _deviceReaderCache.CsdModems.First(p => p.Id == accessPoint.CsdModemId.Value);
                            ApI.CsdModemDeviceSnip = _deviceReaderCache.DeviceSnips.First(p => p.Id == ApI.CsdModem.DeviceId);
                        }
                    }

                    MeasurementDeviceStatusConnectionLogs = Context.Set<MeasurementDeviceStatusConnectionLog>().Where(p => p.MeasurementDeviceId == deviceId).ToList();

                    Context.Configuration.AutoDetectChangesEnabled = true;

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    var e = ex;
                    MeasurementDevice = null;
                    transaction.Rollback();
                }
            }

            if (MeasurementDevice != null)
            {
                DeviceSnip = _deviceReaderCache.GetDeviceSnip(MeasurementDevice.DeviceId);

                DynamicParameterHelper = new DynamicParameterHelper(MeasurementDevice, deviceReaderCache.DynamicParameters);

                DeviceModel = (DeviceModel)MeasurementDevice.DeviceId;
                PortType = (PortType)MeasurementDevice.PortTypeId;

                if (MeasurementDevice.AccessPoint != null)
                {
                    Context.Set<LightDataAccess.Dictionaries.TransportServerModel>().FirstOrDefault(p => p.Id == MeasurementDevice.AccessPoint.TransportServerModelId);
                    LogHelper = new LogHelper(deviceId, LogEntityType.MeasurementDevice);

                    EmergencyEngine = new EmergencyEngine(MeasurementDevice, ApI.AccessPoint, deviceReaderCache, LogHelper);

                    _serverCommunicatorHelper = new ServerCommunicatorHelper(deviceReaderCache.ServerCommunicatorSettings);

                    _configureActionSteps = new ConfigureActionSteps();

                    _conQualHelper = new ConnectionQualityHelper(MeasurementDevice);

                    InitTransport();
                }
                else
                {
                    _hasFaultInitErrors = true;
                    LogHelper = new LogHelper(deviceId, LogEntityType.MeasurementDevice);
                    LogHelper.CreateLog(DeviceMessages.MissingAccessPoint, ErrorType.MissingAccessPoint);
                    LogHelper.SaveLogs();
                }
            }
        }

        void _configureActionSteps_TraceInfoPassed(object sender, ConnectionServerEventArgs e)
        {
            RaiseTraceInfoPassedEvent(e.Text);
        }

        /// <summary>
        /// Завершает опрос: закрывает последовательный порт, если он был открыт;
        /// устанавливает сигнал главного потока
        /// </summary>
        private void EndPolling()
        {
            if (Transport != null)
            {
                Transport.CloseSerialPort();
                Transport.CloseTcpClient();
            }
        }

        public bool Execute()
        {
#if !DEBUG
            // проверяем есть ли заданное расписание опроса и можно ли опрашивать в текущий момент
            if (_scheduleItems != null && _scheduleItems.Count > 0)
            {
                var canExecute = ScheduleItem.CheckSchelude(_scheduleItems);

                if (!canExecute) return true;
            }
#endif

            if (MeasurementDevice != null && MeasurementDevice.AccessPoint != null & !_hasFaultInitErrors)
            {
                if (MeasurementDevice.AccessPoint.TransportTypeId == (int)TransportTypes.CSD)
                {
                    RunViaCsd();
                }
                else if (MeasurementDevice.AccessPoint.TransportServerModelId == (int)TransportServerModel.Virtual)
                {
                    CalculatorExtensions.SetLastConnectionParams(MeasurementDevice);
                    Polling();
                    _conQualHelper.SetSuccessConnectionStatus();
                }
                else if (MeasurementDevice.AccessPoint.TransportServerModelId == (int)TransportServerModel.Strij)
                {
                    Polling();
                }
                else
                {
                    Run();
                }

                PostPollingActions();

                return true;
            }

            return false;
        }

        private string _csdModemDeviceCode;

        private string CsdModemDeviceCode
        {
            get
            {
                if (string.IsNullOrEmpty(_csdModemDeviceCode))
                {
                    if (ApI.CsdModemDeviceSnip != null)
                    {
                        _csdModemDeviceCode = ApI.CsdModemDeviceSnip.Code;
                    }
                }
                return _csdModemDeviceCode;
            }
        }

        /// <summary>
        /// Запускает опрос с использованием технологии CSD (Circuit Switched Data)
        /// </summary>
        private void RunViaCsd()
        {
            if (!CheckCsdPrePollingConditions())
            {
                MeasurementDevice.LastConnectionTime = DateTime.Now;
                return;
            }

            CalculatorExtensions.SetLastConnectionParams(MeasurementDevice);

            try
            {
                if (Transport.InitConnection())
                {
                    RaiseTraceInfoPassedEvent(DeviceMessages.TestHangUpCall);
                    // предварительно кладём трубку модема или настраиваем модем
                    if (CsdModemDeviceCode.Equals("MaestroEvo100", StringComparison.Ordinal))
                    {
                        TuneModemBeforeCall();
                    }
                    else
                    {
                        HangUp();
                        ResetModem();
                    }                    

                    Transport.CloseSerialPort();

                    if (Transport.InitConnection())
                    {
                        RaiseTraceInfoPassedEvent(string.Format(DeviceMessages.MakeCall,
                            MeasurementDevice.AccessPoint.NetPhone));
                        if (Call() != CallResult.Ok)
                        {
                            throw new WrongMakeCallException();
                        }

                        _conQualHelper.SetAccessPointStatusConnectionLog(true, MeasurementDevice.AccessPointId);

                        RaiseTraceInfoPassedEvent(DeviceMessages.CallerPickedUp);
                        // переходим в прозрачный режим
                        Transport.IsCsdCommandMode = false;

                        Polling();

                        // переходим в командный режим
                        Transport.IsCsdCommandMode = true;

                        RaiseTraceInfoPassedEvent(DeviceMessages.AbortCurrentCall);
                        if (HangUp() == CallResult.Ok)
                        {
                            RaiseTraceInfoPassedEvent(DeviceMessages.HangUpCall);
                        }

                        _conQualHelper.SetSuccessConnectionStatus();
                        RaiseTraceInfoPassedEvent(DeviceMessages.SuccessConnectionStatus);
                    }
                    else
                    {
                        _conQualHelper.SetAccessPointStatusConnectionLog(false, MeasurementDevice.AccessPointId);
                        _conQualHelper.SetFailConnectionStatus();
                        RaiseTraceInfoPassedEvent(DeviceMessages.FailConnectionStatus);
                    }
                }
                else
                {
                    _conQualHelper.SetAccessPointStatusConnectionLog(false, MeasurementDevice.AccessPointId);
                    _conQualHelper.SetFailConnectionStatus();
                    RaiseTraceInfoPassedEvent(DeviceMessages.FailConnectionStatus);
                }
            }
            catch (WrongMakeCallException ex)
            {
                HangUp();
                _conQualHelper.SetAccessPointStatusConnectionLog(false, MeasurementDevice.AccessPointId);
                _conQualHelper.SetFailConnectionStatus();

                var text = string.Format(DeviceMessages.WrongMakeCall, MeasurementDevice.AccessPoint.NetPhone);
                LogHelper.CreateLog(text, ErrorType.WrongMakeCallException, ex);
                RaiseTraceInfoPassedEvent(text);
            }
            catch (ReadUncommittedException ex)
            {
                _conQualHelper.SetLostConnectionStatus();
                LogHelper.CreateLog(ex.Message, ErrorType.DbTransactionReadUncommitted, ex);
                RaiseTraceInfoPassedEvent(ex.Message);
            }
            catch (ManualResetException ex)
            {
                HangUp();
                _conQualHelper.SetSuccessConnectionStatus();
                LogHelper.CreateLog(DeviceMessages.ManualResetPolling, ErrorType.ManualResetPolling, ex);
                RaiseTraceInfoPassedEvent(DeviceMessages.ManualResetPolling);
            }
            catch (ErrorDeviceResponseException ex)
            {
                HangUp();
                _conQualHelper.SetFailConnectionStatus();
                LogHelper.CreateLog(ex.Info, ErrorType.ErrorDeviceResponse, ex);

                RaiseTraceInfoPassedEvent(DeviceMessages.ErrorDeviceResponse);
            }
            catch (LostConnectionException ex)
            {
                _conQualHelper.SetLostConnectionStatus();

                if (!string.IsNullOrEmpty(ex.Info))
                {
                    RaiseTraceInfoPassedEvent(ex.Info);
                    LogHelper.CreateLog(ex.Info, ErrorType.PollingError, ex);
                }

                Transport.IsLostConnectionRaised = false;
                // сбрасываем флаг, чтобы можно было принимать данные на COM-порт
                HangUp();
            }
            catch (SocketException)
            {
                HangUp();
                _conQualHelper.SetFailConnectionStatus();
                RaiseTraceInfoPassedEvent(DeviceMessages.SocketException);
            }
            catch (WrongFactoryNumberException ex)
            {
                HangUp();
                _conQualHelper.SetLostConnectionStatus();
                LogHelper.CreateLog(DeviceMessages.WrongFactoryNumber, ErrorType.WrongFactoryNumberException, ex);
            }
            catch (Exception ex)
            {
                HangUp();
                LogHelper.CreateLog(DeviceMessages.ExceptionRaised, ErrorType.Unknown, ex);
                _conQualHelper.SetFailConnectionStatus();
                RaiseTraceInfoPassedEvent(DeviceMessages.FailConnectionStatus);
            }
        }

        private bool CheckCsdPrePollingConditions()
        {
            var conditionDynamicParameter = GetDynamicParameterValue(Types.Proxy.DynamicParameter.DeviceReadOnlyDayArchivesViaCsd);
            if (conditionDynamicParameter != null)
            {
               var readOnlyDayArchives = Convert.ToBoolean(conditionDynamicParameter.Value);
                if (readOnlyDayArchives)
                {
                    var dayArchive = GetLastArchiveByPeriod(PeriodType.Day);
                    var hourArchive = GetLastArchiveByPeriod(PeriodType.Hour);

                    if (MeasurementDevice.GiveHArcData)
                    {
                        if(hourArchive == null || (hourArchive != null && !hourArchive.Time.IsToday()))
                        {
                            return true;
                        }
                    }

                    if (dayArchive != null && dayArchive.Time.IsToday())
                    {
                        RaiseTraceInfoPassedEvent(DeviceMessages.ReadOnlyDayArchivesViaCsd);
                        return false;
                    }
                }
            }

            return true;
        }

        public void RunRealTime()
        {
            ConfigureTransportServer();

            if (ConfigurationStatus == TransportServerConfigurationStatus.SuccessfullyConfigured)
            {
                if (Transport.InitConnection(_preparedTcpClient))
                {
                    try
                    {
                        ReadRealTimeData();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                EndPolling();
            }
        }

        /// <summary>
        /// Запускает опрос с использованием технологии Ethernet, либо прямой опрос через Com-порт
        /// </summary>
        private void Run()
        {
            ConfigureTransportServer();

            // устанавливаем время последнего подключения только для точек доступа типа "Клиент"
            if (MeasurementDeviceTypeConnection == TypeConnection.Client)
            {
                CalculatorExtensions.SetLastConnectionParams(MeasurementDevice.AccessPoint);
            }

            if (ConfigurationStatus == TransportServerConfigurationStatus.SuccessfullyConfigured)
            {
                RaiseTraceInfoPassedEvent(DeviceMessages.DeviceConnection);

                CalculatorExtensions.SetLastConnectionParams(MeasurementDevice);

                if (Transport.InitConnection(_preparedTcpClient))
                {
                    _conQualHelper.SetAccessPointStatusConnectionLog(true, MeasurementDevice.AccessPointId);
                    try
                    {
                        Polling();

                        _conQualHelper.SetSuccessConnectionStatus();
                        RaiseTraceInfoPassedEvent(DeviceMessages.SuccessConnectionStatus);
                    }
                    catch (Vkt7WrongDecimalException ex)
                    {
                        _conQualHelper.SetLostConnectionStatus();
                        LogHelper.CreateLog(string.Format(DeviceMessages.Vkt7WrongDecimals, ex.Message, ex.QualityByte, ex.EmerByte),
                                            ErrorType.SpecificDeviceError, ex);
                        RaiseTraceInfoPassedEvent(DeviceMessages.Vkt7WrongDecimalsInfo);
                    }
                    catch (ReadUncommittedException ex)
                    {
                        _conQualHelper.SetLostConnectionStatus();
                        LogHelper.CreateLog(ex.Message, ErrorType.DbTransactionReadUncommitted, ex);
                        RaiseTraceInfoPassedEvent(ex.Message);
                    }
                    catch(Vkt7SaveArchiveException ex)
                    {
                        _conQualHelper.SetLostConnectionStatus();
                        LogHelper.CreateLog(ex.Message, ErrorType.Vkt7SaveArchiveError);
                        RaiseTraceInfoPassedEvent(ex.Message);
                    }
                    catch (ManualResetException ex)
                    {
                        _conQualHelper.SetSuccessConnectionStatus();
                        LogHelper.CreateLog(DeviceMessages.ManualResetPolling, ErrorType.ManualResetPolling, ex);
                        RaiseTraceInfoPassedEvent(DeviceMessages.ManualResetPolling);
                    }
                    catch (ErrorDeviceResponseException ex)
                    {
                        _conQualHelper.SetLostConnectionStatus();
                        LogHelper.CreateLog(ex.Info, ErrorType.ErrorDeviceResponse, ex);

                        RaiseTraceInfoPassedEvent(DeviceMessages.ErrorDeviceResponse);
                    }
                    catch (LostConnectionException ex)
                    {
                        _conQualHelper.SetLostConnectionStatus();
                        
                        if (!string.IsNullOrEmpty(ex.Info))
                        {
                            RaiseTraceInfoPassedEvent(ex.Info);
                            LogHelper.CreateLog(ex.Info, ErrorType.PollingError, ex);
                        }
                    }
                    catch (SocketException)
                    {
                        _conQualHelper.SetLostConnectionStatus();
                        RaiseTraceInfoPassedEvent(DeviceMessages.SocketException);
                    }
                    catch (WrongFactoryNumberException ex)
                    {
                        _conQualHelper.SetLostConnectionStatus();
                        LogHelper.CreateLog(DeviceMessages.WrongFactoryNumber, ErrorType.WrongFactoryNumberException, ex);
                    }
                    catch(TypedException ex)
                    {
                        LogHelper.CreateLog(ex.Message, ex.ErrorCode, ex);
                        _conQualHelper.SetLostConnectionStatus();
                        RaiseTraceInfoPassedEvent(DeviceMessages.FailConnectionStatus);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.CreateLog(DeviceMessages.ExceptionRaised, ErrorType.Unknown, ex);
                        _conQualHelper.SetLostConnectionStatus();
                        RaiseTraceInfoPassedEvent(DeviceMessages.FailConnectionStatus);
                    }
                }
                else
                {
                    if (!IsTransportServerModelBars() && !IsTransportServerModelLers())
                    {
                        _conQualHelper.SetAccessPointStatusConnectionLog(false, MeasurementDevice.AccessPointId);
                    }
                    _conQualHelper.SetFailConnectionStatus();
                    RaiseTraceInfoPassedEvent(DeviceMessages.FailConnectionStatus);
                }
            }
            else
            {
                string transportServerModelCode = _dictionaryCache.GetTransportServerModelCode(ApI.AccessPoint.TransportServerModelId);

                if ((transportServerModelCode.Equals(ConnectionServerMessages.WIZ107SR) || transportServerModelCode.Equals(ConnectionServerMessages.WIZ108SR)) &&
                    ConfigurationStatus == TransportServerConfigurationStatus.NoConnection)
                {
                    _conQualHelper.SetAccessPointStatusConnectionLog(false, MeasurementDevice.AccessPointId);
                    _conQualHelper.SetFailConnectionStatus();
                }
                else
                {
                    _conQualHelper.SetLostConnectionStatus();
                }
#if DEBUG
                Console.WriteLine("Неудачное конфигурирование точки доступа");
#endif
                LogHelper.CreateLog(DeviceMessages.AccessPointWrongConfiguration);
                CalculatorExtensions.SetLastConnectionParams(MeasurementDevice);
                RaiseTraceInfoPassedEvent(DeviceMessages.AccessPointWrongConfiguration);
            }
        }

        /// <summary>
        /// Обновляет идентификатор последней временной отметки
        /// </summary>
        public void UpdateLastTimeSignatureId()
        {
            if (ArchiveCollector != null && 
                ArchiveCollector.TimeSignature != null &&
                ArchiveCollector.TimeSignature.Id > 0)
            {
                MeasurementDevice.LastTimeSignatureId = ArchiveCollector.TimeSignature.Id;
                SaveState();
                SendUpdateSignal();
            }
        }

        public void SendUpdateSignal(bool isSendInstantValuesToMnemoscheme = false)
        {
            if (_serverCommunicatorHelper != null)
            {
                if (!isSendInstantValuesToMnemoscheme)
                {
                    isSendInstantValuesToMnemoscheme = DynamicParameterHelper.GetDynamicValue<bool>(Types.Proxy.DynamicParameter.DeviceSendInstantValuesToMnemoschemeViaSignalR, true);
                }

                if (isSendInstantValuesToMnemoscheme)
                {
                    MnemoschemeParametersInfo info = new MnemoschemeParametersInfo();
                    info.Parameters = GenerateParametersList();
                    info.MeasurementDevices = new int[] { MeasurementDevice.Id };
                    info.IsPartialUpdateKey = true;
                    _serverCommunicatorHelper.SendUpdateMnemoschemeDataSignal(MeasurementDevice.Id, info);
                }
                else
                {
                    _serverCommunicatorHelper.SendUpdateInstantDataSignal(MeasurementDevice);
                }
            }
        }

        private List<MnemoschemeParameter> GenerateParametersList()
        {
            var parameters = new List<MnemoschemeParameter>();

            foreach(var channel in MeasurementDevice.Channels)
            {
                var templateParameters = _deviceReaderCache.ChannelTemplates.Where(p => p.ChannelTemplateId == channel.ChannelTemplateId && (p.PeriodTypeId == (int)PeriodType.Instant || p.PeriodTypeId == (int)PeriodType.FinalInstant)).ToList();

                foreach(var templateParameter in templateParameters)
                {
                    var archive = LocalArchives.FirstOrDefault(p => (p.PeriodType == PeriodType.Instant || p.PeriodType == PeriodType.FinalInstant) && p.DeviceParameterId == templateParameter.DeviceParameterId);

                    if (archive != null)
                    {
                        var parameter = new MnemoschemeParameter();
                        parameter.ChannelId = channel.Id;
                        parameter.ChannelTemplateId = channel.ChannelTemplateId;
                        parameter.DeviceId = (int)DeviceModel;
                        
                        if (templateParameter.ParameterDictionaryId != null)
                        {
                            var parameterDictionaryValue = _deviceReaderCache.ParameterDictionaryValues
                                .FirstOrDefault(p => p.ParameterDictionaryId == templateParameter.ParameterDictionaryId.Value && p.Value == archive.Value);

                            if (parameterDictionaryValue != null)
                            {
                                parameter.DictionaryValueCode = parameterDictionaryValue.Code;
                                parameter.DictionaryValueDescription = parameterDictionaryValue.Description;
                            }
                        }

                        parameter.DimensionPrefix = _deviceReaderCache.Dimensions.First(p => p.Id == templateParameter.DimensionId).Prefix;
                        parameter.Id = templateParameter.Id;
                        parameter.MeasurementDeviceId = MeasurementDevice.Id;
                        parameter.MeasurementUnitDescription = _deviceReaderCache.MeasurementUnits.First(p => p.Id == templateParameter.MeasurementUnitId).Description;
                        parameter.ParameterCode = _deviceReaderCache.Parameters.First(p => p.Id == templateParameter.ParameterId).Code;
                        parameter.ParameterDescription = _deviceReaderCache.Parameters.First(p => p.Id == templateParameter.ParameterId).Description;

                        var physicalParameterId = _deviceReaderCache.Parameters.First(p => p.Id == templateParameter.ParameterId).PhysicalParameterId;
                        parameter.PhysicalParameterCode = _deviceReaderCache.PhysicalParameters.First(p => p.Id == physicalParameterId).Code;
                        parameter.Time = archive.Time;
                        parameter.Value = archive.Value;
                        parameter.IsValid = archive.IsValid;

                        parameters.Add(parameter);
                    }
                }
            }

            return parameters;
        }

        /// <summary>
        /// Выполняет действия после опроса прибора
        /// </summary>
        private void PostPollingActions()
        {
            TransportServerAfterPollingAction();

            if (Transport != null)
            {
                Transport.WaitTimerClear();
            }

            DevicePostPollingActions();

            AddMeasurementDeviceStatusConnectionLog();

            AnalyzeEmergency();

            SaveState();

            // не надо рвать связь, а поддерживать, если модем сам вышел на связь
            if ((IsTransportServerEtaModem() || IsTransportServerModelBars()) && MeasurementDeviceTypeConnection == TypeConnection.Server)
            {

            }
            else
            {
                EndPolling();
            }

            RaiseTraceInfoPassedEvent("EndPolling");
        }

        /// <summary>
        /// Обновление статуса последнего подключения прибора как "Нет связи", если прибор подключен через GSM-модем
        /// и модем не выходит на связь уже более суток
        /// </summary>
        private void UpdateLastConnectionParamsViaGsmModem()
        {
            var lastgsmModemConnection = MeasurementDevice.AccessPoint.LastConnectionTime;
            StatusConnection gsmModemLastStatusConnection = (StatusConnection)MeasurementDevice.AccessPoint.LastStatusConnectionId;

            var now = DateTime.Now;
            var ts = now - lastgsmModemConnection;
            // если последнее успешное подключение Барса было 60 часов назад, то фиксируем в записи прибора, что "Нет связи";
            // также точке доступа Барс пробиваем статус "Нет связи" и фиксируем время в поле "Время последнего опроса".
            if ((ts.TotalHours > 60 && (gsmModemLastStatusConnection == StatusConnection.Success || gsmModemLastStatusConnection == StatusConnection.Loss)) || gsmModemLastStatusConnection == StatusConnection.Fail)
            {
                CalculatorExtensions.SetLastConnectionParams(MeasurementDevice.AccessPoint);
                CalculatorExtensions.SetLastConnectionParams(MeasurementDevice);

                _conQualHelper.SetAccessPointStatusConnectionLog(false, MeasurementDevice.AccessPointId);
                _conQualHelper.SetFailConnectionStatus();

                AddMeasurementDeviceStatusConnectionLog();
            }
            else
            {
                var deviceLastConnectionTime = MeasurementDevice.LastConnectionTime;
                var spanAfterLastPolling = now - deviceLastConnectionTime;

                if((MeasurementDevice.PollingInterval <= 180 && spanAfterLastPolling.TotalMinutes > 180) || 
                    (MeasurementDevice.PollingInterval > 180 && spanAfterLastPolling.TotalMinutes > MeasurementDevice.PollingInterval * 3))
                {
                    CalculatorExtensions.SetLastConnectionParams(MeasurementDevice);
                    _conQualHelper.SetFailConnectionStatus();
                    AddMeasurementDeviceStatusConnectionLog();
                }
            }

            SaveState();
            RaiseTraceInfoPassedEvent("EndPolling");
        }

        private void AnalyzeEmergency()
        {
            try
            {
                if (EmergencyEngine != null)
                {
                    EmergencyEngine.DeviceTime = DeviceTime;

                    if (ArchiveCollector != null)
                    {
                        EmergencyEngine.TimeSignature = ArchiveCollector.TimeSignature;
                    }

                    EmergencyEngine.CollectValuesForScope();
                    EmergencyEngine.Analyze();
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private CallResult Call()
        {
            var csdStation = new CsdStation(Transport, ApI.AccessPoint, CsdModemDeviceCode);
            return csdStation.Call();
        }

        private bool ResetModem()
        {
            var csdStation = new CsdStation(Transport, ApI.AccessPoint, CsdModemDeviceCode);
            return csdStation.ResetModem();
        }

        private CallResult TuneModemBeforeCall()
        {
            // переходим в командный режим
            Transport.IsCsdCommandMode = true;

            var csdStation = new CsdStation(Transport, ApI.AccessPoint, CsdModemDeviceCode);

            var callResult = CallResult.Unknown;
            
            RaiseTraceInfoPassedEvent(string.Format(DeviceMessages.CsdTuneModemBeforeCall));
            callResult = csdStation.TuneModemBeforeCall();
            
            return callResult;
        }

        private CallResult HangUp()
        {
            // переходим в командный режим
            Transport.IsCsdCommandMode = true;

            var csdStation = new CsdStation(Transport, ApI.AccessPoint, CsdModemDeviceCode);
            
            var callResult = CallResult.Unknown;
            int maxHangUpAttempts = 5;
            int countAttempts = 1;
            while(callResult != CallResult.Ok && countAttempts <= maxHangUpAttempts)
            {
               RaiseTraceInfoPassedEvent(string.Format(DeviceMessages.CsdHangUpAttemptNumber, countAttempts));
               callResult = csdStation.HangUp();
               countAttempts++;
               if(callResult != CallResult.Ok)
               {
                   Thread.Sleep(5000);
               }
            }
            return callResult;
        }

        /// <summary>
        /// Добавляет объект о текущем состоянии подключения к прибору
        /// </summary>
        protected void AddMeasurementDeviceStatusConnectionLog()
        {
            if (Context != null)
            {
                Context.Set<MeasurementDeviceStatusConnectionLog>().Add(new MeasurementDeviceStatusConnectionLog
                {
                    MeasurementDeviceId = MeasurementDevice.Id,
                    StatusConnectionId = MeasurementDevice.LastStatusConnectionId,
                    ConnectionTime = DateTime.Now
                });

                var count = MeasurementDeviceStatusConnectionLogs.Count();
                var successCount = MeasurementDeviceStatusConnectionLogs.Count(p => (StatusConnection)p.StatusConnectionId == StatusConnection.Success);

                if(count != 0)
                {
                    MeasurementDevice.SuccessConnectionPercent = Math.Round(((double)successCount / (double)count) * 100, 2);
                }
                else
                {
                    MeasurementDevice.SuccessConnectionPercent = 0;
                }
            }
        }

        /// <summary>
        /// Проверяет существование значений обязательных динамических параметров прибора
        /// </summary>
        protected void CheckExistDynamicDataValues()
        {
            // делаем запрос на динамические параметры, которые могут быть у прибора
            var deviceDynamicParameters = Context.Set<DeviceLinkDynamicParameter>()
                .Where(p => p.DeviceId == MeasurementDevice.DeviceId)
                .Select(p => p.DynamicParameterId).ToList();

            // определяем обязательные динамические параметры с их значениями по умолчанию
            var requiedDynamicParametersWithDefaults = Context.Set<DynamicParameter>()
                                           .Where(p => deviceDynamicParameters.Contains(p.Id) && p.IsDefault)
                                           .Select(p => new { p.Id, p.DefaultValue }).ToList();

            // выделяем в отдельный массив список идентификаторов обязательных динамических параметров
            var requiedDynamicParameters = requiedDynamicParametersWithDefaults.Select(p => p.Id).ToList();

            // находим уже созданные значения обязательных динамических параметров
            var existDynamicParameters = Context.Set<DynamicParameterValue>()
                .Where(p => requiedDynamicParameters.Contains(p.DynamicParameterId) && p.EntityId == MeasurementDevice.Id)
                .Select(p => p.DynamicParameterId).ToList();

            // определяем отсутствующие обязательные динамические параметры
            var absentDynamicParameters = requiedDynamicParameters.Except(existDynamicParameters).ToList();

            if (absentDynamicParameters.Count > 0)
            {
                foreach (var absentDynamicParameter in absentDynamicParameters)
                {
                    Context.Set<DynamicParameterValue>().Add(
                        new DynamicParameterValue
                        {
                            EntityId = MeasurementDevice.Id,
                            DynamicParameterId = absentDynamicParameter,
                            Value =
                                requiedDynamicParametersWithDefaults.First(p => p.Id == absentDynamicParameter)
                                    .DefaultValue
                        });
                }

                using (var tran = Context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        Context.SaveChanges();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception(DeviceMessages.CheckExistDynamicDataValuesError);
                    }
                }
            }
        }

        /// <summary>
        /// Инициализирует значения динамических параметров
        /// </summary>
        /// <param name="dynamicParameterIds"></param>
        protected void InitDynamicDataValues(int[] dynamicParameterIds)
        {
            DynamicDataValues = Context.Set<DynamicParameterValue>()
                .Include("DynamicParameter")
                .Where(p => dynamicParameterIds.Contains(p.DynamicParameterId) && p.EntityId == MeasurementDevice.Id).ToList();
        }

        /// <summary>
        /// Задержка перед началом выполнения опроса
        /// </summary>
        protected void DelayBeforePolling()
        {
            if (DynamicDataValues != null)
            {
                var delayParam = DynamicDataValues
                    .FirstOrDefault(p => p.DynamicParameterId == (int)Types.Proxy.DynamicParameter.DeviceDelayBeforePolling);

                if (delayParam != null)
                {
                    Thread.Sleep(Convert.ToInt32(delayParam.Value));
                }
            }
        }

        /// <summary>
        /// Возвращает динамический параметр по его коду
        /// </summary>
        /// <param name="paramCode">Код динамического параметра</param>
        /// <exception cref="Exception">Генерируется когда значение динамического параметра не найдено в локальной коллекции DynamicDataValues</exception>
        protected DynamicParameterValue GetDynamicParameterValue(string paramCode)
        {
            var dynamicParameter = DynamicDataValues.FirstOrDefault(p => p.DynamicParameter.Code.Equals(paramCode));
            if (dynamicParameter != null)
            {
                return dynamicParameter;
            }
            throw new Exception(string.Format(DeviceMessages.DynamicParameterNotFound, paramCode));
        }

        protected DynamicParameterValue GetDynamicParameterValue(Types.Proxy.DynamicParameter dynamicParameter)
        {
            DynamicParameterValue result = null;
            using(var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        result = context.Set<DynamicParameterValue>()
                            .FirstOrDefault(
                                p =>
                                    p.EntityId == MeasurementDevice.Id && p.DynamicParameterId == (int) dynamicParameter);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }

            return result;
        }

        protected DynamicParameterValue GetDynamicParameterValueByEntityId(Types.Proxy.DynamicParameter dynamicParameter, int entityId)
        {
            DynamicParameterValue result = null;
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        result = context.Set<DynamicParameterValue>()
                            .FirstOrDefault(
                                p =>
                                    p.EntityId == entityId && p.DynamicParameterId == (int)dynamicParameter);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }

            return result;
        }

        protected void SetLastIndexToDynamicData(string dynamicParameterCode, int currentIndex)
        {
            var dynamicValue = GetDynamicParameterValue(dynamicParameterCode);

            if (dynamicValue != null)
            {
                dynamicValue.Value = Convert.ToString(currentIndex);

                SetValueToDynamicData(dynamicValue);
            }
            else
            {
                throw new Exception(string.Format(DeviceMessages.DynamicParameterNotFound, dynamicParameterCode));
            }
        }

        /// <summary>
        /// Устанавливает новое значение динамического параметра и сохраняет его в БД
        /// </summary>
        /// <param name="dynamicValue">Динамический параметр</param>
        protected void SetValueToDynamicData(DynamicParameterValue dynamicValue)
        {
            if (dynamicValue != null)
            {
                using (var tran = Context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        Context.SaveChanges();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception(string.Format(DeviceMessages.SaveDynamicParameterError, dynamicValue.DynamicParameter.Code));
                    }
                }
            }
            else
            {
                throw new Exception(DeviceMessages.SaveDynamicParameterNullReferenceException);
            }
        }

        /// <summary>
        /// Устанавливает новое значение динамического параметра типа Дата
        /// </summary>
        /// <param name="paramCode">Код динамического параметра</param>
        /// <param name="date">Новое значение даты</param>
        protected void SetNewDateValueToDynamicData(string paramCode, DateTime date)
        {
            var dynamicValue = GetDynamicParameterValue(paramCode);

            if (dynamicValue != null)
            {
                dynamicValue.Value = date.ToString(@"yyyy-MM-ddTHH\:mm\:ss");

                SetValueToDynamicData(dynamicValue);
            }
            else
            {
                throw new Exception(string.Format(DeviceMessages.DynamicParameterNotFound, paramCode));
            }
        }
        private DictionaryCache _dictionaryCache = new DictionaryCache();
        /// <summary>
        /// Определяет является ли транспортным сервером модем Барс
        /// </summary>
        private bool IsTransportServerModelBars()
        {
            string transportServerModelCode = _dictionaryCache.GetTransportServerModelCode(ApI.AccessPoint.TransportServerModelId);
            
            return transportServerModelCode.Equals(ConnectionServerMessages.Bars02, StringComparison.Ordinal) ||
                   transportServerModelCode.Equals(ConnectionServerMessages.Bars02PXM, StringComparison.Ordinal) ||
                   transportServerModelCode.Equals(ConnectionServerMessages.Bars02WXM, StringComparison.Ordinal) ||
                   transportServerModelCode.Equals(ConnectionServerMessages.Bars02_Old, StringComparison.Ordinal);
        }

        /// <summary>
        /// Определяет является ли транспортным сервером модем ЭнергоТехАудит
        /// </summary>
        /// <returns></returns>
        private bool IsTransportServerEtaModem()
        {
            string transportServerModelCode = _dictionaryCache.GetTransportServerModelCode(ApI.AccessPoint.TransportServerModelId);

            return transportServerModelCode.Equals(ConnectionServerMessages.EtaModem, StringComparison.Ordinal);
        }

        /// <summary>
        /// Определяет является ли транспортным сервером модем ЛЭРС GSM
        /// </summary>
        /// <returns></returns>
        private bool IsTransportServerModelLers()
        {
            string transportServerModelCode = _dictionaryCache.GetTransportServerModelCode(ApI.AccessPoint.TransportServerModelId);

            return transportServerModelCode.Equals(ConnectionServerMessages.LersGsmPlus, StringComparison.Ordinal) ||
                   transportServerModelCode.Equals(ConnectionServerMessages.LersGsmLite, StringComparison.Ordinal);
        }

        /// <summary>
        /// Определяет является ли транспортным сервером модем серии Moxa
        /// </summary>
        /// <returns></returns>
        protected bool IsTransportServerModelMoxa()
        {
            string transportServerModelCode = _dictionaryCache.GetTransportServerModelCode(ApI.AccessPoint.TransportServerModelId);

            return transportServerModelCode.Contains(ConnectionServerMessages.Moxa);
        }

        /// <summary>
        /// Конфигурирует транспортный сервер (настраивает скорость, четность, биты данных)
        /// </summary>
        private void ConfigureTransportServer()
        {
            RaiseTraceInfoPassedEvent(TraceMessages.TransportServerConfiguration);
            _configureActionSteps.TraceInfoPassed += _configureActionSteps_TraceInfoPassed;

            string transportServerModelCode = _dictionaryCache.GetTransportServerModelCode(ApI.AccessPoint.TransportServerModelId);

            bool isNeedToCheckWiznetStatusConnection = IsNeedToCheckWiznetStatusConnection();
            if ((transportServerModelCode.Equals(ConnectionServerMessages.WIZ107SR) || transportServerModelCode.Equals(ConnectionServerMessages.WIZ108SR)) &&
                isNeedToCheckWiznetStatusConnection)
            {
                ConfigurationStatus = _configureActionSteps.CheckWiznetStatusConnection(MeasurementDevice, LogHelper);
            }

            if ((transportServerModelCode.Equals(ConnectionServerMessages.Maestro) || transportServerModelCode.Equals(ConnectionServerMessages.Gammy))
                 && MeasurementDevice.AccessPoint.IsNeedToReconfigure)
            {
                ConfigurationStatus = _configureActionSteps.ConfigureMaestroServer(MeasurementDevice, LogHelper);
            }
            else if (transportServerModelCode.Contains(ConnectionServerMessages.Moxa) && MeasurementDevice.AccessPoint.IsNeedToReconfigure)
            {
                ConfigurationStatus = _configureActionSteps.ConfigureMoxaServer(MeasurementDevice, LogHelper, (TransportServerModel)ApI.AccessPoint.TransportServerModelId);
                _preparedTcpClient = _configureActionSteps.PreparedTcpClient;
            }
            else if (transportServerModelCode.Contains(ConnectionServerMessages.EtaModem) && MeasurementDevice.AccessPoint.IsNeedToReconfigure)
            {
                ConfigurationStatus = _configureActionSteps.ConfigureEtaModemServer(_preparedTcpClient, MeasurementDevice, LogHelper);
            }
            else if (IsTransportServerModelBars())
            {
                ConfigurationStatus = _configureActionSteps.ConfigureBarsModem(_preparedTcpClient, MeasurementDevice, LogHelper, (TransportServerModel)ApI.AccessPoint.TransportServerModelId);
            }
            else if (IsTransportServerModelLers())
            {
                var dynamicParameterValue = GetDynamicParameterValue(Types.Proxy.DynamicParameter.DeviceLersModemBaudRateConfigure);

                bool configureBaudRate = false;
                if (dynamicParameterValue != null)
                {
                    configureBaudRate = Convert.ToBoolean(dynamicParameterValue.Value);
                }

                ConfigurationStatus = _configureActionSteps.ConfigureLersGsmModem(_preparedTcpClient, MeasurementDevice, LogHelper, configureBaudRate);
            }
            else if ((transportServerModelCode.Equals(ConnectionServerMessages.WIZ107SR) || transportServerModelCode.Equals(ConnectionServerMessages.WIZ108SR)) &&
                     MeasurementDevice.AccessPoint.IsNeedToReconfigure)
            {
                // если уже проверяли текущее состояние визнета (CONNECT or OPEN), и соединение не открылось, то нет смысла еще раз лезть
                // и пытаться конфигурировать его скорость
                if (isNeedToCheckWiznetStatusConnection && ConfigurationStatus != TransportServerConfigurationStatus.NoConnection)
                {
                    ConfigurationStatus = _configureActionSteps.ConfigureWiznetGateway(MeasurementDevice, LogHelper);
                }
            }
            else if (transportServerModelCode.Contains(ConnectionServerMessages.I7188) && MeasurementDevice.AccessPoint.IsNeedToReconfigure)
            {
                // для связки WIZNET + I7188 если надо чекать состояние визнета (не подвис ли)
                if (isNeedToCheckWiznetStatusConnection)
                {
                    _configureActionSteps.CheckWiznetStatusConnection(MeasurementDevice, LogHelper);
                }

                ConfigurationStatus = _configureActionSteps.ConfigureI7188(MeasurementDevice, LogHelper);
            }
            else
            {
                ConfigurationStatus = TransportServerConfigurationStatus.SuccessfullyConfigured;
            }

            // отщепляем событие трейсинга конфигсервера: оно больше не понадобится
            _configureActionSteps.TraceInfoPassed -= _configureActionSteps_TraceInfoPassed;
        }

        private bool IsNeedToCheckWiznetStatusConnection()
        {
            bool result = false;

            if (MeasurementDevice.AccessPointId != null)
            {
                using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var dynParamValue = Context.Set<DynamicParameterValue>().FirstOrDefault(p => p.EntityId == MeasurementDevice.AccessPointId.Value
                           && p.DynamicParameterId == (int)Types.Proxy.DynamicParameter.AccessPointCheckWiznetStatusConnection);

                        if (dynParamValue != null)
                        {
                            result = Convert.ToBoolean(dynParamValue.Value);
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        result = false;
                    }
                }
            }

            return result;
        }

        private void TransportServerAfterPollingAction()
        {
            if (IsTransportServerModelBars())
            {
                _configureActionSteps.BarsSendEndPolling(_preparedTcpClient, MeasurementDevice, LogHelper);
            }
        }

        /// <summary>
        /// Сохраняет текущее состояние контекста
        /// </summary>
        protected void SaveState()
        {
            if (LogHelper != null)
            {
                LogHelper.SaveLogs();
            }

            using (var transaction = Context.Database.BeginTransaction(IsolationLevel.Snapshot))
            {
                try
                {
                    Context.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        /// <summary>
        /// Сравнивает текущий полученный заводской номер
        /// с заводским номером из базы данных
        /// </summary>
        /// <param name="currentDeviceNumber">Текущий полученный заводской номер</param>
        /// <returns>true - номера совпали; false - не совпали</returns>
        protected bool CheckFactoryNumber(long currentDeviceNumber)
        {
            var eventHelper = new EventHelperBase(MeasurementDevice.Id);

            if (!eventHelper.CheckFactoryNumber(currentDeviceNumber, MeasurementDevice.FactoryNumber))
            {
                _conQualHelper.SetFailConnectionStatus();
                RaiseTraceInfoPassedEvent(DeviceMessages.WrongFactoryNumber);
                throw new WrongFactoryNumberException();
            }
            return true;
        }

        /// <summary>
        /// Возвращает последнюю запись журнала по заданному типу события
        /// </summary>
        /// <param name="internalDeviceEventId">Идентификатор типа события</param>
        /// <returns></returns>
        protected MeasurementDeviceJournal GetLastMeasurementDeviceJournal(int internalDeviceEventId)
        {
            return Context.Set<MeasurementDeviceJournal>().OrderByDescending(p => p.Time)
                .FirstOrDefault(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.InternalDeviceEventId == internalDeviceEventId);
        }

        /// <summary>
        /// Возвращает последнюю архивную запись за период
        /// </summary>
        /// <param name="periodType">Тип периода (часовой, суточный, месячный)</param>
        public Archive GetLastArchiveByPeriod(PeriodType periodType)
        {
            Archive archive = null;
            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    archive = Context.Set<Archive>().OrderByDescending(p => p.Time)
                    .FirstOrDefault(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.PeriodTypeId == (int)periodType);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception(string.Format(StringFormat.CannotGetLastArchiveByPeriod,
                          periodType == PeriodType.Day ? Resources.Common.DayArchive : Resources.Common.HourArchive));
                }
            }

            return archive;
        }

        /// <summary>
        /// Определяет есть ли архивы по заданному типу периода, используя временные сигнатуры
        /// </summary>
        /// <param name="periodType"></param>
        /// <returns></returns>
        protected bool HasArchivesByPeriodUsingTimeSignature(PeriodType periodType)
        {
            var timeSignatureIds = Context.Set<TimeSignature>()
                                  .Where(p => p.MeasurementDeviceId == MeasurementDevice.Id).Select(p => p.Id).ToList();
            var archives = Context.Set<Archive>().Where(p => timeSignatureIds.Contains(p.TimeSignatureId) && p.PeriodTypeId == (int)periodType).Take(10).ToList();
            return archives.Count > 0;
        }


        /// <summary>
        /// Возвращает первую архивную запись за период
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <returns></returns>
        protected Archive GetFirstArchiveByPeriod(PeriodType periodType)
        {
            return Context.Set<Archive>().OrderBy(p => p.Time)
                .FirstOrDefault(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.PeriodTypeId == (int)periodType);
        }

        /// <summary>
        /// Возвращает последнюю архивную запись за период с использованием дополнительного условия
        /// </summary>
        /// <param name="periodType">Тип периода (часовой, суточный, месячный)</param>
        /// <param name="extraCondition">Дополнительное условие</param>
        protected Archive GetLastArchiveByPeriod(PeriodType periodType, Expression<Func<Archive, bool>> extraCondition)
        {
            Archive result = null;

            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                   result =  Context.Set<Archive>().OrderByDescending(p => p.Time)
                        .Where(extraCondition)
                        .FirstOrDefault(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.PeriodTypeId == (int)periodType);
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    throw new Exception(string.Format(DeviceMessages.GetLastArchiveByPeriodError, periodType));
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает архивные записи по времени, периоду и дополнительному условию
        /// </summary>
        /// <param name="periodType">Тип периода (часовой, суточный)</param>
        /// <param name="time">Время</param>
        /// <param name="extraCondition">Дополнительное условие</param>
        /// <returns></returns>
        protected List<Archive> GetLastArchivesByPeriod(PeriodType periodType, DateTime time, Expression<Func<Archive, bool>> extraCondition)
        {
            List<Archive> result = null;

            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    result = Context.Set<Archive>()
                         .Where(extraCondition)
                         .Where(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.PeriodTypeId == (int)periodType && p.Time == time)
                         .ToList();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception(string.Format(DeviceMessages.GetLastArchiveByPeriodError, periodType));
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает архивную запись по периоду на заданную дату с использование дополнительного условия
        /// </summary>
        /// <param name="periodType">Тип периода (часовой, суточный, месячный)</param>
        /// <param name="extraCondition">Дополнительное условие</param>
        /// <param name="time">Заданная дата</param>
        protected Archive GetLastArchiveByTime(PeriodType periodType, Expression<Func<Archive, bool>> extraCondition, DateTime time)
        {
            return Context.Set<Archive>()
                .Where(extraCondition)
                .FirstOrDefault(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.PeriodTypeId == (int)periodType && p.Time == time);
        }

        /// <summary>
        /// Возвращает архивную запись по периоду на заданную дату с использование дополнительного условия
        /// </summary>
        /// <param name="periodType">Тип периода (часовой, суточный, месячный)</param>
        /// <param name="extraCondition">Дополнительное условие</param>
        /// <param name="time">Заданная дата</param>
        protected Archive GetLastArchiveByTime(PeriodType periodType, DateTime time)
        {
            Archive result = null;

            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    result = Context.Set<Archive>()
                    .FirstOrDefault(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.PeriodTypeId == (int)periodType && p.Time == time);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception(string.Format(DeviceMessages.GetLastArchiveByTimeError, periodType, time));
                }

            }

            return result;
        }

        /// <summary>
        /// Возвращает последнее событие определенного типа, связанное с прибором
        /// </summary>
        /// <param name="eventParam">Тип события</param>
        protected DeviceEvent GetLastEventByType(EventParameter eventParam)
        {
            return Context.Set<DeviceEvent>().OrderByDescending(p => p.Time)
                .FirstOrDefault(p => p.MeasurementDeviceId == MeasurementDevice.Id && p.DeviceEventParameterId == (int) eventParam);
        }

        /// <summary>
        /// Возвращает количество журнальных записей
        /// </summary>
        protected int GetMeasurementDeviceJournalCount()
        {
            return Context.Set<MeasurementDeviceJournal>()
                .Where(p => p.MeasurementDeviceId == MeasurementDevice.Id)
                .ToList()
                .Count;
        }

        /// <summary>
        /// Возвращает количество журнальных записей с использованием дополнительного условия
        /// </summary>
        /// <param name="extraCondition">Дополнительное условие</param>
        protected int GetMeasurementDeviceJournalCount(Expression<Func<MeasurementDeviceJournal, bool>> extraCondition)
        {
            int totalCount = 0;
            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var j = Context.Set<MeasurementDeviceJournal>().Where(extraCondition)
                                        .Where(p => p.MeasurementDeviceId == MeasurementDevice.Id)
                                        .FirstOrDefault();
                    totalCount = j != null ? 1 : 0;
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new ReadUncommittedException(DeviceMessages.GetMeasurementDeviceJournalCountError);
                }
            }
            return totalCount;
        }

        /// <summary>
        /// Определяет имеется ли такая журнальная запись прибора в БД
        /// </summary>
        /// <param name="journal">Журнальная запись</param>
        /// <returns>true - имеется; false - не имеется</returns>
        protected bool HasMeasurementDeviceJournalDuplicate(MeasurementDeviceJournal journal)
        {
            bool result = false;
            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var j = Context.Set<MeasurementDeviceJournal>().FirstOrDefault(p => p.MeasurementDeviceId == journal.MeasurementDeviceId &&
                    p.InternalDeviceEventId == journal.InternalDeviceEventId && p.Time == journal.Time &&
                    p.OriginalValue == journal.OriginalValue && p.CurrentValue == journal.CurrentValue);

                    result = j != null;

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new ReadUncommittedException(DeviceMessages.SearchMeasurementDeviceJournalDuplicate);
                }
            }
            return result;
        }
        
        /// <summary>
        /// Записывает список "сырых" архивных мгновенных записей
        /// в аналитическую машину нештатных ситуаций
        /// </summary>
        /// <param name="infoValues">Список "сырых" архивных записей</param>
        public void SetInstantArchiveValuesForAnalyze(List<ValueInfo> infoValues)
        {
            if (EmergencyEngine != null)
            {
                EmergencyEngine.SetInstantAndFinalInstantArchiveValues(infoValues);
            }
        }

        /// <summary>
        /// Определяет находятся ли значения архивов в пределах допустимых согласно технической документации прибора
        /// </summary>
        public void CheckValuesOutOfRange(List<ValueInfo> valueInfoCollection = null)
        {
            if (valueInfoCollection == null) valueInfoCollection = LocalArchives;

            if (_deviceReaderCache != null && _deviceReaderCache.DeviceParameterSettings != null)
            {
                foreach (var localArchive in valueInfoCollection)
                {
                    var deviceParameterSetting = _deviceReaderCache.DeviceParameterSettings.FirstOrDefault(p => p.Id == localArchive.DeviceParameterId);

                    if (deviceParameterSetting != null)
                    {
                        localArchive.IsValid = localArchive.Value >= deviceParameterSetting.Min && localArchive.Value <= deviceParameterSetting.Max;
                    }
                }
            }
        }

        /// <summary>
        /// Записывает список готовых архивных мгновенных записей
        /// в аналитическую машину нештатных ситуаций
        /// </summary>
        /// <param name="infoValues">Список готовых архивных записей</param>
        protected void SetInstantArchiveValuesForAnalyze(List<Archive> archives)
        {
            if (EmergencyEngine != null)
            {
                EmergencyEngine.SetInstantAndFinalInstantArchiveValues(archives);
            }
        }

        /// <summary>
        /// Записывает список предыдущих мгновенных архивов
        /// в аналитическую машину нештатных ситуаций
        /// </summary>
        /// <param name="archives">Список готовых архивных записей</param>
        protected void SetPreviousInstantArchiveValuesForAnalyze(List<Archive> archives)
        {
            if (EmergencyEngine != null)
            {
                EmergencyEngine.SetPreviousInstantArchiveValues(archives);
            }
        }

        /// <summary>
        /// Загружает текущие параметры регуляции, связанные с данным прибором
        /// </summary>
        protected void LoadRegulatorParameters()
        {
            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    Context.Set<RegulatorParameterValue>().Where(p => p.MeasurementDeviceId == MeasurementDevice.Id).Load();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception("Ошибка загрузки текущих параметров регуляции");
                }
            }
        }

        /// <summary>
        /// Загружает текущие параметры регуляции, отфильтрованные по определенному критерию
        /// </summary>
        /// <param name="extraCondition"></param>
        protected void LoadRegulatorParametersByCondition(Expression<Func<RegulatorParameterValue, bool>> extraCondition)
        {
            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    Context.Set<RegulatorParameterValue>().Where(extraCondition).Load();
                         
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception("Ошибка загрузки текущих параметров регуляции");
                }
            }
        }

        protected void SaveInstantAndFinalInstantArchives()
        {
            ArchiveCollector.CreateArchives(LocalArchives);

            if (!ArchiveCollector.SaveArchives())
            {
                throw new Exception(DeviceMessages.FinalInstantArchivesSaveError);
            }

            SetInstantArchiveValuesForAnalyze(LocalArchives);

            UpdateLastTimeSignatureId();
        }

        protected void UpdateDeviceTechnicalParam(List<DeviceTechnicalParameter> techParams, int deviceParameterId, string resultValueStr)
        {
            var techParam = techParams.FirstOrDefault(p => p.DeviceParameterId == deviceParameterId);

            if (techParam != null)
            {
                techParam.Time = DateTime.Now;
                if (!techParam.StringValue.Equals(resultValueStr))
                {
                    techParam.StringValue = resultValueStr;
                }
            }
            else
            {
                Context.Set<DeviceTechnicalParameter>().Add(new DeviceTechnicalParameter
                {
                    DeviceParameterId = deviceParameterId,
                    MeasurementDeviceId = MeasurementDevice.Id,
                    StringValue = resultValueStr,
                    DeviceValue = 0,
                    Time = DateTime.Now
                });
            }
        }

        protected virtual void ReadDeviceSettings()
        {

        }

        protected List<DeviceTechnicalParameter> TechParams;

        /// <summary>
        /// Проверяет наличие архивной записи на заданное время и заданный тип периода
        /// </summary>
        /// <param name="periodType"></param>
        /// <param name="archiveTime"></param>
        /// <returns></returns>
        protected bool CheckArchiveExist(PeriodType periodType, DateTime archiveTime)
        {
            bool result = true;

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var archive = context.Set<Archive>().FirstOrDefault(p => p.PeriodTypeId == (int)periodType && p.MeasurementDeviceId == MeasurementDevice.Id &&
                        p.Time == archiveTime);

                        result = archive != null;
                    }
                    catch
                    {
                        tran.Rollback();
                        result = true;
                    }
                }
            }

            return result;
        }

        protected void CheckDeviceSettings()
        {
            var settingUpdateDate = DynamicParameterHelper.GetDynamicValue<DateTime>(Types.Proxy.DynamicParameter.DeviceDeviceSettingUpdateDate);

            var timeSpan = (DateTime.Now - settingUpdateDate).TotalHours;

            TechParams = new List<DeviceTechnicalParameter>();
            bool techParamsInit = false;
            // раз в неделю синхронизируем
            if (timeSpan > 168)
            {
                using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        TechParams = Context.Set<DeviceTechnicalParameter>().Where(p => p.MeasurementDeviceId == MeasurementDevice.Id).ToList();
                        tran.Commit();
                        techParamsInit = true;
                    }
                    catch
                    {
                        techParamsInit = false;
                        tran.Rollback();
                    }
                }

                if (techParamsInit)
                {
                    ReadDeviceSettings();

                    bool saveResult = false;
                    using (var tran = Context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            Context.SaveChanges();
                            tran.Commit();
                            saveResult = true;
                        }
                        catch (Exception ex)
                        {
                            saveResult = false;
                            tran.Rollback();
                        }
                    }

                    if (saveResult)
                    {
                        DynamicParameterHelper.SetDynamicParameter(Types.Proxy.DynamicParameter.DeviceDeviceSettingUpdateDate, DateTime.Now);
                    }
                }
            }
        }

        protected void Debug(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
        }




        #region Кухня сборки мусора
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
                if(DynamicParameterHelper != null)
                {
                    DynamicParameterHelper.Dispose();
                    DynamicParameterHelper = null;
                }
            }
        }

        ~Device()
        {
            Dispose(false);
        }
        #endregion
    }
}

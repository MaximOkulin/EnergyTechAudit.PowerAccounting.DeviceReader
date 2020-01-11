using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Integrating;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types;
using Device = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.CustomFormatters;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    [Device("TV7")]
    public partial class Tv7 : Device
    {
        private ActionSteps _actionSteps;
        private bool _isM;
        private SubModel _subModel;
        private Parser _parser;
        private ModbusMode _modbusMode;
        private ReportingTime _reportingTime;
        private ArchiveDatesInfo _archiveDatesInfo;
        private bool _isNewFirmware;

        protected override void InitTransport()
        {
            var protocol = (ProtocolSubType) MeasurementDevice.ProtocolSubTypeId;
            switch (protocol)
            {
                case ProtocolSubType.Empty:
                case ProtocolSubType.ModbusRtu:
                    _modbusMode = ModbusMode.RTU;
                    break;

                case ProtocolSubType.ModbusAscii:
                    _modbusMode = ModbusMode.ASCII;
                    break;
            }

            ManualResetEvent = new ManualResetEvent(false);
            Transport = new Tv7Connection(MeasurementDevice, ApI, ManualResetEvent, LogHelper, _modbusMode);
            _parser = new Parser();
            _actionSteps = new ActionSteps(Transport, ManualResetEvent, MeasurementDevice.NetworkAddress);

            CheckExistDynamicDataValues();

            InitDynamicDataValues(new[]
            {
                (int) DynamicParameter.DeviceTv7AibdLastIndex,
                (int) DynamicParameter.DeviceTv7AasLastIndex,
                (int) DynamicParameter.DeviceTv7AdLastIndex                
            });

            DynamicParameterHelper.CheckExistDynamicDataValues();

            DynamicParameterHelper.InitDynamicDataValues(
                new[] { (int)DynamicParameter.DeviceReportHour,
                (int) DynamicParameter.DeviceDeviceSettingUpdateDate }
                );
        }

        public Tv7(int deviceId, DeviceReaderCache deviceReaderCache, TcpClient preparedTcpClient) : base(deviceId, deviceReaderCache, preparedTcpClient) { }

        public Tv7(int deviceId, DeviceReaderCache deviceReaderCache = null) : base(deviceId, deviceReaderCache) { }

        public Tv7(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings) : base(device, preparedTcpClient, serverCommunicatorSettings) { }

        public Tv7(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings, int deviceReaderId) : base(device, preparedTcpClient, serverCommunicatorSettings, deviceReaderId) { }

        protected override Dictionary<string, string> GetConnectionExistence()
        {
            var result = new Dictionary<string, string>();

            _actionSteps.GetDeviceInfo();

            byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
            int factoryNumber = _parser.GetFactoryNumber(buffer);

            result.Add(DeviceMessages.RealFactoryNumberKey,
                string.Format(DeviceMessages.RealFactoryNumber, factoryNumber));

            string subModel = _parser.GetSubmodel(buffer).Item1;
            result.Add(CommandsKeys.SubModelKey, string.Format(DeviceMessages.SubModel, subModel));

            if (factoryNumber == MeasurementDevice.FactoryNumber)
            {
                // получение текущего времени прибора
                _actionSteps.GetDeviceTime();
                buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                DeviceTime = _parser.GetDeviceTime(buffer);

                result.Add(CommandsKeys.DeviceTimeDifferenceKey, string.Format(new DeviceTimeDifferenceFormat(), Resources.Common.DeviceTimeDifferenceStringFormat, DeviceTime.CalculateDeviceTimeDifference()));

                result.Add(CommandsKeys.DeviceTimeKey, string.Format(DeviceMessages.DeviceTime, DeviceTime));

                result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnection);
            }
            else
            {
                result.Add(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionWrongFactoryNumber);
            }
            
            return result;
        }

        protected override Dictionary<string, string> GetCurrents()
        {
            var result = new Dictionary<string, string>();

            _actionSteps.GetDeviceInfo();
            byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
            int factoryNumber = _parser.GetFactoryNumber(buffer);

            if (!CheckFactoryNumber(factoryNumber))
            {
                result.Add(CommandsKeys.WrongFactoryNumberKey, string.Format(DeviceMessages.WrongFactoryAttentionStringFormat, MeasurementDevice.FactoryNumber, factoryNumber));
            }
            // получение версии ПО
            Firmware = _parser.GetFirmware(buffer);
            _isNewFirmware = Firmware.IsSupportFeature(new Firmware(2, 2));

            _actionSteps.GetDeviceTime();
            buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
            DeviceTime = _parser.GetDeviceTime(buffer);
            ArchiveCollector = new ArchiveCollectorBase(DeviceTime, MeasurementDevice);

            ReadInstantArchives();
            ReadFinalInstantArchives();

            ArchiveCollector.CreateArchives(LocalArchives);

            if (!ArchiveCollector.SaveArchives())
            {
                result.Add(CommandsKeys.CurrentArchivesSaveErrorKey, DeviceMessages.FinalInstantArchivesSaveError);
            }
            else
            {
                SetInstantArchiveValuesForAnalyze(LocalArchives);

                UpdateLastTimeSignatureId();

                result.Add(CommandsKeys.ReadCurrentsSuccessfullyKey, DeviceMessages.ReadCurrentsSuccessfully);
            }

            return result;            
        }

        protected override void Polling()
        {
            RaiseTraceInfoPassedEvent(TraceMessages.GetDeviceInfo);
            _actionSteps.GetDeviceInfo();

            byte[] buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
            int factoryNumber = _parser.GetFactoryNumber(buffer);

            if (CheckFactoryNumber(factoryNumber))
            {
                // получение версии ПО
                Firmware = _parser.GetFirmware(buffer);
                MeasurementDevice.Firmware = Firmware.ToString();
                _isNewFirmware = Firmware.IsSupportFeature(new Firmware(2, 2));

                // получение модели исполнения
                var subModelInfo = _parser.GetSubmodel(buffer);
                MeasurementDevice.SubModel = subModelInfo.Item1;
                _subModel = subModelInfo.Item2;
                // определяет содержит ли прибор в модели символ "М"
                _isM = _parser.IsM(buffer);


                RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ReportingTime);
                // получение отчетного времени
                _actionSteps.GetReportingTime();
                buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                _reportingTime = _parser.GetReportingTime(buffer);
                

                DynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceReportHour, _reportingTime.Hour);

                RaiseTraceInfoPassedEvent(DeviceMessages.Tv7ArchiveDatesInfo);
                // получение информации о датах начала/конца архивов
                _actionSteps.GetArchiveDatesInfo();
                buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                _archiveDatesInfo = _parser.GetArchiveDatesInfo(buffer);

                // получение текущего времени прибора
                _actionSteps.GetDeviceTime();
                buffer = ModbusProtocol.ConvertToRtuFormat(Transport.Buffer, _modbusMode);
                DeviceTime = _parser.GetDeviceTime(buffer);
                ArchiveCollector = new ArchiveCollectorBase(DeviceTime, MeasurementDevice);

                RaiseTraceInfoPassedEvent(string.Format(Resources.Common.TwoSimplePartsStringFormat, DeviceMessages.DeviceTime, DeviceTime));

                ReadInstantArchives();
                ReadFinalInstantArchives();

                ArchiveCollector.CreateArchives(LocalArchives);

                if (!ArchiveCollector.SaveArchives())
                {
                    throw new Exception(DeviceMessages.FinalInstantArchivesSaveError);
                }

                SetInstantArchiveValuesForAnalyze(LocalArchives);

                UpdateLastTimeSignatureId();

                ReadDayArchives();
                ReadFinalArchives();

                ReadHourArchives();
                ExecuteHourIntegratingMachine();

                ReadAsyncArchives(AsyncArchiveType.DatabaseChanges);
                ReadAsyncArchives(AsyncArchiveType.Events);
                ReadAsyncArchives(AsyncArchiveType.Diagnostic);

                CheckDeviceSettings();
            }
        }

        /// <summary>
        /// Рассчитывает часовые интеграторы
        /// </summary>
        public void ExecuteHourIntegratingMachine()
        {
            new IntegratingMachine(MeasurementDevice.Id).Calculate();
        }

        /// <summary>
        /// Возвращает идентификатор мгновенного приборного параметра
        /// </summary>
        /// <param name="paramName">Литерал параметра</param>
        /// <param name="pipeNumber">Номер трубопровода</param>
        private int GetParamId(string paramName, int pipeNumber)
        {
            return BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_{0}{1}", paramName, pipeNumber > 0 ? Convert.ToString(pipeNumber) : string.Empty));
        }

        /// <summary>
        /// Возвращает идентификатор интегрального приборного параметра
        /// </summary>
        /// <param name="paramName">Литерал параметра</param>
        /// <param name="pipeNumber">Номер трубопровода или тепловвода</param>
        private int GetSumParamId(string paramName, int pipeNumber)
        {
            return BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_{0}{1}Sum", paramName, pipeNumber));
        }

        /// <summary>
        /// Возвращает идентификатор разностного приборного параметра
        /// </summary>
        /// <param name="paramName">Литерал параметра</param>
        /// <param name="pipeNumber">Номер трубопровода или тепловвода</param>
        private int GetDiffParamId(string paramName, int pipeNumber)
        {
            return BaseExtensions.GetDeviceParameterIdByName(string.Format("TV7_{0}{1}Diff", paramName, pipeNumber));
        }
    }
}

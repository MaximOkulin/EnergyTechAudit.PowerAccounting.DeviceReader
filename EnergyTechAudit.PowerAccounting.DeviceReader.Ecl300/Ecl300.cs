using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Parsers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.CustomFormatters;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using System.Reflection;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Applications;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300
{
    [Device("ECL300")]
    public class Ecl300 : Common.Logic.Device
    {
        private ActionSteps _actionSteps;
        private DynamicParameterValue _eclKeyDynamicParameterValue;

        protected override void InitTransport()
        {
            var autoEvent = new ManualResetEvent(false);
            Transport = new Ecl300Connection(MeasurementDevice, ApI, autoEvent, LogHelper, (PortType)MeasurementDevice.PortTypeId);
            _actionSteps = new ActionSteps(Transport, autoEvent, MeasurementDevice.NetworkAddress);

            DynamicParameterHelper.CheckExistDynamicDataValues();
            DynamicParameterHelper.InitDynamicDataValues(new int[]
            {
                (int)DynamicParameter.DeviceRegParamsLastSyncTime
            });

            using (var tran = Context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                try
                {
                    _eclKeyDynamicParameterValue =
                        Context.Set<DynamicParameterValue>().FirstOrDefault(
                           p => p.DynamicParameterId == (int)DynamicParameter.DeviceEcl300Key && p.EntityId == MeasurementDevice.Id);
                    Context.Set<RegulatorParameterValue>().Where(p => p.MeasurementDeviceId == MeasurementDevice.Id).Load();

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }

        public Ecl300(MeasurementDevice device) : base(device) {  }

        public Ecl300(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings) : base(device, preparedTcpClient, serverCommunicatorSettings) { }

        public Ecl300(int deviceId, DeviceReaderCache deviceReaderCache, TcpClient preparedTcpClient) : base(deviceId, deviceReaderCache, preparedTcpClient) { }

        public Ecl300(int deviceId, DeviceReaderCache deviceReaderCache = null)
            : base(deviceId, deviceReaderCache)
        {

        }

        public Ecl300(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings, int deviceReaderId) : base(device, preparedTcpClient, serverCommunicatorSettings, deviceReaderId) { }

        protected override Dictionary<string, string> GetConnectionExistence()
        {
            List<KeyValuePair<string, string>> resList = new List<KeyValuePair<string, string>>();
            DelayBeforePolling();

            string eclApplicationKey = GetCurrentKeyValue();
            var dictionaryCache = new DictionaryCache();
            string portType = dictionaryCache.GetPortTypeCode(MeasurementDevice.PortTypeId);

            // для ключей RS485 можно проинициализировать значением из прибора
            if (portType.Contains(DeviceMessages.RS485))
            {
                portType = DeviceMessages.RS485;
                _actionSteps.GetRs485Application();
                eclApplicationKey = ParserBase.ParseApplication(Transport.Buffer);

                resList.Add(new KeyValuePair<string, string>(CommandsKeys.Ecl300Key, string.Format(DeviceMessages.Ecl310EclKey, eclApplicationKey)));

                _actionSteps.GetRs485DeviceTime();
                DeviceTime = ParserBase.ParseRs485DeviceTime(Transport.Buffer);

                var now = DateTime.Now;
                var timeSpan = now - DeviceTime;
                if (Math.Abs(timeSpan.TotalHours) > 3)
                {
                    SetNewDeviceTime();
                    resList.Add(new KeyValuePair<string, string>(CommandsKeys.CorrectDeviceTimeKey, DeviceMessages.CorrectDeviceTime));
                    // пересчитываем новое установленное время прибора
                    _actionSteps.GetRs485DeviceTime();
                    DeviceTime = ParserBase.ParseRs485DeviceTime(Transport.Buffer);
                }

                resList.Add(new KeyValuePair<string, string>(CommandsKeys.DeviceTimeDifferenceKey, string.Format(new DeviceTimeDifferenceFormat(), Resources.Common.DeviceTimeDifferenceStringFormat, DeviceTime.CalculateDeviceTimeDifference())));
                resList.Add(new KeyValuePair<string, string>(CommandsKeys.DeviceTimeKey, string.Format(DeviceMessages.DeviceTime, DeviceTime)));

                resList.Insert(0, new KeyValuePair<string, string>(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionHtml));
            }
            else if (eclApplicationKey.Equals(Convert.ToString(EclKeys.NotDefined)))
            {
                resList.Insert(0, new KeyValuePair<string, string>(CommandsKeys.Ecl300KeyNotDefinedKey,
                       string.Format(StringFormat.ErrorResponseHtml, DeviceMessages.Ecl300KeyNotDefined)));
            }
            else
            {
                var eclKeyName = string.Format(StringFormat.TwoSimplePartsWithUnderline, eclApplicationKey, portType);
                var eclKeyType = AssemblyHelper.SearchType(eclKeyName, Resources.Common.EnergyTechAudit);
                if (eclKeyType == null)
                {
                    var notImplementedText = string.Format(DeviceMessages.Ecl300KeyNotImplemented, eclKeyName);
                    resList.Insert(0, new KeyValuePair<string, string>(CommandsKeys.Ecl300KeyNotImplementedKey, 
                       string.Format(StringFormat.ErrorResponseHtml, notImplementedText)));                    
                }
                else
                {
                    _actionSteps.GetSensor1();
                    resList.Insert(0, new KeyValuePair<string, string>(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionHtml));
                }
            }

            return resList.ToDictionary(x => x.Key, x => x.Value);
        }

        protected override Dictionary<string, string> GetCurrents()
        {
            var methodStruct = ReadDeviceTimeAndKey(Resources.Common.GetCurrents);
            return (Dictionary<string, string>)methodStruct.Item1.Invoke(methodStruct.Item2, null);
        }

        protected override Dictionary<string, string> ExecuteExtensionCommand(string commandName)
        {
            var result = new Dictionary<string, string>();

            if (commandName.Equals(Ecl300Resources.SetRegulatorParameterValue, StringComparison.Ordinal))
            {
                int updateParamsCount = Read(false);
                result.Add(CommandsKeys.SetRegulatorParameterValueKey, string.Format(StringFormat.UpdateRegulatorParameters,
                                                                       updateParamsCount));
            }
            else if (commandName.Equals(Ecl300Resources.ReadOnlyRegulatorParameters, StringComparison.Ordinal))
            {
                bool hasError = false;
                try
                {
                    var methodStruct = ReadDeviceTimeAndKey(Ecl300Resources.ReadOnlyRegulatorParameters);
                    methodStruct.Item1.Invoke(methodStruct.Item2, null);
                }
                catch
                {
                    hasError = true;
                }

                if (hasError)
                {
                    result.Add(CommandsKeys.ReadOnlyRegulatorParametersKey, DeviceMessages.ReadOnlyRegulatorParametersFail);
                    DynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, default(DateTime));
                }
                else
                {
                    result.Add(CommandsKeys.ReadOnlyRegulatorParametersKey, DeviceMessages.ReadOnlyRegulatorParametersSuccess);
                }
            }

            return result;
        }

        protected override void Polling()
        {
            DelayBeforePolling();

            Read(true);            
        }

        private int Read(bool isReadInstantValues)
        {
            var methodStruct = ReadDeviceTimeAndKey(DeviceMessages.Run);
            return (int)methodStruct.Item1.Invoke(methodStruct.Item2, new object[] { isReadInstantValues });
        }

        private Tuple<MethodInfo, object> ReadDeviceTimeAndKey(string methodName)
        {
            string eclApplicationKey = GetCurrentKeyValue();
            var dictionaryCache = new DictionaryCache();
            string portType = dictionaryCache.GetPortTypeCode(MeasurementDevice.PortTypeId);

            // для ключей RS485 можно проинициализировать значением из прибора
            if (portType.Contains(DeviceMessages.RS485))
            {
                portType = DeviceMessages.RS485;
                _actionSteps.GetRs485Application();
                eclApplicationKey = ParserBase.ParseApplication(Transport.Buffer);

                _actionSteps.GetRs485DeviceTime();
                DeviceTime = ParserBase.ParseRs485DeviceTime(Transport.Buffer);

                var now = DateTime.Now;
                var timeSpan = now - DeviceTime;
                if (Math.Abs(timeSpan.TotalHours) > 3)
                {
                    SetNewDeviceTime();
                    // пересчитываем новое установленное время прибора
                    _actionSteps.GetRs485DeviceTime();
                    DeviceTime = ParserBase.ParseRs485DeviceTime(Transport.Buffer);
                }
            }
            else
            {
                DeviceTime = DateTime.Now;
            }

            ArchiveCollector = new ArchiveCollectorBase(DeviceTime, MeasurementDevice);

            if (eclApplicationKey.Equals(Convert.ToString(EclKeys.NotDefined)))
            {
                throw new Exception(Ecl300Resources.EclKeyNotDefined);
            }
            else
            {
                // обновляем описание прибора
                var newDescription = string.Format(Resources.Common.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat,
                    Ecl300Resources.CommonName, eclApplicationKey);

                if (!MeasurementDevice.Description.Equals(newDescription, StringComparison.Ordinal))
                {
                    MeasurementDevice.Description = newDescription;
                }

                var eclKeyType = AssemblyHelper.SearchType(string.Format(StringFormat.TwoSimplePartsWithUnderline, eclApplicationKey, portType), Resources.Common.EnergyTechAudit);

                if (eclKeyType != null)
                {
                    var method = eclKeyType.GetMethod(methodName);

                    var eclKeyObj = Activator.CreateInstance(eclKeyType);
                    (eclKeyObj as Application).Context = GetContext();
                    (eclKeyObj as Application).Init(this, _actionSteps, DynamicParameterHelper);

                    return new Tuple<MethodInfo, object>(method, eclKeyObj);
                }
            }
            return null;
        }


        private void SetNewDeviceTime()
        {
            var now = DateTime.Now;
            _actionSteps.SetDeviceTimeHour(now.Hour);
            _actionSteps.SetDeviceTimeMinute(now.Minute);
            _actionSteps.SetDeviceTimeDay(now.Day);
            _actionSteps.SetDeviceTimeMonth(now.Month);
            _actionSteps.SetDeviceTimeYear(now.Year - 2000);
        }

        private string GetCurrentKeyValue()
        {
            if(_eclKeyDynamicParameterValue != null)
            {
                return Convert.ToString(((EclKeys)Convert.ToInt32(_eclKeyDynamicParameterValue.Value)));
            }
            
            return Convert.ToString(EclKeys.NotDefined);
        }
    }
}

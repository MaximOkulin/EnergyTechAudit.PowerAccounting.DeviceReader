using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Parsers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Reflection;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310
{
    [Device("ECL310")]
    public class Ecl310 : DeviceReader.Common.Logic.Device
    {
        private ActionSteps _actionSteps;
        private DynamicParameterValue _eclKeyDynamicParameterValue;

        protected override void InitTransport()
        {
            DynamicParameterHelper.CheckExistDynamicDataValues();
            DynamicParameterHelper.InitDynamicDataValues(new int[]
            {
                (int)DynamicParameter.DeviceRegParamsLastSyncTime
            });

            using (var tran = Context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    _eclKeyDynamicParameterValue =
                        Context.Set<DynamicParameterValue>().FirstOrDefault(
                           p => p.DynamicParameterId == (int)DynamicParameter.DeviceEcl310Key && p.EntityId == MeasurementDevice.Id);                   
                    
                    Context.Set<RegulatorParameterValue>().Where(p => p.MeasurementDeviceId == MeasurementDevice.Id).Load();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }

            var autoEvent = new ManualResetEvent(false);
            Transport = new EclConnection(MeasurementDevice, ApI, autoEvent, LogHelper);
            _actionSteps = new ActionSteps(Transport, autoEvent, MeasurementDevice.NetworkAddress);
        }

        public Ecl310(MeasurementDevice device) : base(device) { }

        public Ecl310(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings) : base(device, preparedTcpClient, serverCommunicatorSettings) { }

        public Ecl310(int deviceId, DeviceReaderCache deviceReaderCache, TcpClient preparedTcpClient) : base(deviceId, deviceReaderCache, preparedTcpClient) { }

        public Ecl310(int deviceId, DeviceReaderCache deviceReaderCache = null)
            : base(deviceId, deviceReaderCache)
        {
            
        }

        public Ecl310(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings, int deviceReaderId) : base(device, preparedTcpClient, serverCommunicatorSettings, deviceReaderId) { }


        protected override Dictionary<string, string> GetConnectionExistence()
        {
            var result = new Dictionary<string, string>();

            var parser = new ParserBase(_actionSteps.Transport, MeasurementDevice);

             _actionSteps.GetDeviceTime();
             var deviceTime = ParserBase.ParseDeviceTime(Transport.Buffer);
            result.Add(CommandsKeys.DeviceTimeKeyKey, string.Format(DeviceMessages.DeviceTime, deviceTime));

            _actionSteps.GetApplicationPrefix();
            string applicationPrefix = parser.ParseApplicationPrefix();
            _actionSteps.GetApplicationType();
            string applicationType = parser.ParseApplicationType();
            _actionSteps.GetApplicationSubType();
            string applicationSubType = parser.ParseApplicationSubType();
            string eclKey = string.Format(StringFormat.ThreePartWithDot, applicationPrefix, applicationType, applicationSubType);

            result.Add(CommandsKeys.EclKey, string.Format(DeviceMessages.Ecl310EclKey, eclKey));

            List<KeyValuePair<string, string>> resList = result.ToList();
            resList.Insert(0, new KeyValuePair<string, string>(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionHtml));

            return resList.ToDictionary(x => x.Key, x => x.Value);
        }

        protected override Dictionary<string, string> GetCurrents()
        {
            var result = new Dictionary<string, string>();

            var methodStruct = ReadDeviceTimeAndKey(Common.GetCurrents);
            result = (Dictionary<string, string>)methodStruct.Item1.Invoke(methodStruct.Item2, null);

            return result;
        }

        protected override Dictionary<string, string> ExecuteExtensionCommand(string commandName)
        {
            var result = new Dictionary<string, string>();

            if(commandName.Equals(Ecl300Resources.SetRegulatorParameterValue, StringComparison.Ordinal))
            {
                int updateParamsCount = Read(false);
                result.Add(CommandsKeys.SetRegulatorParameterValueKey,
                    string.Format(StringFormat.GoodResponseHtml,
                    string.Format(StringFormat.UpdateRegulatorParameters, 
                                                                       updateParamsCount)));
            }
            else if(commandName.Equals(Ecl300Resources.ReadOnlyRegulatorParameters, StringComparison.Ordinal))
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
                    result.Add(CommandsKeys.ReadOnlyRegulatorParametersKey, 
                        string.Format(StringFormat.ErrorResponseHtml,
                        DeviceMessages.ReadOnlyRegulatorParametersFail));
                    DynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, default(DateTime));
                }
                else
                {
                    result.Add(CommandsKeys.ReadOnlyRegulatorParametersKey, 
                        string.Format(StringFormat.GoodResponseHtml,
                        DeviceMessages.ReadOnlyRegulatorParametersSuccess));
                }
            }

            return result;
        }


        protected override void Polling()
        {
            Read(true);
        }

        private int Read(bool isReadInstantValues)
        {
            var methodStruct = ReadDeviceTimeAndKey(DeviceMessages.Run);
            return (int)methodStruct.Item1.Invoke(methodStruct.Item2, new object[] { isReadInstantValues });
        }

        private Tuple<MethodInfo, object> ReadDeviceTimeAndKey(string methodName)
        {
            _actionSteps.GetDeviceTime();
            var deviceTime = ParserBase.ParseDeviceTime(Transport.Buffer);
            ArchiveCollector = new ArchiveCollectorBase(deviceTime, MeasurementDevice);

            string eclApplicationKey = GetCurrentKeyValue();
            RaiseTraceInfoPassedEvent(string.Format(TraceMessages.Ecl310CurrentKey, eclApplicationKey));

            var eclKeyType = AssemblyHelper.SearchType(eclApplicationKey.Replace(Common.DotSymbol, string.Empty), DeviceMessages.EnergyTechAudit);

            if (eclKeyType != null)
            {
                var method = eclKeyType.GetMethod(methodName);

                var eclKeyObj = Activator.CreateInstance(eclKeyType);
                (eclKeyObj as Applications.ApplicationBase).Device = this;
                (eclKeyObj as Applications.ApplicationBase).Context = GetContext();
                (eclKeyObj as Applications.ApplicationBase).Init(_actionSteps, ArchiveCollector, MeasurementDevice, LogHelper, DynamicParameterHelper);

                return new Tuple<MethodInfo, object>(method, eclKeyObj);
            }

            return null;
        }

        private string GetCurrentKeyValue()
        {
            var parser = new ParserBase(_actionSteps.Transport, MeasurementDevice);

            _actionSteps.GetApplicationPrefix();
            string applicationPrefix = parser.ParseApplicationPrefix();
            _actionSteps.GetApplicationType();
            string applicationType = parser.ParseApplicationType();
            _actionSteps.GetApplicationSubType();
            string applicationSubType = parser.ParseApplicationSubType();
            string eclKey = string.Format(StringFormat.ThreePartWithDot, applicationPrefix, applicationType, applicationSubType);

            var currentId = (int)(EclKeys)Enum.Parse(typeof(EclKeys), eclKey.Replace(Common.DotSymbol, string.Empty));

            // обновляем значение динамического параметра ключа
            if (_eclKeyDynamicParameterValue != null)
            {
                _eclKeyDynamicParameterValue.Value = currentId.ToString();
            }
            else
            {
                Context.Set<DynamicParameterValue>().Add(new DynamicParameterValue
                {
                    DynamicParameterId = (int)DynamicParameter.DeviceEcl310Key,
                    Value = currentId.ToString(),
                    EntityId = MeasurementDevice.Id
                });
            }

            return eclKey;
        }
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using System.Data;
using System;
using System.Linq;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Data.Entity;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl;
using System.Net.Sockets;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Types;
using System.Reflection;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Applications;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Parsers;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110
{
    [Device("ECL110")]
    public class Ecl110 : Common.Logic.Device
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
                            p => p.DynamicParameterId == (int)DynamicParameter.DeviceEcl110Key && p.EntityId == MeasurementDevice.Id);

                    Context.Set<RegulatorParameterValue>().Where(p => p.MeasurementDeviceId == MeasurementDevice.Id).Load();

                    tran.Commit();
                }
                catch(Exception)
                {
                    tran.Rollback();
                }
            }

            var autoEvent = new ManualResetEvent(false);
            Transport = new EclConnection(MeasurementDevice, ApI, autoEvent, LogHelper);
            _actionSteps = new ActionSteps(Transport, autoEvent, MeasurementDevice.NetworkAddress);
        }

        public Ecl110(MeasurementDevice device) : base(device) { }

        public Ecl110(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings) : base(device, preparedTcpClient, serverCommunicatorSettings) { }

        public Ecl110(int deviceId, DeviceReaderCache deviceReaderCache, TcpClient preparedTcpClient) : base(deviceId, deviceReaderCache, preparedTcpClient) { }

        public Ecl110(int deviceId, DeviceReaderCache deviceReaderCache = null)
            : base(deviceId, deviceReaderCache)
        {

        }

        public Ecl110(MeasurementDevice device, TcpClient preparedTcpClient, ServerCommunicatorSettings serverCommunicatorSettings, int deviceReaderId) : base(device, preparedTcpClient, serverCommunicatorSettings, deviceReaderId) { }


        protected override Dictionary<string, string> GetConnectionExistence()
        {
            var result = new Dictionary<string, string>();

            var parser = new ParserBase(_actionSteps.Transport, MeasurementDevice);

            _actionSteps.GetDeviceTime();
            var deviceTime = ParserBase.ParseDeviceTime(Transport.Buffer);
            result.Add(CommandsKeys.DeviceTimeKeyKey, string.Format(DeviceMessages.DeviceTime, deviceTime));

            string eclApplicationKey = GetCurrentKeyValue();

            if (eclApplicationKey.Equals(Convert.ToString(EclKeys.NotDefined)))
            {
                result.Add(CommandsKeys.Ecl110Key, DeviceMessages.EclKeyNotDefined);
            }
            else
            {
                result.Add(CommandsKeys.Ecl110Key, string.Format(StringFormat.EclKey, eclApplicationKey.Replace(Resources.Common.K, string.Empty)));
            }

            List<KeyValuePair<string, string>> resList = result.ToList();
            resList.Insert(0, new KeyValuePair<string, string>(DeviceMessages.ConnectionStatusKey, DeviceMessages.SuccessConnectionHtml));

            return resList.ToDictionary(x => x.Key, x => x.Value);
        }

        protected override Dictionary<string, string> GetCurrents()
        {
            var result = new Dictionary<string, string>();

            var methodStruct = ReadDeviceTimeAndKey(Resources.Common.GetCurrents);
            result = (Dictionary<string, string>)methodStruct.Item1.Invoke(methodStruct.Item2, null);

            return result;
        }

        protected override Dictionary<string, string> ExecuteExtensionCommand(string commandName)
        {
            var result = new Dictionary<string, string>();

            if (commandName.Equals(Ecl300Resources.SetRegulatorParameterValue, StringComparison.Ordinal))
            {
                int updateParamsCount = Read(false);
                result.Add(CommandsKeys.SetRegulatorParameterValueKey,
                    string.Format(StringFormat.GoodResponseHtml,
                    string.Format(StringFormat.UpdateRegulatorParameters,
                                                                       updateParamsCount)));
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
            string eclApplicationKey = GetCurrentKeyValue();

            if (eclApplicationKey.Equals(Convert.ToString(EclKeys.NotDefined)))
            {
                throw new Exception(Ecl300Resources.EclKeyNotDefined);
            }
            else
            {
                // обновляем описание прибора
                var newDescription = string.Format(Resources.Common.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat,
                    Ecl300Resources.CommonName, eclApplicationKey.Replace(Resources.Common.K, string.Empty));

                _actionSteps.GetDeviceTime();
                DeviceTime = ParserBase.ParseDeviceTime(Transport.Buffer);

                var now = DateTime.Now;
                var timeSpan = now - DeviceTime;
                if (Math.Abs(timeSpan.TotalHours) > 3)
                {
                    SetNewDeviceTime();
                    // пересчитываем новое установленное время прибора
                    _actionSteps.GetDeviceTime();
                    DeviceTime = ParserBase.ParseDeviceTime(Transport.Buffer);
                }

                ArchiveCollector = new Common.Base.ArchiveCollectorBase(DeviceTime, MeasurementDevice);

                if (!MeasurementDevice.Description.Equals(newDescription, StringComparison.Ordinal))
                {
                    MeasurementDevice.Description = newDescription;
                }

                var eclKeyType = AssemblyHelper.SearchType(eclApplicationKey, Resources.Common.EnergyTechAudit);

                if (eclKeyType != null)
                {
                    var method = eclKeyType.GetMethod(methodName);

                    var eclKeyObj = Activator.CreateInstance(eclKeyType);
                    (eclKeyObj as Application).Context = GetContext();
                    (eclKeyObj as Application).DeviceTime = DeviceTime;
                    (eclKeyObj as Application).Init(this, _actionSteps, DynamicParameterHelper);

                    return new Tuple<MethodInfo, object>(method, eclKeyObj);
                }
            }
            return null;
        }

        /// <summary>
        /// Устаналивает новое время прибора
        /// </summary>
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
            if (_eclKeyDynamicParameterValue != null)
            {
                return Convert.ToString(((EclKeys)Convert.ToInt32(_eclKeyDynamicParameterValue.Value)));
            }

            return Convert.ToString(EclKeys.NotDefined);
        }
    }
}

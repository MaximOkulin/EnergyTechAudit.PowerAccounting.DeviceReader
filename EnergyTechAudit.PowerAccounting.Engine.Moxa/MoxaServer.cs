using System;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Moxa
{
    /// <summary>
    /// Класс, реализующий настройку транспортных серверов Moxa NPort
    /// </summary>
    public class MoxaServer : ConnectionServer
    {
        private readonly ActionSteps _actionSteps;
        private readonly TransportServerModel _moxaModel;

        public MoxaServer(MeasurementDevice device, LogHelper logHelper, TransportServerModel moxaModel) :
            base(device, logHelper)
        {
            var localAutoEvent = new ManualResetEvent(false);
            Connection = new MoxaConnection(Device, localAutoEvent, LogHelper);
            _actionSteps = new ActionSteps(Connection as MoxaConnection, localAutoEvent);
            _moxaModel = moxaModel;

            InitCommandPortFromDynamicParameter(device.AccessPointId);
        }

        private void InitCommandPortFromDynamicParameter(int? accessPointId)
        {
            DynamicParameterValue result = null;
            if (accessPointId != null)
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            result = context.Set<DynamicParameterValue>()
                                .FirstOrDefault(
                                    p =>
                                        p.EntityId == accessPointId &&
                                        p.DynamicParameterId == (int) DynamicParameter.AccessPointMoxaCommandPort);
                            tran.Commit();
                        }
                        catch
                        {
                            result = null;
                            tran.Rollback();
                        }
                    }
                }
            }

            CommandPort = result != null ? Convert.ToInt32(result.Value) : 966;
        }

        protected override bool Polling()
        {
            //var webConsole = new WebConsole(Device, _moxaModel);
            //webConsole.SetSettings();

            var moxaDataSocket = _actionSteps.OpenDataPort(Device.AccessPoint.NetAddress, Device.AccessPoint.Port);

            _actionSteps.SetSettings(Device);

            var configResult = CheckStatusResponse(Connection.Buffer);
            
            if (configResult)
            {
               MoxaTcpClient = new TcpClient();
               MoxaTcpClient.Client = moxaDataSocket;
            }

            return configResult;
        }

        /// <summary>
        /// Проверяет результат выполнения изменения настроек Moxa 
        /// и, в случае неуспеха, записывает в лог текст ошибки, а также сбрасывает поток
        /// </summary>
        /// <param name="buffer">Буфер ответа</param>
        private bool CheckStatusResponse(byte[] buffer)
        {
            if (!(buffer[0] == 0x10 && buffer[1] == 0x4f && buffer[2] == 0x4b))
            {
                return false;
            }
            return true;
        }
    }
}

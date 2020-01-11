using EnergyTechAudit.PowerAccounting.DeviceReader.Common;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using System.Net.Sockets;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem
{
    public class EtaModemConnection : Transport
    {
        private readonly TcpClient _tcpClient;
        public EtaModemConnection(TcpClient tcpClient, ManualResetEvent autoEvent, LogHelper logHelper) :
            base(autoEvent, logHelper)
        {
            _tcpClient = tcpClient;
        }

        protected override void FirstIteration(byte[] buffer)
        {
            State.TotalBytes = CurrentCommand.ResponseLength;

            State.IsFirstIteration = false;
        }

        public override bool InitConnection()
        {
            // если клиент мертвый, то и нет смысла инициализировать соединение
            if (_tcpClient == null) return false;

            var connectionInfo = new ConnectionInfo
            {
                PreparedTcpClient = _tcpClient
            };

            return InitConnection((int)Common.Types.Proxy.TransportType.Ethernet, connectionInfo);
        }
    }
}

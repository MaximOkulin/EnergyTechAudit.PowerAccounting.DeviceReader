using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System.Net.Sockets;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common
{
    /// <summary>
    /// Класс, хранящий настройки подключения к устройству,
    /// а также характеристики его порта
    /// </summary>
    public class ConnectionInfo
    {
        public int AmountAttempt;
        public int ReceiveTimeOut;
        public string NetAddress;
        public string NetPhone;
        public int Port;
        public string SerialPortName;
        public int BaudRate;
        public System.IO.Ports.Parity Parity;
        public int DataBits;
        public System.IO.Ports.StopBits StopBits;
        public TcpClient PreparedTcpClient;
        public PortType PortType;
        public TransportServerModel TransportServerModel;
        public string Identifier;
    }
}

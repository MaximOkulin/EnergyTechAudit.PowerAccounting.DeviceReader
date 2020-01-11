using System.Collections.Generic;
using System.Net.Sockets;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common
{
    /// <summary>
    /// Класс, хранящий текущее состояние чтения данных из приёмного буфера
    /// </summary>
    public class StateObject
    {
        public byte[] TcpBuffer = new byte[1024];
        public List<byte> ComPortBuffer = new List<byte>();
        public int BytesReaded;
        public bool IsFirstIteration = true;
        public int TotalBytes = 0;
        public NetworkStream Stream;
        public TcpClient TcpClient;

        /// <summary>
        /// Очищает TCP-буфер приема данных
        /// </summary>
        public void ClearTcpBuffer()
        {
            TcpBuffer = new byte[1024];
        }

        /// <summary>
        /// Очищает буфер приема данных от COM-порта
        /// </summary>
        public void ClearComPortBuffer()
        {
            ComPortBuffer = new List<byte>();
        }
    }
}

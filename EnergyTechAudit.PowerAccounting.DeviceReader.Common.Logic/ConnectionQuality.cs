using System.Net.Sockets;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;


namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    /// <summary>
    /// Определяет качество подключения
    /// </summary>
    public class ConnectionQuality
    {
        private readonly string _netAddress;

        public ConnectionQuality(string netAddress)
        {
            _netAddress = netAddress.SanitizeNetAddress();
        }

        /// <summary>
        /// Проверяет качество подключения к точке доступа
        /// </summary>
        /// <param name="port">Порт</param>
        /// <returns>Fail - неуспешно; Success - успех</returns>
        public StatusConnection CheckAccessPointConnection(int port)
        {
            NetworkStream stream;
            try
            {
                stream = new TcpClient(_netAddress, port).GetStream();
            }
            catch (SocketException)
            {
                return StatusConnection.Fail;
            }

            stream.Close();

            return StatusConnection.Success;
        }
    }
}

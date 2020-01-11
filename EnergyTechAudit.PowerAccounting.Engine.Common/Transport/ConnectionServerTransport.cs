using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    /// <summary>
    /// Транспорт до сервера (Moxa,Maestro)
    /// </summary>
    public class ConnectionServerTransport : Transport
    {
        private readonly MeasurementDevice _device;

        public ConnectionServerTransport(MeasurementDevice device, ManualResetEvent autoEvent, LogHelper logHelper) :
            base(autoEvent, logHelper)
        {
            _device = device;
        }

        /// <summary>
        /// Инициализирует соединение с удалённым сервером через 966 порт
        /// </summary>
        /// <returns>true - успех; false - неудача</returns>
        public bool InitConnection(int? port = null, int? receiveTimeOut = null)
        {
            if (_device != null && _device.AccessPoint != null)
            {
                var connectionInfo = new ConnectionInfo
                {
                    AmountAttempt = _device.AmountAttempt,
                    ReceiveTimeOut = receiveTimeOut ?? 1000,
                    NetAddress = _device.AccessPoint.NetAddress,
                    Port = port ?? 966,
                };

                return InitConnection(_device.AccessPoint.TransportTypeId, connectionInfo);
            }
            return false;
        }
    }
}

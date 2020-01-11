using System;
using System.Threading;
using System.IO.Ports;
using System.Net.Sockets;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    /// <summary>
    /// Транспорт до измерительного прибора
    /// </summary>
    public class DeviceTransport : Transport
    {
        private readonly MeasurementDevice _device;
        private readonly AccessPointInfo _accessPointInfo;
        private readonly DictionaryCache _dictionaryCache;

        public MeasurementDevice Device
        {
            get
            {
                return _device;
            }
        }

        public DeviceTransport(MeasurementDevice device, AccessPointInfo accessPointInfo, ManualResetEvent autoEvent, LogHelper logHelper) :
            base(autoEvent, logHelper)
        {
            _device = device;
            _accessPointInfo = accessPointInfo;
            _dictionaryCache = new DictionaryCache();
        }

        /// <summary>
        /// Закрывает последовательный порт, если используется прямое подключение
        /// </summary>
        public new void CloseSerialPort()
        {
            base.CloseSerialPort();
        }

        /// <summary>
        /// Закрывает TCP клиента, если используется подключение Ethernet
        /// </summary>
        public new void CloseTcpClient()
        {
            base.CloseTcpClient();
        }

        /// <summary>
        /// Инициализирует соединение с удаленной точкой доступа
        /// </summary>
        /// <param name="netAddress">IP-адрес точки доступа</param>
        /// <param name="port">Порт точки доступа</param>
        /// <returns></returns>
        public bool InitConnection(string netAddress, int port)
        {
            var connectionInfo = new ConnectionInfo
            {
                AmountAttempt = _device.AmountAttempt,
                NetAddress = netAddress,
                Port = port
            };

            return InitConnection(_device.AccessPoint.TransportTypeId, connectionInfo);
        }

        /// <summary>
        /// Инициализирует соединение с удалённым прибором
        /// </summary>
        /// <returns>true - успех; false - неудача</returns>
        public virtual bool InitConnection(TcpClient preparedTcpClient = null)
        {
            if (_device != null && _accessPointInfo.AccessPoint != null)
            {
                var accessPoint = _accessPointInfo.AccessPoint;
                var timeOut = _device.AutoDefTimeoutAnswer;
                    
                // Ethernet & Direct (via ComPort)
                if (accessPoint.TransportTypeId == 1 || accessPoint.TransportTypeId == 3)
                {
                    var connectionInfo = new ConnectionInfo
                    {
                        AmountAttempt = _device.AmountAttempt,
                        ReceiveTimeOut = timeOut,
                        SerialPortName = _dictionaryCache.GetComPortDescription(_device.ComPortId),
                        NetAddress = accessPoint.NetAddress,
                        NetPhone = accessPoint.NetPhone,
                        Port = accessPoint.Port,
                        BaudRate = Convert.ToInt32(_dictionaryCache.GetBaudCode(_device.BaudId)),
                        Parity = (System.IO.Ports.Parity) (_device.ParityId - 1),
                        DataBits = Convert.ToInt32(_dictionaryCache.GetDataBitCode(_device.DataBitId)),
                        StopBits = (StopBits) (_device.StopBitId - 1),
                        PortType = (PortType)_device.PortTypeId,
                        PreparedTcpClient = preparedTcpClient,
                        TransportServerModel = (TransportServerModel)accessPoint.TransportServerModelId,
                        Identifier = accessPoint.Identifier
                    };

                    return InitConnection(_device.AccessPoint.TransportTypeId, connectionInfo);
                }
                // CSD
                if (accessPoint.TransportTypeId == 2 && _accessPointInfo.CsdModem != null)
                {
                    var csdModem = _accessPointInfo.CsdModem;
                    var csdDevice = _accessPointInfo.CsdModemDeviceSnip;
                    var connectionInfo = new ConnectionInfo
                    {
                        AmountAttempt = 1,
                        ReceiveTimeOut = timeOut,
                        SerialPortName = _dictionaryCache.GetComPortDescription(csdModem.ComPortId),
                        NetPhone = accessPoint.NetPhone,
                        BaudRate = Convert.ToInt32(_dictionaryCache.GetBaudCode(csdDevice.BaudId)),
                        Parity = (System.IO.Ports.Parity) (csdDevice.ParityId - 1),
                        DataBits = Convert.ToInt32(_dictionaryCache.GetDataBitCode(csdDevice.DataBitId)),
                        StopBits = (StopBits) (csdDevice.StopBitId - 1)
                    };
                    return InitConnection(_device.AccessPoint.TransportTypeId, connectionInfo);
                }
            }
            return false;
        }

        /// <summary>
        /// Стандартный вычислитель длины пакета ответа
        /// </summary>
        /// <param name="buffer">Буфер</param>
        protected override void FirstIteration(byte[] buffer)
        {
            if (CurrentErrorCode == ErrorCode.None)
            {
                if (CurrentCommand.ResponseLengthType == LengthType.Calculated)
                {
                    // вычисляем общую длину пакета (5 = 3 байта вначале пакета + 2 байта контрольной суммы в конце)
                    State.TotalBytes = 5 + buffer[2];
                }
                else if (CurrentCommand.ResponseLengthType == LengthType.Fixed)
                {
                    State.TotalBytes = CurrentCommand.ResponseLength;
                }
            }
            else
            {
                State.TotalBytes = 6;
            }

            State.IsFirstIteration = false;
        }

        protected override bool CheckNetworkAddress()
        {
            return Buffer[0] == (byte)_device.NetworkAddress;
        }
    }
}

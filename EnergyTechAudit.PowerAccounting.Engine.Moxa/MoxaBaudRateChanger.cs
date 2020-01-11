using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Net.Sockets;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Moxa
{
    public class MoxaBaudRateChanger
    {
        private readonly TcpClient _tcpClient;
        private readonly NetworkStream _networkStream;
        private readonly Functions _functions;
        private readonly int _cmdPort;

        public MoxaBaudRateChanger(string netAddress, int port)
        {
            _tcpClient = new TcpClient(netAddress, port);
            _networkStream = _tcpClient.GetStream();
            _functions = new Functions();
            _cmdPort = port;
        }

        /// <summary>
        /// Изменяет настройки последовательного порта
        /// </summary>
        /// <param name="measurementDevice">Измерительное устройство</param>
        public void ChangeComPortSettings(MeasurementDevice measurementDevice)
        {
            _networkStream.Write(_functions.SetSettings(measurementDevice), 0, 4);

            var moxaCmdReceivedBuffer = new byte[3];
            _networkStream.Read(moxaCmdReceivedBuffer, 0, 3);

            if (!(moxaCmdReceivedBuffer[0] == 0x10 && moxaCmdReceivedBuffer[1] == 0x4f && moxaCmdReceivedBuffer[2] == 0x4b))
            {
                throw new Exception(string.Format(DeviceMessages.MoxaChangeBaudRateFail, _cmdPort));
            }
        }

        /// <summary>
        /// Изменяет настройки последовательного порта
        /// </summary>
        /// <param name="baud">Скорость</param>
        /// <param name="dataBit">Биты данных</param>
        /// <param name="stopBit">Стоповые биты</param>
        /// <param name="parity">Четность</param>
        public void ChangeComPortSettings(Baud baud, DataBit dataBit, StopBit stopBit, Parity parity)
        {
            _networkStream.Write(_functions.SetSettings(baud, dataBit, stopBit, parity), 0, 4);

            var moxaCmdReceivedBuffer = new byte[3];
            _networkStream.Read(moxaCmdReceivedBuffer, 0, 3);

            if (!(moxaCmdReceivedBuffer[0] == 0x10 && moxaCmdReceivedBuffer[1] == 0x4f && moxaCmdReceivedBuffer[2] == 0x4b))
            {
                throw new Exception(string.Format(DeviceMessages.MoxaChangeBaudRateFail, _cmdPort));
            }
        }

        /// <summary>
        /// Закрывает подключение к командному порту
        /// </summary>
        public void CloseConnection()
        {
            if (_networkStream != null)
            {
                _networkStream.Close();
                _networkStream.Dispose();
            }
            
            if (_tcpClient != null)
            {
                _tcpClient.Close();
            }
        }
    }
}

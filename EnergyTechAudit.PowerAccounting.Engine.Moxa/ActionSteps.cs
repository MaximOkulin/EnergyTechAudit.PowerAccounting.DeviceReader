using System.Net.Sockets;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Moxa
{
    internal sealed class ActionSteps : ActionStepsBase
    {
        private readonly Functions _functions;
        private readonly Commands _commands;

        public ActionSteps(MoxaConnection moxaConnection, ManualResetEvent autoEvent)
            :base(moxaConnection, autoEvent)
        {
            _functions = new Functions();
            _commands = new Commands();
        }

        /// <summary>
        /// Открывает сокет данных Moxa
        /// </summary>
        /// <param name="networkAddress">IP-адрес Moxa</param>
        /// <param name="port">Порт Moxa</param>
        public Socket OpenDataPort(string networkAddress, int port)
        {
            networkAddress = networkAddress.Replace(" ", string.Empty).Replace(",", ".");
            var moxaDataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            moxaDataSocket.Connect(networkAddress, port);
            return moxaDataSocket;
        }

        /// <summary>
        /// Закрывает сокет данных Moxa
        /// </summary>
        /// <param name="socket">Сокет</param>
        public void CloseDataPort(Socket socket)
        {
            if (socket.Connected)
            {
                socket.Disconnect(false);
            }
        }

        /// <summary>
        /// Устанавливает настройки последовательного порта Moxa
        /// </summary>
        /// <param name="device">Измерительное устройство</param>
        public void SetSettings(MeasurementDevice device)
        {
            Transport.CurrentCommand = _commands.SetSettings;
            Transport.Send(_functions.SetSettings(device));
            Wait();
        }

        /// <summary>
        /// Посылка команды начала Telnet-сессии
        /// </summary>
        public void StartTelnetSession()
        {
            Transport.CurrentCommand = _commands.StartTelnetSession;
            Transport.Send(new byte[] { 0x0D });
            Wait();
        }

        /// <summary>
        /// Получение текущих параметров сервера
        /// </summary>
        public void ExamineServerSettings()
        {
            Transport.CurrentCommand = _commands.ExamineServerSettings;
            Transport.Send(new byte[] { 0x0D });
            Wait();
        }
        
    }
}

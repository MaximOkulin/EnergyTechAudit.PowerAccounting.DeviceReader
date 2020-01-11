using System;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using Timer = System.Timers.Timer;
using System.Diagnostics;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    /// <summary>
    /// Базовый класс, реализующий транспортную функцию до устройств
    /// </summary>
    public partial class Transport : ITransport
    {
        public TransportTypes TransportType { get; set; }
        public TransportServerModel TransportServerModel { get; set; }
        private SerialPort _port;
        private NetworkStream _stream;
        public readonly ManualResetEvent AutoEvent;
        protected StateObject State;
        public bool IsCsdCommandMode;

        public int TotalBytesWrite { get; set; }
        public int TotalBytesRead { get; set; }

        /// <summary>
        /// Объект, осуществляющий оборачивание пакета
        /// </summary>
        private PackageWrapHelper _packageWrapHelper;

        /// <summary>
        /// Флаг инициации ручного сброса опроса
        /// </summary>
        public bool IsManualReset = false;

        public LogHelper LogHelper { get; set; }
        private ConnectionInfo _connectionInfo;
        public Command CurrentCommand { get; set; }
        
        // флаг - был ли произведен сброс соединения
        private bool _isLostConnectionRaised;
        
        protected byte[] CurrentRequest;

        public byte[] CurReq
        {
            get { return CurrentRequest; }
        }

        private const int MaxRequestAttempts = 7;

        /// <summary>
        /// Таймер, ожидающий приём данных от прибора
        /// </summary>
        public Timer ResponseWaitTimer;

        private int _currentRequestAttemptsCount = 1;
        private bool _useAttemptsInFail;

        public int GoodResponseCount = 0;
        public int BadResponseCount = 0;
        public int WrongCheckSumCount = 0;

        public ErrorCode CurrentErrorCode { get; set; }

        public delegate void ReceiveDataCompleteHandler(object sender, System.EventArgs e);

        // событие "Приём данных завершен"
        public event ReceiveDataCompleteHandler ReceiveDataComplete;

        /// <summary>
        /// Возбуждает событие завершения приема данных
        /// </summary>
        protected virtual void RaiseReceiveDataCompleteEvent()
        {
            GoodResponseCount++;
            if (ReceiveDataComplete != null)
            {
                ReceiveDataComplete(this, null);
            }
        }

        /// <summary>
        /// Строковое представление текущего запроса
        /// </summary>
        public string CurrentRequestDump
        {
            get
            {
                return string.Format("0x{0}", BitConverter.ToString(CurrentRequest));
            }
        }

        public string ErrorText { get; set; }
        

        public bool IsLostConnectionRaised
        {
            get { return _isLostConnectionRaised; }
            set { _isLostConnectionRaised = value; }
        }

        /// <summary>
        /// Буфер данных, полученных от прибора 
        /// </summary>
        public byte[] Buffer
        {
            get
            {
                if (TransportType == TransportTypes.Direct || TransportType == TransportTypes.CSD)
                {
                    return State.ComPortBuffer.Take(State.BytesReaded).ToArray();
                }
                if (TransportType == TransportTypes.Ethernet)
                {
                    return State.TcpBuffer.Take(State.BytesReaded).ToArray();
                }
                return null;
            }
        }


        public Transport(ManualResetEvent autoEvent, LogHelper logHelper)
        {
            AutoEvent = autoEvent;
            LogHelper = logHelper;
        }


        /// <summary>
        /// Возбуждает событие потери связи
        /// </summary>
        protected virtual void RaiseLostConnection(bool isFatal = false, string errorMessage = null)
        {
            _isLostConnectionRaised = true;

            if (ResponseWaitTimer != null)
            {
                ResponseWaitTimer.Stop();

                BadResponseCount++;

                if ((_useAttemptsInFail && _currentRequestAttemptsCount < MaxRequestAttempts && !isFatal))
                {
                    ReSendCommand();
                }
                else
                {
                    CurrentErrorCode = CurrentErrorCode == ErrorCode.None ? ErrorCode.LossConnection : CurrentErrorCode;

                    if (CurrentCommand.ErrorMessageCreator != null)
                    {
                        CurrentCommand.ErrorMessage = CurrentCommand.ErrorMessageCreator(CurrentCommand);
                    }

                    if (!string.IsNullOrEmpty(CurrentCommand.ErrorMessage))
                    {
                        CurrentCommand.ErrorMessage = string.Format("{0}. {1}", errorMessage ?? DeviceMessages.FailConnectionStatus, CurrentCommand.ErrorMessage);
                    }

                    if (TransportType == TransportTypes.CSD || TransportType == TransportTypes.Direct)
                    {
                        AutoEvent.Set();
                    }
                }
            }
        }
    

        /// <summary>
        /// Стандартный таймаут ожидания ответа от прибора
        /// </summary>
        private int _timeOut;
        /// <summary>
        /// Инициализирует соединение с удалённым прибором
        /// </summary>
        /// <returns>true - успех; false - неудача</returns>
        protected bool InitConnection(int transportType, ConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;

            if (connectionInfo.ReceiveTimeOut > 0)
            {
                _timeOut = connectionInfo.ReceiveTimeOut;
            }
            else
            {
                _timeOut = 35000;
            }
            
            ResponseWaitTimer = new Timer
            {
                Interval = _timeOut
            };
            ResponseWaitTimer.Elapsed += _responseWaitTimer_Elapsed;

            CheckIsNeedToWrapPackage();

            switch (transportType)
            {
                case (int) TransportTypes.Ethernet:
                    TransportType = TransportTypes.Ethernet;
                    return SetEthernetSettings(connectionInfo.PreparedTcpClient);
                case (int) TransportTypes.Direct:
                    TransportType = TransportTypes.Direct;
                    return SetComPortSettings();
                case (int)TransportTypes.CSD:
                    TransportType = TransportTypes.CSD;
                    IsCsdCommandMode = true;
                    return SetComPortSettings();
            }

            return false;
        }

        private void CheckIsNeedToWrapPackage()
        {
            if( _connectionInfo.TransportServerModel == TransportServerModel.Tbn_KSPD5G_new ||
                _connectionInfo.TransportServerModel == TransportServerModel.Tbn_KSPD5G_old)
            {
                _packageWrapHelper = new PackageWrapHelper(_connectionInfo.TransportServerModel, _connectionInfo);
            }
        }

        public virtual bool InitConnection()
        {
            return false;
        }
        /// <summary>
        /// Изменяет интервал ожидания
        /// </summary>
        /// <param name="newTimeOut">Новое значение таймаута</param>
        private void ChangeWaitTimeOut(int? newTimeOut)
        {
            if (TransportType == TransportTypes.Ethernet)
            {
                if (newTimeOut != null)
                {
                    _tcpClient.Client.ReceiveTimeout = newTimeOut.Value - 700;
                    _tcpClient.Client.SendTimeout = newTimeOut.Value - 700;
                }
                else
                {
                    _tcpClient.Client.ReceiveTimeout = _timeOut - 700;
                    _tcpClient.Client.SendTimeout = _timeOut - 700;
                }
            }

            if (TransportType == TransportTypes.CSD || TransportType == TransportTypes.Direct)
            {
                if (ResponseWaitTimer != null)
                {
                    if (newTimeOut != null)
                    {
                        ResponseWaitTimer.Interval = newTimeOut.Value;
                        _timeOut = newTimeOut.Value;
                    }
                    else
                    {
                        ResponseWaitTimer.Interval = _timeOut;
                    }
                }
            }
        }

        public void CloseEthernetStream()
        {
#if DEBUG
                Console.WriteLine("Закрываю TCP соединение");
#endif
                if (_stream != null)
                {
                    _stream.Close();
                }
                if (_tcpClient != null)
                {
                    _tcpClient.Close();
                }
#if DEBUG
                Console.WriteLine("Закрыл TCP соединение");
#endif
        }

        public void Send(object state, bool useAttemptsInFail = false, int? timeOut = null, int timeOutBeforeSend = 0)
        {
#if DEBUG
            Console.WriteLine("=== " + CurrentCommand.CommandName + " ===");
#endif
            // если установлен флаг ручного сброса опроса, то генерируем исключение и завершаем опрос
            if (IsManualReset)
            {
                throw new ManualResetException();
            }

            ChangeWaitTimeOut(timeOut);

            // если из динамического параметра пришел таймаут между пакетами, то устанавливаем его
            if (timeOutBeforeSend > 0)
            {
                CurrentCommand.TimeOutBeforeSend = timeOutBeforeSend;
            }

            _currentRequestAttemptsCount = 1;
            _useAttemptsInFail = useAttemptsInFail;

            var data = (byte[])state;

            if (_packageWrapHelper != null)
            {
                CurrentRequest = _packageWrapHelper.Wrap(data);
            }
            else
            {
                CurrentRequest = data;
            }            

            if (State == null)
            {
                State = new StateObject();
            }

            SendCommand();
        }

        private void ReSendCommand()
        {
            if (State == null)
            {
                State = new StateObject();
            }
            // увеличиваем счетчик попыток отправки команды в прибор
            _currentRequestAttemptsCount++;

            SendCommand();
        }

        public void ReadDataFromPort()
        {
            State.BytesReaded = 0;
            State.IsFirstIteration = true;
            State.TotalBytes = 0;

            _isLostConnectionRaised = false;
            ReadData();
        }

        private void SendCommand()
        {
            CurrentErrorCode = ErrorCode.None;

            // если необходимо сделать задержку перед посылкой пакета
            if (CurrentCommand.TimeOutBeforeSend > 0)
            {
                Thread.Sleep(CurrentCommand.TimeOutBeforeSend * 1000);
            }

            // обнуляем объект состояния приема перед отправкой команды
            State.BytesReaded = 0;
            State.IsFirstIteration = true;
            State.TotalBytes = 0;

            _isLostConnectionRaised = false;

#if DEBUG
            Console.WriteLine("Request ASCII: " + Encoding.ASCII.GetString(CurrentRequest));
            Console.WriteLine("Request HEX: " + BitConverter.ToString(CurrentRequest));
            var k = BitConverter.ToString(CurrentRequest);
            //File.AppendAllText(@"E:\dump.txt", CurrentCommand.CommandName + Environment.NewLine);
            //File.AppendAllText(@"E:\dump.txt", "Request HEX: " + BitConverter.ToString(CurrentRequest) + Environment.NewLine);
            //File.AppendAllText(@"E:\dump.txt", Environment.NewLine);
#endif

            try
            {
                if (TransportType == TransportTypes.Direct || TransportType == TransportTypes.CSD)
                {
                    StartWaitTimer();
                    State.ClearComPortBuffer();
                    _port.DiscardInBuffer();
                    _port.DiscardOutBuffer();
                    _port.Write(CurrentRequest, 0, CurrentRequest.Count());
                }
                else if (TransportType == TransportTypes.Ethernet)
                {
                    State.ClearTcpBuffer();
                    State.Stream = _stream;
                    _stream.WriteTimeout = 3000;

                    TotalBytesWrite += CurrentRequest.Length;

                    if (!CurrentCommand.IsReadWithoutWrite)
                    {
                        _stream.Write(CurrentRequest, 0, CurrentRequest.Length);                        
                    }

                    if (!CurrentCommand.IsWriteWithoutRead)
                    {
                        if (CurrentCommand.TimeOutBerforeReceive > 0)
                        {
                            Thread.Sleep(CurrentCommand.TimeOutBerforeReceive * 1000);
                        }

                        ReadData();

                        if(State.BytesReaded < State.TotalBytes)
                        {
                            RaiseLostConnection(false, State.BytesReaded == 0 ? DeviceMessages.EmptyPackageReceived : DeviceMessages.NotFullPackageReceived);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                _stream.Close();
                _tcpClient.Close();
                RaiseLostConnection(true, DeviceMessages.LostConnectionStatus);
            }
        }

        /// <summary>
        /// Первая итерация приема данных от устройства
        /// (должно быть переопределено для каждого устройства согласно его протоколу)
        /// </summary>
        /// <param name="buffer">Входной поток принятных байтов</param>
        protected virtual void FirstIteration(byte[] buffer)
        {
            State.TotalBytes = CurrentCommand.ResponseLengthType == LengthType.Fixed ? CurrentCommand.ResponseLength : 1;
            State.IsFirstIteration = false;
        }

        private void CoreFirstIteration(byte[] buffer)
        {
            State.TotalBytes = CurrentCommand.ResponseLengthType == LengthType.Fixed ? CurrentCommand.ResponseLength : 1;
            State.IsFirstIteration = false;
        }

        private void _responseWaitTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResponseWaitTimer.Stop();
            RaiseLostConnection(false, string.Format(DeviceMessages.TimeOutElapsed, _timeOut));
        }

        /// <summary>
        /// Останавливает ожидающий приема таймер и отсоединяет от него событие
        /// </summary>
        public void WaitTimerClear()
        {
            if (ResponseWaitTimer != null)
            {
                ResponseWaitTimer.Stop();
                ResponseWaitTimer.Elapsed -= _responseWaitTimer_Elapsed;
                ResponseWaitTimer.Dispose();
                ResponseWaitTimer = null;
            }
        }

        /// <summary>
        /// Останавливает таймер, ожидающий получения данных,
        /// и устанавливает флаг, что данные были получены
        /// </summary>
        private void StopWaitTimer()
        {
            if (ResponseWaitTimer != null)
            {
                ResponseWaitTimer.Stop();
            }
        }

        /// <summary>
        /// Запускает таймер, ожидающий получения данных
        /// </summary>
        private void StartWaitTimer()
        {
            if (ResponseWaitTimer != null)
            {
                ResponseWaitTimer.Start();
            }
        }

        /// <summary>
        /// Проверяет контрольную сумму ответа прибора
        /// (должен быть реализован индивидуально каждым транспортом, если протокол прибора реализует проверку контрольной суммы)
        /// </summary>
        /// <returns>true - контрольная сумма верна; false - контрольная сумма неверна</returns>
        protected virtual bool VerifyCheckSum()
        {
            return true;
        }

        /// <summary>
        /// Проверяет сетевой адрес
        /// (должен быть реализован каждым прибором, если его протокол зависит от сетевого адреса)
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckNetworkAddress()
        {
            return true;
        }

        /// <summary>
        /// Выполняет произвольную проверку качества пакета
        /// (должен быть реализован каждым прибором, если есть возможность дополнительно проверять качество пакета)
        /// </summary>
        /// <returns></returns>
        protected virtual PackageCustomCheck PackageCustomCheck()
        {
            return new PackageCustomCheck();
        }
    }
}

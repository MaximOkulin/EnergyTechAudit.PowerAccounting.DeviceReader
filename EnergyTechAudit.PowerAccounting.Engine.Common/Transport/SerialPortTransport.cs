using System;
using System.IO.Ports;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using System.Text;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    public partial class Transport
    {
        /// <summary>
        /// Инициализирует подключение к прибору через последовательный порт
        /// </summary>
        /// <returns>True - успех; False - ошибка</returns>
        private bool SetComPortSettings()
        {
            _port = new SerialPort()
            {
                PortName = _connectionInfo.SerialPortName,
                BaudRate = _connectionInfo.BaudRate,
                Parity = _connectionInfo.Parity,
                StopBits = _connectionInfo.StopBits,
                DataBits = _connectionInfo.DataBits
            };
            _port.DataReceived += _port_DataReceived;
            try
            {
                _port.ReadTimeout = 2000;
                _port.WriteTimeout = 20;
                _port.Open();
            }
            catch (Exception ex)
            {
                if (LogHelper != null)
                {
                    LogHelper.CreateLog(string.Format(DeviceMessages.CannotOpenSerialPort, _connectionInfo.SerialPortName),
                        ErrorType.OpenSerialPortError, ex);
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Закрывает последовательный порт, если используется прямое подключение
        /// </summary>
        protected void CloseSerialPort()
        {
            if ((TransportType == TransportTypes.Direct || TransportType == TransportTypes.CSD) && _port != null)
            {
                if (_port.IsOpen)
                {
                    // отключаем обработчик события приема данных
                    _port.DataReceived -= _port_DataReceived;
                    _port.Close();
                    _port.Dispose();
#if DEBUG
                    Console.WriteLine("COM port closed");
#endif
                }
            }
        }

        /// <summary>
        /// Обрабатывает прием данных из последовательного порта
        /// </summary>
        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_isLostConnectionRaised)
            {
                StopWaitTimer();

                Thread.Sleep(3000);

                bool successReceive = true;

                if (!_port.IsOpen)
                {
                    RaiseLostConnection(false, string.Format(DeviceMessages.CannotOpenSerialPort, _port.PortName));
                }
                else
                {
                    try
                    {
                        // циклом читаем данные из порта
                        do
                        {
                            if (_port.IsOpen)
                            {
                                if (State.BytesReaded >= 3 && State.BytesReaded == State.TotalBytes &&
                                    ResponseWaitTimer.Enabled)
                                {
                                    StopWaitTimer();
                                }

                                var bytesToRead = _port.BytesToRead;
                                if (bytesToRead > 0)
                                {
                                    var _byte = new byte[bytesToRead];
                                    _port.Read(_byte, 0, bytesToRead);

                                    for (var i = 0; i < bytesToRead; i++)
                                    {
                                        State.BytesReaded++;
                                        State.ComPortBuffer.Add(_byte[i]);
                                    }
                                }

                                if (State.IsFirstIteration && (State.BytesReaded >= 3 || CurrentCommand.HasResponseOneByte))
                                {
                                    if (IsCsdCommandMode)
                                    {
                                        CoreFirstIteration(State.ComPortBuffer.ToArray());
                                    }
                                    else
                                    {
                                        FirstIteration(State.ComPortBuffer.ToArray());
                                    }
                                }

                                if ((State.BytesReaded < 3 || State.BytesReaded < State.TotalBytes) && 
                                    !ResponseWaitTimer.Enabled && 
                                    CurrentErrorCode == ErrorCode.None && !CurrentCommand.HasResponseOneByte)
                                {
                                    StartWaitTimer();
                                }
                            }
                            else
                            {
                                RaiseLostConnection(false, string.Format(DeviceMessages.CannotOpenSerialPort, _port.PortName));
                                successReceive = false;
                                break;
                            }

                        } while ((_port.BytesToRead > 0 || State.BytesReaded < State.TotalBytes || State.BytesReaded < 3) 
                                  && CurrentErrorCode == ErrorCode.None);
                    }
                    catch
                    {
                        RaiseLostConnection(false, DeviceMessages.LostConnectionStatus);
                        successReceive = false;
                    }

                    var packageCustomCheck = PackageCustomCheck();

                    if (!IsCsdCommandMode)
                    {

                        if (!packageCustomCheck.Result)
                        {
                            RaiseLostConnection(false, packageCustomCheck.ErrorMessage);
                            successReceive = false;
                        }

                        if (!VerifyCheckSum())
                        {
                            RaiseLostConnection(false, DeviceMessages.FailConnectionStatusWithWrongCheckSum);
                            successReceive = false;
                        }
                        if (!CheckNetworkAddress())
                        {
                            RaiseLostConnection(false, DeviceMessages.WrongNetAddress);
                            successReceive = false;
                        }
                    }

                    if (successReceive)
                    {
                        StopWaitTimer();
                        RaiseReceiveDataCompleteEvent();
                        AutoEvent.Set();
                    }
                }
            }
        }
    }
}

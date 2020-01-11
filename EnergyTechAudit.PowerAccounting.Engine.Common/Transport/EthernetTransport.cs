using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    public partial class Transport
    {
        private TcpClient _tcpClient;
        public TcpClient TcpClient
        {
            get { return _tcpClient; }
        }
        /// <summary>
        /// Инициализирует TCP-подключение к прибору
        /// </summary>
        /// <param name="preparedTcpClient">Готовый Tcp-клиент</param>
        /// <returns>True - успех; False - ошибка</returns>
        private bool SetEthernetSettings(TcpClient preparedTcpClient = null)
        {
            bool connectionResult = false;

            // попытка подключения
            try
            {
                _connectionInfo.NetAddress = _connectionInfo.NetAddress.SanitizeNetAddress();

                if (preparedTcpClient != null)
                {
                    _tcpClient = preparedTcpClient;
                }
                else
                {
#if DEBUG
                    Console.WriteLine("Открываю подключение на {0}:{1}", _connectionInfo.NetAddress, _connectionInfo.Port);
#endif
                    _tcpClient = new TcpClient(_connectionInfo.NetAddress, _connectionInfo.Port);
                }

                _stream = _tcpClient.GetStream();
                _stream.ReadTimeout = _timeOut;
                connectionResult = true;
            }
            catch(ArgumentNullException)
            {
                if (LogHelper != null)
                {
                    LogHelper.CreateLog(DeviceMessages.UnsuccessfulTcpConnection, ErrorType.ConnectionError);
                }
                connectionResult = false;
            }
            catch (SocketException ex)
            {
#if DEBUG
                Console.WriteLine("Подключение неудачно");
#endif
                if (LogHelper != null)
                {
                    LogHelper.CreateLog(DeviceMessages.UnsuccessfulTcpConnection, ErrorType.ConnectionError);
                }
                connectionResult = false;
            }
            catch(InvalidOperationException)
            {
                if (LogHelper != null)
                {
                    LogHelper.CreateLog(DeviceMessages.UnsuccessfulTcpConnection, ErrorType.ConnectionError);
                }
                connectionResult = false;
            }
            
            if (_stream != null)
            {
                
            }
            return connectionResult;
        }

        private void ReadData()
        {
            try
            {
#if FAKEPOLLING
                State.BytesReaded = CurrentCommand.FakeResponse.Length;
                State.TcpBuffer = CurrentCommand.FakeResponse;
#endif
#if !FAKEPOLLING
                var byteList = new List<byte>();

                do
                {
                    var currentBytesRead = _stream.Read(State.TcpBuffer, 0, State.TcpBuffer.Length);
                    State.BytesReaded += currentBytesRead;
                    byteList.AddRange(State.TcpBuffer.Take(currentBytesRead));

                    if (CurrentCommand.ResponseLengthType == LengthType.Fixed || 
                        CurrentCommand.ResponseLengthType == LengthType.Calculated ||
                        CurrentCommand.ResponseLengthType == LengthType.Format)
                    {
                        if (State.IsFirstIteration)
                        {
                            if (_packageWrapHelper != null)
                            {
                                var preWrapBytesCount = _packageWrapHelper.GetPreWrapBytesCount();

                                if (byteList.Count > preWrapBytesCount)
                                {
                                    var arrayByteList = byteList.ToArray();
                                    Array.Reverse(arrayByteList);
                                    var reversedArrayWithoutPreWrapBytes = arrayByteList.Take(arrayByteList.Length - preWrapBytesCount).ToArray();
                                    Array.Reverse(reversedArrayWithoutPreWrapBytes);

                                    FirstIteration(reversedArrayWithoutPreWrapBytes);
                                }
                                else
                                {
                                    Thread.Sleep(1000);
                                }
                            }
                            else
                            {
                                FirstIteration(byteList.ToArray());
                            }

                            if (_packageWrapHelper != null)
                            {
                                State.TotalBytes = _packageWrapHelper.CalculateNewResponseLength(State.TotalBytes);
                            }
                        }

                        if (!State.IsFirstIteration)
                        {
                            if (State.BytesReaded >= State.TotalBytes)
                            {
                                break;
                            }
                            else
                            {
                                Thread.Sleep(1000);
                            }
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                } while (_stream.DataAvailable);

                if (_packageWrapHelper != null)
                {
                    State.TcpBuffer = _packageWrapHelper.UnWrap(byteList.ToArray());
                    State.TotalBytes = State.TotalBytes - _packageWrapHelper.GetPreWrapBytesCount() - _packageWrapHelper.GetPostWrapBytesCount();
                }
                else
                {
                    State.TcpBuffer = byteList.ToArray();
                }
#endif

#if DEBUG 
                Console.WriteLine("Response (ASCII): " + Encoding.ASCII.GetString(State.TcpBuffer, 0, State.TcpBuffer.Length));
                Console.WriteLine("Response (HEX): " + BitConverter.ToString(State.TcpBuffer));
                var t = BitConverter.ToString(State.TcpBuffer);
                //File.AppendAllText(@"E:\dump.txt", "Response (HEX): " + BitConverter.ToString(State.TcpBuffer) + Environment.NewLine);
                //File.AppendAllText(@"E:\dump.txt", Environment.NewLine);
#endif
                /*
                if (CurrentCommand.ResponseLengthType == LengthType.Format)
                {
                    FirstIteration(State.TcpBuffer);
                }
                */

                var packageCustomCheck = PackageCustomCheck();

                if (packageCustomCheck.Result)
                {
                    if (State.BytesReaded >= State.TotalBytes)
                    {
                        // все байты пришли нулевые
                        if (State.TcpBuffer.All(p => p == 0x00))
                        {
                            RaiseLostConnection(false, DeviceMessages.NullBytesPackage);
                        }
                        else if (!VerifyCheckSum())
                        {
                            WrongCheckSumCount++;
                            RaiseLostConnection(false, DeviceMessages.FailConnectionStatusWithWrongCheckSum);
                        }
                        else if (!CheckNetworkAddress())
                        {
                            RaiseLostConnection(false, DeviceMessages.WrongNetAddress);
                        }
                        else
                        {
                            TotalBytesRead += State.BytesReaded;
                            RaiseReceiveDataCompleteEvent();
                        }
                    }
                }
                else
                {
                    RaiseLostConnection(false, packageCustomCheck.ErrorMessage);
                }
            }
            catch (IOException ex)
            {
                var socketException = ex.InnerException as SocketException;
                if (socketException != null && socketException.SocketErrorCode == SocketError.TimedOut)
                {
                    RaiseLostConnection(false, string.Format(DeviceMessages.TimeOutElapsed, _timeOut));
                }
                else
                {
                    RaiseLostConnection(true, DeviceMessages.LostConnectionStatus);
                }
            }
        }

        protected void CloseTcpClient()
        {
            if (TransportType == TransportTypes.Ethernet)
            {
                if (_stream != null)
                {
                    _stream.Close();
                    _stream.Dispose();
                }
                if (_tcpClient != null)
                {
                    _tcpClient.Close();
                }
            }
        }
    }
}

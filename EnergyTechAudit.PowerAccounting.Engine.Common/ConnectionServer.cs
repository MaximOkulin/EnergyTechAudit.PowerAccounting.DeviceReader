using System;
using System.Net.Sockets;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.EventArgs;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common
{
    /// <summary>
    /// Базовый класс транспортных серверов
    /// </summary>
    public class ConnectionServer
    {
        protected MeasurementDevice Device;
        
        protected ConnectionServerTransport Connection;
        protected LogHelper LogHelper;

        public TcpClient MoxaTcpClient;

        public TransportServerConfigurationStatus ConfigurationStatus;

        public delegate void ConnectionServerHandler(object sender, ConnectionServerEventArgs e);

        public event ConnectionServerHandler ConnectionServerTraced;

        protected void RaiseTracedEvent(string text)
        {
            if (ConnectionServerTraced != null)
            {
                ConnectionServerTraced(this, new ConnectionServerEventArgs { Text = text });
            }
        }

        public ConnectionServer(MeasurementDevice device, LogHelper logHelper)
        {
            Device = device;
            LogHelper = logHelper;

            // по умолчанию будем считать, что пока все плохо
            ConfigurationStatus = TransportServerConfigurationStatus.FailureConfiguration;
        }
        
        protected void SetSuccessfullyConfigured()
        {
            RaiseTracedEvent(ConnectionServerMessages.MaestroTimeOutBeforeApply);
            Thread.Sleep((int)TimeOuts.PortCfg * 1000);
            RaiseTracedEvent(ConnectionServerMessages.SuccessTransportServerConfig);
            Device.AccessPoint.LastStatusConnectionId = (int) StatusConnection.Success;
            ConfigurationStatus = TransportServerConfigurationStatus.SuccessfullyConfigured;
        }

        /// <summary>
        /// Прерывает работу потока конфигурирования транспортного сервера
        /// </summary>
        protected void SetFailureConfiguration()
        {
            RaiseTracedEvent(ConnectionServerMessages.ErrorTransportServerConfig);
            LogHelper.CreateLog(ConnectionServerMessages.ErrorTransportServerConfig, ErrorType.TransportServerConfigurationError);
            ConfigurationStatus = TransportServerConfigurationStatus.FailureConfiguration;
        }

        protected void SetNoConnectionStatus()
        {
            RaiseTracedEvent(ConnectionServerMessages.ErrorTransportServerConfig);
            LogHelper.CreateLog(ConnectionServerMessages.ErrorTransportServerConfig, ErrorType.ConnectionError);
            Device.AccessPoint.LastStatusConnectionId = (int)StatusConnection.Fail;
            ConfigurationStatus = TransportServerConfigurationStatus.NoConnection;
        }

        protected void SetLostConnectionConfiguration()
        {
            RaiseTracedEvent(ConnectionServerMessages.LostTransportServerConfig);
            LogHelper.CreateLog(ConnectionServerMessages.LostTransportServerConfig, ErrorType.TransportServerConfigurationError);
            ConfigurationStatus = TransportServerConfigurationStatus.LostConnection;
        }

        public void CheckSettings()
        {
            Run();
        }

        protected int? CommandPort = null;
        protected int? ReceiveTimeOut = null;
        protected virtual void Run()
        {
            if (Connection.InitConnection(CommandPort, ReceiveTimeOut))
            {
                try
                {
                    if (Polling())
                    {
                        SetSuccessfullyConfigured();
                    }
                }
                catch (LostConnectionException)
                {
                    SetLostConnectionConfiguration();
                }
                catch (Exception ex)
                {
                    LogHelper.CreateLog(DeviceMessages.ExceptionRaised, ErrorType.TransportServerConfigurationError, ex);
                    SetFailureConfiguration();
                }
            }
            else
            {
                SetNoConnectionStatus();
            }

            Connection.WaitTimerClear();
        }

        protected virtual bool Polling()
        {
            return true;
        }
    }
}

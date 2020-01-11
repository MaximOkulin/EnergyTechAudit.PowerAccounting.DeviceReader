using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.EventArgs;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common
{
    public class Modem
    {
        protected readonly MeasurementDevice Device;
        protected Transport.Transport Connection;

        public TransportServerConfigurationStatus ConfigurationStatus;

        public delegate void ModemHandler(object sender, ConnectionServerEventArgs e);

        public event ModemHandler ModemTraced;

        protected readonly LogHelper LogHelper;

        protected void RaiseTracedEvent(string text)
        {
            if (ModemTraced != null)
            {
                ModemTraced(this, new ConnectionServerEventArgs { Text = text });
            }
        }

        public Modem()
        {

        }

        public Modem(MeasurementDevice device, LogHelper logHelper)
        {
            Device = device;
            LogHelper = logHelper;

            // по умолчанию будем считать, что пока все плохо
            ConfigurationStatus = TransportServerConfigurationStatus.FailureConfiguration;
        }

        public void CloseTcpClient()
        {
            if (Connection != null)
            {
                Connection.CloseEthernetStream();
            }
        }

        protected void SetSuccessfullyConfigured()
        {
            if (Device.AccessPoint != null)
            {
                Device.AccessPoint.LastStatusConnectionId = (int)StatusConnection.Success;
                Device.AccessPoint.LastConnectionTime = DateTime.Now;
            }
            ConfigurationStatus = TransportServerConfigurationStatus.SuccessfullyConfigured;
        }

        protected void SetFailureConfiguration()
        {
            if (Device.AccessPoint != null)
            {
                Device.AccessPoint.LastStatusConnectionId = (int)StatusConnection.Fail;
                Device.AccessPoint.LastConnectionTime = DateTime.Now;
            }
            ConfigurationStatus = TransportServerConfigurationStatus.FailureConfiguration;
        }

        private void SetLostConnectionConfiguration()
        {
            if (Device.AccessPoint != null)
            {
                Device.AccessPoint.LastStatusConnectionId = (int)StatusConnection.Loss;
                Device.AccessPoint.LastConnectionTime = DateTime.Now;
            }
            ConfigurationStatus = TransportServerConfigurationStatus.LostConnection;
        }

        public bool InitConnection()
        {
            return Connection.InitConnection();
        }

        public void Configure()
        {
            if (Connection.InitConnection())
            {
                try
                {
                    ConfigurationSteps();
                }
                catch (LostConnectionException)
                {
                    SetLostConnectionConfiguration();
                }
                catch (Exception ex)
                {
                    SetFailureConfiguration();
                }
            }
            else
            {
                SetFailureConfiguration();
            }

            Connection.WaitTimerClear();
        }

        protected virtual void ConfigurationSteps()
        {

        }

        public virtual void SendEndPolling()
        {

        }
    }
}

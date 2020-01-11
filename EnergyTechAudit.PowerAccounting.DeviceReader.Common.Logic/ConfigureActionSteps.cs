using System;
using System.Net.Sockets;
using EnergyTechAudit.PowerAccounting.DeviceReader.BarsServer;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.EventArgs;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.I7188;
using EnergyTechAudit.PowerAccounting.DeviceReader.Maestro;
using EnergyTechAudit.PowerAccounting.DeviceReader.Moxa;
using EnergyTechAudit.PowerAccounting.DeviceReader.LersModem;
using EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    public class ConfigureActionSteps
    {
        public delegate void TraceInfoPassHandler(object sender, ConnectionServerEventArgs e);

        public event TraceInfoPassHandler TraceInfoPassed;

        public int SignalQuality = System.Int32.MaxValue;

        public TcpClient PreparedTcpClient;

        protected void RaiseTraceInfoPassedEvent(ConnectionServerEventArgs e)
        {
            if (TraceInfoPassed != null)
            {
                TraceInfoPassed(this, e);
            }
        }

        /// <summary>
        /// Конфигурирует транспортный сервер Maestro
        /// </summary>
        /// <param name="device">Измерительный прибор</param>
        /// <param name="logHelper">Логгер</param>
        /// <returns>Статус результата конфигурирования</returns>
        public TransportServerConfigurationStatus ConfigureMaestroServer(MeasurementDevice device, LogHelper logHelper)
        {
            var maestroServer = new MaestroServer(device, logHelper);

            maestroServer.ConnectionServerTraced += OnTraced;
            maestroServer.CheckSettings();
            maestroServer.ConnectionServerTraced -= OnTraced;

            return maestroServer.ConfigurationStatus;
        }

        private void OnTraced(object sender, ConnectionServerEventArgs e)
        {
            RaiseTraceInfoPassedEvent(e);
        }

        /// <summary>
        /// Конфигурирует GPRS-модем Барс-02 (Промсервис)
        /// </summary>
        /// <param name="tcpClient">Подключение к модему</param>
        /// <param name="device">Измерительные прибор</param>
        /// <param name="logHelper">Логгер</param>
        /// <returns>Статус результата конфигурирования</returns>
        public TransportServerConfigurationStatus ConfigureBarsModem(TcpClient tcpClient, MeasurementDevice device,
            LogHelper logHelper, TransportServerModel transportServerModel)
        {
            var barsModem = new BarsModem(tcpClient, device, logHelper, transportServerModel);
            barsModem.ModemTraced += OnTraced;
            barsModem.Configure();
            barsModem.ModemTraced -= OnTraced;

            return barsModem.ConfigurationStatus;
        }

        public void BarsSendEndPolling(TcpClient tcpClient, MeasurementDevice device, LogHelper logHelper)
        {
            var barsModem = new BarsModem(tcpClient, device, logHelper, TransportServerModel.Bars02);
            barsModem.SendEndPolling();
        }

        public TransportServerConfigurationStatus ConfigureLersGsmModem(TcpClient tcpClient, MeasurementDevice device,
            LogHelper logHelper, bool configureBaudRate)
        {
            var lersGsmModem = new LersGsmModem(tcpClient, device, logHelper, configureBaudRate);
            lersGsmModem.ModemTraced += OnTraced;
            lersGsmModem.Configure();
            lersGsmModem.ModemTraced -= OnTraced;

            return lersGsmModem.ConfigurationStatus;
        }

        private void LersGsmModem_ModemTraced(object sender, ConnectionServerEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Конфигурирует транспортный сервер Moxa
        /// </summary>
        /// <param name="device">Измерительный прибор</param>
        /// <param name="logHelper">Логгер</param>
        /// <param name="moxaModel">Модель Моксы</param>
        /// <returns>Статус результата конфигурирования</returns>
        public TransportServerConfigurationStatus ConfigureMoxaServer(MeasurementDevice device, LogHelper logHelper, TransportServerModel moxaModel)
        {
            var moxaServer = new MoxaServer(device, logHelper, moxaModel);
            moxaServer.CheckSettings();

            PreparedTcpClient = moxaServer.MoxaTcpClient;

            return moxaServer.ConfigurationStatus;
        }

        /// <summary>
        /// Конфигурирует модем ЭнергоТехАудит
        /// </summary>
        /// <param name="device">Измерительный прибор</param>
        /// <param name="logHelper">Логгер</param>
        /// <returns></returns>
        public TransportServerConfigurationStatus ConfigureEtaModemServer(TcpClient tcpClient, MeasurementDevice device, LogHelper logHelper)
        {
            var etaModemServer = new EtaModemServer(tcpClient, device, logHelper);
            etaModemServer.Configure();

            return etaModemServer.ConfigurationStatus;
        }

        /// <summary>
        /// Конфигурирует шлюз Wiznet WIZ 107(108) SR
        /// </summary>
        /// <param name="device">Измерительный прибор</param>
        /// <param name="logHelper">Логгер</param>
        /// <returns>Статус результата конфигурирования</returns>
        public TransportServerConfigurationStatus ConfigureWiznetGateway(MeasurementDevice device, LogHelper logHelper)
        {
            var wiznet = new Wiznet.Wiznet(device, logHelper);
            wiznet.CheckSettings();
            return wiznet.ConfigurationStatus;
        }

        /// <summary>
        /// Проверяет текущий статус подключения шлюза Wiznet WIZ 107(108) SR
        /// и в случае его состояния CONNECT, делает его перезагрузку (сбрасывает)
        /// </summary>
        /// <param name="device">Измерительный прибор</param>
        /// <param name="logHelper">Логгер</param>
        /// <returns>Статус результата конфигурирования</returns>
        public TransportServerConfigurationStatus CheckWiznetStatusConnection(MeasurementDevice device, LogHelper logHelper)
        {
            var wiznet = new Wiznet.Wiznet(device, logHelper);
            wiznet.CheckStatusConnection();
            return wiznet.ConfigurationStatus;
        }
        
        /// <summary>
        /// Конфигурирует контроллер I7188
        /// </summary>
        /// <param name="device">Измерительный прибор</param>
        /// <param name="logHelper">Логгер</param>
        /// <returns>Статус результата конфигурирования</returns>
        public TransportServerConfigurationStatus ConfigureI7188(MeasurementDevice device, LogHelper logHelper)
        {
            var i7188Server = new I7188Server(device, logHelper);
            i7188Server.CheckSettings();
            return i7188Server.ConfigurationStatus;
        }
        
    }
}

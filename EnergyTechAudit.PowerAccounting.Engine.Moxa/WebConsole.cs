using System.Net;
using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Moxa
{
    /// <summary>
    /// Класс для взаимодействия с Web-консолью модема Moxa NPort
    /// </summary>
    public class WebConsole
    {
        private readonly MeasurementDevice _device;
        private readonly TransportServerModel _moxaModel;
        private readonly DictionaryCache _dictionaryCache;

        public WebConsole(MeasurementDevice device, TransportServerModel moxaModel)
        {
            _device = device;
            _moxaModel = moxaModel;
            _dictionaryCache = new DictionaryCache();
        }

        /// <summary>
        /// Формирует строку GET-запроса для установки настроек прибора
        /// </summary>
        private string GetSettingUrl()
        {
            if (_moxaModel == TransportServerModel.Moxa5110)
            {
                return
                    string.Format(
                        "http://{0}/Set.htm?BaudRate={1}&DataBits={2}&StopBits={3}&Parity={4}&PortNo=1&Submit=Submit&setfunc=Serial",
                        _device.AccessPoint.NetAddress, _moxaWebBaudRates[_dictionaryCache.GetBaudCode(_device.BaudId)],
                        _moxaWebDataBits[_dictionaryCache.GetDataBitCode(_device.DataBitId)],
                        _moxaWebStopBits[_dictionaryCache.GetStopBitCode(_device.StopBitId)], _moxaWebParity[_dictionaryCache.GetParityCode(_device.ParityId)]);
            }
            if (_moxaModel == TransportServerModel.Moxa5150)
            {
                return
                    string.Format(
                        "http://{0}/Set.htm?BaudRate={1}&DataBits={2}&StopBits={3}&Parity={4}&IfType={5}&PortNo=1&Submit=Submit&setfunc=Serial",
                        _device.AccessPoint.NetAddress, _moxaWebBaudRates[_dictionaryCache.GetBaudCode(_device.BaudId)],
                        _moxaWebDataBits[_dictionaryCache.GetDataBitCode(_device.DataBitId)],
                        _moxaWebStopBits[_dictionaryCache.GetStopBitCode(_device.StopBitId)], _moxaWebParity[_dictionaryCache.GetParityCode(_device.ParityId)],
                        _moxaWebPortType[_dictionaryCache.GetPortTypeCode(_device.PortTypeId)]);
            }
            if (_moxaModel == TransportServerModel.Moxa5150A)
            {
                return
                    string.Format(
                        "http://{0}/Set.htm?BaudRate={1}&DataBits={2}&StopBits={3}&Parity={4}&Port=1&Submit=Submit&setfunc=Communication+Parameters",
                        _device.AccessPoint.NetAddress, _moxaWebBaudRates[_dictionaryCache.GetBaudCode(_device.BaudId)],
                        _moxaWebDataBits[_dictionaryCache.GetDataBitCode(_device.DataBitId)],
                        _moxaWebStopBits[_dictionaryCache.GetStopBitCode(_device.StopBitId)], _moxaWebParity[_dictionaryCache.GetParityCode(_device.ParityId)]);
            }
            if (_moxaModel == TransportServerModel.Moxa5250A)
            {
                return
                    string.Format(
                        "http://{0}/Set.htm?BaudRate={1}&DataBits={2}&StopBits={3}&Parity={4}&ApplyAll=ON&Port=1&Submit=Submit&setfunc=Communication+Parameters",
                        _device.AccessPoint.NetAddress, _moxaWebBaudRates[_dictionaryCache.GetBaudCode(_device.BaudId)],
                        _moxaWebDataBits[_dictionaryCache.GetDataBitCode(_device.DataBitId)],
                        _moxaWebStopBits[_dictionaryCache.GetStopBitCode(_device.StopBitId)], _moxaWebParity[_dictionaryCache.GetParityCode(_device.ParityId)]);
            }

            return string.Empty;
        }

        /// <summary>
        /// Формирует строку GET-запроса для перезагрузки модема
        /// </summary>
        private string GetRestartUrl()
        {
            if (_moxaModel == TransportServerModel.Moxa5110 || _moxaModel == TransportServerModel.Moxa5150)
            {
                return string.Format("http://{0}/09Set.htm?", _device.AccessPoint.NetAddress);
            }
            if (_moxaModel == TransportServerModel.Moxa5150A || _moxaModel == TransportServerModel.Moxa5250A)
            {
                return string.Format("http://{0}/saverst.htm", _device.AccessPoint.NetAddress);
            }
            return string.Empty;
        }

        /// <summary>
        /// Устанавливает необходимые настройки модема
        /// </summary>
        public void SetSettings()
        {
            using (var webClient = new WebClient())
            {
                // установка необходимых настроек
                var settingUrl = GetSettingUrl();
                webClient.DownloadString(settingUrl);

                // перезагрузка модема
                var restartUrl = GetRestartUrl();
                webClient.DownloadString(restartUrl);
            }
        }

        private Dictionary<string, string> _moxaWebBaudRates
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "1200", "7" },
                    { "2400", "9" },
                    { "4800", "10" },
                    { "9600", "12" },
                    { "19200", "13" },
                    { "38400", "14" },
                    { "57600", "15" },
                    { "115200", "16" }
                };
            }
        }

        private Dictionary<string, string> _moxaWebDataBits
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "5", "0" },
                    { "6", "1" },
                    { "7", "2" },
                    { "8", "3" }
                };
            }
        }

        private Dictionary<string, string> _moxaWebStopBits
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "One",  "0" },
                    { "OnePointFive", "3" },
                    { "Two", "4" }
                };
            }
        }

        private Dictionary<string, string> _moxaWebParity
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "None", "00" },
                    { "Odd", "08" },
                    { "Even", "24" },
                    { "Mark", "40" },
                    { "Space", "56" },
                    { "Empty", "00" }
                };
            }
        }

        private Dictionary<string, string> _moxaWebPortType
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "RS232", "0" },
                    { "RS232Power", "0 "},
                    { "RS422", "1" },
                    { "RS485_2Wire", "2" },
                    { "RS485_4Wire", "3" }
                };
            }
        }
    }
}

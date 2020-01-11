using EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.MeteoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using Reader = EnergyTechAudit.PowerAccounting.LightDataAccess.Business.DeviceReader;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
//using EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.Types.OpenWeather;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo
{
    public class BaseDispatcher
    {
        private readonly Reader _deviceReader;
        private readonly List<MeteoDataSourceType> _meteoDataSourceTypes;
        private readonly List<City> _cityCache;
        private readonly ServerCommunicatorHelper _serverCommunicatorHelper;
        private readonly MeasurementDevice _meteoMeasurementDevice;

        private List<MeteoService> _meteoServices = new List<MeteoService>();
        private readonly Timer _timer = new Timer();

        public static Dictionary<string, int> ParametersMap = new Dictionary<string, int>()
        {
            { AbstractParameters.MonitoringTemperMeteoOutdoorAir, 5010 },
            { AbstractParameters.MonitoringHumidityMeteoOutdoorAir, 5011 },
            { AbstractParameters.MonitoringPressureMeteoAtmosphere, 5012 }
        };

        public BaseDispatcher(int deviceReaderId)
        {
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        _deviceReader = context.Set<Reader>().Include("User").FirstOrDefault(p => p.Id == deviceReaderId);

                        // находим первый попавшийся прибор-метеостанция
                        _meteoMeasurementDevice = context.Set<MeasurementDevice>().FirstOrDefault(p => p.DeviceId == (int)Common.Types.Proxy.DeviceModel.MeteoStation);
                        
                        if(_deviceReader != null)
                        {
                            _serverCommunicatorHelper = new ServerCommunicatorHelper(new ServerCommunicatorSettings(_deviceReader));
                        }

                        _cityCache = context.Set<City>().ToList();
                        _meteoDataSourceTypes = context.Set<MeteoDataSourceType>().Where(p => p.IsUse).ToList();

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }

            InitMeteoServices();
        }

        /// <summary>
        /// Инициализирует коллекцию метеосервисов
        /// </summary>
        private void InitMeteoServices()
        {
            if (_meteoDataSourceTypes != null && _meteoDataSourceTypes.Count() > 0)
            {
                foreach (MeteoDataSourceType meteoDataSourceType in _meteoDataSourceTypes)
                {
                    var meteoServiceType = Type.GetType(string.Format(DeviceMessages.MeteoServiceTypePattern, meteoDataSourceType.Code), false);

                    if (meteoServiceType != null)
                    {
                        _meteoServices.Add((MeteoService)Activator.CreateInstance(meteoServiceType, meteoDataSourceType.Settings, _cityCache, _meteoMeasurementDevice));
                    }
                }
            }
        }

        private void InitTimer()
        {
            _timer.Interval = _deviceReader != null ? _deviceReader.QueuePollingInterval * 1000 : 900000;
            _timer.Elapsed += CollectMeteoData;
            _timer.Start();
        }

        public void Run()
        {
            if (_meteoServices != null && _meteoServices.Count > 0)
            {
                InitTimer();
            }
        }

        private void CollectMeteoData(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timer.Stop();
                foreach(MeteoService meteoService in _meteoServices)
                {
                    meteoService.ReadMeteoData();
                    meteoService.SaveMeteoData();
                }

                SendOutdoorTemperatureToDashboard();

                _timer.Start();
            }
            catch
            {
                if(_timer != null)
                {
                    _timer.Start();
                }
            }
        }

        /// <summary>
        /// Собирает и отправляет метеоданные на IIS-сервер
        /// </summary>
        private void SendOutdoorTemperatureToDashboard()
        {
            _serverCommunicatorHelper.SendMeteoDataToDashboard(string.Empty);
        }
    }
}

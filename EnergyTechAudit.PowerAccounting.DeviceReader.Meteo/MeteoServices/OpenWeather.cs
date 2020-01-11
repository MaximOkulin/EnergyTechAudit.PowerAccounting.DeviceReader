using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.Types.OpenWeather;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using CityModel = EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries.City;
using System.Net;
using System.IO;
using System.Text;
using EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.Types.OpenWeather.Response;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using Ex = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions.BaseExtensions;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.MeteoServices
{
    internal class OpenWeather : MeteoService
    {
        private readonly OpenWeatherSettings _openWeatherSettings;
        private List<CityForRead> _citiesForRead = new List<CityForRead>();
        private List<ParameterForRead> _parametersForRead = new List<ParameterForRead>();

        public OpenWeather(string settings, List<CityModel> cityCache, MeasurementDevice meteoMeasurementDevice): base(settings, cityCache, meteoMeasurementDevice)
        {
            _openWeatherSettings = JsonConvert.DeserializeObject<OpenWeatherSettings>(settings);
            Init();
        }

        /// <summary>
        /// Инициализирует города и метеопараметры, по которым нужно читать метеоданные
        /// </summary>
        private void Init()
        {
            if(_openWeatherSettings != null)
            {
                var citiesForRead = _openWeatherSettings.Cities.Where(p => p.Enabled).ToList();

                foreach(City city in citiesForRead)
                {
                    var cityFromCache = CityCache.FirstOrDefault(p => p.Code.Equals(city.Name, StringComparison.Ordinal));

                    if (cityFromCache != null)
                    {
                        _citiesForRead.Add(new CityForRead
                        {
                            City = city,
                            CityId = cityFromCache.Id
                        });
                    }
                }

                foreach(Parameter parameter in _openWeatherSettings.Parameters)
                {
                    int value = 0;
                    var parseResult = BaseDispatcher.ParametersMap.TryGetValue(parameter.Code, out value);

                    if(parseResult)
                    {
                        _parametersForRead.Add(new ParameterForRead
                        {
                            Code = parameter.Code,
                            Id = value,
                            DimensionId = GetDimensionId(parameter.Code),
                            MeasurementUnitId = GetMeasurementUnitId(parameter.Code)
                        });
                    }
                }
            }
        }

        private int GetDimensionId(string parameterCode)
        {
            if(parameterCode.Equals(AbstractParameters.MonitoringPressureMeteoAtmosphere, StringComparison.Ordinal))
            {
                return (int)Dimensions.Hecto;
            }

            return (int)Dimensions.Empty;
        }

        private int GetMeasurementUnitId(string parameterCode)
        {
            if (parameterCode.Equals(AbstractParameters.MonitoringTemperMeteoOutdoorAir, StringComparison.Ordinal))
            {
                return (int)MeasurementUnit.Celsius;
            }
            else if(parameterCode.Equals(AbstractParameters.MonitoringHumidityMeteoOutdoorAir, StringComparison.Ordinal))
            {
                return (int)MeasurementUnit.Percent;
            }
            else if (parameterCode.Equals(AbstractParameters.MonitoringPressureMeteoAtmosphere, StringComparison.Ordinal))
            {
                return (int)MeasurementUnit.Pascal;
            }

            return (int)MeasurementUnit.Empty;
        }

        /// <summary>
        /// Выполняет чтение метеоданных
        /// </summary>
        public override void ReadMeteoData()
        {
            foreach(CityForRead cityForRead in _citiesForRead)
            {
                foreach(ParameterForRead parameterForRead in _parametersForRead)
                {
                    CreateMeteoData(cityForRead, parameterForRead);                    
                }
            }
        }

        private void CreateMeteoData(CityForRead cityForRead, ParameterForRead parameterForRead)
        {
            string resultJson = ExecuteWebRequest(string.Format(_openWeatherSettings.Url, cityForRead.City.OpenWeatherId));
            MeteoObject meteoObject = null;

            if (resultJson != null && !string.IsNullOrEmpty(resultJson))
            {
                try
                {
                    meteoObject = JsonConvert.DeserializeObject<MeteoObject>(resultJson);
                }
                catch
                {
                    meteoObject = null;
                }
            }

            if (meteoObject != null && meteoObject.GetValue(parameterForRead.Code) != null)
            {
                var cityLatinCode = CityCache.FirstOrDefault(p => p.Id == cityForRead.CityId).LatinCode;
                var parameterName =  BaseDispatcher.ParametersMap.FirstOrDefault(p => p.Value == parameterForRead.Id).Key.Replace(Resources.Common.DotSymbol, Resources.Common.UnderscoreSymbol);

                ArchiveCollector.CreateInstantArchives(new Common.Types.ValueInfo
                {
                    Value = meteoObject.GetValue(parameterForRead.Code).Value,
                    //MeteoStation_Monitoring_Temper_MeteoOutdoorAir_Kazan
                    DeviceParameterId = Ex.GetDeviceParameterIdByName(string.Format(Resources.Common.ThreeSimplePartsDivideUnderlineStringFormat, 
                                                                      DeviceMessages.MeteoStation, parameterName, cityLatinCode))
                });

                
            }            
        }        

        private string ExecuteWebRequest(string url)
        {
            var webRequest = WebRequest.Create(url);

            StringBuilder response = new StringBuilder(1000);

            using (Stream stream = webRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    string sLine = string.Empty;

                    while (sLine != null)
                    {
                        sLine = streamReader.ReadLine();

                        response.Append(sLine);
                    }
                }
            }

            return response.ToString();
        }
    }
}

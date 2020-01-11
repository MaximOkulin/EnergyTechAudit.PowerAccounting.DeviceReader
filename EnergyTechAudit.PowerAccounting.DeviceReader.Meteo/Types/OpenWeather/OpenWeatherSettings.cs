using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.Types.OpenWeather
{
    public class OpenWeatherSettings
    {
        public string Url { get; set; }
        public List<City> Cities { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}

using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.Types
{
    public class Weather
    {
        public string CityCode { get; set; }
        public List<ParameterValue> Values { get; set; }
        public string Time { get; set; }
    }
}

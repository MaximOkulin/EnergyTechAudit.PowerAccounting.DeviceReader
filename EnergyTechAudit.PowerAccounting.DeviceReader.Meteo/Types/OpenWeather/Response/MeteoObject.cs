using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.Types.OpenWeather.Response
{
    internal class MeteoObject
    {
        public Main Main { get; set; }

        public decimal? GetValue(string parameterCode)
        {
            if(parameterCode.Equals(AbstractParameters.MonitoringTemperMeteoOutdoorAir, StringComparison.Ordinal))
            {
                return Main.Temp;
            }
            else if(parameterCode.Equals(AbstractParameters.MonitoringHumidityMeteoOutdoorAir, StringComparison.Ordinal))
            {
                return Main.Humidity;
            }
            else if(parameterCode.Equals(AbstractParameters.MonitoringPressureMeteoAtmosphere, StringComparison.Ordinal))
            {
                return Main.Pressure;
            }

            return null;
        }
    }
}

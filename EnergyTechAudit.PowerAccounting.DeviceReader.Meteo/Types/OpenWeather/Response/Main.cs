using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.Types.OpenWeather.Response
{
    internal class Main
    {
        private decimal _temp;
        
        public decimal Temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15M;
            }
        }

        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
    }
}

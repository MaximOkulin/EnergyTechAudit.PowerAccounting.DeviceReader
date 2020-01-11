using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Integrating;
using System;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Types
{
    public class CurrentTotals
    {
        public DateTime Time { get; set; }
        public List<Parameter> Parameters { get; set;}
        public int HeatSystemNumber { get; set; }
    }
}

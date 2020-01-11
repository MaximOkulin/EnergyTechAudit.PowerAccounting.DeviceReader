using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Integrating
{
    public class IntegratorsReferencePoint
    {
        public PeriodType PeriodType { get; set; }
        public DateTime Date { get; set; }
        public List<Parameter> Parameters { get; set; }
        public List<Area> Areas { get; set; }
        public int HeatSystemNumber { get; set; }
    }
}

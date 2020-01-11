using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Integrating
{
    public class Area
    {
        public AreaType AreaType { get; set; }
        public bool IsFullCalculated { get; set; }
        public DateTime LastCalculatedDate { get; set; }
    }
}

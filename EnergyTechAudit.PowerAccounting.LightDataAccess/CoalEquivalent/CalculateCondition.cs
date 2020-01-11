using System;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.CoalEquivalent
{
    public class CalculateCondition
    {
        public DateTime LastHourCalculatedDate { get; set; }
        public DateTime LastDayCalculatedDate { get; set; }
        public int ScaleCoefficent { get; set; }
        public int TargetDeviceParameterId { get; set; }
        public List<Argument> Arguments { get; set; }
        public string DenominatorZeroCheckCondition { get; set; }
        public string Condition { get; set; }
    }
}

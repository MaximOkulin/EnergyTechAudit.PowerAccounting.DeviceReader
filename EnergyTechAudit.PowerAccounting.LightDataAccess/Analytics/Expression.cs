using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics
{
    public class Expression
    {
        public bool IsIntegralArchiveValue { get; set; }
        public List<Argument> Arguments { get; set; }
        public List<ConditionPart> ConditionParts { get; set; }
        public string Condition { get; set; }
        public string NullArgumentsCheck { get; set; }
        public List<PreCondition> PreConditions { get; set; }
    }
}

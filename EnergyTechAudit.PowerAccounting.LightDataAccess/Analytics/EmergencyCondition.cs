using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics
{
    public class EmergencyCondition
    {
        public bool IsArchiveIntegralityDepends { get; set; }

        public string Name { get; set; }

        public List<Requirement> Requirements { get; set; }

        public List<UserInputValue> UserInputValues { get; set; }

        public List<Expression> Expressions { get; set; }
    }
}

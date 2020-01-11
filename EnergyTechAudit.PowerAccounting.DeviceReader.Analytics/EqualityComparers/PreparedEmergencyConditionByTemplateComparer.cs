using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.EqualityComparers
{
    /// <summary>
    /// Сравниватель параметров нештатных ситуаций по одинаковости шаблонов нештатных ситуаций
    /// </summary>
    public class PreparedEmergencyConditionByTemplateComparer : IEqualityComparer<PreparedEmergencyCondition>
    {
        public bool Equals(PreparedEmergencyCondition param1, PreparedEmergencyCondition param2)
        {
            return param1.EmergencySituationParameter.EmergencySituationParameterTemplateId == param2.EmergencySituationParameter.EmergencySituationParameterTemplateId;
        }

        public int GetHashCode(PreparedEmergencyCondition param)
        {
            return base.GetHashCode();
        }
    }
}

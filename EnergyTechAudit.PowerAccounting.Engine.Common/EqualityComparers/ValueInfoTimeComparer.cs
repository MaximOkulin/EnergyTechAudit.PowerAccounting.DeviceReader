using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.EqualityComparers
{
    public class ValueInfoTimeComparer : IEqualityComparer<ValueInfo>
    {
        public bool Equals(ValueInfo vi1, ValueInfo vi2)
        {
            return vi1.Time == vi2.Time;
        }

        public int GetHashCode(ValueInfo vi)
        {
            return base.GetHashCode();
        }
    }
}

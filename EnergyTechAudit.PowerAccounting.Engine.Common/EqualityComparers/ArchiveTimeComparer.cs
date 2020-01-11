using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.EqualityComparers
{
    public class ArchiveTimeComparer : IEqualityComparer<Archive>
    {
        public bool Equals(Archive arc1, Archive arc2)
        {
            return arc1.Time == arc2.Time;
        }

        public int GetHashCode(Archive obj)
        {
            return base.GetHashCode();
        }
    }
}

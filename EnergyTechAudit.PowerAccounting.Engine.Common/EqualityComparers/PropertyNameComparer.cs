using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.EqualityComparers
{
    public class PropertyNameComparer : IEqualityComparer<EntityHistory>
    {
        public bool Equals(EntityHistory x, EntityHistory y)
        {
            return x.PropertyName == y.PropertyName;
        }

        public int GetHashCode(EntityHistory obj)
        {
            return base.GetHashCode();
        }
    }
}

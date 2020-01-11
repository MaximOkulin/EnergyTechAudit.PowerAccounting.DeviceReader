using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.EqualityComparers
{
    public class EntityIdComparer : IEqualityComparer<EntityHistory>
    {
        public bool Equals(EntityHistory x, EntityHistory y)
        {
            return x.EntityId == y.EntityId;
        }

        public int GetHashCode(EntityHistory obj)
        {
            return base.GetHashCode();
        }
    }
}

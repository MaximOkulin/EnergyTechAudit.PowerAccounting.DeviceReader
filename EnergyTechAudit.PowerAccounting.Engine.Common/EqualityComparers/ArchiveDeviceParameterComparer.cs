using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.EqualityComparers
{
    public class ArchiveDeviceParameterComparer : IEqualityComparer<Archive>
    {
        public bool Equals(Archive arc1, Archive arc2)
        {
            return arc1.DeviceParameterId == arc2.DeviceParameterId;
        }

        public int GetHashCode(Archive obj)
        {
            return base.GetHashCode();
        }
    }
}

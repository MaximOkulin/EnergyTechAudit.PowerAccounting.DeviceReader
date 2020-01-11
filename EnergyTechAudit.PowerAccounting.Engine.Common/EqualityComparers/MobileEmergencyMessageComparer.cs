using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.EqualityComparers
{
    public class MobileEmergencyMessageComparer : IEqualityComparer<MobileEmergencyMessage>
    {
        public bool Equals(MobileEmergencyMessage m1, MobileEmergencyMessage m2)
        {
            return m1.MobileDeviceId == m2.MobileDeviceId;
        }

        public int GetHashCode(MobileEmergencyMessage obj)
        {
            return base.GetHashCode();
        }
    }
}

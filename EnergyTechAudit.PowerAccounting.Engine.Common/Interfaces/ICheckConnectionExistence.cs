using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces
{
    public interface ICheckConnectionExistence
    {
        Dictionary<string, string> CheckConnectionQuality();
    }
}

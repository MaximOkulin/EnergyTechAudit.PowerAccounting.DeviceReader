using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces
{
    public interface IReadCurrents
    {
        Dictionary<string, string> ReadCurrents();
    }
}

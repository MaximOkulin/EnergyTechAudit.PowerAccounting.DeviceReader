using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types
{
    [Flags]
    public enum FinalInstantParamsSet
    {
        TimeNormal = 0x01,
        Volume1 = 0x02,
        Volume2 = 0x04,
        Volume3 = 0x08,
        Mass1 = 0x10,
        Mass2 = 0x20,
        Mass3 = 0x40,
        Heat = 0x80
    }
}

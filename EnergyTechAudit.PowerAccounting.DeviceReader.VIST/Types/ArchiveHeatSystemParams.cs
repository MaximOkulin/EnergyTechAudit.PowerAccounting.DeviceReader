using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types
{
    [Flags]
    public enum ArchiveHeatSystemParams
    {
        Errors = 0x8000,
        Heat = 0x4000,
        IdleTime = 0x400000,
        Mass1 = 0x10,
        Mass2 = 0x20,
        Mass3 = 0x40,
        Press1 = 0x800,
        Press2 = 0x1000,
        Press3 = 0x2000,
        Reserved = 0x100000,
        Temp1 = 0x80,
        Temp2 = 0x100,
        Temp3 = 0x200,
        TempOutdoor = 0x400,
        TimeDeltaTLow = 0x40000,
        TimeFlowOverrun = 0x20000,
        TimeFlowUnderrun = 0x10000,
        TimeNoPower = 0x80000,
        TotalTime = 0x200000,
        Vol1 = 2,
        Vol2 = 4,
        Vol3 = 8,
        Worktime = 1
    }
}

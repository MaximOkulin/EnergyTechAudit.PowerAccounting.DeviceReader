using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types
{
    [Flags]
    public enum InstantParamsSet
    {
        VolumeFlow1 = 0x01,
        VolumeFlow2 = 0x02,
        VolumeFlow3 = 0x04,
        MassFlow1 = 0x08,
        MassFlow2 = 0x10,
        MassFlow3 = 0x20,
        Temperature1 = 0x40,
        Temperature2 = 0x80,
        Temperature3 = 0x100,
        Temperature4 = 0x200,
        Pressure1 = 0x400,
        Pressure2 = 0x800,
        Pressure3 = 0x1000,
        ThermalPower = 0x2000
    }
}

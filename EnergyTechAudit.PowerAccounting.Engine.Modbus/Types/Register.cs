using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Modbus.Types
{
    public class Register
    {
        public PeriodType PeriodType {get; set;}
        public bool IsRegulatorParameter { get; set; }
        public ModbusFunctionCode ModbusFunctionCode { get; set; }
        public int Count { get; set; }
        public int StartAddress { get; set; }
        public string Type { get; set; }
        public int StartDeviceParameterId { get; set; }
        public int Scale { get; set; }
    }
}

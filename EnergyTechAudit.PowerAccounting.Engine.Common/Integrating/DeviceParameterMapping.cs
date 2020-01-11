using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Integrating
{
    public class DeviceParameterMapping
    {
        public DeviceParameter TotalDeviceParameter { get; set; }
        public DeviceParameter DiffDeviceParameter { get; set; }
        public DeviceParameter SumDeviceParameter { get; set; }
    }
}

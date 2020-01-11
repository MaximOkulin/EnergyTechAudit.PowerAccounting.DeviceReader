using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class AccessPointInfo
    {
        public AccessPoint AccessPoint { get; set; }
        public CsdModem CsdModem { get; set; }
        public DeviceSnip CsdModemDeviceSnip { get; set; }
    }
}

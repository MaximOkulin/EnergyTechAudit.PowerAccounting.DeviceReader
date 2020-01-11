using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips
{
    public class AccessPointSnip : ISuccessConnectionPercent
    {
        public string Description;
        public int Id;
        public int TransportTypeId;
        public int TransportServerModelId;
        public string Identifier;
        public DateTime LastConnectionTime { get; set; }
        public double SuccessConnectionPercent { get; set; }
        public int? CsdModemId;
    }
}

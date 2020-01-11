using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips
{
    public class EntityHistorySnip
    {
        public string User { get; set; }
        public DateTime Time { get; set; }
        public int DeviceReaderId { get; set; }
        public string CurrentValue { get; set; }
    }
}

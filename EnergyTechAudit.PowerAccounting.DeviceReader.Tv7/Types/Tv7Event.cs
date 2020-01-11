using System;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types
{
    public class Tv7Event
    {
        public AsyncArchiveType AsyncArchiveType { get; set; }
        public int InternalDeviceEventId { get; set; }
        public int EventNumber { get; set; }
        public Func<byte[], string> ValueParser { get; set; }

        public Func<InternalDeviceEvent, int, int, string> CreateDescription { get; set; }
    }
}

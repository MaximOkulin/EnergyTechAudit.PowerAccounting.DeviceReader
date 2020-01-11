using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.SystemSettings
{
    public class SystemSettingFromCustomData
    {
        public List<MeteoService> MeteoService { get; set; }
        public DeliveryService DeliveryService { get; set; }
        public Analytics Analytics { get; set; }
        public string ServerName { get; set; }
        public string ServerUri { get; set; }
    }
}

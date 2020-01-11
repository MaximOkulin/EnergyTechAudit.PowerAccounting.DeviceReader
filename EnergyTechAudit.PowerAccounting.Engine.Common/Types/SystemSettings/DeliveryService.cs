using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.SystemSettings.Security;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.SystemSettings
{
    public class DeliveryService
    {
        public int CacheUpdateMinutes { get; set; }
        public int MessageRepetitionMinutes { get; set; }
        public WhatsAppCredentials WhatsAppCredentials { get; set; }
    }
}

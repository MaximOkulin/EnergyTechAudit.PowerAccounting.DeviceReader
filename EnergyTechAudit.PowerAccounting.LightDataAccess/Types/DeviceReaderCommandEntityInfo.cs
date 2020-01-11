using Newtonsoft.Json;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Types
{
    public class DeviceReaderCommandEntityInfo : EntityInfo
    {
        [JsonProperty("command")]
        public DeviceReaderCommand Command { get; set; }

        [JsonProperty("customData")]
        public string CustomData { get; set; }

        [JsonProperty("targetEntityTypeName")]
        public string TargetEntityTypeName { get; set; }
    }
}

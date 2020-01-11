using Newtonsoft.Json;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Types
{
    public class EntityInfo
    {
        [JsonProperty("entityId")]
        public int EntityId { get; set; }

        [JsonProperty("entityTypeName")]
        public string EntityTypeName { get; set; }

        public bool IsTypeOf<T>()
        {
            return typeof(T).Name == EntityTypeName;
        }
    }
}

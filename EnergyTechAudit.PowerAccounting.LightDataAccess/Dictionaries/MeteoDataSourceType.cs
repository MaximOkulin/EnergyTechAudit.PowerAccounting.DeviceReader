using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("MeteoDataSourceType", Schema = "Dictionaries")]
    public class MeteoDataSourceType : DictionaryEntityBase
    {
        [Required]
        public bool IsUse { get; set; }

        public string Settings { get; set; }
    }
}

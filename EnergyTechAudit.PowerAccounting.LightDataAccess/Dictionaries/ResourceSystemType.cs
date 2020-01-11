using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("ResourceSystemType", Schema ="Dictionaries")]
    public class ResourceSystemType : DictionaryEntityBase
    {
        [Required]
        public string ShortName { get; set; }
    }
}

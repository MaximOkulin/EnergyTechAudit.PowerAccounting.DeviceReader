using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("Dimension", Schema = "Dictionaries")]
    public class Dimension : DictionaryEntityBase
    {
        public string Prefix { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}

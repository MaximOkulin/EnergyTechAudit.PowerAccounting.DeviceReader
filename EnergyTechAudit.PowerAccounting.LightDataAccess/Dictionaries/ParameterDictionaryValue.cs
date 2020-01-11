using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("ParameterDictionaryValue", Schema = "Dictionaries")]
    public class ParameterDictionaryValue : DictionaryEntityBase
    {
        [Required]
        public int ParameterDictionaryId { get; set; }

        [Required]
        public decimal Value { get; set; }
    }
}

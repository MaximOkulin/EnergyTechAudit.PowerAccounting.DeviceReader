using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Core
{
    [Table("DynamicParameterValue", Schema = "Core")]
    public class DynamicParameterValue : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        public int DynamicParameterId { get; set; }

        [Required]
        public string Value { get; set; }

        [ForeignKey("DynamicParameterId")]        
        public virtual Dictionaries.DynamicParameter DynamicParameter { get; set; }
    }
}

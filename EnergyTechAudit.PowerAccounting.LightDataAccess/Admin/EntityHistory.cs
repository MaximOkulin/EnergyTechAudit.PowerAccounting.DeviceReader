using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Admin
{
    [Table("EntityHistory", Schema = "Admin")]
    public class EntityHistory : IEntity
    {
        [Key]       
        public int Id { get; set; }

        [Required]
        public string PropertyName { get; set; }

        [Required]
        public int EntityId { get; set; }

        public string EntityTypeName { get; set; }

        public string EntityTypeDescription { get; set; }

        public string PropertyDescription { get; set; }

        public string OriginalValue { get; set; }

        public string CurrentValue { get; set; }

        public string User { get; set; }

        public DateTime DateTime { get; set; }
    }
}

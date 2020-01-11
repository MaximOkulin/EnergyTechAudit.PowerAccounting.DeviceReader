using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("EmergencySituationParameter", Schema = "Business")]
    public class EmergencySituationParameter : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool TurnOn { get; set; }

        [Required]
        public int ChannelId { get; set; }

        [Required]
        public int SeasonTypeId { get; set; }

        [Required]
        public string EntityTypeName { get; set; }

        public string Description { get; set; }

        [Required]
        public string PredicateExpression { get; set; }

        [Required]
        public int EmergencySituationParameterTemplateId { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [InverseProperty("EmergencySituationParameter")]
        public virtual ICollection<MobileEmergencyMessage> MobileEmergencyMessages { get; private set; }
    }
}

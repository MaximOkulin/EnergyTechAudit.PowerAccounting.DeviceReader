using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("EmergencyLog", Schema ="Business")]
    public class EmergencyLog : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmergencySituationParameterId { get; set; }

        public string Value { get; set; }
        public string ShortTitle { get; set; }

        public DateTime? RecoveryTime { get; set; }

        [Required]
        public int EmergencyTimeSignatureId { get; set; }

        [ForeignKey("EmergencyTimeSignatureId")]
        public virtual EmergencyTimeSignature EmergencyTimeSignature { get; set; }

        [ForeignKey("EmergencySituationParameterId")]
        public virtual EmergencySituationParameter EmergencySituationParameter { get; set; }
    }
}

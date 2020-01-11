using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("EmergencyTimeSignature", Schema = "Business")]
    public class EmergencyTimeSignature : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}

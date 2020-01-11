using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("UserLinkEmergencyNotificationType", Schema = "Business")]
    public class UserLinkEmergencyNotificationType : IEntity
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public int EmergencySituationParameterId { get; set; }

        [Required]
        public int NotificationTypeId { get; set; }

        [Required]
        public int RepetitionMinutes { get; set; }

        [Required]
        public int UserAdditionalInfoId { get; set; }
    }
}

using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("EmergencyMessage", Schema = "Business")]
    public class EmergencyMessage : IEntity, ICloneable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NotificationTypeId { get; set; }

        [Required]
        public int UserAdditionalInfoId { get; set; }

        public string Text { get; set; }

        [Required]
        public int EmergencyLogId { get; set; }

        [ForeignKey("EmergencyLogId")]
        public EmergencyLog EmergencyLog { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public object Clone()
        {
            return new EmergencyMessage
            {
                Time = Time,
                NotificationTypeId = NotificationTypeId,
                UserAdditionalInfoId = UserAdditionalInfoId,
                EmergencyLogId = EmergencyLogId,
                Text = Text
            };
        }
    }
}

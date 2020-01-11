using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("Channel", Schema ="Business")]
    public class Channel: IEntity
    {
        public Channel()
        {
            MobileEmergencyMessages = new List<MobileEmergencyMessage>();
        }

        [Key]        
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]        
        public int ResourceSystemTypeId { get; set; }

        [ForeignKey("ResourceSystemTypeId")]
        public virtual ResourceSystemType ResourceSystemType { get; set; }

        [Required]
        public int ChannelTemplateId { get; set; }

        [Required]        
        public int MeasurementDeviceId { get; set; }

        [ForeignKey("MeasurementDeviceId")]
        public MeasurementDevice MeasurementDevice { get; set; }

        public int? LastEmergencyTimeSignatureId { get; set; }

        public int? MnemoschemeId { get; set; }

        public int? ResourceSubsystemTypeId { get; set; }

        [Required]
        public int PlacementId { get; set; }

        [ForeignKey("PlacementId")]
        public virtual Placement Placement { get; set; }

        [InverseProperty("Channel")]
        public virtual ICollection<MobileEmergencyMessage> MobileEmergencyMessages { get; private set; }

        public int? OrganizationId { get; set; }

        public int TechnologicAdjunctionTypeId { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

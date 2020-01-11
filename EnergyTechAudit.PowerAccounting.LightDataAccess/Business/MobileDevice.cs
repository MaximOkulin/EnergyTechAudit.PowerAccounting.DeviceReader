using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("MobileDevice", Schema = "Business")]
    public class MobileDevice : IEntity
    {
        public MobileDevice()
        {
            IsActive = true;
        }

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Imei { get; set; }
        public string Model { get; set; }
        public string Os { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastConnectionDate { get; set; }

        public string FcmToken { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [InverseProperty("MobileDevice")]
        public virtual ICollection<MobileEmergencyMessage> MobileEmergencyMessages { get; private set; }
    }
}

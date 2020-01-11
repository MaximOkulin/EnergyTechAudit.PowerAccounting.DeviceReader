using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Admin
{
    [Table("User", Schema = "Admin")]
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(32)]
        public string UserName { get; set; }

        public string Password { get; set; }

        [MaxLength(512)]
        public byte[] EncryptedPassword { get; set; }

        [Required]
        public int RoleId { get; set; }

        public bool IsApproved { get; set; }
        public bool IsTemporary { get; set; }
        public DateTime ExpiredDate { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<DeviceReader> DeviceReaders { get; private set; }        
    }
}

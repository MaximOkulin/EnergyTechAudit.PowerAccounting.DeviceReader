using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("AccessPointStatusConnectionLog", Schema = "Business")]
    public class AccessPointStatusConnectionLog : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AccessPointId { get; set; }

        [Required]
        public int StatusConnectionId { get; set; }

        [Required]
        public DateTime ConnectionTime { get; set; }
    }
}

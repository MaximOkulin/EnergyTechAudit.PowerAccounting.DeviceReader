using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("MeasurementDeviceStatusConnectionLog", Schema = "Business")]
    public class MeasurementDeviceStatusConnectionLog : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MeasurementDeviceId { get; set; }

        [Required]
        public int StatusConnectionId { get; set; }

        [Required]
        public DateTime ConnectionTime { get; set; }
    }
}

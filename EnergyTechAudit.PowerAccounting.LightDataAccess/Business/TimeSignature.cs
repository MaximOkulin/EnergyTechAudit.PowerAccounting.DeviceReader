using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("TimeSignature", Schema ="Business")]
    public class TimeSignature: IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public DateTime DeviceTime { get; set; }

        [Required]        
        public int MeasurementDeviceId { get; set; }

        public int PollingDuration { get; set; }
    }
}

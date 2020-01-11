using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("DeviceEvent", Schema = "Business")]
    public class DeviceEvent : IEntity<long>
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int DeviceEventParameterId { get; set; }

        [Required]
        public decimal State { get; set; }

        [Required]
        public int MeasurementDeviceId { get; set; }

        [ForeignKey("DeviceEventParameterId")]
        public virtual DeviceEventParameter DeviceEventParameter { get; set; }
    }
}

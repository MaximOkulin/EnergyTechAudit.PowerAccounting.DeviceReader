using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("DeviceTechnicalParameter", Schema = "Business")]
    public class DeviceTechnicalParameter : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MeasurementDeviceId { get; set; }

        [Required]
        public int DeviceParameterId { get; set; }

        public int DeviceValue { get; set; }

        public string StringValue { get; set; }

        public DateTime Time { get; set; }

        [ForeignKey("MeasurementDeviceId")]
        public virtual MeasurementDevice MeasurementDevice { get; set; }

        [ForeignKey("DeviceParameterId")]
        public virtual DeviceParameter DeviceParameter { get; set; }
    }
}

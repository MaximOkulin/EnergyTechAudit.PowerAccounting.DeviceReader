using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("RegulatorParameterValue", Schema = "Business")]
    public class RegulatorParameterValue : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MeasurementDeviceId { get; set; }

        [Required]
        public decimal DeviceValue { get; set; }

        [Required]
        public decimal UserValue { get; set; }

        public DateTime? UpdateUserValueTime { get; set; }

        [Required]
        public DateTime SyncDeviceTime { get; set; }

        public int DeviceParameterId { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        [ForeignKey("MeasurementDeviceId")]
        public virtual MeasurementDevice MeasurementDevice { get; set; }

        public bool IsNeedToUpdate()
        {
            return DeviceValue != UserValue && UpdateUserValueTime == null;
        }
    }
}

using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("Archive", Schema = "Business")]
    public class Archive : IEntity<long>, ICloneable
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int TimeSignatureId { get; set; }

        [ForeignKey("TimeSignatureId")]
        public virtual TimeSignature TimeSignature { get; set; }

        [Required]
        public int PeriodTypeId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public bool IsValid { get; set; }

        [Required]
        public int MeasurementDeviceId { get; set; }

        [ForeignKey("MeasurementDeviceId")]
        public virtual MeasurementDevice MeasurementDevice { get; set; }

        [Required]
        public int DeviceParameterId { get; set; }

        public object Clone()
        {
            return new Archive
            {
                TimeSignatureId = TimeSignatureId,
                PeriodTypeId = PeriodTypeId,
                Time = Time,
                Value = Value,
                MeasurementDeviceId = MeasurementDeviceId,
                DeviceParameterId = DeviceParameterId,
                IsValid = IsValid
            };
        }
    }
}

using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("IntegrationArchiveInfo", Schema ="Business")]
    public class IntegrationArchiveInfo : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MeasurementDeviceId { get; set; }

        [Required]
        public int PeriodTypeId { get; set; }

        [Required]
        public int DiffDeviceParameterId { get; set; }

        public DateTime? LastCalculatedDate { get; set; }

        public DateTime? CurrentArchiveDate { get; set; }
    }
}

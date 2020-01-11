using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("MeasurementDeviceJournal", Schema = "Business")]
    public class MeasurementDeviceJournal : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int MeasurementDeviceId { get; set; }

        [Required]
        public int InternalDeviceEventId { get; set; }

        public string Description { get; set; }

        public string OriginalValue { get; set; }

        public string CurrentValue { get; set; }        
    }
}

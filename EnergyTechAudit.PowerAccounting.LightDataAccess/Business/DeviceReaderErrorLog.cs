using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("DeviceReaderErrorLog", Schema = "Business")]
    public class DeviceReaderErrorLog : IEntity
    {
        [Key]       
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public string Text { get; set; }

        public int? ErrorTypeId { get; set; }

        public int? DeviceReaderId { get; set; }

        public int? MeasurementDeviceId { get; set; }

        public string Exception { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}

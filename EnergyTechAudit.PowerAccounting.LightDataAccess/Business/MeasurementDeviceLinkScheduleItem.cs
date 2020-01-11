using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("MeasurementDeviceLinkScheduleItem", Schema = "Business")]
    public class MeasurementDeviceLinkScheduleItem
    {
        [Required]
        public int MeasurementDeviceId { get; set; }
        [Required]
        public int ScheduleItemId { get; set; }
    }
}

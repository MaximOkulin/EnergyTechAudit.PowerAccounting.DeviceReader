using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("DeviceReaderLinkScheduleItem", Schema = "Business")]
    public class DeviceReaderLinkScheduleItem
    {
        [Required]
        public int DeviceReaderId { get; set; }

        [Required]
        public int ScheduleItemId { get; set; }
    }
}

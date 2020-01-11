using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("DeviceLinkDynamicParameter", Schema = "Business")]
    public class DeviceLinkDynamicParameter
    {
        [Required]
        public int DeviceId { get; set; }

        [Required]
        public int DynamicParameterId { get; set; }
    }
}

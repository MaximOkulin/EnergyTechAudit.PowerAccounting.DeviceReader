using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("AccessPointLinkBuilding", Schema = "Business")]
    public class AccessPointLinkBuilding
    {
        [Required]
        public int AccessPointId { get; set; }

        [Required]
        public int BuildingId { get; set; }
    }
}

using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("CsdModem", Schema = "Business")]
    public class CsdModem : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ComPortId { get; set; }

        [Required]
        public int DeviceId { get; set; }
    }
}

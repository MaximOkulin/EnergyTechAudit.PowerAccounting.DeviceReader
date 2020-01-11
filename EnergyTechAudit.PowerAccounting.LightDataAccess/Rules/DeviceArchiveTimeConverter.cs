using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Rules
{
    [Table("DeviceArchiveTimeConverter", Schema ="Rules")]
    public class DeviceArchiveTimeConverter : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [Required]
        public int PeriodTypeId { get; set; }

        [Required]
        public int Interval { get; set; }
    }
}

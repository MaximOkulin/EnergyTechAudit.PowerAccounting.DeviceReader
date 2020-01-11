using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("DeviceParameterSetting", Schema = "Business")]
    public class DeviceParameterSetting : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Min { get; set; }

        [Required]
        public decimal Max { get; set; }

        public string WriteMethodName { get; set; }

        [ForeignKey("Id")]
        public virtual DeviceParameter DeviceParameter { get; set; }
    }
}

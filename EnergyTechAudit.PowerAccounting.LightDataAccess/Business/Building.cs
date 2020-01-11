using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("Building", Schema = "Business")]
    public class Building : IEntity
    {
        [Key]       
        public int Id { get; set; }

        [Required]
        public int DistrictId { get; set; }
        public string Description { get; set; }
    }
}

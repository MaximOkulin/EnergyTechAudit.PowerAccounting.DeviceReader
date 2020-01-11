using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("Hub", Schema = "Business")]
    public class Hub : IEntity
    {
        [Key]        
        public int Id { get; set; }

        public int? DeviceReaderId { get; set; }

        
        [ForeignKey("DeviceReaderId")]
        public virtual DeviceReader DeviceReader { get; set; }
    }
}

using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("UserAdditionalInfo", Schema = "Business")]
    public class UserAdditionalInfo : IEntity
    {
        [Key]        
        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}

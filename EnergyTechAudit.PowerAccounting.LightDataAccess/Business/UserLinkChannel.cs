using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("UserLinkChannel", Schema = "Business")]
    public class UserLinkChannel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ChannelId { get; set; }
    }
}

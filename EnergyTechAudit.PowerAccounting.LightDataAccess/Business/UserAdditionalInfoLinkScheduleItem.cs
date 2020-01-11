using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("UserAdditionalInfoLinkScheduleItem", Schema = "Business")]
    public class UserAdditionalInfoLinkScheduleItem
    {
        [Required]
        public int UserAdditionalInfoId { get; set; }
        [Required]
        public int ScheduleItemId { get; set; }

        [ForeignKey("ScheduleItemId")]
        public virtual ScheduleItem ScheduleItem { get; set; }
    }
}

using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("District", Schema = "Dictionaries")]
    public class District : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}

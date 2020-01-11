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
    [Table("Parameter", Schema = "Dictionaries")]
    public class Parameter : DictionaryEntityBase
    {
        [Required]
        public int PhysicalParameterId { get; set; }
    }
}

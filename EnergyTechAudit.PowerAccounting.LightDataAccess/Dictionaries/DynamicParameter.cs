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
    [Table("DynamicParameter", Schema = "Dictionaries")]
    public class DynamicParameter : DictionaryEntityBase
    {
        [Required]
        public bool IsDefault { get; set; }

        public string DefaultValue { get; set; }

        [Required]
        public string Type { get; set; }
    }
}

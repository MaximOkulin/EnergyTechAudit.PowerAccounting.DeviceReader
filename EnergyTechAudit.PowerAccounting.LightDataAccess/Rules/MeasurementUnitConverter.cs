using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Rules
{
    [Table("MeasurementUnitConverter", Schema = "Rules")]
    public class MeasurementUnitConverter : IEntity
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public int MeasurementUnit1Id { get; set; }

        [Required]
        public int MeasurementUnit2Id { get; set; }

        [Required]
        public string Expression { get; set; }

       
        [ForeignKey("MeasurementUnit1Id")]
        public virtual MeasurementUnit MeasurementUnit1 { get; set; }

       
        [ForeignKey("MeasurementUnit2Id")]
        public virtual MeasurementUnit MeasurementUnit2 { get; set; }
    }
}

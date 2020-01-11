using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("MeasurementUnit", Schema = "Dictionaries")]
    public class MeasurementUnit : DictionaryEntityBase
    {
    }
}

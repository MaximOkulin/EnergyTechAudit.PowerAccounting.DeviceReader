using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("ScheduleType", Schema = "Dictionaries")]
    public class ScheduleType : DictionaryEntityBase
    {
    }
}

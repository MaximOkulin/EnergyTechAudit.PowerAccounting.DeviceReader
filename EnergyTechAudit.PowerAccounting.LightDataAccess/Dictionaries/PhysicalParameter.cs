using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("PhysicalParameter", Schema ="Dictionaries")]
    public class PhysicalParameter : DictionaryEntityBase
    {
    }
}
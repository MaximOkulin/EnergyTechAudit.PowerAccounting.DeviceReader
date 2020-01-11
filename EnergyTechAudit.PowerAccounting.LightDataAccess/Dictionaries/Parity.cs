using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("Parity", Schema ="Dictionaries")]
    public class Parity : DictionaryEntityBase
    {
    }
}

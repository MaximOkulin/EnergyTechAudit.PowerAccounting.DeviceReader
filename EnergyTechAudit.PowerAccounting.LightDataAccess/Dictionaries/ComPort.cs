using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("ComPort", Schema = "Dictionaries")]
    public class ComPort : DictionaryEntityBase
    {
    }
}

using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("PortType", Schema = "Dictionaries")]
    public class PortType : DictionaryEntityBase
    {
    }
}

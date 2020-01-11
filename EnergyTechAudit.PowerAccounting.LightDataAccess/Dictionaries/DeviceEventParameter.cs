using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("DeviceEventParameter", Schema = "Dictionaries")]
    public class DeviceEventParameter : DictionaryEntityBase
    {
    }
}

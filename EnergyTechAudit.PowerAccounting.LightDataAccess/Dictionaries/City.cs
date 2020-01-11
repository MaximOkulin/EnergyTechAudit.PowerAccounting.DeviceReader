using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("City", Schema = "Dictionaries")]
    public class City : DictionaryEntityBase
    {
        public string LatinCode { get; set; }
    }
}

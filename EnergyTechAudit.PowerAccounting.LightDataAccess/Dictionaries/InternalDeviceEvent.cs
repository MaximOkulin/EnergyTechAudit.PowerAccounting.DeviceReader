using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("InternalDeviceEvent", Schema = "Dictionaries")]
    public class InternalDeviceEvent : DictionaryEntityBase
    {
        [Required]
        public int DeviceId { get; set; }
    }
}

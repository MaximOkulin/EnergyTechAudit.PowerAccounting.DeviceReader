using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("DeviceParameter", Schema = "Dictionaries")]
    public class DeviceParameter : DictionaryEntityBase
    {
        public DeviceParameter()
        {
            DeviceTechnicalParameters = new List<DeviceTechnicalParameter>();
        }

        [InverseProperty("DeviceParameter")]
        public virtual DeviceParameterSetting DeviceParameterSetting { get; set; }

        public virtual ICollection<DeviceTechnicalParameter> DeviceTechnicalParameters { get; private set; }
    }
}

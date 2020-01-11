using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    public class TransportServerModel : DictionaryEntityBase
    {
        public TransportServerModel()
        {
            AccessPoints = new List<AccessPoint>();
        }

        [InverseProperty("TransportServerModel")]
        public virtual ICollection<AccessPoint> AccessPoints { get; private set; }
    }
}

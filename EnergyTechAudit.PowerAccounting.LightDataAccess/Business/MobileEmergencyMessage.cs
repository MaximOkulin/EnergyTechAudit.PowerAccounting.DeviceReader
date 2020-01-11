using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("MobileEmergencyMessage", Schema = "Business")]
    public class MobileEmergencyMessage : IEntity<long>
    {
        public MobileEmergencyMessage()
        {
            DeliveredTime = new DateTime(1900, 1, 1);
        }

        [Key]
        public long Id { get; set; }
        public DateTime Time { get; set; }

        public int MobileDeviceId { get; set; }
        public string Address { get; set; }
        public string EmergencyDescription { get; set; }
        public string EmergencyValue { get; set; }
        public int EmergencySituationParameterId { get; set; }

        public bool Delivered { get; set; }

        public DateTime DeliveredTime { get; set; }

        public int ChannelId { get; set; }
        public int MeasurementDeviceId { get; set; }


        [ForeignKey("MobileDeviceId")]
        public virtual MobileDevice MobileDevice { get; set; }
        [ForeignKey("EmergencySituationParameterId")]
        public virtual EmergencySituationParameter EmergencySituationParameter { get; set; }

        [ForeignKey("ChannelId")]
        public virtual Channel Channel { get; set; }
        [ForeignKey("MeasurementDeviceId")]
        public virtual MeasurementDevice MeasurementDevice { get; set; }
    }
}

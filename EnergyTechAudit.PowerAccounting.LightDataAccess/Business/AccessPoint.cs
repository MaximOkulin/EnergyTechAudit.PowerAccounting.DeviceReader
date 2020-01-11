using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    //
    [Table("AccessPoint", Schema ="Business")]
    public class AccessPoint: IEntity, ISuccessConnectionPercent
    {
        [Key]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Description { get; set; }

        public string NetAddress { get; set; }

        public int Port { get; set; }

        [MaxLength(11)]
        public string NetPhone { get; set; }

        public int TransportTypeId { get; set; }

        public int TransportServerModelId { get; set; }

        [ForeignKey("TransportServerModelId")]
        public virtual TransportServerModel TransportServerModel { get; set; }

        public int? DeviceReaderId { get; set; }

        public int? CsdModemId { get; set; }

        public bool IsNeedToReconfigure { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime LastConnectionTime { get; set; }

        [Required]
        public double SuccessConnectionPercent { get; set; }

        [Required]
        public int LastStatusConnectionId { get; set; }

        [InverseProperty("AccessPoint")]        
        public virtual ICollection<MeasurementDevice> MeasurementDevices { get; private set; }
    }
}

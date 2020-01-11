using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("MeasurementDevice", Schema ="Business")]
    public class MeasurementDevice: IEntity, ISuccessConnectionPercent
    {

        public MeasurementDevice()
        {
            RegulatorParameterValues = new List<RegulatorParameterValue>();
            DeviceTechnicalParameters = new List<DeviceTechnicalParameter>();
            MobileEmergencyMessages = new List<MobileEmergencyMessage>();
        }

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public long FactoryNumber { get; set; }

        public DateTime ManufacturingDate { get; set; }

        [Required]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }


        public string SubModel { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime LastConnectionTime { get; set; }

        [Required]
        public int AutoDefTimeoutAnswer { get; set; }

        [Required]
        public int AmountAttempt { get; set; }

        [Required]
        public int PollingInterval { get; set; }

        [Required]
        public int ProtocolSubTypeId { get; set; }

        [Required]
        public int ComPortId { get; set; }

        [Required]
        public int BaudId { get; set; }

        [Required]
        public int DataBitId { get; set; }

        [Required]
        public int StopBitId { get; set; }

        [Required]
        public int ParityId { get; set; }

        [Required]
        public double SuccessConnectionPercent { get; set; }

        [Required]
        public int NetworkAddress { get; set; }

        [Required]
        public bool TurnOn { get; set; }

        public DateTime? LastSuccessConnectionTime { get; set; }

        [ForeignKey("DataBitId")]
        public virtual DataBit DataBit { get; set; }

        [ForeignKey("ComPortId")]
        public virtual ComPort ComPort { get; set; }

        [ForeignKey("BaudId")]
        public virtual Baud Baud { get; set; }

        [ForeignKey("ParityId")]
        public virtual Parity Parity { get; set; }

        [ForeignKey("StopBitId")]
        public virtual StopBit StopBit { get; set; }

        [MaxLength(16)]
        public string Firmware { get; set; }

        [Required]
        public DateTime StartReadArchiveDate { get; set; }

        public int? HubId { get; set; }

        [Required]
        public bool GiveCurrData { get; set; }

        [Required]
        public bool GiveHArcData { get; set; }

        [Required]
        public bool GiveDArcData { get; set; }

        [Required]
        public bool GiveMArcData { get; set; }

        public int? LastTimeSignatureId { get; set; }

        [Required]
        public int LastStatusConnectionId { get; set; }        


        [InverseProperty("MeasurementDevice")]        
        public virtual ICollection<Channel> Channels { get; private set; }

        public int? AccessPointId { get; set; }

        [ForeignKey("AccessPointId")]
        public virtual AccessPoint AccessPoint { get; set; }

        [Required]
        public int PortTypeId { get; set; }

        [InverseProperty("MeasurementDevice")]        
        public virtual ICollection<RegulatorParameterValue> RegulatorParameterValues { get; private set; }

        [InverseProperty("MeasurementDevice")]
        public virtual ICollection<DeviceTechnicalParameter> DeviceTechnicalParameters { get; private set; }

        [InverseProperty("MeasurementDevice")]
        public virtual ICollection<MobileEmergencyMessage> MobileEmergencyMessages { get; private set; }

        public DateTime CurrentAccreditationDate { get; set; }

        public DateTime NextAccreditationDate { get; set; }
        public int Priority { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

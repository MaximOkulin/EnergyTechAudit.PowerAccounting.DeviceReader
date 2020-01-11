using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("DeviceReader", Schema = "Business")]
    public class DeviceReader : IEntity
    {
        [Key]        
        public int Id { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        [Required]
        public int DeviceReaderTypeId { get; set; }

        [Required]
        public string SignalRNetAddress { get; set; }

        [Required]
        public int SignalRPort { get; set; }

        public string SignalRHub { get; set; }

        [Required]
        public string ServerCommunicatorNetAddress { get; set; }

        [Required]
        public string ServerCommunicatorController { get; set; }

        
        public string ServerCommunicatorReceiveAction { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int QueuePollingInterval { get; set; }

        [Required]
        public int HoveringTaskRemoveTime { get; set; }

        [Required]
        public int UpdateConfigInterval { get; set; }

        [Required]
        public int MaxThreadCount { get; set; }

        [InverseProperty("DeviceReader")]
        public virtual ICollection<Hub> Hubs { get; private set; }
    }
}

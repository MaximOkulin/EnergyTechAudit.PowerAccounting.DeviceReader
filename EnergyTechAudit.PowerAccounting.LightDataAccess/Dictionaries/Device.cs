using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries
{
    [Table("Device", Schema ="Dictionaries")]
    public class Device : DictionaryEntityBase
    {
        [Required]
        public int ArchiveDepthHour { get; set; }
        [Required]
        public int ArchiveDepthDay { get; set; }
        [Required]
        public int ArchiveDepthMonth { get; set; }
        [Required]
        public bool HasDigitalInterface { get; set; }
        [Required]
        public int BaudId { get; set; }
        [Required]
        public int DataBitId { get; set; }
        [Required]
        public int StopBitId { get; set; }
        [Required]
        public int ParityId { get; set; }
        [Required]
        public bool IsIntegralArchiveValue { get; set; }

        [ForeignKey("BaudId")]
        public virtual Baud Baud { get; set; }

        [ForeignKey("DataBitId")]
        public virtual DataBit DataBit { get; set; }

        [ForeignKey("StopBitId")]
        public virtual StopBit StopBit { get; set; }

        [ForeignKey("ParityId")]
        public virtual Parity Parity { get; set; }
    }
}

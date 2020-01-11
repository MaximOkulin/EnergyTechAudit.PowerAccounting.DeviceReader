using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
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
    [Table("ParameterMapDeviceParameter", Schema = "Business")]
    public class ParameterMapDeviceParameter : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ParameterId { get; set; }

        [Required]
        public int ChannelTemplateId { get; set; }

        [ForeignKey("ParameterId")]
        public virtual Parameter Parameter { get; set; }

        [Required]
        public int DimensionId { get; set; }

        [ForeignKey("DimensionId")]
        public virtual Dimension Dimension { get; set; }

        [Required]
        public int MeasurementUnitId { get; set; }

        [ForeignKey("MeasurementUnitId")]
        public virtual MeasurementUnit MeasurementUnit { get; set; }

        [Required]
        public int PeriodTypeId { get; set; }

        [Required]
        public int DeviceParameterId { get; set; }

        public int? ParameterDictionaryId { get; set; }
    }
}

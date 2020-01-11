using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Business
{
    [Table("Placement", Schema = "Business")]
    public class Placement : IEntity
    {        
        [Key]        
        public int Id { get; set; }
        public int PlacementPurposeId { get; set; }
        public int BuildingId { get; set; }

        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces
{
    public class DictionaryEntityBase: IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(64)]
        public string Code { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}

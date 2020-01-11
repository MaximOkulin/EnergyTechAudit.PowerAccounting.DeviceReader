using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics
{
    public class Requirement
    {
        public string EntityTypeCode { get; set; }
        public List<FieldValues> FieldsValues { get; set; }
    }
}

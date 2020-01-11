using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics
{
    public class MultipleTitle
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public List<StringFormatPart> StringFormatParts { get; set; }
    }
}

namespace EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics
{
    public class ConditionPart
    {
        public string Check { get; set; }
        public string Expression { get; set; }
        public string ExpressionResultType { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string AlternativeTitle { get; set; }
        public string Type { get; set; }
        public string CustomFormatter { get; set; }
        public MultipleTitle MultipleTitle { get; set; }        
    }
}

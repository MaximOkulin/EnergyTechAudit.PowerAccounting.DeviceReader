namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types
{
    public class FinalInstantValuesForHour
    {
        public decimal TimeNormal { get; set; }
        public decimal Volume1 { get; set; }
        public decimal Volume2 { get; set; }
        public decimal Volume3 { get; set; }
        public decimal Mass1 { get; set; }
        public decimal Mass2 { get; set; }
        public decimal Mass3 { get; set; }
        public decimal Heat { get; set; }
    }
}

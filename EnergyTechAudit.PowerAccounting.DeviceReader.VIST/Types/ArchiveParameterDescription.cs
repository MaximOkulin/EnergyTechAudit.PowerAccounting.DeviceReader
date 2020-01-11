namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types
{
    public class ArchiveParameterDescription
    {
        public string Name { get; set; }
        public string ParseType { get; set; }
        public int Precision { get; set; }
        public bool IsExternalPrecision { get; set; }
        public string PrecisionName { get; set; }
        public ArchiveHeatSystemParams ArchiveHeatSystemParams { get; set; }
        public int Size { get; set; }
        public bool IsIncrease { get; set; }
        public short Order { get; set; }
    }
}

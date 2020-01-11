namespace EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem
{
    public class DataFormat
    {
        public string DataBit { get; set; }
        public string Parity { get; set; }
        public string StopBit { get; set; }
        public short FormatValue { get; set; }
    }
}

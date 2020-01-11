namespace EnergyTechAudit.PowerAccounting.DeviceReader.Modbus.Types
{
    public class SubReq
    {
        public byte ReferenceType { get; set; }
        public byte[] FileNumber { get; set; }
        public byte[] RecordNumber { get; set; }
        public byte[] RecordLength { get; set; }
    }
}

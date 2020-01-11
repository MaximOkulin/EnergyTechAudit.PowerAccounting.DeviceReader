namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips
{
    public class DeviceSnip
    {
        public int Id;
        public bool HasDigitalInterface;
        public int ArchiveDepthMonth;
        public int ArchiveDepthHour;
        public int ArchiveDepthDay;
        public string Code;
        public bool IsIntegralArchiveValue;
        public int BaudId;
        public int ParityId;
        public int DataBitId;
        public int StopBitId;
    }
}

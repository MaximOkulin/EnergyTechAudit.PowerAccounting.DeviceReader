namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips
{
    public class DeviceReaderSnip
    {
        public int Id;
        public string SignalRNetAddress;
        public int SignalRPort;

        public string SignalRUri
        {
            get { return string.Format("http://{0}:{1}", SignalRNetAddress, SignalRPort); }
        }
    }
}

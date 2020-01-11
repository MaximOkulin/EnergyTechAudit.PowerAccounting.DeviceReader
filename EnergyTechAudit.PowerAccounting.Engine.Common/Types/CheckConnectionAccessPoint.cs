namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class CheckConnectionAccessPoint
    {
        public StatusConnection StatusConnection { get; set; }

        public TelnetPortStatus TelnetPortStatus { get; set; }

        public string SignalQuality { get; set; }
    }
}

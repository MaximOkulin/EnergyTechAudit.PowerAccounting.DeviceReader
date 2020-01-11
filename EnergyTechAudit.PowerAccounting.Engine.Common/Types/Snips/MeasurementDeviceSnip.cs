using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Snips
{
    public class MeasurementDeviceSnip
    {
        public int Id;
        public int DeviceId;
        public int PollingInterval;
        public bool TurnOn;
        public string PlacementDescription;
        public int AccessPointId;
        public DateTime LastConnectionTime;
        public string Description;        
    }
}

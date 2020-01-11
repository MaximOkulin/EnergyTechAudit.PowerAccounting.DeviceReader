using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.EventArgs
{
    public class TraceEventArgs : System.EventArgs
    {
        public TraceCommand Command { get; set; }

        public string Text { get; set; }
        public int DeviceId { get; set; }
        public DateTime Time { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }
}

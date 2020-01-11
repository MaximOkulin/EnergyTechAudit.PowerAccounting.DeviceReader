using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types
{
    public class ArchiveAddress
    {
        public int Index { get; set; }
        public DateTime DateTime { get; set; }

        public ArchiveAddress(int index, DateTime dateTime)
        {
            Index = index;
            DateTime = dateTime;
        }
    }
}

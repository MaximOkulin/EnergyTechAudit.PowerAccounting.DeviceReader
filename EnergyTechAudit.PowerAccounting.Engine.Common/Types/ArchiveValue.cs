using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class ArchiveValue
    {
        public DateTime DateTime;
        public double Value;

        public ArchiveValue(DateTime dateTime, double value)
        {
            DateTime = dateTime;
            Value = value;
        }
    }
}

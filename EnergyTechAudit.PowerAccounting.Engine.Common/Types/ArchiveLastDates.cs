using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public struct ArchiveLastDates
    {
        public DateTime Hour;
        public DateTime Day;
        public DateTime Month;

        public DateTime LastHourArchiveScan;
        public DateTime LastDayArchiveScan;
        public DateTime LastMonthArchiveScan;
    }
}

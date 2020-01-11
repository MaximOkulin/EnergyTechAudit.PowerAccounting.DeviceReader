using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    /// <summary>
    /// Диапазон дат, в котором находятся архивы с нерассчитанными суммами
    /// </summary>
    public class NotCalculatedDates
    {
        public DateTime? Min { get; set; }
        public DateTime? Max { get; set; }
    }
}

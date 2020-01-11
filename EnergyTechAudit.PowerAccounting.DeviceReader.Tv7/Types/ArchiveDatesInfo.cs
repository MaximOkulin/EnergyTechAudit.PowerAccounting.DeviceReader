using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types
{
    /// <summary>
    /// Информация о датах начала/конца архивов
    /// </summary>
    public struct ArchiveDatesInfo
    {
        public DateTime HourStart;
        public DateTime DayStart;
        public DateTime MonthStart;
        public DateTime FinalStart;

        public DateTime HourEnd;
        public DateTime DayEnd;
        public DateTime MonthEnd;
        public DateTime FinalEnd;

        // время сброса архива
        public DateTime ResetTime;
    }
}

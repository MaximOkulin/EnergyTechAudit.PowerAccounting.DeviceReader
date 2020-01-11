namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    /// <summary>
    /// Структура хранения расчетных суток и часа
    /// </summary>
    public struct ReportingTime
    {
        public int Hour
        {
            get; set;
        }
        public int Day
        {
            get; set;
        }

        public ReportingTime(int hour, int day) : this()
        {
            this.Hour = hour;
            this.Day = day;
        }
    }
}

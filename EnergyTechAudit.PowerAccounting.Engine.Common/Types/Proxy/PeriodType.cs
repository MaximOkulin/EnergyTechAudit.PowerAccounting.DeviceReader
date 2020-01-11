namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy
{
    /// <summary>
    /// Периоды архивных значений (Dictionaries.PeriodType)
    /// </summary>
    public enum PeriodType
    {        
        Instant = 1,
        Hour = 2,
        Day = 3,
        Month = 4,
        FinalInstant = 5,
        Final = 6
    }
}

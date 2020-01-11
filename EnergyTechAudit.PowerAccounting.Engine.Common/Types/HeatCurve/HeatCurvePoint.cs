namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.HeatCurve
{
    /// <summary>
    /// Класс, представляющий точку температурного графика
    /// </summary>
    public class HeatCurvePoint
    {
        /// <summary>
        /// Температура наружного воздуха
        /// </summary>
        public int OutdoorTemperature { get; set; }
        /// <summary>
        /// Нормативная температура, соответствующая температуре наружного воздуха
        /// </summary>
        public decimal Temperature { get; set; }
    }
}

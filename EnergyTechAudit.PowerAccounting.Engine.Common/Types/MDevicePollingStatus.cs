using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    /// <summary>
    /// Класс-обертка, описывающая текущий статус опроса прибора
    /// </summary>
    public class MDevicePollingStatus
    {
        /// <summary>
        /// Объект прибора
        /// </summary>
        public MeasurementDevice Device { get; set; }
        /// <summary>
        /// Флаг, показывающий был ли уже опрошен прибор
        /// </summary>
        public bool IsPolled { get; set; }
    }
}

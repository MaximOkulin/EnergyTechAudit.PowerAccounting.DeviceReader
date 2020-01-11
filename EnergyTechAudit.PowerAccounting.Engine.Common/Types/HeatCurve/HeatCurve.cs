using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.HeatCurve
{
    /// <summary>
    /// Температурный график
    /// </summary>
    public class HeatCurve
    {
        /// <summary>
        /// Тип температурного графика
        /// </summary>
        public HeatCurveType HeatCurveType { get; set; }
        /// <summary>
        /// Идентификатор организации, к которой относится температурный график
        /// </summary>
        public int OrganizationId { get; set; }
        /// <summary>
        /// Коллекция точек графика
        /// </summary>
        public List<HeatCurvePoint> Points { get; set; }
    }
}

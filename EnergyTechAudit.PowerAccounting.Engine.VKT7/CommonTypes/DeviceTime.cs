using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes
{
    /// <summary>
    /// Класс, хранящий времена ВКТ-7
    /// </summary>
    internal sealed class DeviceTime
    {
        // текущее время устройства
        public DateTime Current;
        // дата начала часового архива
        public DateTime HourArchiveStart;
        // дата начала суточного архива
        public DateTime DailyArchiveStart;
    }
}

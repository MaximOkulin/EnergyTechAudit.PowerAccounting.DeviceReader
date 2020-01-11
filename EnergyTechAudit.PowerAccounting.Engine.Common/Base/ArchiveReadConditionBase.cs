using System;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base
{
    /// <summary>
    /// Класс, хранящий функции формирования дат и условий для чтения архивных данных
    /// </summary>
    public class ArchiveReadConditionBase
    {
        public Func<Archive, DateTime> StartDateCalculator;

        public Func<DateTime, DateTime> EndDateCalculator;

        public Func<TimeSpan, bool> Condition;

        public Func<DateTime, DateTime> NextArchiveDateIterator;
    }
}

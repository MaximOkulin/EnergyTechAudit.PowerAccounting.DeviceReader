using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Helpers
{
    public class ArchiveReadConditionHelper
    {
        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения часовых архивных данных
        /// </summary>
        /// <param name="archiveDatesInfo">Информация о датах начала/конца архивов</param>
        public static ArchiveReadConditionBase GetHourArchiveReadCondition(ArchiveDatesInfo archiveDatesInfo)
        {
            return new ArchiveReadConditionBase
            {
                StartDateCalculator = (archive) => 
                    {
                        if (archiveDatesInfo.HourStart == default(DateTime)) return default(DateTime);
                        var result = archive != null && archive.Time >= archiveDatesInfo.HourStart ? archive.Time : archiveDatesInfo.HourStart.AddHours(-1);
                        return result;
                    },
                EndDateCalculator = currentTime => archiveDatesInfo.HourEnd,
                Condition = ts => (ts.Hours < 0 || ts.Days < 0),
                NextArchiveDateIterator = currentDate => currentDate.AddHours(1)
            };
        }

        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения дневных архивных данных
        /// </summary>
        /// <param name="archiveDatesInfo">Информация о датах начала/конца архивов</param>
        public static ArchiveReadConditionBase GetDayArchiveReadCondition(ArchiveDatesInfo archiveDatesInfo)
        {
            return new ArchiveReadConditionBase
            {
                StartDateCalculator = (archive) =>
                    { 
                        if (archiveDatesInfo.DayStart == default(DateTime)) return default(DateTime);
                        var result = archive != null && archive.Time >= archiveDatesInfo.DayStart ? archive.Time : archiveDatesInfo.DayStart.AddDays(-1);
                        return result;
                    },
                EndDateCalculator = currentTime => archiveDatesInfo.DayEnd,
                Condition = ts => (ts.Days < 0),
                NextArchiveDateIterator = currentDate => currentDate.AddDays(1)
            };
        }

        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения итоговых архивных данных
        /// </summary>
        /// <param name="archiveDatesInfo">Информация о датах начала/конца архивов</param>
        public static ArchiveReadConditionBase GetFinalArchiveReadCondition(ArchiveDatesInfo archiveDatesInfo)
        {
            return new ArchiveReadConditionBase
            {
                StartDateCalculator = (archive) =>
                    { 
                        if (archiveDatesInfo.FinalStart == default(DateTime)) return default(DateTime);
                        var result = archive != null && archive.Time >= archiveDatesInfo.FinalStart ? archive.Time : archiveDatesInfo.FinalStart.AddDays(-1);
                        return result;
                    },
                EndDateCalculator = currentTime => archiveDatesInfo.FinalEnd,
                Condition = ts => (ts.Days < 0),
                NextArchiveDateIterator = currentDate => currentDate.AddDays(1)
            };
        }

        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения месячных архивных данных
        /// </summary>
        /// <param name="archiveDatesInfo">Информация о датах начала/конца архивов</param>
        public static ArchiveReadConditionBase GetMonthArchiveReadCondition(ArchiveDatesInfo archiveDatesInfo)
        {
            return new ArchiveReadConditionBase
            {
                StartDateCalculator = (archive) =>
                    {
                        if (archiveDatesInfo.MonthStart == default(DateTime)) return default(DateTime);
                        var result = archive != null ? archive.Time : archiveDatesInfo.MonthStart.AddMonths(-1);
                        return result;
                    },
                EndDateCalculator = currentTime => archiveDatesInfo.MonthEnd,
                Condition = ts => (ts.Days < 0),
                NextArchiveDateIterator = currentDate => currentDate.AddMonths(1)
            };
        }
    }
}

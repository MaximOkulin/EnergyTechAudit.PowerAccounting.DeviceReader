using System;
using System.Linq.Expressions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API
{
    /// <summary>
    /// Класс, хранящий функции формирования дат и условий для чтения архивных данных
    /// </summary>
    internal sealed class ArchiveReadCondition
    {
        public Func<Archive, DateTime> StartDateCalculator;

        public Func<DateTime, DateTime> EndDateCalculator;

        public Func<TimeSpan, bool> Condition;

        public Func<Parameter, bool> FilterCondition;

        public Func<DateTime, DateTime> NextArchiveDateIterator;

        public Expression<Func<Archive, bool>> GetExtraLastArchivePredicate;
    }

    internal sealed class ArchiveReadConditionHelper
    {
        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения часовых архивных данных
        /// </summary>
        /// <param name="hourArchiveStartDateTime">Дата начала часового архива в приборе</param>
        public static ArchiveReadCondition GetHourArchiveReadCondition(DateTime hourArchiveStartDateTime, DateTime deviceTime)
        {
            return new ArchiveReadCondition
            {
                StartDateCalculator = (archive) =>
                {
                    var startTime = archive != null ? archive.Time : hourArchiveStartDateTime.AddHours(-1);
                    if ((deviceTime - startTime).TotalHours > 1152)
                    {
                        startTime = deviceTime.AddHours(-1152);
                    }
                    return startTime;
                },
                EndDateCalculator = currentDeviceDateTime => currentDeviceDateTime.AddHours(-1),
                Condition = ts => (ts.Hours < 0 || ts.Days < 0),
                FilterCondition = p => p.BeHourly,
                NextArchiveDateIterator = currentDate => currentDate.AddHours(1),
                GetExtraLastArchivePredicate = (archive) => archive.DeviceParameterId == (int)DeviceParameter.VKT7_V1_1Type ||
                         archive.DeviceParameterId == (int)DeviceParameter.VKT7_V3_1Type ||
                         archive.DeviceParameterId == (int)DeviceParameter.VKT7_V1_2Type ||
                         archive.DeviceParameterId == (int)DeviceParameter.VKT7_V3_2Type ||
                         archive.DeviceParameterId == (int)DeviceParameter.VKT7_QntType_1HIP
            };
        }

        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения дневных архивных данных
        /// </summary>
        /// <param name="dayArchiveStartDateTime">Дата начала дневного архива в приборе</param>
        public static ArchiveReadCondition GetDayArchiveReadCondition(DateTime dayArchiveStartDateTime, DateTime deviceTime)
        {
            return new ArchiveReadCondition
            {
                StartDateCalculator = (archive) =>
                {
                    var startTime = archive != null ? archive.Time : new DateTime(dayArchiveStartDateTime.Year,
                                                                  dayArchiveStartDateTime.Month,
                                                                  dayArchiveStartDateTime.Day).AddDays(-1);
                    if ((deviceTime - startTime).TotalDays > 128)
                    {
                        startTime = deviceTime.AddDays(-128).Date;
                    }
                    return startTime;

                },
                EndDateCalculator = currentDeviceDateTime => new DateTime(currentDeviceDateTime.Year,
                                                                          currentDeviceDateTime.Month,
                                                                          currentDeviceDateTime.Day).AddDays(-1),
                Condition = ts => (ts.Days < 0),
                FilterCondition = p => p.BeDaily,
                NextArchiveDateIterator = currentDate => currentDate.AddDays(1),
                GetExtraLastArchivePredicate =  (archive) => archive.DeviceParameterId == (int) DeviceParameter.VKT7_V1_1Type ||
                         archive.DeviceParameterId == (int) DeviceParameter.VKT7_V3_1Type ||
                         archive.DeviceParameterId == (int) DeviceParameter.VKT7_V1_2Type ||
                         archive.DeviceParameterId == (int) DeviceParameter.VKT7_V3_2Type
            };
        }

        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения месячных архивных данных
        /// </summary>
        /// <param name="currentDateTime">Текущая дата</param>
        /// <param name="archiveDepthMonth">Глубина месячного архива</param>
        public static ArchiveReadCondition GetMonthArchiveReadCondition(DateTime currentDateTime, int archiveDepthMonth)
        {
            // по умолчанию дата начала архива = текущая дата - глубина архива по месяцам
            DateTime startDate = currentDateTime.AddMonths(-archiveDepthMonth);
            // по умолчанию дата конца архива - конец предыдущего месяца
            DateTime endDate = currentDateTime.AddMonths(-1);

            return new ArchiveReadCondition
            {
                StartDateCalculator = (archive) =>
                   archive != null ? archive.Time : new DateTime(startDate.Year,
                                                                 startDate.Month,
                                                                 DateTime.DaysInMonth(startDate.Year, startDate.Month)),
                EndDateCalculator = currentDeviceDateTime => new DateTime(endDate.Year,
                                                                          endDate.Month,
                                                                          DateTime.DaysInMonth(endDate.Year, endDate.Month)),
                Condition = ts => (ts.Days < 0),
                FilterCondition = p => p.BeMonthly,
                NextArchiveDateIterator = currentDate =>
                {
                    DateTime nextDate = currentDate.AddMonths(1);
                    return new DateTime(nextDate.Year, nextDate.Month, DateTime.DaysInMonth(nextDate.Year, nextDate.Month));
                },
                GetExtraLastArchivePredicate = (archive) => true
            };
        }

        /// <summary>
        /// Возвращает функции формирования дат и условия для чтения итоговых архивных данных
        /// </summary>
        /// <param name="currentDateTime">Текущая дата</param>
        /// <param name="archiveDepthMonth">Глубина месячного архива</param>
        /// <param name="reportingMonthDay">Отчётный день месяца</param>
        public static ArchiveReadCondition GetFinalArchiveReadCondition(DateTime currentDateTime, int archiveDepthMonth, int reportingMonthDay)
        {
            // по умолчанию дата начала архива = текущая дата - глубина архива по месяцам
            DateTime startDate = currentDateTime.AddMonths(-archiveDepthMonth);
            // по умолчанию дата конца архива - конец предыдущего месяца
            DateTime endDate = currentDateTime.AddMonths(-1);

            return new ArchiveReadCondition
            {
                StartDateCalculator = (archive) =>
                {
                    if (archive != null)
                    {
                        return archive.Time;
                    }
                    return CalculateFinalArchiveDate(startDate, reportingMonthDay);
                },
                EndDateCalculator = currentDeviceDateTime => CalculateFinalArchiveDate(endDate, reportingMonthDay),
                Condition = ts => (ts.Days < 0),
                FilterCondition = p => p.BeFinal,
                NextArchiveDateIterator = currentDate =>
                {
                    DateTime nextDate = currentDate.AddMonths(1);
                    return CalculateFinalArchiveDate(nextDate, reportingMonthDay);
                },
                GetExtraLastArchivePredicate = (archive) => true
            };
        }

        public static DateTime CalculateFinalArchiveDate(DateTime date, int reportingMonthDay)
        {
            if (reportingMonthDay == 31 || (reportingMonthDay == 30 && date.Month == 2) || (reportingMonthDay == 29 && date.Month == 2 && !DateTime.IsLeapYear(date.Year)))
            {
                if (date.Month == 2 && DateTime.IsLeapYear(date.Year))
                {
                    return new DateTime(date.Year, 2, 28);
                }
                return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            }
            return new DateTime(date.Year, date.Month, reportingMonthDay);
        }
    }
}

using System;
using System.Globalization;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public class DateTimeHelper
    {
        /// <summary>
        /// Возвращает дату первого дня недели года по номеру недели
        /// </summary>
        /// <param name="year">Год</param>
        /// <param name="weekOfYear">Номер недели</param>
        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            var jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            var firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        /// <summary>
        /// Возвращает дату вчерашнего дня с нулевыми часовой, минутной и секундной компонентами
        /// </summary>
        public static DateTime GetYesterday()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            return new DateTime(yesterday.Year, yesterday.Month, yesterday.Day);
        }

        /// <summary>
        /// Возвращает дату сегодняшнего дня с нулевыми часовой, минутной и секундной компонентами
        /// </summary>
        public static DateTime GetToday()
        {
            var today = DateTime.Now;
            return new DateTime(today.Year, today.Month, today.Day);
        }
    }
}

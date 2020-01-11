using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using System;
using System.Text;
using CommonResources = EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Common;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.CustomFormatters
{
    /// <summary>
    /// Форматирование для нештатной ситуации "Контроль качества связи с прибором"
    /// </summary>
    public class DeviceTimeDifferenceFormat : IFormatProvider, ICustomFormatter
    {
        private const int SecondsInYear = 31536000;
        private const int SecondsInMonth = 2592000;
        private const int SecondsInDay = 86400;
        private const int SecondsInHour = 3600;
        private const int SecondsInMinute = 60;

        public object GetFormat(Type service)
        {
            if (service == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
        
        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (format == null)
            {
                return String.Format(CommonResources.SimplePartStringFormat, arg);
            }

            if (!format.StartsWith(CommonResources.DeviceTimeDifferenceFormat))
            {
                if (arg is IFormattable)
                {
                    return ((IFormattable)arg).ToString(format, provider);
                }

                else if (arg != null)
                {
                    return arg.ToString();
                }
            }

            var result = string.Empty;

            var totalSeconds = Convert.ToInt32(arg);

            var stringPattern = totalSeconds > 0 ? CommonResources.DeviceTimeRunningOutStringFormat : totalSeconds == 0 ? CommonResources.DeviceTimeNormal : CommonResources.DeviceTimeLateStringFormat;

            if (totalSeconds != 0)
            {
                totalSeconds = Math.Abs(totalSeconds);

                StringBuilder sb = new StringBuilder();

                var fullYears = totalSeconds / SecondsInYear;
                if (fullYears > 0)
                {
                    sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullYears, GetDeclensionString(TimePart.Year, fullYears)));
                    totalSeconds = totalSeconds - fullYears * SecondsInYear;
                }

                var fullMonths = totalSeconds / SecondsInMonth;
                if (fullMonths > 0)
                {
                    sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullMonths, GetDeclensionString(TimePart.Month, fullMonths)));
                    totalSeconds = totalSeconds - fullMonths * SecondsInMonth;
                }

                var fullDays = totalSeconds / SecondsInDay;
                if (fullDays > 0)
                {
                    sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullDays, GetDeclensionString(TimePart.Day, fullDays)));
                    totalSeconds = totalSeconds - fullDays * SecondsInDay;
                }

                var fullHours = totalSeconds / SecondsInHour;
                if (fullHours > 0)
                {
                    sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullHours, GetDeclensionString(TimePart.Hour, fullHours)));
                    totalSeconds = totalSeconds - fullHours * SecondsInHour;
                }

                var fullMinutes = totalSeconds / SecondsInMinute;
                if (fullMinutes > 0)
                {
                    sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullMinutes, GetDeclensionString(TimePart.Minute, fullMinutes)));
                    totalSeconds = totalSeconds - fullMinutes * SecondsInMinute;
                }

                if (totalSeconds > 0)
                {
                    sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, totalSeconds, GetDeclensionString(TimePart.Second, totalSeconds)));
                }

                result = string.Format(stringPattern, sb.ToString());
            }
            else
            {
                result = stringPattern;
            }

            return result;
        }

        /// <summary>
        /// Возвращает литерал временной компоненты, приведенный к нужному склонению
        /// </summary>
        /// <param name="timePart">Временная компонента</param>
        /// <param name="value">Число временной компоненты</param>
        private string GetDeclensionString(TimePart timePart, int value)
        {
            string result = string.Empty;

            switch (timePart)
            {
                case TimePart.Second:
                    result = value == 1 ? Declension.SecondАccusative : IsValue2Between4(value) ? Declension.SecondGenitive : Declension.SecondsGenitive;
                    break;
                case TimePart.Minute:
                    result = value == 1 ? Declension.MinuteАccusative : IsValue2Between4(value) ? Declension.MinuteGenitive : Declension.MinutesGenitive;
                    break;
                case TimePart.Hour:
                    result = value == 1 ? Declension.HourАccusative : IsValue2Between4(value) ? Declension.HourGenitive : Declension.HoursGenitive;
                    break;
                case TimePart.Day:
                    result = value == 1 ? Declension.DayАccusative : IsValue2Between4(value) ? Declension.DayGenitive : Declension.DaysGenitive;
                    break;
                case TimePart.Month:
                    result = value == 1 ? Declension.MonthАccusative : IsValue2Between4(value) ? Declension.MonthGenitive : Declension.MonthsGenitive;
                    break;
                case TimePart.Year:
                    result = value == 1 ? Declension.YearАccusative : IsValue2Between4(value) ? Declension.YearGenitive : Declension.YearsGenitive;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Находится ли заданное число в диапазоне [2-4]
        /// </summary>
        private bool IsValue2Between4(int value)
        {
            return value >= 2 && value <= 4;
        }
    }
}

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
    public class TimeSpanFormat : IFormatProvider, ICustomFormatter
    {
        private const int MinutesInYear = 525600;
        private const int MinutesInMonth = 43200;
        private const int MinutesInDay = 1440;
        private const int MinutesInHour = 60;

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

            if (!format.StartsWith(CommonResources.TimeSpanFormat))
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

            var totalMinutes = Convert.ToInt32(arg);

            StringBuilder sb = new StringBuilder();

            var fullYears = totalMinutes / MinutesInYear;
            if (fullYears > 0)
            {
                sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullYears, GetDeclensionString(TimePart.Year, fullYears)));
                totalMinutes = totalMinutes - fullYears * MinutesInYear;
            }

            var fullMonths = totalMinutes / MinutesInMonth;
            if (fullMonths > 0)
            {
                sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullMonths, GetDeclensionString(TimePart.Month, fullMonths)));
                totalMinutes = totalMinutes - fullMonths * MinutesInMonth;
            }

            var fullDays = totalMinutes / MinutesInDay;
            if (fullDays > 0)
            {
                sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullDays, GetDeclensionString(TimePart.Day, fullDays)));
                totalMinutes = totalMinutes - fullDays * MinutesInDay;
            }

            var fullHours = totalMinutes / MinutesInHour;

            if (fullHours > 0)
            {
                sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, fullHours, GetDeclensionString(TimePart.Hour, fullHours)));
                totalMinutes = totalMinutes - fullHours * MinutesInHour;
            }

            if (totalMinutes > 0)
            {
                sb.Append(string.Format(CommonResources.TwoSimplePartsDivideBeforeWhiteSpaceStringFormat, totalMinutes, GetDeclensionString(TimePart.Minute, totalMinutes)));
            }

            return sb.ToString();
        }

        private string GetDeclensionString(TimePart timePart, int value)
        {
            string result = string.Empty;

            switch (timePart)
            {
                case TimePart.Minute:
                    result = value == 1 ? Declension.MinuteGenitive : Declension.MinutesGenitive;
                    break;
                case TimePart.Hour:
                    result = value == 1 ? Declension.HourGenitive : Declension.HoursGenitive;
                    break;
                case TimePart.Day:
                    result = value == 1 ? Declension.DayGenitive : Declension.DaysGenitive;
                    break;
                case TimePart.Month:
                    result = value == 1 ? Declension.MonthGenitive : Declension.MonthsGenitive;
                    break;
                case TimePart.Year:
                    result = value == 1 ? Declension.YearGenitive : Declension.YearsGenitive;
                    break;
            }

            return result;
        }
    }
}

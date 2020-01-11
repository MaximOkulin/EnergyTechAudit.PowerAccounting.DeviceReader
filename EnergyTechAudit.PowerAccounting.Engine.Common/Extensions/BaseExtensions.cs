using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using DeviceParameter = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.DeviceParameter;
using EventParameter = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.EventParameter;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions
{
    public static class BaseExtensions
    {
        /// <summary>
        /// Клонирование объектов типа IList
        /// </summary>
        /// <typeparam name="T">Тип данных в IList</typeparam>
        /// <param name="listToClone">Список, который следует клонировать</param>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// Удаляет пустые байты 0x00 из массива
        /// </summary>
        /// <param name="buffer">Массив байтов</param>
        public static byte[] RemoveEmptyBytes(this byte[] buffer)
        {
            return buffer.Where(b => b != 0x00).ToArray();
        }

        /// <summary>
        /// Получает текущую дату из представления времени в формате Unix
        /// </summary>
        /// <param name="seconds">Секунды, отсчитываемые от 1 января 1970 года</param>
        public static DateTime ConvertFromUnixTime(this int seconds)
        {
            return new DateTime(1970, 1, 1).AddSeconds(seconds);
        }

        /// <summary>
        /// Получает представление времени в формате Unix по текущей дате
        /// </summary>
        /// <param name="dt">Текущая дата</param>
        public static int ConvertToUnixTime(this DateTime dt)
        {
            return (Int32)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        /// <summary>
        /// Возвращает строковое представление даты в стандарте ISO
        /// (2015-10-24T15:14:34)
        /// </summary>
        /// <param name="dt">Дата</param>
        public static string ToIsoString(this DateTime dt)
        {
            return dt.ToString(@"yyyy-MM-ddTHH\:mm\:ss");
        }

        /// <summary>
        /// Преобразует дату в число секунд, прошедших с 01/01/0001 00:00:00
        /// </summary>
        /// <param name="dt">Дата</param>
        public static decimal TotalNewAgeSeconds(this DateTime dt)
        {
            // Ticks - количество 100-наносекунд прошедших с 1 января 1 года
            var now = dt.Ticks / 10000000;
            return Convert.ToDecimal(now);
        }

        /// <summary>
        /// Возвращает текущую дату из представления времени в формате Unix
        /// </summary>
        /// <param name="seconds">Секунды, отсчитываемые от 1 января 1970 года</param>
        public static DateTime ConvertFromUnixTime(this uint seconds)
        {
            return new DateTime(1970,1,1).AddSeconds(seconds);
        }

        /// <summary>
        /// Возвращает количество секунд, на которое приборное время отличается от текущего серверного
        /// </summary>
        /// <param name="deviceTime">Приборное время</param>
        public static int CalculateDeviceTimeDifference(this DateTime deviceTime)
        {
            return (int)(deviceTime - DateTime.Now).TotalSeconds;
        }

        /// <summary>
        /// Возвращает количество секунд, на которое приборное время ВКТ-7 отличается от текущего серверного
        /// (ВКТ-7 хранит время без минутной и секундной компонент)
        /// </summary>
        /// <param name="deviceTime">Приборное время</param>
        public static int CalculateVkt7DeviceTimeDifference(this DateTime deviceTime, DateTime now)
        {
            var nowMinutes = now.Minute; // текущая минутная компонента
            var withoutMinutesAndSeconds = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);

            var totalSeconds = (int)(deviceTime - withoutMinutesAndSeconds).TotalSeconds;

            var absTotalSeconds = Math.Abs(totalSeconds);
            // если разница оказалась 1 час (3600), но при этом текущее серверное время из-за задержек
            // в получении пакета от прибора успело перейти в следующий час в промежутке первых трёх минут,
            // либо еще было в предыдущем часе позже 57 минуты, то считаем, что время нормальное
            if (absTotalSeconds == 3600 && (nowMinutes >= 57 || nowMinutes <= 3)) return 0;

            return totalSeconds;
        }

        /// <summary>
        /// Проверяет является ли заданная дата сегодняшним днем
        /// без временной компоненты
        /// </summary>
        /// <param name="date">Дата для проверки</param>
        public static bool IsToday(this DateTime date)
        {
            var now = DateTime.Now;
            return now.Year == date.Year && now.Month == date.Month && now.Day == date.Day;
        }

        public static DeviceParameter GetDeviceParameterByName(string name)
        {
            return (DeviceParameter)Enum.Parse(typeof(DeviceParameter), name);
        }

        /// <summary>
        /// Возвращает динамический параметр по его имени
        /// </summary>
        /// <param name="name">Имя динамического параметра</param>
        public static DynamicParameter GetDynamicParameterByName(string name)
        {
            return (DynamicParameter)Enum.Parse(typeof(DynamicParameter), name);
        }

        /// <summary>
        /// Возвращает внутреннее событие прибора по его имени
        /// </summary>
        /// <param name="name">Имя внутреннего события прибора</param>
        /// <returns></returns>
        public static InternalDeviceEvent GetInternalDeviceEventByName(string name)
        {
            return (InternalDeviceEvent)Enum.Parse(typeof(InternalDeviceEvent), name);
        }

        /// <summary>
        /// Возвращает идентификатор внутреннего события прибора по его имени
        /// </summary>
        /// <param name="name">Имя внутреннего события прибора</param>
        /// <returns></returns>
        public static int GetInternalDeviceEventIdByName(string name)
        {
            return (int)GetInternalDeviceEventByName(name);
        }

        /// <summary>
        /// Возвращает идентификатор приборного параметра по его имени
        /// </summary>
        /// <param name="name">Имя параметра</param>
        public static int GetDeviceParameterIdByName(string name)
        {
            return (int) GetDeviceParameterByName(name);
        }

        public static EventParameter GetEventParameterByName(string name)
        {
            return (EventParameter) Enum.Parse(typeof (EventParameter), name);
        }

        /// <summary>
        /// Возвращает значение заданного перечисления по его строковому представлению
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <param name="value">Строкое представление значения</param>
        public static T GetEnumFromString<T>(string value) where T : struct, IConvertible
        {
            if(!typeof(T).IsEnum)
            {
                throw new ArgumentException(Resources.Common.TypeMustBeEnum);
            }
            return (T)Enum.Parse(typeof(T), value);
        }


        public static string ToActiveString(this bool source)
        {
            return source ? "активен" : "не активен";
        }

        /// <summary>
        /// Преобразует текстовое представление Hex-байтов в массив байтов
        /// (например, FD преобразует в 0xFD)
        /// </summary>
        /// <param name="source">Исходная строка, содержащая последовательность Hex-байтов</param>
        public static byte[] ToByteArray(this string source)
        {
            return Enumerable.Range(0, source.Length)
                 .Where(x => x % 2 == 0)
                 .Select(x => Convert.ToByte(source.Substring(x, 2), 16))
                 .ToArray();
        }

        public static void AddRange<T, S>(this Dictionary<T, S> source, Dictionary<T, S> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null");
            }

            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// Вычитает из даты заданный интервал времени в зависимости от типа периода
        /// </summary>
        /// <param name="dt">Дата</param>
        /// <param name="periodType">Тип периода</param>
        /// <param name="interval">Интервал</param>
        public static DateTime SubstractIntervalByPeriod(this DateTime dt, PeriodType periodType, int interval)
        {
            if(periodType == PeriodType.Hour)
            {
                return dt.AddHours(-1 * interval);
            }
            else if(periodType == PeriodType.Day)
            {
                return dt.AddDays(-1 * interval);
            }
            else if(periodType == PeriodType.Month)
            {
                return dt.AddMonths(-1 * interval);
            }
            return dt;
        }

        /// <summary>
        /// Является ли десятичное число целым (т.е. у него отсутствует дробная часть)
        /// </summary>
        /// <param name="d">Десятичное число</param>
        public static bool IsInteger(this decimal d)
        {
            return d % 1 == 0;
        }

        /// <summary>
        /// Возвращает ближайшее меньшее целое число
        /// </summary>
        /// <param name="d">Десятичное число</param>
        public static int GetNearestLowerInt(this decimal d)
        {
            if(d > 0)
            {
                return (int)d;
            }
            else if(d < 0)
            {
                return (int)(d - 1);
            }
            return -1;
        }

        /// <summary>
        /// Возвращает ближайшее большее целое число
        /// </summary>
        /// <param name="d">Десятичное число</param>
        public static int GetNearestUpperInt(this decimal d)
        {
            if(d > 0)
            {
                return (int)(d + 1);
            }
            else if(d < 0)
            {
                return (int)d;
            }
            return 1;
        }

        /// <summary>
        /// Показывает, есть ли в строке какие-либо символы, исключая пустой символ
        /// </summary>
        /// <param name="str">Строка</param>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Выполняет конвертацию вещественного числа в десятичное
        /// </summary>
        /// <param name="d">Исходное вещественное число двойной точности</param>
        public static DoubleToDecimalConvertResult ConvertToDecimal(this double d)
        {
            var result = new DoubleToDecimalConvertResult();

            if (d == Double.NaN)
            {
                result.Value = 0;
                result.IsValid = false;
                return result;
            }

            try
            {
                result.Value = (decimal)d;
                result.IsValid = true;
            }
            catch(OverflowException)
            {
                result.Value = 0;
                result.IsValid = false;
            }

            if (result.IsValid)
            {
                if (result.Value > Constants.MaxArchiveValue)
                {
                    result.Value = 0;
                    result.IsValid = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Выполняет конвертацию вещественного числа в десятичное
        /// </summary>
        /// <param name="d">Исходное вещественное число двойной точности</param>
        public static DoubleToDecimalConvertResult ConvertToDecimal(this float d)
        {
            var result = new DoubleToDecimalConvertResult();

            if (d == Double.NaN)
            {
                result.Value = 0;
                result.IsValid = false;
                return result;
            }

            try
            {
                result.Value = (decimal)d;
                result.IsValid = true;
            }
            catch (OverflowException)
            {
                result.Value = 0;
                result.IsValid = false;
            }

            if (result.IsValid)
            {
                if (result.Value > Constants.MaxArchiveValue)
                {
                    result.Value = 0;
                    result.IsValid = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Удаляет пробелы и заменяет запятые на точки в Ip-адресе
        /// </summary>
        /// <param name="netAddress">Ip-адрес</param>
        public static string SanitizeNetAddress(this string netAddress)
        {
            if (netAddress != null)
            {
                return netAddress.Replace(StringCharSet.WhiteSpace, string.Empty).Replace(StringCharSet.Comma, StringCharSet.Dot);
            }
            return null;
        }

        /// <summary>
        /// Возвращает NullTerminated-строку (байты располагаются в регистрах задом наперед)
        /// </summary>
        /// <param name="charArray"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static NullTerminatedString GetNullTerminatedString(this byte[] charArray, Encoding encoding)
        {
            bool isNullTerminated = false;
            var nullTerminatedString = new NullTerminatedString();

            for (int i = 1; i <= charArray.Length; i = i + 2)
            {
                if (charArray[i] != (Char.MinValue))
                {
                    nullTerminatedString.Value += encoding.GetString(new byte[] { charArray[i] });
                }
                else
                {
                    isNullTerminated = true;
                    break;
                }

                if (charArray[i - 1] != (Char.MinValue))
                {
                    nullTerminatedString.Value += encoding.GetString(new byte[] { charArray[i - 1] });
                }
                else
                {
                    isNullTerminated = true;
                    break;
                }
            }

            nullTerminatedString.IsNullTerminated = isNullTerminated;

            return nullTerminatedString;
        }

        /// <summary>
        /// Возвращает NullTerminated-строку (байты располагаются друг за другом)
        /// </summary>
        /// <param name="charArray"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static NullTerminatedString GetDirectNullTerminatedString(this byte[] charArray, Encoding encoding)
        {
            bool isNullTerminated = false;
            var nullTerminatedString = new NullTerminatedString();

            for (int i = 0; i <= charArray.Length - 1; i++)
            {
                if (charArray[i] != (Char.MinValue))
                {
                    nullTerminatedString.Value += encoding.GetString(new byte[] { charArray[i] });
                }
                else
                {
                    isNullTerminated = true;
                    break;
                }                
            }

            nullTerminatedString.IsNullTerminated = isNullTerminated;

            return nullTerminatedString;
        }

        public static string GetEnumDescription(Enum enumObj)
        {
            DescriptionAttribute attribute = (DescriptionAttribute)GetAttribute(enumObj, typeof(DescriptionAttribute));
            if (attribute != null)
            {
                return attribute.Description;
            }
            return enumObj.ToString();
        }

        public static object GetAttribute(Enum enumObj, Type attributeType)
        {
            if (!attributeType.IsSubclassOf(typeof(Attribute)))
            {
                throw new ArgumentException("Тип должен быть атрибутом.", "attributeType");
            }
            FieldInfo field = enumObj.GetType().GetField(enumObj.ToString());
            if (field != null)
            {
                object[] customAttributes = field.GetCustomAttributes(attributeType, false);
                if (customAttributes.Length != 0)
                {
                    return customAttributes[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Возвращает список установленных флагов в объекте перечисления
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <param name="enumValue">Объект перечисления</param>
        /// <returns></returns>
        public static IEnumerable<T> GetFlagValues<T>(this T enumValue) where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<Enum>().Where(e => ((Enum)(object)enumValue).HasFlag(e)).Cast<T>();
        }
    }
}

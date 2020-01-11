using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public static class StringHelper
    {
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNotNullOrEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Возвращает словарь "Параметр-Значение" из строки запроса
        /// </summary>
        /// <param name="query">Строка запроса</param>
        public static Dictionary<string, string> GetParamsFromQuery(string query)
        {
            var dict = new Dictionary<string, string>();
            var queryStringRegex = new Regex(@"[\?&](?<name>[^&=]+)=(?<value>[^&=]+)");
            var matches = queryStringRegex.Matches(query);

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                var name = match.Groups["name"].Value;
                var value = match.Groups["value"].Value;
                dict.Add(name, value);
            }
            return dict;
        }
    }
}

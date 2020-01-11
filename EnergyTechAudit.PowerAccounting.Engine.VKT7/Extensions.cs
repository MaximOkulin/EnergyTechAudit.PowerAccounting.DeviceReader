using System;
using System.Collections;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7
{
    internal static class Extensions
    {
        /// <summary>
        /// Возвращает индекс параметра ВКТ (из перечисления протокола)
        /// </summary>
        /// <param name="list">Список байтов, содержащий адрес параметра</param>
        public static int GetParamIndex(this List<byte> list)
        {
            var value = new BitArray(list.ToArray());
            // адрес 0x40000000 (в low-endian notation)
            var pattern = new BitArray(new byte[] { 0x00, 0x00, 0x00, 0x40 });
            var resultBitArray = value.Xor(pattern);
            var resultArray = new byte[resultBitArray.Count];
            resultBitArray.CopyTo(resultArray, 0);
            return BitConverter.ToInt32(resultArray, 0);
        }

        /// <summary>
        /// Возвращает дату используя структуру VT_DATA_RAP
        /// </summary>
        /// <param name="buffer">Пакет, содержащий дату</param>
        /// <param name="startIndex">Номер байта с которого начинается структура</param>
        public static DateTime GetDateTimeFromBytes(this byte[] buffer, int startIndex)
        {
            return new DateTime(buffer[startIndex + 2] + 2000, buffer[startIndex + 1], buffer[startIndex], buffer[startIndex + 3], 0, 0);
        }

        /// <summary>
        /// Возвращает дату и время с минутной и секундной компонентами
        /// </summary>
        /// <param name="buffer">Пакет, содержащий дату</param>
        public static DateTime GetTimeWithMinSecComponents(this byte[] buffer)
        {
            return new DateTime(buffer[3] + 2000, buffer[4], buffer[5], buffer[6], buffer[7], buffer[8]);
        }
    }
}

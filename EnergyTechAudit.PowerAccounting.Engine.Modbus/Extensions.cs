using System;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Modbus
{
    public static class Extensions
    {
        /// <summary>
        /// Удаляет из буфера первые три байта заголовка - сетевой адрес, команда, длина данных
        /// </summary>
        public static byte[] RemoveHeader(this byte[] buf)
        {
            var list = buf.ToList();
            list.RemoveRange(0, 3);
            return list.ToArray();
        }

        /// <summary>
        /// Удаляет секцию контрольной суммы и байт нуля в ASCIIZ-строке
        /// </summary>
        public static byte[] RemoveCrcAndNullTerminator(this byte[] buf)
        {
            var list = buf.ToList();
            int responseLength = buf[2];
            int startIndex = 2 + responseLength;
            list.RemoveRange(startIndex, list.Count - startIndex);
            return list.ToArray();
        }

        /// <summary>
        /// Удаляет байты CRC16 из пакета
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static byte[] RemoveCrc(this byte[] buf)
        {
            return buf.Take(buf.Length - 2).ToArray();
        }

        /// <summary>
        /// Удаляет байты перевод строки
        /// </summary>
        public static byte[] RemoveNewLineBytes(this byte[] buf)
        {
            var list = buf.ToList();
            list.RemoveAll(IsNewLinePredicate);
            return list.ToArray();
        }

        private static bool IsNewLinePredicate(byte b)
        {
            return b == 0x0A;
        }

        /// <summary>
        /// Определяет корректность контрольной суммы пакета Modbus в режиме RTU
        /// </summary>
        /// <param name="buf">Пакет Modbus</param>
        /// <param name="totalBytes">Количество байтов в пакете</param>
        /// <returns>true - корректно; false - некорректно</returns>
        public static bool VerifyModbusCheckSum(this byte[] buf, int totalBytes)
        {
            var infoBytes = buf.Take(totalBytes - 2).ToArray();
            var crc16 = infoBytes.Crc16();

            return crc16[0] == buf[totalBytes - 2] && crc16[1] == buf[totalBytes - 1]; 
        }

        /// <summary>
        /// Возвращает целое число, записанное в формате Big-Endian
        /// </summary>
        /// <param name="buf">Пакет Modbus</param>
        public static Int32 ParseBigEndianInt32(this byte[] buf)
        {
            return BitConverter.ToInt32(new[] {buf[6], buf[5], buf[4], buf[3]}, 0);
        }

        /// <summary>
        /// Возвращает целое число, записанное в формате Big-Endian
        /// </summary>
        /// <param name="buf">Пакет Modbus</param>
        public static Int16 ParseBigEndianInt16(this byte[] buf)
        {
            return BitConverter.ToInt16(new[] {buf[4], buf[3]}, 0);
        }

        /// <summary>
        /// Возвращает вещественное число, записанное в формате Big-Endian
        /// </summary>
        /// <param name="buf">Пакет Modbus</param>
        public static Single ParseBigEndianSingle(this byte[] buf)
        {
            return BitConverter.ToSingle(new[] { buf[6], buf[5], buf[4], buf[3] }, 0);
        }

        /// <summary>
        /// Возвращает массив байтов, представляющий целое число 32-битное число, 
        /// лежащее в двух смежных регистрах (по канонам Modbus)
        /// </summary>
        /// <param name="number">Целое</param>
        public static byte[] ToModbusBytesInt32(this Int32 number)
        {
            var sourceBytes = BitConverter.GetBytes(number);
            return new byte[] { sourceBytes[1], sourceBytes[0], sourceBytes[3], sourceBytes[2] };
        }

        /// <summary>
        /// Возвращает 32-разрядное целое, лежащее в двух смежных регистрах (по канонам Modbus)
        /// </summary>
        /// <param name="buf">Пакет Modbus</param>
        public static int ParseModbusInt(this byte[] buf)
        {
            return BitConverter.ToInt32(new[] { buf[4], buf[3], buf[6], buf[5] }, 0);
        }

        /// <summary>
        /// Возвращает байтовое представление UInt16 в формате Big-Endian
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static byte[] ToModbusBytesBigEndianUint16(this UInt16 number)
        {
            return BitConverter.GetBytes(number).Reverse().ToArray();
        }

        /// <summary>
        /// Возвращает тело пакета (содержимое секции полезных данных)
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static byte[] GetPackageBody(this byte[] buf)
        {
            var length = buf.Length;
            return buf.Take(length - 2).Reverse().Take(length - 5).Reverse().ToArray();
        }
    }
}

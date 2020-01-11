using System;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions
{
    public static class BcdExtensions
    {
        /// <summary>
        /// Возвращает целое число, записанное в формате BCD (binary-coded decimal)
        /// </summary>
        /// <param name="b">Байт, представляющий BCD</param>
        public static int ToIntFromBcd(this byte b)
        {
            // получаем количество десятков, путем смещения на 4 бита вправо
            int dec = (b >> 4) * 10;
            // получаем количество единиц, путем побитовой коньюнкции с маской 0x0F
            dec += b & ((1 << 4) - 1);
            return dec;
        }

        public static string ToIntFromBcdWithZero(this byte b)
        {
            var i = b.ToIntFromBcd();
            if (i < 10) return string.Format("0{0}", i);

            return Convert.ToString(i);
        }

        /// <summary>
        /// Возвращает байт BCD-представления целого двухзначного числа
        /// </summary>
        /// <param name="value">Целое двухзначное число</param>
        public static byte ToBcdByteFromInt(this int value)
        {
            int bcd = 0;
            for (int digit = 0; digit < 2; ++digit)
            {
                int nibble = value % 10;
                bcd |= nibble << (digit * 4);
                value /= 10;
            }
            return (byte)bcd;
        }

        /// <summary>
        /// Возвращает 4-х байтовый массив представления в формате BCD (binary-coded decimal)
        /// </summary>
        /// <param name="value">Целое число</param>
        public static byte[] To4BytesBcdFromInt(this int value)
        {
            var bcd = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                bcd[i] = (byte)(value % 10);
                value /= 10;
                bcd[i] |= (byte)((value % 10) << 4);
                value /= 10;
            }
            return bcd;
        }

        /// <summary>
        /// Возвращает 3-х байтовый массив представления в формате
        /// (например, 950622 = [0x95] [0x06] [0x22])
        /// </summary>
        /// <param name="value">Целое число</param>
        public static byte[] To3BcdBigEndianBytesFromInt(this int value)
        {
            var bcd = new byte[3];
            for (int i = 0; i < 3; i++)
            {
                bcd[i] = (byte)(value % 10);
                value /= 10;
                bcd[i] |= (byte)((value % 10) << 4);
                value /= 10;
            }
            return bcd.Reverse().ToArray();
        }

        /// <summary>
        /// Возвращает 6-ти байтовый массив представления в формате BCD (binary-coded decimal)
        /// </summary>
        /// <param name="value">Целое число</param>
        public static byte[] To6BytesBcdFromInt(this int value)
        {
            var bcd = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                bcd[i] = (byte)(value % 10);
                value /= 10;
            }
            return bcd.Reverse().ToArray();
        }


        /// <summary>
        /// Преобразует целое число в двухбайтный массив big-endian
        /// (например, 1200 = 0x04B0)
        /// </summary>
        /// <param name="number">Число</param>
        public static byte[] ToTwoBigEndianBytes(this int number)
        {
            byte[] result = BitConverter.GetBytes((Int16)number);
            Array.Reverse(result);
            return result;
        }

        /// <summary>
        /// Преобразует целое 16-разрядное число в двухбайтный массив big-endian
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static byte[] ToTwoBigEndianBytes(this short number)
        {
            byte[] result = BitConverter.GetBytes(number);
            Array.Reverse(result);
            return result;
        }

        /// <summary>
        /// Преобразует целое числов в четырехбайтный массив big-endian
        /// (например, 345548 = 0x000545CC)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static byte[] ToFourBigEndianBytes(this int number)
        {
            return  BitConverter.GetBytes(number).Reverse().ToArray();
        }

        /// <summary>
        /// Преобразует в десятичное число 4-байтный массив BCD-чисел
        /// </summary>
        /// <param name="bytes">Массив BCD-чисел</param>
        /// <param name="d">Знаков в дробной части</param>
        public static decimal ToDecimalFrom4Bcd(this byte[] bytes, int d = 0)
        {
            if(bytes.Length < 4)
            {
                throw new Exception(Resources.Exceptions.ToDecimalFrom4BcdWrongArrayLength);
            }

            decimal result = bytes[0].ToIntFromBcd() * 1000000 +
                             bytes[1].ToIntFromBcd() * 10000 +
                             bytes[2].ToIntFromBcd() * 100 + bytes[3].ToIntFromBcd();

            if(d > 0)
            {
                result = result / 10 * d;
            }

            return result;
        }
    }
}

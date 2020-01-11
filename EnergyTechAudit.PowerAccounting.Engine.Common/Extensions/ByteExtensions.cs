using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions
{
    /// <summary>
    /// Расширения, связанные с манипуляцией байтами
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Устанавливает бит четности в старший бит каждого байта массива
        /// (общее количество единиц каждого байта - четное)
        /// </summary>
        /// <param name="source">Исходный массив</param>
        public static byte[] SetParity(this byte[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = SetByteParity(source[i]);
            }
            return source;
        }

        /// <summary>
        /// Сбрасывает бит четности каждого байта массива
        /// </summary>
        /// <param name="source">Исходный массив</param>
        public static byte[] RemoveParity(this byte[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = RemoveByteParity(source[i]);
            }
            return source;
        }

        /// <summary>
        /// Устанавливает бит четности в каждый байт массива согласно типу четности (Even или Odd)
        /// </summary>
        /// <param name="source">Исходный массив байтов</param>
        /// <param name="parity">Тип четности (Even или Odd)</param>
        /// <returns></returns>
        public static byte[] SetParity(this byte[] source, Parity parity)
        {
            var parityBuf = new List<byte>();

            foreach(var b in source)
            {
                parityBuf.Add(SetParity(b, parity));
            }

            return parityBuf.ToArray();
        }

        /// <summary>
        /// Устанавливает бит четности в байт согласно типу четности (Even или Odd)
        /// </summary>
        /// <param name="b">Байт</param>
        /// <param name="parity">Тип четности (Even или Odd)</param>
        /// <returns></returns>
        private static byte SetParity(byte b, Parity parity)
        {
            // подсчитываем количество единиц в байте
            int count = Convert.ToString(b, 2).ToCharArray().Count(c => c == '1');

            var highDischargeSetted = b & 0x80;

            // если старший бит = 0, а также единиц нечетное количество, то догоняем в старший разряд 1
            if (highDischargeSetted == 0 && count % 2 != 0 && parity == Parity.Even)
            {
                b = (byte)(b | 0x80);
            }
            // если старший бит = 1, а также единиц четное количество, то догоняем в старший разряд 1
            else if (highDischargeSetted == 0 && count % 2 == 0 && parity == Parity.Odd)
            {
                b = (byte)(b | 0x80);
            }

            return b;
        }

        /// <summary>
        /// Сбрасывает бит четности, находящийся в старшем бите
        /// </summary>
        /// <param name="sourceByte">Исходный байт</param>
        public static byte RemoveByteParity(byte sourceByte)
        {
            var source = new[] {sourceByte};
            BitArray bits = new BitArray(source);
            bits[7] = false;
            bits.CopyTo(source, 0);

            return source[0];
        }

        /// <summary>
        /// Устанавливает бит четности в старший бит
        /// (общее количество единиц - четное)
        /// </summary>
        /// <param name="sourceByte">Исходный байт</param>
        private static byte SetByteParity(byte sourceByte)
        {
            var source = new[] {sourceByte};
            BitArray bits = new BitArray(source);

            int count = 0;

            for (var i = 0; i <= 7; i++)
            {
                if (bits[i]) count++;
            }

            bits[7] = count%2 == 1;

            bits.CopyTo(source, 0);

            return source[0];
        }

        /// <summary>
        /// Устанавливает старший бит байта в единицу
        /// </summary>
        /// <param name="sourceByte">Исходный байт</param>
        public static byte SetHighBit(this byte sourceByte)
        {
            var source = new[] { sourceByte };
            BitArray bits = new BitArray(source);

            bits[7] = true;
            bits.CopyTo(source, 0);

            return source[0];
        }

        /// <summary>
        /// Преобразует 16-ричное представление байтов в ASCII-формат
        /// (например, { 0xAB, 0x01, 0x45 } будет распилен на последовательность { 0x0A, 0x0B, 0x00, 0x01, 0x04, 0x05 })
        /// </summary>
        /// <param name="buffer">Входной поток байтов</param>
        public static byte[] HexToAscii(this byte[] buffer)
        {
            var separatedBytes = new List<byte>();
            foreach (var buf in buffer)
            {
                separatedBytes.Add((byte)((byte)(buf & 0xF0) >> 4));
                separatedBytes.Add((byte)(buf & 0x0F));
            }

            var asciiSymbols = new[]
            {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "A", "B", "C", "D", "E", "F"
            };

            var asciiSeparatedBytes = separatedBytes.Select(separatedByte => asciiSymbols[separatedByte]).ToList();

            var asciiPackage = new List<byte>();

            foreach (var asciiSeparatedByte in asciiSeparatedBytes)
            {
                asciiPackage.AddRange(Encoding.ASCII.GetBytes(asciiSeparatedByte));
            }

            return asciiPackage.ToArray();
        }

        /// <summary>
        /// Преобразует ASCII-представление байтов в 16-ричный формат
        /// (например, { 0x0A, 0x0C, 0x04, 0x07 } будет объединен в последовательность { 0xAC, 0x47 })
        /// </summary>
        /// <param name="buffer">Входной поток байтов</param>
        public static byte[] AsciiToHex(this byte[] buffer)
        {
            var asciiSeparatedBytes = buffer.Select(b => Encoding.ASCII.GetString(new[] { b }, 0, 1)).ToList();

            var result = new List<byte>();

            for (int index = 0; index < asciiSeparatedBytes.Count; index++)
            {
                byte decValueLeft = (byte)(int.Parse(asciiSeparatedBytes[index], System.Globalization.NumberStyles.HexNumber));
                byte decValueRight = (byte)(int.Parse(asciiSeparatedBytes[index + 1], System.Globalization.NumberStyles.HexNumber));
                byte local = 0x00;
                local = (byte)(local | (decValueLeft << 4));
                local = (byte)(local | decValueRight);
                result.Add(local);
                index++;
            }

            return result.ToArray();
        }

        /// <summary>
        /// Преобразует строковое представление hex-массива в массив байтов
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(this string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}

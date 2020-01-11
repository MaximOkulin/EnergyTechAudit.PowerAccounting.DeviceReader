using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions
{
    public static class CrcExtensions
    {
        /// <summary>
        /// Рассчитывает контрольную сумму буфера по алгоритму CRC16
        /// </summary>
        /// <param name="buffer">Буфер</param>
        public static byte[] Crc16(this byte[] buffer)
        {
            UInt16 crc = 0xFFFF;

            foreach (var b in buffer)
            {
                crc ^= (UInt16)b;

                for (var i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return BitConverter.GetBytes(crc);
        }

        private static readonly byte[] crc8Table = 
        {
            0x00, 0x5E, 0xBC, 0xE2, 0x61, 0x3F, 0xDD, 0x83,
            0xC2, 0x9C, 0x7E, 0x20, 0xA3, 0xFD, 0x1F, 0x41,
            0x9D, 0xC3, 0x21, 0x7F, 0xFC, 0xA2, 0x40, 0x1E,
            0x5F, 0x01, 0xE3, 0xBD, 0x3E, 0x60, 0x82, 0xDC,
            0x23, 0x7D, 0x9F, 0xC1, 0x42, 0x1C, 0xFE, 0xA0,
            0xE1, 0xBF, 0x5D, 0x03, 0x80, 0xDE, 0x3C, 0x62,
            0xBE, 0xE0, 0x02, 0x5C, 0xDF, 0x81, 0x63, 0x3D,
            0x7C, 0x22, 0xC0, 0x9E, 0x1D, 0x43, 0xA1, 0xFF,
            0x46, 0x18, 0xFA, 0xA4, 0x27, 0x79, 0x9B, 0xC5,
            0x84, 0xDA, 0x38, 0x66, 0xE5, 0xBB, 0x59, 0x07,
            0xDB, 0x85, 0x67, 0x39, 0xBA, 0xE4, 0x06, 0x58,
            0x19, 0x47, 0xA5, 0xFB, 0x78, 0x26, 0xC4, 0x9A,
            0x65, 0x3B, 0xD9, 0x87, 0x04, 0x5A, 0xB8, 0xE6,
            0xA7, 0xF9, 0x1B, 0x45, 0xC6, 0x98, 0x7A, 0x24,
            0xF8, 0xA6, 0x44, 0x1A, 0x99, 0xC7, 0x25, 0x7B,
            0x3A, 0x64, 0x86, 0xD8, 0x5B, 0x05, 0xE7, 0xB9,
            0x8C, 0xD2, 0x30, 0x6E, 0xED, 0xB3, 0x51, 0x0F,
            0x4E, 0x10, 0xF2, 0xAC, 0x2F, 0x71, 0x93, 0xCD,
            0x11, 0x4F, 0xAD, 0xF3, 0x70, 0x2E, 0xCC, 0x92,
            0xD3, 0x8D, 0x6F, 0x31, 0xB2, 0xEC, 0x0E, 0x50,
            0xAF, 0xF1, 0x13, 0x4D, 0xCE, 0x90, 0x72, 0x2C,
            0x6D, 0x33, 0xD1, 0x8F, 0x0C, 0x52, 0xB0, 0xEE,
            0x32, 0x6C, 0x8E, 0xD0, 0x53, 0x0D, 0xEF, 0xB1,
            0xF0, 0xAE, 0x4C, 0x12, 0x91, 0xCF, 0x2D, 0x73,
            0xCA, 0x94, 0x76, 0x28, 0xAB, 0xF5, 0x17, 0x49,
            0x08, 0x56, 0xB4, 0xEA, 0x69, 0x37, 0xD5, 0x8B,
            0x57, 0x09, 0xEB, 0xB5, 0x36, 0x68, 0x8A, 0xD4,
            0x95, 0xCB, 0x29, 0x77, 0xF4, 0xAA, 0x48, 0x16,
            0xE9, 0xB7, 0x55, 0x0B, 0x88, 0xD6, 0x34, 0x6A,
            0x2B, 0x75, 0x97, 0xC9, 0x4A, 0x14, 0xF6, 0xA8,
            0x74, 0x2A, 0xC8, 0x96, 0x15, 0x4B, 0xA9, 0xF7,
            0xB6, 0xE8, 0x0A, 0x54, 0xD7, 0x89, 0x6B, 0x35
        };

        /// <summary>
        /// Рассчитывает контрольную сумму буфера по алгоритму CRC8
        /// </summary>
        /// <param name="buffer">Буфер</param>
        public static byte Crc8(this byte[] buffer)
        {
            return buffer.Aggregate<byte, byte>(0, (current, t) => crc8Table[current ^ t]);
        }

        /// <summary>
        /// Рассчитывает контрольную сумму буфера по алгоритму CRC8
        /// </summary>
        /// <param name="buffer">Буфер</param>
        /// <param name="polynom">Полином</param>
        public static byte Crc8(this byte[] buffer, byte polynom)
        {
            byte[] table = new byte[256];

            // заполнение таблицы
            for (int i = 0; i < 256; ++i)
            {
                int temp = i;
                for (int j = 0; j < 8; ++j)
                {
                    if ((temp & 0x80) != 0)
                    {
                        temp = (temp << 1) ^ polynom;
                    }
                    else
                    {
                        temp <<= 1;
                    }
                }
                table[i] = (byte)temp;
            }

            byte crc = 0;
            if (buffer != null && buffer.Length > 0)
            {
                crc = buffer.Aggregate(crc, (current, b) => table[current ^ b]);
            }

            return crc;
        }

        /// <summary>
        /// Рассчитывает контрольную сумму буфера по алгоритму LRC (Longitudinal Redundancy Checking)
        /// </summary>
        /// <param name="buffer">Буфер</param>
        public static byte Lrc(this byte[] buffer)
        {
            int LRC = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                LRC -= buffer[i];
            }
            return (byte)LRC;
        }

        /// <summary>
        /// Рассчитывает контрольную сумму буфера, применяя маску 0xFF
        /// </summary>
        /// <param name="buffer">Буфер</param>
        public static byte MaskCrc(this byte[] buffer)
        {
            int crc = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                crc += buffer[i];
            }

            return BitConverter.GetBytes(crc)[0];
        }

        /// <summary>
        /// Выполняет операцию XOR последовательно с каждым байтом буфера
        /// </summary>
        /// <param name="buffer">Буфер</param>
        public static byte Xor(this byte[] buffer)
        {
            byte result = 0x00;

            foreach (var b in buffer)
            {
                result ^= b;
            }

            return result;
        }

        /// <summary>
        /// Выполняет суммирование всех байтов массива и к результату применяет операцию NOT
        /// </summary>
        /// <param name="buffer">Буфер</param>
        /// <returns>Возвращает младший байт результата</returns>
        public static byte SumAndNot(this byte[] buffer)
        {
            int result = 0;

            for(var i = 0; i < buffer.Length; i++)
            {
                result += buffer[i];
            }

            return (byte)~result;
        }

        /// <summary>
        /// Определяет корректность контрольной суммы пакета Modbus в режиме RTU
        /// </summary>
        /// <param name="buf">Пакет Modbus</param>
        /// <param name="totalBytes">Количество байтов в пакете</param>
        /// <returns>true - корректно; false - некорректно</returns>
        public static bool VerifyModbusCrc16CheckSum(this byte[] buf, int totalBytes)
        {
            var infoBytes = buf.Take(totalBytes - 2).ToArray();
            var crc16 = infoBytes.Crc16();

            return crc16[0] == buf[totalBytes - 2] && crc16[1] == buf[totalBytes - 1];
        }

        /// <summary>
        /// Выполняет суммирование всех байтов массива
        /// </summary>
        /// <param name="buffer">Буфер</param>
        /// <returns>Возвращает младший байт результата</returns>
        public static byte SumCrc(this byte[] buffer)
        {
            int result = 0;

            for (var i = 0; i < buffer.Length; i++)
            {
                result += buffer[i];
            }

            return (byte)result;
        }
    }
}

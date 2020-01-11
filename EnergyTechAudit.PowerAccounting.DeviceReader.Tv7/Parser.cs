using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    internal sealed class Parser
    {
        public Parser()
        {
            
        }
        /// <summary>
        /// Возвращает заводской номер прибора
        /// </summary>
        public int GetFactoryNumber(byte[] buf)
        {
            return BitConverter.ToInt32(new byte[] { buf[14], buf[13], buf[16], buf[15] }, 0);
        }

        /// <summary>
        /// Возвращает программную версию ПО устройства
        /// </summary>
        public Firmware GetFirmware(byte[] buffer)
        {
            return new Firmware(BitConverter.ToInt16(new byte[] { buffer[5], 0x00 }, 0),
                                        BitConverter.ToInt16(new byte[] { buffer[6], 0x00 }, 0));
        }

        /// <summary>
        /// Возвращает модель исполнения
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public Tuple<string, SubModel> GetSubmodel(byte[] buffer)
        {
            byte subModelByte = buffer[12];
            ushort hardwareVersion = BitConverter.ToUInt16(new byte[] { buffer[8], buffer[7] }, 0);
            string addSymbol = hardwareVersion >= 0x0500 ? Resources.Common.M : string.Empty;
            string result = string.Empty;
            SubModel subModel = SubModel.None;

            switch(subModelByte)
            {
                case 0x00:
                    result = Tv7Resources.OneModel;
                    subModel = SubModel.Model01;
                    break;
                case 0x02:
                    result = Tv7Resources.ThreeModel;
                    subModel = SubModel.Model03;
                    break;
                case 0x03:
                    result = Tv7Resources.FourModel;
                    subModel = SubModel.Model04;
                    break;
                case 0x04:
                    result = Tv7Resources.FourPointOneModel;
                    subModel = SubModel.Model041;
                    break;
                case 0x05:
                    result = Tv7Resources.FiveModel;
                    subModel = SubModel.Model05;
                    break;
            }
            return new Tuple<string, SubModel>(string.Format(StringFormat.TwoParts, result, addSymbol), subModel);
        }

        /// <summary>
        /// Определяет содержит ли модель прибора символ "М"
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public bool IsM(byte[] buffer)
        {
            ushort hardwareVersion = BitConverter.ToUInt16(new byte[] { buffer[8], buffer[7] }, 0);
            return hardwareVersion >= 0x0500;
        }


        /// <summary>
        /// Возвращает текущее время прибора
        /// </summary>
        public DateTime GetDeviceTime(byte[] buffer)
        {
            var day = BitConverter.ToInt16(new byte[] { buffer[4], 0x00 }, 0);
            var month = BitConverter.ToInt16(new byte[] { buffer[3], 0x00 }, 0);
            var year = BitConverter.ToInt16(new byte[] { buffer[6], 0x00 }, 0) + 2000;
            var hour = BitConverter.ToInt16(new byte[] { buffer[5], 0x00 }, 0);
            var minute = BitConverter.ToInt16(new byte[] { buffer[8], 0x00 }, 0);
            var second = BitConverter.ToInt16(new byte[] { buffer[7], 0x00 }, 0);

            return new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Возвращает заполненную структуру отчетного времени
        /// </summary>
        public ReportingTime GetReportingTime(byte[] buffer)
        {
            var hour = BitConverter.ToInt16(new byte[] { buffer[4], 0x00 }, 0);
            var day = BitConverter.ToInt16(new byte[] {buffer[3], 0x00 }, 0);

            return new ReportingTime {Day = day, Hour = hour};
        }

        /// <summary>
        /// Возвращает заполненную структуру дат начала/конца архивов
        /// </summary>
        public ArchiveDatesInfo GetArchiveDatesInfo(byte[] buf)
        {
            return new ArchiveDatesInfo
            {
                HourStart = GetDateArchiveFromBuffer(buf, 0),
                DayStart = GetDateArchiveFromBuffer(buf, 1),
                MonthStart = GetDateArchiveFromBuffer(buf, 2),
                FinalStart = GetDateArchiveFromBuffer(buf, 3),
                HourEnd = GetDateArchiveFromBuffer(buf, 4),
                DayEnd = GetDateArchiveFromBuffer(buf, 5),
                MonthEnd = GetDateArchiveFromBuffer(buf, 6),
                FinalEnd = GetDateArchiveFromBuffer(buf, 7),
                ResetTime = GetDateArchiveFromBuffer(buf, 8)
            };
        }

        /// <summary>
        /// Возвращает дату из буфера ответа на команду запроса "Информация о датах начала/конца архивов"
        /// </summary>
        /// <param name="buf">Буфер</param>
        /// <param name="dateOffset">Смещение даты относительно начала буфера</param>
        public DateTime GetDateArchiveFromBuffer(byte[] buf, int dateOffset)
        {
            // когда дата в приборе неинициализирована, то приходят 0xFF-FF...
            DateTime result = default(DateTime);
            try
            {
                var monthStart = BitConverter.ToInt16(new byte[] { buf[3 + 6 * dateOffset], 0x00 }, 0);
                var dayStart = BitConverter.ToInt16(new byte[] { buf[4 + 6 * dateOffset], 0x00 }, 0);
                var hourStart = BitConverter.ToInt16(new byte[] { buf[5 + 6 * dateOffset], 0x00 }, 0);
                var yearStart = BitConverter.ToInt16(new byte[] { buf[6 + 6 * dateOffset], 0x00 }, 0) + 2000;
                var secondStart = BitConverter.ToInt16(new byte[] { buf[7 + 6 * dateOffset], 0x00 }, 0);
                var minuteStart = BitConverter.ToInt16(new byte[] { buf[8 + 6 * dateOffset], 0x00 }, 0);
                result = new DateTime(yearStart, monthStart, dayStart, hourStart, minuteStart, secondStart);
            }
            catch
            {
                result = default(DateTime);
            }

            return result;
        }

        /// <summary>
        /// Возвращает дату архива
        /// </summary>
        public DateTime GetArchiveDate(byte[] buf)
        {
            var month = BitConverter.ToInt16(new byte[] {buf[3], 0x00}, 0);
            var day = BitConverter.ToInt16(new byte[] {buf[4], 0x00}, 0);
            var hour = BitConverter.ToInt16(new byte[] {buf[5], 0x00}, 0);
            var year = 2000 + BitConverter.ToInt16(new byte[] {buf[6], 0x00}, 0);

            return new DateTime(year, month, day, hour, 0, 0);
        }

        /// <summary>
        /// Возвращает дату архива при ускоренном чтении
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public DateTime GetSpeedArchiveDate(byte[] buf)
        {
            var month = BitConverter.ToInt16(new byte[] { buf[6], 0x00 }, 0);
            var day = BitConverter.ToInt16(new byte[] { buf[7], 0x00 }, 0);
            var hour = BitConverter.ToInt16(new byte[] { buf[8], 0x00 }, 0);
            var year = 2000 + BitConverter.ToInt16(new byte[] { buf[9], 0x00 }, 0);

            return new DateTime(year, month, day, hour, 0, 0);
        }

        
    }
}

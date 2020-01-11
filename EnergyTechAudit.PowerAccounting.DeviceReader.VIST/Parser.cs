using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types.Precisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST
{
    public class Parser
    {
        /// <summary>
        /// Возвращает заводской номер прибора из ASCIIZ-строки
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static int ParseFactoryNumber(byte[] buf)
        {
            var packageBody = buf.GetPackageBody();
            // отщепляем последний байт, т.к. длина 21 байт
            var asciizBytes = packageBody.Take(packageBody.Length - 1).ToArray();

            var nullTerminatedString = asciizBytes.GetDirectNullTerminatedString(Encoding.GetEncoding(1251));

            int factoryNumber = 0;
            if (nullTerminatedString.IsNullTerminated)
            {
                if (!string.IsNullOrEmpty(nullTerminatedString.Value))
                {
                    int.TryParse(nullTerminatedString.Value, out factoryNumber);
                }
            }
            else
            {
                throw new Exception(VistResources.DoNotDetermineFactoryNumber);
            }

            if (factoryNumber == 0)
            {
                throw new Exception(VistResources.CannotDetectFactoryNumber);
            }

            return factoryNumber;
        }

        /// <summary>
        /// Возвращает версию программного обеспечения прибора из ASCIIZ-строки
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static string ParseFirmware(byte[] buf)
        {
            var packageBody = buf.GetPackageBody();
            // отщепляем последний байт, т.к. длина 21 байт
            var asciizBytes = packageBody.Take(packageBody.Length - 1).ToArray();

            var nullTerminatedString = asciizBytes.GetDirectNullTerminatedString(Encoding.GetEncoding(1251));

            string firmware = string.Empty;

            if (nullTerminatedString.IsNullTerminated)
            {
                firmware = nullTerminatedString.Value;
            }

            return firmware;
        }

        
        /// <summary>
        /// Возвращает отчетное время 
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static ReportingTime ParseReportingTime(byte[] buf)
        {
            var day = BitConverter.ToInt16(new byte[] { buf[5], buf[4] }, 0);
            var hour = BitConverter.ToInt16(new byte[] { buf[7], buf[6] }, 0);

            return new ReportingTime(hour, day);
        }

        /// <summary>
        /// Возвращает текущие дату и время прибора
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static DateTime ParseDeviceTime(byte[] buf)
        {
            var hours = buf[3];
            var minutes = buf[4];
            var seconds = buf[5];
            var day = buf[6];
            var month = buf[7];
            var year = 2000 + buf[8];

            return new DateTime(year, month, day, hours, minutes, seconds);
        }

        /// <summary>
        /// Возвращает набор архивируемых параметров
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="systemNumber">Номер системы</param>
        /// <returns></returns>
        public static ArchiveHeatSystemParams ParseArchiveHeaderSystem(byte[] buf, int systemNumber)
        {
            int offset = systemNumber == 2 ? 1 : 0;

            return (ArchiveHeatSystemParams)BitConverter.ToUInt32(new byte[] { buf[8 + offset], buf[7 + offset], buf[6 + offset], buf[5 + offset] }, 0);
        }

        /// <summary>
        /// Возвращает набор архивируемых параметров из структуры заголовка архивного файла теплосистемы
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static ArchiveHeatSystemParams ParseArchiveHeatSystemParams(byte[] buf)
        {
            return (ArchiveHeatSystemParams)BitConverter.ToUInt32(new byte[] { buf[14], buf[13], buf[12], buf[11] }, 0);
        }



        /// <summary>
        /// Возвращает набор измеряемых текущих параметров теплосистемы
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static InstantParamsSet ParseInstantParamsSet(byte[] buf)
        {
            return (InstantParamsSet)BitConverter.ToUInt32(new byte[] { buf[6], buf[5], buf[4], buf[3] }, 0);
        }

        /// <summary>
        /// Возвращает набор накапливаемых текущих параметров теплосистемы
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static FinalInstantParamsSet ParseFinalInstantParamsSet(byte[] buf)
        {
            return (FinalInstantParamsSet)BitConverter.ToUInt32(new byte[] { buf[6], buf[5], buf[4], buf[3] }, 0);
        }

        /// <summary>
        /// Возвращает точность по расходу и тепловой мощности
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static InstantParamsPrecisions ParseInstantParamsPrecisions(byte[] buf)
        {
            var precisions = new InstantParamsPrecisions();
            precisions.Channel1 = BitConverter.ToUInt16(new byte[] { buf[4], buf[3] }, 0);
            precisions.Channel2 = BitConverter.ToUInt16(new byte[] { buf[6], buf[5] }, 0);
            precisions.Channel3 = BitConverter.ToUInt16(new byte[] { buf[8], buf[7] }, 0);
            precisions.ThermalPower = BitConverter.ToUInt16(new byte[] { buf[10], buf[9] }, 0);
            return precisions;
        }

        /// <summary>
        /// Возвращает точность по объему и тепловой энергии
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static FinalInstantParamsPrecisions ParseFinalInstantParamsPrecisions(byte[] buf)
        {
            var precisions = new FinalInstantParamsPrecisions();
            precisions.Channel1 = BitConverter.ToUInt16(new byte[] { buf[4], buf[3] }, 0);
            precisions.Channel2 = BitConverter.ToUInt16(new byte[] { buf[6], buf[5] }, 0);
            precisions.Channel3 = BitConverter.ToUInt16(new byte[] { buf[8], buf[7] }, 0);
            precisions.Heat = BitConverter.ToUInt16(new byte[] { buf[10], buf[9] }, 0);
            return precisions;
        }

        /// <summary>
        /// Возвращает точность по объему и тепловой энергии для целой части текущих итоговых
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static FinalInstantParamsPrecisions ParseFinalInstantWholePartParamsPrecisions(byte[] buf)
        {
            var precisions = new FinalInstantParamsPrecisions();
            precisions.Channel1 = buf[63];
            precisions.Channel2 = buf[64];
            precisions.Channel3 = buf[65];
            precisions.Heat = buf[66];

            return precisions;
        }

        /// <summary>
        /// Возвращает мгновенную температуру
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="position">Позиция температуры в пакете</param>
        /// <returns></returns>
        public static decimal ParseInstantTemperature(byte[] buf, int position)
        {
            int offset = 2 * (position - 1);
            return (decimal)BitConverter.ToInt16(new byte[] { buf[4 + offset], buf[3 + offset] }, 0) / 100;
        }

        /// <summary>
        /// Возвращает мгновенный расход
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="position">Позиция расхода в пакете</param>
        /// <param name="precision">Точность</param>
        /// <param name="additionalDenominator">Дополнительный знаменатель</param>
        /// <returns></returns>
        public static decimal ParseInstantFlows(byte[] buf, int position, int precision, int additionalDenominator = 1)
        {
            int offset = 4 * (position - 1);
            return Math.Round((decimal)(BitConverter.ToInt32(new byte[] { buf[6 + offset], buf[5 + offset], buf[4 + offset], buf[3 + offset] }, 0) / Math.Pow(10, precision)) / additionalDenominator, 2);
        }

        /// <summary>
        /// Возвращает мгновенное давление
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="position">Позиция давления в пакете</param>
        /// <returns></returns>
        public static decimal ParseInstantPressure(byte[] buf, int position)
        {
            int offset = 2 * (position - 1);
            return (decimal)BitConverter.ToUInt16(new byte[] { buf[4 + offset], buf[3 + offset] }, 0) / 10;
        }

        /// <summary>
        /// Возвращает время наработки за текущий час
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static decimal ParseTimeNormalForHour(byte[] buf)
        {
            return (decimal)BitConverter.ToUInt16(new byte[] { buf[4], buf[3] }, 0) / 100 / 36;
        }

        /// <summary>
        /// Возвращает основную часть объема или массы текущих итоговых их заголовка архивов
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="startIndex"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static decimal ParseWholePartVolumeAndMass(byte[] buf, int startIndex, int precision)
        {
            return (decimal)(BitConverter.ToInt32(new byte[] { buf[startIndex + 3], buf[startIndex + 2], buf[startIndex + 1], buf[startIndex] }, 0) / Math.Pow(10, precision));
        }
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Parsers
{
    internal sealed class ParserBase : EclParser
    {
        public ParserBase(ITransport iTransport, MeasurementDevice mDevice)
            : base(iTransport, mDevice)
        {

        }

        /// <summary>
        /// Возвращает текущее время прибора
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static DateTime ParseDeviceTime(byte[] buf)
        {
            var hour = BitConverter.ToInt16(new byte[] { buf[4], buf[3] }, 0);
            var minute = BitConverter.ToInt16(new byte[] { buf[6], buf[5] }, 0);
            var day = BitConverter.ToInt16(new byte[] { buf[8], buf[7] }, 0);
            var month = BitConverter.ToInt16(new byte[] { buf[10], buf[9] }, 0);
            var year = 2000 + BitConverter.ToInt16(new byte[] { buf[12], buf[11] }, 0);

            return new DateTime(year, month, day, hour, minute, 0);
        }

        /// <summary>
        /// Возвращает значение сенсора по его номеру
        /// </summary>
        /// <param name="sensorNumber"></param>
        /// <returns></returns>
        public double GetSensorValue(int sensorNumber)
        {
            int value = BitConverter.ToInt16(new[] { Buffer[4 + 2 * (sensorNumber - 1)], Buffer[3 + 2 * (sensorNumber - 1)] }, 0);
            return (double)value / 10;
        }

        public void ParsePnu11010_11014()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11010, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11011, BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11012, BitConverter.ToInt16(new byte[] { Buffer[8], Buffer[7] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11013, BitConverter.ToInt16(new byte[] { Buffer[10], Buffer[9] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11014, BitConverter.ToInt16(new byte[] { Buffer[12], Buffer[11] }, 0));
        }

        public void ParsePnu11019_11023()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11019, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11020, BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11021, BitConverter.ToInt16(new byte[] { Buffer[8], Buffer[7] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11022, BitConverter.ToInt16(new byte[] { Buffer[10], Buffer[9] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11023, BitConverter.ToInt16(new byte[] { Buffer[12], Buffer[11] }, 0));
        }

        public void ParsePnu11021_11022()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11021, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11022, BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0));
        }

        public void ParsePnu11034_11036()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11034, (double)BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11035, (double)BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0) / 10);
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11036, BitConverter.ToInt16(new byte[] { Buffer[8], Buffer[7] }, 0));
        }

        public void ParsePnu11029()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11029, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));            
        }

        public void ParsePnu11051()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11051, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePnu11084()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11084, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePnu11140()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11140, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePnu11161()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11161, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePnu11076_11077()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11076, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11077, BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0));
        }

        public void ParsePnu11092()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11092, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePnu11173_11180()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11173, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11174, (double)BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0) / 10);
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11175, BitConverter.ToInt16(new byte[] { Buffer[8], Buffer[7] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11176, BitConverter.ToInt16(new byte[] { Buffer[10], Buffer[9] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11177, BitConverter.ToInt16(new byte[] { Buffer[12], Buffer[11] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11178, BitConverter.ToInt16(new byte[] { Buffer[14], Buffer[13] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11179, BitConverter.ToInt16(new byte[] { Buffer[16], Buffer[15] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11180, BitConverter.ToInt16(new byte[] { Buffer[18], Buffer[17] }, 0));
        }

        public void ParsePnu11176_11177()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11176, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11177, BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0));
        }

        public void ParsePnu11181_11186()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11181, (double)BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11182, (double)BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0) / 10);
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11183, BitConverter.ToInt16(new byte[] { Buffer[8], Buffer[7] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11184, BitConverter.ToInt16(new byte[] { Buffer[10], Buffer[9] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11185, BitConverter.ToInt16(new byte[] { Buffer[12], Buffer[11] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11186, BitConverter.ToInt16(new byte[] { Buffer[14], Buffer[13] }, 0));
        }

        public void ParsePnu11183_11186()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11183, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11184, BitConverter.ToInt16(new byte[] { Buffer[6], Buffer[5] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11185, BitConverter.ToInt16(new byte[] { Buffer[8], Buffer[7] }, 0));
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11186, BitConverter.ToInt16(new byte[] { Buffer[10], Buffer[9] }, 0));
        }

        public void ParsePnu11188()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL110_Pnu_11188, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }
    }
}

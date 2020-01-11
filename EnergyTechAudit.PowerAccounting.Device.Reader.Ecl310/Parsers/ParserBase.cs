using System;
using System.Text;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Parsers
{
    internal sealed class ParserBase : EclParser
    {
        public ParserBase(ITransport iTransport, MeasurementDevice mDevice)
            : base(iTransport, mDevice)
        {
           
        }

        private bool CheckErrors()
        {
            bool result = true;
            
            if (Transport.CurrentErrorCode != ErrorCode.None)
            {
                result = false;
                if (Transport.CurrentErrorCode == ErrorCode.WrongNetworkAddress)
                {
                    Transport.LogHelper.CreateLog(DeviceMessages.WrongNetAddress, ErrorType.ErrorDeviceResponse);
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает префикс приложения
        /// </summary>
        public string ParseApplicationPrefix()
        {
            return Encoding.ASCII.GetString(new[] {Buffer[4]});
        }

        /// <summary>
        /// Возвращает тип приложения
        /// </summary>
        public string ParseApplicationType()
        {
            int value = BitConverter.ToInt16(new[] {Buffer[4], Buffer[3]}, 0);
            return Convert.ToString(value);
        }

        /// <summary>
        /// Возвращает подтип приложения
        /// </summary>
        public string ParseApplicationSubType()
        {
            int value = BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0);
            return Convert.ToString(value);
        }

        /// <summary>
        /// Возвращает дату производства регулятора
        /// </summary>
        public DateTime ParseManufacturingDate()
        {
            int year = 2000 + Buffer[3];
            int weekOfYear = Buffer[4];
            return DateTimeHelper.FirstDateOfWeek(year, weekOfYear);
        }

        /// <summary>
        /// Возвращает заводской номер контроллера
        /// </summary>
        public int ParseFactoryNumber()
        {
            return BitConverter.ToInt16(new[] {Buffer[4], Buffer[3]}, 0);
        }

        /// <summary>
        /// Возвращает номер аппаратной версии контроллера
        /// </summary>
        public string ParseHardwareVersion()
        {
            return string.Format("{0}.{1}", Encoding.ASCII.GetString(new[] {Buffer[3]}), Buffer[4]);
        }

        /// <summary>
        /// Возвращает версию программного обеспечения контроллера
        /// </summary>
        public string ParseFirmware()
        {
            return string.Format("{0}.{1}{2}", Buffer[3], Buffer[4] < 10 ? "0" : string.Empty, Buffer[4]);
        }

        /// <summary>
        /// Возвращает текущее реальное время регулятора Danfoss ECL Comfort 210/310
        /// </summary>
        public static DateTime ParseDeviceTime(byte[] buffer)
        {
            int hour = BitConverter.ToInt16(new[] { buffer[4], buffer[3] }, 0);
            int minute = BitConverter.ToInt16(new[] { buffer[6], buffer[5] }, 0);
            int day = BitConverter.ToInt16(new[] { buffer[8], buffer[7] }, 0);
            int month = BitConverter.ToInt16(new[] { buffer[10], buffer[9] }, 0);
            int year = BitConverter.ToInt16(new[] { buffer[12], buffer[11] }, 0);

            return new DateTime(year, month, day, hour, minute, 0);
        }

        /// <summary>
        /// Возвращает значение сенсора по его номеру
        /// </summary>
        /// <param name="sensorNumber">Номер датчика</param>
        public  double GetSensorValue(int sensorNumber, int scale = 100)
        {
            int value = BitConverter.ToInt16(new[] {Buffer[4 + 2*(sensorNumber - 1)], Buffer[3 +  2*(sensorNumber - 1)]}, 0);
            return (double) value / scale;
        }

        /// <summary>
        /// Получает значения параметров контура 1 (чтение из 11 регистров)
        /// </summary>
        public void ParseHeatSystemParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11178, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11179, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11180, (double)BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11181, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11182, (double)BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11183, (double)BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11184, BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11185, BitConverter.ToInt16(new[] { Buffer[20], Buffer[19] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11186, BitConverter.ToInt16(new[] { Buffer[22], Buffer[21] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11187, BitConverter.ToInt16(new[] { Buffer[24], Buffer[23] }, 0));
            }
        }

        /// <summary>
        /// Получает значения параметров контура 1 (чтение из одного регистра)
        /// </summary>
        public void ParseHeatSystemParameters1Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значения параметров контура 1 (чтение из двух регистров)
        /// </summary>
        public void ParseHeatSystemParameters2Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11178, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
            }
        }       

        /// <summary>
        /// Получает значения параметров контура 1 (чтение из трех регистров)
        /// </summary>
        public void ParseHeatSystemParameters3Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11178, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11179, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
            }
        }


        /// <summary>
        /// Получает значения параметров контура 1 (чтение из восьми регистров)
        /// </summary>
        public void ParseHeatSystemParameters8Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11180, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11181, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11182, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11183, (double)BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11184, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11185, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11186, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11187, BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0));
            }
        }

        /// <summary>
        /// Получает значения желаемыех температур контура 1 (дневная/ночная)
        /// </summary>
        public void ParseDesiredTemperaturesCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11180, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11181, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значения параметров контура 2
        /// </summary>
        public void Parse2CircuitParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12178, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12179, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12180, (double)BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12181, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12182, (double)BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12183, (double)BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12184, BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12185, BitConverter.ToInt16(new[] { Buffer[20], Buffer[19] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12186, BitConverter.ToInt16(new[] { Buffer[22], Buffer[21] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12187, BitConverter.ToInt16(new[] { Buffer[24], Buffer[23] }, 0));
            }
        }

        /// <summary>
        /// Получает значения температур системы отопления
        /// </summary>
        public void ParseHeatSystemTemperatures()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11178, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11179, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11180, (double)BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11181, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значение максимального выходного напряжения
        /// </summary>
        public void ParseMaxOutputVoltage()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12165, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение минимального выходного напряжения
        /// </summary>
        public void ParseMinOutputVoltage()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12167, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значения температур второго контура
        /// </summary>
        public void ParseHwsTemperatures()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12178, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12179, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12180, (double)BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12181, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значения коэффициентов системы отопления
        /// </summary>
        public void ParseHeatSystemKoefficients()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11184, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11185, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11186, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11187, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает значения ограничений температуры подачи системы отопления
        /// </summary>
        public void ParseHeatSystemSupplyTemperatureLimits()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11300, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11301, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11302, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11303, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает значение фильтра S4
        /// </summary>
        public void ParseS4Filter()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_10304, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает адрес ECA
        /// </summary>
        public void ParseEcaAddressId()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11010, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает адрес ECA, контур 2
        /// </summary>
        public void ParseEcaAddressCircuit2Id()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12010, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает смещение
        /// </summary>
        public void ParseOffset()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11017, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг тренировки клапана, контур 1
        /// </summary>
        public void ParseFlapTrainingCurcuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11023, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг тренировки клапана, контур 2
        /// </summary>
        public void ParseFlapTrainingCurcuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12023, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг приоритета ГВС, контур 1
        /// </summary>
        public void ParseHwsPriorityCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11052, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг приоритета ГВС, контур 2
        /// </summary>
        public void ParseHwsPriorityCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12052, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг полного отключения, контур 1
        /// </summary>
        public void ParseBlackout()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11021, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг полного отключения, контур 2
        /// </summary>
        public void ParseBlackoutCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12021, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает время перехода между режимами
        /// </summary>
        public void ParseTransitionModeTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11082, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает температуру защиты от замерзания
        /// </summary>
        public void ParseFrostProtectionTemperature2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11093, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг выбора компенсационной температуры
        /// </summary>
        public void ParseSelectionCompensationTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11140, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11141, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11142, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает параметры внешнего входа, контур 1
        /// </summary>
        public void ParseExternalInputParams()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11141, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11142, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает параметры внешнего входа, контур 2
        /// </summary>
        public void ParseExternalInputParamsCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12141, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12142, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает флаг посылки заданной температуры
        /// </summary>
        public void ParseSendPredeterminedTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11500, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает аварийную температуру замерзания S6
        /// </summary>
        public void ParseAccidentS6FreezingTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11676, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает аварийную температуру замерзания S5
        /// </summary>
        public void ParseAccidentS5FreezingTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11656, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры термостата замерзания
        /// </summary>
        public void ParseFrostThermostatParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11616, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11617, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры термостата пожаробезопасности
        /// </summary>
        public void ParseFireSafetyThermostatParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11636, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11637, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
            }
        }
        
        /// <summary>
        /// Получает параметры температурного монитора, контур 1
        /// </summary>
        public void ParseTemperatureMonitorParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11147, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11148, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11149, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11150, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры температурного монитора, контур 2
        /// </summary>
        public void ParseTemperatureMonitorParametersCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12147, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12148, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12149, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12150, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }
        
        /// <summary>
        /// Получает нижнее значение максимальной границы контура 1 Y1
        /// </summary>
        public void ParseMinHsBorderFlowTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11303, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает верхнее значение максимальной границы контура 1 Y2
        /// </summary>
        public void ParseMaxHsBorderFlowTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11301, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры компенсации
        /// </summary>
        public void ParseCompensationParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11060, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11061, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11062, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11063, (double)BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11064, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11065, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11066, (double)BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11067, (double)BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает время защиты двигателя
        /// </summary>
        public void ParseMotorProtection()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11174, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает время защиты двигателя регулятора 2
        /// </summary>
        public void ParseMotorProtection2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12174, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значения ограничений температуры подачи ГВС
        /// </summary>
        public void ParseHwsSupplyTemperatureLimits()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12300, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12301, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12302, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12303, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }


        /// <summary>
        /// Получает значения желаемых температур горячей воды
        /// </summary>
        public void ParseDesiredHotWaterTemperatures()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12190, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12191, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значения параметров системы отопления для обратного трубопровода контура 1 и пр.
        /// </summary>
        public void ParseHeatSystemReverseParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11031, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11032, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11033, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11034, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11035, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11036, (double)BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11037, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0));
            }
        }

        /// <summary>
        /// Получает значения параметров системы отопления для обратного трубопровода контура 1 и пр.
        /// (3 регистра)
        /// </summary>
        public void ParseHeatSystemReverseParameters3Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11035, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11036, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11037, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
            }
        }

        /// <summary>
        /// Получает предельную температуру замерзания
        /// </summary>
        public void ParseLimitFreezeTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11108, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает мин. влияние предельной безопасной температуры
        /// </summary>
        public void ParseMinLimitFreezeTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11105, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает время оптимизаци предельной безопасной температуры
        /// </summary>
        public void ParseLimitFreezeOptimizationTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11107, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение коэффициента максимального влияния ветра
        /// </summary>
        public void ParseHeatSystemMaxWindInfluence()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11057, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значение фильтра ветра
        /// </summary>
        public void ParseHeatSystemWindFilter()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11081, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение ограничения ветра
        /// </summary>
        public void ParseHeatSystemWindLimit()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11099, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значения параметров системы отопления для обратного трубопровода контура 2 и пр.
        /// </summary>
        public  void ParseHwsReverseParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12031, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12032, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12033, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12034, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12035, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12036, (double)BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12037, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0));
            }
        }

        /// <summary>
        /// Получает значение минимального времени активации электропривода системы отопления
        /// </summary>
        public void ParseHeatSystemDriveActivationTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11189, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значения точек температурного графика
        /// </summary>
        public void ParseHeatCurve()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11400, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11401, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11402, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11403, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11404, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11405, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0));
            }
        }

        /// <summary>
        /// Получает значения точек температурного графика контура 2
        /// </summary>
        public void ParseHeatCurve2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12400, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12401, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12402, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12403, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12404, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12405, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0));
            }
        }

        /// <summary>
        /// Получает значение используется ли внешний сигнал в контуре 1
        /// </summary>
        public void ParseHsExternalSignal()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11084, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение реверса
        /// </summary>
        public void ParseReverse()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12171, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значения настроек управления вентилятором
        /// </summary>
        public void ParseFanParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11086, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11087, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11088, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11089, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11090, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11091, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0));
            }
        }

        /// <summary>
        /// Получает коэффициент разницы заданных комнатных температур
        /// </summary>
        public void ParseRoomTemperaturesDiff()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11027, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает температуру защиты от замерзания
        /// </summary>
        public void ParseFrostProtectionTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11077, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает функцию вентилятора
        /// </summary>
        public void ParseFanFunction()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11137, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает предельную температуру обратки ГВС
        /// </summary>
        public void ParseHwsLimitReverseTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12030, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значения мин/макс влияния обратки ГВС
        /// </summary>
        public void ParseHwsMinMaxInfluenceReverse()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12035, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12036, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12037, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
            }
        }

        /// <summary>
        /// Получает коэффициент мертвой зоны
        /// </summary>
        public void ParseDeadBand()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11009, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает коэффициенты ограничения комнатной температуры
        /// </summary>
        public void ParseInfluenceRoomParams()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11182, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11183, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает скорость адаптации комнатной температуры, контур 1
        /// </summary>
        public void ParseOptimizationTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11015, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает скорость адаптации комнатной температуры, контур 2
        /// </summary>
        public void ParseOptimizationTimeCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12015, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значения мин/макс температур подачи ГВС
        /// </summary>
        public void ParseHwsMinMaxFlowTemperatures()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12177, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12178, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
            }
        }

        /// <summary>
        /// Получает значения параметров ГВС
        /// </summary>
        public void ParseHwsParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12184, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12185, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12186, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12187, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает значения параметров ГВС
        /// </summary>
        public void ParseHwsParameters3Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12185, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12186, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12187, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
            }
        }

        /// <summary>
        /// Получает минимальное время активации электропривода ГВС
        /// </summary>
        public void ParseHwsDriveActivationTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12189, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает ограничение температуры обратки контура 1
        /// </summary>
        public void ParseHeatSystemLimitReverseTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11030, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает режимы работы контуров отопления и ГВС
        /// </summary>
        public void ParseOperatingModes()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4201, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4202, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1); 
            }
        }

        /// <summary>
        /// Получает статусы работы контуров 1 и 2
        /// </summary>
        public void ParseOperatingStatuses()
        {
            if(CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4211, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4212, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает режим работы контура 1
        /// </summary>
        public void ParseOperatingMode()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4201, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает статус работы контура 1
        /// </summary>
        public void ParseOperatingStatus()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4211, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает статусы режимов ручного управления
        /// </summary>
        public void ParseManualRelayStatuses()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4026, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4027, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1);
            }
        }


        /// <summary>
        /// Получает статусы режимов ручного управления (3 регистра)
        /// </summary>
        public void ParseManualRelayStatuses3Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4026, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4027, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4028, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает статусы режимов ручного управления (5 регистров)
        /// </summary>
        public void ParseManualRelayStatuses5Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4026, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4027, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4028, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4029, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4030, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает статусы режимов ручного управления (7 регистров)
        /// </summary>
        public void ParseManualRelayStatuses7Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4026, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4027, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4028, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4029, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4030, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4031, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_4032, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0) + 1);
            }
        }


        /// <summary>
        /// Получает параметры, связанные с работой датчика потока
        /// </summary>
        public void ParseFlowSensorParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12094, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12095, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12096, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12097, Convert.ToBoolean(BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0)));
            }
        }

        /// <summary>
        /// Получает параметры, связанные с доливом воды в контур 1
        /// </summary>
        public void ParseHeatSystemWaterFillParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11320, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11321, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11322, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11323, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры, связанные с доливом воды в контур 2
        /// </summary>
        public void ParseHwsWaterFillParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12320, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12321, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12322, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12323, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры, связанные с доливом воды в систему отопления (часть 2)
        /// </summary>
        public void ParseHeatSystemWaterFillParameters2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11325, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11326, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11327, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает заданную балансовую температуру
        /// </summary>
        public void ParseAdjustedBalanceTemperature()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11008, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает время ожидания перед открытием клапана, контур 1
        /// </summary>
        public void ParseHsWaitOpenValveTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11325, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает время ожидания перед открытием клапана, контур 2
        /// </summary>
        public void ParseHwsWaitOpenValveTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12325, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает тип входного сигнала давления
        /// </summary>
        public void ParseEcl310PressureInputSignalTypeId()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11327, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает тип входного сигнала давления контура 2 
        /// </summary>
        public void ParseEcl310PressureInputSignalType2Id()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12327, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает параметры насосов системы отопления
        /// </summary>
        public void ParseHeatSystemPumpParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11310, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11311, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11312, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11313, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11314, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры насосов ГВС
        /// </summary>
        public void ParseHwsPumpParameters()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12310, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12311, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12312, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12313, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12314, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
            }
        }

        /// <summary>
        /// Получает время профилактики насоса системы отопления
        /// </summary>
        public void ParseHeatSystemPumpTrainingTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11022, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает время профилактики насоса системы отопления (для A231)
        /// </summary>
        public void ParseHeatSystemPumpTrainingTime2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11022_A231, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг приоритета ограничения температуры обратки
        /// </summary>
        public void ParseLimitReversePriority()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11085, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг приоритета ограничения температуры обратки (контур 2)
        /// </summary>
        public void ParseLimitReversePriorityCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12085, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает время профилактики насоса ГВС
        /// </summary>
        public void ParseHwsPumpTrainingTime()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12022, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает количество насосов
        /// </summary>
        public void ParsePumpCount()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_10326, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает температуру защиты от замерзания, контур 2
        /// </summary>
        public void ParseFrostProtectionTemperatureCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12077, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает температуру тепловой нагрузки, контур 1
        /// </summary>
        public void ParseThermalLoadTemperatureCircuit1()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11078, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
        }

        /// <summary>
        /// Получает температуру тепловой нагрузки, контур 2
        /// </summary>
        public void ParseThermalLoadTemperatureCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12078, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает требуемую температуру защиты от замерзания, контур 2
        /// </summary>
        public void ParseFrostProtectionTemperature2Circuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12093, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры ограничения расхода, контур 1
        /// </summary>
        public void ParseFlowLimitationParams()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11112, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11113, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11114, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11115, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11116, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11117, (double)BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11118, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11119, BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0));
            }
        }

        /// <summary>
        /// Получает два параметра ограничения расхода, контур 1
        /// </summary>
        public void ParseFlowLimitation2Params()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11112, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11113, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
            }
        }

        /// <summary>
        /// Получает пять параметров ограничения расхода, контур 1
        /// </summary>
        public void ParseFlowLimitation5Params()
        {
            if (CheckErrors())
            {
                int value = BitConverter.ToInt16(new[] {Buffer[4], Buffer[3]}, 0);
                //_regulator.FlowLimitationUnitDict2Id = value + 1;
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11116, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11117, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11118, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11119, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
            }
        }


        /// <summary>
        /// Получает параметры ограничения расхода, контур 2
        /// </summary>
        public void ParseFlowLimitationParamsCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12112, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12113, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12114, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12115, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) + 1);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12116, (double)BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12117, (double)BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12118, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12119, BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0));
            }
        }

        /// <summary>
        /// Получает два параметра ограничения расхода, контур 2
        /// </summary>
        public void ParseFlowLimitation2ParamsCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12112, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12113, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
            }
        }

        /// <summary>
        /// Получает пять параметров ограничения расхода, контур 2
        /// </summary>
        public void ParseFlowLimitation5ParamsCircuit2()
        {
            if (CheckErrors())
            {
                int value = BitConverter.ToInt16(new[] {Buffer[4], Buffer[3]}, 0);
                //_regulator.FlowLimitationUnitDict2Circuit2Id = value + 1;

                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12116, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12117, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12118, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12119, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0));
            }
        }

        /// <summary>
        /// Получает тип входа ограничения расхода, контур 1
        /// </summary>
        public void ParseFlowLimitationInputTypeId()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11109, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает тип входа ограничения расхода, контур 2
        /// </summary>
        public void ParseFlowLimitationInputTypeCircuit2Id()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12109, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает параметры оптимизации, контур 1
        /// </summary>
        public void ParseOptimizationParams()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11011, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11012, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11013, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11014, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры оптимизации, контур 2
        /// </summary>
        public void ParseOptimizationParamsCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12011, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12012, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12013, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12014, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг задержки отключения, контур 1
        /// </summary>
        public void ParseOptimizationOffDelay()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11026, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг задержки отключения, контур 2
        /// </summary>
        public void ParseOptimizationOffDelayCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12026, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }


        /// <summary>
        /// Получает базис оптимизации, контур 1
        /// </summary>
        public void ParseOptimizationBasisId()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11020, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает базис оптимизации, контур 2
        /// </summary>
        public void ParseOptimizationBasisCircuit2Id()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12020, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает требуемые температуры
        /// </summary>
        public void ParseRequiredTemperatures()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11018, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11019, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает параметры ограничения расхода
        /// </summary>
        public void ParseFlowLimitationParams5Registers()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11111, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11112, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11113, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11114, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11115, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает параметры ограничения расхода, контур 2
        /// </summary>
        public void ParseFlowLimitationParams5RegistersCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12111, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12112, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12113, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12114, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12115, BitConverter.ToInt16(new[] { Buffer[12], Buffer[11] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает нагрузку охлаждения, контур 1
        /// </summary>
        public void ParseCoolingLoadTemperatureCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11070, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает температуру в режиме ожидания, контур 1
        /// </summary>
        public void ParseExpectationFlowTemperatureCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11092, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает коэффициент параллельной работы, контур 1
        /// </summary>
        public void ParseParallelOperationCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11043, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает флаг автонастройки, контур 2
        /// </summary>
        public void ParseAutotuningCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12173, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры сигнализации, контур 1
        /// </summary>
        public void ParseSignalizationParamsCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11079, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11080, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
            }
        }

        /// <summary>
        /// Получает аварийные границы давления, контур 1
        /// </summary>
        public void ParseAccidentLimits()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11614, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11615, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значения давления, контур 1
        /// </summary>
        public void ParsePressureValues()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11607, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11608, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11609, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11610, (double)BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значение флага сброса аварии насосов, контур 1
        /// </summary>
        public void ParseAccidentPumpsCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11315, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение флага сброса аварии насосов, контур 2
        /// </summary>
        public void ParseAccidentPumpsCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12315, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение флага сброса подпитки, контур 1
        /// </summary>
        public void ParseAccidentMakeupCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11324, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение флага сброса подпитки, контур 2
        /// </summary>
        public void ParseAccidentMakeupCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12324, BitConverter.ToBoolean(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает параметры подпитки контура 1
        /// </summary>
        public void ParseMakeupParametersCircuit1()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11320, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11321, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11322, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11323, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11324, BitConverter.ToBoolean(new[] { Buffer[12], Buffer[11] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11325, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11326, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11327, BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает параметры подпитки контура 2
        /// </summary>
        public void ParseMakeupParametersCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12320, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12321, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12322, (double)BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12323, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12324, BitConverter.ToBoolean(new[] { Buffer[12], Buffer[11] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12325, BitConverter.ToInt16(new[] { Buffer[14], Buffer[13] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12326, BitConverter.ToInt16(new[] { Buffer[16], Buffer[15] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12327, BitConverter.ToInt16(new[] { Buffer[18], Buffer[17] }, 0) + 1);
            }
        }

        /// <summary>
        /// Получает задержку аварии, контур 1
        /// </summary>
        public void ParseAccidentFrostThermostatDelay()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11617, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает количество насосов, контур 1
        /// </summary>
        public void ParseHsPumpCount()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11326, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает ограничение ГВС, контур 2
        /// </summary>
        public void ParseFlowLimitationLimitCircuit2()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_12111, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        public void ParseFlowLimitationUnitDict2Circuit2Id()
        {
            if (CheckErrors())
            {
                int value = BitConverter.ToInt16(new[] {Buffer[4], Buffer[3]}, 0);
            }
        }

        /// <summary>
        /// Получает угол наклона температурного графика, контур 1
        /// </summary>
        public void ParseHeatCurveAngle()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11175, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает границу отключения отопления, контур 1
        /// </summary>
        public void ParseHeatingBorder()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11179, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
            }
        }

        /// <summary>
        /// Получает значение регистра 11173
        /// </summary>
        public void ParsePnu11173()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11173, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение регистров 11185-11187
        /// </summary>
        public void ParsePnu11185_11187()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11185, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11186, BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11187, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
            }
        }

        /// <summary>
        /// Получает значение регистра 11189
        /// </summary>
        public void ParsePnu11189()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11189, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        public void ParsePnu11094_11097()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11094, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11095, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11096, BitConverter.ToInt16(new[] { Buffer[8], Buffer[7] }, 0));
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11097, BitConverter.ToInt16(new[] { Buffer[10], Buffer[9] }, 0));
            }
        }

        /// <summary>
        /// Получает значение регистра 11076
        /// </summary>
        public void ParsePnu11076()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11076, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        /// <summary>
        /// Получает значение регистра 11040
        /// </summary>
        public void ParsePnu11040()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11040, BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0));
            }
        }

        public void ParseNewDesiredHotWaterTemperatures()
        {
            if (CheckErrors())
            {
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11190, (double)BitConverter.ToInt16(new[] { Buffer[4], Buffer[3] }, 0) / 10);
                UpdateRegulatorParameter(DeviceParameter.ECL310_Pnu_11191, (double)BitConverter.ToInt16(new[] { Buffer[6], Buffer[5] }, 0) / 10);
            }
        }
    }
}

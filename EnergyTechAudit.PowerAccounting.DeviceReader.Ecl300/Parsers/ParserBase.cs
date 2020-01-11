using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using System.Collections.Generic;
using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Parsers
{
    internal sealed class ParserBase : EclParser
    {
        public ParserBase(ITransport iTransport, MeasurementDevice mDevice)
            : base(iTransport, mDevice)
        { 

        }

        private static Dictionary<byte, string> _applicationTable =
            new Dictionary<byte, string>
            {
                { 0x00, "A" },
                { 0x01, "b" },
                { 0x02, "C" },
                { 0x03, "d" },
                { 0x04, "E" },
                { 0x05, "F" },
                { 0x06, "G" },
                { 0x07, "H" },
                { 0x08, "L" },
                { 0x09, "n" },
                { 0x10, "o" },
                { 0x11, "P" },
                { 0x12, "U" }
            };
            
        /// <summary>
        /// Возвращает тип регулятора
        /// </summary>
        /// <returns></returns>
        public static string ParseApplication(byte[] buf)
        {
            var value = BitConverter.ToInt16(new byte[] { buf[4], buf[3] }, 0);
            var b = (byte)(value / 100);
            var number = value - b * 100;

            return string.Format(Resources.Common.TwoSimplePartsStringFormat, _applicationTable[b], number);
        }

        /// <summary>
        /// Возвращает текущее время прибора
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static DateTime ParseRs485DeviceTime(byte[] buf)
        {
            var hour = BitConverter.ToInt16(new byte[] { buf[4], buf[3] }, 0);
            var minute = BitConverter.ToInt16(new byte[] { buf[6], buf[5] }, 0);
            var day = BitConverter.ToInt16(new byte[] { buf[8], buf[7] }, 0);
            var month = BitConverter.ToInt16(new byte[] { buf[10], buf[9] }, 0);
            var year = 2000 + BitConverter.ToInt16(new byte[] { buf[12], buf[11] }, 0);

            return new DateTime(year, month, day, hour, minute, 0);
        }

        /// <summary>
        /// Возвращает значение температурного датчика
        /// </summary>
        /// <param name="buf">Пакет байтов</param>
        public decimal GetSensorValue()
        {
            short rawValue = BitConverter.ToInt16(new byte[] { Buffer[3], Buffer[2] }, 0);

            return (decimal)((double)rawValue / 128);
        }

        public decimal GetRs485SensorValue()
        {
            short rawValue = BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0);

            return (decimal)((double)rawValue / 10);
        }

        public decimal GetRs485ModeValue()
        {
            short rawValue = BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0);

            return (decimal)rawValue;
        }        

        /// <summary>
        /// Получает значение угла наклона температурного графика, контур 1
        /// </summary>
        public void ParseHeatCurve1()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HeatCurve1, (double)BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0) / 10);
        }

        public void ParseRoomTempDaySet()
        {
            var roomTempDaySet = BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0);
            UpdateRegulatorParameter(DeviceParameter.ECL300_RoomTempDaySet, roomTempDaySet);

            SaveRegulatorParameterToFinalArchive(roomTempDaySet, DeviceParameter.ECL300_RoomTempDaySet);
        }

        public void ParseRoomTempNightSet()
        {
            var roomTempNightSet = BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0);
            UpdateRegulatorParameter(DeviceParameter.ECL300_RoomTempNightSet, roomTempNightSet);

            SaveRegulatorParameterToFinalArchive(roomTempNightSet, DeviceParameter.ECL300_RoomTempNightSet);
        }

        public short GetMode()
        {
            return BitConverter.ToInt16(new byte[] { Buffer[3], 0x00 }, 0);
        }

        public void ParseMode1()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Mode1, BitConverter.ToInt16(new byte[] { Buffer[3], 0x00 }, 0));
        }

        public void ParseMode2()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Mode2, BitConverter.ToInt16(new byte[] { Buffer[3], 0x00 }, 0));
        }

        public void ParseSummerCutout1()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_SummerCutout1, BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0));
        }

        public void ParseSummerCutout2()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_SummerCutout2, BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0));
        }

        #region C66 RS232
        public void ParseHotWaterTempDaySet_C66_RS232()
        {
            var hotWaterTempDaySet = BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0);
            UpdateRegulatorParameter(DeviceParameter.ECL300_HotWaterTempDaySet, hotWaterTempDaySet);

            SaveRegulatorParameterToFinalArchive(hotWaterTempDaySet, DeviceParameter.ECL300_HotWaterTempDaySet);
        }

        public void ParseHotWaterTempNightSet_C66_RS232()
        {
            var hotWaterTempNightSet = BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0);
            UpdateRegulatorParameter(DeviceParameter.ECL300_HotWaterTempNightSet, hotWaterTempNightSet);

            SaveRegulatorParameterToFinalArchive(hotWaterTempNightSet, DeviceParameter.ECL300_HotWaterTempNightSet);
        }

        public void ParseParallel1_C66_RS232()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Parallel1, BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0));
        }

        public void ParseFlowTempMin1_C66_RS232()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_FlowTempMin1, BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0));
        }

        public void ParseFlowTempMax1_C66_RS232()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_FlowTempMax1, BitConverter.ToInt16(new byte[] { Buffer[2], 0x00 }, 0));
        }
        #endregion

        #region C66 RS485
        public void ParseHeatCurve1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HeatCurve1_RS485, (double)BitConverter.ToUInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
        }

        public void ParseHeatCurve2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HeatCurve2_RS485, (double)BitConverter.ToUInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
        }

        public void ParseParallel1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Parallel1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseParallel2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Parallel2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseHsHeatingOffTemperature1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HsHeatingOffTemperature1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseHsHeatingOffTemperature2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HsHeatingOffTemperature2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMinHsFlowTemperature1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MinHsFlowTemperature1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMinHsFlowTemperature2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MinHsFlowTemperature2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMaxHsFlowTemperature1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MaxHsFlowTemperature1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }
        public void ParseMaxHsFlowTemperature2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MaxHsFlowTemperature2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMaxAirInfluence1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MaxAirInfluence1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMinAirInfluence1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MinAirInfluence1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMaxAirInfluence2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MaxAirInfluence2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMinAirInfluence2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MinAirInfluence2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseProportionalBand1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ProportionalBand1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseProportionalBand2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ProportionalBand2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseIntegrationTime1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_IntegrationTime1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseIntegrationTime2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_IntegrationTime2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseDriveStockTravelTime1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_DriveStockTravelTime1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseDriveStockTravelTime2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_DriveStockTravelTime2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseNeutralZone1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_NeutralZone1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseNeutralZone2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_NeutralZone2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseReducedTempAddiction1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReducedTempAddiction1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseReducedTempAddiction2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReducedTempAddiction2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOverrun1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Overrun1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOverrun2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Overrun2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseSmoothTransition1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_SmoothTransition1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseSmoothTransition2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_SmoothTransition2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOptimizationTimeConstant1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_OptimizationTimeConstant1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOptimizationTimeConstant2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_OptimizationTimeConstant2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseAirRoomAdaptation1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_AirRoomAdaptation1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseAirRoomAdaptation2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_AirRoomAdaptation2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseExternalInfluenceTemp1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ExternalInfluenceTemp1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseAirRoomOptimization1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_AirRoomOptimization1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseAirRoomOptimization2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_AirRoomOptimization2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseBlackout1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Blackout1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseBlackout2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Blackout2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePumpTraining1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_PumpTraining1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePumpTraining2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_PumpTraining2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseFlapTraining1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_FlapTraining1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseFlapTraining2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_FlapTraining2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseDriveType1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_DriveType1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseDriveType2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_DriveType2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOpenAirTemp_X1_1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_OpenAirTemp_X1_1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOpenAirTemp_X1_2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_OpenAirTemp_X1_2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseReturnTemp_Y1_1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReturnTemp_Y1_1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseReturnTemp_Y1_2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReturnTemp_Y1_2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOpenAirTemp_X2_1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_OpenAirTemp_X2_1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseOpenAirTemp_X2_2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_OpenAirTemp_X2_2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseReturnTemp_Y2_1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReturnTemp_Y2_1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseReturnTemp_Y2_2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReturnTemp_Y2_2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMaxInfluenceReverse1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MaxInfluenceReverse1_RS485, (double)BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
        }

        public void ParseMaxInfluenceReverse2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MaxInfluenceReverse2_RS485, (double)BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
        }

        public void ParseMinInfluenceReverse1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MinInfluenceReverse1_RS485, (double)BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
        }

        public void ParseMinInfluenceReverse2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MinInfluenceReverse2_RS485, (double)BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0) / 10);
        }

        public void ParseReturnOptimizationViaSupply1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReturnOptimizationViaSupply1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseReturnOptimizationViaSupply2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ReturnOptimizationViaSupply2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseParallelWorkHwsAndHeatSys1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ParallelWorkHwsAndHeatSys1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePIRegulation1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_PIRegulation1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParsePIRegulation2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_PIRegulation2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMotorProtection1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MotorProtection1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseMotorProtection2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_MotorProtection2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseChangeSeason1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_ChangeSeason1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseRoomTempDaySet1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_RoomTempDaySet1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseRoomTempDaySet2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_RoomTempDaySet2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseRoomTempNightSet1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_RoomTempNightSet1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseRoomTempNightSet2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_RoomTempNightSet2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseHotWaterTempDaySet1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HotWaterTempDaySet1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseHotWaterTempDaySet2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HotWaterTempDaySet2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseHotWaterTempNightSet1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HotWaterTempNightSet1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseHotWaterTempNightSet2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_HotWaterTempNightSet2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseLimitReverseTemperature1_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_LimitReverseTemperature1_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseLimitReverseTemperature2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_LimitReverseTemperature2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        public void ParseAutotuning2_RS485()
        {
            UpdateRegulatorParameter(DeviceParameter.ECL300_Autotuning2_RS485, BitConverter.ToInt16(new byte[] { Buffer[4], Buffer[3] }, 0));
        }

        #endregion

        private void SaveRegulatorParameterToFinalArchive(decimal value, DeviceParameter deviceParameter)
        {
            using (var context = new LightDataAccess.LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
                {
                    try
                    {
                        context.Set<Archive>().Add(new Archive
                        {
                            Time = DateTime.Now,
                            DeviceParameterId = (int)deviceParameter,
                            MeasurementDeviceId = MDevice.Id,
                            PeriodTypeId = 6,
                            Value = value,
                            TimeSignature = new TimeSignature
                            {
                                DeviceTime = DateTime.Now,
                                Time = DateTime.Now,
                                MeasurementDeviceId = MDevice.Id
                            }
                        });
                        context.SaveChanges();

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    }
}

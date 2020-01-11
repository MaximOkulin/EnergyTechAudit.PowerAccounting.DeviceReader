using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API
{
    internal sealed partial class Functions
    {
        private readonly PackageHelper _packageHelper;
        private readonly ModbusPackageHelper _modbusPackageHelper;
        private readonly Commands _commands;

        public Functions(int networkAddress) 
        {
            _packageHelper = new PackageHelper();
            _commands = new Commands();
            _modbusPackageHelper = new ModbusPackageHelper(networkAddress);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetSensor1()
        {
            return _packageHelper.GetCommand(_commands.GetSensor1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetSensor2()
        {
            return _packageHelper.GetCommand(_commands.GetSensor2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetSensor3()
        {
            return _packageHelper.GetCommand(_commands.GetSensor3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetSensor4()
        {
            return _packageHelper.GetCommand(_commands.GetSensor4);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetSensor5()
        {
            return _packageHelper.GetCommand(_commands.GetSensor5);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetSensor6()
        {
            return _packageHelper.GetCommand(_commands.GetSensor6);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetCalcFlow1()
        {
            return _packageHelper.GetCommand(_commands.GetCalcFlow1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetCalcFlow2()
        {
            return _packageHelper.GetCommand(_commands.GetCalcFlow2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetCalcReturn1()
        {
            return _packageHelper.GetCommand(_commands.GetCalcReturn1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetCalcReturn2()
        {
            return _packageHelper.GetCommand(_commands.GetCalcReturn2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetRoomTemp1()
        {
            return _packageHelper.GetCommand(_commands.GetRoomTemp1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetRoomTemp2()
        {
            return _packageHelper.GetCommand(_commands.GetRoomTemp2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения
        /// </summary>
        public byte[] GetOutdoorTemperature()
        {
            return _packageHelper.GetCommand(_commands.GetOutdoorTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения угла наклона температурного графика, контур 1
        /// </summary>
        public byte[] GetHeatCurve1()
        {
            return _packageHelper.GetCommand(_commands.GetHeatCurve1);
        }

        public byte[] GetRoomTempDaySet()
        {
            return _packageHelper.GetCommand(_commands.GetRoomTempDaySet);
        }

        public byte[] GetRoomTempNightSet()
        {
            return _packageHelper.GetCommand(_commands.GetRoomTempNightSet);
        }

        public byte[] GetMode1()
        {
            return _packageHelper.GetCommand(_commands.GetMode1);
        }

        public byte[] GetMode2()
        {
            return _packageHelper.GetCommand(_commands.GetMode2);
        }

        public byte[] GetSummerCutout1()
        {
            return _packageHelper.GetCommand(_commands.GetSummerCutout1);
        }

        public byte[] GetSummerCutout2()
        {
            return _packageHelper.GetCommand(_commands.GetSummerCutout2);
        }

        #region C66 - RS232

        public byte[] GetHotWaterTempDaySet_C66_RS232()
        {
            return _packageHelper.GetCommand(_commands.GetHotWaterTempDaySet_C66_RS232);
        }

        public byte[] GetHotWaterTempNightSet_C66_RS232()
        {
            return _packageHelper.GetCommand(_commands.GetHotWaterTempNightSet_C66_RS232);
        }

        public byte[] GetParallel1_C66_RS232()
        {
            return _packageHelper.GetCommand(_commands.GetParallel1_C66_RS232);
        }

        public byte[] GetFlowTempMin1_C66_RS232()
        {
            return _packageHelper.GetCommand(_commands.GetFlowTempMin1_C66_RS232);
        }

        public byte[] GetFlowTempMax1_C66_RS232()
        {
            return _packageHelper.GetCommand(_commands.GetFlowTempMax1_C66_RS232);
        }
        #endregion

        #region C66 RS485
        /// <summary>
        /// Возвращает пакет байтов для чтения типа регулятора RS485
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Application()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Application);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчика S1
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Sensor1()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Sensor1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчика S2
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Sensor2()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Sensor2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчика S3
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Sensor3()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Sensor3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчика S4
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Sensor4()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Sensor4);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчика S5
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Sensor5()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Sensor5);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчика S6
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Sensor6()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Sensor6);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения уставки датчика S1
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485ReferenceS1()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485ReferenceS1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения уставки датчика S2
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485ReferenceS2()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485ReferenceS2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения уставки датчика S3
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485ReferenceS3()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485ReferenceS3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения уставки датчика S4
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485ReferenceS4()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485ReferenceS4);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения уставки датчика S5
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485ReferenceS5()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485ReferenceS5);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения уставки датчика S6
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485ReferenceS6()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485ReferenceS6);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения режима контура 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Circuit1Mode()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Circuit1Mode);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения режима контура 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Circuit2Mode()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Circuit2Mode);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения состояния контура 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Circuit1Status()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Circuit1Status);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения состояния контура 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485Circuit2Status()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485Circuit2Status);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущего времени прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetRs485DeviceTime()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRs485DeviceTime);
        }

        // РЕГУЛЯЦИОННЫЕ ПАРАМЕТРЫ
        /// <summary>
        /// Возвращает пакет байтов для чтения угла наклона температурного графика, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetHeatCurve1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHeatCurve1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения угла наклона температурного графика, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetHeatCurve2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHeatCurve2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параллельного сдвига температурного графика, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetParallel1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetParallel1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параллельного сдвига температурного графика, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetParallel2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetParallel2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения границы отключения отопления, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetHsHeatingOffTemperature1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHsHeatingOffTemperature1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения границы отключения отопления, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetHsHeatingOffTemperature2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHsHeatingOffTemperature2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимальной температуры подачи, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMinHsFlowTemperature1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMinHsFlowTemperature1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимальной температуры подачи, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMinHsFlowTemperature2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMinHsFlowTemperature2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения максимальной температуры подачи, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMaxHsFlowTemperature1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMaxHsFlowTemperature1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения максимальной температуры подачи, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMaxHsFlowTemperature2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMaxHsFlowTemperature2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения максимального влияния температуры воздуха в помещении, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMaxAirInfluence1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMaxAirInfluence1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимального  влияния температуры воздуха в помещении, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMinAirInfluence1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMinAirInfluence1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения максимального влияния температуры воздуха в помещении, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMaxAirInfluence2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMaxAirInfluence2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимального  влияния температуры воздуха в помещении, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMinAirInfluence2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMinAirInfluence2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения зоны пропорциональности, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetProportionalBand1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetProportionalBand1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения зоны пропорциональности, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetProportionalBand2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetProportionalBand2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения постоянной интегрирования, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetIntegrationTime1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetIntegrationTime1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения постоянной интегрирования, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetIntegrationTime2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetIntegrationTime2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени перемещения клапана с электроприводом, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetDriveStockTravelTime1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetDriveStockTravelTime1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени перемещения клапана с электроприводом, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetDriveStockTravelTime2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetDriveStockTravelTime2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения нейтральной зоны, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetNeutralZone1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetNeutralZone1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения нейтральной зоны, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetNeutralZone2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetNeutralZone2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения зависимости пониженной температуры от тем-ры окр. среды, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetReducedTempAddiction1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReducedTempAddiction1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения зависимости пониженной температуры от тем-ры окр. среды, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetReducedTempAddiction2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReducedTempAddiction2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения натопа, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetOverrun1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOverrun1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения натопа, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetOverrun2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOverrun2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения плавного перехода, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetSmoothTransition1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetSmoothTransition1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения плавного перехода, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetSmoothTransition2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetSmoothTransition2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения постоянной времени оптимизации, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetOptimizationTimeConstant1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOptimizationTimeConstant1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения постоянной времени оптимизации, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetOptimizationTimeConstant2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOptimizationTimeConstant2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения адаптации комнатной температуры, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetAirRoomAdaptation1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetAirRoomAdaptation1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения адаптации комнатной температуры, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetAirRoomAdaptation2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetAirRoomAdaptation2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения влияния на задание температуры подачи, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetExternalInfluenceTemp1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetExternalInfluenceTemp1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения оптимизации на основе комнатной тем-ры, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetAirRoomOptimization1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetAirRoomOptimization1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения оптимизации на основне комнатной тем-ры, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetAirRoomOptimization2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetAirRoomOptimization2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения полного отключения, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetBlackout1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetBlackout1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения полного отключения, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetBlackout2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetBlackout2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения прогона насоса, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetPumpTraining1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetPumpTraining1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения прогона насоса, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetPumpTraining2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetPumpTraining2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения прогона клапана, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetFlapTraining1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetFlapTraining1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения прогона клапана, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetFlapTraining2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetFlapTraining2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения типа привода, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetDriveType1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetDriveType1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения типа привода, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetDriveType2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetDriveType2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения макс. наружной температуры X1, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetOpenAirTemp_X1_1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOpenAirTemp_X1_1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения макс. наружной температуры X1, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetOpenAirTemp_X1_2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOpenAirTemp_X1_2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры возвращаемого теплоносителя Y1, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetReturnTemp_Y1_1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReturnTemp_Y1_1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры возвращаемого теплоносителя Y1, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetReturnTemp_Y1_2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReturnTemp_Y1_2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения макс. наружной температуры X2, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetOpenAirTemp_X2_1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOpenAirTemp_X2_1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения макс. наружной температуры X2, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetOpenAirTemp_X2_2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetOpenAirTemp_X2_2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры возвращаемого теплоносителя Y2, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetReturnTemp_Y2_1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReturnTemp_Y2_1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры возвращаемого теплоносителя Y2, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetReturnTemp_Y2_2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReturnTemp_Y2_2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения максимального влияния обратки, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMaxInfluenceReverse1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMaxInfluenceReverse1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения максимального влияния обратки, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMaxInfluenceReverse2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMaxInfluenceReverse2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимального влияния обратки, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMinInfluenceReverse1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMinInfluenceReverse1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимального влияния обратки, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMinInfluenceReverse2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMinInfluenceReverse2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения оптимизации температуры обратки по подаче, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetReturnOptimizationViaSupply1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReturnOptimizationViaSupply1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения оптимизации температуры обратки по подаче, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetReturnOptimizationViaSupply2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetReturnOptimizationViaSupply2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параллельной работы ГВС и контуров отопления, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetParallelWorkHwsAndHeatSys1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetParallelWorkHwsAndHeatSys1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения ПИ-регулирования, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetPIRegulation1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetPIRegulation1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения ПИ-регулирования, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetPIRegulation2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetPIRegulation2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения защиты двигателя, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMotorProtection1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMotorProtection1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения защиты двигателя, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMotorProtection2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetMotorProtection2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения автоматической смены сезонного времени, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetChangeSeason1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetChangeSeason1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой комнатной температуры (комфорт), контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetRoomTempDaySet1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRoomTempDaySet1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой комнатной температуры (комфорт), контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetRoomTempDaySet2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRoomTempDaySet2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой комнатной температуры (эконом), контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetRoomTempNightSet1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRoomTempNightSet1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой комнатной температуры (эконом), контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetRoomTempNightSet2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetRoomTempNightSet2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой температуры горячей воды (комфорт), контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetHotWaterTempDaySet1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHotWaterTempDaySet1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой температуры горячей воды (комфорт), контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetHotWaterTempDaySet2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHotWaterTempDaySet2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой температуры горячей воды (эконом), контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetHotWaterTempNightSet1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHotWaterTempNightSet1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемой температуры горячей воды (эконом), контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetHotWaterTempNightSet2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetHotWaterTempNightSet2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения ограничения температуры возвращаемого теплоносителя, контур 1
        /// </summary>
        /// <returns></returns>
        public byte[] GetLimitReverseTemperature1_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetLimitReverseTemperature1_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения ограничения температуры возвращаемого теплоносителя, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetLimitReverseTemperature2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetLimitReverseTemperature2_RS485);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага автоматической настройки, контур 2
        /// </summary>
        /// <returns></returns>
        public byte[] GetAutotuning2_RS485()
        {
            return _modbusPackageHelper.GetCommand(_commands.GetAutotuning2_RS485);
        }
        #endregion
    }
}

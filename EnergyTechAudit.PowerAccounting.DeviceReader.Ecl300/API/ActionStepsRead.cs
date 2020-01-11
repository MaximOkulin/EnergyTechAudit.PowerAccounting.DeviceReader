using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API
{
    internal sealed partial class ActionSteps : ActionStepsBase
    {
        private readonly Functions _functions; 
        private readonly Commands _commands;

        public ActionSteps(DeviceTransport ecl300Connection, ManualResetEvent autoEvent, int networkAddress)
            : base(ecl300Connection, autoEvent)
        {
            _functions = new Functions(networkAddress);
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetSensor1()
        {
            Transport.CurrentCommand = _commands.GetSensor1;
            Transport.Send(_functions.GetSensor1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetSensor2()
        {
            Transport.CurrentCommand = _commands.GetSensor2;
            Transport.Send(_functions.GetSensor2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetSensor3()
        {
            Transport.CurrentCommand = _commands.GetSensor3;
            Transport.Send(_functions.GetSensor3(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetSensor4()
        {
            Transport.CurrentCommand = _commands.GetSensor4;
            Transport.Send(_functions.GetSensor4(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetSensor5()
        {
            Transport.CurrentCommand = _commands.GetSensor5;
            Transport.Send(_functions.GetSensor5(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetSensor6()
        {
            Transport.CurrentCommand = _commands.GetSensor6;
            Transport.Send(_functions.GetSensor6(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetCalcFlow1()
        {
            Transport.CurrentCommand = _commands.GetCalcFlow1;
            Transport.Send(_functions.GetCalcFlow1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает 
        /// </summary>
        public bool GetCalcFlow2()
        {
            Transport.CurrentCommand = _commands.GetCalcFlow2;
            Transport.Send(_functions.GetCalcFlow2(), true);
            return Wait();
        }

        // <summary>
        /// Возвращает 
        /// </summary>
        public bool GetCalcReturn1()
        {
            Transport.CurrentCommand = _commands.GetCalcReturn1;
            Transport.Send(_functions.GetCalcReturn1(), true);
            return Wait();
        }

        // <summary>
        /// Возвращает 
        /// </summary>
        public bool GetCalcReturn2()
        {
            Transport.CurrentCommand = _commands.GetCalcReturn2;
            Transport.Send(_functions.GetCalcReturn2(), true);
            return Wait();
        }

        // <summary>
        /// Возвращает 
        /// </summary>
        public bool GetRoomTemp1()
        {
            Transport.CurrentCommand = _commands.GetRoomTemp1;
            Transport.Send(_functions.GetRoomTemp1(), true);
            return Wait();
        }


        // <summary>
        /// Возвращает 
        /// </summary>
        public bool GetRoomTemp2()
        {
            Transport.CurrentCommand = _commands.GetRoomTemp2;
            Transport.Send(_functions.GetRoomTemp2(), true);
            return Wait();
        }

        // <summary>
        /// Возвращает температуру наружного воздуха 
        /// </summary>
        public bool GetOutdoorTemperature()
        {
            Transport.CurrentCommand = _commands.GetOutdoorTemperature;
            Transport.Send(_functions.GetOutdoorTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает угол наклона температурного графика, контур 1
        /// </summary>
        public bool GetHeatCurve1()
        {
            Transport.CurrentCommand = _commands.GetHeatCurve1;
            Transport.Send(_functions.GetHeatCurve1(), true);
            return Wait();
        }

        public bool GetRoomTempDaySet()
        {
            Transport.CurrentCommand = _commands.GetRoomTempDaySet;
            Transport.Send(_functions.GetRoomTempDaySet(), true);
            return Wait();
        }

        public bool GetRoomTempNightSet()
        {
            Transport.CurrentCommand = _commands.GetRoomTempNightSet;
            Transport.Send(_functions.GetRoomTempNightSet(), true);
            return Wait();
        }

        public bool GetMode1()
        {
            Transport.CurrentCommand = _commands.GetMode1;
            Transport.Send(_functions.GetMode1(), true);
            return Wait();
        }

        public bool GetMode2()
        {
            Transport.CurrentCommand = _commands.GetMode2;
            Transport.Send(_functions.GetMode2(), true);
            return Wait();
        }

        public bool GetSummerCutout1()
        {
            Transport.CurrentCommand = _commands.GetSummerCutout1;
            Transport.Send(_functions.GetSummerCutout1(), true);
            return Wait();
        }

        public bool GetSummerCutout2()
        {
            Transport.CurrentCommand = _commands.GetSummerCutout2;
            Transport.Send(_functions.GetSummerCutout2(), true);
            return Wait();
        }

        #region C66 - RS232
        public bool GetHotWaterTempDaySet_C66_RS232()
        {
            Transport.CurrentCommand = _commands.GetHotWaterTempDaySet_C66_RS232;
            Transport.Send(_functions.GetHotWaterTempDaySet_C66_RS232(), true);
            return Wait();
        }

        public bool GetHotWaterTempNightSet_C66_RS232()
        {
            Transport.CurrentCommand = _commands.GetHotWaterTempNightSet_C66_RS232;
            Transport.Send(_functions.GetHotWaterTempNightSet_C66_RS232(), true);
            return Wait();
        }

        public bool GetParallel1_C66_RS232()
        {
            Transport.CurrentCommand = _commands.GetParallel1_C66_RS232;
            Transport.Send(_functions.GetParallel1_C66_RS232(), true);
            return Wait();
        }

        public bool GetFlowTempMin1_C66_RS232()
        {
            Transport.CurrentCommand = _commands.GetFlowTempMin1_C66_RS232;
            Transport.Send(_functions.GetFlowTempMin1_C66_RS232(), true);
            return Wait();
        }

        public bool GetFlowTempMax1_C66_RS232()
        {
            Transport.CurrentCommand = _commands.GetFlowTempMax1_C66_RS232;
            Transport.Send(_functions.GetFlowTempMax1_C66_RS232(), true);
            return Wait();
        }

        #endregion

        #region C66 RS485
        /// <summary>
        /// Чтение типа регулятора (RS485)
        /// </summary>
        public void GetRs485Application()
        {
            Transport.CurrentCommand = _commands.GetRs485Application;
            Transport.Send(_functions.GetRs485Application(), true);
            Wait();
        }

        /// <summary>
        /// Чтение значения датчика S1
        /// </summary>
        public bool GetRs485Sensor1()
        {
            Transport.CurrentCommand = _commands.GetRs485Sensor1;
            Transport.Send(_functions.GetRs485Sensor1(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение значения датчика S2
        /// </summary>
        public bool GetRs485Sensor2()
        {
            Transport.CurrentCommand = _commands.GetRs485Sensor2;
            Transport.Send(_functions.GetRs485Sensor2(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение значения датчика S3
        /// </summary>
        public bool GetRs485Sensor3()
        {
            Transport.CurrentCommand = _commands.GetRs485Sensor3;
            Transport.Send(_functions.GetRs485Sensor3(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение значения датчика S4
        /// </summary>
        public bool GetRs485Sensor4()
        {
            Transport.CurrentCommand = _commands.GetRs485Sensor4;
            Transport.Send(_functions.GetRs485Sensor4(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение значения датчика S
        /// </summary>
        public bool GetRs485Sensor5()
        {
            Transport.CurrentCommand = _commands.GetRs485Sensor5;
            Transport.Send(_functions.GetRs485Sensor5(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение значения датчика S6
        /// </summary>
        public bool GetRs485Sensor6()
        {
            Transport.CurrentCommand = _commands.GetRs485Sensor6;
            Transport.Send(_functions.GetRs485Sensor6(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение уставки датчика S1
        /// </summary>
        /// <returns></returns>
        public bool GetRs485ReferenceS1()
        {
            Transport.CurrentCommand = _commands.GetRs485ReferenceS1;
            Transport.Send(_functions.GetRs485ReferenceS1(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение уставки датчика S2
        /// </summary>
        /// <returns></returns>
        public bool GetRs485ReferenceS2()
        {
            Transport.CurrentCommand = _commands.GetRs485ReferenceS2;
            Transport.Send(_functions.GetRs485ReferenceS2(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение уставки датчика S3
        /// </summary>
        /// <returns></returns>
        public bool GetRs485ReferenceS3()
        {
            Transport.CurrentCommand = _commands.GetRs485ReferenceS3;
            Transport.Send(_functions.GetRs485ReferenceS3(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение уставки датчика S4
        /// </summary>
        /// <returns></returns>
        public bool GetRs485ReferenceS4()
        {
            Transport.CurrentCommand = _commands.GetRs485ReferenceS4;
            Transport.Send(_functions.GetRs485ReferenceS4(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение уставки датчика S5
        /// </summary>
        /// <returns></returns>
        public bool GetRs485ReferenceS5()
        {
            Transport.CurrentCommand = _commands.GetRs485ReferenceS5;
            Transport.Send(_functions.GetRs485ReferenceS5(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение уставки датчика S6
        /// </summary>
        /// <returns></returns>
        public bool GetRs485ReferenceS6()
        {
            Transport.CurrentCommand = _commands.GetRs485ReferenceS6;
            Transport.Send(_functions.GetRs485ReferenceS6(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение режима контура 1
        /// </summary>
        /// <returns></returns>
        public bool GetRs485Circuit1Mode()
        {
            Transport.CurrentCommand = _commands.GetRs485Circuit1Mode;
            Transport.Send(_functions.GetRs485Circuit1Mode(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение режима контура 2
        /// </summary>
        /// <returns></returns>
        public bool GetRs485Circuit2Mode()
        {
            Transport.CurrentCommand = _commands.GetRs485Circuit2Mode;
            Transport.Send(_functions.GetRs485Circuit2Mode(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение статуса контура 1
        /// </summary>
        /// <returns></returns>
        public bool GetRs485Circuit1Status()
        {
            Transport.CurrentCommand = _commands.GetRs485Circuit1Status;
            Transport.Send(_functions.GetRs485Circuit1Status(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение статуса контура 2
        /// </summary>
        /// <returns></returns>
        public bool GetRs485Circuit2Status()
        {
            Transport.CurrentCommand = _commands.GetRs485Circuit2Status;
            Transport.Send(_functions.GetRs485Circuit2Status(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение текущего времени прибора
        /// </summary>
        public void GetRs485DeviceTime()
        {
            Transport.CurrentCommand = _commands.GetRs485DeviceTime;
            Transport.Send(_functions.GetRs485DeviceTime(), true);
            Wait();
        }

        // РЕГУЛЯЦИОННЫЕ ПАРАМЕТРЫ
        /// <summary>
        /// Чтение угла наклона температурного графика контура 1
        /// </summary>
        /// <returns></returns>
        public bool GetHeatCurve1_RS485()
        {
            Transport.CurrentCommand = _commands.GetHeatCurve1_RS485;
            Transport.Send(_functions.GetHeatCurve1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение угла наклона температурного графика контура 2
        /// </summary>
        /// <returns></returns>
        public bool GetHeatCurve2_RS485()
        {
            Transport.CurrentCommand = _commands.GetHeatCurve2_RS485;
            Transport.Send(_functions.GetHeatCurve2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение параллельного сдвига температурного графика, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetParallel1_RS485()
        {
            Transport.CurrentCommand = _commands.GetParallel1_RS485;
            Transport.Send(_functions.GetParallel1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение параллельного сдвига температурного графика, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetParallel2_RS485()
        {
            Transport.CurrentCommand = _commands.GetParallel2_RS485;
            Transport.Send(_functions.GetParallel2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение границы отключения отопления, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetHsHeatingOffTemperature1_RS485()
        {
            Transport.CurrentCommand = _commands.GetHsHeatingOffTemperature1_RS485;
            Transport.Send(_functions.GetHsHeatingOffTemperature1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение границы отключения отопления, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetHsHeatingOffTemperature2_RS485()
        {
            Transport.CurrentCommand = _commands.GetHsHeatingOffTemperature2_RS485;
            Transport.Send(_functions.GetHsHeatingOffTemperature2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение минимальной температуры подачи, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetMinHsFlowTemperature1_RS485()
        {
            Transport.CurrentCommand = _commands.GetMinHsFlowTemperature1_RS485;
            Transport.Send(_functions.GetMinHsFlowTemperature1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение минимальной температуры подачи, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetMinHsFlowTemperature2_RS485()
        {
            Transport.CurrentCommand = _commands.GetMinHsFlowTemperature2_RS485;
            Transport.Send(_functions.GetMinHsFlowTemperature2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение максимальной температуры подачи, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetMaxHsFlowTemperature1_RS485()
        {
            Transport.CurrentCommand = _commands.GetMaxHsFlowTemperature1_RS485;
            Transport.Send(_functions.GetMaxHsFlowTemperature1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение максимальной температуры подачи, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetMaxHsFlowTemperature2_RS485()
        {
            Transport.CurrentCommand = _commands.GetMaxHsFlowTemperature2_RS485;
            Transport.Send(_functions.GetMaxHsFlowTemperature2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение максимального влияния температуры воздуха в помещение, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetMaxAirInfluence1_RS485()
        {
            Transport.CurrentCommand = _commands.GetMaxAirInfluence1_RS485;
            Transport.Send(_functions.GetMaxAirInfluence1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение минимального влияния температуры воздуха в помещение, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetMinAirInfluence1_RS485()
        {
            Transport.CurrentCommand = _commands.GetMinAirInfluence1_RS485;
            Transport.Send(_functions.GetMinAirInfluence1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение максимального влияния температуры воздуха в помещение, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetMaxAirInfluence2_RS485()
        {
            Transport.CurrentCommand = _commands.GetMaxAirInfluence2_RS485;
            Transport.Send(_functions.GetMaxAirInfluence2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение минимального влияния температуры воздуха в помещение, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetMinAirInfluence2_RS485()
        {
            Transport.CurrentCommand = _commands.GetMinAirInfluence2_RS485;
            Transport.Send(_functions.GetMinAirInfluence2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение зоны пропорциональности, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetProportionalBand1_RS485()
        {
            Transport.CurrentCommand = _commands.GetProportionalBand1_RS485;
            Transport.Send(_functions.GetProportionalBand1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение зоны пропорциональности, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetProportionalBand2_RS485()
        {
            Transport.CurrentCommand = _commands.GetProportionalBand2_RS485;
            Transport.Send(_functions.GetProportionalBand2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение постоянной интегрирования, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetIntegrationTime1_RS485()
        {
            Transport.CurrentCommand = _commands.GetIntegrationTime1_RS485;
            Transport.Send(_functions.GetIntegrationTime1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение постоянной интегрирования, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetIntegrationTime2_RS485()
        {
            Transport.CurrentCommand = _commands.GetIntegrationTime2_RS485;
            Transport.Send(_functions.GetIntegrationTime2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение времени перемещения клапана с электроприводом, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetDriveStockTravelTime1_RS485()
        {
            Transport.CurrentCommand = _commands.GetDriveStockTravelTime1_RS485;
            Transport.Send(_functions.GetDriveStockTravelTime1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение времени перемещения клапана с электроприводом, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetDriveStockTravelTime2_RS485()
        {
            Transport.CurrentCommand = _commands.GetDriveStockTravelTime2_RS485;
            Transport.Send(_functions.GetDriveStockTravelTime2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение нейтральной зоны, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetNeutralZone1_RS485()
        {
            Transport.CurrentCommand = _commands.GetNeutralZone1_RS485;
            Transport.Send(_functions.GetNeutralZone1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение нейтральной зоны, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetNeutralZone2_RS485()
        {
            Transport.CurrentCommand = _commands.GetNeutralZone2_RS485;
            Transport.Send(_functions.GetNeutralZone2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение зависимости пониженной температуры от тем-ры окр. среды, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetReducedTempAddiction1_RS485()
        {
            Transport.CurrentCommand = _commands.GetReducedTempAddiction1_RS485;
            Transport.Send(_functions.GetReducedTempAddiction1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение зависимости пониженной температуры от тем-ры окр. среды, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetReducedTempAddiction2_RS485()
        {
            Transport.CurrentCommand = _commands.GetReducedTempAddiction2_RS485;
            Transport.Send(_functions.GetReducedTempAddiction2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение натопа, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetOverrun1_RS485()
        {
            Transport.CurrentCommand = _commands.GetOverrun1_RS485;
            Transport.Send(_functions.GetOverrun1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение натопа, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetOverrun2_RS485()
        {
            Transport.CurrentCommand = _commands.GetOverrun2_RS485;
            Transport.Send(_functions.GetOverrun2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение плавного перехода, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetSmoothTransition1_RS485()
        {
            Transport.CurrentCommand = _commands.GetSmoothTransition1_RS485;
            Transport.Send(_functions.GetSmoothTransition1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение плавного перехода, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetSmoothTransition2_RS485()
        {
            Transport.CurrentCommand = _commands.GetSmoothTransition2_RS485;
            Transport.Send(_functions.GetSmoothTransition2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение постоянной времени оптимизации, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetOptimizationTimeConstant1_RS485()
        {
            Transport.CurrentCommand = _commands.GetOptimizationTimeConstant1_RS485;
            Transport.Send(_functions.GetOptimizationTimeConstant1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение постоянной времени оптимизации, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetOptimizationTimeConstant2_RS485()
        {
            Transport.CurrentCommand = _commands.GetOptimizationTimeConstant2_RS485;
            Transport.Send(_functions.GetOptimizationTimeConstant2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение адаптации комнатной температуры, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetAirRoomAdaptation1_RS485()
        {
            Transport.CurrentCommand = _commands.GetAirRoomAdaptation1_RS485;
            Transport.Send(_functions.GetAirRoomAdaptation1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение адаптации комнатной температуры, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetAirRoomAdaptation2_RS485()
        {
            Transport.CurrentCommand = _commands.GetAirRoomAdaptation2_RS485;
            Transport.Send(_functions.GetAirRoomAdaptation2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение влияния на задание температуры подачи, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetExternalInfluenceTemp1_RS485()
        {
            Transport.CurrentCommand = _commands.GetExternalInfluenceTemp1_RS485;
            Transport.Send(_functions.GetExternalInfluenceTemp1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение оптимизации на основне комнатной тем-ры, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetAirRoomOptimization1_RS485()
        {
            Transport.CurrentCommand = _commands.GetAirRoomOptimization1_RS485;
            Transport.Send(_functions.GetAirRoomOptimization1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение оптимизации на основне комнатной тем-ры, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetAirRoomOptimization2_RS485()
        {
            Transport.CurrentCommand = _commands.GetAirRoomOptimization2_RS485;
            Transport.Send(_functions.GetAirRoomOptimization2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение полного отключения, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetBlackout1_RS485()
        {
            Transport.CurrentCommand = _commands.GetBlackout1_RS485;
            Transport.Send(_functions.GetBlackout1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение полного отключения, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetBlackout2_RS485()
        {
            Transport.CurrentCommand = _commands.GetBlackout2_RS485;
            Transport.Send(_functions.GetBlackout2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение прогона насоса, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetPumpTraining1_RS485()
        {
            Transport.CurrentCommand = _commands.GetPumpTraining1_RS485;
            Transport.Send(_functions.GetPumpTraining1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение прогона насоса, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetPumpTraining2_RS485()
        {
            Transport.CurrentCommand = _commands.GetPumpTraining2_RS485;
            Transport.Send(_functions.GetPumpTraining2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение прогона клапана, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetFlapTraining1_RS485()
        {
            Transport.CurrentCommand = _commands.GetFlapTraining1_RS485;
            Transport.Send(_functions.GetFlapTraining1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение прогона клапана, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetFlapTraining2_RS485()
        {
            Transport.CurrentCommand = _commands.GetFlapTraining2_RS485;
            Transport.Send(_functions.GetFlapTraining2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение типа привода, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetDriveType1_RS485()
        {
            Transport.CurrentCommand = _commands.GetDriveType1_RS485;
            Transport.Send(_functions.GetDriveType1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение типа привода, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetDriveType2_RS485()
        {
            Transport.CurrentCommand = _commands.GetDriveType2_RS485;
            Transport.Send(_functions.GetDriveType2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение макс. наружной температураы X1, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetOpenAirTemp_X1_1_RS485()
        {
            Transport.CurrentCommand = _commands.GetOpenAirTemp_X1_1_RS485;
            Transport.Send(_functions.GetOpenAirTemp_X1_1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение макс. наружной температураы X1, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetOpenAirTemp_X1_2_RS485()
        {
            Transport.CurrentCommand = _commands.GetOpenAirTemp_X1_2_RS485;
            Transport.Send(_functions.GetOpenAirTemp_X1_2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y1, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetReturnTemp_Y1_1_RS485()
        {
            Transport.CurrentCommand = _commands.GetReturnTemp_Y1_1_RS485;
            Transport.Send(_functions.GetReturnTemp_Y1_1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y1, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetReturnTemp_Y1_2_RS485()
        {
            Transport.CurrentCommand = _commands.GetReturnTemp_Y1_2_RS485;
            Transport.Send(_functions.GetReturnTemp_Y1_2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение макс. наружной температуры X2, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetOpenAirTemp_X2_1_RS485()
        {
            Transport.CurrentCommand = _commands.GetOpenAirTemp_X2_1_RS485;
            Transport.Send(_functions.GetOpenAirTemp_X2_1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение макс. наружной температуры X2, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetOpenAirTemp_X2_2_RS485()
        {
            Transport.CurrentCommand = _commands.GetOpenAirTemp_X2_2_RS485;
            Transport.Send(_functions.GetOpenAirTemp_X2_2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y2, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetReturnTemp_Y2_1_RS485()
        {
            Transport.CurrentCommand = _commands.GetReturnTemp_Y2_1_RS485;
            Transport.Send(_functions.GetReturnTemp_Y2_1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y2, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetReturnTemp_Y2_2_RS485()
        {
            Transport.CurrentCommand = _commands.GetReturnTemp_Y2_2_RS485;
            Transport.Send(_functions.GetReturnTemp_Y2_2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение максимального влияния обратки, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetMaxInfluenceReverse1_RS485()
        {
            Transport.CurrentCommand = _commands.GetMaxInfluenceReverse1_RS485;
            Transport.Send(_functions.GetMaxInfluenceReverse1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение максимального влияния обратки, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetMaxInfluenceReverse2_RS485()
        {
            Transport.CurrentCommand = _commands.GetMaxInfluenceReverse2_RS485;
            Transport.Send(_functions.GetMaxInfluenceReverse2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение минимального влияния обратки, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetMinInfluenceReverse1_RS485()
        {
            Transport.CurrentCommand = _commands.GetMinInfluenceReverse1_RS485;
            Transport.Send(_functions.GetMinInfluenceReverse1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение минимального влияния обратки, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetMinInfluenceReverse2_RS485()
        {
            Transport.CurrentCommand = _commands.GetMinInfluenceReverse2_RS485;
            Transport.Send(_functions.GetMinInfluenceReverse2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение оптимизации температуры обратки по подаче, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetReturnOptimizationViaSupply1_RS485()
        {
            Transport.CurrentCommand = _commands.GetReturnOptimizationViaSupply1_RS485;
            Transport.Send(_functions.GetReturnOptimizationViaSupply1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение оптимизации температуры обратки по подаче, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetReturnOptimizationViaSupply2_RS485()
        {
            Transport.CurrentCommand = _commands.GetReturnOptimizationViaSupply2_RS485;
            Transport.Send(_functions.GetReturnOptimizationViaSupply2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение параллельной работы ГВС и контуров отопления, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetParallelWorkHwsAndHeatSys1_RS485()
        {
            Transport.CurrentCommand = _commands.GetParallelWorkHwsAndHeatSys1_RS485;
            Transport.Send(_functions.GetParallelWorkHwsAndHeatSys1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение ПИ-регулирования, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetPIRegulation1_RS485()
        {
            Transport.CurrentCommand = _commands.GetPIRegulation1_RS485;
            Transport.Send(_functions.GetPIRegulation1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение ПИ-регулирования, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetPIRegulation2_RS485()
        {
            Transport.CurrentCommand = _commands.GetPIRegulation2_RS485;
            Transport.Send(_functions.GetPIRegulation2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение защиты двигателя, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetMotorProtection1_RS485()
        {
            Transport.CurrentCommand = _commands.GetMotorProtection1_RS485;
            Transport.Send(_functions.GetMotorProtection1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение защиты двигателя, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetMotorProtection2_RS485()
        {
            Transport.CurrentCommand = _commands.GetMotorProtection2_RS485;
            Transport.Send(_functions.GetMotorProtection2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение автоматической смены сезонного времени, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetChangeSeason1_RS485()
        {
            Transport.CurrentCommand = _commands.GetChangeSeason1_RS485;
            Transport.Send(_functions.GetChangeSeason1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой комнатной температуры (комфорт), контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetRoomTempDaySet1_RS485()
        {
            Transport.CurrentCommand = _commands.GetRoomTempDaySet1_RS485;
            Transport.Send(_functions.GetRoomTempDaySet1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой комнатной температуры (комфорт), контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetRoomTempDaySet2_RS485()
        {
            Transport.CurrentCommand = _commands.GetRoomTempDaySet2_RS485;
            Transport.Send(_functions.GetRoomTempDaySet2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой комнатной температуры (эконом), контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetRoomTempNightSet1_RS485()
        {
            Transport.CurrentCommand = _commands.GetRoomTempNightSet1_RS485;
            Transport.Send(_functions.GetRoomTempNightSet1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой комнатной температуры (эконом), контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetRoomTempNightSet2_RS485()
        {
            Transport.CurrentCommand = _commands.GetRoomTempNightSet2_RS485;
            Transport.Send(_functions.GetRoomTempNightSet2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой температуры горячей воды (комфорт), контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetHotWaterTempDaySet1_RS485()
        {
            Transport.CurrentCommand = _commands.GetHotWaterTempDaySet1_RS485;
            Transport.Send(_functions.GetHotWaterTempDaySet1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой температуры горячей воды (комфорт), контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetHotWaterTempDaySet2_RS485()
        {
            Transport.CurrentCommand = _commands.GetHotWaterTempDaySet2_RS485;
            Transport.Send(_functions.GetHotWaterTempDaySet2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой температуры горячей воды (эконом), контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetHotWaterTempNightSet1_RS485()
        {
            Transport.CurrentCommand = _commands.GetHotWaterTempNightSet1_RS485;
            Transport.Send(_functions.GetHotWaterTempNightSet1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение желаемой температуры горячей воды (эконом), контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetHotWaterTempNightSet2_RS485()
        {
            Transport.CurrentCommand = _commands.GetHotWaterTempNightSet2_RS485;
            Transport.Send(_functions.GetHotWaterTempNightSet2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение ограничения температуры возвращаемого теплоносителя, контур 1
        /// </summary>
        /// <returns></returns>
        public bool GetLimitReverseTemperature1_RS485()
        {
            Transport.CurrentCommand = _commands.GetLimitReverseTemperature1_RS485;
            Transport.Send(_functions.GetLimitReverseTemperature1_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение ограничения температуры возвращаемого теплоносителя, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetLimitReverseTemperature2_RS485()
        {
            Transport.CurrentCommand = _commands.GetLimitReverseTemperature2_RS485;
            Transport.Send(_functions.GetLimitReverseTemperature2_RS485(), true);
            return Wait();
        }

        /// <summary>
        /// Чтение флага автоматической настройки, контур 2
        /// </summary>
        /// <returns></returns>
        public bool GetAutotuning2_RS485()
        {
            Transport.CurrentCommand = _commands.GetAutotuning2_RS485;
            Transport.Send(_functions.GetAutotuning2_RS485(), true);
            return Wait();
        }
        #endregion
    }
}

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API
{
    internal sealed partial class ActionSteps
    {
        /// <summary>
        /// Устанавливает новое значение угла наклона температурного графика контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        /// <returns>true - успех; false - сбой</returns> 
        public bool SetHeatCurve1(double value)
        {
            Transport.CurrentCommand = _commands.SetHeatCurve1RAM;
            Transport.Send(_functions.SetHeatCurve1RAM((short)(value* 10)), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetHeatCurve1EEPROM;
            Transport.Send(_functions.SetHeatCurve1EEPROM((short)(value * 10)), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение желаемой комнатной температуры (комфорт)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public bool SetRoomTempDaySet(int value)
        {
            Transport.CurrentCommand = _commands.SetRoomTempDaySetRAM;
            Transport.Send(_functions.SetRoomTempDaySetRAM((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetRoomTempDaySetEEPROM;
            Transport.Send(_functions.SetRoomTempDaySetEEPROM((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение желаемой комнатной температуры (эконом)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public bool SetRoomTempNightSet(int value)
        {
            Transport.CurrentCommand = _commands.SetRoomTempNightSetRAM;
            Transport.Send(_functions.SetRoomTempNightSetRAM((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetRoomTempNightSetEEPROM;
            Transport.Send(_functions.SetRoomTempNightSetEEPROM((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение температуры отключения отопления в контуре 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        public bool SetSummerCutout1(int value)
        {
            Transport.CurrentCommand = _commands.SetSummerCutout1RAM;
            Transport.Send(_functions.SetSummerCutout1RAM((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetSummerCutout1EEPROM;
            Transport.Send(_functions.SetSummerCutout1EEPROM((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение температуры отключения отопления в контуре 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        public bool SetSummerCutout2(int value)
        {
            Transport.CurrentCommand = _commands.SetSummerCutout2RAM;
            Transport.Send(_functions.SetSummerCutout2RAM((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetSummerCutout2EEPROM;
            Transport.Send(_functions.SetSummerCutout2EEPROM((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        #region C66 RS232
        /// <summary>
        /// Устанавливает новое значение желаемой температуры горячей воды (комфорт)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public bool SetHotWaterTempDaySet_C66_RS232(int value)
        {
            Transport.CurrentCommand = _commands.SetHotWaterTempDaySetRAM_C66_RS232;
            Transport.Send(_functions.SetHotWaterTempDaySetRAM_C66_RS232((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetHotWaterTempDaySetEEPROM_C66_RS232;
            Transport.Send(_functions.SetHotWaterTempDaySetEEPROM_C66_RS232((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение желаемой температуры горячей воды (эконом)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public bool SetHotWaterTempNightSet_C66_RS232(int value)
        {
            Transport.CurrentCommand = _commands.SetHotWaterTempNightSetRAM_C66_RS232;
            Transport.Send(_functions.SetHotWaterTempNightSetRAM_C66_RS232((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetHotWaterTempNightSetEEPROM_C66_RS232;
            Transport.Send(_functions.SetHotWaterTempNightSetEEPROM_C66_RS232((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение параллельного переноса графика в контуре 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        public bool SetParallel1_C66_RS232(int value)
        {
            Transport.CurrentCommand = _commands.SetParallel1RAM_C66_RS232;
            Transport.Send(_functions.SetParallel1RAM_C66_RS232((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetParallel1EEPROM_C66_RS232;
            Transport.Send(_functions.SetParallel1EEPROM_C66_RS232((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение минимальной температуры подачи контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        /// <returns></returns>
        public bool SetFlowTempMin1_C66_RS232(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowTempMin1RAM_C66_RS232;
            Transport.Send(_functions.SetFlowTempMin1RAM_C66_RS232((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetFlowTempMin1EEPROM_C66_RS232;
            Transport.Send(_functions.SetFlowTempMin1EEPROM_C66_RS232((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        /// <summary>
        /// Устанавливает новое значение максимальной температуры подачи контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        /// <returns></returns>
        public bool SetFlowTempMax1_C66_RS232(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowTempMax1RAM_C66_RS232;
            Transport.Send(_functions.SetFlowTempMax1RAM_C66_RS232((short)value), true);
            Wait();

            if (Transport.CurrentErrorCode == Common.Types.ErrorCode.Ecl300WriteError)
                return false;

            Transport.CurrentCommand = _commands.SetFlowTempMax1EEPROM_C66_RS232;
            Transport.Send(_functions.SetFlowTempMax1EEPROM_C66_RS232((short)value), true);
            Wait();

            return Transport.CurrentErrorCode == Common.Types.ErrorCode.None;
        }

        #endregion

        #region C66 RS485
        /// <summary>
        /// Устанавливает новый час приборного времени
        /// </summary>
        /// <param name="hour"></param>
        public void SetDeviceTimeHour(int hour)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeHour;
            Transport.Send(_functions.SetDeviceTimeHour(hour), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает новую минуту приборного времени
        /// </summary>
        /// <param name="minute"></param>
        public void SetDeviceTimeMinute(int minute)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeMinute;
            Transport.Send(_functions.SetDeviceTimeMinute(minute), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает новый день приборного времени
        /// </summary>
        /// <param name="day"></param>
        public void SetDeviceTimeDay(int day)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeDay;
            Transport.Send(_functions.SetDeviceTimeDay(day), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает новый месяц приборного времени
        /// </summary>
        /// <param name="month"></param>
        public void SetDeviceTimeMonth(int month)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeMonth;
            Transport.Send(_functions.SetDeviceTimeMonth(month), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает новый год приборного времени
        /// </summary>
        /// <param name="year"></param>
        public void SetDeviceTimeYear(int year)
        {
            Transport.CurrentCommand = _commands.SetDeviceTimeYear;
            Transport.Send(_functions.SetDeviceTimeYear(year), true);
            Wait();
        }

        // РЕГУЛЯЦИОННЫЕ ПАРАМЕТРЫ
        /// <summary>
        /// Устанавливает угол наклона температурного графика, контур 1
        /// </summary>
        /// <param name="value"></param>
        public bool SetHeatCurve1_RS485(double value)
        {
            Transport.CurrentCommand = _commands.SetHeatCurve1_RS485;
            Transport.Send(_functions.SetHeatCurve1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает угол наклона температурного графика, контур 2
        /// </summary>
        /// <param name="value"></param>
        public bool SetHeatCurve2_RS485(double value)
        {
            Transport.CurrentCommand = _commands.SetHeatCurve2_RS485;
            Transport.Send(_functions.SetHeatCurve2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает параллельный сдвиг температурного графика, контур 1
        /// </summary>
        /// <param name="value"></param>
        public bool SetParallel1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetParallel1_RS485;
            Transport.Send(_functions.SetParallel1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает параллельный сдвиг температурного графика, контур 2
        /// </summary>
        /// <param name="value"></param>
        public bool SetParallel2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetParallel2_RS485;
            Transport.Send(_functions.SetParallel2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает границу отключения отопления, контур 1
        /// </summary>
        /// <param name="value"></param>
        public bool SetHsHeatingOffTemperature1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetHsHeatingOffTemperature1_RS485;
            Transport.Send(_functions.SetHsHeatingOffTemperature1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает границу отключения отопления, контур 2
        /// </summary>
        /// <param name="value"></param>
        public bool SetHsHeatingOffTemperature2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetHsHeatingOffTemperature2_RS485;
            Transport.Send(_functions.SetHsHeatingOffTemperature2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает минимальную температуру подачи, контур 1
        /// </summary>
        /// <param name="value"></param>
        public bool SetMinHsFlowTemperature1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsFlowTemperature1_RS485;
            Transport.Send(_functions.SetMinHsFlowTemperature1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает минимальную температуру подачи, контур 2
        /// </summary>
        /// <param name="value"></param>
        public bool SetMinHsFlowTemperature2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsFlowTemperature2_RS485;
            Transport.Send(_functions.SetMinHsFlowTemperature2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает максимальную температуру подачи, контур 1
        /// </summary>
        /// <param name="value"></param>
        public bool SetMaxHsFlowTemperature1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsFlowTemperature1_RS485;
            Transport.Send(_functions.SetMaxHsFlowTemperature1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает максимальную температуру подачи, контур 2
        /// </summary>
        /// <param name="value"></param>
        public bool SetMaxHsFlowTemperature2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsFlowTemperature2_RS485;
            Transport.Send(_functions.SetMaxHsFlowTemperature2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает максимальное влияние температуры воздуха в помещении, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMaxAirInfluence1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxAirInfluence1_RS485;
            Transport.Send(_functions.SetMaxAirInfluence1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает минимальное влияние температуры воздуха в помещении, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMinAirInfluence1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMinAirInfluence1_RS485;
            Transport.Send(_functions.SetMinAirInfluence1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает максимальное влияние температуры воздуха в помещении, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMaxAirInfluence2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxAirInfluence2_RS485;
            Transport.Send(_functions.SetMaxAirInfluence2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает минимальное влияние температуры воздуха в помещении, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMinAirInfluence2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMinAirInfluence2_RS485;
            Transport.Send(_functions.SetMinAirInfluence2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает зону пропорциональности, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetProportionalBand1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetProportionalBand1_RS485;
            Transport.Send(_functions.SetProportionalBand1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает зону пропорциональности, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetProportionalBand2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetProportionalBand2_RS485;
            Transport.Send(_functions.SetProportionalBand2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает постоянную интегрирования, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetIntegrationTime1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetIntegrationTime1_RS485;
            Transport.Send(_functions.SetIntegrationTime1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает постоянную интегрирования, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetIntegrationTime2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetIntegrationTime2_RS485;
            Transport.Send(_functions.SetIntegrationTime2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает время перемещения клапана с электроприводом, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetDriveStockTravelTime1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetDriveStockTravelTime1_RS485;
            Transport.Send(_functions.SetDriveStockTravelTime1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает время перемещения клапана с электроприводом, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetDriveStockTravelTime2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetDriveStockTravelTime2_RS485;
            Transport.Send(_functions.SetDriveStockTravelTime2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает нейтральную зону, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetNeutralZone1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetNeutralZone1_RS485;
            Transport.Send(_functions.SetNeutralZone1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает нейтральную зону, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetNeutralZone2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetNeutralZone2_RS485;
            Transport.Send(_functions.SetNeutralZone2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает зависимость пониженной температуры от тем-ры окр. среды, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReducedTempAddiction1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReducedTempAddiction1_RS485;
            Transport.Send(_functions.SetReducedTempAddiction1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает зависимость пониженной температуры от тем-ры окр. среды, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReducedTempAddiction2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReducedTempAddiction2_RS485;
            Transport.Send(_functions.SetReducedTempAddiction2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает натоп, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOverrun1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOverrun1_RS485;
            Transport.Send(_functions.SetOverrun1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает натоп, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOverrun2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOverrun2_RS485;
            Transport.Send(_functions.SetOverrun2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает плавный переход, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetSmoothTransition1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetSmoothTransition1_RS485;
            Transport.Send(_functions.SetSmoothTransition1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает плавный переход, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetSmoothTransition2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetSmoothTransition2_RS485;
            Transport.Send(_functions.SetSmoothTransition2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает постоянную времени оптимизации, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOptimizationTimeConstant1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationTimeConstant1_RS485;
            Transport.Send(_functions.SetOptimizationTimeConstant1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает постоянную времени оптимизации, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOptimizationTimeConstant2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationTimeConstant2_RS485;
            Transport.Send(_functions.SetOptimizationTimeConstant2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает адаптацию комнатной температуры, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAirRoomAdaptation1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetAirRoomAdaptation1_RS485;
            Transport.Send(_functions.SetAirRoomAdaptation1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает адаптацию комнатной температуры, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAirRoomAdaptation2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetAirRoomAdaptation2_RS485;
            Transport.Send(_functions.SetAirRoomAdaptation2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает влияние на задание температуры подачи, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetExternalInfluenceTemp1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetExternalInfluenceTemp1_RS485;
            Transport.Send(_functions.SetExternalInfluenceTemp1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает оптимизацию на основе комнатной тем-ры, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAirRoomOptimization1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetAirRoomOptimization1_RS485;
            Transport.Send(_functions.SetAirRoomOptimization1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает оптимизацию на основе комнатной тем-ры, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAirRoomOptimization2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetAirRoomOptimization2_RS485;
            Transport.Send(_functions.SetAirRoomOptimization2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает полное отключение, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetBlackout1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetBlackout1_RS485;
            Transport.Send(_functions.SetBlackout1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает полное отключение, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetBlackout2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetBlackout2_RS485;
            Transport.Send(_functions.SetBlackout2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает прогон насоса, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPumpTraining1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetPumpTraining1_RS485;
            Transport.Send(_functions.SetPumpTraining1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает прогон насоса, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPumpTraining2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetPumpTraining2_RS485;
            Transport.Send(_functions.SetPumpTraining2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает прогон клапана, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetFlapTraining1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetFlapTraining1_RS485;
            Transport.Send(_functions.SetFlapTraining1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает прогон клапана, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetFlapTraining2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetFlapTraining2_RS485;
            Transport.Send(_functions.SetFlapTraining2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает тип привода, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetDriveType1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetDriveType1_RS485;
            Transport.Send(_functions.SetDriveType1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает тип привода, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetDriveType2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetDriveType2_RS485;
            Transport.Send(_functions.SetDriveType2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает макс. наружную температуру X1, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOpenAirTemp_X1_1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOpenAirTemp_X1_1_RS485;
            Transport.Send(_functions.SetOpenAirTemp_X1_1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает макс. наружную температуру X1, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOpenAirTemp_X1_2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOpenAirTemp_X1_2_RS485;
            Transport.Send(_functions.SetOpenAirTemp_X1_2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает температуру возвращаемого теплоносителя Y1, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReturnTemp_Y1_1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReturnTemp_Y1_1_RS485;
            Transport.Send(_functions.SetReturnTemp_Y1_1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает температуру возвращаемого теплоносителя Y1, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReturnTemp_Y1_2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReturnTemp_Y1_2_RS485;
            Transport.Send(_functions.SetReturnTemp_Y1_2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает макс. наружную температуру X2, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOpenAirTemp_X2_1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOpenAirTemp_X2_1_RS485;
            Transport.Send(_functions.SetOpenAirTemp_X2_1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает макс. наружную температуру X2, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetOpenAirTemp_X2_2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetOpenAirTemp_X2_2_RS485;
            Transport.Send(_functions.SetOpenAirTemp_X2_2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает температуру возвращаемого теплоносителя Y2, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReturnTemp_Y2_1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReturnTemp_Y2_1_RS485;
            Transport.Send(_functions.SetReturnTemp_Y2_1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает температуру возвращаемого теплоносителя Y2, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReturnTemp_Y2_2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReturnTemp_Y2_2_RS485;
            Transport.Send(_functions.SetReturnTemp_Y2_2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает максимальное влияние обратки, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMaxInfluenceReverse1_RS485(double value)
        {
            Transport.CurrentCommand = _commands.SetMaxInfluenceReverse1_RS485;
            Transport.Send(_functions.SetMaxInfluenceReverse1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает максимальное влияние обратки, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMaxInfluenceReverse2_RS485(double value)
        {
            Transport.CurrentCommand = _commands.SetMaxInfluenceReverse2_RS485;
            Transport.Send(_functions.SetMaxInfluenceReverse2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает минимальное влияние обратки, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMinInfluenceReverse1_RS485(double value)
        {
            Transport.CurrentCommand = _commands.SetMinInfluenceReverse1_RS485;
            Transport.Send(_functions.SetMinInfluenceReverse1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает минимальное влияние обратки, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMinInfluenceReverse2_RS485(double value)
        {
            Transport.CurrentCommand = _commands.SetMinInfluenceReverse2_RS485;
            Transport.Send(_functions.SetMinInfluenceReverse2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает оптимизацию температуры обратки по подаче, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReturnOptimizationViaSupply1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReturnOptimizationViaSupply1_RS485;
            Transport.Send(_functions.SetReturnOptimizationViaSupply1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает оптимизацию температуры обратки по подаче, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetReturnOptimizationViaSupply2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetReturnOptimizationViaSupply2_RS485;
            Transport.Send(_functions.SetReturnOptimizationViaSupply2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает параллельную работу ГВС и контуров отопления, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetParallelWorkHwsAndHeatSys1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetParallelWorkHwsAndHeatSys1_RS485;
            Transport.Send(_functions.SetParallelWorkHwsAndHeatSys1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает ПИ-регулирование, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPIRegulation1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetPIRegulation1_RS485;
            Transport.Send(_functions.SetPIRegulation1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает ПИ-регулирование, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetPIRegulation2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetPIRegulation2_RS485;
            Transport.Send(_functions.SetPIRegulation2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает защиту двигателя, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMotorProtection1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMotorProtection1_RS485;
            Transport.Send(_functions.SetMotorProtection1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает защиту двигателя, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetMotorProtection2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetMotorProtection2_RS485;
            Transport.Send(_functions.SetMotorProtection2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает автоматическую смену сезонного времени, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetChangeSeason1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetChangeSeason1_RS485;
            Transport.Send(_functions.SetChangeSeason1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую комнатную температуру (комфорт), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetRoomTempDaySet1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetRoomTempDaySet1_RS485;
            Transport.Send(_functions.SetRoomTempDaySet1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую комнатную температуру (комфорт), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetRoomTempDaySet2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetRoomTempDaySet2_RS485;
            Transport.Send(_functions.SetRoomTempDaySet2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую комнатную температуру (эконом), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetRoomTempNightSet1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetRoomTempNightSet1_RS485;
            Transport.Send(_functions.SetRoomTempNightSet1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую комнатную температуру (эконом), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetRoomTempNightSet2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetRoomTempNightSet2_RS485;
            Transport.Send(_functions.SetRoomTempNightSet2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую температуру горячей воды (комфорт), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetHotWaterTempDaySet1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetHotWaterTempDaySet1_RS485;
            Transport.Send(_functions.SetHotWaterTempDaySet1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую температуру горячей воды (комфорт), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetHotWaterTempDaySet2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetHotWaterTempDaySet2_RS485;
            Transport.Send(_functions.SetHotWaterTempDaySet2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую температуру горячей воды (эконом), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetHotWaterTempNightSet1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetHotWaterTempNightSet1_RS485;
            Transport.Send(_functions.SetHotWaterTempNightSet1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает желаемую температуру горячей воды (эконом), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetHotWaterTempNightSet2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetHotWaterTempNightSet2_RS485;
            Transport.Send(_functions.SetHotWaterTempNightSet2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает ограничение температуры возвращаемого теплоносителя, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetLimitReverseTemperature1_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetLimitReverseTemperature1_RS485;
            Transport.Send(_functions.SetLimitReverseTemperature1_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает ограничение температуры возвращаемого теплоносителя, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetLimitReverseTemperature2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetLimitReverseTemperature2_RS485;
            Transport.Send(_functions.SetLimitReverseTemperature2_RS485(value), true);
            return Wait();
        }

        /// <summary>
        /// Устанавливает флаг автоматической настройки, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetAutotuning2_RS485(int value)
        {
            Transport.CurrentCommand = _commands.SetAutotuning2_RS485;
            Transport.Send(_functions.SetAutotuning2_RS485(value), true);
            return Wait();
        }
        #endregion
    }
}

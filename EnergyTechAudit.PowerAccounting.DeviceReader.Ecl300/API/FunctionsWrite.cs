using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API
{
    internal sealed partial class Functions 
    {
        /// <summary>
        /// Возвращает пакет байтов для записи нового значения угла наклона
        /// температурного графика контура 1 в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetHeatCurve1RAM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetHeatCurve1RAM, new byte[] { valueByte, valueByte });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения угла наклона
        /// температурного графика контура 1 в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>

        public byte[] SetHeatCurve1EEPROM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetHeatCurve1EEPROM, new byte[] { valueByte, valueByte });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой комнатной температуры (комфорт) в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetRoomTempDaySetRAM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetRoomTempDaySetRAM, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой комнатной температуры (комфорт) в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetRoomTempDaySetEEPROM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetRoomTempDaySetEEPROM, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой комнатной температуры (эконом) в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetRoomTempNightSetRAM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetRoomTempNightSetRAM, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой комнатной температуры (эконом) в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetRoomTempNightSetEEPROM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetRoomTempNightSetEEPROM, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// температуры отключения отопления в контуре 1 в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetSummerCutout1RAM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetSummerCutout1RAM, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// температуры отключения отопления в контуре 1 в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetSummerCutout1EEPROM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetSummerCutout1EEPROM, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// температуры отключения отопления в контуре 2 в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetSummerCutout2RAM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetSummerCutout2RAM, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// температуры отключения отопления в контуре 2 в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetSummerCutout2EEPROM(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetSummerCutout2EEPROM, new byte[] { valueByte, 0x00 });
        }

        #region C66 RS232
        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой температуры горячей воды (комфорт) в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetHotWaterTempDaySetRAM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetHotWaterTempDaySetRAM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой температуры горячей воды (комфорт) в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetHotWaterTempDaySetEEPROM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetHotWaterTempDaySetEEPROM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой температуры горячей воды (эконом) в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetHotWaterTempNightSetRAM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetHotWaterTempNightSetRAM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// желаемой температуры горячей воды (эконом) в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetHotWaterTempNightSetEEPROM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetHotWaterTempNightSetEEPROM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// параллельного переноса графика контура 1 в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetParallel1RAM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetParallel1RAM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// параллельного переноса графика контура 1 в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetParallel1EEPROM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetParallel1EEPROM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// минимальной температуры подачи контура 1 в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetFlowTempMin1RAM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetFlowTempMin1RAM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// минимальной температуры подачи контура 1 в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetFlowTempMin1EEPROM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetFlowTempMin1EEPROM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// максимальной температуры подачи контура 1 в RAM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetFlowTempMax1RAM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetFlowTempMax1RAM_C66_RS232, new byte[] { valueByte, 0x00 });
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового значения
        /// максимальной температуры подачи контура 1 в EEPROM
        /// </summary>
        /// <param name="newValue">Новое значение</param>
        public byte[] SetFlowTempMax1EEPROM_C66_RS232(short newValue)
        {
            var valueByte = BitConverter.GetBytes(newValue)[0];
            return _packageHelper.GetCommand(_commands.SetFlowTempMax1EEPROM_C66_RS232, new byte[] { valueByte, 0x00 });
        }
        #endregion

        #region C66 RS485
        /// <summary>
        /// Возвращает пакет байтов для записи нового часа приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeHour(int hour)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeHour, ActionHelper.SetIntValue(hour));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи новой минуты приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeMinute(int minute)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeMinute, ActionHelper.SetIntValue(minute));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового дня приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeDay(int day)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeDay, ActionHelper.SetIntValue(day));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового месяца приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeMonth(int month)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeMonth, ActionHelper.SetIntValue(month));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нового года приборного времени
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public byte[] SetDeviceTimeYear(int year)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDeviceTimeYear, ActionHelper.SetIntValue(year));
        }

        // РЕГУЛЯЦИОННЫЕ ПАРАМЕТРЫ
        /// <summary>
        /// Возвращает пакет байтов для записи угла наклона температурного графика, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHeatCurve1_RS485(double value)
        {
            int newValue = (short)(value * 10);
            return _modbusPackageHelper.WriteCommand(_commands.SetHeatCurve1_RS485, ActionHelper.SetIntValue(newValue));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи угла наклона температурного графика, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHeatCurve2_RS485(double value)
        {
            int newValue = (short)(value * 10);
            return _modbusPackageHelper.WriteCommand(_commands.SetHeatCurve2_RS485, ActionHelper.SetIntValue(newValue));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи параллельного сдвига температурного графика, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetParallel1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetParallel1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи параллельного сдвига температурного графика, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetParallel2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetParallel2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи границы отключения отопления, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHsHeatingOffTemperature1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetHsHeatingOffTemperature1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи границы отключения отопления, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHsHeatingOffTemperature2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetHsHeatingOffTemperature2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимальной температуры подачи, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMinHsFlowTemperature1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMinHsFlowTemperature1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимальной температуры подачи, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMinHsFlowTemperature2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMinHsFlowTemperature2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимальной температуры подачи, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMaxHsFlowTemperature1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMaxHsFlowTemperature1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимальной температуры подачи, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMaxHsFlowTemperature2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMaxHsFlowTemperature2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимального влияния температуры воздуха в помещении, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMaxAirInfluence1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMaxAirInfluence1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимального влияния температуры воздуха в помещении, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMinAirInfluence1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMinAirInfluence1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимального влияния температуры воздуха в помещении, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMaxAirInfluence2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMaxAirInfluence2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимального влияния температуры воздуха в помещении, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMinAirInfluence2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMinAirInfluence2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи зоны пропорциональности, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetProportionalBand1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetProportionalBand1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи зоны пропорциональности, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetProportionalBand2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetProportionalBand2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи постоянной интегрирования, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetIntegrationTime1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetIntegrationTime1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи постоянной интегрирования, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetIntegrationTime2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetIntegrationTime2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени перемещения клапана с электроприводом, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetDriveStockTravelTime1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDriveStockTravelTime1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени перемещения клапана с электроприводом, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetDriveStockTravelTime2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDriveStockTravelTime2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нейтральной зоны, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetNeutralZone1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetNeutralZone1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нейтральной зоны, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetNeutralZone2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetNeutralZone2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи зависимости пониженной температуры от тем-ры окр. среды, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReducedTempAddiction1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReducedTempAddiction1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи зависимости пониженной температуры от тем-ры окр. среды, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReducedTempAddiction2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReducedTempAddiction2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи натопа, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOverrun1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOverrun1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи натопа, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOverrun2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOverrun2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи плавного перехода, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetSmoothTransition1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetSmoothTransition1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи плавного перехода, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetSmoothTransition2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetSmoothTransition2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи постоянной времени оптимизации, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOptimizationTimeConstant1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOptimizationTimeConstant1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи постоянной времени оптимизации, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOptimizationTimeConstant2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOptimizationTimeConstant2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи адаптации комнатной температуры, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetAirRoomAdaptation1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetAirRoomAdaptation1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи адаптации комнатной температуры, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetAirRoomAdaptation2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetAirRoomAdaptation2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи влияния на задание температуры подачи, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetExternalInfluenceTemp1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetExternalInfluenceTemp1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи оптимизации на основе комнатной тем-ры, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetAirRoomOptimization1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetAirRoomOptimization1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи оптимизации на основе комнатной тем-ры, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetAirRoomOptimization2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetAirRoomOptimization2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи полного отключения, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetBlackout1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetBlackout1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи полного отключения, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetBlackout2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetBlackout2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи прогона насоса, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPumpTraining1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetPumpTraining1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи прогона насоса, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPumpTraining2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetPumpTraining2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи прогона клапана, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetFlapTraining1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetFlapTraining1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи прогона клапана, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetFlapTraining2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetFlapTraining2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи типа привода, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetDriveType1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDriveType1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи типа привода, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetDriveType2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetDriveType2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. наружной температуры X1, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOpenAirTemp_X1_1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOpenAirTemp_X1_1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. наружной температуры X1, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOpenAirTemp_X1_2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOpenAirTemp_X1_2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры возвращаемого теплоносителя Y1, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReturnTemp_Y1_1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReturnTemp_Y1_1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры возвращаемого теплоносителя Y1, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReturnTemp_Y1_2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReturnTemp_Y1_2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. наружной температуры X2, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOpenAirTemp_X2_1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOpenAirTemp_X2_1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. наружной температуры X2, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetOpenAirTemp_X2_2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetOpenAirTemp_X2_2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры возвращаемого теплоносителя Y2, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReturnTemp_Y2_1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReturnTemp_Y2_1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры возвращаемого теплоносителя Y2, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReturnTemp_Y2_2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReturnTemp_Y2_2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимального влияния обратки, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMaxInfluenceReverse1_RS485(double value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMaxInfluenceReverse1_RS485, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимального влияния обратки, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMaxInfluenceReverse2_RS485(double value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMaxInfluenceReverse2_RS485, ActionHelper.SetEcl310DoubleValue(value));
        }        

        /// <summary>
        /// Возвращает пакет байтов для записи минимального влияния обратки, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMinInfluenceReverse1_RS485(double value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMinInfluenceReverse1_RS485, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимального влияния обратки, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMinInfluenceReverse2_RS485(double value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMinInfluenceReverse2_RS485, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи оптимизации температуры обратки по подаче, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReturnOptimizationViaSupply1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReturnOptimizationViaSupply1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи оптимизации температуры обратки по подаче, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetReturnOptimizationViaSupply2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetReturnOptimizationViaSupply2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи параллельной работы ГВС и контуров отопления, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetParallelWorkHwsAndHeatSys1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetParallelWorkHwsAndHeatSys1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ПИ-регулирования, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPIRegulation1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetPIRegulation1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ПИ-регулирования, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPIRegulation2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetPIRegulation2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи защиты двигателя, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMotorProtection1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMotorProtection1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи защиты двигателя, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetMotorProtection2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetMotorProtection2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи автоматической смены сезонного времени, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetChangeSeason1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetChangeSeason1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой комнатной температуры (комфорт), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetRoomTempDaySet1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetRoomTempDaySet1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой комнатной температуры (комфорт), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetRoomTempDaySet2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetRoomTempDaySet2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой комнатной температуры (эконом), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetRoomTempNightSet1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetRoomTempNightSet1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой комнатной температуры (эконом), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetRoomTempNightSet2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetRoomTempNightSet2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой температуры горячей воды (комфорт), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHotWaterTempDaySet1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetHotWaterTempDaySet1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой температуры горячей воды (комфорт), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHotWaterTempDaySet2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetHotWaterTempDaySet2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой температуры горячей воды (эконом), контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHotWaterTempNightSet1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetHotWaterTempNightSet1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой температуры горячей воды (эконом), контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetHotWaterTempNightSet2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetHotWaterTempNightSet2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ограничения температуры возвращаемого теплоносителя, контур 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetLimitReverseTemperature1_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetLimitReverseTemperature1_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ограничения температуры возвращаемого теплоносителя, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetLimitReverseTemperature2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetLimitReverseTemperature2_RS485, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага автоматической настройки, контур 2
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetAutotuning2_RS485(int value)
        {
            return _modbusPackageHelper.WriteCommand(_commands.SetAutotuning2_RS485, ActionHelper.SetIntValue(value));
        }
        #endregion
    }
}

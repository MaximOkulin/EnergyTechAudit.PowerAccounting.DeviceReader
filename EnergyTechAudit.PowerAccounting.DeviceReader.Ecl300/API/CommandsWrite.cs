using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API
{
    internal sealed partial class Commands 
    {
        /// <summary>
        /// Запись угла наклона графика контура 1 в RAM (DE-C9)
        /// </summary>
        public Command SetHeatCurve1RAM = new Command { CommandName = "SetHeatCurve1RAM", ErrorMessage = Ecl300ErrorMessages.SetHeatCurve1RAM, CommandType = CommandType.Write, Code = 51678, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись угла наклона графика контура 1 в EEPROM (90-5D)
        /// </summary>
        public Command SetHeatCurve1EEPROM = new Command { CommandName = "SetHeatCurve1EEPROM", ErrorMessage = Ecl300ErrorMessages.SetHeatCurve1EEPROM, CommandType = CommandType.Write, Code = 23952, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };


        /// <summary>
        /// Запись желаемой комнатной температуры (комфорт) в RAM (FE-9E)
        /// </summary>
        public Command SetRoomTempDaySetRAM = new Command { CommandName = "SetRoomTempDaySetRAM", ErrorMessage = Ecl300ErrorMessages.SetRoomTempDaySetRAM, CommandType = CommandType.Write, Code = 40702, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись желаемой комнатной температуры (комфорт) в EEPROM (B0-48)
        /// </summary>
        public Command SetRoomTempDaySetEEPROM = new Command { CommandName = "SetRoomTempDaySetEEPROM", ErrorMessage = Ecl300ErrorMessages.SetRoomTempDaySetEEPROM, CommandType = CommandType.Write, Code = 18608, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись желаемой комнатной температуры (эконом) в RAM (FE-A0)
        /// </summary>
        public Command SetRoomTempNightSetRAM = new Command { CommandName = "SetRoomTempNightSetRAM", ErrorMessage = Ecl300ErrorMessages.SetRoomTempNightSetRAM, CommandType = CommandType.Write, Code = 41214, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись желаемой комнатной температуры (эконом) в EEPROM (B0-49)
        /// </summary>
        public Command SetRoomTempNightSetEEPROM = new Command { CommandName = "SetRoomTempNightSetEEPROM", ErrorMessage = Ecl300ErrorMessages.SetRoomTempNightSetEEPROM, CommandType = CommandType.Write, Code = 18864, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        /// <summary>
        /// Запись температуры отключения отопления в контуре 1 в RAM (FE-C2)
        /// </summary>
        public Command SetSummerCutout1RAM = new Command { CommandName = "SetSummerCutout1RAM", ErrorMessage = Ecl300ErrorMessages.SetSummerCutout1RAM, CommandType = CommandType.Write, Code = 49918, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись температуры отключения отопления в контуре 1 в EEPROM (B0-5A)
        /// </summary>
        public Command SetSummerCutout1EEPROM = new Command { CommandName = "SetSummerCutout1EEPROM", ErrorMessage = Ecl300ErrorMessages.SetSummerCutout1EEPROM, CommandType = CommandType.Write, Code = 23216, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        /// <summary>
        /// Запись температуры отключения отопления в контуре 2 в RAM (FE-C3)
        /// </summary>
        public Command SetSummerCutout2RAM = new Command { CommandName = "SetSummerCutout2RAM", ErrorMessage = Ecl300ErrorMessages.SetSummerCutout2RAM, CommandType = CommandType.Write, Code = 50174, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись температуры отключения отопления в контуре 2 в EEPROM (A0-5A)
        /// </summary>
        public Command SetSummerCutout2EEPROM = new Command { CommandName = "SetSummerCutout2EEPROM", ErrorMessage = Ecl300ErrorMessages.SetSummerCutout2EEPROM, CommandType = CommandType.Write, Code = 23200, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        #region C66 RS232
        /// <summary>
        /// Запись желаемой температуры горячей воды (комфорт) в RAM (FE-D0)
        /// </summary>
        public Command SetHotWaterTempDaySetRAM_C66_RS232 = new Command { CommandName = "SetHotWaterTempDaySetRAM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempDaySetRAM, CommandType = CommandType.Write, Code = 53502, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись желаемой температуры горячей воды (комфорт) в EEPROM (B0-61)
        /// </summary>
        public Command SetHotWaterTempDaySetEEPROM_C66_RS232 = new Command { CommandName = "SetHotWaterTempDaySetEEPROM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempDaySetEEPROM, CommandType = CommandType.Write, Code = 25008, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        /// <summary>
        /// Запись желаемой температуры горячей воды (эконом) в RAM (FE-D1)
        /// </summary>
        public Command SetHotWaterTempNightSetRAM_C66_RS232 = new Command { CommandName = "SetHotWaterTempNightSetRAM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempNightSetRAM, CommandType = CommandType.Write, Code = 53758, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись желаемой температуры горячей воды (эконом) в EEPROM (A0-61)
        /// </summary>
        public Command SetHotWaterTempNightSetEEPROM_C66_RS232 = new Command { CommandName = "SetHotWaterTempDaySetEEPROM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempDaySetEEPROM, CommandType = CommandType.Write, Code = 24992, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        /// <summary>
        /// Запись параллельного переноса графика контура 1 в RAM (FE-A8)
        /// </summary>
        public Command SetParallel1RAM_C66_RS232 = new Command { CommandName = "SetParallel1RAM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetParallel1RAM, CommandType = CommandType.Write, Code = 43262, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Запись параллельного переноса графика контура 1 в EEPROM (B0-4D)
        /// </summary>
        public Command SetParallel1EEPROM_C66_RS232 = new Command { CommandName = "SetParallel1EEPROM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetParallel1EEPROM, CommandType = CommandType.Write, Code = 19888, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        
        /// <summary>
        /// Запись минимальной температуры подачи контура 1 в RAM (FE-CB)
        /// </summary>
        public Command SetFlowTempMin1RAM_C66_RS232 = new Command { CommandName = "SetFlowTempMin1RAM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetFlowTempMin1RAM, CommandType = CommandType.Write, Code = 52222, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        /// <summary>
        /// Запись минимальной температуры подачи контура 1 в EEPROM (A0-5E)
        /// </summary>
        public Command SetFlowTempMin1EEPROM_C66_RS232 = new Command { CommandName = "SetFlowTempMin1EEPROM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetFlowTempMin1EEPROM, CommandType = CommandType.Write, Code = 24224, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };


        /// <summary>
        /// Запись максимальной температуры подачи контура 1 в RAM (FE-CC)
        /// </summary>
        public Command SetFlowTempMax1RAM_C66_RS232 = new Command { CommandName = "SetFlowTempMax1RAM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetFlowTempMax1RAM, CommandType = CommandType.Write, Code = 52478, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        /// <summary>
        /// Запись максимальной температуры подачи контура 1 в EEPROM (B0-5F)
        /// </summary>
        public Command SetFlowTempMax1EEPROM_C66_RS232 = new Command { CommandName = "SetFlowTempMax1EEPROM_C66_RS232", ErrorMessage = Ecl300ErrorMessages.SetFlowTempMax1EEPROM, CommandType = CommandType.Write, Code = 24496, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        #endregion

        #region C66 RS485
        /// <summary>
        /// Запись часовой компоненты времени прибора
        /// </summary>
        public Command SetDeviceTimeHour = new Command { CommandName = Ecl300Resources.SetDeviceTimeHour, ErrorMessage = Ecl300ErrorMessages.SetDeviceTimeHour, CommandType = CommandType.Write, Code = 64044, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись минутной компоненты времени прибора
        /// </summary>
        public Command SetDeviceTimeMinute = new Command { CommandName = Ecl300Resources.SetDeviceTimeMinute, ErrorMessage = Ecl300ErrorMessages.SetDeviceTimeMinute, CommandType = CommandType.Write, Code = 64045, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись суточной компоненты времени прибора
        /// </summary>
        public Command SetDeviceTimeDay = new Command { CommandName = Ecl300Resources.SetDeviceTimeDay, ErrorMessage = Ecl300ErrorMessages.SetDeviceTimeDay, CommandType = CommandType.Write, Code = 64046, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись месячной компоненты времени прибора
        /// </summary>
        public Command SetDeviceTimeMonth = new Command { CommandName = Ecl300Resources.SetDeviceTimeMonth, ErrorMessage = Ecl300ErrorMessages.SetDeviceTimeMonth, CommandType = CommandType.Write, Code = 64047, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись годовой компоненты времени прибора
        /// </summary>
        public Command SetDeviceTimeYear = new Command { CommandName = Ecl300Resources.SetDeviceTimeYear, ErrorMessage = Ecl300ErrorMessages.SetDeviceTimeYear, CommandType = CommandType.Write, Code = 64048, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        // РЕГУЛЯЦИОННЫЕ ПАРАМЕТРЫ
        /// <summary>
        /// Запись угла наклона температурного графика, контур 1
        /// </summary>
        public Command SetHeatCurve1_RS485 = new Command { CommandName = Ecl300Resources.SetHeatCurve1_RS485, ErrorMessage = Ecl300ErrorMessages.SetHeatCurve1_RS485, CommandType = CommandType.Write, Code = 11174, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись угла наклона температурного графика, контур 2
        /// </summary>
        public Command SetHeatCurve2_RS485 = new Command { CommandName = Ecl300Resources.SetHeatCurve2_RS485, ErrorMessage = Ecl300ErrorMessages.SetHeatCurve2_RS485, CommandType = CommandType.Write, Code = 12174, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись параллельного сдвига температурного графика, контур 1
        /// </summary>
        public Command SetParallel1_RS485 = new Command { CommandName = Ecl300Resources.SetParallel1_RS485, ErrorMessage = Ecl300ErrorMessages.SetParallel1_RS485, CommandType = CommandType.Write, Code = 11175, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись параллельного сдвига температурного графика, контур 2
        /// </summary>
        public Command SetParallel2_RS485 = new Command { CommandName = Ecl300Resources.SetParallel2_RS485, ErrorMessage = Ecl300ErrorMessages.SetParallel2_RS485, CommandType = CommandType.Write, Code = 12175, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись границы отключения отопления, контур 1
        /// </summary>
        public Command SetHsHeatingOffTemperature1_RS485 = new Command { CommandName = Ecl300Resources.SetHsHeatingOffTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.SetHsHeatingOffTemperature1_RS485, CommandType = CommandType.Write, Code = 11178, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись границы отключения отопления, контур 2
        /// </summary>
        public Command SetHsHeatingOffTemperature2_RS485 = new Command { CommandName = Ecl300Resources.SetHsHeatingOffTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.SetHsHeatingOffTemperature2_RS485, CommandType = CommandType.Write, Code = 12178, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись минимальной температуры подачи, контур 1
        /// </summary>
        public Command SetMinHsFlowTemperature1_RS485 = new Command { CommandName = Ecl300Resources.SetMinHsFlowTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.SetMinHsFlowTemperature1_RS485, CommandType = CommandType.Write, Code = 11176, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись минимальной температуры подачи, контур 2
        /// </summary>
        public Command SetMinHsFlowTemperature2_RS485 = new Command { CommandName = Ecl300Resources.SetMinHsFlowTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.SetMinHsFlowTemperature2_RS485, CommandType = CommandType.Write, Code = 12176, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись максимальной температуры подачи, контур 1
        /// </summary>
        public Command SetMaxHsFlowTemperature1_RS485 = new Command { CommandName = Ecl300Resources.SetMaxHsFlowTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.SetMaxHsFlowTemperature1_RS485, CommandType = CommandType.Write, Code = 11177, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись максимальной температуры подачи, контур 2
        /// </summary>
        public Command SetMaxHsFlowTemperature2_RS485 = new Command { CommandName = Ecl300Resources.SetMaxHsFlowTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.SetMaxHsFlowTemperature2_RS485, CommandType = CommandType.Write, Code = 12177, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        
        /// <summary>
        /// Запись максимального влияния температуры воздуха в помещении, контур 1
        /// </summary>
        public Command SetMaxAirInfluence1_RS485 = new Command { CommandName = Ecl300Resources.SetMaxAirInfluence1_RS485, ErrorMessage = Ecl300ErrorMessages.SetMaxAirInfluence1_RS485, CommandType = CommandType.Write, Code = 11181, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись минимального влияния температуры воздуха в помещении, контур 1
        /// </summary>
        public Command SetMinAirInfluence1_RS485 = new Command { CommandName = Ecl300Resources.SetMinAirInfluence1_RS485, ErrorMessage = Ecl300ErrorMessages.SetMinAirInfluence1_RS485, CommandType = CommandType.Write, Code = 11182, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись максимального влияния температуры воздуха в помещении, контур 2
        /// </summary>
        public Command SetMaxAirInfluence2_RS485 = new Command { CommandName = Ecl300Resources.SetMaxAirInfluence2_RS485, ErrorMessage = Ecl300ErrorMessages.SetMaxAirInfluence2_RS485, CommandType = CommandType.Write, Code = 12181, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись минимального влияния температуры воздуха в помещении, контур 2
        /// </summary>
        public Command SetMinAirInfluence2_RS485 = new Command { CommandName = Ecl300Resources.SetMinAirInfluence2_RS485, ErrorMessage = Ecl300ErrorMessages.SetMinAirInfluence2_RS485, CommandType = CommandType.Write, Code = 12182, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись зоны пропорциональности, контур 1
        /// </summary>
        public Command SetProportionalBand1_RS485 = new Command { CommandName = Ecl300Resources.SetProportionalBand1_RS485, ErrorMessage = Ecl300ErrorMessages.SetProportionalBand1_RS485, CommandType = CommandType.Write, Code = 11183, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись зоны пропорциональности, контур 2
        /// </summary>
        public Command SetProportionalBand2_RS485 = new Command { CommandName = Ecl300Resources.SetProportionalBand2_RS485, ErrorMessage = Ecl300ErrorMessages.SetProportionalBand2_RS485, CommandType = CommandType.Write, Code = 12183, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись постоянной интегрирования, контур 1
        /// </summary>
        public Command SetIntegrationTime1_RS485 = new Command { CommandName = Ecl300Resources.SetIntegrationTime1_RS485, ErrorMessage = Ecl300ErrorMessages.SetIntegrationTime1_RS485, CommandType = CommandType.Write, Code = 11184, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись постоянной интегрирования, контур 2
        /// </summary>
        public Command SetIntegrationTime2_RS485 = new Command { CommandName = Ecl300Resources.SetIntegrationTime2_RS485, ErrorMessage = Ecl300ErrorMessages.SetIntegrationTime2_RS485, CommandType = CommandType.Write, Code = 12184, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись времени перемещения клапана с электроприводом, контур 1
        /// </summary>
        public Command SetDriveStockTravelTime1_RS485 = new Command { CommandName = Ecl300Resources.SetDriveStockTravelTime1_RS485, ErrorMessage = Ecl300ErrorMessages.SetDriveStockTravelTime1_RS485, CommandType = CommandType.Write, Code = 11185, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись времени перемещения клапана с электроприводом, контур 2
        /// </summary>
        public Command SetDriveStockTravelTime2_RS485 = new Command { CommandName = Ecl300Resources.SetDriveStockTravelTime2_RS485, ErrorMessage = Ecl300ErrorMessages.SetDriveStockTravelTime2_RS485, CommandType = CommandType.Write, Code = 12185, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись нейтральной зоны, контур 1
        /// </summary>
        public Command SetNeutralZone1_RS485 = new Command { CommandName = Ecl300Resources.SetNeutralZone1_RS485, ErrorMessage = Ecl300ErrorMessages.SetNeutralZone1_RS485, CommandType = CommandType.Write, Code = 11186, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись нейтральной зоны, контур 2
        /// </summary>
        public Command SetNeutralZone2_RS485 = new Command { CommandName = Ecl300Resources.SetNeutralZone2_RS485, ErrorMessage = Ecl300ErrorMessages.SetNeutralZone2_RS485, CommandType = CommandType.Write, Code = 12186, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись зависимости пониженной температуры от тем-ры окр. среды, контур 1
        /// </summary>
        public Command SetReducedTempAddiction1_RS485 = new Command { CommandName = Ecl300Resources.SetReducedTempAddiction1_RS485, ErrorMessage = Ecl300ErrorMessages.SetReducedTempAddiction1_RS485, CommandType = CommandType.Write, Code = 11010, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись зависимости пониженной температуры от тем-ры окр. среды, контур 2
        /// </summary>
        public Command SetReducedTempAddiction2_RS485 = new Command { CommandName = Ecl300Resources.SetReducedTempAddiction2_RS485, ErrorMessage = Ecl300ErrorMessages.SetReducedTempAddiction2_RS485, CommandType = CommandType.Write, Code = 12010, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись натопа, контур 1
        /// </summary>
        public Command SetOverrun1_RS485 = new Command { CommandName = Ecl300Resources.SetOverrun1_RS485, ErrorMessage = Ecl300ErrorMessages.SetOverrun1_RS485, CommandType = CommandType.Write, Code = 11011, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись натопа, контур 2
        /// </summary>
        public Command SetOverrun2_RS485 = new Command { CommandName = Ecl300Resources.SetOverrun2_RS485, ErrorMessage = Ecl300ErrorMessages.SetOverrun2_RS485, CommandType = CommandType.Write, Code = 12011, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись плавного перехода, контур 1
        /// </summary>
        public Command SetSmoothTransition1_RS485 = new Command { CommandName = Ecl300Resources.SetSmoothTransition1_RS485, ErrorMessage = Ecl300ErrorMessages.SetSmoothTransition1_RS485, CommandType = CommandType.Write, Code = 11012, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись плавного перехода, контур 2
        /// </summary>
        public Command SetSmoothTransition2_RS485 = new Command { CommandName = Ecl300Resources.SetSmoothTransition2_RS485, ErrorMessage = Ecl300ErrorMessages.SetSmoothTransition2_RS485, CommandType = CommandType.Write, Code = 12012, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись постоянной времени оптимизации, контур 1
        /// </summary>
        public Command SetOptimizationTimeConstant1_RS485 = new Command { CommandName = Ecl300Resources.SetOptimizationTimeConstant1_RS485, ErrorMessage = Ecl300ErrorMessages.SetOptimizationTimeConstant1_RS485, CommandType = CommandType.Write, Code = 11013, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись постоянной времени оптимизации, контур 2
        /// </summary>
        public Command SetOptimizationTimeConstant2_RS485 = new Command { CommandName = Ecl300Resources.SetOptimizationTimeConstant2_RS485, ErrorMessage = Ecl300ErrorMessages.SetOptimizationTimeConstant2_RS485, CommandType = CommandType.Write, Code = 12013, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись адаптации комнатной температуры, контур 1
        /// </summary>
        public Command SetAirRoomAdaptation1_RS485 = new Command { CommandName = Ecl300Resources.SetAirRoomAdaptation1_RS485, ErrorMessage = Ecl300ErrorMessages.SetAirRoomAdaptation1_RS485, CommandType = CommandType.Write, Code = 11014, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись адаптации комнатной температуры, контур 2
        /// </summary>
        public Command SetAirRoomAdaptation2_RS485 = new Command { CommandName = Ecl300Resources.SetAirRoomAdaptation2_RS485, ErrorMessage = Ecl300ErrorMessages.SetAirRoomAdaptation2_RS485, CommandType = CommandType.Write, Code = 12014, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись влияния на задание температуры подачи, контур 1
        /// </summary>
        public Command SetExternalInfluenceTemp1_RS485 = new Command { CommandName = Ecl300Resources.SetExternalInfluenceTemp1_RS485, ErrorMessage = Ecl300ErrorMessages.SetExternalInfluenceTemp1_RS485, CommandType = CommandType.Write, Code = 11016, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись оптимизации на основе комнатной тем-ры, контур 1
        /// </summary>
        public Command SetAirRoomOptimization1_RS485 = new Command { CommandName = Ecl300Resources.SetAirRoomOptimization1_RS485, ErrorMessage = Ecl300ErrorMessages.SetAirRoomOptimization1_RS485, CommandType = CommandType.Write, Code = 11019, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись оптимизации на основе комнатной тем-ры, контур 2
        /// </summary>
        public Command SetAirRoomOptimization2_RS485 = new Command { CommandName = Ecl300Resources.SetAirRoomOptimization2_RS485, ErrorMessage = Ecl300ErrorMessages.SetAirRoomOptimization2_RS485, CommandType = CommandType.Write, Code = 12019, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись полного отключения, контур 1
        /// </summary>
        public Command SetBlackout1_RS485 = new Command { CommandName = Ecl300Resources.SetBlackout1_RS485, ErrorMessage = Ecl300ErrorMessages.SetBlackout1_RS485, CommandType = CommandType.Write, Code = 11020, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись полного отключения, контур 2
        /// </summary>
        public Command SetBlackout2_RS485 = new Command { CommandName = Ecl300Resources.SetBlackout2_RS485, ErrorMessage = Ecl300ErrorMessages.SetBlackout2_RS485, CommandType = CommandType.Write, Code = 12020, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись прогона насоса, контур 1
        /// </summary>
        public Command SetPumpTraining1_RS485 = new Command { CommandName = Ecl300Resources.SetPumpTraining1_RS485, ErrorMessage = Ecl300ErrorMessages.SetPumpTraining1_RS485, CommandType = CommandType.Write, Code = 11021, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись прогона насоса, контур 2
        /// </summary>
        public Command SetPumpTraining2_RS485 = new Command { CommandName = Ecl300Resources.SetPumpTraining2_RS485, ErrorMessage = Ecl300ErrorMessages.SetPumpTraining2_RS485, CommandType = CommandType.Write, Code = 12021, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись прогона клапана, контур 1
        /// </summary>
        public Command SetFlapTraining1_RS485 = new Command { CommandName = Ecl300Resources.SetFlapTraining1_RS485, ErrorMessage = Ecl300ErrorMessages.SetFlapTraining1_RS485, CommandType = CommandType.Write, Code = 11022, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись прогона клапана, контур 2
        /// </summary>
        public Command SetFlapTraining2_RS485 = new Command { CommandName = Ecl300Resources.SetFlapTraining2_RS485, ErrorMessage = Ecl300ErrorMessages.SetFlapTraining2_RS485, CommandType = CommandType.Write, Code = 12022, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись типа привода, контур 1
        /// </summary>
        public Command SetDriveType1_RS485 = new Command { CommandName = Ecl300Resources.SetDriveType1_RS485, ErrorMessage = Ecl300ErrorMessages.SetDriveType1_RS485, CommandType = CommandType.Write, Code = 11023, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись типа привода, контур 2
        /// </summary>
        public Command SetDriveType2_RS485 = new Command { CommandName = Ecl300Resources.SetDriveType2_RS485, ErrorMessage = Ecl300ErrorMessages.SetDriveType2_RS485, CommandType = CommandType.Write, Code = 12023, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись макс. наружной температуры X1, контур 1
        /// </summary>
        public Command SetOpenAirTemp_X1_1_RS485 = new Command { CommandName = Ecl300Resources.SetOpenAirTemp_X1_1_RS485, ErrorMessage = Ecl300ErrorMessages.SetOpenAirTemp_X1_1_RS485, CommandType = CommandType.Write, Code = 11030, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись макс. наружной температуры X1, контур 2
        /// </summary>
        public Command SetOpenAirTemp_X1_2_RS485 = new Command { CommandName = Ecl300Resources.SetOpenAirTemp_X1_2_RS485, ErrorMessage = Ecl300ErrorMessages.SetOpenAirTemp_X1_2_RS485, CommandType = CommandType.Write, Code = 12030, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись температуры возвращаемого теплоносителя Y1, контур 1
        /// </summary>
        public Command SetReturnTemp_Y1_1_RS485 = new Command { CommandName = Ecl300Resources.SetReturnTemp_Y1_1_RS485, ErrorMessage = Ecl300ErrorMessages.SetReturnTemp_Y1_1_RS485, CommandType = CommandType.Write, Code = 11031, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись температуры возвращаемого теплоносителя Y1, контур 2
        /// </summary>
        public Command SetReturnTemp_Y1_2_RS485 = new Command { CommandName = Ecl300Resources.SetReturnTemp_Y1_2_RS485, ErrorMessage = Ecl300ErrorMessages.SetReturnTemp_Y1_2_RS485, CommandType = CommandType.Write, Code = 12031, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись макс. наружной температуры X2, контур 1
        /// </summary>
        public Command SetOpenAirTemp_X2_1_RS485 = new Command { CommandName = Ecl300Resources.SetOpenAirTemp_X2_1_RS485, ErrorMessage = Ecl300ErrorMessages.SetOpenAirTemp_X2_1_RS485, CommandType = CommandType.Write, Code = 11032, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись макс. наружной температуры X2, контур 2
        /// </summary>
        public Command SetOpenAirTemp_X2_2_RS485 = new Command { CommandName = Ecl300Resources.SetOpenAirTemp_X2_2_RS485, ErrorMessage = Ecl300ErrorMessages.SetOpenAirTemp_X2_2_RS485, CommandType = CommandType.Write, Code = 12032, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись температуры возвращаемого теплоносителя Y2, контур 1
        /// </summary>
        public Command SetReturnTemp_Y2_1_RS485 = new Command { CommandName = Ecl300Resources.SetReturnTemp_Y2_1_RS485, ErrorMessage = Ecl300ErrorMessages.SetReturnTemp_Y2_1_RS485, CommandType = CommandType.Write, Code = 11033, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись температуры возвращаемого теплоносителя Y2, контур 2
        /// </summary>
        public Command SetReturnTemp_Y2_2_RS485 = new Command { CommandName = Ecl300Resources.SetReturnTemp_Y2_2_RS485, ErrorMessage = Ecl300ErrorMessages.SetReturnTemp_Y2_2_RS485, CommandType = CommandType.Write, Code = 12033, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись максимального влияния обратки, контур 1
        /// </summary>
        public Command SetMaxInfluenceReverse1_RS485 = new Command { CommandName = Ecl300Resources.SetMaxInfluenceReverse1_RS485, ErrorMessage = Ecl300ErrorMessages.SetMaxInfluenceReverse1_RS485, CommandType = CommandType.Write, Code = 11034, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись максимального влияния обратки, контур 2
        /// </summary>
        public Command SetMaxInfluenceReverse2_RS485 = new Command { CommandName = Ecl300Resources.SetMaxInfluenceReverse2_RS485, ErrorMessage = Ecl300ErrorMessages.SetMaxInfluenceReverse2_RS485, CommandType = CommandType.Write, Code = 12034, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись минимального влияния обратки, контур 1
        /// </summary>
        public Command SetMinInfluenceReverse1_RS485 = new Command { CommandName = Ecl300Resources.SetMinInfluenceReverse1_RS485, ErrorMessage = Ecl300ErrorMessages.SetMinInfluenceReverse1_RS485, CommandType = CommandType.Write, Code = 11035, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись минимального влияния обратки, контур 2
        /// </summary>
        public Command SetMinInfluenceReverse2_RS485 = new Command { CommandName = Ecl300Resources.SetMinInfluenceReverse2_RS485, ErrorMessage = Ecl300ErrorMessages.SetMinInfluenceReverse2_RS485, CommandType = CommandType.Write, Code = 12035, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись оптимизации температуры обратки по подаче, контур 1
        /// </summary>
        public Command SetReturnOptimizationViaSupply1_RS485 = new Command { CommandName = Ecl300Resources.SetReturnOptimizationViaSupply1_RS485, ErrorMessage = Ecl300ErrorMessages.SetReturnOptimizationViaSupply1_RS485, CommandType = CommandType.Write, Code = 11036, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись оптимизации температуры обратки по подаче, контур 2
        /// </summary>
        public Command SetReturnOptimizationViaSupply2_RS485 = new Command { CommandName = Ecl300Resources.SetReturnOptimizationViaSupply2_RS485, ErrorMessage = Ecl300ErrorMessages.SetReturnOptimizationViaSupply2_RS485, CommandType = CommandType.Write, Code = 12036, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись параллельной работы ГВС и контуров отопления, контур 1
        /// </summary>
        public Command SetParallelWorkHwsAndHeatSys1_RS485 = new Command { CommandName = Ecl300Resources.SetParallelWorkHwsAndHeatSys1_RS485, ErrorMessage = Ecl300ErrorMessages.SetParallelWorkHwsAndHeatSys1_RS485, CommandType = CommandType.Write, Code = 11042, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись ПИ-регулирования, контур 1
        /// </summary>
        public Command SetPIRegulation1_RS485 = new Command { CommandName = Ecl300Resources.SetPIRegulation1_RS485, ErrorMessage = Ecl300ErrorMessages.SetPIRegulation1_RS485, CommandType = CommandType.Write, Code = 11051, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись ПИ-регулирования, контур 2
        /// </summary>
        public Command SetPIRegulation2_RS485 = new Command { CommandName = Ecl300Resources.SetPIRegulation2_RS485, ErrorMessage = Ecl300ErrorMessages.SetPIRegulation2_RS485, CommandType = CommandType.Write, Code = 12051, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись защиты двигателя, контур 1
        /// </summary>
        public Command SetMotorProtection1_RS485 = new Command { CommandName = Ecl300Resources.SetMotorProtection1_RS485, ErrorMessage = Ecl300ErrorMessages.SetMotorProtection1_RS485, CommandType = CommandType.Write, Code = 11173, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись защиты двигателя, контур 2
        /// </summary>
        public Command SetMotorProtection2_RS485 = new Command { CommandName = Ecl300Resources.SetMotorProtection2_RS485, ErrorMessage = Ecl300ErrorMessages.SetMotorProtection2_RS485, CommandType = CommandType.Write, Code = 12173, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись автометической смены сезонного времени, контур 1
        /// </summary>
        public Command SetChangeSeason1_RS485 = new Command { CommandName = Ecl300Resources.SetChangeSeason1_RS485, ErrorMessage = Ecl300ErrorMessages.SetChangeSeason1_RS485, CommandType = CommandType.Write, Code = 11197, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой комнатной температуры (комфорт), контур 1
        /// </summary>
        public Command SetRoomTempDaySet1_RS485 = new Command { CommandName = Ecl300Resources.SetRoomTempDaySet1_RS485, ErrorMessage = Ecl300ErrorMessages.SetRoomTempDaySet1_RS485, CommandType = CommandType.Write, Code = 11179, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой комнатной температуры (комфорт), контур 2
        /// </summary>
        public Command SetRoomTempDaySet2_RS485 = new Command { CommandName = Ecl300Resources.SetRoomTempDaySet2_RS485, ErrorMessage = Ecl300ErrorMessages.SetRoomTempDaySet2_RS485, CommandType = CommandType.Write, Code = 12179, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой комнатной температуры (эконом), контур 1
        /// </summary>
        public Command SetRoomTempNightSet1_RS485 = new Command { CommandName = Ecl300Resources.SetRoomTempNightSet1_RS485, ErrorMessage = Ecl300ErrorMessages.SetRoomTempNightSet1_RS485, CommandType = CommandType.Write, Code = 11180, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой комнатной температуры (эконом), контур 2
        /// </summary>
        public Command SetRoomTempNightSet2_RS485 = new Command { CommandName = Ecl300Resources.SetRoomTempNightSet2_RS485, ErrorMessage = Ecl300ErrorMessages.SetRoomTempNightSet2_RS485, CommandType = CommandType.Write, Code = 12180, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой температуры горячей воды (комфорт), контур 1
        /// </summary>
        public Command SetHotWaterTempDaySet1_RS485 = new Command { CommandName = Ecl300Resources.SetHotWaterTempDaySet1_RS485, ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempDaySet1_RS485, CommandType = CommandType.Write, Code = 11189, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой температуры горячей воды (комфорт), контур 2
        /// </summary>
        public Command SetHotWaterTempDaySet2_RS485 = new Command { CommandName = Ecl300Resources.SetHotWaterTempDaySet2_RS485, ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempDaySet2_RS485, CommandType = CommandType.Write, Code = 12189, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой температуры горячей воды (эконом), контур 1
        /// </summary>
        public Command SetHotWaterTempNightSet1_RS485 = new Command { CommandName = Ecl300Resources.SetHotWaterTempNightSet1_RS485, ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempNightSet1_RS485, CommandType = CommandType.Write, Code = 11190, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись желаемой температуры горячей воды (эконом), контур 2
        /// </summary>
        public Command SetHotWaterTempNightSet2_RS485 = new Command { CommandName = Ecl300Resources.SetHotWaterTempNightSet2_RS485, ErrorMessage = Ecl300ErrorMessages.SetHotWaterTempNightSet2_RS485, CommandType = CommandType.Write, Code = 12190, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Запись ограничения температуры возвращаемого теплоносителя, контур 1
        /// </summary>
        public Command SetLimitReverseTemperature1_RS485 = new Command { CommandName = Ecl300Resources.SetLimitReverseTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.SetLimitReverseTemperature1_RS485, CommandType = CommandType.Write, Code = 11029, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись ограничения температуры возвращаемого теплоносителя, контур 2
        /// </summary>
        public Command SetLimitReverseTemperature2_RS485 = new Command { CommandName = Ecl300Resources.SetLimitReverseTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.SetLimitReverseTemperature2_RS485, CommandType = CommandType.Write, Code = 12029, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись флага автоматической настройки, контур 2
        /// </summary>
        public Command SetAutotuning2_RS485 = new Command { CommandName = Ecl300Resources.SetAutotuning2_RS485, ErrorMessage = Ecl300ErrorMessages.SetAutotuning2_RS485, CommandType = CommandType.Write, Code = 12172, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        #endregion


    }
}

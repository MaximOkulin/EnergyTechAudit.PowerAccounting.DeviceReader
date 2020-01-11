using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.API
{
    internal sealed partial class Commands
    {
        /// <summary>
        /// Чтение версии программного обеспечения прибора
        /// </summary>
        public Command GetFirmware = new Command { CommandName = CommonResources.GetFirmware, ErrorMessage = CommonErrorMessages.GetFirmware, Code = 2, RegistersCount = 11, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 27 };
        /// <summary>
        /// Чтение заводского номера прибора
        /// </summary>
        public Command GetFactoryNumber = new Command { CommandName = CommonResources.GetFactoryNumber, ErrorMessage = CommonErrorMessages.GetFactoryNumber, Code = 23, RegistersCount = 11, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 27 };
        /// <summary>
        /// Чтение отчетного времени прибора
        /// </summary>
        public Command GetReportingTime = new Command { CommandName = CommonResources.GetReportingTime, ErrorMessage = CommonErrorMessages.GetReportingTime, Code = 40, RegistersCount = 3, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// Чтение структуры изменяемых параметров т/с №1 прибора
        /// </summary>
        public Command GetSettingsHeatSys1 = new Command { CommandName = VistResources.GetSettingsHeatSys1, ErrorMessage = VistErrorMessages.GetSettingsHeatSys1, Code = 52, RegistersCount = 10, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 25 };
        /// <summary>
        /// Чтение структуры изменяемых параметров т/с №2 прибора
        /// </summary>
        public Command GetSettingsHeatSys2 = new Command { CommandName = VistResources.GetSettingsHeatSys2, ErrorMessage = VistErrorMessages.GetSettingsHeatSys2, Code = 65, RegistersCount = 10, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 25 };
        /// <summary>
        /// Чтение структуры изменяемых параметров т/с №3 прибора
        /// </summary>
        public Command GetSettingsHeatSys3 = new Command { CommandName = VistResources.GetSettingsHeatSys3, ErrorMessage = VistErrorMessages.GetSettingsHeatSys3, Code = 78, RegistersCount = 10, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 25 };
        /// <summary>
        /// Чтение числа теплосистем в приборе
        /// </summary>
        public Command GetSystemsCount = new Command { CommandName = VistResources.GetSystemsCount, ErrorMessage = VistErrorMessages.GetSystemsCount, Code = 98, RegistersCount = 1, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение текущей даты и времени прибора
        /// </summary>
        public Command GetDeviceTime = new Command { CommandName = CommonResources.GetDeviceTime, ErrorMessage = CommonErrorMessages.GetDeviceTime, Code = 0, RegistersCount = 3, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// Чтение спецификации архивного файла теплосистемы №1
        /// </summary>
        public Command GetArchiveHeaderSystem1 = new Command { CommandName = VistResources.GetArchiveHeaderSystem1, ErrorMessage = VistErrorMessages.GetArchiveHeaderSystem1, Code = 654, RegistersCount = 5, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// Чтение спецификации архивного файла теплосистемы №2
        /// </summary>
        public Command GetArchiveHeaderSystem2 = new Command { CommandName = VistResources.GetArchiveHeaderSystem2, ErrorMessage = VistErrorMessages.GetArchiveHeaderSystem2, Code = 658, RegistersCount = 5, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// Чтение спецификации архивного файла теплосистемы №3
        /// </summary>
        public Command GetArchiveHeaderSystem3 = new Command { CommandName = VistResources.GetArchiveHeaderSystem3, ErrorMessage = VistErrorMessages.GetArchiveHeaderSystem3, Code = 663, RegistersCount = 5, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// Чтение набора измеряемых текущих параметров теплосистемы №1
        /// </summary>
        public Command GetInstantParamsSetSystem1 = new Command { CommandName = VistResources.GetInstantParamsSetSystem1, ErrorMessage = VistErrorMessages.GetInstantParamsSetSystem1, Code = 512, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение набора измеряемых текущих параметров теплосистемы №2
        /// </summary>
        public Command GetInstantParamsSetSystem2 = new Command { CommandName = VistResources.GetInstantParamsSetSystem2, ErrorMessage = VistErrorMessages.GetInstantParamsSetSystem2, Code = 1536, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение набора измеряемых текущих параметров теплосистемы №3
        /// </summary>
        public Command GetInstantParamsSetSystem3 = new Command { CommandName = VistResources.GetInstantParamsSetSystem3, ErrorMessage = VistErrorMessages.GetInstantParamsSetSystem3, Code = 2560, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение точности по расходу и тепловой мощности теплосистемы №1
        /// </summary>
        public Command GetInstantParamsPrecisionsSystem1 = new Command { CommandName = VistResources.GetInstantParamsPrecisionsSystem1, ErrorMessage = VistErrorMessages.GetInstantParamsPrecisionsSystem1, Code = 514, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение точности по расходу и тепловой мощности теплосистемы №2
        /// </summary>
        public Command GetInstantParamsPrecisionsSystem2 = new Command { CommandName = VistResources.GetInstantParamsPrecisionsSystem2, ErrorMessage = VistErrorMessages.GetInstantParamsPrecisionsSystem2, Code = 1538, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение точности по расходу и тепловой мощности теплосистемы №3
        /// </summary>
        public Command GetInstantParamsPrecisionsSystem3 = new Command { CommandName = VistResources.GetInstantParamsPrecisionsSystem3, ErrorMessage = VistErrorMessages.GetInstantParamsPrecisionsSystem3, Code = 2562, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение текущих температур теплосистемы №1
        /// </summary>
        public Command GetInstantTemperaturesSystem1 = new Command { CommandName = VistResources.GetInstantTemperaturesSystem1, ErrorMessage = VistErrorMessages.GetInstantTemperaturesSystem1, Code = 518, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение текущих температур теплосистемы №2
        /// </summary>
        public Command GetInstantTemperaturesSystem2 = new Command { CommandName = VistResources.GetInstantTemperaturesSystem2, ErrorMessage = VistErrorMessages.GetInstantTemperaturesSystem2, Code = 1542, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение текущих температур теплосистемы №3
        /// </summary>
        public Command GetInstantTemperaturesSystem3 = new Command { CommandName = VistResources.GetInstantTemperaturesSystem3, ErrorMessage = VistErrorMessages.GetInstantTemperaturesSystem3, Code = 2566, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение текущих объемных расходов теплосистемы №1
        /// </summary>
        public Command GetInstantVolumeFlowsSystem1 = new Command { CommandName = VistResources.GetInstantVolumeFlowsSystem1, ErrorMessage = VistErrorMessages.GetInstantVolumeFlowsSystem1, Code = 774, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение текущих объемных расходов теплосистемы №2
        /// </summary>
        public Command GetInstantVolumeFlowsSystem2 = new Command { CommandName = VistResources.GetInstantVolumeFlowsSystem2, ErrorMessage = VistErrorMessages.GetInstantVolumeFlowsSystem2, Code = 1798, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение текущих объемных расходов теплосистемы №3
        /// </summary>
        public Command GetInstantVolumeFlowsSystem3 = new Command { CommandName = VistResources.GetInstantVolumeFlowsSystem3, ErrorMessage = VistErrorMessages.GetInstantVolumeFlowsSystem3, Code = 2822, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение текущих массовых расходов теплосистемы №1
        /// </summary>
        public Command GetInstantMassFlowsSystem1 = new Command { CommandName = VistResources.GetInstantMassFlowsSystem1, ErrorMessage = VistErrorMessages.GetInstantMassFlowsSystem1, Code = 786, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение текущих массовых расходов теплосистемы №2
        /// </summary>
        public Command GetInstantMassFlowsSystem2 = new Command { CommandName = VistResources.GetInstantMassFlowsSystem2, ErrorMessage = VistErrorMessages.GetInstantMassFlowsSystem2, Code = 1810, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение текущих массовых расходов теплосистемы №3
        /// </summary>
        public Command GetInstantMassFlowsSystem3 = new Command { CommandName = VistResources.GetInstantMassFlowsSystem3, ErrorMessage = VistErrorMessages.GetInstantMassFlowsSystem3, Code = 2834, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение текущих давлений теплосистемы №1
        /// </summary>
        public Command GetInstantPressureSystem1 = new Command { CommandName = VistResources.GetInstantPressureSystem1, ErrorMessage = VistErrorMessages.GetInstantPressureSystem1, Code = 546, RegistersCount = 3, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// Чтение текущих давлений теплосистемы №2
        /// </summary>
        public Command GetInstantPressureSystem2 = new Command { CommandName = VistResources.GetInstantPressureSystem2, ErrorMessage = VistErrorMessages.GetInstantPressureSystem2, Code = 1570, RegistersCount = 3, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// Чтение текущих давлений теплосистемы №3
        /// </summary>
        public Command GetInstantPressureSystem3 = new Command { CommandName = VistResources.GetInstantPressureSystem3, ErrorMessage = VistErrorMessages.GetInstantPressureSystem3, Code = 2594, RegistersCount = 3, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };

        /// <summary>
        /// Чтение текущей тепловой мощности теплосистемы №1
        /// </summary>
        public Command GetInstantThermalPowerSystem1 = new Command { CommandName = VistResources.GetInstantThermalPowerSystem1, ErrorMessage = VistErrorMessages.GetInstantThermalPowerSystem1, Code = 800, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение текущей тепловой мощности теплосистемы №2
        /// </summary>
        public Command GetInstantThermalPowerSystem2 = new Command { CommandName = VistResources.GetInstantThermalPowerSystem2, ErrorMessage = VistErrorMessages.GetInstantThermalPowerSystem2, Code = 1824, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение текущей тепловой мощности теплосистемы №3
        /// </summary>
        public Command GetInstantThermalPowerSystem3 = new Command { CommandName = VistResources.GetInstantThermalPowerSystem3, ErrorMessage = VistErrorMessages.GetInstantThermalPowerSystem3, Code = 2848, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };

        /// <summary>
        /// Чтение набора накапливаемых текущих параметров теплосистемы №1
        /// </summary>
        public Command GetFinalInstantParamsSetSystem1 = new Command { CommandName = VistResources.GetFinalInstantParamsSetSystem1, ErrorMessage = VistErrorMessages.GetFinalInstantParamsSetSystem1, Code = 1024, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение набора накапливаемых текущих параметров теплосистемы №2
        /// </summary>
        public Command GetFinalInstantParamsSetSystem2 = new Command { CommandName = VistResources.GetFinalInstantParamsSetSystem2, ErrorMessage = VistErrorMessages.GetFinalInstantParamsSetSystem2, Code = 2048, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение набора накапливаемых текущих параметров теплосистемы №3
        /// </summary>
        public Command GetFinalInstantParamsSetSystem3 = new Command { CommandName = VistResources.GetFinalInstantParamsSetSystem3, ErrorMessage = VistErrorMessages.GetFinalInstantParamsSetSystem3, Code = 3072, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };

        /// <summary>
        /// Чтение точности по объему и тепловой энергии теплосистемы №1
        /// </summary>
        public Command GetFinalInstantParamsPrecisionsSystem1 = new Command { CommandName = VistResources.GetFinalInstantParamsPrecisionsSystem1, ErrorMessage = VistErrorMessages.GetFinalInstantParamsPrecisionsSystem1, Code = 1026, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение точности по объему и тепловой энергии теплосистемы №2
        /// </summary>
        public Command GetFinalInstantParamsPrecisionsSystem2 = new Command { CommandName = VistResources.GetFinalInstantParamsPrecisionsSystem2, ErrorMessage = VistErrorMessages.GetFinalInstantParamsPrecisionsSystem2, Code = 2050, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение точности по объему и тепловой энергии теплосистемы №3
        /// </summary>
        public Command GetFinalInstantParamsPrecisionsSystem3 = new Command { CommandName = VistResources.GetFinalInstantParamsPrecisionsSystem3, ErrorMessage = VistErrorMessages.GetFinalInstantParamsPrecisionsSystem3, Code = 3074, RegistersCount = 4, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };

        /// <summary>
        /// Чтение объемов за текущий час теплосистемы №1
        /// </summary>
        public Command GetVolumesForHourSystem1 = new Command { CommandName = VistResources.GetVolumesForHourSystem1, ErrorMessage = VistErrorMessages.GetVolumesForHourSystem1, Code = 1042, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение объемов за текущий час теплосистемы №2
        /// </summary>
        public Command GetVolumesForHourSystem2 = new Command { CommandName = VistResources.GetVolumesForHourSystem2, ErrorMessage = VistErrorMessages.GetVolumesForHourSystem2, Code = 2066, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение объемов за текущий час теплосистемы №3
        /// </summary>
        public Command GetVolumesForHourSystem3 = new Command { CommandName = VistResources.GetVolumesForHourSystem3, ErrorMessage = VistErrorMessages.GetVolumesForHourSystem3, Code = 3090, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение масс за текущий час теплосистемы №1
        /// </summary>
        public Command GetMassesForHourSystem1 = new Command { CommandName = VistResources.GetMassesForHourSystem1, ErrorMessage = VistErrorMessages.GetMassesForHourSystem1, Code = 1048, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение масс за текущий час теплосистемы №2
        /// </summary>
        public Command GetMassesForHourSystem2 = new Command { CommandName = VistResources.GetMassesForHourSystem2, ErrorMessage = VistErrorMessages.GetMassesForHourSystem2, Code = 2072, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение масс за текущий час теплосистемы №3
        /// </summary>
        public Command GetMassesForHourSystem3 = new Command { CommandName = VistResources.GetMassesForHourSystem3, ErrorMessage = VistErrorMessages.GetMassesForHourSystem3, Code = 3096, RegistersCount = 6, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение тепловой энергии за текущий час теплосистемы №1
        /// </summary>
        public Command GetHeatForHourSystem1 = new Command { CommandName = VistResources.GetHeatForHourSystem1, ErrorMessage = VistErrorMessages.GetHeatForHourSystem1, Code = 1076, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение тепловой энергии за текущий час теплосистемы №2
        /// </summary>
        public Command GetHeatForHourSystem2 = new Command { CommandName = VistResources.GetHeatForHourSystem2, ErrorMessage = VistErrorMessages.GetHeatForHourSystem2, Code = 2100, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение тепловой энергии за текущий час теплосистемы №3
        /// </summary>
        public Command GetHeatForHourSystem3 = new Command { CommandName = VistResources.GetHeatForHourSystem3, ErrorMessage = VistErrorMessages.GetHeatForHourSystem3, Code = 3124, RegistersCount = 2, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение времени наработки за текущий час теплосистемы №1
        /// </summary>
        public Command GetTimeNormalForHourSystem1 = new Command { CommandName = VistResources.GetTimeNormalForHourSystem1, ErrorMessage = VistErrorMessages.GetTimeNormalForHourSystem1, Code = 1078, RegistersCount = 1, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение времени наработки за текущий час теплосистемы №2
        /// </summary>
        public Command GetTimeNormalForHourSystem2 = new Command { CommandName = VistResources.GetTimeNormalForHourSystem2, ErrorMessage = VistErrorMessages.GetTimeNormalForHourSystem2, Code = 2102, RegistersCount = 1, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение времени наработки за текущий час теплосистемы №3
        /// </summary>
        public Command GetTimeNormalForHourSystem3 = new Command { CommandName = VistResources.GetTimeNormalForHourSystem3, ErrorMessage = VistErrorMessages.GetTimeNormalForHourSystem3, Code = 3126, RegistersCount = 1, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение структуры заголовка архивного файла и текущих итоговых теплосистемы
        /// </summary>
        public Command GetArchiveStructureAndFinalInstantSystem = new Command { CommandName = VistResources.GetArchiveStructureAndFinalInstantSystem, ErrorMessage = VistErrorMessages.GetArchiveStructureAndFinalInstantSystem, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadFileRecord, ResponseLengthType = LengthType.Fixed, ResponseLength = 103 };
        /// <summary>
        /// Чтение архивной записи по индексу
        /// </summary>
        public Command ReadArchiveByIndex = new Command { CommandName = VistResources.ReadArchiveByIndex, ErrorMessage = VistErrorMessages.ReadArchiveByIndex, CommandType = CommandType.Read, ModbusFunctionCode = ModbusFunction.ReadFileRecord, ResponseLengthType = LengthType.Calculated };
        
    }
}

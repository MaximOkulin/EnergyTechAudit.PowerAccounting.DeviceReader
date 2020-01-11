using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API
{
    /// <summary>
    /// Мета-описание API-команд регулятора Danfoss ECL Comfort 210/310
    /// </summary>
    internal sealed partial class Commands                          
    {
        // КОМАНДЫ ЧТЕНИЯ
        /// <summary>
        /// Чтение префикса приложения (2059)
        /// </summary>
        public Command GetApplicationPrefix = new Command { CommandName = "GetApplicationPrefix", ErrorMessage = Ecl310ErrorMessages.GetApplicationPrefix, CommandType = CommandType.Read, Code = 2059, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение типа приложения (2060)
        /// </summary>
        public Command GetApplicationType = new Command { CommandName = "GetApplicationType", ErrorMessage = Ecl310ErrorMessages.GetApplicationType, CommandType = CommandType.Read, Code = 2060, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение подтипа приложения (2061)
        /// </summary>
        public Command GetApplicationSubType = new Command { CommandName = "GetApplicationSubType", ErrorMessage = Ecl310ErrorMessages.GetApplicationSubType, CommandType = CommandType.Read, Code = 2061, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение даты производства регулятора (2098)
        /// </summary>
        public Command GetManufacturingDate = new Command { CommandName = "GetManufacturingDate", ErrorMessage = Ecl310ErrorMessages.GetManufacturingDate, CommandType = CommandType.Read, Code = 2098, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение заводского номера прибора (7)
        /// </summary>
        public Command GetFactoryNumber = new Command { CommandName = "GetFactoryNumber", ErrorMessage = Ecl310ErrorMessages.GetFactoryNumber, CommandType = CommandType.Read, Code = 7, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение номера аппаратной версии контроллера (33)
        /// </summary>
        public Command GetHardwareVersion = new Command { CommandName = "GetHardwareVersion", ErrorMessage = Ecl310ErrorMessages.GetHardwareVersion, CommandType = CommandType.Read, Code = 33, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение версии программного обеспечения контроллера (34)
        /// </summary>
        public Command GetFirmware = new Command { CommandName = "GetFirmware", ErrorMessage = Ecl310ErrorMessages.GetFirmware, CommandType = CommandType.Read, Code = 34, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение значений датчиков (S1-S12)" (10200 - 12 регистров)
        /// </summary>
        public Command GetSensorsValues = new Command { CommandName = "GetSensorsValues", CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetSensorsValues, CommandType = CommandType.Read, Code = 10200, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 12, ResponseLengthType = LengthType.Fixed, ResponseLength = 29 };
        /// <summary>
        /// "Чтение значения датчика S1" (10200 - 1 регистр)
        /// </summary>
        public Command GetSensor1Value = new Command { CommandName = Ecl310Resources.GetSensor1Value, CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetSensor1Value, CommandType = CommandType.Read, Code = 10200, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение значения датчика S2" (10201 - 1 регистр)
        /// </summary>
        public Command GetSensor2Value = new Command { CommandName = Ecl310Resources.GetSensor2Value, CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetSensor2Value, CommandType = CommandType.Read, Code = 10201, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение значения датчика S3" (10202 - 1 регистр)
        /// </summary>
        public Command GetSensor3Value = new Command { CommandName = Ecl310Resources.GetSensor3Value, CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetSensor3Value, CommandType = CommandType.Read, Code = 10202, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение значения датчика S5" (10204 - 1 регистр)
        /// </summary>
        public Command GetSensor5Value = new Command { CommandName = Ecl310Resources.GetSensor5Value, CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetSensor5Value, CommandType = CommandType.Read, Code = 10204, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        // "Чтение значений датчиков ECA32 (S13-S16)"
        public Command GetEca32SensorsValues = new Command { CommandName = "GetEca32SensorsValues", CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetEca32SensorsValues, CommandType = CommandType.Read, Code = 10218, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        // "Чтение текущего время прибора"
        public Command GetDeviceTime = new Command { CommandName = "GetDeviceTime", CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetDeviceTime, CommandType = CommandType.Read, Code = 64044, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        // "Чтение рассчитанных параметров для датчика 2"
        public Command GetSensor2CalculatedValueCircuit1 = new Command { CommandName = "GetSensor2CalculatedValueCircuit1", CanBeSkip = CanBeSkip.Yes, ErrorMessage = Ecl310ErrorMessages.GetSensor2CalculatedValueCircuit1, CommandType = CommandType.Read, Code = 11251, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        // "Чтение рассчитанных параметров для датчиков 3"
        public Command GetSensor3CalculatedValueCircuit1 = new Command { CommandName = "GetSensor3CalculatedValueCircuit1", ErrorMessage = Ecl310ErrorMessages.GetSensor3CalculatedValueCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11252, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        // "Чтение рассчитанного параметра для датчика 4"
        public Command GetSensor4CalculatedValueCircuit2 = new Command { CommandName = "GetSensor4CalculatedValueCircuit2", ErrorMessage = Ecl310ErrorMessages.GetSensor4CalculatedValueCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12253, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        // "Чтение рассчитанного параметра для датчика 5"
        public Command GetSensor5CalculatedValueCircuit1 = new Command { CommandName = "GetSensor5CalculatedValueCircuit1", ErrorMessage = Ecl310ErrorMessages.GetSensor5CalculatedValueCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11254, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        // "Чтение рассчитанного параметра для датчика 6"
        public Command GetSensor6CalculatedValueCircuit2 = new Command { CommandName = "GetSensor6CalculatedValueCircuit2", ErrorMessage = Ecl310ErrorMessages.GetSensor6CalculatedValueCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12255, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        // "Чтение рассчитанного параметра для датчика 7"
        public Command GetSensor7CalculatedValueCircuit1 = new Command { CommandName = "GetSensor7CalculatedValueCircuit1", ErrorMessage = Ecl310ErrorMessages.GetSensor7CalculatedValueCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11256, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров системы отопления" (11176 - 11 регистров)
        /// </summary>
        public Command GetHeatSystemParameters = new Command { CommandName = "GetHeatSystemParameters", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 11, ResponseLengthType = LengthType.Fixed, ResponseLength = 27 };
        /// <summary>
        /// "Чтение значений температур системы отопления" (11176 - 5 регистров)
        /// </summary>
        public Command GetHeatSystemTemperatures = new Command { CommandName = "GetHeatSystemTemperatures", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemTemperatures, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение желаемых температур горячей воды" (11190-11191)
        /// </summary>
        public Command GetNewDesiredHotWaterTemperatures = new Command { CommandName = Ecl310Resources.GetNewDesiredHotWaterTemperatures, ErrorMessage = Ecl310ErrorMessages.GetNewDesiredHotWaterTemperatures, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11189, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение параметров контура 1" (11176 - 1 регистр)
        /// </summary>
        public Command GetHeatSystemParameters1Registers = new Command { CommandName = "GetHeatSystemParameters1Registers", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemParameters1Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// "Чтение параметров контура 1" (11176 - 2 регистра)
        /// </summary>
        public Command GetHeatSystemParameters2Registers = new Command { CommandName = "GetHeatSystemParameters2Registers", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemParameters2Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение параметров контура 1" (11176 - 3 регистра)
        /// </summary>
        public Command GetHeatSystemParameters3Registers = new Command { CommandName = "GetHeatSystemParameters3Registers", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemParameters3Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// "Чтение параметров контура 1" (11179 - 8 регистров)
        /// </summary>
        public Command GetHeatSystemParameters8Registers = new Command { CommandName = "GetHeatSystemParameters8Registers", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemParameters8Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11179, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Fixed, ResponseLength = 21 };

        /// <summary>
        /// "Чтение желаемых температур контура 1" (11179 - 2 регистра)
        /// </summary>
        public Command GetDesiredTemperaturesCircuit1 = new Command { CommandName = "GetDesiredTemperaturesCircuit1", ErrorMessage = Ecl310ErrorMessages.GetDesiredTemperaturesCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11179, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };

        /// <summary>
        /// "Чтение значений коэффициентов системы отопления" (11183 - 4 регистра)
        /// </summary>
        public Command GetHeatSystemKoefficients = new Command { CommandName = "GetHeatSystemKoefficients", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemKoefficients, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11183, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение значений органичений температуры подачи системы отопления" (11299 - 4 регистра)
        /// </summary>
        public Command GetHeatSystemSupplyTemperatureLimits = new Command { CommandName = "GetHeatSystemSupplyTemperatureLimits", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemSupplyTemperatureLimits, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11299, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение значений органичений температуры подачи системы отопления" (12299 - 4 регистра)
        /// </summary>
        public Command GetHwsSupplyTemperatureLimits = new Command { CommandName = "GetHwsSupplyTemperatureLimits", ErrorMessage = Ecl310ErrorMessages.GetHwsSupplyTemperatureLimits, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12299, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение значений параметров насосов системы отопления" (11309 - 5 регистров)
        /// </summary>
        public Command GetHeatSystemPumpParameters = new Command { CommandName = "GetHeatSystemPumpParameters", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemPumpParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11309, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение значений параметров насосов ГВС" (12309 - 5 регистров)
        /// </summary>
        public Command GetHwsPumpParameters = new Command { CommandName = "GetHwsPumpParameters", ErrorMessage = Ecl310ErrorMessages.GetHwsPumpParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12309, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение использования внешнего сигнала в контуре 1" (11083 - 1 регистр)
        /// </summary>
        public Command GetHsExternalSignal = new Command { CommandName = "GetHsExternalSignal", ErrorMessage = Ecl310ErrorMessages.GetHsExternalSignal, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11083, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        // "Чтение желаемых температур горячей воды"
        public Command GetDesiredHotWaterTemperatures = new Command { CommandName = "GetDesiredHotWaterTemperatures", ErrorMessage = Ecl310ErrorMessages.GetDesiredHotWaterTemperatures, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12189, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение параметров системы отопления для обратного трубопровода контура 1 и пр." (11030 - 7 регистров)
        /// </summary>
        public Command GetHeatSystemReverseParameters = new Command { CommandName = "GetHeatSystemReverseParameters", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemReverseParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11030, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Fixed, ResponseLength = 19 };
        /// <summary>
        /// "Чтение параметров системы отопления для обратного трубопровода контура 1 и пр." (11034 - 3 регистра)
        /// </summary>
        public Command GetHeatSystemReverseParameters3Registers = new Command { CommandName = "GetHeatSystemReverseParameters3Registers", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemReverseParameters3Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11034, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// "Чтение коэффициента максимального влияния ветра" (11056 - 1 регистр)
        /// </summary>
        public Command GetHeatSystemMaxWindInfluence = new Command { CommandName = "GetHeatSystemMaxWindInfluence", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemMaxWindInfluence, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11056, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение ограничения температуры обратного трубопровода контура 1" (11029 - 1 регистр)
        /// </summary>
        public Command GetHeatSystemLimitReverseTemperature = new Command { CommandName = "GetHeatSystemLimitReverseTemperature", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemLimitReverseTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11029, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение фильтра ветра" (11080 - 1 регистр)
        /// </summary>
        public Command GetHeatSystemWindFilter = new Command { CommandName = "GetHeatSystemWindFilter", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemWindFilter, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11080, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение ограничения ветра" (11098 - 1 регистр)
        /// </summary>
        public Command GetHeatSystemWindLimit = new Command { CommandName = "GetHeatSystemWindLimit", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemWindLimit, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11098, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров системы отопления для обратного трубопровода контура 2 и пр." (12030 - 7 регистров)
        /// </summary>
        public Command GetHwsReverseParameters = new Command { CommandName = "GetHwsReverseParameters", ErrorMessage = Ecl310ErrorMessages.GetHwsReverseParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12030, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Fixed, ResponseLength = 19 };
        /// <summary>
        /// "Чтение минимального времени активации электропривода системы отопления" (11188 - 1 регистр)
        /// </summary>
        public Command GetHeatSystemDriveActivationTime = new Command { CommandName = "GetHeatSystemDriveActivationTime", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemDriveActivationTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11188, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение температурного графика" (11399 - 6 регистров)
        /// </summary>
        public Command GetHeatCurve = new Command { CommandName = "GetHeatCurve", ErrorMessage = Ecl310ErrorMessages.GetHeatCurve, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11399, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 6, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// "Чтение температурного графика" (12399 - 6 регистров)
        /// </summary>
        public Command GetHeatCurve2 = new Command { CommandName = "GetHeatCurve2", ErrorMessage = Ecl310ErrorMessages.GetHeatCurve2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12399, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 6, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// "Чтение времени профилактики насоса системы отопления" (11021 - 1 регистр)
        /// </summary>
        public Command GetHeatSystemPumpTrainingTime = new Command { CommandName = "GetHeatSystemPumpTrainingTime", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemPumpTrainingTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11021, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение времени профилактики насоса ГВС" (12021 - 1 регистр)
        /// </summary>
        public Command GetHwsPumpTrainingTime = new Command { CommandName = "GetHwsPumpTrainingTime", ErrorMessage = Ecl310ErrorMessages.GetHwsPumpTrainingTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12021, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров заполнения водой контура 1" (11319 - 4 регистра)
        /// </summary>
        public Command GetHeatSystemWaterFillParameters = new Command { CommandName = "GetHeatSystemWaterFillParameters", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemWaterFillParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11319, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение параметров заполнения водой контура 2" (12319 - 4 регистра)
        /// </summary>
        public Command GetHwsWaterFillParameters = new Command { CommandName = "GetHwsWaterFillParameters", ErrorMessage = Ecl310ErrorMessages.GetHwsWaterFillParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12319, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение параметров подпитки контура 1" (11319 - 8 регистров)
        /// </summary>
        public Command GetMakeupParametersCircuit1 = new Command { CommandName = "GetMakeupParametersCircuit1", ErrorMessage = Ecl310ErrorMessages.GetMakeupParametersCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11319, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Fixed, ResponseLength = 21 };
        /// <summary>
        /// "Чтение параметров подпитки контура 2" (12319 - 8 регистров)
        /// </summary>
        public Command GetMakeupParametersCircuit2 = new Command { CommandName = "GetMakeupParametersCircuit2", ErrorMessage = Ecl310ErrorMessages.GetMakeupParametersCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12319, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Fixed, ResponseLength = 21 };
        /// <summary>
        /// "Чтение параметров заполнения водой системы отопления (2 часть)" (11324 - 3 регистра)
        /// </summary>
        public Command GetHeatSystemWaterFillParameters2 = new Command { CommandName = "GetHeatSystemWaterFillParameters2", ErrorMessage = Ecl310ErrorMessages.GetHeatSystemWaterFillParameters2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11324, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// "Чтение времени ожидания перед открытием клапана" (11324 - 1 регистр)
        /// </summary>
        public Command GetHsWaitOpenValveTime = new Command { CommandName = "GetHsWaitOpenValveTime", ErrorMessage = Ecl310ErrorMessages.GetHsWaitOpenValveTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11324, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение времени ожидания перед открытием клапана" (12324 - 1 регистр)
        /// </summary>
        public Command GetHwsWaitOpenValveTime = new Command { CommandName = "GetHwsWaitOpenValveTime", ErrorMessage = Ecl310ErrorMessages.GetHwsWaitOpenValveTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12324, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение типа входного сигнала давления контура 1" (11326 - 1 регистр)
        /// </summary>
        public Command GetEcl310PressureInputSignalTypeId = new Command { CommandName = "GetEcl310PressureInputSignalTypeId", ErrorMessage = Ecl310ErrorMessages.GetEcl310PressureInputSignalTypeId, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11326, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение типа входного сигнала давления контура 2" (12326 - 1 регистр)
        /// </summary>
        public Command GetEcl310PressureInputSignalType2Id = new Command { CommandName = "GetEcl310PressureInputSignalType2Id", ErrorMessage = Ecl310ErrorMessages.GetEcl310PressureInputSignalType2Id, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12326, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение предельной температуры обратки ГВС" (12029 - 1 регистр)
        /// </summary>
        public Command GetHwsLimitReverseTemperature = new Command { CommandName = "GetHwsLimitReverseTemperature", ErrorMessage = Ecl310ErrorMessages.GetHwsLimitReverseTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12029, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение мин/макс влияния обратки ГВС" (12034 - 3 регистра)
        /// </summary>
        public Command GetHwsMinMaxInfluenceReverse = new Command { CommandName = "GetHwsMinMaxInfluenceReverse", ErrorMessage = Ecl310ErrorMessages.GetHwsMinMaxInfluenceReverse, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12034, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// "Чтение мин/макс температур подачи ГВС" (12176 - 2 регистра)
        /// </summary>
        public Command GetHwsMinMaxFlowTemperatures = new Command { CommandName = "GetHwsMinMaxFlowTemperatures", ErrorMessage = Ecl310ErrorMessages.GetHwsMinMaxFlowTemperatures, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение значений температур второго контура" (12176 - 5 регистров)
        /// </summary>
        public Command GetHwsTemperatures = new Command { CommandName = "GetHwsTemperatures", ErrorMessage = Ecl310ErrorMessages.GetHwsTemperatures, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение параметров контура 2" (12176 - 11 регистров)
        /// </summary>
        public Command Get2CircuitParameters = new Command { CommandName = "Get2CircuitParameters", ErrorMessage = Ecl310ErrorMessages.Get2CircuitParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 11, ResponseLengthType = LengthType.Fixed, ResponseLength = 27 };
        /// <summary>
        /// "Чтение параметров ГВС" (12183 - 4 регистра)
        /// </summary>
        public Command GetHwsParameters = new Command { CommandName = "GetHwsParameters", ErrorMessage = Ecl310ErrorMessages.GetHwsParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12183, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение параметров ГВС" (12184 - 3 регистра)
        /// </summary>
        public Command GetHwsParameters3Registers = new Command { CommandName = "GetHwsParameters3Registers", ErrorMessage = Ecl310ErrorMessages.GetHwsParameters3Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12184, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// "Чтение минимального времени активации электропривода ГВС" (12188 - 1 регистр)
        /// </summary>
        public Command GetHwsDriveActivationTime = new Command { CommandName = "GetHwsDriveActivationTime", ErrorMessage = Ecl310ErrorMessages.GetHwsDriveActivationTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12188, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение режимов работы контуров" (4200 - 2 регистра)
        /// </summary>
        public Command GetOperatingModes = new Command { CommandName = "GetOperatingModes", ErrorMessage = Ecl310ErrorMessages.GetOperatingModes, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4200, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение режима работы контура 1" (4200 - 1 регистр)
        /// </summary>
        public Command GetOperatingMode = new Command { CommandName = "GetOperatingMode", ErrorMessage = Ecl310ErrorMessages.GetOperatingMode, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4200, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение статусов работы контуров" (4210 - 2 регистра)
        /// </summary>
        public Command GetOperatingStatuses = new Command { CommandName = "GetOperatingStatuses", ErrorMessage = Ecl310ErrorMessages.GetOperatingStatuses, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4210, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };

        /// <summary>
        /// "Чтение статуса работы контура 1" (4210 - 1 регистр)
        /// </summary>
        public Command GetOperatingStatus = new Command { CommandName = "GetOperatingStatus", ErrorMessage = Ecl310ErrorMessages.GetOperatingStatus, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4210, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// "Чтение статусов режима ручного управления" (4025 - 2 регистра)
        /// </summary>
        public Command GetManualRelayStatuses = new Command { CommandName = "GetManualRelayStatuses", ErrorMessage = Ecl310ErrorMessages.GetManualRelayStatuses, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4025, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение статусов режима ручного управления (3 регистра)" (4025 - 3 регистра)
        /// </summary>
        public Command GetManualRelayStatuses3Registers = new Command { CommandName = "GetManualRelayStatuses3Registers", ErrorMessage = Ecl310ErrorMessages.GetManualRelayStatuses3Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4025, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// "Чтение статусов режима ручного управления (5 регистров)" (4025 - 5 регистров)
        /// </summary>
        public Command GetManualRelayStatuses5Registers = new Command { CommandName = "GetManualRelayStatuses5Registers", ErrorMessage = Ecl310ErrorMessages.GetManualRelayStatuses5Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4025, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение статусов режима ручного управления (7 регистров)" (4025 - 7 регистров)
        /// </summary>
        public Command GetManualRelayStatuses7Registers = new Command { CommandName = "GetManualRelayStatuses7Registers", ErrorMessage = Ecl310ErrorMessages.GetManualRelayStatuses7Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 4025, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Fixed, ResponseLength = 19 };

        // "Чтение параметров, связанных с работой датчика потока"
        public Command GetFlowSensorParameters = new Command { CommandName = "GetFlowSensorParameters", ErrorMessage = Ecl310ErrorMessages.GetFlowSensorParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12093, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение количества насосов" (10325 - 1 регистр)
        /// </summary>
        public Command GetPumpCount = new Command { CommandName = "GetPumpCount", ErrorMessage = Ecl310ErrorMessages.GetPumpCount, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 10325, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение нижнего значения максимальной границы контура 1 Y1" (11302 - 1 регистр)
        /// </summary>
        public Command GetMinHsBorderFlowTemperature = new Command { CommandName = "GetMinHsBorderFlowTemperature", ErrorMessage = Ecl310ErrorMessages.GetMinHsBorderFlowTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11302, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение верхнего значения максимальной границы контура 1 Y2" (11300 - 1 регистр)
        /// </summary>
        public Command GetMaxHsBorderFlowTemperature = new Command { CommandName = "GetMaxHsBorderFlowTemperature", ErrorMessage = Ecl310ErrorMessages.GetMaxHsBorderFlowTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11300, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров компенсации контура 1" (11059 - 8 регистров)
        /// </summary>
        public Command GetCompensationParameters = new Command { CommandName = "GetCompensationParameters", ErrorMessage = Ecl310ErrorMessages.GetCompensationParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11059, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Fixed, ResponseLength = 21 };
        /// <summary>
        /// "Чтение заданной балансовой температуры" (11007 - 1 регистр)
        /// </summary>
        public Command GetAdjustedBalanceTemperature = new Command { CommandName = "GetAdjustedBalanceTemperature", ErrorMessage = Ecl310ErrorMessages.GetAdjustedBalanceTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11007, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение коэффициента мертвой зоны" (11008 - 1 регистр)
        /// </summary>
        public Command GetDeadBand = new Command { CommandName = "GetDeadBand", ErrorMessage = Ecl310ErrorMessages.GetDeadBand, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11008, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение коэффициентов ограничения комнатной температуры" (11181 - 2 регистра)
        /// </summary>
        public Command GetInfluenceRoomParams = new Command { CommandName = "GetLimitFreezeTemperature", ErrorMessage = Ecl310ErrorMessages.GetLimitFreezeTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11181, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение скорости адаптации комнатной температуры, контур 1" (11014 - 1 регистр)
        /// </summary>
        public Command GetOptimizationTime = new Command { CommandName = "GetOptimizationTime", ErrorMessage = Ecl310ErrorMessages.GetOptimizationTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11014, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение скорости адаптации комнатной температуры, контур 2" (12014 - 1 регистр)
        /// </summary>
        public Command GetOptimizationTimeCircuit2 = new Command { CommandName = "GetOptimizationTimeCircuit2", ErrorMessage = Ecl310ErrorMessages.GetOptimizationTimeCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12014, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение предельной температуры замерзания" (11107 - 1 регистр)
        /// </summary>
        public Command GetLimitFreezeTemperature = new Command { CommandName = "GetLimitFreezeTemperature", ErrorMessage = Ecl310ErrorMessages.GetLimitFreezeTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11107, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение мин. влияния предельной безопасной температуры" (11104 - 1 регистр)
        /// </summary>
        public Command GetMinLimitFreezeTemperature = new Command { CommandName = "GetMinLimitFreezeTemperature", ErrorMessage = Ecl310ErrorMessages.GetMinLimitFreezeTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11104, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение времени оптимизации предельной безопасной температуры" (11106 - 1 регистр)
        /// </summary>
        public Command GetLimitFreezeOptimizationTime = new Command { CommandName = "GetLimitFreezeOptimizationTime", ErrorMessage = Ecl310ErrorMessages.GetLimitFreezeOptimizationTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11106, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение защиты двигателя" (11173 - 1 регистр)
        /// </summary>
        public Command GetMotorProtection = new Command { CommandName = "GetMotorProtection", ErrorMessage = Ecl310ErrorMessages.GetMotorProtection, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11173, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение защиты двигателя регулятор 2" (12173 - 1 регистр)
        /// </summary>
        public Command GetMotorProtection2 = new Command { CommandName = "GetMotorProtection2", ErrorMessage = Ecl310ErrorMessages.GetMotorProtection2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12173, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение максимального выходного напряжения" (12164 - 1 регистр)
        /// </summary>
        public Command GetMaxOutputVoltage = new Command { CommandName = "GetMaxOutputVoltage", ErrorMessage = Ecl310ErrorMessages.GetMaxOutputVoltage, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12164, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение минимального выходного напряжения" (12166 - 1 регистр)
        /// </summary>
        public Command GetMinOutputVoltage = new Command { CommandName = "GetMinOutputVoltage", ErrorMessage = Ecl310ErrorMessages.GetMinOutputVoltage, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12166, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение реверса" (12170 - 1 регистр)
        /// </summary>
        public Command GetReverse = new Command { CommandName = "GetReverse", ErrorMessage = Ecl310ErrorMessages.GetReverse, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12170, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение настроек управления вентилятором" (11085 - 6 регистров)
        /// </summary>
        public Command GetFanParameters = new Command { CommandName = "GetFanParameters", ErrorMessage = Ecl310ErrorMessages.GetFanParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11085, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 6, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// "Чтение коэффициента разницы заданных комнатных температур" (11026 - 1 регистр)
        /// </summary>
        public Command GetRoomTemperaturesDiff = new Command { CommandName = "GetRoomTemperaturesDiff", ErrorMessage = Ecl310ErrorMessages.GetRoomTemperaturesDiff, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11026, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение температуры защиты от замерзания" (11076 - 1 регистр)
        /// </summary>
        public Command GetFrostProtectionTemperature = new Command { CommandName = "GetFrostProtectionTemperature", ErrorMessage = Ecl310ErrorMessages.GetFrostProtectionTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11076, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение функции вентилятора" (11136 - 1 регистр)
        /// </summary>
        public Command GetFanFunction = new Command { CommandName = "GetFanFunction", ErrorMessage = Ecl310ErrorMessages.GetFanFunction, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11136, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение фильтра S4" (10303 - 1 регистр)
        /// </summary>
        public Command GetS4Filter = new Command { CommandName = "GetS4Filter", ErrorMessage = Ecl310ErrorMessages.GetS4Filter, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 10303, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение адреса ECA" (11009 - 1 регистр)
        /// </summary>
        public Command GetEcaAddressId = new Command { CommandName = "GetEcaAddressId", ErrorMessage = Ecl310ErrorMessages.GetEcaAddressId, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11009, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение адреса ECA, контур 2" (12009 - 1 регистр)
        /// </summary>
        public Command GetEcaAddressCircuit2Id = new Command { CommandName = "GetEcaAddressCircuit2Id", ErrorMessage = Ecl310ErrorMessages.GetEcaAddressCircuit2Id, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12009, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага полного отключения, контур 1" (11020 - 1 регистр)
        /// </summary>
        public Command GetBlackout = new Command { CommandName = "GetBlackout", ErrorMessage = Ecl310ErrorMessages.GetBlackout, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11020, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага полного отключения, контур 2" (12020 - 1 регистр)
        /// </summary>
        public Command GetBlackoutCircuit2 = new Command { CommandName = "GetBlackoutCircuit2", ErrorMessage = Ecl310ErrorMessages.GetBlackoutCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12020, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение времени перехода между режимами" (11081 - 1 регистр)
        /// </summary>
        public Command GetTransitionModeTime = new Command { CommandName = "GetTransitionModeTime", ErrorMessage = Ecl310ErrorMessages.GetTransitionModeTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11081, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение температуры защиты от замерзания" (11092 - 1 регистр)
        /// </summary>
        public Command GetFrostProtectionTemperature2 = new Command { CommandName = "GetFrostProtectionTemperature2", ErrorMessage = Ecl310ErrorMessages.GetFrostProtectionTemperature2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11092, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага выбора компенсационной температуры" (11139 - 3 регистра)
        /// </summary>
        public Command GetSelectionCompensationTemperature = new Command { CommandName = "GetSelectionCompensationTemperature", ErrorMessage = Ecl310ErrorMessages.GetSelectionCompensationTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11139, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// "Чтение флага посылки заданной температуры" (11499 - 1 регистр)
        /// </summary>
        public Command GetSendPredeterminedTemperature = new Command { CommandName = "GetSendPredeterminedTemperature", ErrorMessage = Ecl310ErrorMessages.GetSendPredeterminedTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11499, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение аварийной температуры замерзания S6" (11675 - 1 регистр)
        /// </summary>
        public Command GetAccidentS6FreezingTemperature = new Command { CommandName = "GetAccidentS6FreezingTemperature", ErrorMessage = Ecl310ErrorMessages.GetAccidentS6FreezingTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11675, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение аварийной температуры замерзания S5" (11655 - 1 регистр)
        /// </summary>
        public Command GetAccidentS5FreezingTemperature = new Command { CommandName = "GetAccidentS5FreezingTemperature", ErrorMessage = Ecl310ErrorMessages.GetAccidentS5FreezingTemperature, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11655, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров термостата замерзания" (11615 - 2 регистра)
        /// </summary>
        public Command GetFrostThermostatParameters = new Command { CommandName = "GetFrostThermostatParameters", ErrorMessage = Ecl310ErrorMessages.GetFrostThermostatParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11615, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение параметров термостата пожаробезопасности" (11635 - 2 регистра)
        /// </summary>
        public Command GetFireSafetyThermostatParameters = new Command { CommandName = "GetFireSafetyThermostatParameters", ErrorMessage = Ecl310ErrorMessages.GetFireSafetyThermostatParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11635, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение параметров температурного монитора, контур 1" (11146 - 4 регистра)
        /// </summary>
        public Command GetTemperatureMonitorParameters = new Command { CommandName = "GetTemperatureMonitorParameters", ErrorMessage = Ecl310ErrorMessages.GetTemperatureMonitorParameters, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11146, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение параметров температурного монитора, контур 2" (12146 - 4 регистра)
        /// </summary>
        public Command GetTemperatureMonitorParametersCircuit2 = new Command { CommandName = "GetTemperatureMonitorParametersCircuit2", ErrorMessage = Ecl310ErrorMessages.GetTemperatureMonitorParametersCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12146, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение приоритета ограничения температуры обратки" (11084 - 1 регистр)
        /// </summary>
        public Command GetLimitReversePriority = new Command { CommandName = "GetLimitReversePriority", ErrorMessage = Ecl310ErrorMessages.GetLimitReversePriority, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11084, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение приоритета ограничения температуры обратки" (12084 - 1 регистр)
        /// </summary>
        public Command GetLimitReversePriorityCircuit2 = new Command { CommandName = "GetLimitReversePriorityCircuit2", ErrorMessage = Ecl310ErrorMessages.GetLimitReversePriorityCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12084, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров внешнего входа, контур 1" (11140 - 2 регистра)
        /// </summary>
        public Command GetExternalInputParams = new Command { CommandName = "GetExternalInputParams", ErrorMessage = Ecl310ErrorMessages.GetExternalInputParams, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11140, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение параметров внешнего входа, контур 2" (12140 - 2 регистра)
        /// </summary>
        public Command GetExternalInputParamsCircuit2 = new Command { CommandName = "GetExternalInputParamsCircuit2", ErrorMessage = Ecl310ErrorMessages.GetExternalInputParamsCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12140, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение смещения" (11016 - 1 регистр)
        /// </summary>
        public Command GetOffset = new Command { CommandName = "GetOffset", ErrorMessage = Ecl310ErrorMessages.GetOffset, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11016, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение тренировки клапана, контур 1" (11022 - 1 регистр)
        /// </summary>
        public Command GetFlapTrainingCircuit1 = new Command { CommandName = "GetFlapTrainingCircuit1", ErrorMessage = Ecl310ErrorMessages.GetFlapTrainingCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11022, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение тренировки клапана, контур 2" (12022 - 1 регистр)
        /// </summary>
        public Command GetFlapTrainingCircuit2 = new Command { CommandName = "GetFlapTrainingCircuit2", ErrorMessage = Ecl310ErrorMessages.GetFlapTrainingCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12022, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение приоритета ГВС, контур 1" (11051 - 1 регистр)
        /// </summary>
        public Command GetHwsPriorityCircuit1 = new Command { CommandName = "GetHwsPriorityCircuit1", ErrorMessage = Ecl310ErrorMessages.GetHwsPriorityCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11051, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение приоритета ГВС, контур 2" (12051 - 1 регистр)
        /// </summary>
        public Command GetHwsPriorityCircuit2 = new Command { CommandName = "GetHwsPriorityCircuit2", ErrorMessage = Ecl310ErrorMessages.GetHwsPriorityCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12051, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение температуры защиты от замерзания, контур 2" (12076 - 1 регистр)
        /// </summary>
        public Command GetFrostProtectionTemperatureCircuit2 = new Command { CommandName = "GetFrostProtectionTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.GetFrostProtectionTemperatureCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12076, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение температуры тепловой нагрузки, контур 1" (11077 - 1 регистр)
        /// </summary>
        public Command GetThermalLoadTemperatureCircuit1 = new Command { CommandName = "GetThermalLoadTemperatureCircuit1", ErrorMessage = Ecl310ErrorMessages.GetThermalLoadTemperatureCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11077, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение температуры тепловой нагрузки, контур 2" (12077 - 1 регистр)
        /// </summary>
        public Command GetThermalLoadTemperatureCircuit2 = new Command { CommandName = "GetThermalLoadTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.GetThermalLoadTemperatureCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12077, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение требуемой температуры защиты от замерзания, контур 2" (12092 - 1 регистр)
        /// </summary>
        public Command GetFrostProtectionTemperature2Circuit2 = new Command { CommandName = "GetFrostProtectionTemperature2Circuit2", ErrorMessage = Ecl310ErrorMessages.GetFrostProtectionTemperature2Circuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12092, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров ограничения расхода, контур 1" (11111 - 8 регистров)
        /// </summary>
        public Command GetFlowLimitationParams = new Command { CommandName = "GetFlowLimitationParams", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationParams, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11111, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Fixed, ResponseLength = 21 };
        /// <summary>
        /// "Чтение двух параметров ограничения расхода, контур 1" (11111 - 2 регистра)
        /// </summary>
        public Command GetFlowLimitation2Params = new Command { CommandName = "GetFlowLimitation2Params", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitation2Params, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11111, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение пяти параметров ограничения расхода, контур 1" (11114 - 5 регистров)
        /// </summary>
        public Command GetFlowLimitation5Params = new Command { CommandName = "GetFlowLimitation5Params", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitation5Params, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11114, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение параметров ограничения расхода, контур 1" (11110 - 5 регистров)
        /// </summary>
        public Command GetFlowLimitationParams5Registers = new Command { CommandName = "GetFlowLimitationParams5Registers", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationParams5Registers, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11110, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение параметров ограничения расхода, контур 2" (12110 - 5 регистров)
        /// </summary>
        public Command GetFlowLimitationParams5RegistersCircuit2 = new Command { CommandName = "GetFlowLimitationParams5RegistersCircuit2", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationParams5RegistersCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12110, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// "Чтение параметров ограничения расхода, контур 2" (12111 - 8 регистров)
        /// </summary>
        public Command GetFlowLimitationParamsCircuit2 = new Command { CommandName = "GetFlowLimitationParamsCircuit2", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationParamsCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12111, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Fixed, ResponseLength = 21 };
        /// <summary>
        /// "Чтение двух параметров ограничения расхода, контур 2" (12111 - 2 регистра)
        /// </summary>
        public Command GetFlowLimitation2ParamsCircuit2 = new Command { CommandName = "GetFlowLimitation2ParamsCircuit2", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitation2ParamsCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12111, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение пяти параметров ограничения расхода, контур 2" (12114 - 2 регистра)
        /// </summary>
        public Command GetFlowLimitation5ParamsCircuit2 = new Command { CommandName = "GetFlowLimitation5ParamsCircuit2", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitation5ParamsCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12114, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };

        /// <summary>
        /// "Чтение типа входа ограничения расхода, контур 1" (11108 - 1 регистр)
        /// </summary>
        public Command GetFlowLimitationInputTypeId = new Command { CommandName = "GetFlowLimitationInputTypeId", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationInputTypeId, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11108, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение типа входа ограничения расхода, контур 2" (12108 - 1 регистр)
        /// </summary>
        public Command GetFlowLimitationInputTypeCircuit2Id = new Command { CommandName = "GetFlowLimitationInputTypeCircuit2Id", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationInputTypeCircuit2Id, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12108, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров оптимизации, контур 1" (11010 - 4 регистр)
        /// </summary>
        public Command GetOptimizationParams = new Command { CommandName = "GetOptimizationParams", ErrorMessage = Ecl310ErrorMessages.GetOptimizationParams, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11010, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение параметров оптимизации, контур 2" (12010 - 4 регистр)
        /// </summary>
        public Command GetOptimizationParamsCircuit2 = new Command { CommandName = "GetOptimizationParamsCircuit2", ErrorMessage = Ecl310ErrorMessages.GetOptimizationParamsCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12010, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение флага задержки отключения, контур 1" (11025 - 1 регистр)
        /// </summary>
        public Command GetOptimizationOffDelay = new Command { CommandName = "GetOptimizationOffDelay", ErrorMessage = Ecl310ErrorMessages.GetOptimizationOffDelay, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11025, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага задержки отключения, контур 2" (12025 - 1 регистр)
        /// </summary>
        public Command GetOptimizationOffDelayCircuit2 = new Command { CommandName = "GetOptimizationOffDelayCircuit2", ErrorMessage = Ecl310ErrorMessages.GetOptimizationOffDelayCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12025, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение базиса оптимизации, контур 1" (11019 - 1 регистр)
        /// </summary>
        public Command GetOptimizationBasisId = new Command { CommandName = "GetOptimizationBasisId", ErrorMessage = Ecl310ErrorMessages.GetOptimizationBasisId, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11019, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение базиса оптимизации, контур 2" (12019 - 1 регистр)
        /// </summary>
        public Command GetOptimizationBasisCircuit2Id = new Command { CommandName = "GetOptimizationBasisCircuit2Id", ErrorMessage = Ecl310ErrorMessages.GetOptimizationBasisCircuit2Id, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12019, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение требуемых температур" (11017 - 2 регистра)
        /// </summary>
        public Command GetRequiredTemperatures = new Command { CommandName = "GetRequiredTemperatures", ErrorMessage = Ecl310ErrorMessages.GetRequiredTemperatures, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11017, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение нагрузки охлаждения, контур 1" (11069 - 1 регистр)
        /// </summary>
        public Command GetCoolingLoadTemperatureCircuit1 = new Command { CommandName = "GetCoolingLoadTemperatureCircuit1", ErrorMessage = Ecl310ErrorMessages.GetCoolingLoadTemperatureCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11069, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// "Чтение температуры в режиме ожидания, контур 1" (11091 - 1 регистр)
        /// </summary>
        public Command GetExpectationFlowTemperatureCircuit1 = new Command { CommandName = "GetExpectationFlowTemperatureCircuit1", ErrorMessage = Ecl310ErrorMessages.GetExpectationFlowTemperatureCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11091, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение коэффициента параллельной работы, контур 1" (11042 - 1 регистр)
        /// </summary>
        public Command GetParallelOperationCircuit1 = new Command { CommandName = "GetParallelOperationCircuit1", ErrorMessage = Ecl310ErrorMessages.GetParallelOperationCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11042, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага автонастройки, контур 2" (12172 - 1 регистр)
        /// </summary>
        public Command GetAutotuningCircuit2 = new Command { CommandName = "GetAutotuningCircuit2", ErrorMessage = Ecl310ErrorMessages.GetAutotuningCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12172, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение параметров сигнализации, контур 1" (11078 - 2 регистра)
        /// </summary>
        public Command GetSignalizationParamsCircuit1 = new Command { CommandName = "GetSignalizationParamsCircuit1", ErrorMessage = Ecl310ErrorMessages.GetSignalizationParamsCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11078, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение аварийных границ давления, контур 1" (11613 - 2 регистра)
        /// </summary>
        public Command GetAccidentLimits = new Command { CommandName = "GetAccidentLimits", ErrorMessage = Ecl310ErrorMessages.GetAccidentLimits, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11613, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// "Чтение значений давления, контур 1" (11606 - 4 регистра)
        /// </summary>
        public Command GetPressureValues = new Command { CommandName = "GetPressureValues", ErrorMessage = Ecl310ErrorMessages.GetPressureValues, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11606, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// "Чтение флага сброса аварии насосов, контур 1" (11314 - 1 регистр)
        /// </summary>
        public Command GetAccidentPumpsCircuit1 = new Command { CommandName = "GetAccidentPumpsCircuit1", ErrorMessage = Ecl310ErrorMessages.GetAccidentPumpsCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11314, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага сброса аварии насосов, контур 2" (12314 - 1 регистр)
        /// </summary>
        public Command GetAccidentPumpsCircuit2 = new Command { CommandName = "GetAccidentPumpsCircuit2", ErrorMessage = Ecl310ErrorMessages.GetAccidentPumpsCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12314, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага сброса аварии подпитки, контур 1" (11323 - 1 регистр)
        /// </summary>
        public Command GetAccidentMakeupCircuit1 = new Command { CommandName = "GetAccidentMakeupCircuit1", ErrorMessage = Ecl310ErrorMessages.GetAccidentMakeupCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11323, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение флага сброса аварии подпитки, контур 2" (12323 - 1 регистр)
        /// </summary>
        public Command GetAccidentMakeupCircuit2 = new Command { CommandName = "GetAccidentMakeupCircuit1", ErrorMessage = Ecl310ErrorMessages.GetAccidentMakeupCircuit1, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12323, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение задержки аварии, контур 1" (11616 - 1 регистр)
        /// </summary>
        public Command GetAccidentFrostThermostatDelay = new Command { CommandName = "GetAccidentFrostThermostatDelay", ErrorMessage = Ecl310ErrorMessages.GetAccidentFrostThermostatDelay, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11616, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение количества насосов, контур 1" (11325 - 1 регистр)
        /// </summary>
        public Command GetHsPumpCount = new Command { CommandName = "GetHsPumpCount", ErrorMessage = Ecl310ErrorMessages.GetHsPumpCount, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11325, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение ограничения ГВС, контур 2" (12110 - 1 регистр)
        /// </summary>
        public Command GetFlowLimitationLimitCircuit2 = new Command { CommandName = "GetFlowLimitationLimitCircuit2", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationLimitCircuit2, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12110, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение единиц измерения, контур 2" (12114 - 1 регистр)
        /// </summary>
        public Command GetFlowLimitationUnitDict2Circuit2Id = new Command { CommandName = "GetFlowLimitationUnitDict2Circuit2Id", ErrorMessage = Ecl310ErrorMessages.GetFlowLimitationUnitDict2Circuit2Id, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 12114, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// "Чтение угла наклона кривой" (11174 - 1 регистр)
        /// </summary>
        public Command GetHeatCurveAngle = new Command { CommandName = "GetHeatCurveAngle", ErrorMessage = Ecl310ErrorMessages.GetHeatCurveAngle, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11174, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// "Чтение границы отключения отопления" (11178 - 1 регистр)
        /// </summary>
        public Command GetHeatingBorder = new Command { CommandName = "GetHeatingBorder", ErrorMessage = Ecl310ErrorMessages.GetHeatingBorder, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11178, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        
        
        /// <summary>
        /// Чтение PNU 11173
        /// </summary>
        public Command GetPnu11173 = new Command { CommandName = Ecl310Resources.GetPnu11173, ErrorMessage = Ecl310ErrorMessages.GetPnu11173, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11172, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение трех регистров 11185 - 11187
        /// </summary>
        public Command GetPnu11185_11187 = new Command { CommandName = Ecl310Resources.GetPnu11185_11187, ErrorMessage = Ecl310ErrorMessages.GetPnu11185_11187, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11184, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };
        /// <summary>
        /// Чтение PNU 11189
        /// </summary>
        public Command GetPnu11189 = new Command { CommandName = Ecl310Resources.GetPnu11189, ErrorMessage = Ecl310ErrorMessages.GetPnu11189, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11188, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение 4 регистров 11094-11097
        /// </summary>
        public Command GetPnu11094_11097 = new Command { CommandName = Ecl310Resources.GetPnu11094_11097, ErrorMessage = Ecl310ErrorMessages.GetPnu11094_11097, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11093, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение PNU 11076 
        /// </summary>
        public Command GetPnu11076 = new Command { CommandName = Ecl310Resources.GetPnu11076, ErrorMessage = Ecl310ErrorMessages.GetPnu11076, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11075, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение PNU 11040 
        /// </summary>
        public Command GetPnu11040 = new Command { CommandName = Ecl310Resources.GetPnu11040, ErrorMessage = Ecl310ErrorMessages.GetPnu11040, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11039, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
    }
}

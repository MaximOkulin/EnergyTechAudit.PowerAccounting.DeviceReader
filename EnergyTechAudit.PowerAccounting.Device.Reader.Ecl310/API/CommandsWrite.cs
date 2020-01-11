using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API
{
    internal sealed partial class Commands
    {
        // "Запись минимальной температуры подачи системы отопления"
        public Command SetMinHsFlowTemperature = new Command { CommandName = "SetMinHsFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHsFlowTemperature, CommandType = CommandType.Write, Code = 11176, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись максимальной температуры подачи системы отопления"
        public Command SetMaxHsFlowTemperature = new Command { CommandName = "SetMaxHsFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHsFlowTemperature, CommandType = CommandType.Write, Code = 11177, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись температуры отключения отопления"
        public Command SetHsHeatingOffTemperature = new Command { CommandName = "SetHsHeatingOffTemperature", ErrorMessage = Ecl310ErrorMessages.SetHsHeatingOffTemperature, CommandType = CommandType.Write, Code = 11178, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись желаемой дневной комнатной температуры"
        public Command SetHsComfortRoomTemperature = new Command { CommandName = "SetHsComfortRoomTemperature", ErrorMessage = Ecl310ErrorMessages.SetHsComfortRoomTemperature, CommandType = CommandType.Write, Code = 11179, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись желаемой ночной комнатной температуры"
        public Command SetHsSavingRoomTemperature = new Command { CommandName = "SetHsSavingRoomTemperature", ErrorMessage = Ecl310ErrorMessages.SetHsSavingRoomTemperature, CommandType = CommandType.Write, Code = 11180, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись максимального значения коэффициента влияния комнатной температуры, контур 1" (11181)
        /// </summary>
        public Command SetMaxHsInfluenceRoom = new Command { CommandName = "SetMaxHsInfluenceRoom", ErrorMessage = Ecl310ErrorMessages.SetMaxHsInfluenceRoom, CommandType = CommandType.Write, Code = 11181, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись максимального значения коэффициента влияния комнатной температуры, контур 1" (12181)
        /// </summary>
        public Command SetMaxHwsInfluenceRoom = new Command { CommandName = "SetMaxHwsInfluenceRoom", ErrorMessage = Ecl310ErrorMessages.SetMaxHwsInfluenceRoom, CommandType = CommandType.Write, Code = 12181, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимального значения коэффициента влияния комнатной температуры, контур 2" (11182)
        /// </summary>
        public Command SetMinHsInfluenceRoom = new Command { CommandName = "SetMinHsInfluenceRoom", ErrorMessage = Ecl310ErrorMessages.SetMinHsInfluenceRoom, CommandType = CommandType.Write, Code = 11182, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимального значения коэффициента влияния комнатной температуры, контур 2" (12182)
        /// </summary>
        public Command SetMinHwsInfluenceRoom = new Command { CommandName = "SetMinHwsInfluenceRoom", ErrorMessage = Ecl310ErrorMessages.SetMinHwsInfluenceRoom, CommandType = CommandType.Write, Code = 12182, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись коэффициента зоны пропорциональности системы отопления"
        public Command SetHsProportionalBand = new Command { CommandName = "SetHsProportionalBand", ErrorMessage = Ecl310ErrorMessages.SetHsProportionalBand, CommandType = CommandType.Write, Code = 11183, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись постоянной времени интегрирования системы отопления"
        public Command SetHsIntegrationTime = new Command { CommandName = "SetHsIntegrationTime", ErrorMessage = Ecl310ErrorMessages.SetHsIntegrationTime, CommandType = CommandType.Write, Code = 11184, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись времени перемещения штока привода системы отопления"
        public Command SetHsDriveStockTravelTime = new Command { CommandName = "SetHsDriveStockTravelTime", ErrorMessage = Ecl310ErrorMessages.SetHsDriveStockTravelTime, CommandType = CommandType.Write, Code = 11185, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись коэффициента нейтральной зоны системы отопления"
        public Command SetHsNeutralZone = new Command { CommandName = "SetHsNeutralZone", ErrorMessage = Ecl310ErrorMessages.SetHsNeutralZone, CommandType = CommandType.Write, Code = 11186, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись желаемой дневной температуры горячей воды"
        public Command SetHwsComfortRoomTemperature = new Command { CommandName = "SetHwsComfortRoomTemperature", ErrorMessage = Ecl310ErrorMessages.SetHwsComfortRoomTemperature, CommandType = CommandType.Write, Code = 12189, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись желаемой ночной температуры горячей воды"
        public Command SetHwsSavingRoomTemperature = new Command { CommandName = "SetHwsSavingRoomTemperature", ErrorMessage = Ecl310ErrorMessages.SetHwsSavingRoomTemperature, CommandType = CommandType.Write, Code = 12190, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись максимальной температуры открытого воздуха контура 1" (11030)
        /// </summary>
        public Command SetMaxHsOpenAirTemperature = new Command { CommandName = "SetMaxHsOpenAirTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHsOpenAirTemperature, CommandType = CommandType.Write, Code = 11030, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись максимальной температуры открытого воздуха контура 2" (12030)
        /// </summary>
        public Command SetMaxHwsOpenAirTemperature = new Command { CommandName = "SetMaxHwsOpenAirTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHwsOpenAirTemperature, CommandType = CommandType.Write, Code = 12030, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимальной температуры обратного трубопровода контура 1" (11031)
        /// </summary>
        public Command SetMinHsReverseTemperature = new Command { CommandName = "SetMinHsReverseTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHsReverseTemperature, CommandType = CommandType.Write, Code = 11031, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимальной температуры обратного трубопровода контура 2" (12031)
        /// </summary>
        public Command SetMinHwsReverseTemperature = new Command { CommandName = "SetMinHwsReverseTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHwsReverseTemperature, CommandType = CommandType.Write, Code = 12031, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимальной температуры открытого воздуха контура 1" (11032)
        /// </summary>
        public Command SetMinHsOpenAirTemperature = new Command { CommandName = "SetMinHsOpenAirTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHsOpenAirTemperature, CommandType = CommandType.Write, Code = 11032, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимальной температуры открытого воздуха контура 2" (12032)
        /// </summary>
        public Command SetMinHwsOpenAirTemperature = new Command { CommandName = "SetMinHwsOpenAirTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHwsOpenAirTemperature, CommandType = CommandType.Write, Code = 12032, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись максимальной температуры обратного трубопровода контура 1" (11033)
        /// </summary>
        public Command SetMaxHsReverseTemperature = new Command { CommandName = "SetMaxHsReverseTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHsReverseTemperature, CommandType = CommandType.Write, Code = 11033, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись максимальной температуры обратного трубопровода контура 2" (12033)
        /// </summary>
        public Command SetMaxHwsReverseTemperature = new Command { CommandName = "SetMaxHwsReverseTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHwsReverseTemperature, CommandType = CommandType.Write, Code = 12033, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        // "Запись максимального коэффициента влияния обратки системы отопления"
        public Command SetMaxHsInfluenceReverse = new Command { CommandName = "SetMaxHsInfluenceReverse", ErrorMessage = Ecl310ErrorMessages.SetMaxHsInfluenceReverse, CommandType = CommandType.Write, Code = 11034, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись минимального коэффициента влияния обратки системы отопления"
        public Command SetMinHsInfluenceReverse = new Command { CommandName = "SetMinHsInfluenceReverse", ErrorMessage = Ecl310ErrorMessages.SetMinHsInfluenceReverse, CommandType = CommandType.Write, Code = 11035, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись времени адаптации температуры в системе отопления"
        public Command SetHsOptimizationTime = new Command { CommandName = "SetHsOptimizationTime", ErrorMessage = Ecl310ErrorMessages.SetHsOptimizationTime, CommandType = CommandType.Write, Code = 11036, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись минимального времени активации привода системы отопления"
        public Command SetMinHsDriveActivationTime = new Command { CommandName = "SetMinHsDriveActivationTime", ErrorMessage = Ecl310ErrorMessages.SetMinHsDriveActivationTime, CommandType = CommandType.Write, Code = 11188, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при -30 для контура 1" (11399)
        /// </summary>
        public Command SetMinus30FlowTemperature = new Command { CommandName = "SetMinus30FlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinus30FlowTemperature, CommandType = CommandType.Write, Code = 11399, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при -30 для контура 2" (12399)
        /// </summary>
        public Command SetMinus30FlowTemperature2 = new Command { CommandName = "SetMinus30FlowTemperature2", ErrorMessage = Ecl310ErrorMessages.SetMinus30FlowTemperature2, CommandType = CommandType.Write, Code = 12399, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при -15 для контура 1" (11400)
        /// </summary>
        public Command SetMinus15FlowTemperature = new Command { CommandName = "SetMinus15FlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinus15FlowTemperature, CommandType = CommandType.Write, Code = 11400, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при -15 для контура 2" (12400)
        /// </summary>
        public Command SetMinus15FlowTemperature2 = new Command { CommandName = "SetMinus15FlowTemperature2", ErrorMessage = Ecl310ErrorMessages.SetMinus15FlowTemperature2, CommandType = CommandType.Write, Code = 12400, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при -5 для контура 1" (11401)
        /// </summary>
        public Command SetMinus5FlowTemperature = new Command { CommandName = "SetMinus5FlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinus5FlowTemperature, CommandType = CommandType.Write, Code = 11401, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при -5 для контура 2" (12401)
        /// </summary>
        public Command SetMinus5FlowTemperature2 = new Command { CommandName = "SetMinus5FlowTemperature2", ErrorMessage = Ecl310ErrorMessages.SetMinus5FlowTemperature2, CommandType = CommandType.Write, Code = 12401, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при 0 для контура 1" (11402)
        /// </summary>
        public Command SetZeroFlowTemperature = new Command { CommandName = "SetZeroFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetZeroFlowTemperature, CommandType = CommandType.Write, Code = 11402, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при 0 для контура 2" (12402)
        /// </summary>
        public Command SetZeroFlowTemperature2 = new Command { CommandName = "SetZeroFlowTemperature2", ErrorMessage = Ecl310ErrorMessages.SetZeroFlowTemperature2, CommandType = CommandType.Write, Code = 12402, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при +5 для контура 1" (11403)
        /// </summary>
        public Command SetPlus5FlowTemperature = new Command { CommandName = "SetPlus5FlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetPlus5FlowTemperature, CommandType = CommandType.Write, Code = 11403, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при +5 для контура 2" (12403)
        /// </summary>
        public Command SetPlus5FlowTemperature2 = new Command { CommandName = "SetPlus5FlowTemperature2", ErrorMessage = Ecl310ErrorMessages.SetPlus5FlowTemperature2, CommandType = CommandType.Write, Code = 12403, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при +15 для контура 1" (11404)
        /// </summary>
        public Command SetPlus15FlowTemperature = new Command { CommandName = "SetPlus15FlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetPlus15FlowTemperature, CommandType = CommandType.Write, Code = 11404, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись точки температурного графика при +15 для контура 2" (12404)
        /// </summary>
        public Command SetPlus15FlowTemperature2 = new Command { CommandName = "SetPlus15FlowTemperature2", ErrorMessage = Ecl310ErrorMessages.SetPlus15FlowTemperature2, CommandType = CommandType.Write, Code = 12404, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        // "Запись ограничения температуры обратки ГВС"
        public Command SetHwsLimitReverseTemperature = new Command { CommandName = "SetHwsLimitReverseTemperature", ErrorMessage = Ecl310ErrorMessages.SetHwsLimitReverseTemperature, CommandType = CommandType.Write, Code = 12029, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись максимального коэффициента влияния обратного контура ГВС"
        public Command SetMaxHwsInfluenceReverse = new Command { CommandName = "SetMaxHwsInfluenceReverse", ErrorMessage = Ecl310ErrorMessages.SetMaxHwsInfluenceReverse, CommandType = CommandType.Write, Code = 12034, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись минимального коэффициента влияния обратного контура ГВС"
        public Command SetMinHwsInfluenceReverse = new Command { CommandName = "SetMinHwsInfluenceReverse", ErrorMessage = Ecl310ErrorMessages.SetMinHwsInfluenceReverse, CommandType = CommandType.Write, Code = 12035, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись времени адаптации температуры в ГВС"
        public Command SetHwsOptimizationTime = new Command { CommandName = "SetHwsOptimizationTime", ErrorMessage = Ecl310ErrorMessages.SetHwsOptimizationTime, CommandType = CommandType.Write, Code = 12036, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись минимальной температуры подачи ГВС"
        public Command SetMinHwsFlowTemperature = new Command { CommandName = "SetMinHwsFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHwsFlowTemperature, CommandType = CommandType.Write, Code = 12176, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись максимальной температуры подачи ГВС"
        public Command SetMaxHwsFlowTemperature = new Command { CommandName = "SetMaxHwsFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHwsFlowTemperature, CommandType = CommandType.Write, Code = 12177, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись температуры отключения отопления контура 2" (12178)
        /// </summary>
        public Command SetHwsHeatingOffTemperature = new Command { CommandName = "SetHwsHeatingOffTemperature", ErrorMessage = Ecl310ErrorMessages.SetHwsHeatingOffTemperature, CommandType = CommandType.Write, Code = 12178, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись желаемой комнатной дневной температуры контура 2" (12179)
        /// </summary>
        public Command SetHsComfortRoomTemperatureCircuit2 = new Command { CommandName = "SetHsComfortRoomTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.SetHsComfortRoomTemperatureCircuit2, CommandType = CommandType.Write, Code = 12179, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись желаемой комнатной ночной температуры контура 2" (12180)
        /// </summary>
        public Command SetHsSavingRoomTemperatureCircuit2 = new Command { CommandName = "SetHsSavingRoomTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.SetHsSavingRoomTemperatureCircuit2, CommandType = CommandType.Write, Code = 12180, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись зоны пропорциональности ГВС"
        public Command SetHwsProportionalBand = new Command { CommandName = "SetHwsProportionalBand", ErrorMessage = Ecl310ErrorMessages.SetHwsProportionalBand, CommandType = CommandType.Write, Code = 12183, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись постоянной времени интегрирования ГВС"
        public Command SetHwsIntegrationTime = new Command { CommandName = "SetHwsIntegrationTime", ErrorMessage = Ecl310ErrorMessages.SetHwsIntegrationTime, CommandType = CommandType.Write, Code = 12184, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись времени перемещения штока привода ГВС"
        public Command SetHwsDriveStockTravelTime = new Command { CommandName = "SetHwsDriveStockTravelTime", ErrorMessage = Ecl310ErrorMessages.SetHwsDriveStockTravelTime, CommandType = CommandType.Write, Code = 12185, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись коэффициента нейтральной зоны ГВС"
        public Command SetHwsNeutralZone = new Command { CommandName = "SetHwsNeutralZone", ErrorMessage = Ecl310ErrorMessages.SetHwsNeutralZone, CommandType = CommandType.Write, Code = 12186, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись минимального времени активации привода ГВС"
        public Command SetMinHwsDriveActivationTime = new Command { CommandName = "SetMinHwsDriveActivationTime", ErrorMessage = Ecl310ErrorMessages.SetMinHwsDriveActivationTime, CommandType = CommandType.Write, Code = 12188, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись режима работы контура 1"
        public Command SetCircuit1OperatingMode = new Command { CommandName = "SetCircuit1OperatingMode", ErrorMessage = Ecl310ErrorMessages.SetCircuit1OperatingMode, CommandType = CommandType.Write, Code = 4200, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись режима работы контура 2"
        public Command SetCircuit2OperatingMode = new Command { CommandName = "SetCircuit2OperatingMode", ErrorMessage = Ecl310ErrorMessages.SetCircuit2OperatingMode, CommandType = CommandType.Write, Code = 4201, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        // "Запись статуса работы контура 1"
        public Command SetCircuit1OperatingStatus = new Command { CommandName = "SetCircuit1OperatingStatus", ErrorMessage = Ecl310ErrorMessages.SetCircuit2OperatingStatus, CommandType = CommandType.Write, Code = 4210, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись статуса работы контура 2"
        public Command SetCircuit2OperatingStatus = new Command { CommandName = "SetCircuit2OperatingStatus", ErrorMessage = Ecl310ErrorMessages.SetCircuit2OperatingStatus, CommandType = CommandType.Write, Code = 4211, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        // "Запись времени принудительного открытия клапана ГВС"
        public Command SetForcedOpeningTime = new Command { CommandName = "SetForcedOpeningTime", ErrorMessage = Ecl310ErrorMessages.SetForcedOpeningTime, CommandType = CommandType.Write, Code = 12093, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись времени принудительного закрытия клапана ГВС"
        public Command SetForcedClosingTime = new Command { CommandName = "SetForcedClosingTime", ErrorMessage = Ecl310ErrorMessages.SetForcedClosingTime, CommandType = CommandType.Write, Code = 12094, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись холостого времени ГВС"
        public Command SetHwsIdleTime = new Command { CommandName = "SetHwsIdleTime", ErrorMessage = Ecl310ErrorMessages.SetHwsIdleTime, CommandType = CommandType.Write, Code = 12095, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись выбора температуры подачи ГВС"
        public Command SetHwsFlowTemperatureIdle = new Command { CommandName = "SetHwsFlowTemperatureIdle", ErrorMessage = Ecl310ErrorMessages.SetHwsFlowTemperatureIdle, CommandType = CommandType.Write, Code = 12096, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись верхнего значения температуры подачи системы отопления X2" (11299)
        /// </summary>
        public Command SetMaxHsSetFlowTemperature = new Command { CommandName = "SetMaxHsSetFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHsSetFlowTemperature, CommandType = CommandType.Write, Code = 11299, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись верхнего значения температуры подачи ГВС X2" (12299)
        /// </summary>
        public Command SetMaxHwsSetFlowTemperature = new Command { CommandName = "SetMaxHsSetFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHsSetFlowTemperature, CommandType = CommandType.Write, Code = 12299, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись верхнего значения максимальной границы системы отопления Y2" (11300)
        /// </summary>
        public Command SetMaxHsBorderFlowTemperature = new Command { CommandName = "SetMaxHsBorderFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHsBorderFlowTemperature, CommandType = CommandType.Write, Code = 11300, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись верхнего значения максимальной границы ГВС Y2" (12300)
        /// </summary>
        public Command SetMaxHwsBorderFlowTemperature = new Command { CommandName = "SetMaxHwsBorderFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMaxHwsBorderFlowTemperature, CommandType = CommandType.Write, Code = 12300, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нижнего значения температуры подачи X1 системы отопления" (11301)
        /// </summary>
        public Command SetMinHsSetFlowTemperature = new Command { CommandName = "SetMinHsSetFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHsSetFlowTemperature, CommandType = CommandType.Write, Code = 11301, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нижнего значения температуры подачи X1 ГВС" (12301)
        /// </summary>
        public Command SetMinHwsSetFlowTemperature = new Command { CommandName = "SetMinHwsSetFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHwsSetFlowTemperature, CommandType = CommandType.Write, Code = 12301, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нижнего значения максимальной границы отопления Y1" (11302)
        /// </summary>
        public Command SetMinHsBorderFlowTemperature = new Command { CommandName = "SetMinHsBorderFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHsBorderFlowTemperature, CommandType = CommandType.Write, Code = 11302, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нижнего значения максимальной границы ГВС Y1" (12302)
        /// </summary>
        public Command SetMinHwsBorderFlowTemperature = new Command { CommandName = "SetMinHwsBorderFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetMinHwsBorderFlowTemperature, CommandType = CommandType.Write, Code = 12302, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени повтора при регулировании насосов контура 1" (11309)
        /// </summary>
        public Command SetHsPumpIterationTime = new Command { CommandName = "SetHsPumpIterationTime", ErrorMessage = Ecl310ErrorMessages.SetHsPumpIterationTime, CommandType = CommandType.Write, Code = 11309, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени повтора при регулировании насосов контура 2" (12309)
        /// </summary>
        public Command SetHwsPumpIterationTime = new Command { CommandName = "SetHwsPumpIterationTime", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpIterationTime, CommandType = CommandType.Write, Code = 12309, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись длительности смены при регулировании насосов контура 1" (11310)
        /// </summary>
        public Command SetHsPumpChangePeriod = new Command { CommandName = "SetHsPumpChangePeriod", ErrorMessage = Ecl310ErrorMessages.SetHsPumpChangePeriod, CommandType = CommandType.Write, Code = 11310, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись длительности смены при регулировании насосов контура 2" (12310)
        /// </summary>
        public Command SetHwsPumpChangePeriod = new Command { CommandName = "SetHwsPumpChangePeriod", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpChangePeriod, CommandType = CommandType.Write, Code = 12310, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись часа смены при регулировании насосов контура 1" (11311)
        /// </summary>
        public Command SetHsPumpChangeHour = new Command { CommandName = "SetHsPumpChangeHour", ErrorMessage = Ecl310ErrorMessages.SetHsPumpChangeHour, CommandType = CommandType.Write, Code = 11311, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись часа смены при регулировании насосов контура 2" (12311)
        /// </summary>
        public Command SetHwsPumpChangeHour = new Command { CommandName = "SetHwsPumpChangeHour", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpChangeHour, CommandType = CommandType.Write, Code = 12311, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени стабилизации при регулировании насосов контура 1" (11312)
        /// </summary>
        public Command SetHsPumpStabilizationTime = new Command { CommandName = "SetHsPumpStabilizationTime", ErrorMessage = Ecl310ErrorMessages.SetHsPumpStabilizationTime, CommandType = CommandType.Write, Code = 11312, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени стабилизации при регулировании насосов контура 2" (12312)
        /// </summary>
        public Command SetHwsPumpStabilizationTime = new Command { CommandName = "SetHwsPumpStabilizationTime", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpStabilizationTime, CommandType = CommandType.Write, Code = 12312, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени переключения при регулировании насосов контура 1" (11313)
        /// </summary>
        public Command SetHsPumpSwitchingTime = new Command { CommandName = "SetHsPumpSwitchingTime", ErrorMessage = Ecl310ErrorMessages.SetHsPumpSwitchingTime, CommandType = CommandType.Write, Code = 11313, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени переключения при регулировании насосов контура 2" (12313)
        /// </summary>
        public Command SetHwsPumpSwitchingTime = new Command { CommandName = "SetHwsPumpSwitchingTime", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpSwitchingTime, CommandType = CommandType.Write, Code = 12313, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени профилактики насоса системы отопления" (11021)
        /// </summary>
        public Command SetHsPumpTrainingTime = new Command { CommandName = "SetHsPumpTrainingTime", ErrorMessage = Ecl310ErrorMessages.SetHsPumpTrainingTime, CommandType = CommandType.Write, Code = 11021, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени тестирования насоса подпитки контура 1" (11319)
        /// </summary>
        public Command SetHsSupplyPumpTrainingTime = new Command { CommandName = "SetHsSupplyPumpTrainingTime", ErrorMessage = Ecl310ErrorMessages.SetHsSupplyPumpTrainingTime, CommandType = CommandType.Write, Code = 11319, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени тестирования насоса подпитки контура 2" (12319)
        /// </summary>
        public Command SetHwsSupplyPumpTrainingTime = new Command { CommandName = "SetHwsSupplyPumpTrainingTime", ErrorMessage = Ecl310ErrorMessages.SetHwsSupplyPumpTrainingTime, CommandType = CommandType.Write, Code = 12319, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись требуемого давления для системы подпитки контура 1" (11320)
        /// </summary>
        public Command SetHsPumpRequiredPressure = new Command { CommandName = "SetHsPumpRequiredPressure", ErrorMessage = Ecl310ErrorMessages.SetHsPumpRequiredPressure, CommandType = CommandType.Write, Code = 11320, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись требуемого давления для системы подпитки контура 2" (12320)
        /// </summary>
        public Command SetHwsPumpRequiredPressure = new Command { CommandName = "SetHwsPumpRequiredPressure", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpRequiredPressure, CommandType = CommandType.Write, Code = 12320, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись разницы переключения давления для системы подпитки контура 1" (11321)
        /// </summary>
        public Command SetHsPumpSwitchingDiff = new Command { CommandName = "SetHsPumpSwitchingDiff", ErrorMessage = Ecl310ErrorMessages.SetHsPumpSwitchingDiff, CommandType = CommandType.Write, Code = 11321, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись разницы переключения давления для системы подпитки контура 2" (12321)
        /// </summary>
        public Command SetHwsPumpSwitchingDiff = new Command { CommandName = "SetHwsPumpSwitchingDiff", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpSwitchingDiff, CommandType = CommandType.Write, Code = 12321, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись длительности долива для системы подпитки контура 1" (11322)
        /// </summary>
        public Command SetHsPumpToppingDuration = new Command { CommandName = "SetHsPumpToppingDuration", ErrorMessage = Ecl310ErrorMessages.SetHsPumpToppingDuration, CommandType = CommandType.Write, Code = 11322, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись длительности долива для системы подпитки контура 2" (12322)
        /// </summary>
        public Command SetHwsPumpToppingDuration = new Command { CommandName = "SetHwsPumpToppingDuration", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpToppingDuration, CommandType = CommandType.Write, Code = 12322, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись ожидания перед открытием клапана" (11324)
        /// </summary>
        public Command SetHsWaitOpenValveTime = new Command { CommandName = "SetHsWaitOpenValveTime", ErrorMessage = Ecl310ErrorMessages.SetHsWaitOpenValveTime, CommandType = CommandType.Write, Code = 11324, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись ожидания перед открытием клапана, контур 2" (12324)
        /// </summary>
        public Command SetHwsWaitOpenValveTime = new Command { CommandName = "SetHwsWaitOpenValveTime", ErrorMessage = Ecl310ErrorMessages.SetHwsWaitOpenValveTime, CommandType = CommandType.Write, Code = 12324, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись количества насосов" (11325)
        /// </summary>
        public Command SetHsPumpCount = new Command { CommandName = "SetHsPumpCount", ErrorMessage = Ecl310ErrorMessages.SetHsPumpCount, CommandType = CommandType.Write, Code = 11325, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись количества насосов, контур 2" (12325)
        /// </summary>
        public Command SetHwsPumpCount = new Command { CommandName = "SetHwsPumpCount", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpCount, CommandType = CommandType.Write, Code = 12325, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись типа входного сигнала давления контура 1" (11326)
        /// </summary>
        public Command SetEcl310PressureInputSignalTypeId = new Command { CommandName = "SetEcl310PressureInputSignalTypeId", ErrorMessage = Ecl310ErrorMessages.SetEcl310PressureInputSignalTypeId, CommandType = CommandType.Write, Code = 11326, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись типа входного сигнала давления контура 2" (12326)
        /// </summary>
        public Command SetEcl310PressureInputSignalType2Id = new Command { CommandName = "SetEcl310PressureInputSignalType2Id", ErrorMessage = Ecl310ErrorMessages.SetEcl310PressureInputSignalType2Id, CommandType = CommandType.Write, Code = 12326, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени профилактики насоса ГВС" (12021)
        /// </summary>
        public Command SetHwsPumpTrainingTime = new Command { CommandName = "SetHwsPumpTrainingTime", ErrorMessage = Ecl310ErrorMessages.SetHwsPumpTrainingTime, CommandType = CommandType.Write, Code = 12021, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись количества насосов" (10325)
        /// </summary>
        public Command SetPumpCount = new Command { CommandName = "SetPumpCount", ErrorMessage = Ecl310ErrorMessages.SetPumpCount, CommandType = CommandType.Write, Code = 10325, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись использования внешнего сигнала в контуре 1" (11083)
        /// </summary>
        public Command SetHsExternalSignal = new Command { CommandName = "SetHsExternalSignal", ErrorMessage = Ecl310ErrorMessages.SetHsExternalSignal, CommandType = CommandType.Write, Code = 11083, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись ограничения температуры контура 1 (компенсация точка 1)" (11059)
        /// </summary>
        public Command SetHsCompensation1Temperature = new Command { CommandName = "SetHsCompensation1Temperature", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation1Temperature, CommandType = CommandType.Write, Code = 11059, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени оптимизации контура 1 (компенсация точка 1)" (11060)
        /// </summary>
        public Command SetHsCompensation1OptimizationTime = new Command { CommandName = "SetHsCompensation1OptimizationTime", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation1OptimizationTime, CommandType = CommandType.Write, Code = 11060, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Максимальное влияние контура 1 (компенсация точка 1)" (11061)
        /// </summary>
        public Command SetHsCompensation1MaxInfluence = new Command { CommandName = "SetHsCompensation1MaxInfluence", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation1MaxInfluence, CommandType = CommandType.Write, Code = 11061, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Минимальное влияние контура 1 (компенсация точка 1)" (11062)
        /// </summary>
        public Command SetHsCompensation1MinInfluence = new Command { CommandName = "SetHsCompensation1MinInfluence", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation1MinInfluence, CommandType = CommandType.Write, Code = 11062, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись ограничения температуры контура 1 (компенсация точка 2)" (11063)
        /// </summary>
        public Command SetHsCompensation2Temperature = new Command { CommandName = "SetHsCompensation2Temperature", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation2Temperature, CommandType = CommandType.Write, Code = 11063, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени оптимизации контура 1 (компенсация точка 2)" (11064)
        /// </summary>
        public Command SetHsCompensation2OptimizationTime = new Command { CommandName = "SetHsCompensation2OptimizationTime", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation2OptimizationTime, CommandType = CommandType.Write, Code = 11064, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Максимальное влияние контура 1 (компенсация точка 2)" (11065)
        /// </summary>
        public Command SetHsCompensation2MaxInfluence = new Command { CommandName = "SetHsCompensation2MaxInfluence", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation2MaxInfluence, CommandType = CommandType.Write, Code = 11065, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Минимальное влияние контура 1 (компенсация точка 2)" (11066)
        /// </summary>
        public Command SetHsCompensation2MinInfluence = new Command { CommandName = "SetHsCompensation2MinInfluence", ErrorMessage = Ecl310ErrorMessages.SetHsCompensation2MinInfluence, CommandType = CommandType.Write, Code = 11066, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись коэффициента максимального влияния ветра" (11056)
        /// </summary>
        public Command SetHsMaxWindInfluence = new Command { CommandName = "SetHsMaxWindInfluence", ErrorMessage = Ecl310ErrorMessages.SetHsMaxWindInfluence, CommandType = CommandType.Write, Code = 11056, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись фильтра ветра" (11080)
        /// </summary>
        public Command SetHsWindFilter = new Command { CommandName = "SetHsWindFilter", ErrorMessage = Ecl310ErrorMessages.SetHsWindFilter, CommandType = CommandType.Write, Code = 11080, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись ограничения ветра" (11098)
        /// </summary>
        public Command SetHsWindLimit = new Command { CommandName = "SetHsWindLimit", ErrorMessage = Ecl310ErrorMessages.SetHsWindLimit, CommandType = CommandType.Write, Code = 11098, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись ограничения температуры обратного трубопровода контура 1" (11029)
        /// </summary>
        public Command SetHsLimitReverseTemperature = new Command { CommandName = "SetHsLimitReverseTemperature", ErrorMessage = Ecl310ErrorMessages.SetHsLimitReverseTemperature, CommandType = CommandType.Write, Code = 11029, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись заданной балансовой температуры" (11007)
        /// </summary>
        public Command SetAdjustedBalanceTemperature = new Command { CommandName = "SetAdjustedBalanceTemperature", ErrorMessage = Ecl310ErrorMessages.SetAdjustedBalanceTemperature, CommandType = CommandType.Write, Code = 11007, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись коэффициента мертвой зоны" (11008)
        /// </summary>
        public Command SetDeadBand = new Command { CommandName = "SetDeadBand", ErrorMessage = Ecl310ErrorMessages.SetDeadBand, CommandType = CommandType.Write, Code = 11008, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись скорости адаптации комнатной температуры, контур 1" (11014)
        /// </summary>
        public Command SetOptimizationTime = new Command { CommandName = "SetOptimizationTime", ErrorMessage = Ecl310ErrorMessages.SetOptimizationTime, CommandType = CommandType.Write, Code = 11014, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись скорости адаптации комнатной температуры, контур 2" (12014)
        /// </summary>
        public Command SetOptimizationTimeCircuit2 = new Command { CommandName = "SetOptimizationTimeCircuit2", ErrorMessage = Ecl310ErrorMessages.SetOptimizationTimeCircuit2, CommandType = CommandType.Write, Code = 12014, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись предельной температуры замерзания" (11107)
        /// </summary>
        public Command SetLimitFreezeTemperature = new Command { CommandName = "SetLimitFreezeTemperature", ErrorMessage = Ecl310ErrorMessages.SetLimitFreezeTemperature, CommandType = CommandType.Write, Code = 11107, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись мин. влияния предельной безопасной температуры" (11104)
        /// </summary>
        public Command SetMinLimitFreezeInfluence = new Command { CommandName = "SetMinLimitFreezeInfluence", ErrorMessage = Ecl310ErrorMessages.SetMinLimitFreezeInfluence, CommandType = CommandType.Write, Code = 11104, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записи времени оптимизации предельной безопасной температуры" (11106)
        /// </summary>
        public Command SetLimitFreezeOptimizationTime = new Command { CommandName = "SetLimitFreezeOptimizationTime", ErrorMessage = Ecl310ErrorMessages.SetLimitFreezeOptimizationTime, CommandType = CommandType.Write, Code = 11106, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени защиты двигателя" (11173)
        /// </summary>
        public Command SetMotorProtection = new Command { CommandName = "SetMotorProtection", ErrorMessage = Ecl310ErrorMessages.SetMotorProtection, CommandType = CommandType.Write, Code = 11173, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени защиты двигателя регулятора 2" (12173)
        /// </summary>
        public Command SetMotorProtection2 = new Command { CommandName = "SetMotorProtection2", ErrorMessage = Ecl310ErrorMessages.SetMotorProtection2, CommandType = CommandType.Write, Code = 12173, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись максимального выходного напряжения" (12164)
        /// </summary>
        public Command SetMaxOutputVoltage = new Command { CommandName = "SetMaxOutputVoltage", ErrorMessage = Ecl310ErrorMessages.SetMaxOutputVoltage, CommandType = CommandType.Write, Code = 12164, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимального выходного напряжения" (12166)
        /// </summary>
        public Command SetMinOutputVoltage = new Command { CommandName = "SetMinOutputVoltage", ErrorMessage = Ecl310ErrorMessages.SetMinOutputVoltage, CommandType = CommandType.Write, Code = 12166, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись реверса" (12170)
        /// </summary>
        public Command SetReverse = new Command { CommandName = "SetReverse", ErrorMessage = Ecl310ErrorMessages.SetReverse, CommandType = CommandType.Write, Code = 12170, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись задержки включения вентилятора" (11085)
        /// </summary>
        public Command SetFanDelay = new Command { CommandName = "SetFanDelay", ErrorMessage = Ecl310ErrorMessages.SetFanDelay, CommandType = CommandType.Write, Code = 11085, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись задержки включения вспомогательного оборудования" (11086)
        /// </summary>
        public Command SetPermissibleDelay = new Command { CommandName = "SetPermissibleDelay", ErrorMessage = Ecl310ErrorMessages.SetPermissibleDelay, CommandType = CommandType.Write, Code = 11086, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись функции выхода вентилятора" (11087)
        /// </summary>
        public Command SetFanOutputFunction = new Command { CommandName = "SetFanOutputFunction", ErrorMessage = Ecl310ErrorMessages.SetFanOutputFunction, CommandType = CommandType.Write, Code = 11087, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись функции выхода вспомогательного оборудования (заслонки)" (11088)
        /// </summary>
        public Command SetFlapOutputFunction = new Command { CommandName = "SetFlapOutputFunction", ErrorMessage = Ecl310ErrorMessages.SetFlapOutputFunction, CommandType = CommandType.Write, Code = 11088, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись дополнительной функции реле 3" (11089)
        /// </summary>
        public Command SetRelay3Function = new Command { CommandName = "SetRelay3Function", ErrorMessage = Ecl310ErrorMessages.SetRelay3Function, CommandType = CommandType.Write, Code = 11089, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись программы реле 2" (11090)
        /// </summary>
        public Command SetRelay2Programm = new Command { CommandName = "SetRelay2Programm", ErrorMessage = Ecl310ErrorMessages.SetRelay2Programm, CommandType = CommandType.Write, Code = 11090, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись коэффициента разницы заданных комнатных температур" (11026)
        /// </summary>
        public Command SetRoomTemperaturesDiff = new Command { CommandName = "SetRoomTemperaturesDiff", ErrorMessage = Ecl310ErrorMessages.SetRoomTemperaturesDiff, CommandType = CommandType.Write, Code = 11026, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись температуры защиты от замерзания" (11076)
        /// </summary>
        public Command SetFrostProtectionTemperature = new Command { CommandName = "SetFrostProtectionTemperature", ErrorMessage = Ecl310ErrorMessages.SetFrostProtectionTemperature, CommandType = CommandType.Write, Code = 11076, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись функции вентилятора" (11136)
        /// </summary>
        public Command SetFanFunction = new Command { CommandName = "SetFanFunction", ErrorMessage = Ecl310ErrorMessages.SetFanFunction, CommandType = CommandType.Write, Code = 11136, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись фильтра S4" (10303)
        /// </summary>
        public Command SetS4Filter = new Command { CommandName = "SetS4Filter", ErrorMessage = Ecl310ErrorMessages.SetS4Filter, CommandType = CommandType.Write, Code = 10303, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись адреса ECA" (11009)
        /// </summary>
        public Command SetEcaAddressId = new Command { CommandName = "SetEcaAddressId", ErrorMessage = Ecl310ErrorMessages.SetEcaAddressId, CommandType = CommandType.Write, Code = 11009, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись адреса ECA, контур 2" (12009)
        /// </summary>
        public Command SetEcaAddressCircuit2Id = new Command { CommandName = "SetEcaAddressCircuit2Id", ErrorMessage = Ecl310ErrorMessages.SetEcaAddressCircuit2Id, CommandType = CommandType.Write, Code = 12009, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись флага полного отключения, контур 1" (11020)
        /// </summary>
        public Command SetBlackout = new Command { CommandName = "SetBlackout", ErrorMessage = Ecl310ErrorMessages.SetBlackout, CommandType = CommandType.Write, Code = 11020, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись флага полного отключения, контур 2" (12020)
        /// </summary>
        public Command SetBlackoutCircuit2 = new Command { CommandName = "SetBlackoutCircuit2", ErrorMessage = Ecl310ErrorMessages.SetBlackoutCircuit2, CommandType = CommandType.Write, Code = 12020, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись времени перехода между режимами" (11081)
        /// </summary>
        public Command SetTransitionModeTime = new Command { CommandName = "SetTransitionModeTime", ErrorMessage = Ecl310ErrorMessages.SetTransitionModeTime, CommandType = CommandType.Write, Code = 11081, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись температуры защиты от замерзания" (11092)
        /// </summary>
        public Command SetFrostProtectionTemperature2 = new Command { CommandName = "SetFrostProtectionTemperature2", ErrorMessage = Ecl310ErrorMessages.SetFrostProtectionTemperature2, CommandType = CommandType.Write, Code = 11092, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись флага выбора компенсационной температуры" (11139)
        /// </summary>
        public Command SetSelectionCompensationTemperature = new Command { CommandName = "SetSelectionCompensationTemperature", ErrorMessage = Ecl310ErrorMessages.SetSelectionCompensationTemperature, CommandType = CommandType.Write, Code = 11139, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись внешнего входа ECL 210, контур 1" (11140)
        /// </summary>
        public Command SetExternalInputEcl210 = new Command { CommandName = "SetExternalInputEcl210", ErrorMessage = Ecl310ErrorMessages.SetExternalInputEcl210, CommandType = CommandType.Write, Code = 11140, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись внешнего входа ECL 210, контур 2" (12140)
        /// </summary>
        public Command SetExternalInputEcl210Circuit2 = new Command { CommandName = "SetExternalInputEcl210Circuit2", ErrorMessage = Ecl310ErrorMessages.SetExternalInputEcl210Circuit2, CommandType = CommandType.Write, Code = 12140, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись режима внешней перенастройки, контур 1" (11141)
        /// </summary>
        public Command SetExternalOverrideModeId = new Command { CommandName = "SetExternalOverrideModeId", ErrorMessage = Ecl310ErrorMessages.SetExternalOverrideModeId, CommandType = CommandType.Write, Code = 11141, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись режима внешней перенастройки, контур 2" (12141)
        /// </summary>
        public Command SetExternalOverrideModeCircuit2Id = new Command { CommandName = "SetExternalOverrideModeCircuit2Id", ErrorMessage = Ecl310ErrorMessages.SetExternalOverrideModeCircuit2Id, CommandType = CommandType.Write, Code = 12141, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись флага посылки заданной температуры" (11499)
        /// </summary>
        public Command SetSendPredeterminedTemperature = new Command { CommandName = "SetSendPredeterminedTemperature", ErrorMessage = Ecl310ErrorMessages.SetSendPredeterminedTemperature, CommandType = CommandType.Write, Code = 11499, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись аварийной температуры замерзания S6" (11675)
        /// </summary>
        public Command SetAccidentS6FreezingTemperature = new Command { CommandName = "SetAccidentS6FreezingTemperature", ErrorMessage = Ecl310ErrorMessages.SetAccidentS6FreezingTemperature, CommandType = CommandType.Write, Code = 11675, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись аварийной температуры замерзания S5" (11655)
        /// </summary>
        public Command SetAccidentS5FreezingTemperature = new Command { CommandName = "SetAccidentS5FreezingTemperature", ErrorMessage = Ecl310ErrorMessages.SetAccidentS5FreezingTemperature, CommandType = CommandType.Write, Code = 11655, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись аварийного значения термостата замерзания" (11615)
        /// </summary>
        public Command SetAccidentFrostThermostat = new Command { CommandName = "SetAccidentFrostThermostat", ErrorMessage = Ecl310ErrorMessages.SetAccidentFrostThermostat, CommandType = CommandType.Write, Code = 11615, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись задержки аварии термостата замерзания" (11616)
        /// </summary>
        public Command SetAccidentFrostThermostatDelay = new Command { CommandName = "SetAccidentFrostThermostatDelay", ErrorMessage = Ecl310ErrorMessages.SetAccidentFrostThermostatDelay, CommandType = CommandType.Write, Code = 11616, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись аварийного значения термостата пожаробезопасности" (11635)
        /// </summary>
        public Command SetAccidentFireSafetyThermostat = new Command { CommandName = "SetAccidentFireSafetyThermostat", ErrorMessage = Ecl310ErrorMessages.SetAccidentFireSafetyThermostat, CommandType = CommandType.Write, Code = 11635, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись задержки аварии термостата пожаробезопасности" (11636)
        /// </summary>
        public Command SetAccidentFireSafetyThermostatDelay = new Command { CommandName = "SetAccidentFireSafetyThermostatDelay", ErrorMessage = Ecl310ErrorMessages.SetAccidentFireSafetyThermostatDelay, CommandType = CommandType.Write, Code = 11636, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись верхней разницы температурного монитора, контур 1" (11146)
        /// </summary>
        public Command SetUpperDifferenceTemperatureMonitor = new Command { CommandName = "SetUpperDifferenceTemperatureMonitor", ErrorMessage = Ecl310ErrorMessages.SetUpperDifferenceTemperatureMonitor, CommandType = CommandType.Write, Code = 11146, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись верхней разницы температурного монитора, контур 2" (12146)
        /// </summary>
        public Command SetUpperDifferenceTemperatureMonitorCircuit2 = new Command { CommandName = "SetUpperDifferenceTemperatureMonitorCircuit2", ErrorMessage = Ecl310ErrorMessages.SetUpperDifferenceTemperatureMonitorCircuit2, CommandType = CommandType.Write, Code = 12146, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нижней разницы температурного монитора, контур 1" (11147)
        /// </summary>
        public Command SetLowerDifferenceTemperatureMonitor = new Command { CommandName = "SetLowerDifferenceTemperatureMonitor", ErrorMessage = Ecl310ErrorMessages.SetLowerDifferenceTemperatureMonitor, CommandType = CommandType.Write, Code = 11147, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нижней разницы температурного монитора, контур 2" (12147)
        /// </summary>
        public Command SetLowerDifferenceTemperatureMonitorCircuit2 = new Command { CommandName = "SetLowerDifferenceTemperatureMonitorCircuit2", ErrorMessage = Ecl310ErrorMessages.SetLowerDifferenceTemperatureMonitorCircuit2, CommandType = CommandType.Write, Code = 12147, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись паузы температурного монитора, контур 1" (11148)
        /// </summary>
        public Command SetPauseTemperatureMonitor = new Command { CommandName = "SetPauseTemperatureMonitor", ErrorMessage = Ecl310ErrorMessages.SetPauseTemperatureMonitor, CommandType = CommandType.Write, Code = 11148, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись паузы температурного монитора, контур 2" (12148)
        /// </summary>
        public Command SetPauseTemperatureMonitorCircuit2 = new Command { CommandName = "SetPauseTemperatureMonitorCircuit2", ErrorMessage = Ecl310ErrorMessages.SetPauseTemperatureMonitorCircuit2, CommandType = CommandType.Write, Code = 12148, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимальной температуры температурного монитора, контур 1" (11149)
        /// </summary>
        public Command SetMinTemperatureMonitor = new Command { CommandName = "SetMinTemperatureMonitor", ErrorMessage = Ecl310ErrorMessages.SetMinTemperatureMonitor, CommandType = CommandType.Write, Code = 11149, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись минимальной температуры температурного монитора, контур 2" (12149)
        /// </summary>
        public Command SetMinTemperatureMonitorCircuit2 = new Command { CommandName = "SetMinTemperatureMonitorCircuit2", ErrorMessage = Ecl310ErrorMessages.SetMinTemperatureMonitorCircuit2, CommandType = CommandType.Write, Code = 12149, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись приоритета ограничения температуры обратки" (11084)
        /// </summary>
        public Command SetLimitReversePriority = new Command { CommandName = "SetLimitReversePriority", ErrorMessage = Ecl310ErrorMessages.SetLimitReversePriority, CommandType = CommandType.Write, Code = 11084, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись приоритета ограничения температуры обратки, контур 2" (12084)
        /// </summary>
        public Command SetLimitReversePriorityCircuit2 = new Command { CommandName = "SetLimitReversePriorityCircuit2", ErrorMessage = Ecl310ErrorMessages.SetLimitReversePriorityCircuit2, CommandType = CommandType.Write, Code = 12084, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает смещение" (11016)
        /// </summary>
        public Command SetOffset = new Command { CommandName = "SetOffset", ErrorMessage = Ecl310ErrorMessages.SetOffset, CommandType = CommandType.Write, Code = 11016, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг тренировки клапана, контур 1" (11022)
        /// </summary>
        public Command SetFlapTrainingCirciut1 = new Command { CommandName = "SetFlapTrainingCirciut1", ErrorMessage = Ecl310ErrorMessages.SetFlapTrainingCirciut1, CommandType = CommandType.Write, Code = 11022, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг тренировки клапана, контур 2" (12022)
        /// </summary>
        public Command SetFlapTrainingCirciut2 = new Command { CommandName = "SetFlapTrainingCirciut2", ErrorMessage = Ecl310ErrorMessages.SetFlapTrainingCirciut2, CommandType = CommandType.Write, Code = 12022, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг приоритета ГВС, контур 1" (11051)
        /// </summary>
        public Command SetHwsPriorityCircuit1 = new Command { CommandName = "SetHwsPriorityCircuit1", ErrorMessage = Ecl310ErrorMessages.SetHwsPriorityCircuit1, CommandType = CommandType.Write, Code = 11051, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг приоритета ГВС, контур 2" (12051)
        /// </summary>
        public Command SetHwsPriorityCircuit2 = new Command { CommandName = "SetHwsPriorityCircuit2", ErrorMessage = Ecl310ErrorMessages.SetHwsPriorityCircuit2, CommandType = CommandType.Write, Code = 12051, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает температуру защиты от замерзания, контур 2" (12076)
        /// </summary>
        public Command SetFrostProtectionTemperatureCircuit2 = new Command { CommandName = "SetFrostProtectionTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFrostProtectionTemperatureCircuit2, CommandType = CommandType.Write, Code = 12076, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает температуру тепловой нагрузки, контур 1" (11077)
        /// </summary>
        public Command SetThermalLoadTemperatureCircuit1 = new Command { CommandName = "SetThermalLoadTemperatureCircuit1", ErrorMessage = Ecl310ErrorMessages.SetThermalLoadTemperatureCircuit1, CommandType = CommandType.Write, Code = 11077, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает температуру тепловой нагрузки, контур 2" (12077)
        /// </summary>
        public Command SetThermalLoadTemperatureCircuit2 = new Command { CommandName = "SetThermalLoadTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.SetThermalLoadTemperatureCircuit2, CommandType = CommandType.Write, Code = 12077, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает требуемую температуру защиты от замерзания, контур 2" (12092)
        /// </summary>
        public Command SetFrostProtectionTemperature2Circuit2 = new Command { CommandName = "SetFrostProtectionTemperature2Circuit2", ErrorMessage = Ecl310ErrorMessages.SetFrostProtectionTemperature2Circuit2, CommandType = CommandType.Write, Code = 12092, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает время оптимизации ограничения расхода, контур 1" (11111)
        /// </summary>
        public Command SetFlowLimitationOptimizationTime = new Command { CommandName = "SetFlowLimitationOptimizationTime", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationOptimizationTime, CommandType = CommandType.Write, Code = 11111, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает время оптимизации ограничения расхода, контур 2" (12111)
        /// </summary>
        public Command SetFlowLimitationOptimizationTimeCircuit2 = new Command { CommandName = "SetFlowLimitationOptimizationTimeCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationOptimizationTimeCircuit2, CommandType = CommandType.Write, Code = 12111, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает фильтр ввода ограничения расхода, контур 1" (11112)
        /// </summary>
        public Command SetFlowLimitationInputFilter = new Command { CommandName = "SetFlowLimitationInputFilter", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationInputFilter, CommandType = CommandType.Write, Code = 11112, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает фильтр ввода ограничения расхода, контур 2" (12112)
        /// </summary>
        public Command SetFlowLimitationInputFilterCircuit2 = new Command { CommandName = "SetFlowLimitationInputFilterCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationInputFilterCircuit2, CommandType = CommandType.Write, Code = 12112, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает импульс ограничения расхода, контур 1" (11113)
        /// </summary>
        public Command SetFlowLimitationImpulseWeight = new Command { CommandName = "SetFlowLimitationImpulseWeight", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationImpulseWeight, CommandType = CommandType.Write, Code = 11113, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает импульс ограничения расхода, контур 2" (12113)
        /// </summary>
        public Command SetFlowLimitationImpulseWeightCircuit2 = new Command { CommandName = "SetFlowLimitationImpulseWeightCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationImpulseWeightCircuit2, CommandType = CommandType.Write, Code = 12113, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает единицу измерения ограничения расхода, контур 1" (11114)
        /// </summary>
        public Command SetFlowLimitationUnitId = new Command { CommandName = "SetFlowLimitationUnitId", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationUnitId, CommandType = CommandType.Write, Code = 11114, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает единицу измерения ограничения расхода, контур 2" (12114)
        /// </summary>
        public Command SetFlowLimitationUnitCircuit2Id = new Command { CommandName = "SetFlowLimitationUnitCircuit2Id", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationUnitCircuit2Id, CommandType = CommandType.Write, Code = 12114, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает макс. расход обратки Y2, контур 1" (11115)
        /// </summary>
        public Command SetFlowLimitationMaxReverseRate = new Command { CommandName = "SetFlowLimitationMaxReverseRate", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMaxReverseRate, CommandType = CommandType.Write, Code = 11115, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает макс. расход обратки Y2, контур 2" (12115)
        /// </summary>
        public Command SetFlowLimitationMaxReverseRateCircuit2 = new Command { CommandName = "SetFlowLimitationMaxReverseRateCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMaxReverseRateCircuit2, CommandType = CommandType.Write, Code = 12115, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает мин. расход обратки Y1, контур 1" (11116)
        /// </summary>
        public Command SetFlowLimitationMinReverseRate = new Command { CommandName = "SetFlowLimitationMinReverseRate", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMinReverseRate, CommandType = CommandType.Write, Code = 11116, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает мин. расход обратки Y1, контур 2" (12116)
        /// </summary>
        public Command SetFlowLimitationMinReverseRateCircuit2 = new Command { CommandName = "SetFlowLimitationMinReverseRateCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMinReverseRateCircuit2, CommandType = CommandType.Write, Code = 12116, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает мин. нар. температуру X2, контур 1" (11117)
        /// </summary>
        public Command SetFlowLimitationMinOpenAirTemperature = new Command { CommandName = "SetFlowLimitationMinOpenAirTemperature", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMinOpenAirTemperature, CommandType = CommandType.Write, Code = 11117, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает мин. нар. температуру X2, контур 2" (12117)
        /// </summary>
        public Command SetFlowLimitationMinOpenAirTemperatureCircuit2 = new Command { CommandName = "SetFlowLimitationMinOpenAirTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMinOpenAirTemperatureCircuit2, CommandType = CommandType.Write, Code = 12117, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает макс. нар. температуру X1, контур 1" (11118)
        /// </summary>
        public Command SetFlowLimitationMaxOpenAirTemperature = new Command { CommandName = "SetFlowLimitationMaxOpenAirTemperature", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMaxOpenAirTemperature, CommandType = CommandType.Write, Code = 11118, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает макс. нар. температуру X1, контур 2" (12118)
        /// </summary>
        public Command SetFlowLimitationMaxOpenAirTemperatureCircuit2 = new Command { CommandName = "SetFlowLimitationMaxOpenAirTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationMaxOpenAirTemperatureCircuit2, CommandType = CommandType.Write, Code = 12118, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает тип входа ограничения расхода, контур 1" (11108)
        /// </summary>
        public Command SetFlowLimitationInputTypeId = new Command { CommandName = "SetFlowLimitationInputTypeId", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationInputTypeId, CommandType = CommandType.Write, Code = 11108, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает тип входа ограничения расхода, контур 2" (12108)
        /// </summary>
        public Command SetFlowLimitationInputTypeCircuit2Id = new Command { CommandName = "SetFlowLimitationInputTypeCircuit2Id", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationInputTypeCircuit2Id, CommandType = CommandType.Write, Code = 12108, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает температуру автоотключения, контур 1" (11010)
        /// </summary>
        public Command SetOptimizationAutoPowerOffTemperature = new Command { CommandName = "SetOptimizationAutoPowerOffTemperature", ErrorMessage = Ecl310ErrorMessages.SetOptimizationAutoPowerOffTemperature, CommandType = CommandType.Write, Code = 11010, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает температуру автоотключения, контур 2" (12010)
        /// </summary>
        public Command SetOptimizationAutoPowerOffTemperatureCircuit2 = new Command { CommandName = "SetOptimizationAutoPowerOffTemperatureCircuit2", ErrorMessage = Ecl310ErrorMessages.SetOptimizationAutoPowerOffTemperatureCircuit2, CommandType = CommandType.Write, Code = 12010, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает натоп, контур 1" (11011)
        /// </summary>
        public Command SetOptimizationBoost = new Command { CommandName = "SetOptimizationBoost", ErrorMessage = Ecl310ErrorMessages.SetOptimizationBoost, CommandType = CommandType.Write, Code = 11011, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает натоп, контур 2" (12011)
        /// </summary>
        public Command SetOptimizationBoostCircuit2 = new Command { CommandName = "SetOptimizationBoostCircuit2", ErrorMessage = Ecl310ErrorMessages.SetOptimizationBoostCircuit2, CommandType = CommandType.Write, Code = 12011, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает время натопа, контур 1" (11012)
        /// </summary>
        public Command SetOptimizationBoostTime = new Command { CommandName = "SetOptimizationBoostTime", ErrorMessage = Ecl310ErrorMessages.SetOptimizationBoostTime, CommandType = CommandType.Write, Code = 11012, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает время натопа, контур 2" (12012)
        /// </summary>
        public Command SetOptimizationBoostTimeCircuit2 = new Command { CommandName = "SetOptimizationBoostTimeCircuit2", ErrorMessage = Ecl310ErrorMessages.SetOptimizationBoostTimeCircuit2, CommandType = CommandType.Write, Code = 12012, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает оптимизатор, контур 1" (11013)
        /// </summary>
        public Command SetOptimizationOptimum = new Command { CommandName = "SetOptimizationOptimum", ErrorMessage = Ecl310ErrorMessages.SetOptimizationOptimum, CommandType = CommandType.Write, Code = 11013, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает оптимизатор, контур 2" (12013)
        /// </summary>
        public Command SetOptimizationOptimumCircuit2 = new Command { CommandName = "SetOptimizationOptimumCircuit2", ErrorMessage = Ecl310ErrorMessages.SetOptimizationOptimumCircuit2, CommandType = CommandType.Write, Code = 12013, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг задержки отключения, контур 1" (11025)
        /// </summary>
        public Command SetOptimizationOffDelay = new Command { CommandName = "SetOptimizationOffDelay", ErrorMessage = Ecl310ErrorMessages.SetOptimizationOffDelay, CommandType = CommandType.Write, Code = 11025, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг задержки отключения, контур 2" (12025)
        /// </summary>
        public Command SetOptimizationOffDelayCircuit2 = new Command { CommandName = "SetOptimizationOffDelayCircuit2", ErrorMessage = Ecl310ErrorMessages.SetOptimizationOffDelayCircuit2, CommandType = CommandType.Write, Code = 12025, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает базис оптимизации, контур 1" (11019)
        /// </summary>
        public Command SetOptimizationBasisId = new Command { CommandName = "SetOptimizationBasisId", ErrorMessage = Ecl310ErrorMessages.SetOptimizationBasisId, CommandType = CommandType.Write, Code = 11019, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает базис оптимизации, контур 2" (12019)
        /// </summary>
        public Command SetOptimizationBasisCircuit2Id = new Command { CommandName = "SetOptimizationBasisCircuit2Id", ErrorMessage = Ecl310ErrorMessages.SetOptimizationBasisCircuit2Id, CommandType = CommandType.Write, Code = 12019, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает требуемую температуру подачи в режиме комфорт" (11017)
        /// </summary>
        public Command SetRequiredComfortFlowTemperature = new Command { CommandName = "SetRequiredComfortFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetRequiredComfortFlowTemperature, CommandType = CommandType.Write, Code = 11017, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает требуемую температуру подачи в режиме эконом" (11018)
        /// </summary>
        public Command SetRequiredEconomyFlowTemperature = new Command { CommandName = "SetRequiredEconomyFlowTemperature", ErrorMessage = Ecl310ErrorMessages.SetRequiredEconomyFlowTemperature, CommandType = CommandType.Write, Code = 11018, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает предельное значение ограничения расхода" (11110)
        /// </summary>
        public Command SetFlowLimitationLimit = new Command { CommandName = "SetFlowLimitationLimit", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationLimit, CommandType = CommandType.Write, Code = 11110, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает предельное значение ограничения расхода, контур 2" (12110)
        /// </summary>
        public Command SetFlowLimitationLimitCircuit2 = new Command { CommandName = "SetFlowLimitationLimitCircuit2", ErrorMessage = Ecl310ErrorMessages.SetFlowLimitationLimitCircuit2, CommandType = CommandType.Write, Code = 12110, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает нагрузку охлаждения, контур 1" (11069)
        /// </summary>
        public Command SetCoolingLoadTemperatureCircuit1 = new Command { CommandName = "SetCoolingLoadTemperatureCircuit1", ErrorMessage = Ecl310ErrorMessages.SetCoolingLoadTemperatureCircuit1, CommandType = CommandType.Write, Code = 11069, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает температуру в режиме ожидания, контур 1" (11091)
        /// </summary>
        public Command SetExpectationFlowTemperatureCircuit1 = new Command { CommandName = "SetExpectationFlowTemperatureCircuit1", ErrorMessage = Ecl310ErrorMessages.SetExpectationFlowTemperatureCircuit1, CommandType = CommandType.Write, Code = 11091, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает коэффициент параллельной работы, контур 1" (11042)
        /// </summary>
        public Command SetParallelOperationCircuit1 = new Command { CommandName = "SetParallelOperationCircuit1", ErrorMessage = Ecl310ErrorMessages.SetParallelOperationCircuit1, CommandType = CommandType.Write, Code = 11042, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг автонастройки, контур 2" (12172)
        /// </summary>
        public Command SetAutotuningCircuit2 = new Command { CommandName = "SetAutotuningCircuit2", ErrorMessage = Ecl310ErrorMessages.SetAutotuningCircuit2, CommandType = CommandType.Write, Code = 12172, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает температуру подачи сигнализации, контур 1" (11078)
        /// </summary>
        public Command SetSignalizationFlowTemperatureCircuit1 = new Command { CommandName = "SetSignalizationFlowTemperatureCircuit1", ErrorMessage = Ecl310ErrorMessages.SetSignalizationFlowTemperatureCircuit1, CommandType = CommandType.Write, Code = 11078, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает паузу сигнализации, контур 1" (11079)
        /// </summary>
        public Command SetSignalizationPauseCircuit1 = new Command { CommandName = "SetSignalizationPauseCircuit1", ErrorMessage = Ecl310ErrorMessages.SetSignalizationPauseCircuit1, CommandType = CommandType.Write, Code = 11079, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает верхнюю аварийную границу, контур 1" (11613)
        /// </summary>
        public Command SetAccidentTopLimit = new Command { CommandName = "SetAccidentTopLimit", ErrorMessage = Ecl310ErrorMessages.SetAccidentTopLimit, CommandType = CommandType.Write, Code = 11613, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает нижнюю аварийную границу, контур 1" (11614)
        /// </summary>
        public Command SetAccidentBottomLimit = new Command { CommandName = "SetAccidentBottomLimit", ErrorMessage = Ecl310ErrorMessages.SetAccidentBottomLimit, CommandType = CommandType.Write, Code = 11614, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает нижн. X, контур 1" (11606)
        /// </summary>
        public Command SetPressureBottomXCircuit1 = new Command { CommandName = "SetPressureBottomXCircuit1", ErrorMessage = Ecl310ErrorMessages.SetPressureBottomXCircuit1, CommandType = CommandType.Write, Code = 11606, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает верхн. X, контур 1" (11607)
        /// </summary>
        public Command SetPressureTopXCircuit1 = new Command { CommandName = "SetPressureTopXCircuit1", ErrorMessage = Ecl310ErrorMessages.SetPressureTopXCircuit1, CommandType = CommandType.Write, Code = 11607, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает нижн. Y, контур 1" (11608)
        /// </summary>
        public Command SetPressureBottomYCircuit1 = new Command { CommandName = "SetPressureBottomYCircuit1", ErrorMessage = Ecl310ErrorMessages.SetPressureBottomYCircuit1, CommandType = CommandType.Write, Code = 11608, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает верхн. Y, контур 1" (11609)
        /// </summary>
        public Command SetPressureTopYCircuit1 = new Command { CommandName = "SetPressureTopYCircuit1", ErrorMessage = Ecl310ErrorMessages.SetPressureTopYCircuit1, CommandType = CommandType.Write, Code = 11609, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг сброса аварии насосов, контур 1" (11314)
        /// </summary>
        public Command SetAccidentPumpsCircuit1 = new Command { CommandName = "SetAccidentPumpsCircuit1", ErrorMessage = Ecl310ErrorMessages.SetAccidentPumpsCircuit1, CommandType = CommandType.Write, Code = 11314, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг сброса аварии насосов, контур 2" (12314)
        /// </summary>
        public Command SetAccidentPumpsCircuit2 = new Command { CommandName = "SetAccidentPumpsCircuit2", ErrorMessage = Ecl310ErrorMessages.SetAccidentPumpsCircuit2, CommandType = CommandType.Write, Code = 12314, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг сброса аварии подпитки, контур 1" (11323)
        /// </summary>
        public Command SetAccidentMakeupCircuit1 = new Command { CommandName = "SetAccidentMakeupCircuit1", ErrorMessage = Ecl310ErrorMessages.SetAccidentMakeupCircuit1, CommandType = CommandType.Write, Code = 11323, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает флаг сброса аварии подпитки, контур 2" (12323)
        /// </summary>
        public Command SetAccidentMakeupCircuit2 = new Command { CommandName = "SetAccidentMakeupCircuit2", ErrorMessage = Ecl310ErrorMessages.SetAccidentMakeupCircuit2, CommandType = CommandType.Write, Code = 12323, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает угол наклона температурного графика, контур 1" (11174)
        /// </summary>
        public Command SetHeatCurveAngle = new Command { CommandName = "SetHeatCurveAngle", ErrorMessage = Ecl310ErrorMessages.SetHeatCurveAngle, CommandType = CommandType.Write, Code = 11174, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// "Записывает регистр PNU 11173"
        /// </summary>
        public Command SetPnu11173 = new Command { CommandName = Ecl310Resources.SetPnu11173, ErrorMessage = Ecl310ErrorMessages.SetPnu11173, CommandType = CommandType.Write, Code = 11172, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает регистр PNU 11094"
        /// </summary>
        public Command SetPnu11094 = new Command { CommandName = Ecl310Resources.SetPnu11094, ErrorMessage = Ecl310ErrorMessages.SetPnu11094, CommandType = CommandType.Write, Code = 11093, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает регистр PNU 11095"
        /// </summary>
        public Command SetPnu11095 = new Command { CommandName = Ecl310Resources.SetPnu11095, ErrorMessage = Ecl310ErrorMessages.SetPnu11095, CommandType = CommandType.Write, Code = 11094, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает регистр PNU 11096"
        /// </summary>
        public Command SetPnu11096 = new Command { CommandName = Ecl310Resources.SetPnu11096, ErrorMessage = Ecl310ErrorMessages.SetPnu11096, CommandType = CommandType.Write, Code = 11095, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает регистр PNU 11097"
        /// </summary>
        public Command SetPnu11097 = new Command { CommandName = Ecl310Resources.SetPnu11097, ErrorMessage = Ecl310ErrorMessages.SetPnu11097, CommandType = CommandType.Write, Code = 11096, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает регистр PNU 11076"
        /// </summary>
        public Command SetPnu11076 = new Command { CommandName = Ecl310Resources.SetPnu11076, ErrorMessage = Ecl310ErrorMessages.SetPnu11076, CommandType = CommandType.Write, Code = 11075, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает регистр PNU 11040"
        /// </summary>
        public Command SetPnu11040 = new Command { CommandName = Ecl310Resources.SetPnu11040, ErrorMessage = Ecl310ErrorMessages.SetPnu11040, CommandType = CommandType.Write, Code = 11039, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// "Записывает регистр PNU 11190"
        /// </summary>
        public Command SetPnu11190 = new Command { CommandName = Ecl310Resources.SetPnu11190, ErrorMessage = Ecl310ErrorMessages.SetPnu11190, CommandType = CommandType.Write, Code = 11189, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Записывает регистр PNU 11191"
        /// </summary>
        public Command SetPnu11191 = new Command { CommandName = Ecl310Resources.SetPnu11191, ErrorMessage = Ecl310ErrorMessages.SetPnu11191, CommandType = CommandType.Write, Code = 11190, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
    }
}

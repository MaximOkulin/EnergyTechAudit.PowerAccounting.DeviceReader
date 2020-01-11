using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API
{
    internal sealed partial class Commands
    {
        // МГНОВЕННЫЕ ЗНАЧЕНИЯ
        /// <summary>
        /// Чтение значения датчика S1 (CE-3A)
        /// </summary>
        public Command GetSensor1 = new Command { CommandName = Ecl300Resources.GetSensor1, ErrorMessage = Ecl300ErrorMessages.GetSensor1, CommandType = CommandType.Read, Code = 15054, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение значения датчика S2 (CE-38)
        /// </summary>
        public Command GetSensor2 = new Command { CommandName = Ecl300Resources.GetSensor2, ErrorMessage = Ecl300ErrorMessages.GetSensor2, CommandType = CommandType.Read, Code = 14542, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение значения датчика S3 (CE-36)
        /// </summary>
        public Command GetSensor3 = new Command { CommandName = Ecl300Resources.GetSensor3, ErrorMessage = Ecl300ErrorMessages.GetSensor3, CommandType = CommandType.Read, Code = 14030, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение значения датчика S4 (CE-34)
        /// </summary>
        public Command GetSensor4 = new Command { CommandName = Ecl300Resources.GetSensor4, ErrorMessage = Ecl300ErrorMessages.GetSensor4, CommandType = CommandType.Read, Code = 13518, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение значения датчика S5 (CE-32)
        /// </summary>
        public Command GetSensor5 = new Command { CommandName = Ecl300Resources.GetSensor5, ErrorMessage = Ecl300ErrorMessages.GetSensor5, CommandType = CommandType.Read, Code = 13006, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение значения датчика S6 (CE-30)
        /// </summary>
        public Command GetSensor6 = new Command { CommandName = Ecl300Resources.GetSensor6, ErrorMessage = Ecl300ErrorMessages.GetSensor6, CommandType = CommandType.Read, Code = 12494, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение рассчитанной температуры подачи, контур 1 (CE-46)
        /// </summary>
        public Command GetCalcFlow1 = new Command { CommandName = Ecl300Resources.GetCalcFlow1, ErrorMessage = Ecl300ErrorMessages.GetCalcFlow1, CommandType = CommandType.Read, Code = 18126, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение рассчитанной температуры подачи, контур 2 (CE-48)
        /// </summary>
        public Command GetCalcFlow2 = new Command { CommandName = Ecl300Resources.GetCalcFlow2, ErrorMessage = Ecl300ErrorMessages.GetCalcFlow2, CommandType = CommandType.Read, Code = 18638, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение рассчитанной температуры обратки, контур 1 (CE-4A)
        /// </summary>
        public Command GetCalcReturn1 = new Command { CommandName = Ecl300Resources.GetCalcReturn1, ErrorMessage = Ecl300ErrorMessages.GetCalcReturn1, CommandType = CommandType.Read, Code = 19150, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение рассчитанной температуры обратки, контур 2 (CE-4C)
        /// </summary>
        public Command GetCalcReturn2 = new Command { CommandName = Ecl300Resources.GetCalcReturn2, ErrorMessage = Ecl300ErrorMessages.GetCalcReturn2, CommandType = CommandType.Read, Code = 19662, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение комнатной температуры, контур 1 (CE-3E)
        /// </summary>
        public Command GetRoomTemp1 = new Command { CommandName = Ecl300Resources.GetRoomTemp1, ErrorMessage = Ecl300ErrorMessages.GetRoomTemp1, CommandType = CommandType.Read, Code = 16078, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение комнатной температуры, контур 2 (CE-40)
        /// </summary>
        public Command GetRoomTemp2 = new Command { CommandName = Ecl300Resources.GetRoomTemp2, ErrorMessage = Ecl300ErrorMessages.GetRoomTemp2, CommandType = CommandType.Read, Code = 16590, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение температуры наружного воздуха (CE-3C)
        /// </summary>
        public Command GetOutdoorTemperature = new Command { CommandName = Ecl300Resources.GetOutdoorTemperature, ErrorMessage = Ecl300ErrorMessages.GetOutdoorTemperature, CommandType = CommandType.Read, Code = 15566, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        // РЕГУЛИРУЕМЫЕ ЗНАЧЕНИЯ
        /// <summary>
        /// Чтение угла наклона температурного графика, контур 1 (CE-C9)
        /// </summary>
        public Command GetHeatCurve1 = new Command { CommandName = Ecl300Resources.GetHeatCurve1, ErrorMessage = Ecl300ErrorMessages.GetHeatCurve1, CommandType = CommandType.Read, Code = 51662, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        /// <summary>
        /// Чтение желаемой комнатной температуры (комфорт) (CE-9E)
        /// </summary>
        public Command GetRoomTempDaySet = new Command { CommandName = Ecl300Resources.GetRoomTempDaySet, ErrorMessage = Ecl300ErrorMessages.GetRoomTempDaySet, CommandType = CommandType.Read, Code = 40654, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение желаемой комнатной температуры (эконом) (CE-A0)
        /// </summary>
        public Command GetRoomTempNightSet = new Command { CommandName = Ecl300Resources.GetRoomTempNightSet, ErrorMessage = Ecl300ErrorMessages.GetRoomTempNightSet, CommandType = CommandType.Read, Code = 41166, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение режима контура 1 (11-01)
        /// </summary>
        public Command GetMode1 = new Command { CommandName = Ecl300Resources.GetMode1, ErrorMessage = Ecl300ErrorMessages.GetMode1, CommandType = CommandType.Read, Code = 273, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение режима контура 2 (11-02)
        /// </summary>
        public Command GetMode2 = new Command { CommandName = Ecl300Resources.GetMode2, ErrorMessage = Ecl300ErrorMessages.GetMode2, CommandType = CommandType.Read, Code = 529, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение температуры отключения, контур 1 (CE-C2)
        /// </summary>
        public Command GetSummerCutout1 = new Command { CommandName = Ecl300Resources.GetSummerCutout1, ErrorMessage = Ecl300ErrorMessages.GetSummerCutout1, CommandType = CommandType.Read, Code = 49870, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение температуры отключения, контур 2 (CE-C3)
        /// </summary>
        public Command GetSummerCutout2 = new Command { CommandName = Ecl300Resources.GetSummerCutout2, ErrorMessage = Ecl300ErrorMessages.GetSummerCutout2, CommandType = CommandType.Read, Code = 50126, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };

        #region C66 RS232
        /// <summary>
        /// Чтение желаемой температуры горячей воды (комфорт) (CE-D0)
        /// </summary>
        public Command GetHotWaterTempDaySet_C66_RS232 = new Command { CommandName = Ecl300Resources.GetHotWaterTempDaySet_C66_RS232, ErrorMessage = Ecl300ErrorMessages.GetHotWaterTempDaySet, CommandType = CommandType.Read, Code = 53454, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение желаемой температуры горячей воды (эконом) (CE-D1)
        /// </summary>
        public Command GetHotWaterTempNightSet_C66_RS232 = new Command { CommandName = Ecl300Resources.GetHotWaterTempNightSet_C66_RS232, ErrorMessage = Ecl300ErrorMessages.GetHotWaterTempNightSet, CommandType = CommandType.Read, Code = 53710, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение параллельного сдвига, контур 1 (CE-A8)
        /// </summary>
        public Command GetParallel1_C66_RS232 = new Command { CommandName = Ecl300Resources.GetParallel1_C66_RS232, ErrorMessage = Ecl300ErrorMessages.GetParallel1, CommandType = CommandType.Read, Code = 43214, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение минимальной температуры подачи, контур 1 (CE-CB)
        /// </summary>
        public Command GetFlowTempMin1_C66_RS232 = new Command { CommandName = Ecl300Resources.GetFlowTempMin1_C66_RS232, ErrorMessage = Ecl300ErrorMessages.GetFlowTempMin1, CommandType = CommandType.Read, Code = 52174, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        /// <summary>
        /// Чтение максимальной температуры подачи, контур 1 (CE-СС)
        /// </summary>
        public Command GetFlowTempMax1_C66_RS232 = new Command { CommandName = Ecl300Resources.GetFlowTempMax1_C66_RS232, ErrorMessage = Ecl300ErrorMessages.GetFlowTempMax1, CommandType = CommandType.Read, Code = 52430, ResponseLengthType = LengthType.Fixed, ResponseLength = 5 };
        #endregion

        #region C66 RS485
        /// <summary>
        /// Чтение типа регулятора
        /// </summary>
        public Command GetRs485Application = new Command { CommandName = Ecl300Resources.GetRs485Application, ErrorMessage = Ecl300ErrorMessages.GetRs485Application, CommandType = CommandType.Read, Code = 2107, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение значения датчика 1
        /// </summary>
        public Command GetRs485Sensor1 = new Command { CommandName = Ecl300Resources.GetRs485Sensor1, ErrorMessage = Ecl300ErrorMessages.GetRs485Sensor1, CommandType = CommandType.Read, Code = 11200, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение значения датчика 2
        /// </summary>
        public Command GetRs485Sensor2 = new Command { CommandName = Ecl300Resources.GetRs485Sensor2, ErrorMessage = Ecl300ErrorMessages.GetRs485Sensor2, CommandType = CommandType.Read, Code = 11201, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение значения датчика 3
        /// </summary>
        public Command GetRs485Sensor3= new Command { CommandName = Ecl300Resources.GetRs485Sensor3, ErrorMessage = Ecl300ErrorMessages.GetRs485Sensor3, CommandType = CommandType.Read, Code = 11202, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение значения датчика 4
        /// </summary>
        public Command GetRs485Sensor4 = new Command { CommandName = Ecl300Resources.GetRs485Sensor4, ErrorMessage = Ecl300ErrorMessages.GetRs485Sensor4, CommandType = CommandType.Read, Code = 11203, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение значения датчика 5
        /// </summary>
        public Command GetRs485Sensor5 = new Command { CommandName = Ecl300Resources.GetRs485Sensor5, ErrorMessage = Ecl300ErrorMessages.GetRs485Sensor5, CommandType = CommandType.Read, Code = 11204, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение значения датчика 6
        /// </summary>
        public Command GetRs485Sensor6 = new Command { CommandName = Ecl300Resources.GetRs485Sensor6, ErrorMessage = Ecl300ErrorMessages.GetRs485Sensor6, CommandType = CommandType.Read, Code = 11205, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение уставки датчика 1
        /// </summary>
        public Command GetRs485ReferenceS1 = new Command { CommandName = Ecl300Resources.GetRs485ReferenceS1, ErrorMessage = Ecl300ErrorMessages.GetRs485ReferenceS1, CommandType = CommandType.Read, Code = 11227, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение уставки датчика 2
        /// </summary>
        public Command GetRs485ReferenceS2 = new Command { CommandName = Ecl300Resources.GetRs485ReferenceS2, ErrorMessage = Ecl300ErrorMessages.GetRs485ReferenceS2, CommandType = CommandType.Read, Code = 11228, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение уставки датчика 3
        /// </summary>
        public Command GetRs485ReferenceS3 = new Command { CommandName = Ecl300Resources.GetRs485ReferenceS3, ErrorMessage = Ecl300ErrorMessages.GetRs485ReferenceS3, CommandType = CommandType.Read, Code = 11229, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение уставки датчика 4
        /// </summary>
        public Command GetRs485ReferenceS4 = new Command { CommandName = Ecl300Resources.GetRs485ReferenceS4, ErrorMessage = Ecl300ErrorMessages.GetRs485ReferenceS4, CommandType = CommandType.Read, Code = 11230, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение уставки датчика 5
        /// </summary>
        public Command GetRs485ReferenceS5 = new Command { CommandName = Ecl300Resources.GetRs485ReferenceS5, ErrorMessage = Ecl300ErrorMessages.GetRs485ReferenceS5, CommandType = CommandType.Read, Code = 11231, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение уставки датчика 6
        /// </summary>
        public Command GetRs485ReferenceS6 = new Command { CommandName = Ecl300Resources.GetRs485ReferenceS6, ErrorMessage = Ecl300ErrorMessages.GetRs485ReferenceS6, CommandType = CommandType.Read, Code = 11232, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение режима контура 1
        /// </summary>
        public Command GetRs485Circuit1Mode = new Command { CommandName = Ecl300Resources.GetRs485Circuit1Mode, ErrorMessage = Ecl300ErrorMessages.GetRs485Circuit1Mode, CommandType = CommandType.Read, Code = 4200, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение режима контура 2
        /// </summary>
        public Command GetRs485Circuit2Mode = new Command { CommandName = Ecl300Resources.GetRs485Circuit2Mode, ErrorMessage = Ecl300ErrorMessages.GetRs485Circuit2Mode, CommandType = CommandType.Read, Code = 4201, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение состояния контура 1
        /// </summary>
        public Command GetRs485Circuit1Status = new Command { CommandName = Ecl300Resources.GetRs485Circuit1Status, ErrorMessage = Ecl300ErrorMessages.GetRs485Circuit1Status, CommandType = CommandType.Read, Code = 4210, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение состояния контура 2
        /// </summary>
        public Command GetRs485Circuit2Status = new Command { CommandName = Ecl300Resources.GetRs485Circuit2Status, ErrorMessage = Ecl300ErrorMessages.GetRs485Circuit2Status, CommandType = CommandType.Read, Code = 4211, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение текущего времени прибора
        /// </summary>
        public Command GetRs485DeviceTime = new Command { CommandName = Ecl300Resources.GetRs485DeviceTime, ErrorMessage = Ecl300ErrorMessages.GetRs485DeviceTime, CommandType = CommandType.Read, Code = 64044, RegistersCount = 5, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        
        // РЕГУЛЯЦИОННЫЕ ПАРАМЕТРЫ
        /// <summary>
        /// Чтение угла наклона температурного графика, контур 1
        /// </summary>
        public Command GetHeatCurve1_RS485 = new Command { CommandName = Ecl300Resources.GetHeatCurve1_RS485, ErrorMessage = Ecl300ErrorMessages.GetHeatCurve1_RS485, CommandType = CommandType.Read, Code = 11174, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение угла наклона температурного графика, контур 2
        /// </summary>
        public Command GetHeatCurve2_RS485 = new Command { CommandName = Ecl300Resources.GetHeatCurve2_RS485, ErrorMessage = Ecl300ErrorMessages.GetHeatCurve2_RS485, CommandType = CommandType.Read, Code = 12174, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение параллельного сдвига температурного графика для контура 1
        /// </summary>
        public Command GetParallel1_RS485 = new Command { CommandName = Ecl300Resources.GetParallel1_RS485, ErrorMessage = Ecl300ErrorMessages.GetParallel1_RS485, CommandType = CommandType.Read, Code = 11175, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение параллельного сдвига температурного графика для контура 2
        /// </summary>
        public Command GetParallel2_RS485 = new Command { CommandName = Ecl300Resources.GetParallel2_RS485, ErrorMessage = Ecl300ErrorMessages.GetParallel2_RS485, CommandType = CommandType.Read, Code = 12175, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение границы отключения отопления, контур 1
        /// </summary>
        public Command GetHsHeatingOffTemperature1_RS485 = new Command { CommandName = Ecl300Resources.GetHsHeatingOffTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.GetHsHeatingOffTemperature1_RS485, CommandType = CommandType.Read, Code = 11178, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение границы отключения отопления, контур 2
        /// </summary>
        public Command GetHsHeatingOffTemperature2_RS485 = new Command { CommandName = Ecl300Resources.GetHsHeatingOffTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.GetHsHeatingOffTemperature2_RS485, CommandType = CommandType.Read, Code = 12178, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };


        /// <summary>
        /// Чтение минимальной температуры подачи, контур 1
        /// </summary>
        public Command GetMinHsFlowTemperature1_RS485 = new Command { CommandName = Ecl300Resources.GetMinHsFlowTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.GetMinHsFlowTemperature1_RS485, CommandType = CommandType.Read, Code = 11176, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение минимальной температуры подачи, контур 2
        /// </summary>
        public Command GetMinHsFlowTemperature2_RS485 = new Command { CommandName = Ecl300Resources.GetMinHsFlowTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.GetMinHsFlowTemperature2_RS485, CommandType = CommandType.Read, Code = 12176, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение максимальной температуры подачи, контур 1
        /// </summary>
        public Command GetMaxHsFlowTemperature1_RS485 = new Command { CommandName = Ecl300Resources.GetMaxHsFlowTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.GetMaxHsFlowTemperature1_RS485, CommandType = CommandType.Read, Code = 11177, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение максимальной температуры подачи, контур 2
        /// </summary>
        public Command GetMaxHsFlowTemperature2_RS485 = new Command { CommandName = Ecl300Resources.GetMaxHsFlowTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.GetMaxHsFlowTemperature2_RS485, CommandType = CommandType.Read, Code = 12177, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение максимального влияния температуры воздуха в помещении, контур 1
        /// </summary>
        public Command GetMaxAirInfluence1_RS485 = new Command { CommandName = Ecl300Resources.GetMaxAirInfluence1_RS485, ErrorMessage = Ecl300ErrorMessages.GetMaxAirInfluence1_RS485, CommandType = CommandType.Read, Code = 11181, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение минимального влияния температуры воздуха в помещении, контур 1
        /// </summary>
        public Command GetMinAirInfluence1_RS485 = new Command { CommandName = Ecl300Resources.GetMinAirInfluence1_RS485, ErrorMessage = Ecl300ErrorMessages.GetMinAirInfluence1_RS485, CommandType = CommandType.Read, Code = 11182, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение максимального влияния температуры воздуха в помещении, контур 2
        /// </summary>
        public Command GetMaxAirInfluence2_RS485 = new Command { CommandName = Ecl300Resources.GetMaxAirInfluence2_RS485, ErrorMessage = Ecl300ErrorMessages.GetMaxAirInfluence2_RS485, CommandType = CommandType.Read, Code = 12181, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение минимального влияния температуры воздуха в помещении, контур 2
        /// </summary>
        public Command GetMinAirInfluence2_RS485 = new Command { CommandName = Ecl300Resources.GetMinAirInfluence2_RS485, ErrorMessage = Ecl300ErrorMessages.GetMinAirInfluence2_RS485, CommandType = CommandType.Read, Code = 12182, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение зоны пропорциональности, контур 1
        /// </summary>
        public Command GetProportionalBand1_RS485 = new Command { CommandName = Ecl300Resources.GetProportionalBand1_RS485, ErrorMessage = Ecl300ErrorMessages.GetProportionalBand1_RS485, CommandType = CommandType.Read, Code = 11183, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение зоны пропорциональности, контур 2
        /// </summary>
        public Command GetProportionalBand2_RS485 = new Command { CommandName = Ecl300Resources.GetProportionalBand2_RS485, ErrorMessage = Ecl300ErrorMessages.GetProportionalBand2_RS485, CommandType = CommandType.Read, Code = 12183, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение постоянной интегрирования, контур 1
        /// </summary>
        public Command GetIntegrationTime1_RS485 = new Command { CommandName = Ecl300Resources.GetIntegrationTime1_RS485, ErrorMessage = Ecl300ErrorMessages.GetIntegrationTime1_RS485, CommandType = CommandType.Read, Code = 11184, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение постоянной интегрирования, контур 2
        /// </summary>
        public Command GetIntegrationTime2_RS485 = new Command { CommandName = Ecl300Resources.GetIntegrationTime2_RS485, ErrorMessage = Ecl300ErrorMessages.GetIntegrationTime2_RS485, CommandType = CommandType.Read, Code = 12184, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение времени перемещения клапана с электроприводом, контур 1
        /// </summary>
        public Command GetDriveStockTravelTime1_RS485 = new Command { CommandName = Ecl300Resources.GetDriveStockTravelTime1_RS485, ErrorMessage = Ecl300ErrorMessages.GetDriveStockTravelTime1_RS485, CommandType = CommandType.Read, Code = 11185, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение времени перемещения клапана с электроприводом, контур 2
        /// </summary>
        public Command GetDriveStockTravelTime2_RS485 = new Command { CommandName = Ecl300Resources.GetDriveStockTravelTime2_RS485, ErrorMessage = Ecl300ErrorMessages.GetDriveStockTravelTime2_RS485, CommandType = CommandType.Read, Code = 12185, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение нейтральной зоны, контур 1
        /// </summary>
        public Command GetNeutralZone1_RS485 = new Command { CommandName = Ecl300Resources.GetNeutralZone1_RS485, ErrorMessage = Ecl300ErrorMessages.GetNeutralZone1_RS485, CommandType = CommandType.Read, Code = 11186, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение нейтральной зоны, контур 2
        /// </summary>
        public Command GetNeutralZone2_RS485 = new Command { CommandName = Ecl300Resources.GetNeutralZone2_RS485, ErrorMessage = Ecl300ErrorMessages.GetNeutralZone2_RS485, CommandType = CommandType.Read, Code = 12186, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение зависимости пониженной температуры от тем-ры окр. среды, контур 1
        /// </summary>
        public Command GetReducedTempAddiction1_RS485 = new Command { CommandName = Ecl300Resources.GetReducedTempAddiction1_RS485, ErrorMessage = Ecl300ErrorMessages.GetReducedTempAddiction1_RS485, CommandType = CommandType.Read, Code = 11010, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение зависимости пониженной температуры от тем-ры окр. среды, контур 2
        /// </summary>
        public Command GetReducedTempAddiction2_RS485 = new Command { CommandName = Ecl300Resources.GetReducedTempAddiction2_RS485, ErrorMessage = Ecl300ErrorMessages.GetReducedTempAddiction2_RS485, CommandType = CommandType.Read, Code = 12010, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение натопа, контур 1
        /// </summary>
        public Command GetOverrun1_RS485 = new Command { CommandName = Ecl300Resources.GetOverrun1_RS485, ErrorMessage = Ecl300ErrorMessages.GetOverrun1_RS485, CommandType = CommandType.Read, Code = 11011, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение натопа, контур 2
        /// </summary>
        public Command GetOverrun2_RS485 = new Command { CommandName = Ecl300Resources.GetOverrun2_RS485, ErrorMessage = Ecl300ErrorMessages.GetOverrun2_RS485, CommandType = CommandType.Read, Code = 12011, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение плавного перехода, контур 1
        /// </summary>
        public Command GetSmoothTransition1_RS485 = new Command { CommandName = Ecl300Resources.GetSmoothTransition1_RS485, ErrorMessage = Ecl300ErrorMessages.GetSmoothTransition1_RS485, CommandType = CommandType.Read, Code = 11012, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение плавного перехода, контур 2
        /// </summary>
        public Command GetSmoothTransition2_RS485 = new Command { CommandName = Ecl300Resources.GetSmoothTransition2_RS485, ErrorMessage = Ecl300ErrorMessages.GetSmoothTransition2_RS485, CommandType = CommandType.Read, Code = 12012, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение постоянной времени оптимизации, контур 1
        /// </summary>
        public Command GetOptimizationTimeConstant1_RS485 = new Command { CommandName = Ecl300Resources.GetOptimizationTimeConstant1_RS485, ErrorMessage = Ecl300ErrorMessages.GetOptimizationTimeConstant1_RS485, CommandType = CommandType.Read, Code = 11013, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение постоянной времени оптимизации, контур 2
        /// </summary>
        public Command GetOptimizationTimeConstant2_RS485 = new Command { CommandName = Ecl300Resources.GetOptimizationTimeConstant2_RS485, ErrorMessage = Ecl300ErrorMessages.GetOptimizationTimeConstant2_RS485, CommandType = CommandType.Read, Code = 12013, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение адаптации комнатной температуры, контур 1
        /// </summary>
        public Command GetAirRoomAdaptation1_RS485 = new Command { CommandName = Ecl300Resources.GetAirRoomAdaptation1_RS485, ErrorMessage = Ecl300ErrorMessages.GetAirRoomAdaptation1_RS485, CommandType = CommandType.Read, Code = 11014, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение адаптации комнатной температуры, контур 2
        /// </summary>
        public Command GetAirRoomAdaptation2_RS485 = new Command { CommandName = Ecl300Resources.GetAirRoomAdaptation2_RS485, ErrorMessage = Ecl300ErrorMessages.GetAirRoomAdaptation2_RS485, CommandType = CommandType.Read, Code = 12014, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение влияния на задание температуры подачи, контур 1
        /// </summary>
        public Command GetExternalInfluenceTemp1_RS485 = new Command { CommandName = Ecl300Resources.GetExternalInfluenceTemp1_RS485, ErrorMessage = Ecl300ErrorMessages.GetExternalInfluenceTemp1_RS485, CommandType = CommandType.Read, Code = 11016, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение оптимизации на основе комнатной тем-ры, контур 1
        /// </summary>
        public Command GetAirRoomOptimization1_RS485 = new Command { CommandName = Ecl300Resources.GetAirRoomOptimization1_RS485, ErrorMessage = Ecl300ErrorMessages.GetAirRoomOptimization1_RS485, CommandType = CommandType.Read, Code = 11019, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение оптимизации на основе комнатной тем-ры, контур 2
        /// </summary>
        public Command GetAirRoomOptimization2_RS485 = new Command { CommandName = Ecl300Resources.GetAirRoomOptimization2_RS485, ErrorMessage = Ecl300ErrorMessages.GetAirRoomOptimization2_RS485, CommandType = CommandType.Read, Code = 12019, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение полного отключения, контур 1
        /// </summary>
        public Command GetBlackout1_RS485 = new Command { CommandName = Ecl300Resources.GetBlackout1_RS485, ErrorMessage = Ecl300ErrorMessages.GetBlackout1_RS485, CommandType = CommandType.Read, Code = 11020, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение полного отключения, контур 2
        /// </summary>
        public Command GetBlackout2_RS485 = new Command { CommandName = Ecl300Resources.GetBlackout2_RS485, ErrorMessage = Ecl300ErrorMessages.GetBlackout2_RS485, CommandType = CommandType.Read, Code = 12020, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение прогона насоса, контур 1
        /// </summary>
        public Command GetPumpTraining1_RS485 = new Command { CommandName = Ecl300Resources.GetPumpTraining1_RS485, ErrorMessage = Ecl300ErrorMessages.GetPumpTraining1_RS485, CommandType = CommandType.Read, Code = 11021, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение прогона насоса, контур 2
        /// </summary>
        public Command GetPumpTraining2_RS485 = new Command { CommandName = Ecl300Resources.GetPumpTraining2_RS485, ErrorMessage = Ecl300ErrorMessages.GetPumpTraining2_RS485, CommandType = CommandType.Read, Code = 12021, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение прогона клапана, контур 1
        /// </summary>
        public Command GetFlapTraining1_RS485 = new Command { CommandName = Ecl300Resources.GetFlapTraining1_RS485, ErrorMessage = Ecl300ErrorMessages.GetFlapTraining1_RS485, CommandType = CommandType.Read, Code = 11022, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение прогона клапана, контур 2
        /// </summary>
        public Command GetFlapTraining2_RS485 = new Command { CommandName = Ecl300Resources.GetFlapTraining2_RS485, ErrorMessage = Ecl300ErrorMessages.GetFlapTraining2_RS485, CommandType = CommandType.Read, Code = 12022, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение типа привода, контур 1
        /// </summary>
        public Command GetDriveType1_RS485 = new Command { CommandName = Ecl300Resources.GetDriveType1_RS485, ErrorMessage = Ecl300ErrorMessages.GetDriveType1_RS485, CommandType = CommandType.Read, Code = 11023, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение типа привода, контур 2
        /// </summary>
        public Command GetDriveType2_RS485 = new Command { CommandName = Ecl300Resources.GetDriveType2_RS485, ErrorMessage = Ecl300ErrorMessages.GetDriveType2_RS485, CommandType = CommandType.Read, Code = 12023, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение макс. наружной температуры X1, контур 1
        /// </summary>
        public Command GetOpenAirTemp_X1_1_RS485 = new Command { CommandName = Ecl300Resources.GetOpenAirTemp_X1_1_RS485, ErrorMessage = Ecl300ErrorMessages.GetOpenAirTemp_X1_1_RS485, CommandType = CommandType.Read, Code = 11030, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение макс. наружной температуры X1, контур 2
        /// </summary>
        public Command GetOpenAirTemp_X1_2_RS485 = new Command { CommandName = Ecl300Resources.GetOpenAirTemp_X1_2_RS485, ErrorMessage = Ecl300ErrorMessages.GetOpenAirTemp_X1_2_RS485, CommandType = CommandType.Read, Code = 12030, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y1, контур 1
        /// </summary>
        public Command GetReturnTemp_Y1_1_RS485 = new Command { CommandName = Ecl300Resources.GetReturnTemp_Y1_1_RS485, ErrorMessage = Ecl300ErrorMessages.GetReturnTemp_Y1_1_RS485, CommandType = CommandType.Read, Code = 11031, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y1, контур 2
        /// </summary>
        public Command GetReturnTemp_Y1_2_RS485 = new Command { CommandName = Ecl300Resources.GetReturnTemp_Y1_2_RS485, ErrorMessage = Ecl300ErrorMessages.GetReturnTemp_Y1_2_RS485, CommandType = CommandType.Read, Code = 12031, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение макс. наружной температуры X2, контур 1
        /// </summary>
        public Command GetOpenAirTemp_X2_1_RS485 = new Command { CommandName = Ecl300Resources.GetOpenAirTemp_X2_1_RS485, ErrorMessage = Ecl300ErrorMessages.GetOpenAirTemp_X2_1_RS485, CommandType = CommandType.Read, Code = 11032, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение  макс. наружной температуры X2, контур 2
        /// </summary>
        public Command GetOpenAirTemp_X2_2_RS485 = new Command { CommandName = Ecl300Resources.GetOpenAirTemp_X2_2_RS485, ErrorMessage = Ecl300ErrorMessages.GetOpenAirTemp_X2_2_RS485, CommandType = CommandType.Read, Code = 12032, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y2, контур 1
        /// </summary>
        public Command GetReturnTemp_Y2_1_RS485 = new Command { CommandName = Ecl300Resources.GetReturnTemp_Y2_1_RS485, ErrorMessage = Ecl300ErrorMessages.GetReturnTemp_Y2_1_RS485, CommandType = CommandType.Read, Code = 11033, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение температуры возвращаемого теплоносителя Y2, контур 2
        /// </summary>
        public Command GetReturnTemp_Y2_2_RS485 = new Command { CommandName = Ecl300Resources.GetReturnTemp_Y2_2_RS485, ErrorMessage = Ecl300ErrorMessages.GetReturnTemp_Y2_2_RS485, CommandType = CommandType.Read, Code = 12033, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение максимального влияния обратки, контур 1
        /// </summary>
        public Command GetMaxInfluenceReverse1_RS485 = new Command { CommandName = Ecl300Resources.GetMaxInfluenceReverse1_RS485, ErrorMessage = Ecl300ErrorMessages.GetMaxInfluenceReverse1_RS485, CommandType = CommandType.Read, Code = 11034, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение  максимального влияния обратки, контур 2
        /// </summary>
        public Command GetMaxInfluenceReverse2_RS485 = new Command { CommandName = Ecl300Resources.GetMaxInfluenceReverse2_RS485, ErrorMessage = Ecl300ErrorMessages.GetMaxInfluenceReverse2_RS485, CommandType = CommandType.Read, Code = 12034, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение минимального влияния обратки, контур 1
        /// </summary>
        public Command GetMinInfluenceReverse1_RS485 = new Command { CommandName = Ecl300Resources.GetMinInfluenceReverse1_RS485, ErrorMessage = Ecl300ErrorMessages.GetMinInfluenceReverse1_RS485, CommandType = CommandType.Read, Code = 11035, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение  минимального влияния обратки, контур 2
        /// </summary>
        public Command GetMinInfluenceReverse2_RS485 = new Command { CommandName = Ecl300Resources.GetMinInfluenceReverse2_RS485, ErrorMessage = Ecl300ErrorMessages.GetMinInfluenceReverse2_RS485, CommandType = CommandType.Read, Code = 12035, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение оптимизации температуры обратки по подаче, контур 1
        /// </summary>
        public Command GetReturnOptimizationViaSupply1_RS485 = new Command { CommandName = Ecl300Resources.GetReturnOptimizationViaSupply1_RS485, ErrorMessage = Ecl300ErrorMessages.GetReturnOptimizationViaSupply1_RS485, CommandType = CommandType.Read, Code = 11036, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение оптимизации температуры обратки по подаче, контур 2
        /// </summary>
        public Command GetReturnOptimizationViaSupply2_RS485 = new Command { CommandName = Ecl300Resources.GetReturnOptimizationViaSupply2_RS485, ErrorMessage = Ecl300ErrorMessages.GetReturnOptimizationViaSupply2_RS485, CommandType = CommandType.Read, Code = 12036, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение параллельной работы ГВС и контуров отопления, контур 1
        /// </summary>
        public Command GetParallelWorkHwsAndHeatSys1_RS485 = new Command { CommandName = Ecl300Resources.GetParallelWorkHwsAndHeatSys1_RS485, ErrorMessage = Ecl300ErrorMessages.GetParallelWorkHwsAndHeatSys1_RS485, CommandType = CommandType.Read, Code = 11042, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение ПИ-регулирования, контур 1
        /// </summary>
        public Command GetPIRegulation1_RS485 = new Command { CommandName = Ecl300Resources.GetPIRegulation1_RS485, ErrorMessage = Ecl300ErrorMessages.GetPIRegulation1_RS485, CommandType = CommandType.Read, Code = 11051, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение ПИ-регулирования, контур 2
        /// </summary>
        public Command GetPIRegulation2_RS485 = new Command { CommandName = Ecl300Resources.GetPIRegulation2_RS485, ErrorMessage = Ecl300ErrorMessages.GetPIRegulation2_RS485, CommandType = CommandType.Read, Code = 12051, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение защиты двигателя, контур 1
        /// </summary>
        public Command GetMotorProtection1_RS485 = new Command { CommandName = Ecl300Resources.GetMotorProtection1_RS485, ErrorMessage = Ecl300ErrorMessages.GetMotorProtection1_RS485, CommandType = CommandType.Read, Code = 11173, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение защиты двигателя, контур 2
        /// </summary>
        public Command GetMotorProtection2_RS485 = new Command { CommandName = Ecl300Resources.GetMotorProtection2_RS485, ErrorMessage = Ecl300ErrorMessages.GetMotorProtection2_RS485, CommandType = CommandType.Read, Code = 12173, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение автоматической смены сезонного времени, контур 1
        /// </summary>
        public Command GetChangeSeason1_RS485 = new Command { CommandName = Ecl300Resources.GetChangeSeason1_RS485, ErrorMessage = Ecl300ErrorMessages.GetChangeSeason1_RS485, CommandType = CommandType.Read, Code = 11197, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение желаемой комнатной температуры (комфорт), контур 1
        /// </summary>
        public Command GetRoomTempDaySet1_RS485 = new Command { CommandName = Ecl300Resources.GetRoomTempDaySet1_RS485, ErrorMessage = Ecl300ErrorMessages.GetRoomTempDaySet1_RS485, CommandType = CommandType.Read, Code = 11179, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение  желаемой комнатной температуры (комфорт), контур 2
        /// </summary>
        public Command GetRoomTempDaySet2_RS485 = new Command { CommandName = Ecl300Resources.GetRoomTempDaySet2_RS485, ErrorMessage = Ecl300ErrorMessages.GetRoomTempDaySet2_RS485, CommandType = CommandType.Read, Code = 12179, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение желаемой комнатной температуры (эконом), контур 1
        /// </summary>
        public Command GetRoomTempNightSet1_RS485 = new Command { CommandName = Ecl300Resources.GetRoomTempNightSet1_RS485, ErrorMessage = Ecl300ErrorMessages.GetRoomTempNightSet1_RS485, CommandType = CommandType.Read, Code = 11180, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение  желаемой комнатной температуры (эконом), контур 2
        /// </summary>
        public Command GetRoomTempNightSet2_RS485 = new Command { CommandName = Ecl300Resources.GetRoomTempNightSet2_RS485, ErrorMessage = Ecl300ErrorMessages.GetRoomTempNightSet2_RS485, CommandType = CommandType.Read, Code = 12180, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение желаемой температуры горячей воды (комфорт), контур 1
        /// </summary>
        public Command GetHotWaterTempDaySet1_RS485 = new Command { CommandName = Ecl300Resources.GetHotWaterTempDaySet1_RS485, ErrorMessage = Ecl300ErrorMessages.GetHotWaterTempDaySet1_RS485, CommandType = CommandType.Read, Code = 11189, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение желаемой температуры горячей воды (комфорт), контур 2
        /// </summary>
        public Command GetHotWaterTempDaySet2_RS485 = new Command { CommandName = Ecl300Resources.GetHotWaterTempDaySet2_RS485, ErrorMessage = Ecl300ErrorMessages.GetHotWaterTempDaySet2_RS485, CommandType = CommandType.Read, Code = 12189, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение желаемой температуры горячей воды (эконом), контур 1
        /// </summary>
        public Command GetHotWaterTempNightSet1_RS485 = new Command { CommandName = Ecl300Resources.GetHotWaterTempNightSet1_RS485, ErrorMessage = Ecl300ErrorMessages.GetHotWaterTempNightSet1_RS485, CommandType = CommandType.Read, Code = 11190, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение желаемой температуры горячей воды (эконом), контур 2
        /// </summary>
        public Command GetHotWaterTempNightSet2_RS485 = new Command { CommandName = Ecl300Resources.GetHotWaterTempNightSet2_RS485, ErrorMessage = Ecl300ErrorMessages.GetHotWaterTempNightSet2_RS485, CommandType = CommandType.Read, Code = 12190, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        #endregion

        /// <summary>
        /// Чтение ограничения температуры возвращаемого теплоносителя, контур 1
        /// </summary>
        public Command GetLimitReverseTemperature1_RS485 = new Command { CommandName = Ecl300Resources.GetLimitReverseTemperature1_RS485, ErrorMessage = Ecl300ErrorMessages.GetLimitReverseTemperature1_RS485, CommandType = CommandType.Read, Code = 11029, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение ограничения температуры возвращаемого теплоносителя, контур 2
        /// </summary>
        public Command GetLimitReverseTemperature2_RS485 = new Command { CommandName = Ecl300Resources.GetLimitReverseTemperature2_RS485, ErrorMessage = Ecl300ErrorMessages.GetLimitReverseTemperature2_RS485, CommandType = CommandType.Read, Code = 12029, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение флага автоматической настройки, контур 2
        /// </summary>
        public Command GetAutotuning2_RS485 = new Command { CommandName = Ecl300Resources.GetAutotuning2_RS485, ErrorMessage = Ecl300ErrorMessages.GetAutotuning2_RS485, CommandType = CommandType.Read, Code = 12172, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
    }
}

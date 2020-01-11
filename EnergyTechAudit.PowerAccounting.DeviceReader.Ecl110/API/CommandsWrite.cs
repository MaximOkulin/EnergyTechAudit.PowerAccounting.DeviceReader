using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API
{
    internal sealed partial class Commands
    {
        /// <summary>
        /// "Запись нового значения часа в текущее время прибора"
        /// </summary>
        public Command SetDeviceTimeHour = new Command { CommandName = Ecl110Resources.SetDeviceTimeHour, ErrorMessage = Ecl110ErrorMessages.SetDeviceTimeHour, CommandType = CommandType.Write, Code = 64044, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения минуты в текущее время прибора"
        /// </summary>
        public Command SetDeviceTimeMinute = new Command { CommandName = Ecl110Resources.SetDeviceTimeMinute, ErrorMessage = Ecl110ErrorMessages.SetDeviceTimeMinute, CommandType = CommandType.Write, Code = 64045, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения дня в текущее время прибора"
        /// </summary>
        public Command SetDeviceTimeDay = new Command { CommandName = Ecl110Resources.SetDeviceTimeDay, ErrorMessage = Ecl110ErrorMessages.SetDeviceTimeDay, CommandType = CommandType.Write, Code = 64046, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения месяца в текущее время прибора"
        /// </summary>
        public Command SetDeviceTimeMonth = new Command { CommandName = Ecl110Resources.SetDeviceTimeMonth, ErrorMessage = Ecl110ErrorMessages.SetDeviceTimeMonth, CommandType = CommandType.Write, Code = 64047, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения года в текущее время прибора"
        /// </summary>
        public Command SetDeviceTimeYear = new Command { CommandName = Ecl110Resources.SetDeviceTimeYear, ErrorMessage = Ecl110ErrorMessages.SetDeviceTimeYear, CommandType = CommandType.Write, Code = 64048, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11010"
        /// </summary>
        public Command SetPnu11010 = new Command { CommandName = Ecl110Resources.SetPnu11010, ErrorMessage = Ecl110ErrorMessages.SetPnu11010, CommandType = CommandType.Write, Code = 11010, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// "Запись нового значения в регистр 11011"
        /// </summary>
        public Command SetPnu11011 = new Command { CommandName = Ecl110Resources.SetPnu11011, ErrorMessage = Ecl110ErrorMessages.SetPnu11011, CommandType = CommandType.Write, Code = 11011, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11012"
        /// </summary>
        public Command SetPnu11012 = new Command { CommandName = Ecl110Resources.SetPnu11012, ErrorMessage = Ecl110ErrorMessages.SetPnu11012, CommandType = CommandType.Write, Code = 11012, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11013"
        /// </summary>
        public Command SetPnu11013 = new Command { CommandName = Ecl110Resources.SetPnu11013, ErrorMessage = Ecl110ErrorMessages.SetPnu11013, CommandType = CommandType.Write, Code = 11013, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11014"
        /// </summary>
        public Command SetPnu11014 = new Command { CommandName = Ecl110Resources.SetPnu11014, ErrorMessage = Ecl110ErrorMessages.SetPnu11014, CommandType = CommandType.Write, Code = 11014, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11019"
        /// </summary>
        public Command SetPnu11019 = new Command { CommandName = Ecl110Resources.SetPnu11019, ErrorMessage = Ecl110ErrorMessages.SetPnu11019, CommandType = CommandType.Write, Code = 11019, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11020"
        /// </summary>
        public Command SetPnu11020 = new Command { CommandName = Ecl110Resources.SetPnu11020, ErrorMessage = Ecl110ErrorMessages.SetPnu11020, CommandType = CommandType.Write, Code = 11020, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11021"
        /// </summary>
        public Command SetPnu11021 = new Command { CommandName = Ecl110Resources.SetPnu11021, ErrorMessage = Ecl110ErrorMessages.SetPnu11021, CommandType = CommandType.Write, Code = 11021, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11022"
        /// </summary>
        public Command SetPnu11022 = new Command { CommandName = Ecl110Resources.SetPnu11022, ErrorMessage = Ecl110ErrorMessages.SetPnu11022, CommandType = CommandType.Write, Code = 11022, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11023"
        /// </summary>
        public Command SetPnu11023 = new Command { CommandName = Ecl110Resources.SetPnu11023, ErrorMessage = Ecl110ErrorMessages.SetPnu11023, CommandType = CommandType.Write, Code = 11023, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11029"
        /// </summary>
        public Command SetPnu11029 = new Command { CommandName = Ecl110Resources.SetPnu11029, ErrorMessage = Ecl110ErrorMessages.SetPnu11029, CommandType = CommandType.Write, Code = 11029, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11034"
        /// </summary>
        public Command SetPnu11034 = new Command { CommandName = Ecl110Resources.SetPnu11034, ErrorMessage = Ecl110ErrorMessages.SetPnu11034, CommandType = CommandType.Write, Code = 11034, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11035"
        /// </summary>
        public Command SetPnu11035 = new Command { CommandName = Ecl110Resources.SetPnu11035, ErrorMessage = Ecl110ErrorMessages.SetPnu11035, CommandType = CommandType.Write, Code = 11035, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11036"
        /// </summary>
        public Command SetPnu11036 = new Command { CommandName = Ecl110Resources.SetPnu11036, ErrorMessage = Ecl110ErrorMessages.SetPnu11036, CommandType = CommandType.Write, Code = 11036, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11051"
        /// </summary>
        public Command SetPnu11051 = new Command { CommandName = Ecl110Resources.SetPnu11051, ErrorMessage = Ecl110ErrorMessages.SetPnu11051, CommandType = CommandType.Write, Code = 11051, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11076"
        /// </summary>
        public Command SetPnu11076 = new Command { CommandName = Ecl110Resources.SetPnu11076, ErrorMessage = Ecl110ErrorMessages.SetPnu11076, CommandType = CommandType.Write, Code = 11076, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11077"
        /// </summary>
        public Command SetPnu11077 = new Command { CommandName = Ecl110Resources.SetPnu11077, ErrorMessage = Ecl110ErrorMessages.SetPnu11077, CommandType = CommandType.Write, Code = 11077, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11084"
        /// </summary>
        public Command SetPnu11084 = new Command { CommandName = Ecl110Resources.SetPnu11084, ErrorMessage = Ecl110ErrorMessages.SetPnu11084, CommandType = CommandType.Write, Code = 11084, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11140"
        /// </summary>
        public Command SetPnu11140 = new Command { CommandName = Ecl110Resources.SetPnu11140, ErrorMessage = Ecl110ErrorMessages.SetPnu11140, CommandType = CommandType.Write, Code = 11140, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11161"
        /// </summary>
        public Command SetPnu11161 = new Command { CommandName = Ecl110Resources.SetPnu11161, ErrorMessage = Ecl110ErrorMessages.SetPnu11161, CommandType = CommandType.Write, Code = 11161, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11173"
        /// </summary>
        public Command SetPnu11173 = new Command { CommandName = Ecl110Resources.SetPnu11173, ErrorMessage = Ecl110ErrorMessages.SetPnu11173, CommandType = CommandType.Write, Code = 11173, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11174"
        /// </summary>
        public Command SetPnu11174 = new Command { CommandName = Ecl110Resources.SetPnu11174, ErrorMessage = Ecl110ErrorMessages.SetPnu11174, CommandType = CommandType.Write, Code = 11174, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11175"
        /// </summary>
        public Command SetPnu11175 = new Command { CommandName = Ecl110Resources.SetPnu11175, ErrorMessage = Ecl110ErrorMessages.SetPnu11175, CommandType = CommandType.Write, Code = 11175, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11176"
        /// </summary>
        public Command SetPnu11176 = new Command { CommandName = Ecl110Resources.SetPnu11176, ErrorMessage = Ecl110ErrorMessages.SetPnu11176, CommandType = CommandType.Write, Code = 11176, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11177"
        /// </summary>
        public Command SetPnu11177 = new Command { CommandName = Ecl110Resources.SetPnu11177, ErrorMessage = Ecl110ErrorMessages.SetPnu11177, CommandType = CommandType.Write, Code = 11177, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11178"
        /// </summary>
        public Command SetPnu11178 = new Command { CommandName = Ecl110Resources.SetPnu11178, ErrorMessage = Ecl110ErrorMessages.SetPnu11178, CommandType = CommandType.Write, Code = 11178, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11181"
        /// </summary>
        public Command SetPnu11181 = new Command { CommandName = Ecl110Resources.SetPnu11181, ErrorMessage = Ecl110ErrorMessages.SetPnu11181, CommandType = CommandType.Write, Code = 11181, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11182"
        /// </summary>
        public Command SetPnu11182 = new Command { CommandName = Ecl110Resources.SetPnu11182, ErrorMessage = Ecl110ErrorMessages.SetPnu11182, CommandType = CommandType.Write, Code = 11182, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11183"
        /// </summary>
        public Command SetPnu11183 = new Command { CommandName = Ecl110Resources.SetPnu11183, ErrorMessage = Ecl110ErrorMessages.SetPnu11183, CommandType = CommandType.Write, Code = 11183, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11184"
        /// </summary>
        public Command SetPnu11184 = new Command { CommandName = Ecl110Resources.SetPnu11184, ErrorMessage = Ecl110ErrorMessages.SetPnu11184, CommandType = CommandType.Write, Code = 11184, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11185"
        /// </summary>
        public Command SetPnu11185 = new Command { CommandName = Ecl110Resources.SetPnu11185, ErrorMessage = Ecl110ErrorMessages.SetPnu11185, CommandType = CommandType.Write, Code = 11185, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11186"
        /// </summary>
        public Command SetPnu11186 = new Command { CommandName = Ecl110Resources.SetPnu11186, ErrorMessage = Ecl110ErrorMessages.SetPnu11186, CommandType = CommandType.Write, Code = 11186, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11188"
        /// </summary>
        public Command SetPnu11188 = new Command { CommandName = Ecl110Resources.SetPnu11188, ErrorMessage = Ecl110ErrorMessages.SetPnu11188, CommandType = CommandType.Write, Code = 11188, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11179"
        /// </summary>
        public Command SetPnu11179 = new Command { CommandName = Ecl110Resources.SetPnu11179, ErrorMessage = Ecl110ErrorMessages.SetPnu11179, CommandType = CommandType.Write, Code = 11179, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// "Запись нового значения в регистр 11180"
        /// </summary>
        public Command SetPnu11180 = new Command { CommandName = Ecl110Resources.SetPnu11180, ErrorMessage = Ecl110ErrorMessages.SetPnu11180, CommandType = CommandType.Write, Code = 11180, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// "Запись нового значения в регистр 11092"
        /// </summary>
        public Command SetPnu11092 = new Command { CommandName = Ecl110Resources.SetPnu11092, ErrorMessage = Ecl110ErrorMessages.SetPnu11092, CommandType = CommandType.Write, Code = 11092, ModbusFunctionCode = ModbusFunction.PresetSingleRegister, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
    }
}

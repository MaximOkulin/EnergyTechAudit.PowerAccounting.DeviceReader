using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API
{
    /// <summary>
    /// Мета-описание API-команд регулятора Danfoss ECL Comfort 110
    /// </summary>
    internal sealed partial class Commands
    {
        /// <summary>
        /// Чтение 4 регистров 11200-11203
        /// </summary>
        public Command GetPnu11200_11203 = new Command { CommandName = Ecl110Resources.GetPnu11200_11203, ErrorMessage = Ecl110ErrorMessages.GetPnu11200_11203, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11200, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
        /// <summary>
        /// Чтение 5 регистров 64044-64048
        /// </summary>
        public Command GetDeviceTime = new Command { CommandName = Ecl110Resources.GetDeviceTime, ErrorMessage = Ecl110ErrorMessages.GetDeviceTime, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 64044, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// Чтение 2 регистров 11228-11229
        /// </summary>
        public Command GetPnu11228_11229 = new Command { CommandName = Ecl110Resources.GetPnu11228_11229, ErrorMessage = Ecl110ErrorMessages.GetPnu11228_11229, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11228, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение 5 регистров 11010-11014
        /// </summary>
        public Command GetPnu11010_11014 = new Command { CommandName = Ecl110Resources.GetPnu11010_11014, ErrorMessage = Ecl110ErrorMessages.GetPnu11010_11014, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11010, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// Чтение 5 регистров 11019-11023
        /// </summary>
        public Command GetPnu11019_11023 = new Command { CommandName = Ecl110Resources.GetPnu11019_11023, ErrorMessage = Ecl110ErrorMessages.GetPnu11019_11023, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11019, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Fixed, ResponseLength = 15 };
        /// <summary>
        /// Чтение 2 регистров 11021-11022
        /// </summary>
        public Command GetPnu11021_11022 = new Command { CommandName = Ecl110Resources.GetPnu11021_11022, ErrorMessage = Ecl110ErrorMessages.GetPnu11021_11022, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11021, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение 3 регистров 11034-11036
        /// </summary>
        public Command GetPnu11034_11036 = new Command { CommandName = Ecl110Resources.GetPnu11034_11036, ErrorMessage = Ecl110ErrorMessages.GetPnu11034_11036, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11034, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Fixed, ResponseLength = 11 };

        /// <summary>
        /// Чтение регистра 11029
        /// </summary>
        public Command GetPnu11029 = new Command { CommandName = Ecl110Resources.GetPnu11029, ErrorMessage = Ecl110ErrorMessages.GetPnu11029, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11029, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение регистра 11051
        /// </summary>
        public Command GetPnu11051 = new Command { CommandName = Ecl110Resources.GetPnu11051, ErrorMessage = Ecl110ErrorMessages.GetPnu11051, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11051, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение регистра 11084
        /// </summary>
        public Command GetPnu11084 = new Command { CommandName = Ecl110Resources.GetPnu11084, ErrorMessage = Ecl110ErrorMessages.GetPnu11084, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11084, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение регистра 11140
        /// </summary>
        public Command GetPnu11140 = new Command { CommandName = Ecl110Resources.GetPnu11140, ErrorMessage = Ecl110ErrorMessages.GetPnu11140, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11140, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение регистра 11161
        /// </summary>
        public Command GetPnu11161 = new Command { CommandName = Ecl110Resources.GetPnu11161, ErrorMessage = Ecl110ErrorMessages.GetPnu11161, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11161, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение регистров 11076-11077
        /// </summary>
        public Command GetPnu11076_11077 = new Command { CommandName = Ecl110Resources.GetPnu11076_11077, ErrorMessage = Ecl110ErrorMessages.GetPnu11076_11077, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11076, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение регистров 11173-11180
        /// </summary>
        public Command GetPnu11173_11180 = new Command { CommandName = Ecl110Resources.GetPnu11173_11180, ErrorMessage = Ecl110ErrorMessages.GetPnu11173_11180, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11173, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Fixed, ResponseLength = 21 };
        /// <summary>
        /// Чтение регистров 11181-11186
        /// </summary>
        public Command GetPnu11181_11186 = new Command { CommandName = Ecl110Resources.GetPnu11181_11186, ErrorMessage = Ecl110ErrorMessages.GetPnu11181_11186, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11181, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 6, ResponseLengthType = LengthType.Fixed, ResponseLength = 17 };
        /// <summary>
        /// Чтение регистра 11188
        /// </summary>
        public Command GetPnu11188 = new Command { CommandName = Ecl110Resources.GetPnu11188, ErrorMessage = Ecl110ErrorMessages.GetPnu11188, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11188, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение регистра 11092
        /// </summary>
        public Command GetPnu11092 = new Command { CommandName = Ecl110Resources.GetPnu11092, ErrorMessage = Ecl110ErrorMessages.GetPnu11092, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11092, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
        /// <summary>
        /// Чтение регистров 11176-11177
        /// </summary>
        public Command GetPnu11176_11177 = new Command { CommandName = Ecl110Resources.GetPnu11176_11177, ErrorMessage = Ecl110ErrorMessages.GetPnu11176_11177, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11176, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        /// <summary>
        /// Чтение регистров 11183-11186
        /// </summary>
        public Command GetPnu11183_11186 = new Command { CommandName = Ecl110Resources.GetPnu11183_11186, ErrorMessage = Ecl110ErrorMessages.GetPnu11183_11186, CanBeSkip = CanBeSkip.Yes, CommandType = CommandType.Read, Code = 11183, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem
{
    public class Commands
    {
        /// <summary>
        /// Чтение скорости порта
        /// </summary>
        public Command GetBaudRate = new Command { CommandName = EtaModemResources.GetBaudRate, CommandType = CommandType.Read, Code = 0x00CE, RegistersCount = 2, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 9 };
        
        /// <summary>
        /// Чтение формата кадра данных последовательного порта
        /// </summary>
        public Command GetDataFormat = new Command { CommandName = EtaModemResources.GetDataFormat, CommandType = CommandType.Read, Code = 0x00D2, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Чтение текущей версии прошивки
        /// </summary>
        public Command ReadSoftware = new Command { CommandName = EtaModemResources.ReadSoftware, Code = 24, CommandType = CommandType.Read, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };

        /// <summary>
        /// Запись скорости порта
        /// </summary>
        public Command SetBaudRate = new Command { CommandName = EtaModemResources.SetBaudRate, CommandType = CommandType.Write, Code = 0x00CE, ModbusFunctionCode = ModbusFunction.PresetMultipleRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        /// <summary>
        /// Запись формата кадра данных последовательного порта
        /// </summary>
        public Command SetDataFormat = new Command { CommandName = EtaModemResources.SetDataFormat, CommandType = CommandType.Write, Code = 0x00D2, ModbusFunctionCode = ModbusFunction.PresetMultipleRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        public Command SaveSettings = new Command { CommandName = EtaModemResources.SaveSettings, CommandType = CommandType.Write, Code = 0, ModbusFunctionCode = ModbusFunction.PresetMultipleRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        /// <summary>
        /// Чтение текущих состояний дискретных входов
        /// </summary>
        public Command GetInputs = new Command { CommandName = EtaModemResources.GetInputs, Code = 0, CommandType = CommandType.Read, RegistersCount = 1, ModbusFunctionCode = ModbusFunction.ReadInputRegisters, ResponseLengthType = LengthType.Fixed, ResponseLength = 7 };
    }
}

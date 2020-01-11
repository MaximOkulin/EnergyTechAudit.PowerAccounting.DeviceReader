using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Helpers
{
    /// <summary>
    /// Класс, формирующий пакет байтов согласно протоколу Modbus
    /// </summary>
    internal sealed class ModbusPackageHelper : ModbusPackageHelperBase
    {
        /// <summary>
        /// Возвращает пакет на чтение данных
        /// </summary>
        /// <param name="networkAddress">Сетевой адрес устройства</param>
        /// <param name="cmd">Команда ВКТ-7</param>
        /// <param name="registersCount">Количество регистров для чтения</param>
        protected override byte[] ReadCommand(int networkAddress, Command cmd, int registersCount = 0)
        {
            var command = ModbusProtocol.GetReadRequest(new ModbusFunctionData
            {
                DeviceAddress = networkAddress,
                Function = ModbusFunction.ReadHoldingRegisters,
                StartingAddress = cmd.Code,
                RegistersCount = registersCount
            }, ModbusMode.RTU);

            command = WrapIdleBytes(command);
            return command;
        }

        /// <summary>
        /// Возвращает пакет на запись данных
        /// </summary>
        /// <param name="networkAddress">Сетевой адрес устройства</param>
        /// <param name="cmd">Команда ВКТ-7</param>
        /// <param name="action">Действие по заполнению данных пакета</param>
        protected override byte[] WriteCommand(int networkAddress, Command cmd, Action<ModbusFunctionData> action = null)
        {
            var functionData = new ModbusFunctionData
            {
                DeviceAddress = networkAddress,
                Function = ModbusFunction.PresetMultipleRegisters,
                StartingAddress = cmd.Code,
            };

            if (action != null)
            {
                action(functionData);
            }

            var command = ModbusProtocol.GetWriteRequest(functionData, ModbusMode.RTU);

            command = WrapIdleBytes(command);

            return command;
        }

        /// <summary>
        /// Добавляет в начало пакета два байта FF FF
        /// </summary>
        /// <param name="buffer">Пакет</param>
        private static byte[] WrapIdleBytes(byte[] buffer)
        {
            var wrappedTemplate = new byte[buffer.Length + 2];
            wrappedTemplate[0] = 0xFF;
            wrappedTemplate[1] = 0xFF;
            Array.Copy(buffer, 0, wrappedTemplate, 2, buffer.Length);
            return wrappedTemplate;
        }
    }
}

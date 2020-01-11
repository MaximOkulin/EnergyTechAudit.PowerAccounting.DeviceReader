using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl.Helpers
{
    /// <summary>
    /// Класс, формирующий пакет байтов согласно протоколу Modbus
    /// </summary>
    public sealed class ModbusPackageHelper : ModbusPackageHelperBase
    {
        public ModbusPackageHelper()
        {

        }

        public ModbusPackageHelper(int networkAddress):base(networkAddress)
        {

        }
        protected override byte[] WriteCommand(int networkAddress, Command cmd,
            Action<ModbusFunctionData> action = null)
        {
            var functionData = new ModbusFunctionData
            {
                DeviceAddress = networkAddress,
                Function = ModbusFunction.PresetSingleRegister,
                StartingAddress = cmd.Code
            };

            action?.Invoke(functionData);

            var command = ModbusProtocol.GetWriteRequest(functionData, ModbusMode.RTU, false, false);

            return command;
        }


        public byte[] WriteCommand(Command cmd, Action<ModbusFunctionData> action = null)
        {
            return WriteCommand(DeviceAddress, cmd, action);
        }
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Modbus
{
    public class ModbusTcpPackageHelper
    {
        private ModbusPackageHelperBase _modbusHelper;
        private short _packageCounter = 1;

        public ModbusTcpPackageHelper(int deviceAddress)
        {
            _modbusHelper = new ModbusPackageHelperBase(deviceAddress);
        }

        public byte[] GetCommand(Command cmd)
        {
            var classicModbusPackage = _modbusHelper.GetCommand(cmd);
            // удаляем байты CRC16
            classicModbusPackage = classicModbusPackage.Take(classicModbusPackage.Length - 2).ToArray();

            _packageCounter++;

            var package = new List<byte>();
            package.AddRange(BitConverter.GetBytes(_packageCounter)); // идентификатор транзакции
            package.AddRange(new byte[] { 0x00, 0x00 }); // идентификатор протокола
            package.AddRange(classicModbusPackage.Length.ToTwoBigEndianBytes()); // длина сообщения
            package.AddRange(classicModbusPackage); // основное тело сообщения

            return package.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Helpers
{
    /// <summary>
    /// Класс, формирующий пакет байтов согласно протоколу Modbus
    /// </summary>
    internal sealed class ModbusPackageHelper : ModbusPackageHelperBase
    {
        public ModbusPackageHelper(ModbusMode modbusMode):base(modbusMode)
        {

        }
    }
}

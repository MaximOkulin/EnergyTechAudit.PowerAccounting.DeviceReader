using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Modbus
{
    /// <summary>
    /// Режим передачи данных
    /// </summary>
    public enum ModbusMode
    {
        RTU = 0,
        ASCII = 1
    }
}

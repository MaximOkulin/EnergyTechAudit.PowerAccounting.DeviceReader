using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using System;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Helpers
{
    internal sealed class PackageHelper
    { 
        /// <summary>
        /// Возвращает пакет байтов для выполнения заданной команды
        /// </summary>
        /// <param name="cmd">Команда</param>
        public byte[] GetCommand(Command cmd, byte[] bytes = null)
        {
            var package = new List<byte>();
            package.AddRange(BitConverter.GetBytes((short)cmd.Code));

            if (cmd.CommandType == CommandType.Read)
            {
                package.AddRange(new byte[] { 0x00, 0x00 });
            }
            else if(cmd.CommandType == CommandType.Write && bytes != null)
            {
                package.AddRange(bytes);
            }

            // контрольная сумма
            package.Add(package.ToArray().Xor());

            return package.ToArray();
        }
    }
}

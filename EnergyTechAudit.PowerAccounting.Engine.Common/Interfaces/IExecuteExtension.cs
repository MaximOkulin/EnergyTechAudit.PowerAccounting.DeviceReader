using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces
{
    public interface IExecuteExtension
    {
        Dictionary<string, string> ExecuteExtension(string commandName);
    }
}

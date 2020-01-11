using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    public class Km5Exception : Exception
    {
        public Km5Exception(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}

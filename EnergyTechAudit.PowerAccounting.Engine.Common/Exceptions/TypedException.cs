using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    public class TypedException : Exception
    {
        public ErrorType ErrorCode;

        public TypedException(string message, ErrorType errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

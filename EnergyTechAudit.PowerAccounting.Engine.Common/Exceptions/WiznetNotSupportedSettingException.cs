using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    public class WiznetNotSupportedSettingException : Exception
    {
        public WiznetNotSupportedSettingException(string message) : base(message)
        {
            
        }
    }
}

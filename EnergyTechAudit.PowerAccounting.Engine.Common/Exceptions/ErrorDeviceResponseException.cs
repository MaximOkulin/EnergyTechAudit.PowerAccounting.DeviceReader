using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    public class ErrorDeviceResponseException : Exception
    {
        private readonly string _info;
        public ErrorDeviceResponseException(string info)
        {
            _info = info;
        }

        public string Info
        {
            get
            {
                return _info;
            }
        }
    }
}

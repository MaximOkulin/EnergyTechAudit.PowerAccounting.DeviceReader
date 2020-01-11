using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    public class LostConnectionException : Exception
    {
        private readonly string _info;

        public LostConnectionException(string info = null)
        {
            _info = info;
        }

        public string Info
        {
            get { return _info; }
        }
    }
}

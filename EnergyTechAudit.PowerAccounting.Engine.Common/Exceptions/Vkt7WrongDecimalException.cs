using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    public class Vkt7WrongDecimalException : Exception
    {
        public string QualityByte;
        public string EmerByte;
        public Vkt7WrongDecimalException(string message, string qualityByte, string emerByte) : base(message)
        {
            QualityByte = qualityByte;
            EmerByte = emerByte;
        }
    }
}

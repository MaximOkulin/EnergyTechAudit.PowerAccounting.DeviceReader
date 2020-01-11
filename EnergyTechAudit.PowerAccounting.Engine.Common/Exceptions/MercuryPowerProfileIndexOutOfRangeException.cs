using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    /// <summary>
    /// Исключение, генерируемое когда заданная дата профиля мощности выходит
    /// за пределы доступных дат
    /// </summary>
    public class MercuryPowerProfileIndexOutOfRangeException : Exception
    {
    }
}

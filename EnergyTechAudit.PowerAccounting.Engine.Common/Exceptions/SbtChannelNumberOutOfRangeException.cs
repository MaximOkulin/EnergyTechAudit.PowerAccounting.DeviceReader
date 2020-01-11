using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    /// <summary>
    /// Исключение сигнализирующее о том, что указанный номер канала СБТ-адаптера
    /// находится за пределами допустимого диапазона
    /// </summary>
    public class SbtChannelNumberOutOfRangeException : Exception
    {
    }
}

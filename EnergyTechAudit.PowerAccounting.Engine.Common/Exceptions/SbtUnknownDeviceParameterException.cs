using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    /// <summary>
    /// Исключение, генерируемое когда невозможно определить параметр устройства
    /// для сохранения архивного значения
    /// </summary>
    public class SbtUnknownDeviceParameterException : Exception
    {
    }
}

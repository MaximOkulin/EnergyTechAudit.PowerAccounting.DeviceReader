using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    /// <summary>
    /// Исключение, генерируемое когда заданный радиоадаптер присутствует в базе коммуникатора,
    /// но архивные данные отсутствуют
    /// </summary>
    public class SbtArchiveRowNotFoundException : Exception
    {
    }
}

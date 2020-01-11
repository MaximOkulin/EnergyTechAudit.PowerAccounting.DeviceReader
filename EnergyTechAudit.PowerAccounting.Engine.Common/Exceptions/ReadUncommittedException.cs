using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions
{
    /// <summary>
    /// Исключение возникающее при ошибке чтения данных из БД в режиме транзакции ReadUncommitted
    /// </summary>
    public class ReadUncommittedException : Exception
    {
        public ReadUncommittedException(string message): base(message)
        {

        }
    }
}

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy
{
    /// <summary>
    /// Статус выполнения задачи
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Создана
        /// </summary>
        Created = 1,
        /// <summary>
        /// В обработке
        /// </summary>
        Process = 2,
        /// <summary>
        /// Завершена
        /// </summary>
        Completed = 3
    }
}

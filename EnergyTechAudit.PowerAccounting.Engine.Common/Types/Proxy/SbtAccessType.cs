namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy
{
    /// <summary>
    /// Способ доступа к данным прибора через СБТ-Солярис
    /// </summary>
    public enum SbtAccessType
    {
        /// <summary>
        /// Неизвестен
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Из архива контроллера
        /// </summary>
        ControllerArchive = 1,
        /// <summary>
        /// Прямой доступ через радиоадаптер
        /// </summary>
        Direct = 2
    }
}

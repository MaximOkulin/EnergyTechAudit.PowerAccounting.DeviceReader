namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy
{
    public enum Task
    {
        /// <summary>
        /// Присоединить устройства к пользователю
        /// </summary>
        DoUserLinkMeasurementDevice = 1,
        /// <summary>
        /// Выгрузить XML-пакет архива устройства
        /// </summary>
        DownloadArchivePackageBy = 2,
        /// <summary>
        /// Удалить архивы прибора
        /// </summary>
        DeleteArchives = 3
    }
}

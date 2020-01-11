using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes
{
    /// <summary>
    /// Возможности прошивки измерительного прибора
    /// </summary>
    internal sealed class DeviceFeatures
    {
        public bool IsGetDateIntervalSupports;
        public bool IsGetCurrentTimeSupports;

        private readonly Firmware _deviceFirmware;

        public DeviceFeatures(Firmware deviceFrimware)
        {
            _deviceFirmware = deviceFrimware;
            CheckGetDateIntervalSupports();
            CheckGetCurrentTimeSupports();
        }
        /// <summary>
        /// Определяет поддерживает ли прибор функцию чтения текущих и архивных дат
        /// </summary>
        private void CheckGetDateIntervalSupports()
        {
            IsGetDateIntervalSupports = _deviceFirmware.IsSupportFeature(new Firmware(1, 7));
        }

        /// <summary>
        /// Определяет поддерживает ли прибор функцию чтения текущей даты и времени 
        /// с минутным и секундным компонентами
        /// </summary>
        private void CheckGetCurrentTimeSupports()
        {
            IsGetCurrentTimeSupports = _deviceFirmware.IsSupportFeature(new Firmware(2, 7));
        }
    }
}

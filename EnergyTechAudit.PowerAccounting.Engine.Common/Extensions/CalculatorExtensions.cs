using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Interfaces;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions
{
    /// <summary>
    /// Расширения, выполняющие расчеты
    /// </summary>
    public static class CalculatorExtensions
    {
        /// <summary>
        /// Устанавливает время последнего подключения
        /// </summary>
        public static void SetLastConnectionParams<T>(T entity) where T : ISuccessConnectionPercent
        {
            // устанавливаем время последнего подключения
            entity.LastConnectionTime = DateTime.Now;
        }

        /// <summary>
        /// Рассчитывает уровень сигнала в дБ
        /// </summary>
        /// <param name="signal">Уровень сигнала в единицах AT-команд</param>
        public static int CalculateSignalLevel(this int signal)
        {
            int signalLevel = 0;
            // 99 - качество сигнала неизвестно или неопределено
            if (signal != 99)
            {
                signalLevel = -113 + signal * 2;
            }
            return signalLevel;
        }

        /// <summary>
        /// Рассчитывает время следующего запуска опроса
        /// </summary>
        /// <param name="previousStartTime">Предыдущее время опроса</param>
        /// <param name="pollingInterval">Период опроса прибора</param>
        public static DateTime CalculateNextStartTime(this DateTime previousStartTime, int pollingInterval)
        {
            var dt = previousStartTime.Year == 1900 ? DateTime.Now : previousStartTime.AddMinutes(pollingInterval);
            return DateTime.SpecifyKind(dt, DateTimeKind.Unspecified);
        }
    }
}

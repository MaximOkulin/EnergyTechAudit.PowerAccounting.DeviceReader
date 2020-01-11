using EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types.Precisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.Types
{
    public class ArchiveInfo
    {
        /// <summary>
        /// Текущее число записей в архиве
        /// </summary>
        public int ArchiveRecordCount { get; set; }
        /// <summary>
        /// Индекс будущей записи в архиве
        /// </summary>
        public int NextRecordIndex { get; set; }
        /// <summary>
        /// Предельное число записей в архиве
        /// </summary>
        public int MaxArchiveRecord { get; set; }
        /// <summary>
        /// Дата и время обновления архива
        /// </summary>
        public DateTime RefreshDate { get; set; }
        /// <summary>
        /// Длина архива
        /// </summary>
        public int ArchiveLen { get; set; }
        /// <summary>
        /// Список архивируемых параметров в порядке их приоритетов
        /// </summary>
        public ArchiveHeatSystemParams ArchiveHeatSystemParams { get; set; }
        /// <summary>
        /// Номер теплосистемы
        /// </summary>
        public int SystemNumber { get; set; }
        /// <summary>
        /// Точность
        /// </summary>
        public FinalInstantParamsPrecisions Precisions { get; set; }
        /// <summary>
        /// Текущие итоговые данные на дату обновления архива
        /// </summary>
        public FinalInstantValuesForHour FinalInstantValues { get; set; }
    }
}

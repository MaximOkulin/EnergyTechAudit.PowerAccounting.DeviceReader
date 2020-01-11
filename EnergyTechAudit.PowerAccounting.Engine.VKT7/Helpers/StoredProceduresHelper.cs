using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Helpers
{
    internal sealed class StoredProceduresHelper
    {
        private readonly LightDatabaseContext _context;
        private readonly PeriodType _periodType;
        private readonly int _measurementDeviceId;

        public StoredProceduresHelper(LightDatabaseContext context, PeriodType periodType, int measurementDeviceId)
        {
            _context = context;
            _periodType = periodType;
            _measurementDeviceId = measurementDeviceId;
        }

        /// <summary>
        /// Рассчитывает стартовое значение накопительных параметров относительно ближайшего итогового архива (новая модель параметров)
        /// </summary>
        /// <param name="startDate">Начальная дата нерассчитанных архивов</param>
        /// <param name="finalDate">Дата ближайшего итогового архива</param>
        public IntegratingParameters CalculateStartingPoint(DateTime startDate, DateTime finalDate)
        {
            return ((IObjectContextAdapter)_context)
                            .ObjectContext
                            .ExecuteStoreQuery<IntegratingParameters>(
                                "EXEC [Programmability].[CalculateVkt7StartingPoint] @MeasurementDeviceId, @PeriodTypeId, @StartDate, @FinalDate",
                                new object[]
                                {
                                    new SqlParameter("@MeasurementDeviceId", _measurementDeviceId) { SqlDbType = SqlDbType.Int},
                                    new SqlParameter("@PeriodTypeId", (int) _periodType) { SqlDbType = SqlDbType.Int},
                                    new SqlParameter("@StartDate", startDate) { SqlDbType = SqlDbType.DateTime },
                                    new SqlParameter("@FinalDate", finalDate) { SqlDbType = SqlDbType.DateTime },
                                }).First();
        }

        
        /// <summary>
        /// Возвращает значения накопительных параметров по времени (новая модель параметров)
        /// </summary>
        /// <param name="time">Время</param>
        /// <param name="isDiff">true - возвращать разностные значения; false - возвращать суммированные значения</param>
        public IntegratingParameters GetIntegratingParametersByTime(DateTime time, bool isDiff = false)
        {
            return ((IObjectContextAdapter)_context)
                            .ObjectContext
                            .ExecuteStoreQuery<IntegratingParameters>(
                                "EXEC [Programmability].[GetVkt7IntegratingParameters] @MeasurementDeviceId, @PeriodTypeId, @Time, @IsDiff",
                                new object[]
                                {
                                    new SqlParameter("@MeasurementDeviceId", _measurementDeviceId) { SqlDbType = SqlDbType.Int },
                                    new SqlParameter("@PeriodTypeId", (int) _periodType) { SqlDbType = SqlDbType.Int },
                                    new SqlParameter("@Time", time) { SqlDbType = SqlDbType.DateTime },
                                    new SqlParameter("@IsDiff", isDiff) { SqlDbType = SqlDbType.Bit }
                                }).First();
        }

        /// <summary>
        /// Возвращает диапазон дат нерассчитанных архивов (новая модель параметров)
        /// </summary>
        public NotCalculatedDates GetNotCalculatedDates()
        {
            return ((IObjectContextAdapter)_context)
                    .ObjectContext
                    .ExecuteStoreQuery<NotCalculatedDates>("EXEC [Programmability].[GetVkt7MinMaxNotCalculatedDates] @MeasurementDeviceId, @PeriodTypeId",
                        new object[] { new SqlParameter("@MeasurementDeviceId", _measurementDeviceId) { SqlDbType = SqlDbType.Int },
                                       new SqlParameter("@PeriodTypeId", (int)_periodType) { SqlDbType = SqlDbType.Int }}).First();
        }
    }
}

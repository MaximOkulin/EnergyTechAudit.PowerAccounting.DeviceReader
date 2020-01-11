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
    internal sealed class NewStoredProceduresHelper
    {
        private readonly LightDatabaseContext _context;
        private readonly PeriodType _periodType;
        private readonly int _measurementDeviceId;

        public NewStoredProceduresHelper(LightDatabaseContext context, PeriodType periodType, int measurementDeviceId)
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
        /// <param name="diffParameterId">Идентификатор параметра, содержащего потребление за интервал</param>
        /// <param name="sumParameterId">Идентификатор параметра, содержащего интегратор</param>
        public decimal? CalculateStartingPointForPart(DateTime startDate, DateTime finalDate, int diffParameterId, int sumParameterId)
        {
            return ((IObjectContextAdapter)_context)
                            .ObjectContext
                            .ExecuteStoreQuery<decimal>(
                                "EXEC [Programmability].[CalculateVkt7StartingPointForPart] @MeasurementDeviceId, @PeriodTypeId, @DiffParameterId, @SumParameterId, @StartDate, @FinalDate",
                                new object[]
                                {
                                    new SqlParameter("@MeasurementDeviceId", _measurementDeviceId) { SqlDbType = SqlDbType.Int},
                                    new SqlParameter("@PeriodTypeId", (int) _periodType) { SqlDbType = SqlDbType.Int},
                                    new SqlParameter("@DiffParameterId", diffParameterId) {SqlDbType = SqlDbType.Int}, 
                                    new SqlParameter("@SumParameterId", sumParameterId) {SqlDbType = SqlDbType.Int}, 
                                    new SqlParameter("@StartDate", startDate) { SqlDbType = SqlDbType.DateTime },
                                    new SqlParameter("@FinalDate", finalDate) { SqlDbType = SqlDbType.DateTime },
                                }).First();
        }

        
        /// <summary>
        /// Возвращает значения накопительных параметров по времени (новая модель параметров)
        /// </summary>
        /// <param name="time">Время</param>
        /// <param name="isDiff">true - возвращать разностные значения; false - возвращать суммированные значения</param>
        /// <param name="diffParameterId">Идентификатор параметра, содержащего потребление за интервал</param>
        /// <param name="sumParameterId">Идентификатор параметра, содержащего интегратор</param>
        public decimal? GetIntegratingParametersByTimeForPart(DateTime time, int diffParameterId, int sumParameterId, bool isDiff = false)
        {
            return ((IObjectContextAdapter)_context)
                            .ObjectContext
                            .ExecuteStoreQuery<decimal?>(
                                "EXEC [Programmability].[GetVkt7IntegratingParametersForPart] @MeasurementDeviceId, @PeriodTypeId, @DiffParameterId, @SumParameterId, @Time, @IsDiff",
                                new object[]
                                {
                                    new SqlParameter("@MeasurementDeviceId", _measurementDeviceId) { SqlDbType = SqlDbType.Int },
                                    new SqlParameter("@PeriodTypeId", (int) _periodType) { SqlDbType = SqlDbType.Int },
                                    new SqlParameter("@Time", time) { SqlDbType = SqlDbType.DateTime },
                                    new SqlParameter("@DiffParameterId", diffParameterId) {SqlDbType = SqlDbType.Int}, 
                                    new SqlParameter("@SumParameterId", sumParameterId) {SqlDbType = SqlDbType.Int}, 
                                    new SqlParameter("@IsDiff", isDiff) { SqlDbType = SqlDbType.Bit }
                                }).First();
        }

        /// <summary>
        /// Возвращает диапазон дат нерассчитанных архивов (новая модель параметров)
        /// </summary>
        /// <param name="diffParameterId">Идентификатор параметра, содержащего потребление за интервал</param>
        /// <param name="sumParameterId">Идентификатор параметра, содержащего интегратор</param>
        public NotCalculatedDates GetNotCalculatedDatesForPart(int diffParameterId, int sumParameterId)
        {
            return ((IObjectContextAdapter)_context)
                    .ObjectContext
                    .ExecuteStoreQuery<NotCalculatedDates>("EXEC [Programmability].[GetVkt7MinMaxNotCalculatedDatesForPart] @MeasurementDeviceId, @PeriodTypeId, @DiffParameterId, @SumParameterId",
                        new object[] { new SqlParameter("@MeasurementDeviceId", _measurementDeviceId) { SqlDbType = SqlDbType.Int },
                                       new SqlParameter("@DiffParameterId", diffParameterId) {SqlDbType = SqlDbType.Int}, 
                                       new SqlParameter("@SumParameterId", sumParameterId) {SqlDbType = SqlDbType.Int}, 
                                       new SqlParameter("@PeriodTypeId", (int)_periodType) { SqlDbType = SqlDbType.Int }}).First();
        }
    }
}

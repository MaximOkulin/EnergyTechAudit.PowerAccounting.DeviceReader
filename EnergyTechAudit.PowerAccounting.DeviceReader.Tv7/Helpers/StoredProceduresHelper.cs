using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Integrating;
using EnergyTechAudit.PowerAccounting.LightDataAccess;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Helpers
{
    internal sealed class StoredProceduresHelper : StoredProcedureHelperBase
    {
        public StoredProceduresHelper(LightDatabaseContext context, int measurementDeviceId)
            : base(context, measurementDeviceId)
        {
            
        }

        /// <summary>
        /// Рассчитывает стартовое значение накопительных параметров относительно ближайшего итогового архива
        /// </summary>
        /// <param name="startDate">Начальная дата нерассчитанных архивов</param>
        /// <param name="finalDate">Дата ближайшего итогового архива</param>
        public IntegratingParameters CalculateStartingPoint(DateTime startDate, DateTime finalDate)
        {
            return ((IObjectContextAdapter) Context)
                .ObjectContext
                .ExecuteStoreQuery<IntegratingParameters>(
                    "EXEC [Programmability].[CalculateTv7StartingPoint] @MeasurementDeviceId, @StartDate, @FinalDate",
                    new object[]
                    {
                        new SqlParameter("@MeasurementDeviceId", MeasurementDeviceId) { SqlDbType = SqlDbType.Int}, 
                        new SqlParameter("@StartDate", startDate) { SqlDbType = SqlDbType.DateTime }, 
                        new SqlParameter("@FinalDate", finalDate) { SqlDbType = SqlDbType.DateTime }, 
                    }
                ).First();
        }

        /// <summary>
        /// Возвращает значения накопительных параметров по времени
        /// </summary>
        /// <param name="time">Время</param>
        /// <param name="isDiff">true - возвращать разностные значения; false - возвращать суммированные значения</param>
        public IntegratingParameters GetIntegratingParametersByTime(DateTime time, bool isDiff = false)
        {
            return ((IObjectContextAdapter) Context)
                .ObjectContext
                .ExecuteStoreQuery<IntegratingParameters>(
                    "EXEC [Programmability].[GetTv7IntegratingParameters] @MeasurementDeviceId, @Time, @IsDiff",
                    new object[]
                    {
                        new SqlParameter("@MeasurementDeviceId", MeasurementDeviceId) {SqlDbType = SqlDbType.Int},
                        new SqlParameter("@Time", time) {SqlDbType = SqlDbType.DateTime},
                        new SqlParameter("@IsDiff", isDiff) {SqlDbType = SqlDbType.Bit},
                    }).First();
        }

        /// <summary>
        /// Возвращает диапазон дат нерассчитанных часовых архивов
        /// </summary>
        public NotCalculatedDates GetNotCalculatedDates()
        {
            return ((IObjectContextAdapter) Context)
                .ObjectContext
                .ExecuteStoreQuery<NotCalculatedDates>(
                    "EXEC [Programmability].[GetTv7MinMaxHourNotCalculatedDates] @MeasurementDeviceId",
                    new object[]
                    { new SqlParameter("@MeasurementDeviceId", MeasurementDeviceId) {SqlDbType = SqlDbType.Int}}).First();
        }
    }
}

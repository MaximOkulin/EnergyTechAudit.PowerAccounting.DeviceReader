using System;
using System.Data;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System.Collections.Generic;
using System.Linq.Expressions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic.Helpers
{
    public class ArchiveHelper : IDisposable
    {
        private readonly int _measurementDeviceId;
        private LightDatabaseContext _context;

        public ArchiveHelper(int measurementDeviceId)
        {
            _measurementDeviceId = measurementDeviceId;
            _context = new LightDatabaseContext();
        }


        /// <summary>
        /// Возвращает дату самой свежей архивной записи, используя дополнительное условие
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <param name="extraCondition">Дополнительное условие</param>
        /// <returns></returns>
        public DateTime GetLastArchiveTimeByPeriodAndCondition(PeriodType periodType, Expression<Func<Archive, bool>> extraCondition)
        {
            DateTime time = default(DateTime);

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var archive = _context.Set<Archive>().OrderByDescending(p => p.Time)
                        .Where(extraCondition)
                        .FirstOrDefault(p => p.MeasurementDeviceId == _measurementDeviceId && p.PeriodTypeId == (int)periodType);

                    if (archive != null)
                    {
                        time = archive.Time;
                    }

                    tran.Commit();
                }
                catch
                {
                    time = default(DateTime);
                    tran.Rollback();
                }
            }

            return time;
        }

        /// <summary>
        /// Возвращает сумму, вычисленную по значениям архивных записей, отобранных по указанному условию
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <param name="extraCondition">Дополнительное условие отбора архивов</param>
        /// <returns></returns>
        public decimal GetSumArchiveByPeriodAndCondition(PeriodType periodType, Expression<Func<Archive, bool>> extraCondition)
        {
            decimal sum = 0;

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    sum =  _context.Set<Archive>().Where(extraCondition)
                        .Where(p => p.MeasurementDeviceId == _measurementDeviceId && p.PeriodTypeId == (int)periodType).Select(p => p.Value).Sum();

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }

            return sum;
        }

        /// <summary>
        /// Возвращает самую свежую архивную запись, используя дополнительное условие
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <param name="extraCondition">Дополнительное условие</param>
        /// <returns></returns>
        public Archive GetLastArchiveByPeriodAndCondition(PeriodType periodType, Expression<Func<Archive, bool>> extraCondition)
        {
            Archive archive = null;

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    archive = _context.Set<Archive>().OrderByDescending(p => p.Time)
                        .Where(extraCondition)
                        .FirstOrDefault(p => p.MeasurementDeviceId == _measurementDeviceId && p.PeriodTypeId == (int)periodType);
                    

                    tran.Commit();
                }
                catch
                {
                    archive = null;
                    tran.Rollback();
                }
            }

            return archive;
        }


        /// <summary>
        /// Возвращает дату самой свежей архивной записи, находящейся в базе данных
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <returns></returns>
        public DateTime GetLastArchiveTimeByPeriod(PeriodType periodType)
        {
            DateTime time = default(DateTime);
            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var archive = _context.Set<Archive>().OrderByDescending(p => p.Time)
                        .FirstOrDefault(p => p.MeasurementDeviceId == _measurementDeviceId && p.PeriodTypeId == (int)periodType);

                    if (archive != null)
                    {
                        time = archive.Time;
                    }

                    tran.Commit();
                }
                catch
                {
                    time = default(DateTime);
                    tran.Rollback();
                }
            }

            return time;
        }

        /// <summary>
        /// Возвращает кортеж архивов, соответствующий заданным дате и типу периода архива
        /// </summary>
        /// <param name="dt">Дата</param>
        /// <param name="periodType">Тип периода</param>
        /// <returns></returns>
        public List<Archive> GetArchivesByTimeAndPeriod(DateTime dt, PeriodType periodType)
        {
            List<Archive> archives = new List<Archive>();

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    archives = _context.Set<Archive>().Where(p => p.Time == dt && p.PeriodTypeId == (int)periodType && p.MeasurementDeviceId == _measurementDeviceId).ToList();
                    tran.Commit();
                }
                catch
                {
                    archives.Clear();
                    tran.Rollback();
                }
            }

            return archives;
        }

        /// <summary>
        /// Возвращает идентификатор архивной записи 
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <param name="deviceParameterId">Идентификатор девайсового параметра</param>
        /// <param name="time">Время архива</param>
        /// <returns></returns>
        public long GetArchiveId(PeriodType periodType, int deviceParameterId, DateTime time)
        {
            long id = 0;
            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var archive = _context.Set<Archive>().FirstOrDefault(p => p.MeasurementDeviceId == _measurementDeviceId && p.PeriodTypeId == (int)periodType &&
                    p.Time == time && p.DeviceParameterId == deviceParameterId);

                    if (archive != null)
                    {
                        id = archive.Id;
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception(DeviceMessages.GetArchiveIdError);
                }
            }

            return id;
        }

        /// <summary>
        /// Обновление значения архивной записи
        /// </summary>
        /// <param name="archiveId">Идентификатор архивной записи</param>
        /// <param name="newValue">Новое значение</param>
        public void UpdateArchiveValue(long archiveId, decimal newValue)
        {
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        var archive = context.Set<Archive>().Create();
                        archive.Id = archiveId;
                        archive.Value = newValue;
                        context.Set<Archive>().Attach(archive);

                        context.Entry(archive).Property(Resources.Common.ValueColumn).IsModified = true;

                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception(DeviceMessages.UpdateArchiveValueError);
                    }
                }
            }
        }

        #region Кухня сборки мусора

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        ~ArchiveHelper()
        {
            Dispose(false);
        }

        #endregion
    }
}

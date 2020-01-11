using System;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.EventArgs;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System.Data;
using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base
{
    public class IntegratingMachineBase
    {
        protected readonly MeasurementDevice MeasurementDevice;

        // событие возникновения трейсовой информации
        public delegate void TraceInfoPassHandler(object sender, IntegratingMachineEventArgs e);

        public event TraceInfoPassHandler TraceInfoPassed;

        protected void RaiseTraceInfoPassedEvent(string text)
        {
            if (TraceInfoPassed != null)
            {
                TraceInfoPassed(this, new IntegratingMachineEventArgs
                {
                    Text = text
                });
            }
        }

        public IntegratingMachineBase(MeasurementDevice measurementDevice)
        {
            MeasurementDevice = measurementDevice;
        }
        

        protected decimal? GetDeviceParamSum(int diffDeviceParameterId, DateTime startDate, DateTime endDate)
        {
            var archivesCount = (endDate - startDate).TotalHours + 1;
            decimal? result = null;

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        var archives = context.Set<Archive>().Where(p => p.DeviceParameterId == (int)diffDeviceParameterId &&
                        p.PeriodTypeId == (int)PeriodType.Hour && p.Time >= startDate && 
                        p.Time <= endDate && p.MeasurementDeviceId == MeasurementDevice.Id).ToList();

                        if (archives.Count == archivesCount)
                        {
                            result = archives.Sum(p => p.Value);
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }

            return result;
        }

        protected bool SaveIntegratorsArchives(List<Archive> archives)
        {
            bool saveResult = false;

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        context.Set<Archive>().AddRange(archives);
                        context.SaveChanges();
                        tran.Commit();
                        saveResult = true;
                    }
                    catch (Exception ex)
                    {
                        saveResult = false;
                        tran.Rollback();
                    }
                }
            }

            if (!saveResult)
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            var archive = archives.First();
                            var deviceParameterId = archive.DeviceParameterId;
                            var periodTypeId = archive.PeriodTypeId;
                            var time = archive.Time;

                            var duplicateArchive = context.Set<Archive>().FirstOrDefault(p => p.DeviceParameterId == deviceParameterId && p.PeriodTypeId == periodTypeId && p.Time == time
                            && p.MeasurementDeviceId == MeasurementDevice.Id);

                            if (duplicateArchive != null)
                            {
#if DEBUG
                                Console.WriteLine("Duplicate: " + time);
#endif
                                saveResult = true;
                            }
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw new Exception();
                        }
                    }
                }
            }

            return saveResult;
        }

        /// <summary>
        /// Возвращает все интеграционные архивы на заданную дату
        /// </summary>
        /// <param name="sumDeviceParameters">Список идентификаторов параметров</param>
        /// <param name="periodType">Тип периода</param>
        /// <param name="time">Дата архива</param>
        protected List<Archive> GetArchives(List<int> parameters, PeriodType periodType, DateTime time)
        {
            List<Archive> result = null;
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        result = context.Set<Archive>()
                            .Where(p => p.Time == time && p.PeriodTypeId == (int)periodType && parameters.Contains(p.DeviceParameterId) &&
                            p.MeasurementDeviceId == MeasurementDevice.Id).ToList();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception();
                    }
                }
            }
            return result;
        }

        protected DateTime GetDiffArchiveMinDateTime(int deviceParameterId, PeriodType periodType)
        {
            DateTime result = default(DateTime);

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        result =  context.Set<Archive>().Where(p => p.PeriodTypeId == (int)periodType && p.MeasurementDeviceId == MeasurementDevice.Id).Min(p => p.Time);
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception();
                    }
                }
            }

            return result;
        }
    }
}

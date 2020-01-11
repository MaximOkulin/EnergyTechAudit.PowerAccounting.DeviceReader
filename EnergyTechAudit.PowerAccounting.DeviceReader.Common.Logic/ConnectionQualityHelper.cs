using System;
using System.Linq;
using System.Data;
using StatusConnection = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.StatusConnection;
using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    /// <summary>
    /// Класс, обновляющий статистические параметры качества подключения
    /// </summary>
    public class ConnectionQualityHelper
    {
        private readonly MeasurementDevice _device;
        private readonly List<AccessPointStatusConnectionLog> _apConLogs;
        private static readonly object _apConLogsLocker = new object();

        public ConnectionQualityHelper(MeasurementDevice device)
        {
            _device = device;
            _apConLogs = new List<AccessPointStatusConnectionLog>();
        }

        public bool IsNeedAccessPointNewConnectionLog(int accessPointId)
        {
            var result = false;
            lock(_apConLogsLocker)
            {
                var log = _apConLogs.FirstOrDefault(p => p.AccessPointId == accessPointId);
                if (log == null)
                {
                    using (var context = new LightDatabaseContext())
                    {
                        using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                        {
                            try
                            {
                                var logs = context.Set<AccessPointStatusConnectionLog>().Where(p => p.AccessPointId == accessPointId).ToList();
                                if (logs.Count == 0)
                                {
                                    result = true;
                                }
                                else
                                {
                                    var maxTime = logs.Select(p => p.ConnectionTime).Max();
                                    _apConLogs.Add(new AccessPointStatusConnectionLog
                                    {
                                        AccessPointId = accessPointId,
                                        ConnectionTime = maxTime
                                    });

                                    if (IsLogObsolete(maxTime))
                                    {
                                        result = true;
                                    }
                                }
                            }
                            catch
                            {
                                tran.Rollback();
                            }
                        }
                    }
                }
                else
                {
                    if (IsLogObsolete(log.ConnectionTime))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        private bool IsLogObsolete(DateTime dt)
        {
            var span = DateTime.Now - dt;

            return (span.TotalMinutes >= 15);
        }

        /// <summary>
        /// Устанавливает статус "Ошибка передачи" опроса прибора
        /// </summary>
        public void SetLostConnectionStatus()
        {
            _device.LastStatusConnectionId = (int)StatusConnection.Loss;
        }

        /// <summary>
        /// Устанавливает успешное завершение опроса прибора
        /// </summary>
        public void SetSuccessConnectionStatus()
        {
            _device.LastStatusConnectionId = (int)StatusConnection.Success;
            _device.LastSuccessConnectionTime = DateTime.Now;
        }

        /// <summary>
        /// Устанавливает неудачное завершение опроса прибора
        /// </summary>
        public void SetFailConnectionStatus()
        {
            _device.LastStatusConnectionId = (int)StatusConnection.Fail;
        }

        public void SetAccessPointStatusConnectionLog(bool connectionResult, int? accessPointId)
        {
            if (accessPointId != null)
            {
                SetAccessPointStatusConnectionLog(connectionResult, accessPointId.Value);
            }
        }

        /// <summary>
        /// Устанавливает успешное подключение к точке доступа
        /// </summary>
        /// <param name="connectionResult">true - успешное подключение к точке доступа; false - неуспешное</param>
        public void SetAccessPointStatusConnectionLog(bool connectionResult, int accessPointId)
        {
            List<AccessPointStatusConnectionLog> logs = new List<AccessPointStatusConnectionLog>();

            bool readLastLogsResult = false;
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        logs = context.Set<AccessPointStatusConnectionLog>().Where(p => p.AccessPointId == accessPointId).ToList();
                        tran.Commit();
                        readLastLogsResult = true;
                    }
                    catch
                    {
                        readLastLogsResult = false;
                        tran.Rollback();
                    }
                }

                if (readLastLogsResult)
                {
                    var aPoint = context.Set<AccessPoint>().Create();
                    aPoint.Id = accessPointId;
                    aPoint.LastConnectionTime = DateTime.Now;
                    aPoint.LastStatusConnectionId = connectionResult ? (int)StatusConnection.Success : (int)StatusConnection.Fail;

                    var count = logs.Count() + 1;
                    var successCount = logs.Count(p => (StatusConnection)p.StatusConnectionId == StatusConnection.Success);

                    if (connectionResult)
                    {
                        successCount++;
                    }

                    if (count != 0)
                    {
                        aPoint.SuccessConnectionPercent = Math.Round(((double)successCount / (double)count) * 100, 2);
                    }
                    else
                    {
                        aPoint.SuccessConnectionPercent = 0;
                    }

                    context.Set<AccessPoint>().Attach(aPoint);
                    context.Entry(aPoint).Property(Resources.Common.LastConnectionTimeColumn).IsModified = true;
                    context.Entry(aPoint).Property(Resources.Common.LastStatusConnectionIdColumn).IsModified = true;
                    context.Entry(aPoint).Property(Resources.Common.SuccessConnectionPercentColumn).IsModified = true;

                    var log = new AccessPointStatusConnectionLog
                    {
                        AccessPointId = aPoint.Id,
                        ConnectionTime = aPoint.LastConnectionTime,
                        StatusConnectionId = aPoint.LastStatusConnectionId
                    };

                    context.Set<AccessPointStatusConnectionLog>().Add(log);

                    var saveResult = false;
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            context.SaveChanges();
                            tran.Commit();
                            saveResult = true;
                        }
                        catch(Exception ex)
                        {
                            saveResult = false;
                            tran.Rollback();                            
                        }
                    }

                    if (saveResult)
                    {
                        lock(_apConLogsLocker)
                        {
                            var logInLogs = _apConLogs.FirstOrDefault(p => p.AccessPointId == accessPointId);
                            if (logInLogs == null)
                            {
                                _apConLogs.Add(log);
                            }
                            else
                            {
                                _apConLogs.Remove(logInLogs);
                                _apConLogs.Add(log);
                            }
                        }
                    }
                }
            }
        }
    }
}

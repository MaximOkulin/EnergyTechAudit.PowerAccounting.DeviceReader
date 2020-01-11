using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Helpers
{
    public class EmergencyLogHelper
    {
        private readonly Channel _channel;
        private readonly DeviceReaderCache _deviceReaderCache;
        private readonly List<EmergencyLog> _emergencyLogs = new List<EmergencyLog>();
        private readonly List<MobileEmergencyMessage> _mobileEmergencyMessages = new List<MobileEmergencyMessage>();
        private bool _isSuccessSave;

        // пользователи, которые видят данный канал
        private readonly List<int> _usersIds;

        public List<MobileEmergencyMessage> MobileEmergencyMessages
        {
            get
            {
                return _mobileEmergencyMessages;
            }
        }

        public EmergencyLogHelper(Channel channel, DeviceReaderCache deviceReaderCache)
        {
            _channel = channel;
            _deviceReaderCache = deviceReaderCache;

            // все пользователи, которые видят данный канал
            _usersIds = deviceReaderCache.UserLinksChannel.Where(p => p.ChannelId == _channel.Id).Select(p => p.UserId).ToList();
        }

        public void AddEmergencyLog(EmergencyLog emergencyLog)
        {
            _emergencyLogs.Add(emergencyLog);
        }

        public void AddMobileEmergencyMessage(MobileEmergencyMessage message)
        {
            // пользователи, подписанные на оповещение по данной нештатке
            var subscribedUsers = _deviceReaderCache.MobileEmergencyNotifications
                .Where(p => _usersIds.Contains(p.UserAdditionalInfoId) && p.EmergencySituationParameterId == message.EmergencySituationParameterId)
                .Select(p => p.UserAdditionalInfoId).ToList();

            var mobileDevices = _deviceReaderCache.MobileDevices.Where(p => subscribedUsers.Contains(p.UserId)).ToList();

            foreach (var md in mobileDevices)
            {
                _mobileEmergencyMessages.Add(new MobileEmergencyMessage
                {
                    Address = message.Address,
                    Time = DateTime.Now,
                    EmergencyDescription = message.EmergencyDescription,
                    EmergencyValue = message.EmergencyValue,
                    EmergencySituationParameterId = message.EmergencySituationParameterId,
                    MobileDeviceId = md.Id,
                    ChannelId = message.ChannelId,
                    MeasurementDeviceId = message.MeasurementDeviceId
                });
            }
        }

        public void AddEmergencyLogs(List<EmergencyLog> emergencyLogs)
        {
            _emergencyLogs.AddRange(emergencyLogs);
        }

        public bool HasEmergencyLogs
        {
            get { return _emergencyLogs.Count > 0 && _isSuccessSave; }
        }

        public void SetTimeToRecoveryEmergencyLogs(List<int> recoveryEmergencyLogsIds)
        {
            if (recoveryEmergencyLogsIds != null && recoveryEmergencyLogsIds.Count > 0)
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            foreach (var recoveryEmergencyLogId in recoveryEmergencyLogsIds)
                            {
                                var emergencyLog = context.Set<EmergencyLog>().Create();
                                emergencyLog.Id = recoveryEmergencyLogId;
                                emergencyLog.RecoveryTime = DateTime.Now;
                                context.Set<EmergencyLog>().Attach(emergencyLog);

                                context.Entry(emergencyLog).Property(DeviceMessages.RecoveryTime).IsModified = true;
                            }

                            context.SaveChanges();
                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                        }
                    }
                }
            }
        }

        public void SaveEmergencyLogs()
        {
            if (_emergencyLogs.Count > 0)
            {
                _isSuccessSave = false;

                var emergencyTimeSignature = new EmergencyTimeSignature
                {
                    Time = DateTime.Now
                };

                foreach (var emergencyLog in _emergencyLogs)
                {
                    emergencyLog.EmergencyTimeSignature = emergencyTimeSignature;
                }

                using (var context = new LightDatabaseContext())
                {
                    context.Configuration.AutoDetectChangesEnabled = true;

                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            context.Set<EmergencyLog>().AddRange(_emergencyLogs);
                            context.SaveChanges();

                            tran.Commit();
                            _isSuccessSave = true;
                        }
                        catch
                        {
                            _isSuccessSave = false;
                            tran.Rollback();
                        }
                    }
                }

                if (emergencyTimeSignature.Id > 0)
                {
                    _channel.LastEmergencyTimeSignatureId = emergencyTimeSignature.Id;
                }
            }
        }

        public bool SaveMobileEmergencyMessages()
        {
            bool isSuccessSave = false;
            if (_mobileEmergencyMessages != null && _mobileEmergencyMessages.Count > 0)
            {
                using (var context = new LightDatabaseContext())
                {
                    context.Configuration.AutoDetectChangesEnabled = true;

                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            context.Set<MobileEmergencyMessage>().AddRange(_mobileEmergencyMessages);
                            context.SaveChanges();

                            tran.Commit();
                            isSuccessSave = true;
                        }
                        catch(Exception ex)
                        {
                            isSuccessSave = false;
                            tran.Rollback();
                        }
                    }
                }
            }

            return isSuccessSave;
        }
    }
}

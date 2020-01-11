using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Helpers
{
    public class IntegrationArchiveInfoHelper
    {
        private int _measurementDeviceId;
        private PeriodType _periodType;
        private List<IntegrationArchiveInfo> _archiveInfo;
        private List<CurrentArchiveDateInfo> _currentArchiveDateInfo;
        private List<LastCalculatedArchiveDateInfo> _lastCalculatedArchiveDateInfo;
        private bool _hasInitError = false;
        private bool _hasCheckError = false;

        public bool HasInitErrors
        {
            get
            {
                return _hasCheckError || _hasInitError;
            }
        }

        public IntegrationArchiveInfo GetIntergrationArchiveInfo(int diffParamId)
        {
            return _archiveInfo.First(p => p.DiffDeviceParameterId == diffParamId);
        }

        public IntegrationArchiveInfoHelper(int measurementDeviceId, PeriodType periodType)
        {
            _measurementDeviceId = measurementDeviceId;
            _periodType = periodType;
            _currentArchiveDateInfo = new List<CurrentArchiveDateInfo>();
            _lastCalculatedArchiveDateInfo = new List<LastCalculatedArchiveDateInfo>();

            Init();
            CheckArchiveInfo();
        }

        /// <summary>
        /// Получает список IntergrationArchiveInfo из БД для данного прибора и типа периода
        /// </summary>
        private void Init()
        {
            _currentArchiveDateInfo.Clear();
            _lastCalculatedArchiveDateInfo.Clear();
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        _archiveInfo = context.Set<IntegrationArchiveInfo>()
                            .Where(p => p.MeasurementDeviceId == _measurementDeviceId && p.PeriodTypeId == (int)_periodType)
                            .ToList();

                        _currentArchiveDateInfo.AddRange(_archiveInfo.Select(p => new CurrentArchiveDateInfo { DiffDeviceParameterId = p.DiffDeviceParameterId, Date = p.CurrentArchiveDate }).ToArray());
                        _lastCalculatedArchiveDateInfo.AddRange(_archiveInfo.Select(p => new LastCalculatedArchiveDateInfo { DiffDeviceParameterId = p.DiffDeviceParameterId, Date = p.LastCalculatedDate }).ToArray());

                        tran.Commit();
                    }
                    catch
                    {
                        _hasInitError = true;
                        tran.Rollback();
                    }
                }
            }
        }

        /// <summary>
        /// Проверяет наличие всех необходимых IntegrationArchiveInfo, и при необходимости добавляет недостающие
        /// </summary>
        private void CheckArchiveInfo()
        {
            var archiveInfoForCreate = new List<IntegrationArchiveInfo>();

            foreach (var integParam in IntegratingParameters.IntegParams)
            {
                var archiveInfo = _archiveInfo.FirstOrDefault(p => p.DiffDeviceParameterId == integParam.DiffParamId);

                if (archiveInfo == null)
                {
                    archiveInfoForCreate.Add(new IntegrationArchiveInfo
                    {
                        MeasurementDeviceId = _measurementDeviceId,
                        PeriodTypeId = (int)_periodType,
                        DiffDeviceParameterId = integParam.DiffParamId
                    });
                }
            }

            if (archiveInfoForCreate.Any())
            {
                _hasCheckError = CreateIntegrationArchiveInfo(archiveInfoForCreate);

                // заново инициализируем
                if (!_hasCheckError)
                {
                    Init();
                }
            }
        }
        
        /// <summary>
        /// Создает в базе данных новые IntegrationArchiveInfo
        /// </summary>
        /// <param name="archiveInfoForCreate">Список для создания</param>
        /// <returns>true - создание успешно; false - создание неуспешно</returns>
        private bool CreateIntegrationArchiveInfo(List<IntegrationArchiveInfo> archiveInfoForCreate)
        {
            bool hasCreateErrors = false;

            using (var context = new LightDatabaseContext())
            {
                context.Configuration.AutoDetectChangesEnabled = true;
                using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        context.Set<IntegrationArchiveInfo>().AddRange(archiveInfoForCreate);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch
                    {
                        hasCreateErrors = true;
                        tran.Rollback();
                    }
                }
            }

            return hasCreateErrors;
        }

        /// <summary>
        /// Возвращает идентификатор объекта IntegrationArchiveInfo по его DiffDeviceParameterId
        /// </summary>
        /// <param name="diffId">DiffDeviceParameterId</param>
        public int GetIntegrationArchiveInfoByDiffId(int diffId)
        {
            return _archiveInfo.First(p => p.DiffDeviceParameterId == diffId).Id;
        }

        /// <summary>
        /// Возвращает последнюю рассчитанную дату по DiffDeviceParameterId
        /// </summary>
        /// <param name="diffId"></param>
        public DateTime? GetLastCalculatedDateByDiffId(int diffId)
        {
            return _archiveInfo.First(p => p.DiffDeviceParameterId == diffId).LastCalculatedDate;
        }

        /// <summary>
        /// Возвращает дату последнего считанного архива по DiffDeviceParameterId
        /// </summary>
        /// <param name="diffId"></param>
        public DateTime? GetCurrentArchiveDateByDiffId(int diffId)
        {
            return _archiveInfo.First(p => p.DiffDeviceParameterId == diffId).CurrentArchiveDate;
        }

        /// <summary>
        /// Устанавливает последнюю рассчитанную дату в локальной коллекции
        /// </summary>
        /// <param name="dt">Новая рассчитанная дата</param>
        /// <param name="diffId">Идентификатор дифференциального параметра</param>
        public void UpdateLastCalculatedDateInLocalCollection(LastCalculatedArchiveDateInfo lastCalculatedSnip)
        {
            _archiveInfo.First(p => p.DiffDeviceParameterId == lastCalculatedSnip.DiffDeviceParameterId).LastCalculatedDate = lastCalculatedSnip.Date;
        }


        public void UpdateIntegrationArchiveInfoInDb()
        {
            if (!HasInitErrors)
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            foreach (IntegrationArchiveInfo archiveInfo in _archiveInfo)
                            {
                                var currentArchiveDateInDb = _currentArchiveDateInfo.First(p => p.DiffDeviceParameterId == archiveInfo.DiffDeviceParameterId).Date;
                                var lastCalculatedDateInDb = _lastCalculatedArchiveDateInfo.First(p => p.DiffDeviceParameterId == archiveInfo.DiffDeviceParameterId).Date;


                                // если CurrentArchiveDate изменился, то есть смысл обновиться в БД
                                if (currentArchiveDateInDb != archiveInfo.CurrentArchiveDate || lastCalculatedDateInDb != archiveInfo.LastCalculatedDate)
                                {
                                    var integArchiveInfo = context.Set<IntegrationArchiveInfo>().Create();
                                    integArchiveInfo.Id = archiveInfo.Id;
                                    context.Set<IntegrationArchiveInfo>().Attach(integArchiveInfo);

                                    if (currentArchiveDateInDb != archiveInfo.CurrentArchiveDate)
                                    {
                                        integArchiveInfo.CurrentArchiveDate = archiveInfo.CurrentArchiveDate;
                                        context.Entry(integArchiveInfo).Property(Resources.Common.CurrentArchiveDateColumn).IsModified = true;
                                    }

                                    if (lastCalculatedDateInDb != archiveInfo.LastCalculatedDate)
                                    {
                                        integArchiveInfo.LastCalculatedDate = archiveInfo.LastCalculatedDate;
                                        context.Entry(integArchiveInfo).Property(Resources.Common.LastCalculatedDateColumn).IsModified = true;
                                    }
                                }
                            }

                            context.SaveChanges();
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обновляет время последних считанных дифференциальных архивов в локальной коллекции
        /// </summary>
        /// <param name="diffParamIds">Массив идентификаторов дифференциальных параметров</param>
        /// <param name="time">Время архива</param>
        public void UpdateLocalCurrentArchiveDate(int[] diffParamIds, DateTime time)
        {
            if (!HasInitErrors)
            {
                for (var i = 0; i < diffParamIds.Length; i++)
                {
                    var archiveInfo = _archiveInfo.FirstOrDefault(p => p.DiffDeviceParameterId == diffParamIds[i]);

                    if (archiveInfo != null)
                    {
                        archiveInfo.CurrentArchiveDate = time;
                    }
                }
            }
        }

        public void ClearArchiveInfo()
        {
            if (!HasInitErrors)
            {
                // если итак уже сброшено, то и не надо этого делать повторно
                if (_archiveInfo.Count == _archiveInfo.Count(p => p.LastCalculatedDate == null) && 
                    _archiveInfo.Count == _archiveInfo.Count(p => p.CurrentArchiveDate == null))
                {
                    return;
                }

                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            foreach (var aInfo in _archiveInfo)
                            {
                                // сбрасываем локальн
                                aInfo.CurrentArchiveDate = null;
                                aInfo.LastCalculatedDate = null;
                                _currentArchiveDateInfo.First(p => p.DiffDeviceParameterId == aInfo.DiffDeviceParameterId).Date = null;
                                _lastCalculatedArchiveDateInfo.First(p => p.DiffDeviceParameterId == aInfo.DiffDeviceParameterId).Date = null;

                                var integArchiveInfo = context.Set<IntegrationArchiveInfo>().Create();
                                
                                // сбрасываем в базе
                                integArchiveInfo.CurrentArchiveDate = null;
                                integArchiveInfo.LastCalculatedDate = null;
                                integArchiveInfo.Id = aInfo.Id;
                                context.Set<IntegrationArchiveInfo>().Attach(integArchiveInfo);

                                context.Entry(integArchiveInfo).Property(Resources.Common.CurrentArchiveDateColumn).IsModified = true;
                                context.Entry(integArchiveInfo).Property(Resources.Common.LastCalculatedDateColumn).IsModified = true;
                            }

                            context.SaveChanges();
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw new Exception(DeviceMessages.ClearIntegrationArchiveInfoError);
                        }
                    }
                }                
            }
        }
    }
}

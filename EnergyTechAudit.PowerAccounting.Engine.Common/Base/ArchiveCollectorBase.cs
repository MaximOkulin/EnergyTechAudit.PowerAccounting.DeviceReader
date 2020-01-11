using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base
{
    /// <summary>
    /// Базовый класс для сборки и сохранения архивных данных
    /// </summary>
    public class ArchiveCollectorBase
    {
        private TimeSignature _timeSignature;
        /// <summary>
        /// Временная отметка в режиме одиночного прибора
        /// </summary>
        public TimeSignature TimeSignature
        {
            get
            {
                return _timeSignature;
            }
            set
            {
                _timeSignature = value;
            }
        }

        public List<Archive> Archives = new List<Archive>();
        public List<Archive> ArchiveCache;
        public List<MeasurementDeviceJournal> MeasurementDeviceJournals = new List<MeasurementDeviceJournal>();
        
        protected readonly MeasurementDevice Device;
        
        /// <summary>
        /// Конструктор для работы с одиночным прибором
        /// </summary>
        /// <param name="deviceTime">Время прибора</param>
        /// <param name="device">Объект измерительного прибора</param>
        public ArchiveCollectorBase(DateTime deviceTime, MeasurementDevice device)            
        {
            Device = device;
            ArchiveCache = new List<Archive>();

            // создаём временную отметку для всех архивных записей
            // и сохраняем её в базу данных

            _timeSignature = new TimeSignature
            {
                    Time = DateTime.Now,
                    DeviceTime = deviceTime,
                    MeasurementDeviceId = Device.Id
            };
        }

        /// <summary>
        /// Создает мгновенные архивы
        /// </summary>
        /// <param name="valueInfo">Информации об архивном значении</param>
        /// <param name="addToCollection">Сохранение архива в коллекцию</param>
        public ValueInfo CreateInstantArchives(ValueInfo valueInfo, bool addToCollection = true)
        {
            valueInfo.PeriodType = PeriodType.Instant;
            valueInfo.Time = DateTime.Now;

            if (addToCollection)
            {
                CreateArchive(valueInfo);
            }
            return valueInfo;
        }

        /// <summary>
        /// Создает мгновенные архивы
        /// </summary>
        /// <param name="valueInfos">Список архивных значений</param>
        public void CreateInstantArchives(List<ValueInfo> valueInfos)
        {
            foreach (var valueInfo in valueInfos)
            {
                CreateInstantArchives(valueInfo);
            }
        }

        /// <summary>
        /// Создает итоговые текущие архивы
        /// </summary>
        /// <param name="valueInfos">Список архивных значений</param>
        public void CreateFinalInstantArchives(List<ValueInfo> valueInfos)
        {
            foreach (var valueInfo in valueInfos)
            {
                CreateFinalInstantArchives(valueInfo);
            }
        }

        /// <summary>
        /// Создает итоговые текущие архивы
        /// </summary>
        /// <param name="valueInfo">Информации об архивном значении</param>
        /// <param name="addToCollection">Сохранение архива в коллекцию</param>
        public ValueInfo CreateFinalInstantArchives(ValueInfo valueInfo, bool addToCollection = true)
        {
            valueInfo.PeriodType = PeriodType.FinalInstant;
            valueInfo.Time = DateTime.Now;

            if (addToCollection)
            {
                CreateArchive(valueInfo);
            }
            return valueInfo;
        }

        /// <summary>
        /// Создает архив и добавляет в список архивов
        /// </summary>
        /// <param name="valueCreator">Функция, формирующая архивное значение</param>
        /// <param name="addToCollection">Сохранение архива в коллекцию</param>
        public ValueInfo CreateArchive(Func<ValueInfo> valueCreator, bool addToCollection = true)
        {
            var valueInfo = valueCreator();

            if (addToCollection)
            {
                CreateArchive(valueInfo);
            }
            return valueInfo;
        }

        /// <summary>
        /// Создает архивы
        /// </summary>
        /// <param name="values">Список архивных значений</param>
        public void CreateArchives(List<ValueInfo> values, TimeSignature timeSignature = null)
        {
            foreach (var valueInfo in values)
            {
                CreateArchive(valueInfo, timeSignature);
            }
        }
        

        public void CreateMeasurementDeviceJournal(DateTime time, string description, string originalValue, string currentValue, InternalDeviceEvent deviceEvent)
        {
            MeasurementDeviceJournals.Add(new MeasurementDeviceJournal
            {
                MeasurementDeviceId = Device.Id,
                Time = time,
                Description = description,
                OriginalValue = originalValue,
                CurrentValue = currentValue,
                InternalDeviceEventId = (int)deviceEvent
            });
        }

        /// <summary>
        /// Создает архив и добавляет в список архивов
        /// </summary>
        /// <param name="valueInfo">Обертка, содержащая описание измеренного параметра</param>
        /// <param name="deviceTime">Время прибора</param>
        /// <param name="deviceId">Идентификатор прибора в БД</param>
        public void CreateArchive(ValueInfo valueInfo, TimeSignature timeSignature = null)
        {
            var archive = new Archive();
            // создание архива для одиночного прибора

            var ts = timeSignature == null ? _timeSignature : timeSignature;

            // берем идентификатор или объект единственной временной отметки, созданной в рамках класса для одиночного прибора
            if (ts.Id > 0)
            {
                archive.TimeSignatureId = ts.Id;
            }
            else
            {
                archive.TimeSignature = ts;
            }


            archive.PeriodTypeId = (int)valueInfo.PeriodType;
            archive.Time = valueInfo.Time;
            archive.Value = valueInfo.Value;
            archive.IsValid = valueInfo.IsValid;
            archive.MeasurementDeviceId = Device.Id;
            archive.DeviceParameterId = valueInfo.DeviceParameterId;

            var uniqueKeyArchiveCount =
                Archives.Count(p => p.PeriodTypeId == archive.PeriodTypeId && p.Time == archive.Time &&
                                    p.MeasurementDeviceId == archive.MeasurementDeviceId &&
                                    p.DeviceParameterId == archive.DeviceParameterId);

            if (uniqueKeyArchiveCount == 0)
            {
                Archives.Add(archive);
            }
        }

        /// <summary>
        /// Сохраняет собранный список архивов в БД
        /// </summary>
        public bool SaveArchives()
        {
            bool saveResult = true;
            if (Archives.Count > 0 || MeasurementDeviceJournals.Count > 0)
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            context.Configuration.AutoDetectChangesEnabled = true;
                            context.Set<Archive>().AddRange(Archives);

                            if (MeasurementDeviceJournals != null && MeasurementDeviceJournals.Count > 0)
                            {
                                context.Set<MeasurementDeviceJournal>().AddRange(MeasurementDeviceJournals);
                            }

                            context.SaveChanges();

                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            saveResult = false;
                            tran.Rollback();
                        }
                    }

                    context.Set<Archive>().Local.Clear();
                }

                Archives.Clear();
                if (MeasurementDeviceJournals != null) MeasurementDeviceJournals.Clear();
            }
            return saveResult;
        }
    }
}

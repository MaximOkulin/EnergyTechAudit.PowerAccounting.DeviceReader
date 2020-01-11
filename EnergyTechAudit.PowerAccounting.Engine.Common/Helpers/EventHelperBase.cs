using System;
using System.Collections.Generic;
using System.Data;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    /// <summary>
    /// Базовый класс, создающий "Событие"
    /// </summary>
    public class EventHelperBase
    {
        protected List<DeviceEvent> Events = new List<DeviceEvent>();

        protected readonly int DeviceId;

        public EventHelperBase(int deviceId)
        {
            DeviceId = deviceId;
        }

        /// <summary>
        /// Проверяет совпадает ли текущий заводской номер с номером устройства из БД
        /// </summary>
        /// <param name="currentNumber">Текущий заводской номер</param>
        /// <param name="deviceNumber">Номер устройства из БД</param>
        /// <returns>true - совпадает; false - не совпадает</returns>
        public bool CheckFactoryNumber(long currentNumber, long deviceNumber)
        {
            bool result = true;
            if (currentNumber != deviceNumber)
            {
                result = false;
                CreateEvent(EventParameter.CommonWrongFactoryNumber, currentNumber);
                SaveEvents();
            }
            return result;
        }

        /// <summary>
        /// Создает и сохраняет в БД объект сущности "Событие"
        /// </summary>
        /// <param name="eventParameter">Тип системного события</param>
        /// <param name="state">Состояние события</param>
        /// <param name="time">Время возникновения события</param>
        protected void CreateEvent(EventParameter eventParameter, decimal state = 0M, DateTime? time = null)
        {
            Events.Add(new DeviceEvent()
            {
                Time = time ?? DateTime.Now,
                DeviceEventParameterId = (int)eventParameter,
                State = state,
                MeasurementDeviceId = DeviceId,
            });
        }

        /// <summary>
        /// Сохраняет события в БД
        /// </summary>
        public void SaveEvents()
        {
            if (Events != null && Events.Count > 0)
            {
                using (var context = new LightDatabaseContext())
                {
                    using (var tran = context.Database.BeginTransaction(IsolationLevel.Snapshot))
                    {
                        try
                        {
                            context.Set<DeviceEvent>().AddRange(Events);
                            context.SaveChanges();
                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                            throw new Exception(DeviceMessages.SaveEventsError);
                        }
                    }
                    Events.Clear();
                }
            }
        }
    }
}

using System;
using System.Linq.Expressions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    public class ConditionFactory
    {
        /// <summary>
        /// Возвращает условие для поиска записей изменения базы данных (АИБД)
        /// </summary>
        private static Expression<Func<MeasurementDeviceJournal, bool>> GetAidbArchivesCondition()
        {
            return (measurementDeviceJournal) =>
                measurementDeviceJournal.InternalDeviceEventId >= (int)InternalDeviceEvent.Tv7DatabaseChanges0 && 
                measurementDeviceJournal.InternalDeviceEventId <= (int)InternalDeviceEvent.Tv7DatabaseChanges88;
        }

        /// <summary>
        /// Возвращает условие для поиска записей архива событий (ААС)
        /// </summary>
        private static Expression<Func<MeasurementDeviceJournal, bool>> GetAasArchiveCondition()
        {
            return (measurementDeviceJournal) =>
                measurementDeviceJournal.InternalDeviceEventId >= (int) InternalDeviceEvent.Tv7Events0 &&
                measurementDeviceJournal.InternalDeviceEventId <= (int) InternalDeviceEvent.Tv7Events30;
        }

        /// <summary>
        /// Возвращает условие для поиска записей диагностического архива (АД)
        /// </summary>
        private static Expression<Func<MeasurementDeviceJournal, bool>> GetAdArchiveCondition()
        {
            return (measurementDeviceJournal) =>
                measurementDeviceJournal.InternalDeviceEventId >= (int) InternalDeviceEvent.Tv7Diagnostic0 &&
                measurementDeviceJournal.InternalDeviceEventId <= (int) InternalDeviceEvent.Tv7Diagnostic5;
        }

        public static Expression<Func<MeasurementDeviceJournal, bool>> GetCondition(AsyncArchiveType archiveType)
        {
            switch (archiveType)
            {
                    case AsyncArchiveType.DatabaseChanges: return GetAidbArchivesCondition();
                    case AsyncArchiveType.Events: return GetAasArchiveCondition();
                    case AsyncArchiveType.Diagnostic: return GetAdArchiveCondition();
                default:
                    return null;
            }
        }
    }
}

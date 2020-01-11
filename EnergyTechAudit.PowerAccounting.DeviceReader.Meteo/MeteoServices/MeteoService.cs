using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Meteo.MeteoServices
{
    /// <summary>
    /// Базовый класс метеосервиса
    /// </summary>
    internal class MeteoService
    {
        protected List<City> CityCache;
        protected ArchiveCollectorBase ArchiveCollector;

        public MeteoService(string settings, List<City> cityCache, MeasurementDevice meteoMeasurementDevice)
        {
            CityCache = cityCache;
            ArchiveCollector = new ArchiveCollectorBase(DateTime.Now, meteoMeasurementDevice);
        }

        /// <summary>
        /// Выполняет чтение метеоданных
        /// </summary>
        public virtual void ReadMeteoData()
        {

        }

        /// <summary>
        /// Сохраняет накопленные метеоданные в базу данных
        /// </summary>
        public void SaveMeteoData()
        {
            // сохранение в параметры прибора
            ArchiveCollector.SaveArchives();
        }
    }
}

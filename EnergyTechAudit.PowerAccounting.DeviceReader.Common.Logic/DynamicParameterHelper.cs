using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using System.Globalization;
using ProxyDynamicParameter = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.DynamicParameter;
using ProxyPeriodType = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy.PeriodType;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Core;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    /// <summary>
    /// Вспомогательный класс для прозрачной работы с динамическими параметрами
    /// </summary>
    public class DynamicParameterHelper : IDisposable
    {
        private List<DynamicParameterValue> _dynamicDataValues;
        private List<DynamicParameterValue> _commonDynamicDataValues;
        private readonly List<DynamicParameter> _dynamicParameters;
        private LightDatabaseContext _context;
        
        private readonly MeasurementDevice _measurementDevice;

        public DynamicParameterHelper(MeasurementDevice measurementDevice, List<DynamicParameter> dynamicParameters)
        {
            _measurementDevice = measurementDevice;
            _dynamicParameters = dynamicParameters;
 
            _context = new LightDatabaseContext();
            _context.Configuration.AutoDetectChangesEnabled = true;

            InitCommonDynamicDataValues();
        }

        public DynamicParameterHelper(MeasurementDevice measurementDevice) : this(measurementDevice, null)
        {

        }

        /// <summary>
        /// Проверяет существование значений обязательных динамических параметров прибора,
        /// и создаёт недостающие параметры
        /// </summary>
        public void CheckExistDynamicDataValues()
        {
            // делаем запрос на динамические параметры, которые могут быть у прибора
            var deviceDynamicParameters = _context.Set<DeviceLinkDynamicParameter>()
                .Where(p => p.DeviceId == _measurementDevice.DeviceId)
                .Select(p => p.DynamicParameterId).ToList();

            // определяем обязательные динамические параметры с их значениями по умолчанию
            var requiedDynamicParametersWithDefaults = _context.Set<DynamicParameter>()
                                           .Where(p => deviceDynamicParameters.Contains(p.Id) && p.IsDefault)
                                           .Select(p => new { p.Id, p.DefaultValue }).ToList();

            // выделяем в отдельный массив список идентификаторов обязательных динамических параметров
            var requiedDynamicParameters = requiedDynamicParametersWithDefaults.Select(p => p.Id).ToList();

            // находим уже созданные значения обязательных динамических параметров
            var existDynamicParameters = _context.Set<DynamicParameterValue>()
                .Where(p => requiedDynamicParameters.Contains(p.DynamicParameterId) && p.EntityId == _measurementDevice.Id)
                .Select(p => p.DynamicParameterId).ToList();

            // определяем отсутствующие обязательные динамические параметры
            var absentDynamicParameters = requiedDynamicParameters.Except(existDynamicParameters).ToList();

            if (absentDynamicParameters.Count > 0)
            {
                foreach (var absentDynamicParameter in absentDynamicParameters)
                {
                    _context.Set<DynamicParameterValue>().Add(
                        new DynamicParameterValue
                        {
                            EntityId = _measurementDevice.Id,
                            DynamicParameterId = absentDynamicParameter,
                            Value =
                                requiedDynamicParametersWithDefaults.First(p => p.Id == absentDynamicParameter)
                                    .DefaultValue
                        });
                }

                using (var tran = _context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        _context.SaveChanges();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception(DeviceMessages.CheckExistDynamicDataValuesError);
                    }
                }
            }
        }

        /// <summary>
        /// Инициализирует общие динамические параметры
        /// </summary>
        private void InitCommonDynamicDataValues()
        {
            // DeviceSendInstantValuesToMnemoschemeViaSignalR
            int[] dynamicParameterIds = new int[] { 165 };

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    if (_commonDynamicDataValues == null) _commonDynamicDataValues = new List<DynamicParameterValue>();

                    var localDynamicDataValues = _context.Set<DynamicParameterValue>()
                        .Where(p => dynamicParameterIds.Contains(p.DynamicParameterId) && p.EntityId == _measurementDevice.Id)
                        .ToList();

                    _commonDynamicDataValues.AddRange(localDynamicDataValues);

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception(DeviceMessages.CheckExistCommonDynamicDataValuesError);
                }
            }
        }

        /// <summary>
        /// Инициализирует значения динамических параметров
        /// </summary>
        /// <param name="dynamicParameterIds"></param>
        public void InitDynamicDataValues(int[] dynamicParameterIds)
        {
            using (var tran = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    if (_dynamicDataValues == null) _dynamicDataValues = new List<DynamicParameterValue>();

                    var localDynamicDataValues = _context.Set<DynamicParameterValue>()
                        .Include("DynamicParameter")
                        .Where(p => dynamicParameterIds.Contains(p.DynamicParameterId) && p.EntityId == _measurementDevice.Id)
                        .ToList();

                    _dynamicDataValues.AddRange(localDynamicDataValues);

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw new Exception(DeviceMessages.CheckExistDynamicDataValuesError);
                }
            }
        }

        /// <summary>
        /// Возвращает преобразованное значение динамического параметра в примитивный тип
        /// </summary>
        /// <typeparam name="T">Примитивный тип</typeparam>
        /// <param name="dynamicParameter">Тип динамического параметра</param>
        /// <param name="entityId">Идентификатор сущности</param>
        public T GetDynamicValue<T>(Types.Proxy.DynamicParameter dynamicParameter, bool isCommon = false)
        {
            var dynamicParameterTemplate = _dynamicParameters.First(p => p.Id == (int)dynamicParameter);
            
            var type = typeof(Convert);
            var method = type.GetMethod(string.Format("To{0}", dynamicParameterTemplate.Type), new[] { typeof(object), typeof(IFormatProvider) });

            DynamicParameterValue dynamicValue = null;

            if (isCommon)
            {
                dynamicValue = GetCommonDynamicParameterValue(dynamicParameter);
            }
            else
            {
                dynamicValue = GetDynamicParameterValue(dynamicParameter);
            }

            string value = string.Empty;

            if (dynamicValue != null)
            {
                value = dynamicValue.Value;
            }
            else
            {
                value = dynamicParameterTemplate.DefaultValue;
            }

            if (dynamicParameterTemplate.Type.Equals(Resources.Common.Decimal, StringComparison.Ordinal))
            {
                var numberDecimalSeparator = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;
                value = value.Replace(Resources.Common.CommaSymbol, numberDecimalSeparator).Replace(Resources.Common.DotSymbol, numberDecimalSeparator);
            }

            return (T)method.Invoke(null, new object[] { value, CultureInfo.InvariantCulture });
        }

        /// <summary>
        /// Возвращает преобразованное значение динамического параметра в примитивный тип
        /// </summary>
        /// <typeparam name="T">Примитивный тип</typeparam>
        /// <param name="dynamicParameter">Тип динамического параметра</param>
        /// <param name="entityId">Идентификатор сущности</param>
        public T GetAccessPointDynamicValue<T>(Types.Proxy.DynamicParameter dynamicParameter)
        {
            var dynamicParameterTemplate = _dynamicParameters.First(p => p.Id == (int)dynamicParameter);

            var type = typeof(Convert);
            var method = type.GetMethod(string.Format("To{0}", dynamicParameterTemplate.Type), new[] { typeof(object), typeof(IFormatProvider) });

            DynamicParameterValue dynamicValue = null;
            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        dynamicValue = context.Set<DynamicParameterValue>().FirstOrDefault(p => p.EntityId == _measurementDevice.AccessPointId.Value && p.DynamicParameterId == (int)dynamicParameter);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }           

            string value = string.Empty;

            if (dynamicValue != null)
            {
                value = dynamicValue.Value;
            }
            else
            {
                value = dynamicParameterTemplate.DefaultValue;
            }

            if (dynamicParameterTemplate.Type.Equals(Resources.Common.Decimal, StringComparison.Ordinal))
            {
                var numberDecimalSeparator = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;
                value = value.Replace(Resources.Common.CommaSymbol, numberDecimalSeparator).Replace(Resources.Common.DotSymbol, numberDecimalSeparator);
            }

            return (T)method.Invoke(null, new object[] { value, CultureInfo.InvariantCulture });
        }

        public void SetDynamicParameter(Types.Proxy.DynamicParameter dynamicParameter, object value)
        {
            var dynamicDataValue = GetDynamicParameterValue(dynamicParameter);

            if(dynamicDataValue != null)
            {
                if(value.GetType() == typeof(DateTime))
                {
                    dynamicDataValue.Value = ((DateTime)value).ToString(@"yyyy-MM-ddTHH\:mm\:ss");
                }
                else
                {
                    dynamicDataValue.Value = value.ToString();
                }

                using (var tran = _context.Database.BeginTransaction(IsolationLevel.Snapshot))
                {
                    try
                    {
                        _context.SaveChanges();
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw new Exception(string.Format(DeviceMessages.SaveDynamicParameterError, dynamicParameter));
                    }
                }
            }
            else
            {
                throw new Exception(string.Format(DeviceMessages.DynamicParameterNotFound, dynamicParameter));
            }
        }

        public DynamicParameterValue GetDynamicParameterValue(Types.Proxy.DynamicParameter dynamicParameter)
        {
            return _dynamicDataValues.FirstOrDefault(p => p.DynamicParameterId == (int)dynamicParameter);
        }

        public DynamicParameterValue GetCommonDynamicParameterValue(Types.Proxy.DynamicParameter dynamicParameter)
        {
            return _commonDynamicDataValues.FirstOrDefault(p => p.DynamicParameterId == (int)dynamicParameter);
        }

        /// <summary>
        /// Возвращает описание динамического параметра
        /// </summary>
        /// <param name="dynamicParameter">Динамический параметр</param>
        /// <returns></returns>
        public string GetDynamicParameterDescription(Types.Proxy.DynamicParameter dynamicParameter)
        {
            return _dynamicDataValues.FirstOrDefault(p => p.DynamicParameterId == (int)dynamicParameter).DynamicParameter.Description;
        }

        /// <summary>
        /// Равно ли значение динамического параматра типа "Дата/время" значению по умолчанию
        /// </summary>
        /// <param name="dynamicParameter"></param>
        /// <returns></returns>
        public bool HasDynamicParameterDateTimeDefaultValue(Types.Proxy.DynamicParameter dynamicParameter)
        {
            var dateTime = GetDynamicValue<DateTime>(dynamicParameter);

            return dateTime == default(DateTime);
        }

        /// <summary>
        /// Возвращает значение динамического параметра по идентификатору сущности
        /// </summary>
        /// <param name="dynamicParameter">Динамический параметр</param>
        /// <param name="entityId">Идентификатор сущности</param>
        /// <returns></returns>
        public DynamicParameterValue GetDynamicParameterByEntityId(ProxyDynamicParameter dynamicParameter, int entityId)
        {
            DynamicParameterValue value = null;

            using (var context = new LightDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    try
                    {
                        value = context.Set<DynamicParameterValue>().FirstOrDefault(p => p.DynamicParameterId == (int)dynamicParameter &&
                        p.EntityId == entityId);
                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// Определяет установлен ли "флаг наличия архивов" в динамическом параметре
        /// (если прибор содержит динамические параметры DeviceHasDayArchive и DeviceHasHourArchive)
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <returns></returns>
        public bool HasArchiveInDb(ProxyPeriodType periodType)
        {
            ProxyDynamicParameter dynamicParameter = GetHasPeriodArchive(periodType);

            return GetDynamicValue<bool>(dynamicParameter);
        }

        private ProxyDynamicParameter GetHasPeriodArchive(ProxyPeriodType periodType)
        {
            ProxyDynamicParameter dynamicParameter = ProxyDynamicParameter.None;

            switch (periodType)
            {
                case ProxyPeriodType.Day:
                    dynamicParameter = ProxyDynamicParameter.DeviceHasDayArchive;
                    break;
                case ProxyPeriodType.Hour:
                    dynamicParameter = ProxyDynamicParameter.DeviceHasHourArchive;
                    break;
                case ProxyPeriodType.Month:
                    dynamicParameter = ProxyDynamicParameter.DeviceHasMonthArchive;
                    break;
            }

            return dynamicParameter;
        }

        /// <summary>
        /// Устанавливает новое значение "флага наличия архивов" в динамическом параметре
        /// (если прибор содержит динамические параметры DeviceHasDayArchive и DeviceHasHourArchive)
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <param name="value">Новое значение</param>
        public void SetHasArchive(ProxyPeriodType periodType, bool value)
        {
            ProxyDynamicParameter dynamicParameter = GetHasPeriodArchive(periodType);

            SetDynamicParameter(dynamicParameter, value);
        }

        /// <summary>
        /// Устанавливает новое значение "последней просканированный даты архива" в динамическом параметре
        /// (если прибор содержит динамические параметры DeviceLastDayArchiveScan и DeviceLastHourArchiveScan)
        /// </summary>
        /// <param name="periodType">Тип периода</param>
        /// <param name="dt">Новое значение</param>
        public void SetLastScanDate(ProxyPeriodType periodType, DateTime dt)
        {
            ProxyDynamicParameter dynamicParameter = ProxyDynamicParameter.None;

            switch(periodType)
            {
                case ProxyPeriodType.Day: dynamicParameter = ProxyDynamicParameter.DeviceLastDayArchiveScan;
                    break;
                case ProxyPeriodType.Hour: dynamicParameter = ProxyDynamicParameter.DeviceLastHourArchiveScan;
                    break;
                case ProxyPeriodType.Month: dynamicParameter = ProxyDynamicParameter.DeviceHasMonthArchive;
                    break;
            }

            if (dynamicParameter != ProxyDynamicParameter.None)
            {
                SetDynamicParameter(dynamicParameter, dt);
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
            if(disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        ~DynamicParameterHelper()
        {
            Dispose(false);
        }

        #endregion
    }
}

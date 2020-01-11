using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl
{
    public class ApplicationBase
    {
        protected ArchiveCollectorBase ArchiveCollector;
        protected MeasurementDevice MeasurementDevice;
        // список параметров, измеряемых датчиками
        protected List<DeviceParameter> SensorParameters;
        // список рассчитываемых параметров, измеряемых датчиками
        protected List<DeviceParameter> SensorCalculatedParameters;

        protected LogHelper LogHelper;

        protected string KeyName;

        private Common.Logic.DynamicParameterHelper _dynamicParameterHelper;

        private LightDatabaseContext _context;
        public LightDatabaseContext Context
        {
            set
            {
                _context = value;
            }
            get
            {
                return _context;
            }
        }

        protected string NumberDecimalSeparator;
        private DeviceInitiator _deviceInitiator;
        protected Common.Logic.Device Device;

        private DateTime _regParamsLastSyncTime;

        public DateTime DeviceTime;


        public void Init(Common.Logic.Device device, Common.Logic.DynamicParameterHelper dynamicParameterHelper)
        {
            Device = device;
            ArchiveCollector = device.GetArchiveCollector();
            MeasurementDevice = device.MeasurementDevice;

            _deviceInitiator = new DeviceInitiator(MeasurementDevice.Id);
            LogHelper = device.GetLogHelper();


            KeyName = GetType().Name;
            NumberDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            _dynamicParameterHelper = dynamicParameterHelper;
            _regParamsLastSyncTime = dynamicParameterHelper.GetDynamicValue<DateTime>(DynamicParameter.DeviceRegParamsLastSyncTime);
        }

        public Dictionary<string, string> GetCurrents()
        {
            var result = new List<KeyValuePair<string, string>>();

            _deviceInitiator.InitDynamicParameters();

            if (_deviceInitiator.IsNeedToInit)
            {
                result.Add(new KeyValuePair<string, string>(CommandsKeys.Ecl310NeedToInitKey, DeviceMessages.Ecl310NeedToInit));
                ReadInstantValues();

                if (ReadParamsFromEcl())
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, DateTime.Now);
                    _deviceInitiator.IsInitValue.Value = Resources.Common.True;
                    _deviceInitiator.InitDateValue.Value = DateTime.Now.ToIsoString();
                    _deviceInitiator.SaveChanges();
                }

                result.Insert(0, new KeyValuePair<string, string>(CommandsKeys.ReadCurrentsSuccessfullyKey,
                      string.Format(StringFormat.GoodResponseHtml, DeviceMessages.ReadCurrentsSuccessfully)));
            }
            else
            {
                ReadInstantValues();
                result.Insert(0, new KeyValuePair<string, string>(CommandsKeys.ReadCurrentsSuccessfullyKey,
                      string.Format(StringFormat.GoodResponseHtml, DeviceMessages.ReadCurrentsSuccessfully)));
            }

            SaveChanges();
            Device.SendUpdateSignal();

            return result.ToDictionary(x => x.Key, x => x.Value);
        }

        public int Run(bool isReadInstantValues)
        {
            int updatedParamsCount = 0;
            _deviceInitiator.InitDynamicParameters();

            if (_deviceInitiator.IsNeedToInit)
            {
                if (isReadInstantValues)
                {
                    ReadInstantValues();
                }

                if (ReadParamsFromEcl())
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, DateTime.Now);
                    _deviceInitiator.IsInitValue.Value = Resources.Common.True;
                    _deviceInitiator.InitDateValue.Value = DateTime.Now.ToIsoString();
                    _deviceInitiator.SaveChanges();
                }
            }
            else
            {
                updatedParamsCount = WriteParamsToEcl();

                if (isReadInstantValues)
                {
                    ReadInstantValues();
                }

                var readParamsTimeSpan = DateTime.Now - _regParamsLastSyncTime;

                if (updatedParamsCount > 0 || readParamsTimeSpan.TotalDays >= 7)
                {
                    if (ReadParamsFromEcl())
                    {
                        _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, DateTime.Now);
                    }
                }
            }

            SaveChanges();
            Device.SendUpdateSignal();

            return updatedParamsCount;
        }

        protected void SetInstantArchiveValuesForAnalyze()
        {
            Device.SetInstantArchiveValuesForAnalyze(SensorsValues);
        }

        public void ReadOnlyRegulatorParameters()
        {
            _deviceInitiator.InitDynamicParameters();

            // если прибор еще не был инициализирован, то только читаем его настройки
            if (_deviceInitiator.IsNeedToInit)
            {
                if (ReadParamsFromEcl())
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, DateTime.Now);
                    _deviceInitiator.IsInitValue.Value = Resources.Common.True;
                    _deviceInitiator.InitDateValue.Value = DateTime.Now.ToIsoString();
                    _deviceInitiator.SaveChanges();
                }
                else
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, default(DateTime));
                }
            }
            else
            {
                if (ReadParamsFromEcl())
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, DateTime.Now);
                }
                else
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, default(DateTime));
                }
            }

            SaveChanges();
            Device.SendUpdateSignal();
        }

        private void SaveChanges()
        {
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
                }
            }
        }

        /// <summary>
        /// Виртуальный метод чтения мгновенных параметров регулятора (должен быть переопределен каждый классом-наследником)
        /// </summary>
        protected virtual void ReadInstantValues()
        {

        }

        /// <summary>
        /// Виртуальный метод чтения параметров из регулятора (должен быть переопределен каждым классом-наследником)
        /// </summary>
        protected virtual bool ReadParamsFromEcl()
        {
            return false;
        }

        /// <summary>
        /// Запись обновленных параметров в регулятор
        /// </summary>
        private int WriteParamsToEcl()
        {
            DebugTrace("Получение всех актуальных значений данного регулятора");

            // получаем список всех актуальных значений данного регулятора
            var regulatorParameterValues = _context.Set<RegulatorParameterValue>().Local.ToList();

            // получает список всех значений, которые нужно сравнять с пользовательскими 
            // (время пользовательского обновления задано, но реально обновления не было)
            var parametersToReset =
                regulatorParameterValues.Where(p => p.DeviceValue != p.UserValue && p.UpdateUserValueTime != null);

            foreach (var parameterToReset in parametersToReset)
            {
                parameterToReset.UserValue = parameterToReset.DeviceValue;
                parameterToReset.UpdateUserValueTime = null;
            }

            using (var tran = _context.Database.BeginTransaction(IsolationLevel.Snapshot))
            {
                try
                {
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }

            var parametersToUpdate =
                regulatorParameterValues.Where(p => p.DeviceValue != p.UserValue && p.UpdateUserValueTime == null).ToList();

            DebugTrace(string.Format("Параметров для обновления: {0}", parametersToUpdate.Count()));
            foreach (var parameterToUpdate in parametersToUpdate)
            {
                SetValue(parameterToUpdate);
            }

            return parametersToUpdate.Count();
        }

        /// <summary>
        /// Ищет метод установки, и устанавливает с помощью него новое значение
        /// </summary>
        /// <param name="parameterValue">Параметр</param>
        private bool SetValue(RegulatorParameterValue parameterValue)
        {
            var deviceParameter = _context.Set<LightDataAccess.Dictionaries.DeviceParameter>().Include("DeviceParameterSetting")
                                                           .FirstOrDefault(p => p.Id == parameterValue.DeviceParameterId);

            if (deviceParameter != null && deviceParameter.DeviceParameterSetting != null)
            {
                var method = GetSetMethod(deviceParameter.DeviceParameterSetting.WriteMethodName);

                if (method != null)
                {
                    DebugTrace(string.Format("Метод установки: {0}", method));

                    var setValueResult = SetValue(method, parameterValue.UserValue.ToString(CultureInfo.InvariantCulture),
                        parameterValue.DeviceValue.ToString(CultureInfo.InvariantCulture));
                    if (setValueResult)
                    {
                        parameterValue.DeviceValue = parameterValue.UserValue;
                        parameterValue.SyncDeviceTime = DateTime.Now;
                        parameterValue.UpdateUserValueTime = DateTime.Now;

                        using (var tran = _context.Database.BeginTransaction(IsolationLevel.Snapshot))
                        {
                            try
                            {
                                _context.SaveChanges();
                                tran.Commit();
                            }
                            catch (Exception)
                            {
                                tran.Rollback();
                            }
                        }
                    }
                    return setValueResult;
                }
            }

            return false;
        }

        /// <summary>
        /// Находит метод установки параметра в ECL в классе ActionSteps, используя рефлексию
        /// </summary>
        /// <param name="paramName">Название параметра</param>
        protected virtual MethodInfo GetSetMethod(string paramName)
        {
            return null;
        }


        /// <summary>
        /// Устанавливает новое значение параметра в регуляторе ECL 210/310
        /// </summary>
        /// <param name="setMethod">Метод установки</param>
        /// <param name="newVal">Новое значение</param>
        /// <param name="oldVal">Старое значение (нужно для булевых типов)</param>
        /// <returns>true - успех; false - неудача</returns>
        protected virtual bool SetValue(MethodInfo setMethod, string newVal, string oldVal = null)
        {
            return false;
        }

        /// <summary>
        /// Выполняет чтение регулирующих параметров прибора
        /// </summary>
        /// <param name="methodNames">Список методов для чтения</param>
        protected virtual bool ExecuteReadRegulatorParameters(string[] methodNames)
        {
            return false;
        }

        /// <summary>
        /// Список считанных значений датчиков
        /// </summary>
        protected List<ValueInfo> SensorsValues;

        /// <summary>
        /// Создает архивное значение датчика и добавляет его в список
        /// </summary>
        /// <param name="sensorParameter">Измеряемый параметр</param>
        /// <param name="value">Значение</param>
        protected void CreateArchiveValue(DeviceParameter sensorParameter, decimal value, bool? isValid = null)
        {
            if (SensorsValues == null)
            {
                SensorsValues = new List<ValueInfo>();
            }

            SensorsValues.Add(new ValueInfo
            {
                PeriodType = PeriodType.Instant,
                Time = DateTime.Now,
                DeviceParameterId = (int)sensorParameter,
                Value = value,
                IsValid = isValid != null ? isValid.Value : value < 300
            });
        }

        protected void DebugTrace(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
        }
    }
}

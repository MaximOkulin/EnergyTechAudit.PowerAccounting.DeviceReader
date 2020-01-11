using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Parsers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications
{
    /// <summary>
    /// Базовый класс для всех ключей-приложений Danfoss ECL Comfort 210/310
    /// </summary>
    internal class ApplicationBase
    {
        protected ActionSteps ActionSteps;
        protected ArchiveCollectorBase ArchiveCollector;
        protected MeasurementDevice MeasurementDevice;
        // список параметров, измеряемых датчиками
        protected List<DeviceParameter> SensorParameters;
        // список рассчитываемых параметров, измеряемых датчиками
        protected List<DeviceParameter> SensorCalculatedParameters;

        private LogHelper _logHelper;

        protected ParserBase ParserBase;

        protected string KeyName;

        private LightDatabaseContext _context;
        private DeviceReader.Common.Logic.DynamicParameterHelper _dynamicParameterHelper;
        private DateTime _regParamsLastSyncTime;

        public LightDatabaseContext Context
        {
            set
            {
                _context = value;
            }
        }

        private string _numberDecimalSeparator;
        private DeviceInitiator _deviceInitiator;

        protected DeviceReader.Common.Logic.Device Dev;

        public DeviceReader.Common.Logic.Device Device
        {
            set
            {
                Dev = value;
            }
        }

        public void Init(ActionSteps actionSteps, ArchiveCollectorBase archiveCollector, MeasurementDevice measurementDevice,
               LogHelper logHelper, DeviceReader.Common.Logic.DynamicParameterHelper dynamicParameterHelper)
        {
            ActionSteps = actionSteps;
            ArchiveCollector = archiveCollector;
            MeasurementDevice = measurementDevice;

            _dynamicParameterHelper = dynamicParameterHelper;
            _regParamsLastSyncTime = dynamicParameterHelper.GetDynamicValue<DateTime>(DynamicParameter.DeviceRegParamsLastSyncTime);

            _deviceInitiator = new DeviceInitiator(measurementDevice.Id);
            _logHelper = logHelper;

            KeyName = GetType().Name;
            ParserBase = new ParserBase(actionSteps.Transport, MeasurementDevice);
            _numberDecimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }

        public ApplicationBase()
        {
            
        }

        public Dictionary<string, string> GetCurrents()
        {
            var result = new List<KeyValuePair<string, string>>();

            _deviceInitiator.InitDynamicParameters();
            // если прибор еще не был инициализирован, то только читаем его настройки
            if (_deviceInitiator.IsNeedToInit)
            {
                result.Add(new KeyValuePair<string, string>(CommandsKeys.Ecl310NeedToInitKey, DeviceMessages.Ecl310NeedToInit));
                ReadInitParams();
                ReadInstantValues();
                ReadParamsFromEcl();

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
            Dev.SendUpdateSignal();

            return result.ToDictionary(x => x.Key, x => x.Value); ;
        }

        /// <summary>
        /// Запускает процесс опроса и записи в регулятор
        /// </summary>
        public int Run(bool isReadInstantValues)
        {
            int updatedParamsCount = 0;
            _deviceInitiator.InitDynamicParameters();
            // если прибор еще не был инициализирован, то только читаем его настройки
            if (_deviceInitiator.IsNeedToInit)
            {
                ReadInitParams();

                if (isReadInstantValues)
                {
                    ReadInstantValues();
                }

                if (ReadParamsFromEcl())
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, DateTime.Now);
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
            Dev.SendUpdateSignal();

            return updatedParamsCount;
        }

        public void ReadOnlyRegulatorParameters()
        {
            _deviceInitiator.InitDynamicParameters();

            // если прибор еще не был инициализирован, то только читаем его настройки
            if (_deviceInitiator.IsNeedToInit)
            {
                ReadInitParams();

                if (ReadParamsFromEcl())
                {
                    _dynamicParameterHelper.SetDynamicParameter(DynamicParameter.DeviceRegParamsLastSyncTime, DateTime.Now);
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
            Dev.SendUpdateSignal();
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
        /// Читает параметры первоначальной инициализации прибора
        /// </summary>
        private void ReadInitParams()
        {
            var mDevice = MeasurementDevice;
            ActionSteps.GetManufacturingDate();
            mDevice.ManufacturingDate = ParserBase.ParseManufacturingDate();

            ActionSteps.GetHardwareVersion();
            string hardwareVersion = ParserBase.ParseHardwareVersion();

            ActionSteps.GetFirmware();
            string firmware = ParserBase.ParseFirmware();
            mDevice.Firmware = string.Format("{0}/{1}", hardwareVersion, firmware);

            _deviceInitiator.IsInitValue.Value = "true";
            _deviceInitiator.InitDateValue.Value = DateTime.Now.ToIsoString();
            _deviceInitiator.SaveChanges();
        }

        /// <summary>
        /// Запись обновленных параметров в регулятор
        /// </summary>
        private int WriteParamsToEcl()
        {
            DebugTrace("Получение всех актуальных значений данного регулятора");
            
            // получаем список всех актуальных значений данного регулятора
            var regulatorParameterValues = _context.Set<RegulatorParameterValue>()
                                                   .Where(p => p.MeasurementDeviceId == MeasurementDevice.Id).ToList();

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

            return false;
        }

        public Dictionary<string, string> WriteParamToEcl(RegulatorParameterValue parameterValue)
        {
            var result = new Dictionary<string, string>();

            if (parameterValue.DeviceValue != parameterValue.UserValue)
            {
                var setValueResult = SetValue(parameterValue);
                if (setValueResult)
                {
                    result.Add(DeviceMessages.Ecl310ParameterUpdatedSuccessfully, 
                               DeviceMessages.Ecl310ParameterUpdatedText);
                    UpdateParameterValueInDb(parameterValue);
                }
                else
                {
                    result.Add(DeviceMessages.Ecl310ParameterUpdateFailed,
                               DeviceMessages.Ecl310ParameterUpdateFailedText);
                    UpdateParameterValueInDb(parameterValue, false);
                    result.Add(DeviceMessages.Ecl310ParameterUpdateDelayed,
                        DeviceMessages.Ecl310ParameterUpdateDelayedText);
                }

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    result.Add(DeviceMessages.UpdateDbError, DeviceMessages.UpdateDbErrorText);
                }
            }
            else
            {
                result.Add(DeviceMessages.Ecl310ParameterUpdateFailed, DeviceMessages.Ecl310ParametersEqual);
            }
            return result;
        }

        /// <summary>
        /// Обновляет значение регуляционного параметра в БД
        /// </summary>
        /// <param name="value">Регуляционный параметр</param>
        /// <param name="isDeviceValueUpdate">Нужно ли синхронизировать значение из прибора</param>
        private void UpdateParameterValueInDb(RegulatorParameterValue value, bool isDeviceValueUpdate = true)
        {
            var paramValue = _context.Set<RegulatorParameterValue>().Create();
            paramValue.Id = value.Id;
            paramValue.UserValue = value.UserValue;
            if (isDeviceValueUpdate)
            {
                paramValue.DeviceValue = value.DeviceValue;
                paramValue.SyncDeviceTime = value.SyncDeviceTime;
                paramValue.UpdateUserValueTime = value.UpdateUserValueTime;
            }
            else
            {
                paramValue.UpdateUserValueTime = null;
            }


            _context.Set<RegulatorParameterValue>().Attach(paramValue);
            if (isDeviceValueUpdate)
            {
                _context.Entry(paramValue).Property("DeviceValue").IsModified = true;
                _context.Entry(paramValue).Property("SyncDeviceTime").IsModified = true;
            }
            _context.Entry(paramValue).Property("UserValue").IsModified = true;
            _context.Entry(paramValue).Property("UpdateUserValueTime").IsModified = true;
        }

        /// <summary>
        /// Находит метод установки параметра в ECL в классе ActionSteps, используя рефлексию и аттрибуты доступа ключей
        /// </summary>
        /// <param name="paramName">Название параметра</param>
        private MethodInfo GetSetMethod(string paramName)
        {
            return typeof(ActionSteps).GetMethods().FirstOrDefault(mi => mi.Name == string.Format("Set{0}", paramName));
        }

        /// <summary>
        /// Устанавливает новое значение параметра в регуляторе ECL 210/310
        /// </summary>
        /// <param name="setMethod">Метод установки</param>
        /// <param name="newVal">Новое значение</param>
        /// <param name="oldVal">Старое значение (нужно для булевых типов)</param>
        /// <returns>true - успех; false - неудача</returns>
        private bool SetValue(MethodInfo setMethod, string newVal, string oldVal = null)
        {
            if (setMethod != null)
            {
                ParameterInfo argParameter = setMethod.GetParameters().FirstOrDefault();
                
                if (argParameter != null)
                {
                    var parType = argParameter.ParameterType;
                    if (parType == typeof(Int32) || parType == typeof(bool))
                    {
                        // для целочисленных и булевых избавляемся от точки и знаков после точки
                        newVal = newVal.Split('.')[0];
                        if(oldVal != null)
                        {
                            oldVal = oldVal.Split('.')[0];
                        }

                        if(parType == typeof(bool))
                        {
                            newVal = newVal.Equals("1") ? "true" : "false";
                            oldVal = oldVal.Equals("1") ? "true" : "false";
                        }
                    }

                    // меняем строковый тип на целевой, попутно меняя сепаратор чисел согласно региональной настройке 
                    var newValue = Convert.ChangeType(newVal.Replace(".", _numberDecimalSeparator), parType);
                    
                    if (oldVal != null)
                    {
                        var oldValue = Convert.ChangeType(oldVal.Replace(".", _numberDecimalSeparator), parType);

                        if (argParameter.ParameterType == typeof (bool))
                        {
                            if (!IsCanToSetAccidentFlags(setMethod.Name, (bool) oldValue))
                            {
                                return true;
                            }
                        }
                    }

                    setMethod.Invoke(ActionSteps, new[] { newValue });
                    if (ActionSteps.Transport.CurrentErrorCode == ErrorCode.None)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Определяет, может ли быть установлен флаг сброса аварии
        /// </summary>
        /// <param name="paramName">Название параметра флага сброса аварии</param>
        /// <param name="value">Текущее значение флага</param>
        private bool IsCanToSetAccidentFlags(string paramName, bool value)
        {
            bool isAccidentField = paramName.Contains("AccidentPumpsCircuit1") || paramName.Contains("AccidentPumpsCircuit2") ||
                                   paramName.Contains("AccidentMakeupCircuit1") || paramName.Contains("AccidentMakeupCircuit2");
            // если значение "ВЫК": невозможно изменить на "ВКЛ"
            if (!value && isAccidentField)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Виртуальный метод чтения мгновенных параметров регулятора (должен быть переопределен каждый классом-наследником)
        /// </summary>
        protected virtual void ReadInstantValues()
        {
            
        }

        protected void SetInstantArchiveValuesForAnalyze()
        {
            Dev.SetInstantArchiveValuesForAnalyze(SensorsValues);
        }

        /// <summary>
        /// Виртуальный метод чтения параметров из регулятора (должен быть переопределен каждым классом-наследником)
        /// </summary>
        protected virtual bool ReadParamsFromEcl()
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
        protected void CreateArchiveValue(DeviceParameter sensorParameter, double value)
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
                Value = (decimal)value,
                IsValid = value < 117 && value > -200
            });
        }

        /// <summary>
        /// Выполняет чтение регулирующих параметров прибора
        /// </summary>
        /// <param name="methodNames">Список методов для чтения</param>
        protected bool ExecuteReadRegulatorParameters(string[] methodNames)
        {
            var result = true;
            foreach (var methodName in methodNames)
            {
                var readMethod = typeof (ActionSteps).GetMethod(string.Format("Get{0}", methodName));
                DebugTrace(string.Format("Чтение регулирующего параметра: {0}", readMethod));

                if ((bool) readMethod.Invoke(ActionSteps, null))
                {
                    var parseMethod = typeof (ParserBase).GetMethod(string.Format("Parse{0}", methodName));
                    parseMethod.Invoke(ParserBase, null);
                }
                else
                {
                    result = false;
                    if (_logHelper != null)
                    {
                        _logHelper.CreateLog(string.Format(DeviceMessages.Ecl310ReadMethodError, methodName), ErrorType.SpecificDeviceError);
                    }
                }
            }
            return result;
        }
        
        protected void DebugTrace(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
        }
    }
}

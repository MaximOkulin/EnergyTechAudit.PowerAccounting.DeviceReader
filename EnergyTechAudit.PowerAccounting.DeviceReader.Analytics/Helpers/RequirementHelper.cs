using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Cache;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Helpers
{
    /// <summary>
    /// Класс, позволяющий определить выполнение необходимых условий для анализа наличия нештатных ситуаций
    /// </summary>
    public class RequirementHelper
    {
        private readonly Channel _channel;
        private readonly MeasurementDevice _measurementDevice;
        private readonly EmergencyCondition _condition;
        private readonly int _emergencySituationParameterId;
        private readonly DeviceReaderCache _deviceReaderCache;

        public RequirementHelper(EmergencyCondition condition, Channel channel, 
             MeasurementDevice measurementDevice, int emergencySituationParameterId, DeviceReaderCache deviceReaderCache)
        {
            _channel = channel;
            _measurementDevice = measurementDevice;
            _condition = condition;
            _emergencySituationParameterId = emergencySituationParameterId;
            _deviceReaderCache = deviceReaderCache;
        }
        
        /// <summary>
        /// Выполняет анализ необходимых требований
        /// </summary>
        /// <returns>true - требования выполняются; false - требования не выполняются</returns>
        public bool AnalyzeRequirements()
        {
            List<EmergencyLog> emergencyLogs = new List<EmergencyLog>();

            if (_condition.Requirements != null && _condition.Requirements.Count > 0)
            {
                foreach (Requirement requirement in _condition.Requirements)
                {
                    var type = Type.GetType(string.Format(Resources.DeviceMessages.ModelAssemblyPattern, requirement.EntityTypeCode));

                    foreach (var fieldValues in requirement.FieldsValues)
                    {
                        if (type != null)
                        {
                            var property = type.GetProperty(fieldValues.FieldName);
                            if (property != null)
                            {
                                string actualValue = GetActualValue(property, requirement.EntityTypeCode);

                                var values = fieldValues.Values.Split(new string[] { Resources.Common.SemicolonSymbol }, StringSplitOptions.None);

                                if (values.Contains("not null"))
                                {
                                    if (actualValue == null)
                                    {
                                        emergencyLogs.Add(new EmergencyLog
                                        {
                                            Value = fieldValues.ErrorText,
                                            EmergencySituationParameterId = _emergencySituationParameterId
                                        });
                                    }
                                    continue;
                                }

                                if(actualValue != null && !values.Contains(actualValue))
                                {
                                    emergencyLogs.Add(new EmergencyLog
                                    {
                                        Value = fieldValues.ErrorText,
                                        EmergencySituationParameterId = _emergencySituationParameterId
                                    });
                                }
                            }
                        }
                    }
                }
            }

            if(emergencyLogs.Count > 0)
            {
                SaveEmergencyLogs(emergencyLogs);
            }

            return emergencyLogs.Count == 0;
        }
        
        private void SaveEmergencyLogs(List<EmergencyLog> emergencyLogs)
        {
            var emergencyLogHelper = new EmergencyLogHelper(_channel, _deviceReaderCache);
            emergencyLogHelper.AddEmergencyLogs(emergencyLogs);
            emergencyLogHelper.SaveEmergencyLogs();
        }

        /// <summary>
        /// Возвращает актуальное значение свойства сущности
        /// </summary>
        /// <param name="propertyInfo">Свойство</param>
        /// <param name="entityTypeCode">Имя сущности (Channel, MeasurementDevice или AccessPoint)</param>
        private string GetActualValue(PropertyInfo propertyInfo, string entityTypeCode)
        {
            object result = null;
            if(entityTypeCode.Contains(Resources.Common.ChannelEntityName))
            {
                result = propertyInfo.GetValue(_channel);
            }
            if(entityTypeCode.Contains(Resources.Common.MeasurementDeviceEntityName))
            {
                result = propertyInfo.GetValue(_measurementDevice);
            }
            if(entityTypeCode.Contains(Resources.Common.AccessPointEntityName))
            {
                result = propertyInfo.GetValue(_measurementDevice.AccessPoint);
            }

            if (result != null) return Convert.ToString(result);

            return null;
        }
    }
}

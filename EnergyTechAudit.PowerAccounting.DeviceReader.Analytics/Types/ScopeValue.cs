using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Dictionaries;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Rules;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types
{
    /// <summary>
    /// Класс, хранящий информацию о текущих значениях
    /// контролируемых параметров
    /// </summary>
    public class ScopeValue
    {
        public Argument Argument;
        public int? DeviceParameterId;
        public decimal? Value;
        public LightDataAccess.Dictionaries.MeasurementUnit DeviceParameterUnit;
        public Dimension DeviceParameterDimension;
        public decimal DeviceParameterDimensionCoef;
        public MeasurementUnitConverter MeasurementUnitConverter;
        public bool IsNeedToConvertUnit;
        public bool IsNeedToConvertDimension;
        public ChannelEmergencyInfo ParentChannelEmergencyInfo;
        public int? ParameterDictionaryId;
        public List<EmergencyLog> EmergencyLogs = new List<EmergencyLog>();
        public List<UserInputValue> UserInputValues;
    }
}

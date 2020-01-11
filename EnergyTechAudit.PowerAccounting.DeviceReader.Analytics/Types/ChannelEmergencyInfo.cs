using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types
{
    /// <summary>
    /// Класс, хранящий информацию о канале: его параметрах, взятых из шаблона;
    /// текущих значениях параметров
    /// </summary>
    public class ChannelEmergencyInfo
    {
        public Channel Channel;
        public string Address;
        public List<ParameterMapDeviceParameter> ParameterMapsDeviceParameter = new List<ParameterMapDeviceParameter>();
        public List<EmergencySituationParameter> EmergencySituationParameters = new List<EmergencySituationParameter>();
        public List<PreparedEmergencyCondition> PreparedEmergencyConditions = new List<PreparedEmergencyCondition>();
        public List<ScopeValue> ScopeValues = new List<ScopeValue>();
    }
}

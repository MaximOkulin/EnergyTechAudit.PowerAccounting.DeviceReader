using EnergyTechAudit.PowerAccounting.LightDataAccess.Analytics;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;


namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Types
{
    public class PreparedEmergencyCondition
    {
        public int? PreviousEmergencyLogId { get; set; }

        public EmergencySituationParameter EmergencySituationParameter { get; set; }
        public Expression Expression { get; set; }

        /// <summary>
        /// Имя сущности относительно которой осуществляется анализ нештатной ситуации
        /// </summary>
        public string EntityName { get; set; }
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Analytics.Collectors
{
    public class VKT7Collector : BaseCollector
    {
        public VKT7Collector(EmergencyEngine emergencyEngine) : base(emergencyEngine)
        {
        }

        public override void CollectValuesForScope()
        {
            if (EmergencyEngine.IsNeedToCollectParam("ThermalPower_SupplyPipe_Instant"))
            {
                CollectInstantThermalPowerSupplyPipe();
            }
            base.CollectValuesForScope();
        }

        private void CollectInstantThermalPowerSupplyPipe()
        {
            // Поиск Qo_1TypeP
            var archiveQ1 = GetLastArchiveByPeriod(PeriodType.Hour,
                GetQoLastHourArchivePredicate(DeviceParameter.VKT7_Qo_1TypeP));

            if (archiveQ1 != null)
            {
                var ts = DeviceTime - archiveQ1.Time;
                if (ts.Hours <= 1)
                {
                    var tv1ChannelTemplates = new[] { 2, 104, 106 };
                    EmergencyEngine.CollectIndirectValue(archiveQ1.Value, parameters => tv1ChannelTemplates.ToList().Contains(parameters.Channel.ChannelTemplateId),
                        scopeValue => scopeValue.Argument.ScopeParameterName.Equals("ThermalPower_SupplyPipe_Instant"));
                }
            }

            // Поиск Qo_2TypeP
            var archiveQ2 = GetLastArchiveByPeriod(PeriodType.Hour,
                GetQoLastHourArchivePredicate(DeviceParameter.VKT7_Qo_2TypeP));

            if (archiveQ2 != null)
            {
                var ts = DeviceTime - archiveQ2.Time;
                if (ts.Hours <= 1)
                {
                    var tv2ChannelTemplates = new[] { 3, 105, 107 };
                    EmergencyEngine.CollectIndirectValue(archiveQ2.Value, parameters => tv2ChannelTemplates.ToList().Contains(parameters.Channel.ChannelTemplateId),
                        scopeValue => scopeValue.Argument.ScopeParameterName.Equals("ThermalPower_SupplyPipe_Instant"));
                }
            }
        }

        private Expression<Func<Archive, bool>> GetQoLastHourArchivePredicate(DeviceParameter deviceParameter)
        {
            return (archive) => archive.DeviceParameterId == (int)deviceParameter;
        }
    }
}

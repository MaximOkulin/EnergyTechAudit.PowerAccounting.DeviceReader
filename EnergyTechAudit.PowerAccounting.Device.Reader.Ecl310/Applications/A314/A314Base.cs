using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A314
{
    /// <summary>
    /// Клаcc, реализующий базовую бизнес-логику приложения A314 (ECL Comfort 310)
    /// (регулирование заданной температуры воздуха (нагрева/охлаждения) для систем вентиляции
    /// </summary>
    internal class A314Base : A214314Base
    {
        public A314Base() :
            base()
        {

        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "LimitFreezeTemperature", "MinLimitFreezeTemperature", "LimitFreezeOptimizationTime",
                "FanFunction", "AccidentS5FreezingTemperature", "FrostThermostatParameters", "TemperatureMonitorParameters"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

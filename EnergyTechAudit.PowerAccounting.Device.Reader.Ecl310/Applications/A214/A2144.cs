using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A214
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A214.4
    /// </summary>
    internal sealed class A2144 : A214Base
    {
        public A2144() : base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "DeadBand", "LimitFreezeTemperature", "MinLimitFreezeTemperature", "LimitFreezeOptimizationTime",
                "MotorProtection2", "HwsParameters", "HwsDriveActivationTime", "FanFunction", "S4Filter", "TransitionModeTime", "FrostProtectionTemperature2",
                "AccidentS5FreezingTemperature", "FrostThermostatParameters", "TemperatureMonitorParameters"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

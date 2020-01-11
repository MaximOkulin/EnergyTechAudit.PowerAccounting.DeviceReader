using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A314
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A314.1
    /// </summary>
    internal sealed class A3141 : A314Base
    {
        public A3141() :
            base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "DeadBand", "MotorProtection2", "HwsParameters", "HwsDriveActivationTime",
                "MaxOutputVoltage", "MinOutputVoltage", "Reverse", "S4Filter", "TransitionModeTime", "FrostProtectionTemperature"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

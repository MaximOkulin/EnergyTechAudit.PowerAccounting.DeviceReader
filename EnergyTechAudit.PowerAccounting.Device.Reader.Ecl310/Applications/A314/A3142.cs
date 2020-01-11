using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A314
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A314.2
    /// </summary>
    internal sealed class A3142 : A314Base
    {
        public A3142() :
            base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "DeadBand", "MotorProtection2", "HwsParameters", "HwsDriveActivationTime",
                "MaxOutputVoltage", "MinOutputVoltage", "Reverse", "EcaAddressId", "TransitionModeTime"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

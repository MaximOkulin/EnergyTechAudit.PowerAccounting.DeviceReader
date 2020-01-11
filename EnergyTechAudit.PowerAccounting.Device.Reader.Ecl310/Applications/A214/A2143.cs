using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A214
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A214.3
    /// </summary>
    internal sealed class A2143 : A214Base
    {
        public A2143() : base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "LimitFreezeTemperature", "MinLimitFreezeTemperature", "LimitFreezeOptimizationTime",
                "RoomTemperaturesDiff", "FanFunction", "EcaAddressId", "AccidentS5FreezingTemperature", "FrostThermostatParameters",
                "TemperatureMonitorParameters"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

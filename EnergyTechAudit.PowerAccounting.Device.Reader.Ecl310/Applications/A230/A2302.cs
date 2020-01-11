using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A230
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A230.2
    /// </summary>
    internal sealed class A2302 : A230Base
    {
        public A2302() : base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            base.ReadParamsFromEcl();

            var rnd = new Random();

            return ExecuteReadRegulatorParameters(new[] { "HeatSystemParameters2Registers", "HeatSystemParameters8Registers",
                "RequiredTemperatures", "FlowLimitationParams5Registers", "CoolingLoadTemperatureCircuit1",
                "ExpectationFlowTemperatureCircuit1", "HeatSystemReverseParameters3Registers", "ManualRelayStatuses3Registers",
                "HeatSystemLimitReverseTemperature", "HsExternalSignal", "CompensationParameters", "OptimizationTime",
                "FlowLimitationInputTypeId", "MotorProtection", "EcaAddressId", "Offset", "HeatSystemPumpTrainingTime",
                "FlapTrainingCurcuit1", "ExternalInputParams"
            }.OrderBy(x => rnd.Next()).ToArray());
        }
    }
}

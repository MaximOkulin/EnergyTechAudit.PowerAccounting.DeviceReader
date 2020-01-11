using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A230
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A230.1
    /// </summary>
    internal sealed class A2301 : A230Base
    {
        public A2301() : base()
        {
            
        }
        
        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "HeatCurveAngle" });

            var rnd = new Random();

            var readResult3 = ExecuteReadRegulatorParameters(new[] { "HeatSystemParameters", "HeatSystemReverseParameters", "HeatCurve",
                "HeatSystemMaxWindInfluence", "OptimizationTime", "HeatSystemWindFilter", "HeatSystemWindLimit",
                "FlowLimitationParams", "FlowLimitationInputTypeId", "LimitReversePriority", "OptimizationParams",
                "OptimizationOffDelay", "OptimizationBasisId", "Blackout", "MotorProtection", "EcaAddressId",
                "Offset", "HeatSystemPumpTrainingTime", "FlapTrainingCurcuit1", "HwsPriorityCircuit1",
                "FrostProtectionTemperature", "ThermalLoadTemperatureCircuit1", "FrostProtectionTemperature2",
                "ExternalInputParams", "TemperatureMonitorParameters", "ManualRelayStatuses"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2 && readResult3;
        }
    }
}

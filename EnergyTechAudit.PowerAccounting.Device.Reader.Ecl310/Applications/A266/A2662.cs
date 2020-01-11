using System;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A266
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A266.2
    /// </summary>
    internal sealed class A2662 : A266Base
    {
        public A2662() :
            base()
        {

        }

        protected override void ReadInstantValues()
        {
            InitSensorParameters1Or2();
            InitSensorCalculatedParameters1Or2();
            base.ReadInstantValues();

            // Читаем рассчитанное значение для датчика S2
            if (ActionSteps.GetSensor2CalculatedValueCircuit1())
            {
                double val = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[0], val);
            }

            // Читаем рассчитанное значение для датчика S3
            if (ActionSteps.GetSensor3CalculatedValueCircuit1())
            {
                double val = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[1], val);
            }

            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Dev.UpdateLastTimeSignatureId();

            SetInstantArchiveValuesForAnalyze();
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();

            var readResult2 = ExecuteReadRegulatorParameters(new[]{ "HeatSystemParameters", "HwsParameters3Registers", "OptimizationTime",
                "FlowSensorParameters", "LimitReversePriority", "FlowLimitationParams", "FlowLimitationInputTypeId",
                "OptimizationParams", "OptimizationOffDelay", "OptimizationBasisId", "Blackout", "ParallelOperationCircuit1",
                "LimitReversePriorityCircuit2", "FlowLimitationParams5RegistersCircuit2", "FlowLimitationInputTypeCircuit2Id",
                "AutotuningCircuit2", "MotorProtection", "MotorProtection2", "GetEcaAddressId", "HwsPumpTrainingTime",
                "FlapTrainingCurcuit2", "FrostProtectionTemperatureCircuit2", "ThermalLoadTemperatureCircuit2",
                "FrostProtectionTemperature2Circuit2", "ExternalInputParamsCircuit2", "HeatSystemPumpTrainingTime", "FlapTrainingCurcuit1",
                "HwsPriorityCircuit1", "FrostProtectionTemperature", "ThermalLoadTemperatureCircuit1", "FrostProtectionTemperature2",
                "ExternalInputParams", "TemperatureMonitorParameters", "TemperatureMonitorParametersCircuit2", "SignalizationParamsCircuit1"
                
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

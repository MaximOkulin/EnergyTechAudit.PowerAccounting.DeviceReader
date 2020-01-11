using System;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A266
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A266.1
    /// </summary>
    internal class A2661 : A266Base
    {
        public A2661() :
            base()
        {
            
        }

        protected override void ReadInstantValues()
        {
            InitSensorParameters1Or2();
            InitSensorCalculatedParameters1Or2();
            base.ReadInstantValues();

            // Читаем рассчитанное значение для датчика S2
            DebugTrace("Читаем рассчитанное значение для датчика S2");
            if (ActionSteps.GetSensor2CalculatedValueCircuit1())
            {
                double val = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[0], val);
            }

            // Читаем рассчитанное значение для датчика S3
            DebugTrace("Читаем рассчитанное значение для датчика S3");
            if (ActionSteps.GetSensor3CalculatedValueCircuit1())
            {
                double val = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[1], val);
            }

            // Читаем рассчитанное значение для датчика S6
            DebugTrace("Читаем рассчитанное значение для датчика S6");
            if (ActionSteps.GetSensor6CalculatedValueCircuit2())
            {
                double sensor6CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[4], sensor6CalcValue);
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
            var readResult2 = ExecuteReadRegulatorParameters(new []{ "TemperatureMonitorParametersCircuit2",
                "DesiredHotWaterTemperatures", "HeatSystemParameters", "HwsParameters", "OptimizationTime", "LimitReversePriority", "FlowLimitationInputTypeId",
                "FlowLimitationParams", "OptimizationParams", "OptimizationOffDelay", "OptimizationBasisId", "Blackout", "ParallelOperationCircuit1",
                "LimitReversePriorityCircuit2", "FlowLimitationParams5RegistersCircuit2", "FlowLimitationInputTypeCircuit2Id", "FlowLimitationInputTypeCircuit2Id", 
                "AutotuningCircuit2", "HwsPumpTrainingTime", "FlapTrainingCurcuit2", "FrostProtectionTemperatureCircuit2", "ThermalLoadTemperatureCircuit2", 
                "FrostProtectionTemperature2Circuit2", "ExternalInputParamsCircuit2", "MotorProtection", "MotorProtection2", "EcaAddressId", 
                "HeatSystemPumpTrainingTime", "FlapTrainingCurcuit1", "HwsPriorityCircuit1", "FrostProtectionTemperature", "ThermalLoadTemperatureCircuit1", 
                "FrostProtectionTemperature2", "ExternalInputParams", "TemperatureMonitorParameters"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

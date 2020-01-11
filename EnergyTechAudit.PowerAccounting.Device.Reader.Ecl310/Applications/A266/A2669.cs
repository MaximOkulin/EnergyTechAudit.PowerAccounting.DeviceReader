using System;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A266
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A266.9
    /// </summary>
    internal sealed class A2669 : A266Base
    {
        public A2669() :
            base()
        {

        }

        protected override void ReadInstantValues()
        {
            InitSensorParameters9();
            InitSensorCalculatedParameters9();
            base.ReadInstantValues();

            // Читаем рассчитанное значение для датчика S3
            if (ActionSteps.GetSensor3CalculatedValueCircuit1())
            {
                double sensor3CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[1], sensor3CalcValue);
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

            var readResult2 = ExecuteReadRegulatorParameters(new[]{ "HwsParameters", "HeatSystemParameters3Registers", "HeatSystemKoefficients", "LimitReversePriority",
                "OptimizationParams", "Blackout", "MotorProtection", "MotorProtection2", "AutotuningCircuit2", "HeatSystemPumpTrainingTime",
                "FlapTrainingCurcuit1", "HwsPriorityCircuit1", "FrostProtectionTemperature", "ThermalLoadTemperatureCircuit1", "FrostProtectionTemperature2",
                "HwsPumpTrainingTime", "FlapTrainingCurcuit2", "FrostProtectionTemperatureCircuit2", "ThermalLoadTemperatureCircuit2", "FrostProtectionTemperature2Circuit2",
                "AccidentLimits", "PressureValues", "FireSafetyThermostatParameters", "SignalizationParamsCircuit1", "AccidentFrostThermostatDelay"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

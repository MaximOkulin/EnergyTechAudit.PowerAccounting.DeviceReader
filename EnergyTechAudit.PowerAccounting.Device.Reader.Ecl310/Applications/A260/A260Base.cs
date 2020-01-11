using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A260
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложения A260
    /// (управление оборудованием двух независимых систем отопления)
    /// </summary>
    internal class A260Base : ApplicationBase
    {
        public A260Base() : base()
        {
            InitSensorParameters();
            InitSensorCalculatedParameters();
        }

        /// <summary>
        /// Инициализирует соответствие измеряемых параметров каждому датчику
        /// </summary>
        protected void InitSensorParameters()
        {
            SensorParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_RawSensor1,
                DeviceParameter.ECL310_RawSensor2,
                DeviceParameter.ECL310_RawSensor3,
                DeviceParameter.ECL310_RawSensor4,
                DeviceParameter.ECL310_RawSensor5,
                DeviceParameter.ECL310_RawSensor6,
                DeviceParameter.ECL310_RawSensor8
            };
        }

        /// <summary>
        /// Инициализирует соответствие рассчитываемых измеряемых параметров каждому датчику
        /// </summary>
        protected void InitSensorCalculatedParameters()
        {
            SensorCalculatedParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_S2_SensorReference_C1,
                DeviceParameter.ECL310_S3_SensorReference_C1,
                DeviceParameter.ECL310_S4_SensorReference_C2,
                DeviceParameter.ECL310_S5_SensorReference_C1,
                DeviceParameter.ECL310_S6_SensorReference_C2
            };
        }

        protected override void ReadInstantValues()
        {
            // 1. Читаем показания датчиков
            if (ActionSteps.GetSensorsValues())
            {
                for (var sensorNumber = 1; sensorNumber <= SensorParameters.Count; sensorNumber++)
                {
                    double val = ParserBase.GetSensorValue(sensorNumber);
                    CreateArchiveValue(SensorParameters[sensorNumber - 1], val);
                }
            }

            // Читаем рассчитанное значение для датчика S2
            if (ActionSteps.GetSensor2CalculatedValueCircuit1())
            {
                double val2 = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[0], val2);
            }

            // Читаем рассчитанное значение для датчика S3
            if (ActionSteps.GetSensor3CalculatedValueCircuit1())
            {
                double val3 = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[1], val3);
            }

            // 3. Читаем рассчитанное значение для датчика S5
            if (ActionSteps.GetSensor5CalculatedValueCircuit1())
            {
                double sensor5CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[3], sensor5CalcValue);
            }

            // 4. Читаем рассчитанное значение для датчика S4
            if (ActionSteps.GetSensor4CalculatedValueCircuit2())
            {
                double sensor4CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[2], sensor4CalcValue);
            }

            // 5. Читаем рассчитанное значение для датчика S6
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
            var rnd = new Random();

            return ExecuteReadRegulatorParameters(new[] { "HeatSystemParameters", "OptimizationTime", "OptimizationTimeCircuit2",
                "Blackout", "BlackoutCircuit2", "HeatSystemReverseParameters", "HeatSystemDriveActivationTime",
                "MotorProtection", "MotorProtection2", "HwsPumpTrainingTime", "HeatCurve", "ExternalInputParams",
                "ExternalInputParamsCircuit2", "EcaAddressId", "EcaAddressCircuit2Id", "HeatSystemPumpTrainingTime",
                "FrostProtectionTemperature", "FrostProtectionTemperatureCircuit2", "ThermalLoadTemperatureCircuit1",
                "ThermalLoadTemperatureCircuit2", "Offset", "FlapTrainingCurcuit1", "FlapTrainingCurcuit2",
                "HwsPriorityCircuit1", "HwsPriorityCircuit2", "2CircuitParameters", "FrostProtectionTemperature2",
                "FlowLimitationParams", "FlowLimitationParamsCircuit2", "FrostProtectionTemperature2Circuit2",
                "HwsReverseParameters", "HwsDriveActivationTime", "OptimizationParams", "OptimizationParamsCircuit2",
                "TemperatureMonitorParameters", "TemperatureMonitorParametersCircuit2", "OptimizationOffDelay", "OptimizationOffDelayCircuit2",
                "LimitReversePriority", "LimitReversePriorityCircuit2", "FlowLimitationInputTypeId", "FlowLimitationInputTypeCircuit2Id",
                "OptimizationBasisId", "OptimizationBasisCircuit2Id", "HeatCurve2", "OperatingModes", "ManualRelayStatuses"
            }.OrderBy(x => rnd.Next()).ToArray());
        }
    }
}

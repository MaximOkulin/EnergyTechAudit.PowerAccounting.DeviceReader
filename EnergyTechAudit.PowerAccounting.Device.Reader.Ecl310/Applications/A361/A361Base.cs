using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A361
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложения A361
    /// </summary>
    internal class A361Base : ApplicationBase
    {
        public A361Base() :
            base()
        {
            InitSensorParameters();
            InitSensorCalculatedParameters();
        }

        /// <summary>
        /// Инициализирует соответствие измеряемых параметров каждому датчику
        /// </summary>
        private void InitSensorParameters()
        {
            SensorParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_RawSensor1,
                DeviceParameter.ECL310_RawSensor2,
                DeviceParameter.ECL310_RawSensor3,
                DeviceParameter.ECL310_RawSensor4,
                DeviceParameter.ECL310_RawSensor5,
                DeviceParameter.ECL310_RawSensor6,
                DeviceParameter.ECL310_RawSensor7,
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
                for (var sensorNumber = 1; sensorNumber <= 8; sensorNumber++)
                {
                    // пропускаем значение второго сенсора, т.к. он используется только в A361.2
                    if (sensorNumber == 2 && !KeyName.Equals("A3612"))
                    {
                        continue;
                    }

                    double val = ParserBase.GetSensorValue(sensorNumber,
                        GetScaleForParameter(SensorParameters[sensorNumber - 1]));
                    CreateArchiveValue(SensorParameters[sensorNumber - 1], val);
                }
            }

            // 2. Читаем рассчитанное значение для датчика S3
            if (ActionSteps.GetSensor3CalculatedValueCircuit1())
            {
                double sensor3CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[0], sensor3CalcValue);
            }

            // 3. Читаем рассчитанное значение для датчика S5
            if (ActionSteps.GetSensor5CalculatedValueCircuit1())
            {
                double sensor5CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[2], sensor5CalcValue);
            }

            // 4. Читаем рассчитанное значение для датчика S4
            if (ActionSteps.GetSensor4CalculatedValueCircuit2())
            {
                double sensor4CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[1], sensor4CalcValue);
            }

            // 5. Читаем рассчитанное значение для датчика S6
            if (ActionSteps.GetSensor6CalculatedValueCircuit2())
            {
                double sensor6CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[3], sensor6CalcValue);
            }
            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Dev.UpdateLastTimeSignatureId();

            SetInstantArchiveValuesForAnalyze();
        }

        protected override bool ReadParamsFromEcl()
        {
            var rnd = new Random();
            return ExecuteReadRegulatorParameters(new[]
            {
               "HeatSystemTemperatures", "HeatSystemKoefficients", "HeatSystemReverseParameters",
               "HeatSystemDriveActivationTime", "HeatCurve", "HeatSystemPumpParameters",
               "HeatSystemPumpTrainingTime", "PumpCount", "HeatSystemWaterFillParameters",
               "HsWaitOpenValveTime", "Ecl310PressureInputSignalTypeId", "HwsTemperatures",
               "HwsParameters", "HwsReverseParameters", "HwsDriveActivationTime", "HeatCurve2",
               "HwsPumpParameters", "HwsPumpTrainingTime", "Ecl310PressureInputSignalType2Id",
               "LimitReversePriority", "LimitReversePriorityCircuit2", "FlowLimitation2Params",
               "FlowLimitation5Params", "FlowLimitation2ParamsCircuit2", "FlowLimitation5ParamsCircuit2",
               "FlowLimitationInputTypeId", "FlowLimitationInputTypeCircuit2Id", "OptimizationParams",
               "OptimizationOffDelay", "Blackout", "OptimizationParamsCircuit2", "OptimizationOffDelayCircuit2",
               "BlackoutCircuit2", "MotorProtection", "MotorProtection2", "HeatSystemWaterFillParameters",
               "HsWaitOpenValveTime", "Ecl310PressureInputSignalTypeId", "HwsWaterFillParameters",
               "Ecl310PressureInputSignalType2Id", "Offset", "FlapTrainingCurcuit1", "HwsPriorityCircuit1",
               "FrostProtectionTemperature", "ThermalLoadTemperatureCircuit1", "FrostProtectionTemperature2",
               "ExternalInputParams", "FlapTrainingCurcuit2", "HwsPriorityCircuit2", "FrostProtectionTemperatureCircuit2",
               "ThermalLoadTemperatureCircuit2", "FrostProtectionTemperature2Circuit2", "ExternalInputParamsCircuit2",
               "TemperatureMonitorParameters", "TemperatureMonitorParametersCircuit2", "AccidentPumpsCircuit1",
               "AccidentPumpsCircuit2", "AccidentMakeupCircuit1", "AccidentMakeupCircuit2", "OperatingModes",
               "ManualRelayStatuses5Registers"
            }.OrderBy(x => rnd.Next()).ToArray());
        }

        /// <summary>
        /// Определяет коэффициент масштабирования величины параметра
        /// </summary>
        /// <param name="sensorParameter">Параметр, измеряемый датчиком</param>
        private int GetScaleForParameter(DeviceParameter sensorParameter)
        {
            int scale = sensorParameter == DeviceParameter.ECL310_RawSensor7 || sensorParameter == DeviceParameter.ECL310_RawSensor8
                ? 1
                : 100;
            return scale;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A368
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложения A368
    /// </summary>
    internal class A368Base : ApplicationBase
    {
        public A368Base() : base()
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
                DeviceParameter.ECL310_RawSensor8,
                DeviceParameter.ECL310_RawSensor9,
                DeviceParameter.ECL310_RawSensor11,
                DeviceParameter.ECL310_ECA32_S13,
                DeviceParameter.ECL310_ECA32_S14,
                DeviceParameter.ECL310_ECA32_S15,
                DeviceParameter.ECL310_ECA32_S16
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
                for (var sensorNumber = 1; sensorNumber <= 9; sensorNumber++)
                {
                    // пропускаем значение второго сенсора, т.к. он используется только в A386.2 и в A386.6
                    if (sensorNumber == 2 && !KeyName.Equals("A3682") && !KeyName.Equals("A3686"))
                    {
                        continue;
                    }

                    double val = ParserBase.GetSensorValue(sensorNumber,
                        GetScaleForParameter(SensorParameters[sensorNumber - 1]));
                    CreateArchiveValue(SensorParameters[sensorNumber - 1], val);
                }
            }

            if (KeyName.Equals("A3686"))
            {
                double val = ParserBase.GetSensorValue(10, 100);
                CreateArchiveValue(DeviceParameter.ECL310_RawSensor10, val);
            }

            if (KeyName.Equals("A3683") || KeyName.Equals("A3684"))
            {
                double val = ParserBase.GetSensorValue(11, 1);
                CreateArchiveValue(SensorParameters[9], val);

                if (ActionSteps.GetEca32SensorsValues())
                {
                    for (var sensorNumber = 1; sensorNumber <= 4; sensorNumber++)
                    {
                        double value = ParserBase.GetSensorValue(sensorNumber, 1);
                        CreateArchiveValue(SensorParameters[sensorNumber + 9], value);
                    }
                }

                if (ActionSteps.GetManualRelayStatuses7Registers())
                {
                    ParserBase.ParseManualRelayStatuses7Registers();
                }
            }
            else
            {
                if (ActionSteps.GetManualRelayStatuses5Registers())
                {
                    ParserBase.ParseManualRelayStatuses5Registers();
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
            return ExecuteReadRegulatorParameters(new[] { "HeatSystemTemperatures", "HeatSystemKoefficients", "HeatSystemReverseParameters",
                "HeatSystemDriveActivationTime", "HeatCurve", "HeatSystemPumpParameters", "HeatSystemPumpTrainingTime", "HeatSystemWaterFillParameters",
                "HeatSystemWaterFillParameters2", "HwsLimitReverseTemperature", "HwsMinMaxInfluenceReverse", "HwsMinMaxFlowTemperatures",
                "HwsParameters", "HwsDriveActivationTime", "DesiredHotWaterTemperatures", "HwsPumpParameters", "HwsPumpTrainingTime",
                "LimitReversePriority", "LimitReversePriorityCircuit2", "FlowLimitation2Params", "FlowLimitation5Params", "FlowLimitation2ParamsCircuit2",
                "FlowLimitationInputTypeId", "FlowLimitationInputTypeCircuit2Id", "FlowLimitationLimitCircuit2", "FlowLimitationUnitDict2Circuit2Id",
                "OptimizationParams", "OptimizationOffDelay", "Blackout", "ParallelOperationCircuit1", "MotorProtection", "MotorProtection2",
                "AutotuningCircuit2", "Offset", "FlapTrainingCurcuit1", "HwsPriorityCircuit1", "FrostProtectionTemperature", "ThermalLoadTemperatureCircuit1",
                "FrostProtectionTemperature2", "ExternalInputParams", "FlapTrainingCurcuit2", "FrostProtectionTemperatureCircuit2", "ThermalLoadTemperatureCircuit2",
                "FrostProtectionTemperature2Circuit2", "ExternalInputParamsCircuit2", "TemperatureMonitorParameters", "TemperatureMonitorParametersCircuit2",
                "AccidentPumpsCircuit1", "AccidentMakeupCircuit1", "AccidentPumpsCircuit2"
            }.OrderBy(x => rnd.Next()).ToArray());
        }

        /// <summary>
        /// Определяет коэффициент масштабирования величины параметра
        /// </summary>
        /// <param name="sensorParameter">Параметр, измеряемый датчиком</param>
        private int GetScaleForParameter(DeviceParameter sensorParameter)
        {
            // 7, 8, 9 - это как правило датчики давления или охранный вход
            int scale = sensorParameter == DeviceParameter.ECL310_RawSensor7 ||
                        sensorParameter == DeviceParameter.ECL310_RawSensor8 ||
                        sensorParameter == DeviceParameter.ECL310_RawSensor9
                ? 1
                : 100;
            return scale;
        }
    }
}

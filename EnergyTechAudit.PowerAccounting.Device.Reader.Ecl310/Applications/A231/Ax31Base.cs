using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A231
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложения A231/A331
    /// (управление оборудованием независимой системы отопления)
    /// </summary>
    internal class Ax31Base : ApplicationBase
    {
        public Ax31Base() : base()
        {

        }

        /// <summary>
        /// Инициализирует соответствие измеряемых параметров каждому датчику
        /// для приложения A231.1 и A331.1
        /// </summary>
        protected void InitSensorParameters1()
        {
            SensorParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_RawSensor1,
                DeviceParameter.ECL310_RawSensor3,
                DeviceParameter.ECL310_RawSensor5
            };
        }

        /// <summary>
        /// Инициализирует соответствие измеряемых параметров каждому датчику
        /// для приложения A231.2 и A331.2
        /// </summary>
        protected void InitSensorParameters2()
        {
            SensorParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_RawSensor1,
                DeviceParameter.ECL310_RawSensor2,
                DeviceParameter.ECL310_RawSensor3,
                DeviceParameter.ECL310_RawSensor5
            };
        }

        /// <summary>
        /// Инициализирует соответствие рассчитываемых измеряемых параметров каждому датчику
        /// (для всех приложений: А231.1,A231.2,A331.1,A331,2)
        /// </summary>
        protected void InitSensorCalculatedParameters()
        {
            SensorCalculatedParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_S3_SensorReference_C1,
                DeviceParameter.ECL310_S5_SensorReference_C1
            };
        }

        protected override void ReadInstantValues()
        {
            // 1. Читаем показания датчиков
            if (ActionSteps.GetSensorsValues())
            {
                // S1
                double valS1 = ParserBase.GetSensorValue(1);
                CreateArchiveValue(DeviceParameter.ECL310_RawSensor1, valS1);
                // S3
                double valS3 = ParserBase.GetSensorValue(3);
                CreateArchiveValue(DeviceParameter.ECL310_RawSensor3, valS3);
                // S5
                double valS5 = ParserBase.GetSensorValue(5);
                CreateArchiveValue(DeviceParameter.ECL310_RawSensor5, valS5);

                if (SensorParameters.Count == 4)
                {
                    // S2 - датчик температуры первичного контура (для А231.2 и A331.2)
                    double valS2 = ParserBase.GetSensorValue(2);
                    CreateArchiveValue(DeviceParameter.ECL310_RawSensor2, valS2);
                }
            }

            // 2. Читаем рассчитанное значение для датчика S3
            DebugTrace("Читаем рассчитанное значение для датчика S3");
            if (ActionSteps.GetSensor3CalculatedValueCircuit1())
            {
                double sensor3CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(DeviceParameter.ECL310_S3_SensorReference_C1, sensor3CalcValue);
            }

            // 3. Читаем рассчитанное значение для датчика S5
            DebugTrace("Читаем рассчитанное значение для датчика S5");
            if (ActionSteps.GetSensor5CalculatedValueCircuit1())
            {
                double sensor5CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(DeviceParameter.ECL310_S5_SensorReference_C1, sensor5CalcValue);
            }
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = ExecuteReadRegulatorParameters(new[] { "HeatCurveAngle" });

            var rnd = new Random();
            var readResult2 = ExecuteReadRegulatorParameters(new[]
            {
                "HeatCurve", "DesiredTemperaturesCircuit1", "HeatSystemReverseParameters", "LimitReversePriority", "FlowLimitationInputTypeId",
                "FlowLimitation2Params", "FlowLimitation5Params", "OptimizationParams", "Blackout", "OptimizationOffDelay", "MotorProtection",
                "HeatSystemKoefficients", "HeatSystemPumpParameters", "HeatSystemPumpTrainingTime2", "HeatSystemWaterFillParameters",
                "HeatSystemWaterFillParameters2", "Offset", "FlapTrainingCurcuit1", "HwsPriorityCircuit1", "FrostProtectionTemperature",
                "ThermalLoadTemperatureCircuit1", "FrostProtectionTemperature2", "ExternalInputParams", "HeatSystemDriveActivationTime",
                "TemperatureMonitorParameters", "AccidentPumpsCircuit1", "AccidentMakeupCircuit1", "HeatingBorder", "OperatingMode", "OperatingStatus"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

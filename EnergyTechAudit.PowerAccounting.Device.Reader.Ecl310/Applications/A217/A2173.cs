using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A217
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложения A217.3
    /// </summary>
    internal class A2173 : ApplicationBase
    {
        protected override void ReadInstantValues()
        {
            // Значение датчика S1
            ActionSteps.GetSensor1Value();
            double sensor1 = ParserBase.GetSensorValue(1);
            CreateArchiveValue(DeviceParameter.ECL310_RawSensor1, sensor1);

            // Значение датчика S2
            ActionSteps.GetSensor2Value();
            double sensor2 = ParserBase.GetSensorValue(1);
            CreateArchiveValue(DeviceParameter.ECL310_RawSensor2, sensor2);

            // Значение датчика S3
            ActionSteps.GetSensor3Value();
            double sensor3 = ParserBase.GetSensorValue(1);
            CreateArchiveValue(DeviceParameter.ECL310_RawSensor3, sensor3);

            // Значение датчика S5
            ActionSteps.GetSensor5Value();
            double sensor5 = ParserBase.GetSensorValue(1);
            CreateArchiveValue(DeviceParameter.ECL310_RawSensor5, sensor5);

            // Читаем рассчитанное значение для датчика S3
            if (ActionSteps.GetSensor3CalculatedValueCircuit1())
            {
                double sensor3CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(DeviceParameter.ECL310_S3_SensorReference_C1, sensor3CalcValue);
            }

            // Читаем рассчитанное значение для датчика S5
            if (ActionSteps.GetSensor5CalculatedValueCircuit1())
            {
                double sensor5CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(DeviceParameter.ECL310_S5_SensorReference_C1, sensor5CalcValue);
            }

            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Dev.UpdateLastTimeSignatureId();

            SetInstantArchiveValuesForAnalyze();
        }

        protected override bool ReadParamsFromEcl()
        {
            var rnd = new Random();

            return ExecuteReadRegulatorParameters(new[] { "HeatSystemParameters2Registers", "HeatSystemReverseParameters3Registers", "LimitReversePriority",
            "FlowLimitationParams5Registers", "FlowLimitationInputTypeId", "MotorProtection", "Pnu11173", "Pnu11185_11187", "Pnu11189", "Pnu11094_11097",
            "SendPredeterminedTemperature", "HeatSystemPumpTrainingTime", "FlapTrainingCurcuit1", "FrostProtectionTemperature2",
            "ExternalInputParams", "Pnu11076", "Pnu11040", "TemperatureMonitorParameters", "NewDesiredHotWaterTemperatures" }.OrderBy(x => rnd.Next()).ToArray());
        }
    }
}

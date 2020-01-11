using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A230
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложения A230
    /// (регулирование температуры в одном контуре тепло- или холодоснабжения)
    /// </summary>
    internal class A230Base : ApplicationBase
    {
        public A230Base() :  base()
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
                DeviceParameter.ECL310_S5_SensorReference_C1
            };
        }

        protected override void ReadInstantValues()
        {
            // 1. Читаем показания датчиков
            if (ActionSteps.GetSensorsValues())
            {
                for (var sensorNumber = 1; sensorNumber <= 5; sensorNumber++)
                {
                    double val = ParserBase.GetSensorValue(sensorNumber);
                    CreateArchiveValue(SensorParameters[sensorNumber - 1], val);
                }

                if (KeyName.Equals("A2301"))
                {
                    double val = ParserBase.GetSensorValue(8);
                    CreateArchiveValue(SensorParameters[6], val);
                }
                else if (KeyName.Equals("A2302"))
                {
                    double val = ParserBase.GetSensorValue(6);
                    CreateArchiveValue(SensorParameters[5], val);
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
                CreateArchiveValue(SensorCalculatedParameters[2], sensor5CalcValue);
            }
            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Dev.UpdateLastTimeSignatureId();

            SetInstantArchiveValuesForAnalyze();
        }

        protected override bool ReadParamsFromEcl()
        {
            var rnd = new Random();

            return ExecuteReadRegulatorParameters(new[] { "HeatSystemDriveActivationTime", "OperatingMode", "OperatingStatus"
            }.OrderBy(x => rnd.Next()).ToArray());
        }
    }
}

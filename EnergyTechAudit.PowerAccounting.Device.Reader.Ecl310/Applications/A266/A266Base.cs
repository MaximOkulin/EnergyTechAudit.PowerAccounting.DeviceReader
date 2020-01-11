using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A266
{
    /// <summary>
    /// Класс, реализующий базовую бизнес-логику приложения A266
    /// (управление оборудованием двух независимых систем отопления и горячего водоснабжения (ГВС)
    /// при централизованном теплоснабжении)
    /// </summary>
    internal class A266Base : ApplicationBase
    {
        public A266Base() :
            base()
        {
            
        }

        /// <summary>
        /// Инициализирует соответствие измеряемых параметров каждому датчику
        /// для приложений A266.1 и A266.2
        /// </summary>
        protected void InitSensorParameters1Or2()
        {
            SensorParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_RawSensor1,
                DeviceParameter.ECL310_RawSensor2,
                DeviceParameter.ECL310_RawSensor3,
                DeviceParameter.ECL310_RawSensor4,
                DeviceParameter.ECL310_RawSensor5,
                DeviceParameter.ECL310_RawSensor6
            };
        }

        /// <summary>
        /// Инициализирует соответствие измеряемых параметров каждому датчику
        /// для приложения A266.9
        /// </summary>
        protected void InitSensorParameters9()
        {
            SensorParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_RawSensor1,
                DeviceParameter.ECL310_RawSensor2,
                DeviceParameter.ECL310_RawSensor3,
                DeviceParameter.ECL310_RawSensor4,
                DeviceParameter.ECL310_RawSensor5,
                DeviceParameter.ECL310_RawSensor6,
                DeviceParameter.ECL310_RawSensor7
            };
        }

        /// <summary>
        /// Инициализирует соответствие рассчитываемых измеряемых параметров каждому датчику
        /// для приложений A266.1 и A266.2
        /// </summary>
        protected void InitSensorCalculatedParameters1Or2()
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

        /// <summary>
        /// Инициализирует соответствие рассчитываемых измеряемых параметров каждому датчику
        /// для приложения A266.9
        /// </summary>
        protected void InitSensorCalculatedParameters9()
        {
            SensorCalculatedParameters = new List<DeviceParameter>
            {
                DeviceParameter.ECL310_S2_SensorReference_C1,
                DeviceParameter.ECL310_S3_SensorReference_C1,
                DeviceParameter.ECL310_S4_SensorReference_C2,
                DeviceParameter.ECL310_S5_SensorReference_C1,
                DeviceParameter.ECL310_S6_SensorReference_C2,
                DeviceParameter.ECL310_S7_SensorReference_C1
            };
        }

        protected override void ReadInstantValues()
        {
            // 1. Читаем показания датчиков
            DebugTrace("Чтение показаний датчиков");
            if(ActionSteps.GetSensorsValues())
            {
                for (var sensorNumber = 1; sensorNumber <= SensorParameters.Count; sensorNumber++)
                {
                    double val = ParserBase.GetSensorValue(sensorNumber);
                    CreateArchiveValue(SensorParameters[sensorNumber - 1], val);
                }
            }
            
            // 3. Читаем рассчитанное значение для датчика S5
            DebugTrace("Читаем рассчитанное значение для датчика S5");
            if (ActionSteps.GetSensor5CalculatedValueCircuit1())
            {
                double sensor5CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[3], sensor5CalcValue);
            }
            

            // 4. Читаем рассчитанное значение для датчика S4
            DebugTrace("Читаем рассчитанное значение для датчика S4");
            if (ActionSteps.GetSensor4CalculatedValueCircuit2())
            {
                double sensor4CalcValue = ParserBase.GetSensorValue(1);
                CreateArchiveValue(SensorCalculatedParameters[2], sensor4CalcValue);
            }            
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = ExecuteReadRegulatorParameters(new [] { "HeatCurveAngle" });

            var rnd = new Random();
            var readResult2 = ExecuteReadRegulatorParameters(new []
            {
                "HeatSystemReverseParameters", "HeatSystemDriveActivationTime", "HeatCurve", "HwsLimitReverseTemperature",
                "HwsMinMaxInfluenceReverse", "HwsMinMaxFlowTemperatures", "HwsDriveActivationTime", "OperatingModes", "OperatingStatuses", "ManualRelayStatuses"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

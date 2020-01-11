using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Applications
{
    internal class K130 : Application
    {
        protected override void ReadInstantValues()
        {
            if (ActionSteps.GetPnu11200_11203())
            {
                // S1
                decimal sensor1Value = (decimal) ParserBase.GetSensorValue(1);
                CreateArchiveValue(DeviceParameter.ECL110_RawSensor1, sensor1Value);

                // S2
                decimal sensor2Value = (decimal)ParserBase.GetSensorValue(2);
                CreateArchiveValue(DeviceParameter.ECL110_RawSensor2, sensor2Value);

                // S3
                decimal sensor3Value = (decimal)ParserBase.GetSensorValue(3);
                CreateArchiveValue(DeviceParameter.ECL110_RawSensor3, sensor3Value);

                // S4
                decimal sensor4Value = (decimal)ParserBase.GetSensorValue(4);
                CreateArchiveValue(DeviceParameter.ECL110_RawSensor4, sensor2Value);
            }

            if (ActionSteps.GetPnu11228_11229())
            {
                // S2 desired
                decimal sensor2DesiredValue = (decimal)ParserBase.GetSensorValue(1);
                CreateArchiveValue(DeviceParameter.ECL110_DesiredSensor2, sensor2DesiredValue);

                // S3 desired
                decimal sensor3DesiredValue = (decimal)ParserBase.GetSensorValue(2);
                CreateArchiveValue(DeviceParameter.ECL110_DesiredSensor3, sensor3DesiredValue);
            }

            // текущее время прибора
            SensorsValues.Add(new Common.Types.ValueInfo
            {
                PeriodType = PeriodType.Instant,
                Time = DateTime.Now,
                DeviceParameterId = (int)DeviceParameter.ECL110_DeviceTime,
                Value = (decimal)DeviceTime.ToOADate(),
                IsValid = true
            });

            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Device.UpdateLastTimeSignatureId();
        }

        protected override bool ReadParamsFromEcl()
        {
            return ExecuteReadRegulatorParameters(new[] { Ecl110Resources.Pnu11010_11014, Ecl110Resources.Pnu11019_11023, Ecl110Resources.Pnu11034_11036,
            Ecl110Resources.Pnu11029, Ecl110Resources.Pnu11051, Ecl110Resources.Pnu11084, Ecl110Resources.Pnu11140, Ecl110Resources.Pnu11161,
                Ecl110Resources.Pnu11076_11077, Ecl110Resources.Pnu11173_11180, Ecl110Resources.Pnu11181_11186, Ecl110Resources.Pnu11188
           });
        }
    }
}

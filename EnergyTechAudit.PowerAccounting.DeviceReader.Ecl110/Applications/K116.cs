using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.Applications
{
    internal class K116 : Application
    {
        protected override void ReadInstantValues()
        {
            if (ActionSteps.GetPnu11200_11203())
            {
                // S2
                decimal sensor2Value = (decimal)ParserBase.GetSensorValue(2);
                CreateArchiveValue(DeviceParameter.ECL110_RawSensor2, sensor2Value, sensor2Value < 192);

                // S3
                decimal sensor3Value = (decimal)ParserBase.GetSensorValue(3);
                CreateArchiveValue(DeviceParameter.ECL110_RawSensor3, sensor3Value, sensor3Value < 192);

                // S4
                decimal sensor4Value = (decimal)ParserBase.GetSensorValue(4);
                CreateArchiveValue(DeviceParameter.ECL110_RawSensor4, sensor4Value, sensor4Value < 192);
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
            return ExecuteReadRegulatorParameters(new[] { Ecl110Resources.Pnu11029, Ecl110Resources.Pnu11034_11036,
                Ecl110Resources.Pnu11076_11077, Ecl110Resources.Pnu11140, Ecl110Resources.Pnu11188,
                Ecl110Resources.Pnu11021_11022, Ecl110Resources.Pnu11092, Ecl110Resources.Pnu11176_11177, Ecl110Resources.Pnu11183_11186
            });
        }
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Applications.RS232
{
    internal class RS232Base : Application
    {
        protected override void ReadInstantValues()
        {
            if (ActionSteps.GetSensor1())
            {
                decimal sensor1Value = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor1, sensor1Value);
            }

            if (ActionSteps.GetSensor2())
            {
                decimal sensor2Value = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor2, sensor2Value);
            }

            if (ActionSteps.GetSensor3())
            {
                decimal sensor3Value = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor3, sensor3Value);
            }

            if (ActionSteps.GetSensor4())
            {
                decimal sensor4Value = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor4, sensor4Value);
            }

            if (ActionSteps.GetSensor5())
            {
                decimal sensor5Value = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor5, sensor5Value);
            }

            if (ActionSteps.GetSensor6())
            {
                decimal sensor6Value = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor6, sensor6Value);
            }

            if (ActionSteps.GetCalcFlow1())
            {
                decimal calcFlow1 = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_CalcFlow1, calcFlow1);
            }

            if (ActionSteps.GetCalcFlow2())
            {
                decimal calcFlow2 = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_CalcFlow2, calcFlow2);
            }

            if (ActionSteps.GetCalcReturn1())
            {
                decimal calcReturn1 = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_CalcReturn1, calcReturn1);
            }

            if (ActionSteps.GetCalcReturn2())
            {
                decimal calcReturn2 = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_CalcReturn2, calcReturn2);
            }

            if (ActionSteps.GetRoomTemp1())
            {
                decimal roomTemp1 = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_RoomTemp1, roomTemp1);
            }

            if (ActionSteps.GetRoomTemp2())
            {
                decimal roomTemp2 = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_RoomTemp2, roomTemp2);
            }

            if (ActionSteps.GetOutdoorTemperature())
            {
                decimal outdoor = ParserBase.GetSensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_OutdoorTemperature, outdoor);
            }

            if (ActionSteps.GetMode1())
            {
                decimal mode1 = ParserBase.GetMode();
                CreateArchiveValue(DeviceParameter.ECL300_Mode1, mode1);
            }

            if (ActionSteps.GetMode2())
            {
                decimal mode2 = ParserBase.GetMode();
                CreateArchiveValue(DeviceParameter.ECL300_Mode2, mode2);
            }

            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Device.UpdateLastTimeSignatureId();
        }

        protected override bool ReadParamsFromEcl()
        {
            return ExecuteReadRegulatorParameters(new[] { "HeatCurve1", "RoomTempDaySet", "RoomTempNightSet", "SummerCutout1", "SummerCutout2" });
        }
    }
}

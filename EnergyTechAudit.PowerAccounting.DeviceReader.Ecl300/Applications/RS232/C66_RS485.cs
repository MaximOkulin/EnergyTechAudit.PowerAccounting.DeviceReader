using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.API;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Applications.RS232
{
    internal class C66_RS485 : Application
    {
        protected override void ReadInstantValues()
        {
            // Значения датчиков
            if (ActionSteps.GetRs485Sensor1())
            {
                decimal sensor1Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_OutdoorTemperature, sensor1Value);
            }

            if (ActionSteps.GetRs485Sensor2())
            {
                decimal sensor2Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor2, sensor2Value);
            }

            if (ActionSteps.GetRs485Sensor3())
            {
                decimal sensor3Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor3, sensor3Value);
            }

            if (ActionSteps.GetRs485Sensor4())
            {
                decimal sensor4Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor4, sensor4Value);
            }

            if (ActionSteps.GetRs485Sensor5())
            {
                decimal sensor5Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor5, sensor5Value);
            }

            if (ActionSteps.GetRs485Sensor6())
            {
                decimal sensor6Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_Sensor6, sensor6Value);
            }

            // уставки датчиков
            if (ActionSteps.GetRs485ReferenceS1())
            {
                decimal sensor1Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_ReferenceS1, sensor1Value);
            }

            if (ActionSteps.GetRs485ReferenceS2())
            {
                decimal sensor2Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_ReferenceS2, sensor2Value);
            }

            if (ActionSteps.GetRs485ReferenceS3())
            {
                decimal sensor3Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_ReferenceS3, sensor3Value);
            }

            if (ActionSteps.GetRs485ReferenceS4())
            {
                decimal sensor4Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_ReferenceS4, sensor4Value);
            }

            if (ActionSteps.GetRs485ReferenceS5())
            {
                decimal sensor5Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_ReferenceS5, sensor5Value);
            }

            if (ActionSteps.GetRs485ReferenceS6())
            {
                decimal sensor6Value = ParserBase.GetRs485SensorValue();
                CreateArchiveValue(DeviceParameter.ECL300_ReferenceS6, sensor6Value);
            }

            // режимы и состояния контуров 1 и 2
            if (ActionSteps.GetRs485Circuit1Mode())
            {
                decimal mode = ParserBase.GetRs485ModeValue();
                CreateArchiveValue(DeviceParameter.ECL300_Mode1, mode);
            }

            if (ActionSteps.GetRs485Circuit2Mode())
            {
                decimal mode = ParserBase.GetRs485ModeValue();
                CreateArchiveValue(DeviceParameter.ECL300_Mode2, mode);
            }

            if (ActionSteps.GetRs485Circuit1Status())
            {
                decimal status = ParserBase.GetRs485ModeValue();
                CreateArchiveValue(DeviceParameter.ECL300_Status1, status);
            }

            if (ActionSteps.GetRs485Circuit2Status())
            {
                decimal status = ParserBase.GetRs485ModeValue();
                CreateArchiveValue(DeviceParameter.ECL300_Status2, status);
            }

            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Device.UpdateLastTimeSignatureId();
        }

        protected override bool ReadParamsFromEcl()
        {
            return ExecuteReadRegulatorParameters(new[] { Ecl300Resources.HeatCurve1_RS485, Ecl300Resources.HeatCurve2_RS485, Ecl300Resources.Parallel1_RS485, Ecl300Resources.Parallel2_RS485,
            Ecl300Resources.HsHeatingOffTemperature1_RS485, Ecl300Resources.HsHeatingOffTemperature2_RS485, Ecl300Resources.MinHsFlowTemperature1_RS485, Ecl300Resources.MinHsFlowTemperature2_RS485,
            Ecl300Resources.MaxHsFlowTemperature1_RS485, Ecl300Resources.MaxHsFlowTemperature2_RS485, Ecl300Resources.MaxAirInfluence1_RS485, Ecl300Resources.MinAirInfluence1_RS485,
            Ecl300Resources.MaxAirInfluence2_RS485, Ecl300Resources.MinAirInfluence2_RS485, Ecl300Resources.ProportionalBand1_RS485, Ecl300Resources.ProportionalBand2_RS485,
            Ecl300Resources.IntegrationTime1_RS485, Ecl300Resources.IntegrationTime2_RS485, Ecl300Resources.DriveStockTravelTime1_RS485, Ecl300Resources.DriveStockTravelTime2_RS485,
            Ecl300Resources.NeutralZone1_RS485, Ecl300Resources.NeutralZone2_RS485,Ecl300Resources.ReducedTempAddiction1_RS485, Ecl300Resources.ReducedTempAddiction2_RS485,
            Ecl300Resources.Overrun1_RS485, Ecl300Resources.Overrun2_RS485, Ecl300Resources.SmoothTransition1_RS485, Ecl300Resources.SmoothTransition2_RS485, Ecl300Resources.OptimizationTimeConstant1_RS485, Ecl300Resources.OptimizationTimeConstant2_RS485,
            Ecl300Resources.AirRoomAdaptation1_RS485, Ecl300Resources.AirRoomAdaptation2_RS485, Ecl300Resources.ExternalInfluenceTemp1_RS485, Ecl300Resources.AirRoomOptimization1_RS485,
             Ecl300Resources.AirRoomOptimization2_RS485, Ecl300Resources.Blackout1_RS485, Ecl300Resources.Blackout2_RS485, Ecl300Resources.PumpTraining1_RS485, Ecl300Resources.PumpTraining2_RS485,
             Ecl300Resources.FlapTraining1_RS485, Ecl300Resources.FlapTraining2_RS485, Ecl300Resources.DriveType1_RS485, Ecl300Resources.DriveType2_RS485, Ecl300Resources.OpenAirTemp_X1_1_RS485,
                Ecl300Resources.OpenAirTemp_X1_2_RS485, Ecl300Resources.ReturnTemp_Y1_1_RS485, Ecl300Resources.ReturnTemp_Y1_2_RS485,
             Ecl300Resources.OpenAirTemp_X2_1_RS485, Ecl300Resources.OpenAirTemp_X2_2_RS485, Ecl300Resources.ReturnTemp_Y2_1_RS485, Ecl300Resources.ReturnTemp_Y2_2_RS485, Ecl300Resources.MaxInfluenceReverse1_RS485,
                Ecl300Resources.MaxInfluenceReverse2_RS485, Ecl300Resources.MinInfluenceReverse1_RS485, Ecl300Resources.MinInfluenceReverse2_RS485,
             Ecl300Resources.ReturnOptimizationViaSupply1_RS485, Ecl300Resources.ReturnOptimizationViaSupply2_RS485, Ecl300Resources.ParallelWorkHwsAndHeatSys1_RS485, Ecl300Resources.PIRegulation1_RS485, Ecl300Resources.PIRegulation2_RS485,
                Ecl300Resources.MotorProtection1_RS485, Ecl300Resources.MotorProtection2_RS485, Ecl300Resources.ChangeSeason1_RS485,
             Ecl300Resources.RoomTempDaySet1_RS485, Ecl300Resources.RoomTempDaySet2_RS485, Ecl300Resources.RoomTempNightSet1_RS485, Ecl300Resources.RoomTempNightSet2_RS485, Ecl300Resources.HotWaterTempDaySet1_RS485,
                Ecl300Resources.HotWaterTempDaySet2_RS485, Ecl300Resources.HotWaterTempNightSet1_RS485, Ecl300Resources.HotWaterTempNightSet2_RS485,
            Ecl300Resources.LimitReverseTemperature1_RS485, Ecl300Resources.LimitReverseTemperature2_RS485, Ecl300Resources.Autotuning2_RS485});
        }
    }
}

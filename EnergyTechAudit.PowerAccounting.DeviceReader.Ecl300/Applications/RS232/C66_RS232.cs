namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Applications.RS232
{
    internal class C66_RS232 : RS232Base
    {
        protected override bool ReadParamsFromEcl()
        {
            var resultRead1 = base.ReadParamsFromEcl();

            var resultRead2 = ExecuteReadRegulatorParameters(new[] { "HotWaterTempDaySet_C66_RS232", "HotWaterTempNightSet_C66_RS232", "Parallel1_C66_RS232", "FlowTempMin1_C66_RS232", "FlowTempMax1_C66_RS232" });

            return resultRead1 && resultRead2;
        }
    }
}

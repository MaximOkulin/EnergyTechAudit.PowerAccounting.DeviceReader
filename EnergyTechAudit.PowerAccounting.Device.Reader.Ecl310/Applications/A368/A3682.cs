namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A368
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A368.2
    /// </summary>
    internal sealed class A3682 : A368Base
    {
        public A3682() :  base()
        {

        }


        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "HeatSystemSupplyTemperatureLimits" });

            return readResult1 && readResult2;
        }
    }
}

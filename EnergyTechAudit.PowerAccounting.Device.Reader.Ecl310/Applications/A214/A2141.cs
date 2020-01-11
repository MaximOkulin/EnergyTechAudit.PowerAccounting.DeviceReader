namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A214
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A214.1
    /// </summary>
    internal sealed class A2141 : A214Base
    {
        public A2141() :  base()
        {
            
        }

        protected override bool  ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "EcaAddressId" });

            return readResult1 && readResult2;
        }
    }
}

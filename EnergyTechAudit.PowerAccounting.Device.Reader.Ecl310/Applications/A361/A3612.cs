using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A361
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A361.2
    /// </summary>
    internal sealed class A3612 : A361Base
    {
        public A3612() :
            base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();
            var readResult2 = ExecuteReadRegulatorParameters(new[] {
               "HeatSystemSupplyTemperatureLimits", "HwsSupplyTemperatureLimits"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

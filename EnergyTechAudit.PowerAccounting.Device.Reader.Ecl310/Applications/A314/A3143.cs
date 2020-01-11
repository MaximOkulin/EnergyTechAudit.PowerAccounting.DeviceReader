using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A314
{
    /// <summary>
    /// Класс, реализующий ключ-приложение A314.3
    /// </summary>
    internal sealed class A3143 : A314Base
    {
        public A3143() :
            base()
        {
            
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();

            var readResult2 = ExecuteReadRegulatorParameters(new[] { "HeatSystemWindFilter", "RoomTemperaturesDiff", "EcaAddressId"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

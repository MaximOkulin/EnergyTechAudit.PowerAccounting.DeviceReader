using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A231
{
    internal sealed class A2312 : Ax31Base
    {
        public A2312() :  base()
        {

        }

        protected override void ReadInstantValues()
        {
            InitSensorParameters2();
            base.ReadInstantValues();

            ArchiveCollector.CreateArchives(SensorsValues);
            ArchiveCollector.SaveArchives();

            Dev.UpdateLastTimeSignatureId();
            SetInstantArchiveValuesForAnalyze();
        }

        protected override bool ReadParamsFromEcl()
        {
            var readResult1 = base.ReadParamsFromEcl();

            var rnd = new Random();
            var readResult2 = ExecuteReadRegulatorParameters(new[]{
                "HeatSystemParameters1Registers", "HeatSystemSupplyTemperatureLimits"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

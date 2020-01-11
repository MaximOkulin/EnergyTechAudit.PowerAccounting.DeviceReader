using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A231
{
    internal sealed class A3311 : Ax31Base
    {
        public A3311() : base()
        {

        }

        protected override void ReadInstantValues()
        {
            InitSensorParameters1();
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
                "HeatSystemParameters2Registers"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResult1 && readResult2;
        }
    }
}

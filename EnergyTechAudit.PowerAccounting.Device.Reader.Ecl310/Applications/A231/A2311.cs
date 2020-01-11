using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Applications.A231
{
    internal sealed class A2311 : Ax31Base
    {
        public A2311() : base()
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
            var readResul1 = base.ReadParamsFromEcl();

            var rnd = new Random();
            var readResult2 = ExecuteReadRegulatorParameters(new[]{
                "HeatSystemParameters2Registers"
            }.OrderBy(x => rnd.Next()).ToArray());

            return readResul1 && readResult2;
        }
    }
}

using System.ServiceProcess;
using EnergyTechAudit.PowerAccounting.DeviceReader.Engine;

namespace EnergyTechAudit.DeviceReader.ClientService
{
    public partial class Service : ServiceBase
    {
        private Engine _engine;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _engine = new Engine();
            _engine.Run();
        }

        protected override void OnStop()
        {
            if (_engine != null)
            {
                _engine.Stop();
            }
        }
    }
}

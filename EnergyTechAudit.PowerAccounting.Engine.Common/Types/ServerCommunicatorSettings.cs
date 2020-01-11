using EnergyTechAudit.PowerAccounting.LightDataAccess.Admin;
using Reader = EnergyTechAudit.PowerAccounting.LightDataAccess.Business.DeviceReader;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class ServerCommunicatorSettings
    {
        private readonly User _user;
        private readonly string _netAddress;
        private readonly string _controller;
        private readonly string _receiveAction;

        public User User
        {
            get
            {
                return _user;
            }
        }

        public string NetAddress
        {
            get
            {
                return _netAddress;
            }
        }

        public string Controller
        {
            get
            {
                return _controller;
            }
        }
        public string ReceiveAction
        {
            get
            {
                return _receiveAction;
            }
        }

        public ServerCommunicatorSettings(Reader deviceReader)
        {
            _user = deviceReader.User;
            _controller = deviceReader.ServerCommunicatorController;
            _netAddress = deviceReader.ServerCommunicatorNetAddress;
            _receiveAction = deviceReader.ServerCommunicatorReceiveAction;
        }
    }
}

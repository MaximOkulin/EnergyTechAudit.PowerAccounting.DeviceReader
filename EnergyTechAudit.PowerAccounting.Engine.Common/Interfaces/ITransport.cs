using System.Security.Cryptography.X509Certificates;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using System.Net.Sockets;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces
{
    public interface ITransport
    {
        byte[] Buffer { get; }
        Command CurrentCommand { get; set; }

        ErrorCode CurrentErrorCode { get; set; }

        LogHelper LogHelper { get; set; }

        bool IsLostConnectionRaised { get; }

        string CurrentRequestDump { get; }

        TransportTypes TransportType { get; set; }

        string ErrorText { get; set; }

        void Send(object state, bool useAttemptsInFail = false, int? timeOut = null, int timeOutBeforeSend = 0);

        void ReadDataFromPort();
    }
}

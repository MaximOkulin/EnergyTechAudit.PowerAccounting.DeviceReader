namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{
    public class SignalrInfo
    {
        private string _uri;
        private string _traceHub;

        public string Uri
        {
            get { return _uri; }
        }

        public string TraceHub
        {
            get { return _traceHub; }
        }

        public SignalrInfo(string address, int port, string traceHub)
        {
            _uri = string.Format(Resources.Common.SignalrUriPattern, address, port);
            _traceHub = traceHub;
        }

        public SignalrInfo(LightDataAccess.Business.DeviceReader deviceReader):
            this(deviceReader.SignalRNetAddress, deviceReader.SignalRPort, deviceReader.SignalRHub)
        {
            
        }
    }
}

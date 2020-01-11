using System.IO.Ports;
using System.Text;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    public class ComPortTransport : Transport
    {
        public ComPortTransport(ManualResetEvent autoEvent) : base(autoEvent, null)
        {
            
        }

        protected override void FirstIteration(byte[] buffer)
        {
            var str = Encoding.ASCII.GetString(buffer);

            if (CurrentCommand.ResponseLengthType == LengthType.Fixed)
            {
                  State.TotalBytes = CurrentCommand.ResponseLength;
                  State.IsFirstIteration = false;
            }
        }

        public bool InitConnection()
        {
            var connectionInfo = new ConnectionInfo
            {
                SerialPortName = "COM2",
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One
            };
            return InitConnection(1, connectionInfo);
        }
    }
}

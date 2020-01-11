using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Moxa
{
    internal sealed class MoxaConnection : ConnectionServerTransport
    {
        public MoxaConnection(MeasurementDevice device, ManualResetEvent autoEvent, LogHelper logHelper) :
            base(device, autoEvent, logHelper)
        {
            
        }

        protected override void FirstIteration(byte[] buffer)
        {
            if (CurrentCommand.ResponseLengthType == LengthType.Fixed)
            {
                State.TotalBytes = CurrentCommand.ResponseLength;
            }
            State.IsFirstIteration = false;
        }
    }
}

using System;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Exceptions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Interfaces;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base
{
    /// <summary>
    /// Базовый класс выполнения действий с прибором
    /// </summary>
    public class ActionStepsBase
    {
        public ITransport Transport;
        protected ManualResetEvent AutoEvent;
        

        public ActionStepsBase(ITransport transport, ManualResetEvent autoEvent)
        {
            Transport = transport;
            AutoEvent = autoEvent;
        }


        protected bool Wait()
        {
            //
            if (Transport.TransportType == TransportTypes.CSD || Transport.TransportType == TransportTypes.Direct)
            {
                AutoEvent.WaitOne();
                AutoEvent.Reset();
            }

            if (Transport.IsLostConnectionRaised)
            {
                if (Transport.CurrentCommand.CanBeSkip == CanBeSkip.Yes)
                {
                    return false;
                }

                throw new LostConnectionException(Transport.CurrentCommand.ErrorMessage);
            }
            if (Transport.CurrentCommand.IsGenerateErrorResponseException)
            {
                if (Transport.CurrentErrorCode != ErrorCode.None)
                {
                    throw new ErrorDeviceResponseException(string.Format(DeviceMessages.RequestDumpOnError,
                        Transport.CurrentCommand.CommandName, Transport.ErrorText, Transport.CurrentRequestDump));
                }
            }
            
            return true;
        }
    }
}

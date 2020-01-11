using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Linq;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST
{
    public sealed class VISTConnection : DeviceTransport
    {
        private readonly MeasurementDevice _device;

        public VISTConnection(MeasurementDevice device, AccessPointInfo accessPointInfo, ManualResetEvent autoEvent,
            LogHelper logHelper) : base(device, accessPointInfo, autoEvent, logHelper)
        {
            _device = device;
        }

        protected override void FirstIteration(byte[] buffer)
        {
            if (buffer.All(p => p == 0x00))
            {
                LogHelper.CreateLog(DeviceMessages.NullBytesPackage, ErrorType.ErrorDeviceResponse);
                CurrentErrorCode = ErrorCode.NullBytesPackage;
                State.TotalBytes = 6;
            }
            else if (buffer[0] != (byte)_device.NetworkAddress)
            {
                LogHelper.CreateLog(DeviceMessages.WrongNetAddress, ErrorType.ErrorDeviceResponse);
                CurrentErrorCode = ErrorCode.WrongNetworkAddress;
            }
            else
            {
                if (CurrentCommand.CommandType == CommandType.Read && buffer[1] == 0x83)
                {
                    CurrentErrorCode = ErrorCode.ReadError;
                }
                else if (CurrentCommand.CommandType == CommandType.Write && buffer[1] == 0x90)
                {
                    CurrentErrorCode = ErrorCode.WriteError;
                }

                if (CurrentErrorCode == ErrorCode.None && (buffer[1] == 0x03 || buffer[1] == 0x04 || buffer[1] == 0x14))
                {
                    if (CurrentCommand.ResponseLengthType == LengthType.Calculated)
                    {
                        // вычисляем общую длину пакета (5 = 3 байта вначале пакета + 2 байта контрольной суммы в конце)
                        State.TotalBytes = 5 + buffer[2];
                    }
                    else if (CurrentCommand.ResponseLengthType == LengthType.Fixed)
                    {
                        State.TotalBytes = CurrentCommand.ResponseLength;
                    }
                }
                else
                {
                    State.TotalBytes = 5;
                }
            }

            State.IsFirstIteration = false;
        }

        protected override bool VerifyCheckSum()
        {
            return Buffer.VerifyModbusCheckSum(State.TotalBytes);
        }

        protected override bool CheckNetworkAddress()
        {
            return Buffer[0] == (byte)_device.NetworkAddress;
        }
    }
}

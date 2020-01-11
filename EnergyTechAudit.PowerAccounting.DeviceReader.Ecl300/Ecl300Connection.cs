using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using System.Threading;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using ApI = EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.AccessPointInfo;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl300
{
    internal sealed class Ecl300Connection : DeviceTransport
    {
        private PortType _portType;
        private int _networkAddress;
        public Ecl300Connection(MeasurementDevice device, ApI accessPointInfo, ManualResetEvent autoEvent, LogHelper logHelper, PortType portType) :
            base(device, accessPointInfo, autoEvent, logHelper)
        {
            _portType = portType;
            _networkAddress = device.NetworkAddress;
        }

        protected override void FirstIteration(byte[] buffer)
        {
            if (_portType == PortType.RS232 || _portType == PortType.RS232Power)
            {
                if (buffer.Length < 5)
                {
                    return;
                }

                if (buffer.All(p => p == 0x00))
                {
                    LogHelper.CreateLog(DeviceMessages.NullBytesPackage, ErrorType.ErrorDeviceResponse);
                    CurrentErrorCode = Common.Types.ErrorCode.NullBytesPackage;
                }
                else if (CurrentCommand.CommandType == Common.Types.CommandType.Read && buffer[0] != (byte)Types.ErrorCode.NormalAnswer)
                {
                    switch (buffer[0])
                    {
                        case (byte)Types.ErrorCode.UnknownValue:
                            LogHelper.CreateLog(Ecl300Resources.UnknownValue, ErrorType.Ecl300ErrorResponse);
                            break;
                        case (byte)Types.ErrorCode.InvalidValueDate:
                            LogHelper.CreateLog(Ecl300Resources.InvalidValueDate, ErrorType.Ecl300ErrorResponse);
                            break;
                        case (byte)Types.ErrorCode.NonExistingCircuit:
                            LogHelper.CreateLog(Ecl300Resources.NonExistingCircuit, ErrorType.Ecl300ErrorResponse);
                            break;
                        case (byte)Types.ErrorCode.NonExistingMode:
                            LogHelper.CreateLog(Ecl300Resources.NonExistingMode, ErrorType.Ecl300ErrorResponse);
                            break;
                        case (byte)Types.ErrorCode.NonExistingPort:
                            LogHelper.CreateLog(Ecl300Resources.NonExistingPort, ErrorType.Ecl300ErrorResponse);
                            break;
                        case (byte)Types.ErrorCode.CommunicationError:
                            LogHelper.CreateLog(Ecl300Resources.CommunicationError, ErrorType.Ecl300ErrorResponse);
                            break;
                    }

                    CurrentErrorCode = Common.Types.ErrorCode.Ecl300ErrorResponse;
                }
                else if (CurrentCommand.CommandType == Common.Types.CommandType.Write)
                {
                    if (buffer[0] != 0x01 || buffer[1] != CurrentRequest[0] || buffer[2] != 0x00 || buffer[3] != 0x00)
                    {
                        CurrentErrorCode = Common.Types.ErrorCode.Ecl300WriteError;
                    }
                }

                State.TotalBytes = 5;

                State.IsFirstIteration = false;
            }
            else if (_portType == PortType.RS485_2Wire || _portType == PortType.RS485_4Wire)
            {
                if (buffer.Length < 3)
                {
                    return;
                }

                if (CurrentCommand.CommandType == CommandType.Read &&
                    (buffer[1] == ModbusFunction.ReadInputRegisters.WrongResponseCode ||
                     buffer[1] == ModbusFunction.ReadHoldingRegisters.WrongResponseCode))
                {
                    CurrentErrorCode = Common.Types.ErrorCode.ReadError;
                    State.TotalBytes = 5;
                    State.IsFirstIteration = false;
                    return;
                }

                if (CurrentErrorCode == Common.Types.ErrorCode.None)
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
                    State.TotalBytes = 6;
                }

                State.IsFirstIteration = false;
            }
        }

        protected override bool VerifyCheckSum()
        {
            if (_portType == PortType.RS232 || _portType == PortType.RS232Power)
            {
                var body = Buffer.Take(Buffer.Length - 1).ToArray();

                var calcCrc = body.Xor();

                return calcCrc == Buffer[Buffer.Length - 1];
            }
            else if (_portType == PortType.RS485_2Wire || _portType == PortType.RS485_4Wire)
            {
                return Buffer.VerifyModbusCheckSum(State.TotalBytes);
            }
            return false;
        }

        protected override bool CheckNetworkAddress()
        {
            if (_portType == PortType.RS232 || _portType == PortType.RS232Power)
            {
                return true;
            }
            else if (_portType == PortType.RS485_2Wire || _portType == PortType.RS485_4Wire)
            {
                return Buffer[0] == (byte)_networkAddress;
            }
            return false;
        }
    }
}

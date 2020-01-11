using System.Linq;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7
{
    /// <summary>
    /// Класс, обеспечивающий транспортную функцию при соединении с ТВ7
    /// </summary>
    internal sealed class Tv7Connection : DeviceTransport
    {
        private readonly MeasurementDevice _device;
        public ModbusMode ModbusMode;

        public Tv7Connection(MeasurementDevice device, AccessPointInfo accessPointInfo, ManualResetEvent autoEvent, LogHelper logHelper, ModbusMode modbusMode) :
            base(device, accessPointInfo, autoEvent, logHelper)
        {
            _device = device;
            ModbusMode = modbusMode;
        }

        /// <summary>
        /// Обрабатывает заголовок принятого пакета при первой итерации приёма данных
        /// </summary>
        /// <param name="buffer">Буфер данных, принятый от прибора</param>
        protected override void FirstIteration(byte[] buffer)
        {
            byte responseCmd = 0x00;

            if (ModbusMode == ModbusMode.RTU)
            {
                if (buffer.Length < 2)
                {
                    State.TotalBytes = 5;
                    return;
                }
                responseCmd = buffer[1];
            }
            if (ModbusMode == ModbusMode.ASCII)
            {
                responseCmd = (buffer.Skip(3).Take(2).ToArray()).AsciiToHex().First();
            }

            if ((CurrentCommand.CommandType == CommandType.Read && responseCmd == 0x83) || (CurrentCommand.CommandType == CommandType.Read && responseCmd == 0xC8) ||
                (CurrentCommand.CommandType == CommandType.Write && responseCmd == 0x90))
            {
                // TODO: обработка кода возникшей ошибки
                if (buffer[2] == 0x84) CurrentErrorCode = ErrorCode.ArchiveDataNotAvailable;
            }

            if (CurrentErrorCode == ErrorCode.None)
            {
                if (CurrentCommand.ResponseLengthType == LengthType.Calculated)
                {
                    if (CurrentCommand.CommandType == CommandType.Read)
                    {
                        if (ModbusMode == ModbusMode.ASCII)
                        {
                            var packageLength = (buffer.Skip(5).Take(2).ToArray()).AsciiToHex().First();
                            // вычисляем общую длину пакета (11 = 1 байт (0x3a вначале пакета) + 6 байтов (СА + CMD + Длина) + 2 байт (LRC) + 2 байта (0x0D, 0x0A - конец пакета))
                            State.TotalBytes = 11 + packageLength * 2;
                        }
                        else if (ModbusMode == ModbusMode.RTU)
                        {
                            // вычисляем общую длину пакета (5 = 3 байта в начале пакета + 2 байта контрольной суммы в конце)
                            State.TotalBytes = 5 + buffer[2];
                        }
                    }

                    else if (CurrentCommand.CommandType == CommandType.Write)
                    {
                        if (ModbusMode == ModbusMode.ASCII)
                        {
                            State.TotalBytes = 17;
                        }
                        else if (ModbusMode == ModbusMode.RTU)
                        {
                            State.TotalBytes = 8;
                        }
                    }
                }
                else if (CurrentCommand.ResponseLengthType == LengthType.Fixed)
                {
                    State.TotalBytes = CurrentCommand.ResponseLength;
                }
            }
            else
            {
                if (ModbusMode == ModbusMode.RTU)
                {
                    State.TotalBytes = 5;
                }
                else if (ModbusMode == ModbusMode.ASCII)
                {
                    State.TotalBytes = 11;
                }
            }

            if (ModbusMode == ModbusMode.RTU && State.BytesReaded < 3)
            {
                State.IsFirstIteration = true;
                return;
            }
            State.IsFirstIteration = false;
        }

        protected override bool VerifyCheckSum()
        {
            if (ModbusMode == ModbusMode.RTU)
            {
                return Buffer.VerifyModbusCheckSum(State.TotalBytes);
            }
            if (ModbusMode == ModbusMode.ASCII)
            {
                return ModbusProtocol.VerifyLrcCheckSum(Buffer);
            }
            return false;
        }

        protected override bool CheckNetworkAddress()
        {
            // первый заход на приём байтов (первые три байта как минимум должны прийти)
            return (ModbusMode == ModbusMode.RTU && Buffer[0] == (byte) _device.NetworkAddress) ||
                   (ModbusMode == ModbusMode.ASCII && (Buffer.Skip(1).Take(2).ToArray()).AsciiToHex().First() == (byte) _device.NetworkAddress);

        }

        protected override PackageCustomCheck PackageCustomCheck()
        {
            var packageCustomCheck = new PackageCustomCheck();

            if (ModbusMode == ModbusMode.ASCII)
            {
                try
                {
                    var bytes = ModbusProtocol.ConvertToRtuFormat(Buffer, ModbusMode);
                }
                catch
                {
                    State.TotalBytes = 10000;
                    packageCustomCheck.Result = false;
                    packageCustomCheck.ErrorMessage = DeviceMessages.Tv7WrongPackageFormat;
                }
            }
            return packageCustomCheck;
        }
    }
}



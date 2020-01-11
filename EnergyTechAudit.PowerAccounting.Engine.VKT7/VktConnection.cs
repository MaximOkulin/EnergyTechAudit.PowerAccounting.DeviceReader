using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7
{
    /// <summary>
    /// Класс, обеспечивающий транспортную функцию при соединении с ВКТ-7
    /// </summary>
    internal sealed class VktConnection : DeviceTransport
    {
        private readonly MeasurementDevice _device;
        private readonly Commands _commands;

        public VktConnection(MeasurementDevice device, AccessPointInfo accessPointInfo, ManualResetEvent autoEvent, LogHelper logHelper) :
            base(device, accessPointInfo, autoEvent, logHelper)
        {
            _device = device;
            _commands = new Commands();
        }

        /// <summary>
        /// Обрабатывает заголовок принятого пакета при первой итерации приёма данных
        /// </summary>
        /// <param name="buffer">Буфер данных, принятых от прибора</param>
        protected override void FirstIteration(byte[] buffer)
        {
            if (State.BytesReaded < 3)
            {
                State.IsFirstIteration = true;
                return;
            }

            if ((CurrentCommand.CommandType == CommandType.Read && buffer[1] == 0x83) ||
                (CurrentCommand.CommandType == CommandType.Write && buffer[1] == 0x90))
            {
                // ошибка: возникло исключение при обработке запроса
                // в третьем байте содержится код исключения
                int errorCode = buffer[2];

                if (CurrentCommand.CommandName == _commands.GetData.CommandName)
                {
                    if (errorCode == 0x05)
                    {
                        CurrentErrorCode = ErrorCode.MeasurementSchemaChanged;
                    }
                }
                else if (CurrentCommand.CommandName == _commands.SetArchiveDate.CommandName)
                {
                    if (errorCode == 0x03)
                    {
                        CurrentErrorCode = ErrorCode.ArchiveDataNotAvailable;
                    }
                }
                else if (CurrentCommand.CommandName == _commands.GetDateInterval.CommandName)
                {
                    if (errorCode == 0x03)
                    {
                        CurrentErrorCode = ErrorCode.VKT_GetDateIntervalError;
                    }
                }
                else if (CurrentCommand.CommandName == _commands.GetDiscreteOutputsStates.CommandName)
                {
                    if (errorCode == 0x07)
                    {
                        CurrentErrorCode = ErrorCode.DigitalOutputsDisabled;
                    }
                }
                else if (errorCode == 0x06)
                {
                    CurrentErrorCode = ErrorCode.UnsupportedCommand;
                }
            }

            if (CurrentErrorCode == ErrorCode.None)
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

        protected override bool VerifyCheckSum()
        {
            return Buffer.VerifyModbusCheckSum(State.TotalBytes);
        }

        protected override bool CheckNetworkAddress()
        {
            return Buffer[0] == (byte) _device.NetworkAddress;
        }
    }
}

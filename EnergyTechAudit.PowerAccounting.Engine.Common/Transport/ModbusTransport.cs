using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport
{
    public class ModbusTransport : DeviceTransport
    {
        private readonly int _networkAddress;

        public ModbusTransport(MeasurementDevice device, AccessPointInfo accessPointInfo, ManualResetEvent autoEvent, LogHelper logHelper)
            : base(device, accessPointInfo, autoEvent, logHelper)
        {
            _networkAddress = device.NetworkAddress;
        }

        /// <summary>
        /// Обрабатывает заголовок принятого пакета при первой итерации приёма данных
        /// </summary>
        /// <param name="buffer">Буфер данных, принятых от прибора</param>
        protected override void FirstIteration(byte[] buffer)
        {
            // если получено меньше трех байтов, нет смысла обрабатывать
            if (State.BytesReaded < 3)
            {
                State.IsFirstIteration = true;
                return;
            }

            // проверяем не возникла ли ошибка при выполнении Modbus-запроса
            if (CurrentCommand.CommandType == CommandType.Read && (buffer[1] == 0x83 || buffer[1] == 0x84))
            {
                // фиксируем ошибку обезличенно
                CurrentErrorCode = ErrorCode.Undefined;
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
                State.TotalBytes = 5;
            }

            State.IsFirstIteration = false;
        }

        protected override bool VerifyCheckSum()
        {
            return Buffer.VerifyModbusCrc16CheckSum(State.TotalBytes);
        }

        protected override bool CheckNetworkAddress()
        {
            return Buffer[0] == (byte)_networkAddress;
        }
    }
}

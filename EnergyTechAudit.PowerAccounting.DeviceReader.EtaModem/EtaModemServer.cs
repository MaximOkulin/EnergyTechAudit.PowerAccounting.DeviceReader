using EnergyTechAudit.PowerAccounting.DeviceReader.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem
{
    public class EtaModemServer : Modem
    {
        private readonly ActionSteps _actionSteps;

        public EtaModemServer(TcpClient tcpClient, MeasurementDevice device, LogHelper logHelper)
            : base(device, logHelper)
        {
            var localAutoEvent = new ManualResetEvent(false);
            Connection = new EtaModemConnection(tcpClient, localAutoEvent, logHelper);
            _actionSteps = new ActionSteps(Connection as EtaModemConnection, localAutoEvent, 254);
        }

        private bool IsOldSoftware(ushort softwareVersion)
        {
            return softwareVersion != 101;
        }

        private void PauseForOldSoftware(ushort softwareVersion, int sleepMilliseconds)
        {
            if (IsOldSoftware(softwareVersion))
            {
                Thread.Sleep(sleepMilliseconds);
            }
        }

        protected override void ConfigurationSteps()
        {
            // для устройства дискретного ввода "ЭнергоТехАудит" не надо ничего делать
            if (Device.DeviceId == (int)DeviceModel.EtaDiscrete)
            {
                SetSuccessfullyConfigured();
                return;
            }

            // текущая версия прошивки
            _actionSteps.ReadSoftware();
            var softwareVersion = BitConverter.ToUInt16(new byte[] { Connection.Buffer[4], Connection.Buffer[3] }, 0);

            var dictionaryCache = new DictionaryCache();
            uint baud = Convert.ToUInt32(dictionaryCache.GetBaudCode(Device.BaudId));

            _actionSteps.GetBaudRate();
            var buf = Connection.Buffer;
            var currentBaudRate = BitConverter.ToUInt32(new byte[] { buf[4], buf[3], buf[6], buf[5] }, 0);

            /*
            if (currentBaudRate == baud)
            {
                baud = currentBaudRate == 9600 ? (uint)4800 : 9600;
            }
            */

            bool isNeedToSaveSettings = false;
            if (currentBaudRate != baud)
            {
                PauseForOldSoftware(softwareVersion, 2500);
#if DEBUG
                Console.WriteLine(string.Format("Устанавливаю скорость : {0}", baud));
#endif
                _actionSteps.SetBaudRate(baud);

                PauseForOldSoftware(softwareVersion, 20000);
                isNeedToSaveSettings = true;
            }

            var dataBitCode = dictionaryCache.GetDataBitCode(Device.DataBitId);
            var parityCode = dictionaryCache.GetParityCode(Device.ParityId);
            var stopBitCode = dictionaryCache.GetStopBitCode(Device.StopBitId);


            var format = DataFormatDictionary.Formats.FirstOrDefault(p => p.DataBit.Equals(dataBitCode) && p.Parity.Equals(parityCode) && p.StopBit.Equals(stopBitCode));
            if (format != null)
            {
                _actionSteps.GetDataFormat();
                buf = Connection.Buffer;

                var currentDataFormat = BitConverter.ToInt16(new byte[] { buf[4], buf[3] }, 0);

                /*
                if (currentDataFormat == format.FormatValue)
                {
                    format.FormatValue = currentDataFormat == 6 ? (short)14 : (short)6;
                }
                */

                if (currentDataFormat != format.FormatValue)
                {
                    PauseForOldSoftware(softwareVersion, 2500);

#if DEBUG
                    Console.WriteLine("Устанавливаю формат данных: {0}-{1}-{2}", dataBitCode, parityCode, stopBitCode);
#endif
                    _actionSteps.SetDataFormat(format.FormatValue);
                    isNeedToSaveSettings = true;
                    PauseForOldSoftware(softwareVersion, 5000);
                }
            }           

            SetSuccessfullyConfigured();
        }
    }
}

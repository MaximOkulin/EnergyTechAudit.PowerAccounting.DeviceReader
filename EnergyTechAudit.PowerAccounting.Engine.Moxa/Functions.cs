using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Cache;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Moxa
{
    public class Functions
    {
        private DictionaryCache _dictionaryCache = new DictionaryCache();

        /// <summary>
        /// Возвращает пакет байтов для конфигурации настроек последовательного порта
        /// </summary>
        /// <param name="baud">Скорость</param>
        /// <param name="dataBit">Биты данных</param>
        /// <param name="stopBit">Стопоповые биты</param>
        /// <param name="parity">Четность</param>
        /// <returns></returns>
        public byte[] SetSettings(Baud baud, DataBit dataBit, StopBit stopBit, Parity parity)
        {
            var package = new byte[4];

            var dataBitCode = _dictionaryCache.GetDataBitCode((int)dataBit);
            var baudCode = _dictionaryCache.GetBaudCode((int)baud);
            var parityCode = _dictionaryCache.GetParityCode((int)parity);
            var stopBitCode = _dictionaryCache.GetStopBitCode((int)stopBit);

            package[0] = 0x10;
            package[1] = 0x02;
            package[2] = _moxaBaudRates[baudCode];
            package[3] = (byte)(_moxaDataBits[dataBitCode] |
                                _moxaStopBits[stopBitCode] |
                                _moxaParities[parityCode]);
            return package;
        }

        /// <summary>
        /// Возвращает пакет байтов для конфигурации настроек последовательного порта
        /// </summary>
        /// <param name="device">Измерительное устройство</param>
        /// <returns></returns>
        public byte[] SetSettings(MeasurementDevice device)
        {
            var package = new byte[4];

            var dataBitCode = _dictionaryCache.GetDataBitCode(device.DataBitId);
            var baudCode = _dictionaryCache.GetBaudCode(device.BaudId);
            var parityCode = _dictionaryCache.GetParityCode(device.ParityId);
            var stopBitCode = _dictionaryCache.GetStopBitCode(device.StopBitId);

            package[0] = 0x10;
            package[1] = 0x02;
            package[2] = _moxaBaudRates[baudCode];
            package[3] = (byte)(_moxaDataBits[dataBitCode] | 
                                _moxaStopBits[stopBitCode] |
                                _moxaParities[parityCode]);
            return package;
        }

        private Dictionary<string, byte> _moxaBaudRates
        {
            get
            {
                return new Dictionary<string, byte>
                {
                    { Resources.DictionariesCache.Number300, 0 },
                    { Resources.DictionariesCache.Number600, 1 },
                    { Resources.DictionariesCache.Number1200, 2 },
                    { Resources.DictionariesCache.Number2400, 3 },
                    { Resources.DictionariesCache.Number4800, 4 },
                    { Resources.DictionariesCache.Number7200, 5 },
                    { Resources.DictionariesCache.Number9600, 6 },
                    { Resources.DictionariesCache.Number19200, 7 },
                    { Resources.DictionariesCache.Number38400, 8 },
                    { Resources.DictionariesCache.Number57600, 9 },
                    { Resources.DictionariesCache.Number115200, 10 },
                    { Resources.DictionariesCache.Number230400, 11 },
                    { Resources.DictionariesCache.Number460800, 12 },
                    { Resources.DictionariesCache.Number921600, 13 }
                };
            }
        }

        private Dictionary<string, byte> _moxaDataBits
        {
            get
            {
                return new Dictionary<string, byte>
                {
                    { Resources.DictionariesCache.Eight, 3 },
                    { Resources.DictionariesCache.Seven, 2 },
                    { Resources.DictionariesCache.Six, 1 },
                    { Resources.DictionariesCache.Five, 0 }
                };
            }
        }

        private Dictionary<string, byte> _moxaStopBits
        {
            get
            {
                return new Dictionary<string, byte>
                {
                    { Resources.DictionariesCache.One, 1 },
                    { Resources.DictionariesCache.Two, 4 }
                };
            }
        }

        private Dictionary<string, byte> _moxaParities
        {
            get
            {
                return new Dictionary<string, byte>
                {
                    { Resources.DictionariesCache.Even, 8 },
                    { Resources.DictionariesCache.Odd, 16 },
                    { Resources.DictionariesCache.None, 0 },
                    { Resources.DictionariesCache.Empty, 0 }
                };
            }
        }
    }
}

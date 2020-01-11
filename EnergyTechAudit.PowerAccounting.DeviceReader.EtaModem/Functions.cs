using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using System;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.EtaModem
{
    public class Functions
    {
        private ModbusPackageHelperBase _packageHelper;
        private Commands _commands;

        public Functions(int networkAddress)
        {
            _packageHelper = new ModbusPackageHelperBase(networkAddress);
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает пакет байтов для установки скорости порта
        /// </summary>
        /// <param name="baudRate"></param>
        /// <returns></returns>
        public byte[] SetBaudRate(uint baudRate)
        {
            return _packageHelper.GetCommand(_commands.SetBaudRate,
                data =>
                {
                    var bytes = BitConverter.GetBytes(baudRate);
                    data.Data = new byte[] { bytes[1], bytes[0], bytes[3], bytes[2] };
                    data.RegistersCount = 2;
                });
        }

        /// <summary>
        /// Возвращает пакет байтов для установки формата кадра данных последовательного порта
        /// </summary>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public byte[] SetDataFormat(short dataFormat)
        {
            return _packageHelper.GetCommand(_commands.SetDataFormat,
                data =>
                {
                    data.Data = BitConverter.GetBytes(dataFormat).Reverse().ToArray();
                    data.RegistersCount = 1;
                });
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущей скорости порта
        /// </summary>
        /// <returns></returns>
        public byte[] GetBaudRate()
        {
            return _packageHelper.GetCommand(_commands.GetBaudRate);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения кадра данных последовательного порта
        /// </summary>
        /// <returns></returns>
        public byte[] GetDataFormat()
        {
            return _packageHelper.GetCommand(_commands.GetDataFormat);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущей версии прошивки
        /// </summary>
        /// <returns></returns>
        public byte[] ReadSoftware()
        {
            return _packageHelper.GetCommand(_commands.ReadSoftware);
        }

        /// <summary>
        /// Возвращает пакет байтов для записи настроек в модем
        /// </summary>
        /// <returns></returns>
        public byte[] SaveSettings()
        {
            return _packageHelper.GetCommand(_commands.SaveSettings,
                data =>
                {
                    data.Data = new byte[] { 0x00, 0x00 };
                    data.RegistersCount = 1;
                });
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения состояния текущих дискретных входов
        /// </summary>
        /// <returns></returns>
        public byte[] GetInputs()
        {
            return _packageHelper.GetCommand(_commands.GetInputs);
        }
    }
}

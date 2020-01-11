using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Ecl110.API
{
    internal sealed partial class Functions
    {
        private int _deviceAddress;
        private readonly ModbusPackageHelper _modbusPackageHelper;
        private readonly Commands _commands;

        public Functions(int deviceAddress)
        {
            _deviceAddress = deviceAddress;
            _modbusPackageHelper = new ModbusPackageHelper(deviceAddress);
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11200-11203
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11200_11203()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11200_11203);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущего времени прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetDeviceTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDeviceTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11228-11229
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11228_11229()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11228_11229);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11010-11014
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11010_11014()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11010_11014);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11019-11023
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11019_11023()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11019_11023);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11034-11036
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11034_11036()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11034_11036);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистра 11029
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11029()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11029);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистра 11051
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11051()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11051);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистра 11084
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11084()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11084);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистра 11140
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11140()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11140);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистра 11161
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11161()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11161);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11076-11077
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11076_11077()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11076_11077);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11173-11180
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11173_11180()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11173_11180);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11181-11186
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11181_11186()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11181_11186);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистра 11188
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11188()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11188);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11021-11022
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11021_11022()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11021_11022);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистра 11092
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11092()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11092);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11176-11177
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11176_11177()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11176_11177);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11183-11186
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11183_11186()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11183_11186);
        }
    }
}

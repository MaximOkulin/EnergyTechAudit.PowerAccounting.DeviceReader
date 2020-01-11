using System;
using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Modbus
{
    /// <summary>
    /// Базовый класс для формирования пакета байтов согласно протоколу Modbus
    /// </summary>
    public class ModbusPackageHelperBase
    {
        private readonly ModbusMode _modbusMode;
        private readonly int _deviceAddress;

        public ModbusMode ModbusMode
        {
            get
            {
                return _modbusMode;
            }
        }

        public int DeviceAddress
        {
            get
            {
                return _deviceAddress;
            }
        }

        public ModbusPackageHelperBase()
        {
            _modbusMode = ModbusMode.RTU;
        }

        public ModbusPackageHelperBase(ModbusMode modbusMode)
        {
            _modbusMode = modbusMode;
        }

        public ModbusPackageHelperBase(int deviceAddress)
        {
            _deviceAddress = deviceAddress;
            _modbusMode = ModbusMode.RTU;
        }

        /// <summary>
        /// Возвращает пакет в формате Modbus
        /// </summary>
        /// <param name="cmd">Команда</param>
        /// <param name="action">Действие по заполнению сегмента данных пакета</param>
        /// <returns></returns>
        public byte[] GetCommand(Command cmd, Action<ModbusFunctionData> action = null)
        {
            return GetCommand(_deviceAddress, cmd, action);
        }

        /// <summary>
        /// Возвращает пакет в формате Modbus
        /// </summary>
        /// <param name="networkAddress">Сетевой адрес устройства</param>
        /// <param name="cmd">Команда (чтение/запись)</param>
        /// <param name="action">Действие по заполнению сегмента данных пакета</param>
        public byte[] GetCommand(int networkAddress, Command cmd, Action<ModbusFunctionData> action = null)
        {
            if (cmd.CommandType == CommandType.Read)
            {
                return ReadCommand(networkAddress, cmd, cmd.RegistersCount);
            }
            if (cmd.CommandType == CommandType.Write)
            {
                return WriteCommand(networkAddress, cmd, action);
            }
            return null;
        }

        /// <summary>
        /// Возвращает пакет на чтение данных
        /// (должен быть переопределен в наследнике класса)
        /// </summary>
        /// <param name="networkAddress">Сетевой адрес устройства</param>
        /// <param name="cmd">Команда</param>
        /// <param name="registersCount">Количество регистров</param>
        protected virtual byte[] ReadCommand(int networkAddress, Command cmd, int registersCount = 0)
        {
            var command = ModbusProtocol.GetReadRequest(new ModbusFunctionData
            {
                DeviceAddress = networkAddress,
                Function = cmd.ModbusFunctionCode,
                StartingAddress = cmd.Code,
                RegistersCount = registersCount
            }, _modbusMode);

            return command;
        }

        /// <summary>
        /// Возвращает пакет данных для выполнения пользовательского запроса
        /// </summary>
        /// <param name="networkAddress">Сетевой адрес устройства</param>
        /// <param name="cmd">Команда</param>
        /// <param name="data">Данные (могут отсутствовать)</param>
        /// <returns></returns>
        public byte[] GetUserDefinedCommand(int networkAddress, Command cmd, byte[] data = null)
        {
            var command = ModbusProtocol.GetUserDefinedRequest(new ModbusFunctionData
            {
                DeviceAddress = networkAddress,
                Function = cmd.ModbusFunctionCode,
                StartingAddress = cmd.Code,
                Data = data
            });

            return command;
        }

        /// <summary>
        /// Возвращает пакет данных для получения информации об устройстве (0x11)
        /// </summary>
        /// <returns></returns>
        public byte[] GetReportSlaveId()
        {
            return ModbusProtocol.GetReportSlaveIdRequest(_deviceAddress);
        }

        /// <summary>
        /// Возвращает пакет данных для получения информации об устройстве (0x11)
        /// </summary>
        /// <param name="networkAddress"></param>
        /// <returns></returns>
        public byte[] GetReportSlaveId(int networkAddress)
        {
            return ModbusProtocol.GetReportSlaveIdRequest(networkAddress);
        }

        /// <summary>
        /// Возвращает пакет данных для чтения файловой записи (0x14)
        /// </summary>
        /// <param name="networkAddress"></param>
        /// <param name="subReqs"></param>
        /// <returns></returns>
        public byte[] GetReadFileRecordRequest(int networkAddress, List<SubReq> subReqs)
        {
            return ModbusProtocol.GetReadFileRecordRequest(networkAddress, subReqs);
        }

        /// <summary>
        /// Возвращает пакет на запись данных (стандартный)
        /// (должен быть переопределен в наследнике класса, если прибор реализует неправильный Modbus)
        /// </summary>
        /// <param name="networkAddress">Сетевой адрес устройства</param>
        /// <param name="cmd">Команда</param>
        /// <param name="action">Действие по заполнению данных пакета</param>
        protected virtual byte[] WriteCommand(int networkAddress, Command cmd, Action<ModbusFunctionData> action = null)
        {
            var functionData = new ModbusFunctionData
            {
                DeviceAddress = networkAddress,
                Function = cmd.ModbusFunctionCode,
                StartingAddress = cmd.Code,
                RegistersCount = cmd.RegistersCount
            };

            if (action != null)
            {
                action(functionData);
            }

            var command = ModbusProtocol.GetWriteRequest(functionData, _modbusMode);

            return command;
        }
    }
}

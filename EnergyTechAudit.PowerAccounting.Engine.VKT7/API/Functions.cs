using System;
using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Helpers;


namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API
{
    /// <summary>
    /// Класс, реализующий API-функции ВКТ-7
    /// </summary>
    internal sealed class Functions
    {
        private readonly int _deviceAddress;
        private readonly ModbusPackageHelper _modbusPackageHelper;
        private readonly Commands _commands;

        public Functions(int deviceAddress)
        {
            _deviceAddress = deviceAddress;
            _modbusPackageHelper = new ModbusPackageHelper();
            _commands = new Commands();
        }

        public byte[] GetTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTime);
        }

        public byte[] StartSession()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.StartSession,
                data =>
                {
                    // заполняем специфичное тело запроса для команды "Начало сеанса связи"
                    data.ArbitraryData = new byte[] { 0xCC, 0x80, 0x00, 0x00, 0x00 };
                });
        }

        public byte[] GetActiveElementsList()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetActiveElementsList);
        }

        public byte[] GetDeviceIdentifier()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDeviceIdentifier);
        }

        public byte[] SetValueTypes(ValueTypes valueType)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetValueTypes,
                data =>
                {
                    data.Data = new byte[] { Convert.ToByte((int)valueType), 0x00 };
                });
        }

        public byte[] SetPropertiesElementsList()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPropertiesElementsList,
                data =>
                {
                    var dataBytes = new List<byte>();

                    foreach (var property in Properties.List)
                    {
                        // добавляем адрес свойства
                        dataBytes.AddRange(new Byte[] { Convert.ToByte(property.Code), 0x00, 0x00, 0x40 });
                        // добавляем размер свойства
                        dataBytes.AddRange(new byte[] { Convert.ToByte((int)property.PropertyType), 0x00 });
                    }
                    data.Data = dataBytes.ToArray();
                });
        }

        public byte[] GetData()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetData);
        }

        public byte[] GetDateInterval()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDateInterval);
        }

        public byte[] GetActiveDBNumber()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetActiveDBNumber);
        }

        public byte[] GetMeasurementSchemaNumberTB1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMeasurementSchemaNumberTB1);
        }

        public byte[] GetMeasurementSchemaNumberTB2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMeasurementSchemaNumberTB2);
        }

        public byte[] SetReadElementsList(Dictionary<Parameter, int> parametersToRead)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetReadElementsList,
                data =>
                {
                    var dataBytes = new List<byte>();

                    foreach (var param in parametersToRead)
                    {
                        // добавляем адрес параметра
                        dataBytes.AddRange(new byte[] { Convert.ToByte(param.Key.Id), 0x00, 0x00, 0x40 });
                        // добавляем размер параметра
                        dataBytes.AddRange(new byte[] { Convert.ToByte(param.Value), 0x00 });
                    }

                    data.Data = dataBytes.ToArray();
                });
        }

        public byte[] SetArchiveDate(DateTime dateTime)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetArchiveDate,
                data =>
                {
                    data.Data = new byte[4]
                    {
                        Convert.ToByte(dateTime.Day),
                        Convert.ToByte(dateTime.Month),
                        Convert.ToByte(Convert.ToInt32(dateTime.ToString("yy"))),
                        Convert.ToByte(dateTime.Hour)
                    };
                });
        }

        public byte[] GetServiceInformation()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetServiceInformation);
        }

        public byte[] GetDiscreteOutputsStates()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDiscreteOutputsStates);
        }
    }
}

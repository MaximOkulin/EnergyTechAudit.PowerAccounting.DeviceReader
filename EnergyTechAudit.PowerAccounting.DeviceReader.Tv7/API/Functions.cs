using System;
using System.Collections.Generic;
using System.Linq;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Extensions;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.API
{
    /// <summary>
    /// Класс, реализующий API-функции ТВ7
    /// </summary>
    internal sealed class Functions
    {
        private readonly int _deviceAddress;
        private readonly ModbusPackageHelper _modbusPackageHelper;
        private readonly Commands _commands;

        public Functions(int deviceAddress, ModbusMode modbusMode)
        {
            _deviceAddress = deviceAddress;
            _modbusPackageHelper = new ModbusPackageHelper(modbusMode);
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает пакет байтов для получения серийного номера прибора
        /// </summary>
        public byte[] GetFactoryNumber()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFactoryNumber);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения информации об устройстве
        /// </summary>
        public byte[] GetDeviceInfo()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDeviceInfo);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущего приборного времени
        /// </summary>
        public byte[] GetDeviceTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDeviceTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных температур и давлений
        /// </summary>
        public byte[] GetInstantTemperaturesAndPressures()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantTemperaturesAndPressures);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных температур и давлений (новая прошивка)
        /// </summary>
        public byte[] GetInstantTemperaturesAndPressuresNewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantTemperaturesAndPressuresNewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных объемных и массовых расходов
        /// </summary>
        public byte[] GetInstantFlows()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantFlows);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных объемных и массовых расходов (новая прошивка)
        /// </summary>
        public byte[] GetInstantFlowsNewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantFlowsNewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных тепловых поток и энтальпий по трубопроводам
        /// </summary>
        public byte[] GetInstantThermalPowersAndEnthalpiesPipes()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantThermalPowersAndEnthalpiesPipes);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных тепловых поток и энтальпий по трубопроводам (новая прошивка)
        /// </summary>
        public byte[] GetInstantThermalPowersAndEnthalpiesPipesNewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantThermalPowersAndEnthalpiesPipesNewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных тепловых потоков, энтальпий и расхода по доп.каналу
        /// </summary>
        public byte[] GetInstantThermalPowersAndEnthalpiesHeatInput()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress,
                _commands.GetInstantThermalPowersAndEnthalpiesHeatInput);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения мгновенных значений температур и давлений по тепловым вводам
        /// </summary>
        public byte[] GetInstantHeatInputParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantHeatInputParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по трубе 1 ТВ1
        /// </summary>
        public byte[] GetFinalInstantTv1Pipe1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv1Pipe1);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по трубе 2 ТВ1
        /// </summary>
        public byte[] GetFinalInstantTv1Pipe2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv1Pipe2);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по трубе 3 ТВ1
        /// </summary>
        public byte[] GetFinalInstantTv1Pipe3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv1Pipe3);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по трубе 1 ТВ2
        /// </summary>
        public byte[] GetFinalInstantTv2Pipe1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv2Pipe1);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по трубе 2 ТВ2
        /// </summary>
        public byte[] GetFinalInstantTv2Pipe2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv2Pipe2);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по трубе 3 ТВ2
        /// </summary>
        public byte[] GetFinalInstantTv2Pipe3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv2Pipe3);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по ТВ1
        /// </summary>
        public byte[] GetFinalInstantTv1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv1);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения текущих итоговых по ТВ2
        /// </summary>
        public byte[] GetFinalInstantTv2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantTv2);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения отчетного времени
        /// </summary>
        public byte[] GetReportingTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetReportingTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для получения информации о датах начала/конца архивов
        /// </summary>
        public byte[] GetArchiveDatesInfo()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetArchiveDatesInfo);
        }

        /// <summary>
        /// Возвращает пакет байтов для установки даты и типа архива (часовой, суточный, месячный и итоговый)
        /// </summary>
        public byte[] SetArchiveDate(DateTime dateTime, PeriodType tv7PeriodType)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetArchiveDate,
                data =>
                {
                    data.Data = new byte[10]
                    {
                        Convert.ToByte(dateTime.Month), // месяц (старший байт)
                        Convert.ToByte(dateTime.Day), // день (младший байт)
                        Convert.ToByte(dateTime.Hour), // час (старший байт)
                        Convert.ToByte(Convert.ToInt32(dateTime.ToString("yy"))), // год (младший байт)
                        Convert.ToByte(dateTime.Second), // секунда (старший байт)
                        Convert.ToByte(dateTime.Minute), // минута (младший байт)
                        0x00, 
                        Convert.ToByte((int)tv7PeriodType), // тип архива
                        0x00,
                        0x00 // номер записи
                    };
                });
        }

        /// <summary>
        /// Возвращает пакет байтов для ускоренного чтения архивной записи
        /// </summary>
        /// <param name="dateTime">Время архива</param>
        /// <param name="tv7PeriodType">Период архива</param>
        /// <returns></returns>
        public byte[] SpeedReadArchive(DateTime dateTime, PeriodType tv7PeriodType)
        {
            var package = new List<byte>();
            package.Add((byte)_deviceAddress);
            package.Add(0x48);
            package.Add(0x0a); // адрес для чтения 2740
            package.Add(0xb4); // адрес для чтения 2740
            package.Add(0x00); // количество регистров для чтения 88
            package.Add(0x58); // количество регистров для чтения 88
            package.Add(0x00); // адрес для записи 99
            package.Add(0x63); // адрес для записи 99
            package.Add(0x00); // количество регистров для записи 5
            package.Add(0x05); // количество регистров для записи 5
            package.Add(0x00); // количество записываемых байтов 10
            package.Add(0x0a); // количество записываемых байтов 10

            var transactBytes = new byte[2];
            new Random().NextBytes(transactBytes);

            package.AddRange(transactBytes);

            package.Add(Convert.ToByte(dateTime.Month)); // месяц (старший байт)
            package.Add(Convert.ToByte(dateTime.Day)); // день (младший байт)
            package.Add(Convert.ToByte(dateTime.Hour)); // час (старший байт)
            package.Add(Convert.ToByte(Convert.ToInt32(dateTime.ToString("yy")))); // год (младший байт)                 
            package.Add(Convert.ToByte(dateTime.Second)); // секунда (старший байт)
            package.Add(Convert.ToByte(dateTime.Minute)); // минута (младший байт)                   
            package.Add(0x00);
            package.Add(Convert.ToByte((int)tv7PeriodType)); // тип архива  
            package.Add(0x00);
            package.Add(0x00); // номер записи

            if (_modbusPackageHelper.ModbusMode == ModbusMode.RTU)
            {
                package.AddRange(package.ToArray().Crc16());
            }
            else if (_modbusPackageHelper.ModbusMode == ModbusMode.ASCII)
            {
                package = ModbusProtocol.PrepareAsciiPackage(package);
            }

            return package.ToArray();
        }

        /// <summary>
        /// Возвращает пакет байтов для ускоренного чтения итоговой архивной записи
        /// </summary>
        /// <param name="dateTime">Время архива</param>
        /// <param name="tv7PeriodType">Период архива</param>
        /// <returns></returns>
        public byte[] SpeedReadFinalArchive(DateTime dateTime)
        {
            var package = new List<byte>();
            package.Add((byte)_deviceAddress);
            package.Add(0x48);
            package.Add(0x0b); // адрес для чтения 2868
            package.Add(0x34); // адрес для чтения 2868
            package.Add(0x00); // количество регистров для чтения 100
            package.Add(0x64); // количество регистров для чтения 100
            package.Add(0x00); // адрес для записи 99
            package.Add(0x63); // адрес для записи 99
            package.Add(0x00); // количество регистров для записи 5
            package.Add(0x05); // количество регистров для записи 5
            package.Add(0x00); // количество записываемых байтов 10
            package.Add(0x0a); // количество записываемых байтов 10

            var transactBytes = new byte[2];
            new Random().NextBytes(transactBytes);

            package.AddRange(transactBytes);

            package.Add(Convert.ToByte(dateTime.Month)); // месяц (старший байт)
            package.Add(Convert.ToByte(dateTime.Day)); // день (младший байт)
            package.Add(Convert.ToByte(dateTime.Hour)); // час (старший байт)
            package.Add(Convert.ToByte(Convert.ToInt32(dateTime.ToString("yy")))); // год (младший байт)                 
            package.Add(Convert.ToByte(dateTime.Second)); // секунда (старший байт)
            package.Add(Convert.ToByte(dateTime.Minute)); // минута (младший байт)                   
            package.Add(0x00);
            package.Add(0x03); // тип архива (итоговый)
            package.Add(0x00);
            package.Add(0x00); // номер записи

            if (_modbusPackageHelper.ModbusMode == ModbusMode.RTU)
            {
                package.AddRange(package.ToArray().Crc16());
            }
            else if (_modbusPackageHelper.ModbusMode == ModbusMode.ASCII)
            {
                package = ModbusProtocol.PrepareAsciiPackage(package);
            }

            return package.ToArray();
        }

        /// <summary>
        /// Возвращает пакет байтов для установки номера записи асинхронного архива (АИБД, ААС, АД)
        /// </summary>
        /// <param name="index">Индекс записи</param>
        public byte[] SetAsyncArchiveIndex(int index)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAsyncArchiveIndex,
                data =>
                {
                    data.Data = BitConverter.GetBytes(Convert.ToInt16(index)).Reverse().ToArray();
                });
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения даты архивной записи
        /// </summary>
        public byte[] ReadArchiveTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchiveTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по трубе 1
        /// </summary>
        public byte[] ReadArchivePipe1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchivePipe1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по трубе 2
        /// </summary>
        public byte[] ReadArchivePipe2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchivePipe2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по трубе 3
        /// </summary>
        public byte[] ReadArchivePipe3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchivePipe3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по трубе 4
        /// </summary>
        public byte[] ReadArchivePipe4()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchivePipe4);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по трубе 5
        /// </summary>
        public byte[] ReadArchivePipe5()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchivePipe5);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по трубе 6
        /// </summary>
        public byte[] ReadArchivePipe6()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchivePipe6);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по тепловому вводу 1
        /// </summary>
        public byte[] ReadArchiveHeatInput1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchiveHeatInput1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архива по тепловому вводу 2
        /// </summary>
        public byte[] ReadArchiveHeatInput2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchiveHeatInput2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущего итогового значения по доп. параметру
        /// </summary>
        public byte[] GetFinalInstantAdditionalParameter()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantAdditionalParameter);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архивного значения под доп. параметру
        /// </summary>
        public byte[] ReadArchiveAdditionalParameter()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadArchiveAdditionalParameter);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения даты итоговой архивной записи
        /// </summary>
        public byte[] ReadFinalArchiveTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchiveTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по трубе 1
        /// </summary>
        public byte[] ReadFinalArchivePipe1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchivePipe1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по трубе 2
        /// </summary>
        public byte[] ReadFinalArchivePipe2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchivePipe2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по трубе 3
        /// </summary>
        public byte[] ReadFinalArchivePipe3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchivePipe3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по трубе 4
        /// </summary>
        public byte[] ReadFinalArchivePipe4()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchivePipe4);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по трубе 5
        /// </summary>
        public byte[] ReadFinalArchivePipe5()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchivePipe5);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по трубе 6
        /// </summary>
        public byte[] ReadFinalArchivePipe6()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchivePipe6);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по тепловому вводу 1
        /// </summary>
        public byte[] ReadFinalArchiveHeatInput1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchiveHeatInput1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архива по тепловому вводу 2
        /// </summary>
        public byte[] ReadFinalArchiveHeatInput2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchiveHeatInput2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения итогового архивного значения по доп. параметру
        /// </summary>
        public byte[] ReadFinalArchiveAdditionalParameter()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadFinalArchiveAdditionalParameter);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения информации об архивах изменений БД (АИБД)
        /// </summary>
        public byte[] ReadDatabaseChangesArchivesInfo()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadDatabaseChangesArchivesInfo);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения информации об архивах событий (ААС)
        /// </summary>
        public byte[] ReadEventsArchivesInfo()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadEventsArchivesInfo);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения информации о диагностическом архиве (АД)
        /// </summary>
        public byte[] ReadDiagnosticArchivesInfo()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadDiagnosticArchivesInfo);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архивной записи изменений базы данных
        /// </summary>
        public byte[] ReadDatabaseChangesArchive()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadDatabaseChangesArchive);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения записи архива событий
        /// </summary>
        public byte[] ReadEventsArchive()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadEventsArchive);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения записи диагностического архива
        /// </summary>
        public byte[] ReadDiagnosticArchive()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.ReadDiagnosticArchive);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения системных настроек
        /// </summary>
        public byte[] GetSystemSettings()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSystemSettings);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения системных настроек (новая прошивка)
        /// </summary>
        public byte[] GetSystemSettingsNewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSystemSettingsNewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения активной БД
        /// </summary>
        /// <returns></returns>
        public byte[] GetActiveDatabase()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetActiveDatabase);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 0-2) БД1
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db1_0_2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db1_0_2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 0-2) БД1 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db1_0_2NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db1_0_2NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 3-5) БД1
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db1_3_5()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db1_3_5);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 3-5) БД1 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db1_3_5NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db1_3_5NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, труба 6) БД1
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipe_Db1_6()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipe_Db1_6);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, труба 6) БД1 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipe_Db1_6NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipe_Db1_6NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 0-2) БД2
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db2_0_2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db2_0_2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 0-2) БД2 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db2_0_2NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db2_0_2NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 3-5) БД2
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db2_3_5()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db2_3_5);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, трубы 3-5) БД2 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipes_Db2_3_5NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipes_Db2_3_5NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, труба 6) БД2
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipe_Db2_6()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipe_Db2_6);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек труб (контроль, труба 6) БД2 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetPipesSettingsControlPipe_Db2_6NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPipesSettingsControlPipe_Db2_6NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек тепловых вводов БД1
        /// </summary>
        /// <returns></returns>
        public byte[] GetTvSettings_Db1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTvSettings_Db1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек тепловых вводов БД1 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetTvSettings_Db1NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTvSettings_Db1NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек тепловых вводов БД2
        /// </summary>
        /// <returns></returns>
        public byte[] GetTvSettings_Db2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTvSettings_Db2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек тепловых вводов БД2 (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetTvSettings_Db2NewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTvSettings_Db2NewFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек дополнительного импульсного входа
        /// </summary>
        /// <returns></returns>
        public byte[] GetImpulseInputSettings()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetImpulseInputSettings);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек дополнительного импульсного входа (новая прошивка)
        /// </summary>
        /// <returns></returns>
        public byte[] GetImpulseInputSettingsNewFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetImpulseInputSettingsNewFirmware);
        }
    }
}

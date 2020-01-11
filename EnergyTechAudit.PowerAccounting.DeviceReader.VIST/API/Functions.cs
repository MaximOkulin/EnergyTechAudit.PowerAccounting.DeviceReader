using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus.Types;
using System;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.API
{
    internal sealed class Functions
    {
        private int _deviceAddress;
        private readonly ModbusPackageHelperBase _modbusPackageHelper;
        private readonly Commands _commands;

        public Functions(int deviceAddress)
        {
            _deviceAddress = deviceAddress;
            _modbusPackageHelper = new ModbusPackageHelperBase(deviceAddress);
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения версии программного обеспечения прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFirmware); 
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения заводского номера прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetFactoryNumber()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFactoryNumber);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения отчетного времени прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetReportingTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetReportingTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения структуры изменяемых параметров т/с №1 прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetSettingsHeatSys1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSettingsHeatSys1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения структуры изменяемых параметров т/с №2 прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetSettingsHeatSys2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSettingsHeatSys2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения структуры изменяемых параметров т/с №3 прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetSettingsHeatSys3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSettingsHeatSys3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения числа теплосистем в приборе
        /// </summary>
        /// <returns></returns>
        public byte[] GetSystemsCount()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSystemsCount);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих даты и времени прибора
        /// </summary>
        /// <returns></returns>
        public byte[] GetDeviceTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDeviceTime);
        }
        
        /// <summary>
        /// Возвращает пакет байтов для чтения спецификации архивного файла теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetArchiveHeaderSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetArchiveHeaderSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения спецификации архивного файла теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetArchiveHeaderSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetArchiveHeaderSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения спецификации архивного файла теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetArchiveHeaderSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetArchiveHeaderSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения набора измеряемых текущих параметров теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantParamsSetSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantParamsSetSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения набора измеряемых текущих параметров теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantParamsSetSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantParamsSetSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения набора измеряемых текущих параметров теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantParamsSetSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantParamsSetSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения точности по расходу и тепловой мощности теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantParamsPrecisionsSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantParamsPrecisionsSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения точности по расходу и тепловой мощности теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantParamsPrecisionsSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantParamsPrecisionsSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения точности по расходу и тепловой мощности теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantParamsPrecisionsSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantParamsPrecisionsSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих температур теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantTemperaturesSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantTemperaturesSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих температур теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantTemperaturesSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantTemperaturesSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих температур теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantTemperaturesSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantTemperaturesSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих объемных расходов теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantVolumeFlowsSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantVolumeFlowsSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих объемных расходов теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantVolumeFlowsSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantVolumeFlowsSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих объемных расходов теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantVolumeFlowsSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantVolumeFlowsSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих массовых расходов теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantMassFlowsSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantMassFlowsSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих массовых расходов теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantMassFlowsSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantMassFlowsSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих массовых расходов теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantMassFlowsSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantMassFlowsSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих давлений теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantPressureSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantPressureSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих давлений теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantPressureSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantPressureSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущих давлений теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantPressureSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantPressureSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущей тепловой мощности теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantThermalPowerSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantThermalPowerSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущей тепловой мощности теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantThermalPowerSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantThermalPowerSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущей тепловой мощности теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetInstantThermalPowerSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInstantThermalPowerSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения набора накапливаемых текущих параметров теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetFinalInstantParamsSetSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantParamsSetSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения набора накапливаемых текущих параметров теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetFinalInstantParamsSetSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantParamsSetSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения набора накапливаемых текущих параметров теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetFinalInstantParamsSetSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantParamsSetSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения точности по объему и тепловой энергии теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetFinalInstantParamsPrecisionsSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantParamsPrecisionsSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения точности по объему и тепловой энергии теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetFinalInstantParamsPrecisionsSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantParamsPrecisionsSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения точности по объему и тепловой энергии теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetFinalInstantParamsPrecisionsSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFinalInstantParamsPrecisionsSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения объемов за текущий час теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetVolumesForHourSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetVolumesForHourSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения объемов за текущий час теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetVolumesForHourSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetVolumesForHourSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения объемов за текущий час теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetVolumesForHourSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetVolumesForHourSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения масс за текущий час теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetMassesForHourSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMassesForHourSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения масс за текущий час теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetMassesForHourSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMassesForHourSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения масс за текущий час теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetMassesForHourSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMassesForHourSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения тепловой энергии за текущий час теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetHeatForHourSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatForHourSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения тепловой энергии за текущий час теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetHeatForHourSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatForHourSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения тепловой энергии за текущий час теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetHeatForHourSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatForHourSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени наработки за текущий час теплосистемы №1
        /// </summary>
        /// <returns></returns>
        public byte[] GetTimeNormalForHourSystem1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTimeNormalForHourSystem1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени наработки за текущий час теплосистемы №2
        /// </summary>
        /// <returns></returns>
        public byte[] GetTimeNormalForHourSystem2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTimeNormalForHourSystem2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени наработки за текущий час теплосистемы №3
        /// </summary>
        /// <returns></returns>
        public byte[] GetTimeNormalForHourSystem3()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTimeNormalForHourSystem3);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения структуры заголовка архивного файла и текущих итоговых
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        /// <returns></returns>
        public byte[] GetArchiveStructureAndFinalInstantSystem(int systemNumber)
        {
            byte[] fileNumber = GetFileNumber(systemNumber);

            return _modbusPackageHelper.GetReadFileRecordRequest(_deviceAddress, new List<SubReq>
            {
                new SubReq
                {
                    FileNumber = fileNumber,
                    RecordLength = new byte[] { 0x00, 0x30 },
                    RecordNumber = new byte[] { 0x00, 0x00 }, // читаем нулевую запись архива (в ней структура заголовка архивного файла)
                    ReferenceType = 0x06
                }
            });
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения архивной записи по её индексу
        /// </summary>
        /// <param name="systemNumber"></param>
        /// <param name="recordNumber"></param>
        /// <param name="recordLength"></param>
        /// <returns></returns>
        public byte[] ReadArchiveByIndex(int systemNumber, ushort recordNumber, ushort recordLength)
        {
            byte[] fileNumberBytes = GetFileNumber(systemNumber);
            byte[] recordNumberBytes = BitConverter.GetBytes(recordNumber);
            Array.Reverse(recordNumberBytes);
            byte[] recordLengthBytes = BitConverter.GetBytes(recordLength);
            Array.Reverse(recordLengthBytes);

            return _modbusPackageHelper.GetReadFileRecordRequest(_deviceAddress, new List<SubReq>
            {
                new SubReq
                {
                    FileNumber = fileNumberBytes,
                    RecordLength = recordLengthBytes,
                    RecordNumber = recordNumberBytes,
                    ReferenceType = 0x06
                }
            });
        }

        private byte[] GetFileNumber(int systemNumber)
        {
            return systemNumber == 1 ? new byte[] { 0x00, 0x00 } : systemNumber == 2 ? new byte[] { 0x00, 0x01 } : new byte[] { 0x00, 0x02 };
        }
    }
}

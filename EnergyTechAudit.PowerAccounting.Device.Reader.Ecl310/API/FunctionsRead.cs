using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl.Helpers;
using EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Helpers;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API
{
    /// <summary>
    /// Класс, реализующий API-функции регулятора Danfoss ECL 210/310
    /// </summary>
    internal sealed partial class Functions
    {
        private int _deviceAddress;
        private readonly ModbusPackageHelper _modbusPackageHelper;
        private readonly Commands _commands;

        public Functions(int deviceAddress)
        {
            _deviceAddress = deviceAddress;
            _modbusPackageHelper = new ModbusPackageHelper();
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения префикса приложения
        /// (PNU 2060)
        /// </summary>
        public byte[] GetApplicationPrefix()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetApplicationPrefix);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения типа приложения
        /// (PNU 2061)
        /// </summary>
        public byte[] GetApplicationType()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetApplicationType);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения подтипа приложения
        /// (PNU 2062)
        /// </summary>
        public byte[] GetApplicationSubType()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetApplicationSubType);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения даты производства регулятора
        /// (PNU 2099)
        /// </summary>
        public byte[] GetManufacturingDate()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetManufacturingDate);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения заводского номера прибора
        /// (PNU 8)
        /// </summary>
        public byte[] GetFactoryNumber()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFactoryNumber);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения номера аппаратной версии контроллера
        /// (PNU 34)
        /// </summary>
        public byte[] GetHardwareVersion()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHardwareVersion);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения версии программного обеспечения контроллера
        /// (PNU 35)
        /// </summary>
        public byte[] GetFirmware()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFirmware);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчиков
        /// (PNU 10201-10212)
        /// </summary>
        public byte[] GetSensorsValues()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensorsValues);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значения датчика S1 (PNU 10201)
        /// </summary>
        /// <returns></returns>
        public byte[] GetSensor1Value()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor1Value);
        }
        /// <summary>
        /// Возвращает пакет байтов для чтения значения датчика S2 (PNU 10202)
        /// </summary>
        /// <returns></returns>
        public byte[] GetSensor2Value()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor2Value);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значения датчика S3 (PNU 10203)
        /// </summary>
        /// <returns></returns>
        public byte[] GetSensor3Value()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor3Value);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значения датчика S5 (PNU 10205)
        /// </summary>
        /// <returns></returns>
        public byte[] GetSensor5Value()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor5Value);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений датчиков,
        /// присоединенных к модулю расширения ECA32 (PNU 10219-10222)
        /// </summary>
        public byte[] GetEca32SensorsValues()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetEca32SensorsValues);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения текущего времени регулятора
        /// (PNU 64045-64049)
        /// </summary>
        public byte[] GetDeviceTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDeviceTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения рассчитанного значения датчика 2
        /// (PNU 11252-11253)
        /// </summary>
        public byte[] GetSensor2CalculatedValueCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor2CalculatedValueCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения рассчитанного значения датчика 3
        /// (PNU 12253)
        /// </summary>
        public byte[] GetSensor3CalculatedValueCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor3CalculatedValueCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров контура 2
        /// (PNU 12176-12186)
        /// </summary>
        public byte[] Get2CircuitParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.Get2CircuitParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров внешнего входа, контур 1
        /// (PNU 11141-11142)
        /// </summary>
        public byte[] GetExternalInputParams()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetExternalInputParams);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров внешнего входа, контур 2
        /// (PNU 12141-12142)
        /// </summary>
        public byte[] GetExternalInputParamsCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetExternalInputParamsCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения рассчитанного значения датчика 5
        /// (PNU 11255)
        /// </summary>
        public byte[] GetSensor5CalculatedValueCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor5CalculatedValueCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения рассчитанного значения датчика 4
        /// (PNU 12254)
        /// </summary>
        public byte[] GetSensor4CalculatedValueCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor4CalculatedValueCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения рассчитанного значения датчика 6
        /// (PNU 12256)
        /// </summary>
        public byte[] GetSensor6CalculatedValueCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor6CalculatedValueCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения рассчитанного значения датчика 7
        /// (PNU 11257)
        /// </summary>
        public byte[] GetSensor7CalculatedValueCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSensor7CalculatedValueCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров контура 1
        /// (PNU 11177-11187)
        /// </summary>
        public byte[] GetHeatSystemParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения защиты двигателя
        /// (PNU 11174)
        /// </summary>
        public byte[] GetMotorProtection()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMotorProtection);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения приоритета ограничения температуры обратки
        /// (PNU 11085)
        /// </summary>
        public byte[] GetLimitReversePriority()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetLimitReversePriority);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения приоритета ограничения температуры обратки (контур 2)
        /// (PNU 12085)
        /// </summary>
        public byte[] GetLimitReversePriorityCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetLimitReversePriorityCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения защиты двигателя регулятора 2
        /// (PNU 12174)
        /// </summary>
        public byte[] GetMotorProtection2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMotorProtection2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения максимального выходного напряжения
        /// (PNU 12165)
        /// </summary>
        public byte[] GetMaxOutputVoltage()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMaxOutputVoltage);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимального выходного напряжения
        /// (PNU 12167)
        /// </summary>
        public byte[] GetMinOutputVoltage()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMinOutputVoltage);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров контура 1
        /// (PNU 11177-11178)
        /// </summary>
        public byte[] GetHeatSystemParameters2Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemParameters2Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров контура 1
        /// (PNU 11177)
        /// </summary>
        public byte[] GetHeatSystemParameters1Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemParameters1Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров контура 1
        /// (PNU 11177-11179)
        /// </summary>
        public byte[] GetHeatSystemParameters3Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemParameters3Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров контура 1
        /// (PNU 11180-11187)
        /// </summary>
        /// <returns></returns>
        public byte[] GetHeatSystemParameters8Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemParameters8Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемых температур контура 1
        /// (PNU 11180-11181)
        /// </summary>
        /// <returns></returns>
        public byte[] GetDesiredTemperaturesCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDesiredTemperaturesCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений температур системы отопления
        /// (PNU 11177-11181)
        /// </summary>
        public byte[] GetHeatSystemTemperatures()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemTemperatures);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения аварийной температуры замерзания S6
        /// (PNU 11676)
        /// </summary>
        public byte[] GetAccidentS6FreezingTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentS6FreezingTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения аварийной температуры замерзания S5
        /// (PNU 11656)
        /// </summary>
        public byte[] GetAccidentS5FreezingTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentS5FreezingTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров термостата замерзания
        /// (PNU 11616-11617)
        /// </summary>
        public byte[] GetFrostThermostatParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFrostThermostatParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров термостата пожаробезопасности
        /// (PNU 11636-11637)
        /// </summary>
        public byte[] GetFireSafetyThermostatParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFireSafetyThermostatParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров температурного монитора, контур 1
        /// (PNU 11147-11150)
        /// </summary>
        public byte[] GetTemperatureMonitorParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTemperatureMonitorParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров температурного монитора, контур 2
        /// (PNU 12147-12150)
        /// </summary>
        public byte[] GetTemperatureMonitorParametersCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTemperatureMonitorParametersCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значения использования внешнего сигнала в контуре 1
        /// (PNU 11084)
        /// </summary>
        public byte[] GetHsExternalSignal()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHsExternalSignal);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения ограничения температуры обратного трубопровода контура 1
        /// (PNU 11030)
        /// </summary>
        public byte[] GetHeatSystemLimitReverseTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemLimitReverseTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений коэффициентов системы отопления
        /// (PNU 11184-11187)
        /// </summary>
        public byte[] GetHeatSystemKoefficients()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemKoefficients);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений ограничений температуры подачи системы отопления
        /// (PNU 11300-11303)
        /// </summary>
        public byte[] GetHeatSystemSupplyTemperatureLimits()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemSupplyTemperatureLimits);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений ограничений температуры подачи ГВС
        /// (PNU 12300-12303)
        /// </summary>
        public byte[] GetHwsSupplyTemperatureLimits()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsSupplyTemperatureLimits);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений параметров насосов ГВС
        /// (PNU 12310-12314)
        /// </summary>
        public byte[] GetHwsPumpParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsPumpParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения коэффициентов ограничения комнатной температуры
        /// (PNU 11182-11183)
        /// </summary>
        public byte[] GetInfluenceRoomParams()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetInfluenceRoomParams);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения скорости адаптации комнатной температуры, контур 1
        /// (PNU 11015)
        /// </summary>
        public byte[] GetOptimizationTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения скорости адаптации комнатной температуры, контур 2
        /// (PNU 12015)
        /// </summary>
        public byte[] GetOptimizationTimeCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationTimeCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени профилактики насоса ГВС
        /// (PNU 12022)
        /// </summary>
        public byte[] GetHwsPumpTrainingTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsPumpTrainingTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения статусов 3 реле
        /// (PNU 4026-4028)
        /// </summary>
        public byte[] GetManualRelayStatuses3Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetManualRelayStatuses3Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения статусов 5 реле
        /// (PNU 4026-4030)
        /// </summary>
        public byte[] GetManualRelayStatuses5Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetManualRelayStatuses5Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения статусов 7 реле
        /// (PNU 4026-4032)
        /// </summary>
        public byte[] GetManualRelayStatuses7Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetManualRelayStatuses7Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения реверса
        /// (PNU 12171)
        /// </summary>
        public byte[] GetReverse()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetReverse);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени ожидания перед открытием клапана
        /// (PNU 11325)
        /// </summary>
        public byte[] GetHsWaitOpenValveTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHsWaitOpenValveTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени ожидания перед открытием клапана, контур 2
        /// (PNU 12325)
        /// </summary>
        public byte[] GetHwsWaitOpenValveTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsWaitOpenValveTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения типа входного сигнала давления
        /// (PNU 11327)
        /// </summary>
        public byte[] GetEcl310PressureInputSignalTypeId()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetEcl310PressureInputSignalTypeId);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения количества насосов
        /// (PNU 10326)
        /// </summary>
        public byte[] GetPumpCount()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPumpCount);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени оптимизации предельной безопасной температуры
        /// (PNU 11107)
        /// </summary>
        /// <returns></returns>
        public byte[] GetLimitFreezeOptimizationTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetLimitFreezeOptimizationTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температур второго контура
        /// (PNU 12177-12181)
        /// </summary>
        public byte[] GetHwsTemperatures()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsTemperatures);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров для обратного трубопровода контура 2 и пр.
        /// (PNU 12031-12037)
        /// </summary>
        public byte[] GetHwsReverseParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsReverseParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температурного графика контура 2
        /// (PNU 12400-12405)
        /// </summary>
        public byte[] GetHeatCurve2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatCurve2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров заполнения водой контура 2
        /// (PNU 12320-12323)
        /// </summary>
        public byte[] GetHwsWaterFillParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsWaterFillParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения типа входного сигнала давления контура 2
        /// (PNU 12327)
        /// </summary>
        public byte[] GetEcl310PressureInputSignalType2Id()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetEcl310PressureInputSignalType2Id);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемых температур горячей воды
        /// (PNU 12190-12191)
        /// </summary>
        public byte[] GetDesiredHotWaterTemperatures()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDesiredHotWaterTemperatures);
        }


        /// <summary>
        /// Возвращает пакет байтов для чтения параметров системы отопления 
        /// для обратного контура и пр. (PNU 11031-11037) 
        /// </summary>
        public byte[] GetHeatSystemReverseParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemReverseParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров системы отопления
        /// для обратного контура и пр. (PNU 11035-11037)
        /// </summary>
        public byte[] GetHeatSystemReverseParameters3Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemReverseParameters3Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения предельной температуры замерзания
        /// (PNU 11108)
        /// </summary>
        public byte[] GetLimitFreezeTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetLimitFreezeTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения минимального времени активации
        /// электропривода системы отопления (PNU 11189)
        /// </summary>
        public byte[] GetHeatSystemDriveActivationTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemDriveActivationTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения коэффициента максимального влияния ветра
        /// (PNU 11057)
        /// </summary>
        public byte[] GetHeatSystemMaxWindInfluence()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemMaxWindInfluence);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температурного графика
        /// (PNU 11400-11405)
        /// </summary>
        public byte[] GetHeatCurve()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatCurve);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения коэффициента разницы заданных комнатных температур
        /// (PNU 11027)
        /// </summary>
        public byte[] GetRoomTemperaturesDiff()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetRoomTemperaturesDiff);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры защиты от замерзания
        /// (PNU 11077)
        /// </summary>
        public byte[] GetFrostProtectionTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFrostProtectionTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения функции вентилятора
        /// (PNU 11137)
        /// </summary>
        public byte[] GetFanFunction()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFanFunction);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения фильтра ветра
        /// (PNU 11081)
        /// </summary>
        public byte[] GetHeatSystemWindFilter()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemWindFilter);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения настроек управления вентилятором
        /// (PNU 11086-11091)
        /// </summary>
        public byte[] GetFanParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFanParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения ограничения ветра
        /// (PNU 11099)
        /// </summary>
        public byte[] GetHeatSystemWindLimit()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemWindLimit);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений параметров насосов системы отопления
        /// (PNU 11310-11314)
        /// </summary>
        public byte[] GetHeatSystemPumpParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemPumpParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения нижнего значения максимальной границы контура 1 Y1
        /// (PNU 11303)
        /// </summary>
        public byte[] GetMinHsBorderFlowTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMinHsBorderFlowTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров компенсации контура 1
        /// (PNU 11060-11067)
        /// </summary>
        public byte[] GetCompensationParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetCompensationParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения верхнего значения максимальной границы контура 1 Y2
        /// (PNU 11301)
        /// </summary>
        public byte[] GetMaxHsBorderFlowTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMaxHsBorderFlowTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значения времени профилактики насоса системы отопления
        /// (PNU 11022)
        /// </summary>
        public byte[] GetHeatSystemPumpTrainingTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemPumpTrainingTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров заполнения водой системы отопления
        /// (PNU 11320-11323)
        /// </summary>
        public byte[] GetHeatSystemWaterFillParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemWaterFillParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров заполнения водой системы отопления (2 часть)
        /// (PNU 11325-11327)
        /// </summary>
        public byte[] GetHeatSystemWaterFillParameters2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatSystemWaterFillParameters2);
        }

        /// <summary>
        /// Возвращает значение предельной температур обратки ГВС
        /// (PNU 12030)
        /// </summary>
        public byte[] GetHwsLimitReverseTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsLimitReverseTemperature);
        }

        /// <summary>
        /// Возвращает значения мин/макс влияния обратки ГВС
        /// (PNU 12035-12037)
        /// </summary>
        public byte[] GetHwsMinMaxInfluenceReverse()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsMinMaxInfluenceReverse);
        }

        /// <summary>
        /// Возвращает значения мин/макс температур подачи ГВС
        /// (PNU 12177-12178)
        /// </summary>
        public byte[] GetHwsMinMaxFlowTemperatures()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsMinMaxFlowTemperatures);
        }

        /// <summary>
        /// Возвращает значения параметров ГВС
        /// (PNU 12184-12187)
        /// </summary>
        public byte[] GetHwsParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsParameters);
        }

        /// <summary>
        /// Возвращает значения параметров ГВС
        /// (PNU 12185-12187)
        /// </summary>
        /// <returns></returns>
        public byte[] GetHwsParameters3Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsParameters3Registers);
        }

        /// <summary>
        /// Возвращает минимальное время активации электропривода ГВС
        /// (PNU 12189)
        /// </summary>
        public byte[] GetHwsDriveActivationTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsDriveActivationTime);
        }

        /// <summary>
        /// Возвращает режимы работы контуров 
        /// (PNU 4201-4202)
        /// </summary>
        public byte[] GetOperatingModes()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOperatingModes);
        }

        /// <summary>
        /// Возвращает статусы работы контуров 
        /// (PNU 4211-4212)
        /// </summary>
        public byte[] GetOperatingStatuses()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOperatingStatuses);
        }

        /// <summary>
        /// Возвращает статус работы контура 1
        /// (PNU 4211)
        /// </summary>
        public byte[] GetOperatingStatus()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOperatingStatus);
        }

        /// <summary>
        /// Возвращает режим работы контура 1 
        /// (PNU 4201)
        /// </summary>
        public byte[] GetOperatingMode()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOperatingMode);
        }

        /// <summary>
        /// Возвращает статусы режимов ручного управления
        /// (PNU 4026-4027)
        /// </summary>
        public byte[] GetManualRelayStatuses()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetManualRelayStatuses);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров, связанных с работой
        /// датчика потока (PNU 12094-12097)
        /// </summary>
        public byte[] GetFlowSensorParameters()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowSensorParameters);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения заданной балансовой температуры
        /// (PNU 11008)
        /// </summary>
        public byte[] GetAdjustedBalanceTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAdjustedBalanceTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения коэффициента мертвой зоны
        /// (PNU 11009)
        /// </summary>
        public byte[] GetDeadBand()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetDeadBand);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения мин. влияния предельной безопасной температуры
        /// (PNU 11105)
        /// </summary>
        public byte[] GetMinLimitFreezeTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMinLimitFreezeTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения фильтра S4
        /// (PNU 10304)
        /// </summary>
        public byte[] GetS4Filter()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetS4Filter);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения адреса ECA
        /// (PNU 11010)
        /// </summary>
        public byte[] GetEcaAddressId()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetEcaAddressId);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения адреса ECA, контур 2
        /// (PNU 12010)
        /// </summary>
        public byte[] GetEcaAddressCircuit2Id()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetEcaAddressCircuit2Id);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага полного отключения, контур 1
        /// (PNU 11021)
        /// </summary>
        public byte[] GetBlackout()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetBlackout);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага полного отключения, контур 2
        /// (PNU 12021)
        /// </summary>
        public byte[] GetBlackoutCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetBlackoutCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения времени перехода между режимами
        /// (PNU 11082)
        /// </summary>
        public byte[] GetTransitionModeTime()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetTransitionModeTime);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры защиты от замерзания
        /// (PNU 11093)
        /// </summary>
        public byte[] GetFrostProtectionTemperature2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFrostProtectionTemperature2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага выбора компенсационной температуры
        /// (PNU 11140-11142)
        /// </summary>
        public byte[] GetSelectionCompensationTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSelectionCompensationTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага посылки заданной температуры
        /// (PNU 11500)
        /// </summary>
        public byte[] GetSendPredeterminedTemperature()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSendPredeterminedTemperature);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения смещения
        /// (PNU 11017)
        /// </summary>
        public byte[] GetOffset()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOffset);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения тренировки клапана, контур 1
        /// (PNU 11023)
        /// </summary>
        public byte[] GetFlapTrainingCurcuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlapTrainingCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения тренировки клапана, контур 2
        /// (PNU 12023)
        /// </summary>
        public byte[] GetFlapTrainingCurcuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlapTrainingCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения приоритета ГВС, контур 1
        /// (PNU 11052)
        /// </summary>
        public byte[] GetHwsPriorityCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsPriorityCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения приоритета ГВС, контур 2
        /// (PNU 12052)
        /// </summary>
        public byte[] GetHwsPriorityCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHwsPriorityCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры защиты от замерзания, контур 2
        /// (PNU 12077)
        /// </summary>
        public byte[] GetFrostProtectionTemperatureCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFrostProtectionTemperatureCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры тепловой нагрузки, контур 1
        /// (PNU 11078)
        /// </summary>
        public byte[] GetThermalLoadTemperatureCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetThermalLoadTemperatureCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры тепловой нагрузки, контур 2
        /// (PNU 12078)
        /// </summary>
        public byte[] GetThermalLoadTemperatureCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetThermalLoadTemperatureCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения требуемой температуры защиты от замерзания, контур 2
        /// (PNU 12093)
        /// </summary>
        public byte[] GetFrostProtectionTemperature2Circuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFrostProtectionTemperature2Circuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров ограничения расхода, контур 1
        /// (PNU 11112-11119)
        /// </summary>
        public byte[] GetFlowLimitationParams()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationParams);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения двух параметров ограничения расхода, контур 1
        /// (PNU 11112-11113)
        /// </summary>
        public byte[] GetFlowLimitation2Params()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitation2Params);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения пяти параметров ограничения расхода, контур 1
        /// (PNU 11115-11119)
        /// </summary>
        public byte[] GetFlowLimitation5Params()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitation5Params);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров ограничения расхода, контур 2
        /// (PNU 12112-12119)
        /// </summary>
        public byte[] GetFlowLimitationParamsCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationParamsCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения двух параметров ограничения расхода, контур 2
        /// (PNU 12112-12113)
        /// </summary>
        public byte[] GetFlowLimitation2ParamsCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitation2ParamsCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения пяти параметров ограничения расхода, контур 2
        /// (PNU 12115-12119)
        /// </summary>
        public byte[] GetFlowLimitation5ParamsCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitation5ParamsCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения типа входа ограничения расхода, контур 1
        /// (PNU 11109)
        /// </summary>
        public byte[] GetFlowLimitationInputTypeId()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationInputTypeId);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения типа входа ограничения расхода, контур 2
        /// (PNU 12109)
        /// </summary>
        public byte[] GetFlowLimitationInputTypeCircuit2Id()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationInputTypeCircuit2Id);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров оптимизации, контур 1
        /// (PNU 11011-11014)
        /// </summary>
        public byte[] GetOptimizationParams()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationParams);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров оптимизации, контур 2
        /// (PNU 12011-12014)
        /// </summary>
        public byte[] GetOptimizationParamsCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationParamsCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага задержки отключения, контур 1
        /// (PNU 11026)
        /// </summary>
        public byte[] GetOptimizationOffDelay()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationOffDelay);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага задержки отключения, контур 2
        /// (PNU 12026)
        /// </summary>
        public byte[] GetOptimizationOffDelayCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationOffDelayCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения базиса оптимизации, контур 1
        /// (PNU 11020)
        /// </summary>
        public byte[] GetOptimizationBasisId()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationBasisId);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения базиса оптимизации, контур 2
        /// (PNU 12020)
        /// </summary>
        public byte[] GetOptimizationBasisCircuit2Id()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetOptimizationBasisCircuit2Id);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения требуемых температур
        /// (PNU 11018-11019)
        /// </summary>
        public byte[] GetRequiredTemperatures()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetRequiredTemperatures);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров ограничения расхода
        /// (PNU 11111-11115)
        /// </summary>
        public byte[] GetFlowLimitationParams5Registers()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationParams5Registers);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров ограничения расхода, контур 2
        /// (PNU 12111-12115)
        /// </summary>
        public byte[] GetFlowLimitationParams5RegistersCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationParams5RegistersCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения нагрузки охлаждения, контур 1
        /// (PNU 11070)
        /// </summary>
        public byte[] GetCoolingLoadTemperatureCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetCoolingLoadTemperatureCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения температуры в режиме ожидания, контур 1
        /// (PNU 11092)
        /// </summary>
        public byte[] GetExpectationFlowTemperatureCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetExpectationFlowTemperatureCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения коэффициента параллельной работы, контур 1
        /// (PNU 11043)
        /// </summary>
        public byte[] GetParallelOperationCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetParallelOperationCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага автонастройки, контур 2
        /// (PNU 12173)
        /// </summary>
        public byte[] GetAutotuningCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAutotuningCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров сигнализации, контур 1
        /// (PNU 11079-11080)
        /// </summary>
        public byte[] GetSignalizationParamsCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetSignalizationParamsCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения аварийных границы давления, контур 1
        /// (PNU 11614-11615)
        /// </summary>
        public byte[] GetAccidentLimits()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentLimits);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения значений давления, контур 1
        /// (PNU 11607-11610)
        /// </summary>
        public byte[] GetPressureValues()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPressureValues);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага сброса аварии насосов, контур 1
        /// (PNU 11315)
        /// </summary>
        public byte[] GetAccidentPumpsCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentPumpsCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага сброса аварии насосов, контур 2
        /// (PNU 12315)
        /// </summary>
        public byte[] GetAccidentPumpsCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentPumpsCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага сброса аварии подпитки, контур 1
        /// (PNU 11324)
        /// </summary>
        public byte[] GetAccidentMakeupCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentMakeupCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения флага сброса аварии подпитки, контур 2
        /// (PNU 12324)
        /// </summary>
        public byte[] GetAccidentMakeupCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentMakeupCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров подпитки контура 1
        /// (PNU 11320-11327)
        /// </summary>
        public byte[] GetMakeupParametersCircuit1()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMakeupParametersCircuit1);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения параметров подпитки контура 2
        /// (PNU 12320-12327)
        /// </summary>
        public byte[] GetMakeupParametersCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetMakeupParametersCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения задержки аварии, контур 1
        /// (PNU 11617)
        /// </summary>
        public byte[] GetAccidentFrostThermostatDelay()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetAccidentFrostThermostatDelay);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения количества насосов, контур 1
        /// (PNU 11326)
        /// </summary>
        public byte[] GetHsPumpCount()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHsPumpCount);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения ограничения ГВС, контур 2
        /// (PNU 12111)
        /// </summary>
        public byte[] GetFlowLimitationLimitCircuit2()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationLimitCircuit2);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения единиц измерения, контур 2
        /// (PNU 12115)
        /// </summary>
        public byte[] GetFlowLimitationUnitDict2Circuit2Id()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetFlowLimitationUnitDict2Circuit2Id);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения угла наклона температурного графика, контур 1
        /// (PNU 11175)
        /// </summary>
        public byte[] GetHeatCurveAngle()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatCurveAngle);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения границы отключения отопления, контур 1
        /// (PNU 11179)
        /// </summary>
        public byte[] GetHeatingBorder()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetHeatingBorder);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения PNU 11173
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11173()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11173);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11185 - 11187
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11185_11187()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11185_11187);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения PNU 11189
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11189()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11189);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения регистров 11094-11097
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11094_11097()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11094_11097);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения PNU 11076
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11076()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11076);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения PNU 11040
        /// </summary>
        /// <returns></returns>
        public byte[] GetPnu11040()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetPnu11040);
        }

        /// <summary>
        /// Возвращает пакет байтов для чтения желаемых температур горячей воды (PNU 11190-11191)
        /// </summary>
        /// <returns></returns>
        public byte[] GetNewDesiredHotWaterTemperatures()
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.GetNewDesiredHotWaterTemperatures);
        }
    }
}

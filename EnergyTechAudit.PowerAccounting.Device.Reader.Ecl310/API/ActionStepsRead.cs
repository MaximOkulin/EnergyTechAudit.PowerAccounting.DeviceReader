using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API
{
    /// <summary>
    /// Класс, реализующий шаги действий при взаимодействии с прибором
    /// </summary>
    internal sealed partial class ActionSteps : ActionStepsBase
    {
        private readonly Functions _functions;
        private readonly int _deviceAddress;
        private readonly Commands _commands;

        public ActionSteps(DeviceTransport eclConnection, ManualResetEvent autoEvent, int deviceAddress)
            : base(eclConnection, autoEvent)
        {
            _functions = new Functions(deviceAddress);
            _deviceAddress = deviceAddress;
            _commands = new Commands();
        }

        /// <summary>
        /// Возвращает перфикс приложения
        /// </summary>
        public void GetApplicationPrefix()
        {
            Transport.CurrentCommand = _commands.GetApplicationPrefix;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetApplicationPrefix(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает тип приложения
        /// </summary>
        public void GetApplicationType()
        {
            Transport.CurrentCommand = _commands.GetApplicationType;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetApplicationType(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает подтип приложения
        /// </summary>
        public void GetApplicationSubType()
        {
            Transport.CurrentCommand = _commands.GetApplicationSubType;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetApplicationSubType(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает дату производства регулятора
        /// </summary>
        public void GetManufacturingDate()
        {
            Transport.CurrentCommand = _commands.GetManufacturingDate;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetManufacturingDate(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает заводской номер прибора
        /// </summary>
        public void GetFactoryNumber()
        {
            Transport.CurrentCommand = _commands.GetFactoryNumber;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFactoryNumber(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает номер аппаратной версии контроллера
        /// </summary>
        public void GetHardwareVersion()
        {
            Transport.CurrentCommand = _commands.GetHardwareVersion;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHardwareVersion(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает приоритет ограничения температуры обратки
        /// </summary>
        public bool GetLimitReversePriority()
        {
            Transport.CurrentCommand = _commands.GetLimitReversePriority;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetLimitReversePriority(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает приоритет ограничения температуры обратки (контур 2)
        /// </summary>
        public bool GetLimitReversePriorityCircuit2()
        {
            Transport.CurrentCommand = _commands.GetLimitReversePriorityCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetLimitReversePriorityCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает версию программного обеспечения контроллера
        /// </summary>
        public void GetFirmware()
        {
            Transport.CurrentCommand = _commands.GetFirmware;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает значения датчиков S1-S12
        /// </summary>
        public bool GetSensorsValues()
        {
            Transport.CurrentCommand = _commands.GetSensorsValues;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensorsValues(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение датчика S1
        /// </summary>
        /// <returns></returns>
        public bool GetSensor1Value()
        {
            Transport.CurrentCommand = _commands.GetSensor1Value;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor1Value(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение датчика S2
        /// </summary>
        /// <returns></returns>
        public bool GetSensor2Value()
        {
            Transport.CurrentCommand = _commands.GetSensor2Value;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor2Value(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение датчика S3
        /// </summary>
        /// <returns></returns>
        public bool GetSensor3Value()
        {
            Transport.CurrentCommand = _commands.GetSensor3Value;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor3Value(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение датчика S5
        /// </summary>
        /// <returns></returns>
        public bool GetSensor5Value()
        {
            Transport.CurrentCommand = _commands.GetSensor5Value;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor5Value(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения датчиков S13-S16,
        /// присоединенных к модулю расширения ECA32
        /// </summary>
        public bool GetEca32SensorsValues()
        {
            Transport.CurrentCommand = _commands.GetEca32SensorsValues;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetEca32SensorsValues(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает текущее значение реального времени регулятора
        /// </summary>
        public void GetDeviceTime()
        {
            Transport.CurrentCommand = _commands.GetDeviceTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetDeviceTime(), true);
            Wait();
        }

        /// <summary>
        /// Возвращает рассчитанное значение датчика 2
        /// </summary>
        public bool GetSensor2CalculatedValueCircuit1()
        {
            Transport.CurrentCommand = _commands.GetSensor2CalculatedValueCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor2CalculatedValueCircuit1());
            return Wait();
        }

        /// <summary>
        /// Возвращает рассчитанное значение датчика 3
        /// </summary>
        public bool GetSensor3CalculatedValueCircuit1()
        {
            Transport.CurrentCommand = _commands.GetSensor3CalculatedValueCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor3CalculatedValueCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры контура 2
        /// </summary>
        public bool Get2CircuitParameters()
        {
            Transport.CurrentCommand = _commands.Get2CircuitParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.Get2CircuitParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает рассчитанное значение датчика 5
        /// </summary>
        public bool GetSensor5CalculatedValueCircuit1()
        {
            Transport.CurrentCommand = _commands.GetSensor5CalculatedValueCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor5CalculatedValueCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает рассчитанное значение датчика 4
        /// </summary>
        public bool GetSensor4CalculatedValueCircuit2()
        {
            Transport.CurrentCommand = _commands.GetSensor4CalculatedValueCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor4CalculatedValueCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает рассчитанное значение датчика 6
        /// </summary>
        public bool GetSensor6CalculatedValueCircuit2()
        {
            Transport.CurrentCommand = _commands.GetSensor6CalculatedValueCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor6CalculatedValueCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает рассчитанное значение датчика 7
        /// </summary>
        public bool GetSensor7CalculatedValueCircuit1()
        {
            Transport.CurrentCommand = _commands.GetSensor7CalculatedValueCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSensor7CalculatedValueCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры контура 1
        /// </summary>
        public bool GetHeatSystemParameters()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает аварийную температуру замерзания S6
        /// </summary>
        public bool GetAccidentS6FreezingTemperature()
        {
            Transport.CurrentCommand = _commands.GetAccidentS6FreezingTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentS6FreezingTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает аварийную температуру замерзания S5
        /// </summary>
        public bool GetAccidentS5FreezingTemperature()
        {
            Transport.CurrentCommand = _commands.GetAccidentS5FreezingTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentS5FreezingTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры термостата замерзания
        /// </summary>
        public bool GetFrostThermostatParameters()
        {
            Transport.CurrentCommand = _commands.GetFrostThermostatParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFrostThermostatParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры внешнего входа, контур 1
        /// </summary>
        public bool GetExternalInputParams()
        {
            Transport.CurrentCommand = _commands.GetExternalInputParams;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetExternalInputParams(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры внешнего входа, контур 2
        /// </summary>
        public bool GetExternalInputParamsCircuit2()
        {
            Transport.CurrentCommand = _commands.GetExternalInputParamsCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetExternalInputParamsCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры термостата пожаробезопасности
        /// </summary>
        public bool GetFireSafetyThermostatParameters()
        {
            Transport.CurrentCommand = _commands.GetFireSafetyThermostatParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFireSafetyThermostatParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры температурного монитора, контур 1
        /// </summary>
        public bool GetTemperatureMonitorParameters()
        {
            Transport.CurrentCommand = _commands.GetTemperatureMonitorParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetTemperatureMonitorParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры температурного монитора, контур 2
        /// </summary>
        public bool GetTemperatureMonitorParametersCircuit2()
        {
            Transport.CurrentCommand = _commands.GetTemperatureMonitorParametersCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetTemperatureMonitorParametersCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения температур контура 1
        /// </summary>
        public bool GetHeatSystemTemperatures()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemTemperatures;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemTemperatures(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение времени оптимизации предельной безопасной температуры
        /// </summary>
        public bool GetLimitFreezeOptimizationTime()
        {
            Transport.CurrentCommand = _commands.GetLimitFreezeOptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetLimitFreezeOptimizationTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает время защиты двигателя
        /// </summary>
        public bool GetMotorProtection()
        {
            Transport.CurrentCommand = _commands.GetMotorProtection;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMotorProtection(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает время защиты двигателя регулятора 2
        /// </summary>
        public bool GetMotorProtection2()
        {
            Transport.CurrentCommand = _commands.GetMotorProtection2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMotorProtection2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения настроек управления вентилятором
        /// </summary>
        public bool GetFanParameters()
        {
            Transport.CurrentCommand = _commands.GetFanParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFanParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает коэффициент разницы заданных комнатных температур
        /// </summary>
        public bool GetRoomTemperaturesDiff()
        {
            Transport.CurrentCommand = _commands.GetRoomTemperaturesDiff;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetRoomTemperaturesDiff(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает температуру защиты от замерзания
        /// </summary>
        public bool GetFrostProtectionTemperature()
        {
            Transport.CurrentCommand = _commands.GetFrostProtectionTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFrostProtectionTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает функцию вентилятора
        /// </summary>
        public bool GetFanFunction()
        {
            Transport.CurrentCommand = _commands.GetFanFunction;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFanFunction(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров контура 1
        /// </summary>
        public bool GetHeatSystemParameters1Registers()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemParameters1Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemParameters1Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров контура 1
        /// </summary>
        public bool GetHeatSystemParameters2Registers()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemParameters2Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemParameters2Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров контура 1
        /// </summary>
        public bool GetHeatSystemParameters3Registers()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemParameters3Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemParameters3Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров контура 1
        /// </summary>
        public bool GetHeatSystemParameters8Registers()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemParameters8Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemParameters8Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает желаемые температуры контура 1
        /// </summary>
        public bool GetDesiredTemperaturesCircuit1()
        {
            Transport.CurrentCommand = _commands.GetDesiredTemperaturesCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetDesiredTemperaturesCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения коэффициентов контура 1
        /// </summary>
        public bool GetHeatSystemKoefficients()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemKoefficients;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemKoefficients(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения ограничений температуры подачи контура 1
        /// </summary>
        public bool GetHeatSystemSupplyTemperatureLimits()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemSupplyTemperatureLimits;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemSupplyTemperatureLimits(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение максимального выходного напряжения
        /// </summary>
        public bool GetMaxOutputVoltage()
        {
            Transport.CurrentCommand = _commands.GetMaxOutputVoltage;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMaxOutputVoltage(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение минимального выходного напряжения
        /// </summary>
        public bool GetMinOutputVoltage()
        {
            Transport.CurrentCommand = _commands.GetMinOutputVoltage;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMinOutputVoltage(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение реверса
        /// </summary>
        public bool GetReverse()
        {
            Transport.CurrentCommand = _commands.GetReverse;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetReverse(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает коэффициенты ограничения комнатной температуры
        /// </summary>
        public bool GetInfluenceRoomParams()
        {
            Transport.CurrentCommand = _commands.GetInfluenceRoomParams;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInfluenceRoomParams(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения ограничений температуры подачи контура 2
        /// </summary>
        public bool GetHwsSupplyTemperatureLimits()
        {
            Transport.CurrentCommand = _commands.GetHwsSupplyTemperatureLimits;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsSupplyTemperatureLimits(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает скорость адаптации комнатной температуры, контур 1
        /// </summary>
        public bool GetOptimizationTime()
        {
            Transport.CurrentCommand = _commands.GetOptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает скорость адаптации комнатной температуры, контур 2
        /// </summary>
        public bool GetOptimizationTimeCircuit2()
        {
            Transport.CurrentCommand = _commands.GetOptimizationTimeCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationTimeCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает нижнее значение максимальной границы контура 1 Y1
        /// </summary>
        public bool GetMinHsBorderFlowTemperature()
        {
            Transport.CurrentCommand = _commands.GetMinHsBorderFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMinHsBorderFlowTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры компенсации контура 1
        /// </summary>
        public bool GetCompensationParameters()
        {
            Transport.CurrentCommand = _commands.GetCompensationParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetCompensationParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает верхнее значение максимальной температуры контура 1 Y2
        /// </summary>
        public bool GetMaxHsBorderFlowTemperature()
        {
            Transport.CurrentCommand = _commands.GetMaxHsBorderFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMaxHsBorderFlowTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров насосов контура 1
        /// </summary>
        public bool GetHeatSystemPumpParameters()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemPumpParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemPumpParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение времени профилактики насоса контура 1
        /// </summary>
        public bool GetHeatSystemPumpTrainingTime()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemPumpTrainingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemPumpTrainingTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение времени профилактики насоса контура 1 (для ключа А231, в секундах)
        /// </summary>
        public bool GetHeatSystemPumpTrainingTime2()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemPumpTrainingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemPumpTrainingTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров заполнения водой контура 1
        /// </summary>
        public bool GetHeatSystemWaterFillParameters()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemWaterFillParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemWaterFillParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров заполнения водой системы контура 1 (часть 2)
        /// </summary>
        public bool GetHeatSystemWaterFillParameters2()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemWaterFillParameters2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemWaterFillParameters2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает желаемые температуры горячей воды
        /// </summary>
        public bool GetDesiredHotWaterTemperatures()
        {
            Transport.CurrentCommand = _commands.GetDesiredHotWaterTemperatures;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetDesiredHotWaterTemperatures(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры для обратного трубопровода контура 1 и пр.
        /// </summary>
        public bool GetHeatSystemReverseParameters()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemReverseParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemReverseParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры для обратного трубопровода контура 1 и пр.
        /// (3 регистра)
        /// </summary>
        public bool GetHeatSystemReverseParameters3Registers()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemReverseParameters3Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemReverseParameters3Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает коэффициент максимального влияния ветра
        /// </summary>
        public bool GetHeatSystemMaxWindInfluence()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemMaxWindInfluence;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemMaxWindInfluence(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает заданную балансовую температуру
        /// </summary>
        public bool GetAdjustedBalanceTemperature()
        {
            Transport.CurrentCommand = _commands.GetAdjustedBalanceTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAdjustedBalanceTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает фильтр ветра
        /// </summary>
        public bool GetHeatSystemWindFilter()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemWindFilter;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemWindFilter(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает ограничение ветра
        /// </summary>
        public bool GetHeatSystemWindLimit()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemWindLimit;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemWindLimit(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает минимальное время активации электропривода контура 1
        /// </summary>
        public bool GetHeatSystemDriveActivationTime()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemDriveActivationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemDriveActivationTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения точек температурного графика контура 1
        /// </summary>
        public bool GetHeatCurve()
        {
            Transport.CurrentCommand = _commands.GetHeatCurve;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatCurve(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает время ожидания перед открытием клапана контура 1
        /// </summary>
        public bool GetHsWaitOpenValveTime()
        {
            Transport.CurrentCommand = _commands.GetHsWaitOpenValveTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHsWaitOpenValveTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает время ожидания перед открытием клапана контура 2
        /// </summary>
        public bool GetHwsWaitOpenValveTime()
        {
            Transport.CurrentCommand = _commands.GetHwsWaitOpenValveTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsWaitOpenValveTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения температур контура 2
        /// </summary>
        public bool GetHwsTemperatures()
        {
            Transport.CurrentCommand = _commands.GetHwsTemperatures;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsTemperatures(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров для обратного трубопровода контура 2
        /// </summary>
        public bool GetHwsReverseParameters()
        {
            Transport.CurrentCommand = _commands.GetHwsReverseParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsReverseParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает мин. влияние предельной безопасной температуры
        /// </summary>
        public bool GetMinLimitFreezeTemperature()
        {
            Transport.CurrentCommand = _commands.GetMinLimitFreezeTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMinLimitFreezeTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения точек температурного графика контура 2
        /// </summary>
        public bool GetHeatCurve2()
        {
            Transport.CurrentCommand = _commands.GetHeatCurve2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatCurve2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает тип входного сигнала давления
        /// </summary>
        public bool GetEcl310PressureInputSignalTypeId()
        {
            Transport.CurrentCommand = _commands.GetEcl310PressureInputSignalTypeId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetEcl310PressureInputSignalTypeId(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает предельную температуру обратки контура 2
        /// </summary>
        public bool GetHwsLimitReverseTemperature()
        {
            Transport.CurrentCommand = _commands.GetHwsLimitReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsLimitReverseTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение фильтра S4
        /// </summary>
        public bool GetS4Filter()
        {
            Transport.CurrentCommand = _commands.GetS4Filter;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetS4Filter(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение адреса ECA
        /// </summary>
        public bool GetEcaAddressId()
        {
            Transport.CurrentCommand = _commands.GetEcaAddressId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetEcaAddressId(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение адреса ECA, контур 2
        /// </summary>
        public bool GetEcaAddressCircuit2Id()
        {
            Transport.CurrentCommand = _commands.GetEcaAddressCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetEcaAddressCircuit2Id(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага полного отключения, контур 1
        /// </summary>
        public bool GetBlackout()
        {
            Transport.CurrentCommand = _commands.GetBlackout;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetBlackout(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага полного отключения, контур 2
        /// </summary>
        public bool GetBlackoutCircuit2()
        {
            Transport.CurrentCommand = _commands.GetBlackoutCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetBlackoutCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение времени перехода между режимами
        /// </summary>
        public bool GetTransitionModeTime()
        {
            Transport.CurrentCommand = _commands.GetTransitionModeTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetTransitionModeTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение температуры защиты от замерзания
        /// </summary>
        public bool GetFrostProtectionTemperature2()
        {
            Transport.CurrentCommand = _commands.GetFrostProtectionTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFrostProtectionTemperature2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага выбора компенсационной температуры
        /// </summary>
        public bool GetSelectionCompensationTemperature()
        {
            Transport.CurrentCommand = _commands.GetSelectionCompensationTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSelectionCompensationTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает ограничение температуры обратного трубопровода контура 1
        /// </summary>
        public bool GetHeatSystemLimitReverseTemperature()
        {
            Transport.CurrentCommand = _commands.GetHeatSystemLimitReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatSystemLimitReverseTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага посылки заданной температуры
        /// </summary>
        public bool GetSendPredeterminedTemperature()
        {
            Transport.CurrentCommand = _commands.GetSendPredeterminedTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSendPredeterminedTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение использования внешнего сигнала в контуре 1
        /// </summary>
        public bool GetHsExternalSignal()
        {
            Transport.CurrentCommand = _commands.GetHsExternalSignal;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHsExternalSignal(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения мин/макс влияния обратки контура 2
        /// </summary>
        public bool GetHwsMinMaxInfluenceReverse()
        {
            Transport.CurrentCommand = _commands.GetHwsMinMaxInfluenceReverse;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsMinMaxInfluenceReverse(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения мин/макс температур подачи контура 2
        /// </summary>
        public bool GetHwsMinMaxFlowTemperatures()
        {
            Transport.CurrentCommand = _commands.GetHwsMinMaxFlowTemperatures;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsMinMaxFlowTemperatures(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров контура 2
        /// </summary>
        public bool GetHwsParameters()
        {
            Transport.CurrentCommand = _commands.GetHwsParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров контура 2
        /// </summary>
        public bool GetHwsParameters3Registers()
        {
            Transport.CurrentCommand = _commands.GetHwsParameters3Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsParameters3Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров насосов контура 2
        /// </summary>
        public bool GetHwsPumpParameters()
        {
            Transport.CurrentCommand = _commands.GetHwsPumpParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsPumpParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение времени профилактики насоса контура 2
        /// </summary>
        public bool GetHwsPumpTrainingTime()
        {
            Transport.CurrentCommand = _commands.GetHwsPumpTrainingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsPumpTrainingTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает статусы режимов ручного управления 3 реле
        /// </summary>
        public bool GetManualRelayStatuses3Registers()
        {
            Transport.CurrentCommand = _commands.GetManualRelayStatuses3Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetManualRelayStatuses3Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает статусы режимов ручного управления 5 реле
        /// </summary>
        public bool GetManualRelayStatuses5Registers()
        {
            Transport.CurrentCommand = _commands.GetManualRelayStatuses5Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetManualRelayStatuses5Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает статусы режимов ручного управления 7 реле
        /// </summary>
        public bool GetManualRelayStatuses7Registers()
        {
            Transport.CurrentCommand = _commands.GetManualRelayStatuses7Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetManualRelayStatuses7Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает минимальное время активации электропривода контура 2
        /// </summary>
        public bool GetHwsDriveActivationTime()
        {
            Transport.CurrentCommand = _commands.GetHwsDriveActivationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsDriveActivationTime(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает предельную температуру замерзания
        /// </summary>
        public bool GetLimitFreezeTemperature()
        {
            Transport.CurrentCommand = _commands.GetLimitFreezeTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetLimitFreezeTemperature(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения параметров заполнения водой контура 2
        /// </summary>
        public bool GetHwsWaterFillParameters()
        {
            Transport.CurrentCommand = _commands.GetHwsWaterFillParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsWaterFillParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение типа входного сигнала давления контура 2
        /// </summary>
        public bool GetEcl310PressureInputSignalType2Id()
        {
            Transport.CurrentCommand = _commands.GetEcl310PressureInputSignalType2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetEcl310PressureInputSignalType2Id(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает режимы работы контуров
        /// </summary>
        public bool GetOperatingModes()
        {
            Transport.CurrentCommand = _commands.GetOperatingModes;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOperatingModes(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает статусы работы контуров (1 и 2)
        /// </summary>
        /// <returns></returns>
        public bool GetOperatingStatuses()
        {
            Transport.CurrentCommand = _commands.GetOperatingStatuses;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOperatingStatuses(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает статус работы контура 1
        /// </summary>
        public bool GetOperatingStatus()
        {
            Transport.CurrentCommand = _commands.GetOperatingStatus;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOperatingStatus(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает режим работы контура 1
        /// </summary>
        public bool GetOperatingMode()
        {
            Transport.CurrentCommand = _commands.GetOperatingMode;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOperatingMode(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает статусы режимов ручного управления
        /// </summary>
        public bool GetManualRelayStatuses()
        {
            Transport.CurrentCommand = _commands.GetManualRelayStatuses;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetManualRelayStatuses(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает количество насосов
        /// </summary>
        public bool GetPumpCount()
        {
            Transport.CurrentCommand = _commands.GetPumpCount;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPumpCount(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры, связанные с работой датчика потока
        /// </summary>
        public bool GetFlowSensorParameters()
        {
            Transport.CurrentCommand = _commands.GetFlowSensorParameters;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowSensorParameters(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает коэффициент мертвой зоны
        /// </summary>
        public bool GetDeadBand()
        {
            Transport.CurrentCommand = _commands.GetDeadBand;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetDeadBand(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает смещение
        /// </summary>
        public bool GetOffset()
        {
            Transport.CurrentCommand = _commands.GetOffset;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOffset(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает флаг тренировки клапана, контур 1
        /// </summary>
        public bool GetFlapTrainingCurcuit1()
        {
            Transport.CurrentCommand = _commands.GetFlapTrainingCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlapTrainingCurcuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает флаг тренировки клапана, контур 2
        /// </summary>
        public bool GetFlapTrainingCurcuit2()
        {
            Transport.CurrentCommand = _commands.GetFlapTrainingCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlapTrainingCurcuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает флаг приоритета ГВС, контур 1
        /// </summary>
        public bool GetHwsPriorityCircuit1()
        {
            Transport.CurrentCommand = _commands.GetHwsPriorityCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsPriorityCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает флаг приоритета ГВС, контур 2
        /// </summary>
        public bool GetHwsPriorityCircuit2()
        {
            Transport.CurrentCommand = _commands.GetHwsPriorityCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHwsPriorityCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает температуру защиты от замерзания, контур 2
        /// </summary>
        public bool GetFrostProtectionTemperatureCircuit2()
        {
            Transport.CurrentCommand = _commands.GetFrostProtectionTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFrostProtectionTemperatureCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает температуру тепловой нагрузки, контур 1
        /// </summary>
        public bool GetThermalLoadTemperatureCircuit1()
        {
            Transport.CurrentCommand = _commands.GetThermalLoadTemperatureCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetThermalLoadTemperatureCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает температуру тепловой нагрузки, контур 2
        /// </summary>
        public bool GetThermalLoadTemperatureCircuit2()
        {
            Transport.CurrentCommand = _commands.GetThermalLoadTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetThermalLoadTemperatureCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает требуемую температуру защиты от замерзания, контур 2
        /// </summary>
        public bool GetFrostProtectionTemperature2Circuit2()
        {
            Transport.CurrentCommand = _commands.GetFrostProtectionTemperature2Circuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFrostProtectionTemperature2Circuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры ограничения расхода, контур 1
        /// </summary>
        public bool GetFlowLimitationParams()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationParams;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationParams(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает два параметра ограничения расхода, контур 1
        /// </summary>
        public bool GetFlowLimitation2Params()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitation2Params;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitation2Params(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает пяти параметров ограничения расхода, контур 1
        /// </summary>
        public bool GetFlowLimitation5Params()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitation5Params;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitation5Params(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры ограничения расхода, контур 2
        /// </summary>
        public bool GetFlowLimitationParamsCircuit2()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationParamsCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationParamsCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает два параметра ограничения расхода, контур 2
        /// </summary>
        public bool GetFlowLimitation2ParamsCircuit2()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitation2ParamsCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitation2ParamsCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает пять параметров ограничения расхода, контур 2
        /// </summary>
        public bool GetFlowLimitation5ParamsCircuit2()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitation5ParamsCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitation5ParamsCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает тип входа ограничения расхода, контур 1
        /// </summary>
        public bool GetFlowLimitationInputTypeId()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationInputTypeId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationInputTypeId(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает тип входа ограничения расхода, контур 2
        /// </summary>
        public bool GetFlowLimitationInputTypeCircuit2Id()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationInputTypeCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationInputTypeCircuit2Id(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры оптимизации, контур 1
        /// </summary>
        public bool GetOptimizationParams()
        {
            Transport.CurrentCommand = _commands.GetOptimizationParams;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationParams(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры оптимизации, контур 2
        /// </summary>
        public bool GetOptimizationParamsCircuit2()
        {
            Transport.CurrentCommand = _commands.GetOptimizationParamsCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationParamsCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает флаг задержки отключения, контур 1
        /// </summary>
        public bool GetOptimizationOffDelay()
        {
            Transport.CurrentCommand = _commands.GetOptimizationOffDelay;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationOffDelay(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает флаг задержки отключения, контур 2
        /// </summary>
        public bool GetOptimizationOffDelayCircuit2()
        {
            Transport.CurrentCommand = _commands.GetOptimizationOffDelayCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationOffDelayCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает базис оптимизации, контур 1
        /// </summary>
        public bool GetOptimizationBasisId()
        {
            Transport.CurrentCommand = _commands.GetOptimizationBasisId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationBasisId(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает базис оптимизации, контур 2
        /// </summary>
        public bool GetOptimizationBasisCircuit2Id()
        {
            Transport.CurrentCommand = _commands.GetOptimizationBasisCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetOptimizationBasisCircuit2Id(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает требуемые температуры
        /// </summary>
        public bool GetRequiredTemperatures()
        {
            Transport.CurrentCommand = _commands.GetRequiredTemperatures;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetRequiredTemperatures(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры ограничения расхода
        /// </summary>
        public bool GetFlowLimitationParams5Registers()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationParams5Registers;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationParams5Registers(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры ограничения расхода, контур 2
        /// </summary>
        public bool GetFlowLimitationParams5RegistersCircuit2()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationParams5RegistersCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationParams5RegistersCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает нагрузку охлаждения, контур 1
        /// </summary>
        public bool GetCoolingLoadTemperatureCircuit1()
        {
            Transport.CurrentCommand = _commands.GetCoolingLoadTemperatureCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetCoolingLoadTemperatureCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает температуру в режиме ожидания, контур 1
        /// </summary>
        public bool GetExpectationFlowTemperatureCircuit1()
        {
            Transport.CurrentCommand = _commands.GetExpectationFlowTemperatureCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetExpectationFlowTemperatureCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает коэффициент параллельной работы, контур 1
        /// </summary>
        public bool GetParallelOperationCircuit1()
        {
            Transport.CurrentCommand = _commands.GetParallelOperationCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetParallelOperationCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает флаг автонастройки, контур 2
        /// </summary>
        public bool GetAutotuningCircuit2()
        {
            Transport.CurrentCommand = _commands.GetAutotuningCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAutotuningCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры сигнализации, контур 1
        /// </summary>
        public bool GetSignalizationParamsCircuit1()
        {
            Transport.CurrentCommand = _commands.GetSignalizationParamsCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSignalizationParamsCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает аварийные границы давления, контур 1
        /// </summary>
        public bool GetAccidentLimits()
        {
            Transport.CurrentCommand = _commands.GetAccidentLimits;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentLimits(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значения давления, контур 1
        /// </summary>
        public bool GetPressureValues()
        {
            Transport.CurrentCommand = _commands.GetAccidentLimits;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPressureValues(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага сброса аварии насосов, контур 1
        /// </summary>
        public bool GetAccidentPumpsCircuit1()
        {
            Transport.CurrentCommand = _commands.GetAccidentPumpsCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentPumpsCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага сброса аварии насосов, контур 2
        /// </summary>
        public bool GetAccidentPumpsCircuit2()
        {
            Transport.CurrentCommand = _commands.GetAccidentPumpsCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentPumpsCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага сброса подпитки, контур 1
        /// </summary>
        public bool GetAccidentMakeupCircuit1()
        {
            Transport.CurrentCommand = _commands.GetAccidentMakeupCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentMakeupCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает значение флага сброса подпитки, контур 2
        /// </summary>
        public bool GetAccidentMakeupCircuit2()
        {
            Transport.CurrentCommand = _commands.GetAccidentMakeupCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentMakeupCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры подпитки контура 1
        /// </summary>
        public bool GetMakeupParametersCircuit1()
        {
            Transport.CurrentCommand = _commands.GetMakeupParametersCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMakeupParametersCircuit1(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает параметры подпитки контура 2
        /// </summary>
        public bool GetMakeupParametersCircuit2()
        {
            Transport.CurrentCommand = _commands.GetMakeupParametersCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMakeupParametersCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает задержку аварии, контур 1
        /// </summary>
        public bool GetAccidentFrostThermostatDelay()
        {
            Transport.CurrentCommand = _commands.GetAccidentFrostThermostatDelay;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetAccidentFrostThermostatDelay(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает количество насосов, контур 1
        /// </summary>
        public bool GetHsPumpCount()
        {
            Transport.CurrentCommand = _commands.GetHsPumpCount;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHsPumpCount(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает ограничение ГВС, контур 2
        /// </summary>
        public bool GetFlowLimitationLimitCircuit2()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationLimitCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationLimitCircuit2(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает единицу измерения, контур 2
        /// </summary>
        public bool GetFlowLimitationUnitDict2Circuit2Id()
        {
            Transport.CurrentCommand = _commands.GetFlowLimitationUnitDict2Circuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFlowLimitationUnitDict2Circuit2Id(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает угол наклона температурного графика, контур 1
        /// </summary>
        public bool GetHeatCurveAngle()
        {
            Transport.CurrentCommand = _commands.GetHeatCurveAngle;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatCurveAngle(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает границу отключения отопления, контур 1
        /// </summary>
        public bool GetHeatingBorder()
        {
            Transport.CurrentCommand = _commands.GetHeatingBorder;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatingBorder(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает содержимое регистра PNU 11173
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11173()
        {
            Transport.CurrentCommand = _commands.GetPnu11173;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11173(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает содержимое регистров PNU 11185 - 11187
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11185_11187()
        {
            Transport.CurrentCommand = _commands.GetPnu11185_11187;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11185_11187(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает содержимое регистра PNU 11189
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11189()
        {
            Transport.CurrentCommand = _commands.GetPnu11189;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11189(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает содержимое регистров PNU 11094-11097
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11094_11097()
        {
            Transport.CurrentCommand = _commands.GetPnu11094_11097;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11094_11097(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает содержимое регистра PNU 11076
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11076()
        {
            Transport.CurrentCommand = _commands.GetPnu11076;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11076(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает содержимое регистра PNU 11040
        /// </summary>
        /// <returns></returns>
        public bool GetPnu11040()
        {
            Transport.CurrentCommand = _commands.GetPnu11040;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetPnu11040(), true);
            return Wait();
        }

        /// <summary>
        /// Возвращает желаемые температуры горчей воды
        /// </summary>
        /// <returns></returns>
        public bool GetNewDesiredHotWaterTemperatures()
        {
            Transport.CurrentCommand = _commands.GetNewDesiredHotWaterTemperatures;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetNewDesiredHotWaterTemperatures(), true);
            return Wait();
        }
    }
}


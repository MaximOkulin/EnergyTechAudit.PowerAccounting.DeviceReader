using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API
{
    internal sealed partial class Functions
    {

        /// <summary>
        /// Устанавливает минимальную температуру подачи системы отопления (PNU 11177)
        /// </summary>
        public byte[] SetMinHsFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsFlowTemperature, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Устаналивает максимальную температуру подачи системы отопления (PNU 11178)
        /// </summary>
        public byte[] SetMaxHsFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHsFlowTemperature, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Устанавливает температуру отключения отопления (PNU 11179)
        /// </summary>
        public byte[] SetHsHeatingOffTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsHeatingOffTemperature, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Устанавливает желаемую дневную комнатную температуру (PNU 11180)
        /// </summary>
        public byte[] SetHsComfortRoomTemperature(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsComfortRoomTemperature,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Устанавливает желаемую ночную комнатную температуру (PNU 11181)
        /// </summary>
        public byte[] SetHsSavingRoomTemperature(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsSavingRoomTemperature,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Устанавливает максимальное значение коэффициента влияния комнатной температуры
        /// на систему отопления (PNU 11182)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMaxHsInfluenceRoom(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHsInfluenceRoom,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Устанавливает максимальное значение коэффициента влияния комнатной температуры,
        /// контур 2 (PNU 12182)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMaxHwsInfluenceRoom(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHwsInfluenceRoom,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Устанавливает минимальное значение коэффициента влияния комнатной температуры
        /// на систему отопления (PNU 11183)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMinHsInfluenceRoom(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsInfluenceRoom,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Устанавливает минимальное значение коэффициента влияния комнатной температуры,
        /// контур 2 (PNU 12183)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMinHwsInfluenceRoom(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsInfluenceRoom,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Устанавливает коэффициент зоны пропорциональности системы отопления
        /// (PNU 11184)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetHsProportionalBand(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsProportionalBand,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Устанавливает постоянную времени интегрирования системы отопления
        /// (PNU 11185)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetHsIntegrationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsIntegrationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Устанавливает время перемещения штока привода системы отопления
        /// (PNU 11186)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetHsDriveStockTravelTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsDriveStockTravelTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Устанавливает коэффициент нейтральной зоны системы отопления
        /// (PNU 11187)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetHsNeutralZone(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsNeutralZone,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Устанавливает желаемую дневную температуру горячей воды
        /// (PNU 12190)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetHwsComfortRoomTemperature(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsComfortRoomTemperature,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Устанавливает желаемую ночную температуру горячей воды
        /// (PNU 12191)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetHwsSavingRoomTemperature(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsSavingRoomTemperature,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки максимальной температуры открытого воздуха
        /// (PNU 11031)
        /// </summary>
        /// <param name="value">Новое максимальное значение температуры открытого воздуха</param>
        public byte[] SetMaxHsOpenAirTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHsOpenAirTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимальной температуры обратного контура системы отопления (PNU 11032)
        /// </summary>
        /// <param name="value">Новое минимальное значение температуры обратного контура системы отопления</param>
        public byte[] SetMinHsReverseTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsReverseTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимальной температуры открытого воздуха
        /// (PNU 11033)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetMinHsOpenAirTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsOpenAirTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки максимального значения температуры
        /// обратного контура системы отопления (PNU 11034)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetMaxHsReverseTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHsReverseTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки максимального коэффициента влияния обратки
        /// системы отопления (PNU 11035)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMaxHsInfluenceReverse(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHsInfluenceReverse,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимального коэффициента влияния обратки
        /// системы отопления (PNU 11036)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMinHsInfluenceReverse(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsInfluenceReverse,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки времени адаптации температуры в системе отопления (PNU 11037)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetHsOptimizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsOptimizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимального времени активации привода системы отопления (PNU 11189)
        /// </summary>
        /// <param name="value">Новое значение времени в секундах</param>
        public byte[] SetMinHsDriveActivationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsDriveActivationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при -30 (PNU 11400)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetMinus30FlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinus30FlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при -30 для контура 2 (PNU 12400)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetMinus30FlowTemperature2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinus30FlowTemperature2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при -15 (PNU 11401)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetMinus15FlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinus15FlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при -15 для контура 2 (PNU 12401)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetMinus15FlowTemperature2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinus15FlowTemperature2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при -5 (PNU 11402)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetMinus5FlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinus5FlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при -5 для контура 2 (PNU 12402)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetMinus5FlowTemperature2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinus5FlowTemperature2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при 0 (PNU 11403)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetZeroFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetZeroFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при 0 для контура 2 (PNU 12403)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetZeroFlowTemperature2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetZeroFlowTemperature2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при +5 (PNU 11404)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetPlus5FlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPlus5FlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при +5 для контура 2 (PNU 12404)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetPlus5FlowTemperature2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPlus5FlowTemperature2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при +15 (PNU 11405)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetPlus15FlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPlus15FlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки точки температурного графика при +15 для контура 2 (PNU 12405)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetPlus15FlowTemperature2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPlus15FlowTemperature2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки ограничения температуры обратки (PNU 12030)
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        public byte[] SetHwsLimitReverseTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsLimitReverseTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки максимального коэффициента влияния обратного контура ГВС (PNU 12035)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMaxHwsInfluenceReverse(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHwsInfluenceReverse,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимального коэффициента влияния обратного контура ГВС (PNU 12036)
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        public byte[] SetMinHwsInfluenceReverse(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsInfluenceReverse,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки времени адаптации температуры в ГВС (PNU 12037)
        /// </summary>
        /// <param name="value">Новое значение времени адаптации в секундах</param>
        public byte[] SetHwsOptimizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsOptimizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимальной температуры подачи ГВС (PNU 12177)
        /// </summary>
        public byte[] SetMinHwsFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки максимальной температуры подачи ГВС (PNU 12178)
        /// </summary>
        public byte[] SetMaxHwsFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHwsFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки зоны пропорциональности ГВС (PNU 12184)
        /// </summary>
        public byte[] SetHwsProportionalBand(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsProportionalBand,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки постоянной времени интегрирования ГВС (PNU 12185)
        /// </summary>
        public byte[] SetHwsIntegrationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsIntegrationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки времени перемещения штока привода ГВС (PNU 12186)
        /// </summary>
        public byte[] SetHwsDriveStockTravelTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsDriveStockTravelTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки коэффициента нейтральной зоны ГВС (PNU 12187)
        /// </summary>
        public byte[] SetHwsNeutralZone(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsNeutralZone,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимального времени активации привода ГВС (PNU 12188)
        /// </summary>
        public byte[] SetMinHwsDriveActivationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsDriveActivationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки режима работы контура 1 (PNU 4201)
        /// </summary>
        public byte[] SetCircuit1OperatingMode(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetCircuit1OperatingMode,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки режима работы контура 2 (PNU 4202)
        /// </summary>
        public byte[] SetCircuit2OperatingMode(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetCircuit2OperatingMode,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки статуса работы контура 1 (PNU 4211)
        /// </summary>
        public byte[] SetCircuit1OperatingStatus(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetCircuit1OperatingStatus,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки статуса работы контура 1 (PNU 4212)
        /// </summary>
        public byte[] SetCircuit2OperatingStatus(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetCircuit2OperatingStatus,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки времени принудительного открытия клапана ГВС (PNU 12094)
        /// </summary>
        public byte[] SetForcedOpeningTime(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetForcedOpeningTime,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки времени принудительного закрытия клапана ГВС (PNU 12095)
        /// </summary>
        public byte[] SetForcedClosingTime(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetForcedClosingTime,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки холостого времени ГВС (PNU 12096)
        /// </summary>
        public byte[] SetHwsIdleTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsIdleTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки выбора температуры подачи ГВС (PNU 12097)
        /// </summary>
        public byte[] SetHwsFlowTemperatureIdle(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsFlowTemperatureIdle,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхнего значения температуры подачи системы отопления X2 (PNU 11300)
        /// </summary>
        public byte[] SetMaxHsSetFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHsSetFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхнего значения температуры подачи ГВС X2 (PNU 12300)
        /// </summary>
        public byte[] SetMaxHwsSetFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHwsSetFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхнего значения максимальной границы системы отопления Y2 (PNU 11301)
        /// </summary>
        public byte[] SetMaxHsBorderFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHsBorderFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхнего значения максимальной границы ГВС Y2 (PNU 12301)
        /// </summary>
        public byte[] SetMaxHwsBorderFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHwsBorderFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижнего значения температуры подачи системы отопления X1 (PNU 11302)
        /// </summary>
        public byte[] SetMinHsSetFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsSetFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижнего значения температуры подачи ГВС X1 (PNU 12302)
        /// </summary>
        public byte[] SetMinHwsSetFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsSetFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижнего значения максимальной границы системы отопления Y1 (PNU 11303)
        /// </summary>
        public byte[] SetMinHsBorderFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHsBorderFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижнего значения максимальной границы ГВС Y1 (PNU 12303)
        /// </summary>
        public byte[] SetMinHwsBorderFlowTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsBorderFlowTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени повтора при регулировании насосов контура 1 (PNU 11310)
        /// </summary>
        public byte[] SetHsPumpIterationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpIterationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени повтора при регулировании насосов контура 2 (PNU 12310)
        /// </summary>
        public byte[] SetHwsPumpIterationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpIterationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи длительности смены при регулировании насосов контура 1 (PNU 11311)
        /// </summary>
        public byte[] SetHsPumpChangePeriod(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpChangePeriod,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи длительности смены при регулировании насосов контура 2 (PNU 12311)
        /// </summary>
        public byte[] SetHwsPumpChangePeriod(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpChangePeriod,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи часа смены при регулировании насосов контура 1 (PNU 11312)
        /// </summary>
        public byte[] SetHsPumpChangeHour(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpChangeHour,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи часа смены при регулировании насосов контура 2 (PNU 12312)
        /// </summary>
        public byte[] SetHwsPumpChangeHour(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpChangeHour,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени стабилизации при регулировании насосов контура 1 (PNU 11313)
        /// </summary>
        public byte[] SetHsPumpStabilizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpStabilizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени стабилизации при регулировании насосов контура 2 (PNU 12313)
        /// </summary>
        public byte[] SetHwsPumpStabilizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpStabilizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени переключения при регулировании насосов контура 1 (PNU 11314)
        /// </summary>
        public byte[] SetHsPumpSwitchingTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpSwitchingTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени переключения при регулировании насосов контура 2 (PNU 12314)
        /// </summary>
        public byte[] SetHwsPumpSwitchingTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpSwitchingTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени профилактики насоса системы отопления (PNU 11021)
        /// </summary>
        public byte[] SetHsPumpTrainingTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpTrainingTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени тестирования насоса подпитки контура 1 (PNU 11320)
        /// </summary>
        public byte[] SetHsSupplyPumpTrainingTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsSupplyPumpTrainingTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени тестирования насоса подпитки контура 2 (PNU 12320)
        /// </summary>
        public byte[] SetHwsSupplyPumpTrainingTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsSupplyPumpTrainingTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи требуемого давления для системы подпитки контура 1 (PNU 11321)
        /// </summary>
        public byte[] SetHsPumpRequiredPressure(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpRequiredPressure,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи требуемого давления для системы подпитки контура 2 (PNU 12321)
        /// </summary>
        public byte[] SetHwsPumpRequiredPressure(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpRequiredPressure,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи разницы переключения давления для системы подпитки контура 1 (PNU 11322)
        /// </summary>
        public byte[] SetHsPumpSwitchingDiff(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpSwitchingDiff,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи разницы переключения давления для системы подпитки контура 2 (PNU 12322)
        /// </summary>
        public byte[] SetHwsPumpSwitchingDiff(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpSwitchingDiff,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи длительности долива для системы подпитки контура 1 (PNU 11323)
        /// </summary>
        public byte[] SetHsPumpToppingDuration(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpToppingDuration,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи длительности долива для системы подпитки контура 2 (PNU 12323)
        /// </summary>
        public byte[] SetHwsPumpToppingDuration(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpToppingDuration,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ожидания перед открытием клапана (PNU 11325)
        /// </summary>
        public byte[] SetHsWaitOpenValveTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsWaitOpenValveTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ожидания перед открытием клапана, контур 2 (PNU 12325)
        /// </summary>
        public byte[] SetHwsWaitOpenValveTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsWaitOpenValveTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи количества насосов (PNU 11326)
        /// </summary>
        public byte[] SetHsPumpCount(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsPumpCount, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи количества насосов, контур 2 (PNU 12326)
        /// </summary>
        public byte[] SetHwsPumpCount(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpCount, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи типа входного сигнала давления контура 1 (PNU 11327)
        /// </summary>
        public byte[] SetEcl310PressureInputSignalTypeId(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetEcl310PressureInputSignalTypeId, ActionHelper.SetIntValue(value-1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи типа входного сигнала давления контура 2 (PNU 12327)
        /// </summary>
        public byte[] SetEcl310PressureInputSignalType2Id(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetEcl310PressureInputSignalType2Id, ActionHelper.SetIntValue(value-1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени профилактики насоса ГВС (PNU 12022)
        /// </summary>
        public byte[] SetHwsPumpTrainingTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPumpTrainingTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи количества насосов (PNU 10326)
        /// </summary>
        public byte[] SetPumpCount(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPumpCount,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры отключения отопления контура 2 (PNU 12179)
        /// </summary>
        public byte[] SetHwsHeatingOffTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsHeatingOffTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой комнатной дневной температуры контура 2 (PNU 12180)
        /// </summary>
        public byte[] SetHsComfortRoomTemperatureCircuit2(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsComfortRoomTemperatureCircuit2,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи желаемой комнатной ночной температуры контура 2 (PNU 12181)
        /// </summary>
        public byte[] SetHsSavingRoomTemperatureCircuit2(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsSavingRoomTemperatureCircuit2,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимальной температуры открытого воздуха контура 2 (PNU 12031)
        /// </summary>
        public byte[] SetMaxHwsOpenAirTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHwsOpenAirTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимальной температуры обратного трубопровода контура 2 (PNU 12032)
        /// </summary>
        public byte[] SetMinHwsReverseTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsReverseTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимальной температуры открытого воздуха контура 2 (PNU 12033)
        /// </summary>
        public byte[] SetMinHwsOpenAirTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinHwsOpenAirTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимальной температуры обратного трубопровода контура 2 (PNU 12034)
        /// </summary>
        public byte[] SetMaxHwsReverseTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxHwsReverseTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи значения использования внешего сигнала в контуре 1
        /// </summary>
        public byte[] SetHsExternalSignal(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsExternalSignal, ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ограничения температуры контура 1 (компенсация т.1) (PNU 11060)
        /// </summary>
        public byte[] SetHsCompensation1Temperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation1Temperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ограничения температуры контура 1 (компенсация т.2) (PNU 11064)
        /// </summary>
        public byte[] SetHsCompensation2Temperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation2Temperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени оптимизации контура 1 (компенсация т.1) (PNU 11061)
        /// </summary>
        public byte[] SetHsCompensation1OptimizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation1OptimizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени оптимизации контура 1 (компенсация т.2) (PNU 11065)
        /// </summary>
        public byte[] SetHsCompensation2OptimizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation2OptimizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимального влияния контура 1 (компенсация т.1) (PNU 11062)
        /// </summary>
        public byte[] SetHsCompensation1MaxInfluence(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation1MaxInfluence, ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи максимального влияния контура 1 (компенсация т.2) (PNU 11066)
        /// </summary>
        public byte[] SetHsCompensation2MaxInfluence(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation2MaxInfluence,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимального влияния контура 1 (компенсация т.1) (PNU 11063)
        /// </summary>
        public byte[] SetHsCompensation1MinInfluence(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation1MinInfluence,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимального влияния контура 1 (компенсация т.2) (PNU 11067)
        /// </summary>
        public byte[] SetHsCompensation2MinInfluence(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsCompensation2MinInfluence,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи коэффициента максимального влияния ветра (PNU 11057)
        /// </summary>
        public byte[] SetHsMaxWindInfluence(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsMaxWindInfluence,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи фильтра ветра (PNU 11081)
        /// </summary>
        public byte[] SetHsWindFilter(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsWindFilter,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ограничения ветра (PNU 11099)
        /// </summary>
        public byte[] SetHsWindLimit(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsWindLimit,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи ограничения температуры обратного трубопровода контура 1 (PNU 11030)
        /// </summary>
        public byte[] SetHsLimitReverseTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHsLimitReverseTemperature,
               ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи заданной балансовой температуры (PNU 11008)
        /// </summary>
        public byte[] SetAdjustedBalanceTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAdjustedBalanceTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи коэффициента мертвой зоны
        ///  </summary>
        public byte[] SetDeadBand(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetDeadBand,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи скорости адаптации комнатной температуры, контур 1 (PNU 11015)
        /// </summary>
        public byte[] SetOptimizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи скорости адаптации комнатной температуры, контур 2 (PNU 12015)
        /// </summary>
        public byte[] SetOptimizationTimeCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationTimeCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи предельной температуры замерзания (PNU 11108)
        /// </summary>
        public byte[] SetLimitFreezeTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetLimitFreezeTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи мин. влияния предельной безопасной температуры (PNU 11105)
        /// </summary>
        public byte[] SetMinLimitFreezeInfluence(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinLimitFreezeInfluence,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени оптимизации предельной безопасной температуры (PNU 11107)
        /// </summary>
        public byte[] SetLimitFreezeOptimizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetLimitFreezeOptimizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени защиты двигателя (PNU 11174)
        /// </summary>
        public byte[] SetMotorProtection(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMotorProtection,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени защиты двигателя регулятора 2 (PNU 12174)
        /// </summary>
        public byte[] SetMotorProtection2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMotorProtection2, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки максимального выходного напряжения (PNU 12165)
        /// </summary>
        public byte[] SetMaxOutputVoltage(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMaxOutputVoltage,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки минимального выходного напряжения (PNU 12167)
        /// </summary>
        public byte[] SetMinOutputVoltage(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinOutputVoltage,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для установки реверса (PNU 12171)
        /// </summary>
        public byte[] SetReverse(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetReverse, ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи задержки включения вентилятора (PNU 11086)
        /// </summary>
        public byte[] SetFanDelay(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFanDelay, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи задержки включения вспомогательного оборудования (PNU 11087)
        /// </summary>
        public byte[] SetPermissibleDelay(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPermissibleDelay,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи функции выхода вентилятора (PNU 11088)
        /// </summary>
        public byte[] SetFanOutputFunction(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFanOutputFunction,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи функции выхода вспомогательного оборудования (заслонки) (PNU 11089)
        /// </summary>
        public byte[] SetFlapOutputFunction(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlapOutputFunction,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи дополнительной функции реле 3 (PNU 11090)
        /// </summary>
        public byte[] SetRelay3Function(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetRelay3Function,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи программы реле 2 (PNU 11091)
        /// </summary>
        public byte[] SetRelay2Programm(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetRelay2Programm,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи коэфффициента разницы заданных комнатных температур (PNU 11027)
        /// </summary>
        public byte[] SetRoomTemperaturesDiff(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetRoomTemperaturesDiff,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры защиты от замерзания (PNU 11077)
        /// </summary>
        public byte[] SetFrostProtectionTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFrostProtectionTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи функции вентилятора (PNU 11137)
        /// </summary>
        public byte[] SetFanFunction(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFanFunction,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи фильтра S4 (PNU 10304)
        /// </summary>
        public byte[] SetS4Filter(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetS4Filter, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи адреса ECA (PNU 11010)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetEcaAddressId(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetEcaAddressId,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи адреса ECA, контур 2 (PNU 12010)
        /// </summary>
        public byte[] SetEcaAddressCircuit2Id(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetEcaAddressCircuit2Id,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага полного отключения, контур 1 (PNU 11021)
        /// </summary>
        public byte[] SetBlackout(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetBlackout,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага полного отключения, контур 2 (PNU 12021)
        /// </summary>
        public byte[] SetBlackoutCircuit2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetBlackoutCircuit2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени перехода между режимами (PNU 11082)
        /// </summary>
        public byte[] SetTransitionModeTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetTransitionModeTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры защиты от замерзания (PNU 11093)
        /// </summary>
        public byte[] SetFrostProtectionTemperature2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFrostProtectionTemperature2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага выбора компенсационной температуры (PNU 11140)
        /// </summary>
        public byte[] SetSelectionCompensationTemperature(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetSelectionCompensationTemperature,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи внешнего входа ECL 210, контур 1 (PNU 11141)
        /// </summary>
        public byte[] SetExternalInputEcl210(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetExternalInputEcl210,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи внешнего входа ECL 210, контур 2 (PNU 12141)
        /// </summary>
        public byte[] SetExternalInputEcl210Circuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetExternalInputEcl210Circuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи режима внешней перенастройки, контур 1 (PNU 11142)
        /// </summary>
        public byte[] SetExternalOverrideModeId(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetExternalOverrideModeId,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи режима внешней перенастройки, контур 2 (PNU 12142)
        /// </summary>
        public byte[] SetExternalOverrideModeCircuit2Id(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetExternalOverrideModeCircuit2Id,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага посылки заданной температуры (PNU 11500)
        /// </summary>
        public byte[] SetSendPredeterminedTemperature(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetSendPredeterminedTemperature,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи аварийной температуры замерзания S6 (PNU 11676)
        /// </summary>
        public byte[] SetAccidentS6FreezingTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentS6FreezingTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи аварийной температуры замерзания S5 (PNU 11656)
        /// </summary>
        public byte[] SetAccidentS5FreezingTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentS5FreezingTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи аварийного значения термостата замерзания (PNU 11616)
        /// </summary>
        public byte[] SetAccidentFrostThermostat(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentFrostThermostat,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи задержки аварии термостата замерзания (PNU 11617)
        /// </summary>
        public byte[] SetAccidentFrostThermostatDelay(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentFrostThermostatDelay,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи аварийного значения термостата пожаробезопасности
        /// (PNU 11636)
        /// </summary>
        public byte[] SetAccidentFireSafetyThermostat(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentFireSafetyThermostat,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи задержки аварии термостата пожаробезопасности (PNU 11637)
        /// </summary>
        public byte[] SetAccidentFireSafetyThermostatDelay(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentFireSafetyThermostatDelay,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхней разницы температурного монитора, контур 1 (PNU 11147)
        /// </summary>
        public byte[] SetUpperDifferenceTemperatureMonitor(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetUpperDifferenceTemperatureMonitor,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхней разницы температурного монитора, контур 2 (PNU 12147)
        /// </summary>
        public byte[] SetUpperDifferenceTemperatureMonitorCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetUpperDifferenceTemperatureMonitorCircuit2,
                ActionHelper.SetIntValue(value));
        }


        /// <summary>
        /// Возвращает пакет байтов для записи нижней разницы температурного монитора, контур 1 (PNU 11148)
        /// </summary>
        public byte[] SetLowerDifferenceTemperatureMonitor(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetLowerDifferenceTemperatureMonitor,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижней разницы температурного монитора, контур 2 (PNU 12148)
        /// </summary>
        public byte[] SetLowerDifferenceTemperatureMonitorCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetLowerDifferenceTemperatureMonitorCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи паузы температурного монитора, контур 1 (PNU 11149)
        /// </summary>
        public byte[] SetPauseTemperatureMonitor(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPauseTemperatureMonitor,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи паузы температурного монитора, контур 2 (PNU 12149)
        /// </summary>
        public byte[] SetPauseTemperatureMonitorCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPauseTemperatureMonitorCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимальной температуры температурного монитора, контур 1 (PNU 11150)
        /// </summary>
        public byte[] SetMinTemperatureMonitor(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinTemperatureMonitor,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи минимальной температуры температурного монитора, контур 2 (PNU 12150)
        /// </summary>
        public byte[] SetMinTemperatureMonitorCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetMinTemperatureMonitorCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи приоритета ограничения температуры обратки (PNU 11085)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetLimitReversePriority(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetLimitReversePriority,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи приоритета ограничения температуры обратки (контур 2) (PNU 12085)
        /// </summary>
        /// <param name="value">Новое значение</param>
        public byte[] SetLimitReversePriorityCircuit2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetLimitReversePriorityCircuit2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи смещения (PNU 11017)
        /// </summary>
        public byte[] SetOffset(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOffset, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага тренировки клапана, контур 1 (PNU 11023)
        /// </summary>
        public byte[] SetFlapTrainingCurciut1(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlapTrainingCirciut1,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага тренировки клапана, контур 2 (PNU 12023)
        /// </summary>
        public byte[] SetFlapTrainingCurciut2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlapTrainingCirciut2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага приоритета ГВС, контур 1 (PNU 11052)
        /// </summary>
        public byte[] SetHwsPriorityCurcuit1(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPriorityCircuit1,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага приоритета ГВС, контур 2 (PNU 12052)
        /// </summary>
        public byte[] SetHwsPriorityCurcuit2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHwsPriorityCircuit2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры защиты от замерзания, контур 2 (PNU 12077)
        /// </summary>
        public byte[] SetFrostProtectionTemperatureCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFrostProtectionTemperatureCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры тепловой нагрузки, контур 1 (PNU 11078)
        /// </summary>
        public byte[] SetThermalLoadTemperatureCircuit1(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetThermalLoadTemperatureCircuit1,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры тепловой нагрузки, контур 2 (PNU 12078)
        /// </summary>
        public byte[] SetThermalLoadTemperatureCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetThermalLoadTemperatureCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи требуемой температуры защиты от замерзания, контур 2 (PNU 12093)
        /// </summary>
        public byte[] SetFrostProtectionTemperature2Circuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFrostProtectionTemperature2Circuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени оптимизации ограничения расхода, контур 1 (PNU 11112)
        /// </summary>
        public byte[] SetFlowLimitationOptimizationTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationOptimizationTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени оптимизации ограничения расхода, контур 2 (PNU 12112)
        /// </summary>
        public byte[] SetFlowLimitationOptimizationTimeCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationOptimizationTimeCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи фильтра ввода ограничения расхода, контур 1 (PNU 11113)
        /// </summary>
        public byte[] SetFlowLimitationInputFilter(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationInputFilter,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи фильтра ввода ограничения расхода, контур 2 (PNU 12113)
        /// </summary>
        public byte[] SetFlowLimitationInputFilterCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationInputFilterCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи импульса ограничения расхода, контур 1 (PNU 11114)
        /// </summary>
        public byte[] SetFlowLimitationImpulseWeight(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationImpulseWeight,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи импульса ограничения расхода, контур 2 (PNU 12114)
        /// </summary>
        public byte[] SetFlowLimitationImpulseWeightCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationImpulseWeightCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи единицы измерения ограничения расхода, контур 1 (PNU 11115)
        /// </summary>
        public byte[] SetFlowLimitationUnitId(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationUnitId,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи единицы измерения ограничения расхода, контур 2 (PNU 12115)
        /// </summary>
        public byte[] SetFlowLimitationUnitCircuit2Id(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationUnitCircuit2Id,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. расхода обратки Y2, контур 1 (PNU 11116)
        /// </summary>
        public byte[] SetFlowLimitationMaxReverseRate(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationMaxReverseRate,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. расхода обратки Y2, контур 2 (PNU 12116)
        /// </summary>
        public byte[] SetFlowLimitationMaxReverseRateCircuit2(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationMaxReverseRateCircuit2,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи мин. расхода обратки Y2, контур 1 (PNU 11117)
        /// </summary>
        public byte[] SetFlowLimitationMinReverseRate(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationMinReverseRate,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи мин. расхода обратки Y2, контур 2 (PNU 12117)
        /// </summary>
        public byte[] SetFlowLimitationMinReverseRateCircuit2(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationMinReverseRateCircuit2,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи мин. нар. температуры X2, контур 1 (PNU 11118)
        /// </summary>
        public byte[] SetFlowLimitationMinOpenAirTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationMinOpenAirTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи мин. нар. температуры X2, контур 2 (PNU 12118)
        /// </summary>
        public byte[] SetFlowLimitationMinOpenAirTemperatureCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress,
                _commands.SetFlowLimitationMinOpenAirTemperatureCircuit2, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. нар. температуры X1, контур 1 (PNU 11119)
        /// </summary>
        public byte[] SetFlowLimitationMaxOpenAirTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationMaxOpenAirTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи макс. нар. температуры X1, контур 2 (PNU 12119)
        /// </summary>
        public byte[] SetFlowLimitationMaxOpenAirTemperatureCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress,
                _commands.SetFlowLimitationMaxOpenAirTemperatureCircuit2, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи типа входа ограничения расхода, контур 1 (PNU 11109)
        /// </summary>
        public byte[] SetFlowLimitationInputTypeId(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationInputTypeId,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи типа входа ограничения расхода, контур 2 (PNU 12109)
        /// </summary>
        public byte[] SetFlowLimitationInputTypeCircuit2Id(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationInputTypeCircuit2Id,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры автоотключения, контур 1 (PNU 11011)
        /// </summary>
        public byte[] SetOptimizationAutoPowerOffTemperature(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationAutoPowerOffTemperature,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры автоотключения, контур 2 (PNU 12011)
        /// </summary>
        public byte[] SetOptimizationAutoPowerOffTemperatureCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress,
                _commands.SetOptimizationAutoPowerOffTemperatureCircuit2, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи натопа, контур 1 (PNU 11012)
        /// </summary>
        public byte[] SetOptimizationBoost(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationBoost,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи натопа, контур 2 (PNU 12012)
        /// </summary>
        public byte[] SetOptimizationBoostCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationBoostCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени натопа, контур 1 (PNU 11013)
        /// </summary>
        public byte[] SetOptimizationBoostTime(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationBoostTime,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи времени натопа, контур 2 (PNU 12013)
        /// </summary>
        public byte[] SetOptimizationBoostTimeCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationBoostTimeCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи оптимизатора, контур 1 (PNU 11014)
        /// </summary>
        public byte[] SetOptimizationOptimum(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationOptimum,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи оптимизатора, контур 2 (PNU 12014)
        /// </summary>
        public byte[] SetOptimizationOptimumCircuit2(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationOptimumCircuit2,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага задержки отключения, контур 1 (PNU 11026)
        /// </summary>
        public byte[] SetOptimizationOffDelay(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationOffDelay,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага задержки отключения, контур 2 (PNU 12026)
        /// </summary>
        public byte[] SetOptimizationOffDelayCircuit2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationOffDelayCircuit2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи базиса оптимизации, контур 1 (PNU 11020)
        /// </summary>
        public byte[] SetOptimizationBasisId(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationBasisId,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи базиса оптимизации, контур 2 (PNU 12020)
        /// </summary>
        public byte[] SetOptimizationBasisCircuit2Id(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetOptimizationBasisCircuit2Id,
                ActionHelper.SetIntValue(value - 1));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи требуемой температуры подачи в режиме комфорт (PNU 11018)
        /// </summary>
        public byte[] SetRequiredComfortFlowTemperature(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetRequiredComfortFlowTemperature,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи требуемой температуры подачи в режиме эконом (PNU 11019)
        /// </summary>
        public byte[] SetRequiredEconomyFlowTemperature(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetRequiredEconomyFlowTemperature,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи предельного значения ограничения расхода (PNU 11111)
        /// </summary>
        public byte[] SetFlowLimitationLimit(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationLimit,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи предельного значения ограничения расхода, контур 2 (PNU 12111)
        /// </summary>
        public byte[] SetFlowLimitationLimitCircuit2(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetFlowLimitationLimitCircuit2,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нагрузки охлаждения, контур 1 (PNU 11070)
        /// </summary>
        public byte[] SetCoolingLoadTemperatureCircuit1(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetCoolingLoadTemperatureCircuit1, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры в режиме ожидания, контур 1 (PNU 11092)
        /// </summary>
        public byte[] SetExpectationFlowTemperatureCircuit1(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetExpectationFlowTemperatureCircuit1, ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи коэффициента параллельной работы, контур 1 (PNU 11043)
        /// </summary>
        public byte[] SetParallelOperationCircuit1(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetParallelOperationCircuit1,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага автонастройки, контур 2 (PNU 12173)
        /// </summary>
        public byte[] SetAutotuningCircuit2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAutotuningCircuit2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи температуры подачи сигнализации, контур 1 (PNU 11079)
        /// </summary>
        public byte[] SetSignalizationFlowTemperatureCircuit1(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetSignalizationFlowTemperatureCircuit1,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи паузы сигнализации, контур 1 (PNU 11080)
        /// </summary>
        public byte[] SetSignalizationPauseCircuit1(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetSignalizationPauseCircuit1,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхней аварийной границы, контур 1 (PNU 11614) 
        /// </summary>
        public byte[] SetAccidentTopLimit(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentTopLimit,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижней аварийной границы, контур 1 (PNU 11615)
        /// </summary>
        public byte[] SetAccidentBottomLimit(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentBottomLimit,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижн. X, контур 1 (PNU 11607)
        /// </summary>
        public byte[] SetPressureBottomXCircuit1(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPressureBottomXCircuit1,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхн. X, контур 1 (PNU 11608)
        /// </summary>
        public byte[] SetPressureTopXCircuit1(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPressureTopXCircuit1,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи нижн. Y, контур 1 (PNU 11609)
        /// </summary>
        public byte[] SetPressureBottomYCircuit1(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPressureBottomYCircuit1,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи верхн. Y, контур 1 (PNU 11610)
        /// </summary>
        public byte[] SetPressureTopYCircuit1(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPressureTopYCircuit1,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага сброса аварии насосов, контур 1 (PNU 11315)
        /// </summary>
        public byte[] SetAccidentPumpsCircuit1(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentPumpsCircuit1,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага сброса аварии насосов, контур 2 (PNU 12315)
        /// </summary>
        public byte[] SetAccidentPumpsCircuit2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentPumpsCircuit2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага сброса аварии подпитки, контур 1 (PNU 11324)
        /// </summary>
        public byte[] SetAccidentMakeupCircuit1(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentMakeupCircuit1,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи флага сброса аварии подпитки, контур 2 (PNU 12324)
        /// </summary>
        public byte[] SetAccidentMakeupCircuit2(bool value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetAccidentMakeupCircuit2,
                ActionHelper.SetBoolValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи угла наклона температурного графика, контур 1 (PNU 11175)
        /// </summary>
        public byte[] SetHeatCurveAngle(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetHeatCurveAngle,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11173
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11173(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11173,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11094
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11094(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11094,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11095
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11095(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11095,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11096
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11096(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11096,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11097
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11097(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11097,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11076
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11076(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11076,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11040
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11040(int value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11040,
                ActionHelper.SetIntValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11190
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11190(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11190,
                ActionHelper.SetEcl310DoubleValue(value));
        }

        /// <summary>
        /// Возвращает пакет байтов для записи PNU 11191
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] SetPnu11191(double value)
        {
            return _modbusPackageHelper.GetCommand(_deviceAddress, _commands.SetPnu11191,
                ActionHelper.SetEcl310DoubleValue(value));
        }
    }
}


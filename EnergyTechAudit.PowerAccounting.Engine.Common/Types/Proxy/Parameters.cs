
namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy
{
    /// <summary>
    /// Параметры, измеряемые прибором (Dictionaries.Parameter)
    /// </summary>
    public enum Parameters
    {
        /// <summary>
        /// Давление в подающем трубопроводе системы отопления
        /// </summary>
        HeatSysPressureSupplyPipe = 7,
        /// <summary>
        /// Температура воды в подающем трубопроводе
        /// </summary>
        HeatSysTemperSupplyPipe = 8,
        /// <summary>
        /// Объемный расход в подающем трубопроводе
        /// </summary>
        HeatSysVolumeFlowSupplyPipe = 9,
        /// <summary>
        /// Масса воды в подающем трубопроводе
        /// </summary>
        HeatSysMassSupplyPipe = 10,
        /// <summary>
        /// Тепловая энергия полная
        /// </summary>
        HeatSysHeatTotal = 11,
        /// <summary>
        /// Избыточое давление в обратном трубопроводе
        /// </summary>
        HeatSysPressureReturnPipe = 12,
        /// <summary>
        /// Температура воды в обратном трубопроводе
        /// </summary>
        HeatSysTemperReturnPipe = 13,
        /// <summary>
        /// Объемный расход в обратном трубопроводе
        /// </summary>
        HeatSysVolumeFlowReturnPipe = 14,
        /// <summary>
        /// Масса воды в обратном трубопроводе
        /// </summary>
        HeatSysMassReturnPipe = 15,
        /// <summary>
        /// Тепловая энергия в трубопроводе ГВС
        /// </summary>
        HeatSysHeatHwsPipe = 16,
        /// <summary>
        /// Разность температур воды
        /// </summary>
        HeatSysTemperDiff = 17,
        /// <summary>
        /// Температура воды в подающем трубопроводе ГВС
        /// </summary>
        HeatSysTemperHwsSupplyPipe = 20,
        /// <summary>
        /// Объем воды в подающем трубопроводе
        /// </summary>
        HeatSysVolumeSupplyPipe = 21,
        /// <summary>
        /// Объем воды в обратном трубопроводе
        /// </summary>
        HeatSysVolumeReturnPipe = 22,
        /// <summary>
        /// Объем воды в трубопроводе ГВС
        /// </summary>
        HeatSysVolumeHwsPipe = 23,
        /// <summary>
        /// Масса воды в трубопроводе ГВС
        /// </summary>
        HeatSysMassHwsPipe = 24,
        /// <summary>
        /// Масса воды, отобранной из системы
        /// </summary>
        HeatSysMassSelected = 25,
        /// <summary>
        /// Температура холодной воды
        /// </summary>
        HeatSysTemperColdWater = 26,
        /// <summary>
        /// Температура наружного воздуха
        /// </summary>
        HeatSysTemperOutdoorAir = 27,
        /// <summary>
        /// Время нормальной работы
        /// </summary>
        HeatSysTimeNormal = 28,
        /// <summary>
        /// Время отсутствия счета
        /// </summary>
        HeatSysTimeDenial = 29,
        /// <summary>
        /// Время наработки прибора
        /// </summary>
        ElectroSysTimeWorking = 31,
        /// <summary>
        /// Суммарная накопленная электроэнергия
        /// </summary>
        ElectroSysElectricPowerSummary = 32,
        /// <summary>
        /// Мгновенная полная потребляемая мощность
        /// </summary>
        ElectroSysPowerInstant = 33,
        /// <summary>
        /// Мгновенное напряжение
        /// </summary>
        ElectroSysVoltageInstant = 34,
        /// <summary>
        /// Мгновенный потребляемый ток
        /// </summary>
        ElectroSysCurrentInstant = 35,
        /// <summary>
        /// Мгновенная активная потребляемая мощность
        /// </summary>
        ElectroSysPowerActiveInstant = 36,
        /// <summary>
        /// Мгновенная реактивная потребляемая мощность
        /// </summary>
        ElectroSysPowerReactiveInstant = 37,
        /// <summary>
        /// Коэффициент мощности
        /// </summary>
        ElectroSysPowerFactorInstant = 38,
        /// <summary>
        /// Частота
        /// </summary>
        ElectroSysFrequencyInstant = 39,
        /// <summary>
        /// Суммарный объем потребленной холодной воды
        /// </summary>
        CwsVolumeColdWater = 40,
        /// <summary>
        /// Суммарный объем потребленной горячей воды
        /// </summary>
        HwsVolumeHotWaterSummary = 41,
        /// <summary>
        /// Суммарный объем потребленного газа
        /// </summary>
        GasSysVolumeGasSummary = 42,
        /// <summary>
        /// Температура воздуха в помещении
        /// </summary>
        HeatSysTemperIndoorAir = 43,
        /// <summary>
        /// Температура воды в обратном трубопроводе ГВС
        /// </summary>
        HeatSysTemperHwsReturnPipe = 44,
        /// <summary>
        /// Рассчитанная температура воздуха в помещении
        /// </summary>
        HeatSysTemperCalcIndoorAir = 45,
        /// <summary>
        /// Рассчитанная температура воды в подающем трубопроводе
        /// </summary>
        HeatSysTemperCalcSupplyPipe = 46,
        /// <summary>
        /// Рассчитанная температура воды в обратном трубопроводе
        /// </summary>
        HeatSysTemperCalcReturnPipe = 47,
        /// <summary>
        /// Рассчитанная температура воды в подающем трубопроводе ГВС
        /// </summary>
        HeatSysTemperCalcHwsSupplyPipe = 48,
        /// <summary>
        /// Рассчитанная температура воды в обратном трубопроводе ГВС
        /// </summary>
        HeatSysTemperCalcHwsReturnPipe = 49,
        /// <summary>
        /// Рассчитанное избыточное давление в обратном трубопроводе
        /// </summary>
        HeatSysPressureCalcReturnPipe = 50,
        /// <summary>
        /// Контрольное значение температуры воды в обратном трубопроводе
        /// </summary>
        HeatSysTemperControlReturnPipe = 51,
        /// <summary>
        /// Контрольное рассчитанное значение температуры воды в обратном трубопроводе
        /// </summary>
        HeatSysTemperControlCalcReturnPipe = 52,
        /// <summary>
        /// Дифференциальное реле давления в системе отопления
        /// </summary>
        HeatSysPressureDifferentialSwitch = 53,
        /// <summary>
        /// Дифференциальное реле давления ГВС
        /// </summary>
        HeatSysPressureHwsDifferentialSwitch = 54,
        /// <summary>
        /// Аварийная ситуация с насосом
        /// </summary>
        HeatSysPumpFailure = 55,
        /// <summary>
        /// Температура первичного контура
        /// </summary>
        HeatSysTemperPrimaryCurcuit = 56,
        /// <summary>
        /// Давление на входе контура системы отопления
        /// </summary>
        HeatSysPressurePrimaryCurcuitInput = 57,
        /// <summary>
        /// Давление на выходе контура системы отопления
        /// </summary>
        HeatSysPressurePrimaryCurcuitOutput = 58,
        /// <summary>
        /// Давление на входе контура ГВС
        /// </summary>
        HeatSysPressureSecondaryCurcuitInput = 59,
        /// <summary>
        /// Давление на выходе контура ГВС
        /// </summary>
        HeatSysPressureSecondaryCurcuitOutput = 60,
        /// <summary>
        /// Скорость ветра
        /// </summary>
        HeatSysVelocityWind = 61,
        /// <summary>
        /// Объем воды через импульсный вход
        /// </summary>
        HeatSysVolumeImpulseInput = 62,
        /// <summary>
        /// Объем воды через импульсный вход 2
        /// </summary>
        HeatSysVolumeImpulseReturnPipe = 63,
        /// <summary>
        /// Масса воды через импульсный вход 2
        /// </summary>
        HeatSysMassImpulseReturnPipe = 64,
        /// <summary>
        /// Объем воды через доп. импульсный вход
        /// </summary>
        HeatSysVolumeImpulseSupplyPipe = 65,
        /// <summary>
        /// Масса воды через доп. импульсный вход
        /// </summary>
        HeatSysMassImpulseSupplyPipe = 66,
        /// <summary>
        /// Индикатор пустой трубы
        /// </summary>
        HeatSysIndicatorEmptyPipe = 67,
        /// <summary>
        /// Индикатор отрицательного теплового потока
        /// </summary>
        HeatSysIndicatorNegativeHeatFlow = 68,
        /// <summary>
        /// Масса воды в трубопроводе подпитки
        /// </summary>
        HeatSysMassFeedPipe = 69,
        /// <summary>
        /// Массовый расход в подающем трубопроводе
        /// </summary>
        HeatSysMassFlowSupplyPipe = 70,
        /// <summary>
        /// Массовый расход в обратном трубопроводе
        /// </summary>
        HeatSysMassFlowReturnPipe = 71,
        /// <summary>
        /// Массовый расход через имульсный вход
        /// </summary>
        HeatSysMassFlowImpulseInput = 72,
        /// <summary>
        /// Избыточное давление через импульсный вход
        /// </summary>
        HeatSysPressureImpulseInput = 73,
        /// <summary>
        /// Тепловая мощность
        /// </summary>
        HeatSysThermalPower = 74,
        /// <summary>
        /// Температура внутри прибора
        /// </summary>
        HeatSysTemperInsideDevice = 75,
        /// <summary>
        /// Температура воды в подающем трубопроводе (потребитель 1)
        /// </summary>
        HeatSysTemperConsumer1SupplyPipe = 76,
        /// <summary>
        /// Температура воды в подающем трубопроводе (потребитель 2)
        /// </summary>
        HeatSysTemperConsumer2SupplyPipe = 77,
        /// <summary>
        /// Температура воды в подающем трубопроводе (потребитель 3)
        /// </summary>
        HeatSysTemperConsumer3SupplyPipe = 78,
        /// <summary>
        /// Температура воды в обратном трубопроводе (потребитель 1)
        /// </summary>
        HeatSysTemperConsumer1ReturnPipe = 79,
        /// <summary>
        /// Температура воды в обратном трубопроводе (потребитель 2)
        /// </summary>
        HeatSysTemperConsumer2ReturnPipe = 80,
        /// <summary>
        /// Температура воды в обратном трубопроводе (потребитель 3)
        /// </summary>
        HeatSysTemperConsumer3ReturnPipe = 81,

        /// <summary>
        /// Объемный расход в подающем трубопроводе (потребитель 1)
        /// </summary>
        HeatSysVolumeFlowConsumer1SupplyPipe = 82,
        /// <summary>
        /// Объемный расход в подающем трубопроводе (потребитель 2)
        /// </summary>
        HeatSysVolumeFlowConsumer2SupplyPipe = 83,
        /// <summary>
        /// Объемный расход в подающем трубопроводе (потребитель 3)
        /// </summary>
        HeatSysVolumeFlowConsumer3SupplyPipe = 84,
        /// <summary>
        /// Объемный расход в обратном трубопроводе (потребитель 1)
        /// </summary>
        HeatSysVolumeFlowConsumer1ReturnPipe = 85,
        /// <summary>
        /// Объемный расход в обратном трубопроводе (потребитель 2)
        /// </summary>
        HeatSysVolumeFlowConsumer2ReturnPipe = 86,
        /// <summary>
        /// Объемный расход в обратном трубопроводе (потребитель 3)
        /// </summary>
        HeatSysVolumeFlowConsumer3ReturnPipe = 87,
        /// <summary>
        /// Давление теплоносителя в подающем трубопроводе (потребитель 1)
        /// </summary>
        HeatSysPressureConsumer1SupplyPipe = 88,
        /// <summary>
        /// Давление теплоносителя в подающем трубопроводе (потребитель 2)
        /// </summary>
        HeatSysPressureConsumer2SupplyPipe = 89,
        /// <summary>
        /// Давление теплоносителя в подающем трубопроводе (потребитель 3)
        /// </summary>
        HeatSysPressureConsumer3SupplyPipe = 90,
        /// <summary>
        /// Давление теплоносителя в обратном трубопроводе (потребитель 1)
        /// </summary>
        HeatSysPressureConsumer1ReturnPipe = 91,
        /// <summary>
        /// Давление теплоносителя в обратном трубопроводе (потребитель 2)
        /// </summary>
        HeatSysPressureConsumer2ReturnPipe = 92,
        /// <summary>
        /// Давление теплоносителя в обратном трубопроводе (потребитель 3)
        /// </summary>
        HeatSysPressureConsumer3ReturnPipe = 93,

        /// <summary>
        /// Температура горячей воды в подающем трубопроводе (потребитель 1)
        /// </summary>
        HwsTemperConsumer1SupplyPipe = 94,
        /// <summary>
        /// Температура горячей воды в подающем трубопроводе (потребитель 2)
        /// </summary>
        HwsTemperConsumer2SupplyPipe = 95,
        /// <summary>
        /// Температура горячей воды в подающем трубопроводе (потребитель 3)
        /// </summary>
        HwsTemperConsumer3SupplyPipe = 96,
        /// <summary>
        /// Температура горячей воды в обратном трубопроводе (потребитель 1)
        /// </summary>
        HwsTemperConsumer1ReturnPipe = 97,
        /// <summary>
        /// Температура горячей воды в обратном трубопроводе (потребитель 2)
        /// </summary>
        HwsTemperConsumer2ReturnPipe = 98,
        /// <summary>
        /// Температура горячей воды в обратном трубопроводе (потребитель 3)
        /// </summary>
        HwsTemperConsumer3ReturnPipe = 99,

        /// <summary>
        /// Объемный расход горячей воды в подающем трубопроводе (потребитель 1)
        /// </summary>
        HwsVolumeFlowConsumer1SupplyPipe = 100,
        /// <summary>
        /// Объемный расход горячей воды в подающем трубопроводе (потребитель 2)
        /// </summary>
        HwsVolumeFlowConsumer2SupplyPipe = 101,
        /// <summary>
        /// Объемный расход горячей воды в подающем трубопроводе (потребитель 3)
        /// </summary>
        HwsVolumeFlowConsumer3SupplyPipe = 102,

        /// <summary>
        /// Объемный расход горячей воды в обратном трубопроводе (потребитель 1)
        /// </summary>
        HwsVolumeFlowConsumer1ReturnPipe = 103,
        /// <summary>
        /// Объемный расход горячей воды в обратном трубопроводе (потребитель 2)
        /// </summary>
        HwsVolumeFlowConsumer2ReturnPipe = 104,
        /// <summary>
        /// Объемный расход горячей воды в обратном трубопроводе (потребитель 3)
        /// </summary>
        HwsVolumeFlowConsumer3ReturnPipe = 105,
        /// <summary>
        /// Давление горячей воды в подающем трубопроводе (потребитель 1)
        /// </summary>
        HwsPressureConsumer1SupplyPipe = 106,
        /// <summary>
        /// Давление горячей воды в подающем трубопроводе (потребитель 2)
        /// </summary>
        HwsPressureConsumer2SupplyPipe = 107,
        /// <summary>
        /// Давление горячей воды в подающем трубопроводе (потребитель 3)
        /// </summary>
        HwsPressureConsumer3SupplyPipe = 108,
        /// <summary>
        /// Давление горячей воды в обратном трубопроводе (потребитель 1)
        /// </summary>
        HwsPressureConsumer1ReturnPipe = 109,
        /// <summary>
        /// Давление горячей воды в обратном трубопроводе (потребитель 2)
        /// </summary>
        HwsPressureConsumer2ReturnPipe = 110,
        /// <summary>
        /// Давление горячей воды в обратном трубопроводе (потребитель 3)
        /// </summary>
        HwsPressureConsumer3ReturnPipe = 111,

        MonitoringTemperMeteoOutdoorAir = 5010
    }
}

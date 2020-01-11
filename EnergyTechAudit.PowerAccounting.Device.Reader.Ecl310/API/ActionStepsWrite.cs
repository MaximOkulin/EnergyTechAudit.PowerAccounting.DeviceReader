using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A214;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A230;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A231;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A260;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A266;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A314;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A361;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Attributes.EclApplications.A368;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.API
{
    internal sealed partial class ActionSteps
    {
        /// <summary>
        /// Устанавливает минимальную температуру подачи контура 1
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetMinHsFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальную температуру подачи контура 1
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A3311]
        public void SetMaxHsFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHsFlowTemperature(value), true);
            Wait();
        }        

        /// <summary>
        /// Устанавливает температуру отключения отопления контура 1
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsHeatingOffTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetHsHeatingOffTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsHeatingOffTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает желаемую дневную комнатную температуру контура 1
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsComfortRoomTemperature(double value)
        {
            Transport.CurrentCommand = _commands.SetHsComfortRoomTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsComfortRoomTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает желаемую ночную комнатную температуру контура 1
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsSavingRoomTemperature(double value)
        {
            Transport.CurrentCommand = _commands.SetHsSavingRoomTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsSavingRoomTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальное значение коэффициента влияния комнатной температуры
        /// на контур 1
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetMaxHsInfluenceRoom(double value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsInfluenceRoom;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHsInfluenceRoom(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальное значение коэффициента влияния комнатной температуры
        /// на контур 2
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        [ApplicationBase, A2601]
        public void SetMaxHwsInfluenceRoom(double value)
        {
            Transport.CurrentCommand = _commands.SetMaxHwsInfluenceRoom;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHwsInfluenceRoom(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное значение коэффициента влияния комнатной температуры
        /// на контур 1
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetMinHsInfluenceRoom(double value)
        {
            Transport.CurrentCommand = _commands.SetMinHsInfluenceRoom;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsInfluenceRoom(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное значение коэффициента влияния комнатной температуры
        /// на контур 2
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        [ApplicationBase, A2601]
        public void SetMinHwsInfluenceRoom(double value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsInfluenceRoom;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsInfluenceRoom(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает коэффициент зоны пропорциональности контура 1
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetHsProportionalBand(int value)
        {
            Transport.CurrentCommand = _commands.SetHsProportionalBand;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsProportionalBand(value));
            Wait();
        }

        /// <summary>
        /// Устанавливает постоянную времени интегрирования контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetHsIntegrationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsIntegrationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsIntegrationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время перемещения штока привода контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetHsDriveStockTravelTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsDriveStockTravelTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsDriveStockTravelTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает коэффициент нейтральной зоны контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetHsNeutralZone(int value)
        {
            Transport.CurrentCommand = _commands.SetHsNeutralZone;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsNeutralZone(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает желаемую дневную температуру контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2661, A2662, A2669, A3681, A3682, A3683, A3684]
        public void SetHwsComfortRoomTemperature(double value)
        {
            Transport.CurrentCommand = _commands.SetHwsComfortRoomTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsComfortRoomTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает желаемую ночную температуру контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2661, A2662, A2669, A3681, A3682, A3683, A3684]
        public void SetHwsSavingRoomTemperature(double value)
        {
            Transport.CurrentCommand = _commands.SetHwsSavingRoomTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsSavingRoomTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает новое максимальное значение температуры открытого воздуха контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMaxHsOpenAirTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsOpenAirTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHsOpenAirTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное значение температуры обратного трубопровода контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMinHsReverseTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsReverseTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное значение температуры открытого воздуха контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMinHsOpenAirTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsOpenAirTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsOpenAirTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальное значение температуры обратного трубопровода контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMaxHsReverseTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHsReverseTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальный коэффициент влияния обратки контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetMaxHsInfluenceReverse(double value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsInfluenceReverse;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHsInfluenceReverse(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальный коэффициент влияния обратки контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetMinHsInfluenceReverse(double value)
        {
            Transport.CurrentCommand = _commands.SetMinHsInfluenceReverse;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsInfluenceReverse(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время адаптации температуры в контуре 1
        /// </summary>
        /// <param name="value">Новое значение времени в секундах</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetHsOptimizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsOptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsOptimizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное время активации привода контура 1
        /// </summary>
        /// <param name="value">Новое значение времени в секундах</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2311, A2312, A3311, A3312]
        public void SetMinHsDriveActivationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsDriveActivationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsDriveActivationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при -30
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMinus30FlowTemperature1(int value)
        {
            Transport.CurrentCommand = _commands.SetMinus30FlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinus30FlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при -30 для контура 2
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetMinus30FlowTemperature2(int value)
        {
            Transport.CurrentCommand = _commands.SetMinus30FlowTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinus30FlowTemperature2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при -15
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMinus15FlowTemperature1(int value)
        {
            Transport.CurrentCommand = _commands.SetMinus15FlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinus15FlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при -15 для контура 2
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetMinus15FlowTemperature2(int value)
        {
            Transport.CurrentCommand = _commands.SetMinus15FlowTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinus15FlowTemperature2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при -5
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMinus5FlowTemperature1(int value)
        {
            Transport.CurrentCommand = _commands.SetMinus5FlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinus5FlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при -5 для контура 2
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetMinus5FlowTemperature2(int value)
        {
            Transport.CurrentCommand = _commands.SetMinus5FlowTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinus5FlowTemperature2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при 0
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetZeroFlowTemperature1(int value)
        {
            Transport.CurrentCommand = _commands.SetZeroFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetZeroFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при 0 для контура 2
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetZeroFlowTemperature2(int value)
        {
            Transport.CurrentCommand = _commands.SetZeroFlowTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetZeroFlowTemperature2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при +5
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetPlus5FlowTemperature1(int value)
        {
            Transport.CurrentCommand = _commands.SetPlus5FlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPlus5FlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при +5 для контура 2
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetPlus5FlowTemperature2(int value)
        {
            Transport.CurrentCommand = _commands.SetPlus5FlowTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPlus5FlowTemperature2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при +15
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2301, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetPlus15FlowTemperature1(int value)
        {
            Transport.CurrentCommand = _commands.SetPlus15FlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPlus15FlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение точки температурного графика при +15 для контура 2
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetPlus15FlowTemperature2(int value)
        {
            Transport.CurrentCommand = _commands.SetPlus15FlowTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPlus15FlowTemperature2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает ограничение температуры обратки контура 2
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2661, A2662, A2669, A3681, A3682, A3683, A3684]
        public void SetHwsLimitReverseTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsLimitReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsLimitReverseTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальный коэффициент влияния обратного трубопровода контура 2
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetMaxHwsInfluenceReverse(double value)
        {
            Transport.CurrentCommand = _commands.SetMaxHwsInfluenceReverse;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHwsInfluenceReverse(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальный коэффициент влияния обратного контура ГВС
        /// </summary>
        /// <param name="value">Новое значение коэффициента</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetMinHwsInfluenceReverse(double value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsInfluenceReverse;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsInfluenceReverse(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время адаптации температуры в ГВС
        /// </summary>
        /// <param name="value">Новое значение времени адаптации в секундах</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetHwsOptimizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsOptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsOptimizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальную температуру подачи ГВС
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetMinHwsFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальную температуру подачи ГВС
        /// </summary>
        /// <param name="value">Новое значение температуры</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetMaxHwsFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHwsFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHwsFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает зону пропорциональности ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2144, A2145, A3141, A3142]
        public void SetHwsProportionalBand(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsProportionalBand;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsProportionalBand(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает постоянную времени интегрирования ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2144, A2145, A3141, A3142]
        public void SetHwsIntegrationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsIntegrationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsIntegrationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время перемещения штока привода ГВС
        /// </summary>
        /// <param name="value">Время перемещения в секундах</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2144, A2145, A3141, A3142]
        public void SetHwsDriveStockTravelTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsDriveStockTravelTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsDriveStockTravelTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает коэффициент нейтральной зоны ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2144, A2145, A3141, A3142]
        public void SetHwsNeutralZone(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsNeutralZone;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsNeutralZone(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное время активации привода ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2144, A2145, A3141, A3142]
        public void SetMinHwsDriveActivationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsDriveActivationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsDriveActivationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает режим работы контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetCircuit1OperatingMode(int value)
        {
            Transport.CurrentCommand = _commands.SetCircuit1OperatingMode;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetCircuit1OperatingMode(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает режим работы контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetCircuit2OperatingMode(int value)
        {
            Transport.CurrentCommand = _commands.SetCircuit2OperatingMode;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetCircuit2OperatingMode(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает статус работы контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetCircuit1OperatingStatus(int value)
        {
            Transport.CurrentCommand = _commands.SetCircuit1OperatingStatus;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetCircuit1OperatingStatus(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает статус работы контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A2302, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetCircuit2OperatingStatus(int value)
        {
            Transport.CurrentCommand = _commands.SetCircuit2OperatingStatus;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetCircuit2OperatingStatus(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время принудительного открытия клапана ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2662]
        public void SetForcedOpeningTime(double value)
        {
            Transport.CurrentCommand = _commands.SetForcedOpeningTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetForcedOpeningTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время принудительного закрытия клапана ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2662]
        public void SetForcedClosingTime(double value)
        {
            Transport.CurrentCommand = _commands.SetForcedClosingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetForcedClosingTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает холостое время ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2662]
        public void SetIdleTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsIdleTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsIdleTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает выбор температуры подачи ГВС
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2662]
        public void SetFlowTemperatureIdle(bool value)
        {
            Transport.CurrentCommand = _commands.SetHwsFlowTemperatureIdle;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsFlowTemperatureIdle(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает верхнее значение температуры подачи системы отопления X2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3612, A3681, A3682, A3683, A3684, A2312, A3312]
        public void SetMaxHsSetFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsSetFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHsSetFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает верхнее значение температуры подачи ГВС X2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3612]
        public void SetMaxHwsSetFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHwsSetFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHwsSetFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает верхнее значение максимальной границы системы отопления Y2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302, A3612, A3681, A3682, A3683, A3684, A3312, A2312]
        public void SetMaxHsBorderFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHsBorderFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHsBorderFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает верхнее значение максимальной границы ГВС Y2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3612]
        public void SetMaxHwsBorderFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHwsBorderFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHwsBorderFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает нижнее значение температуры подачи системы отопления X1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3612, A3681, A3682, A3683, A3684, A2312, A3312]
        public void SetMinHsSetFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsSetFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsSetFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает нижнее значение температуры подачи ГВС X1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3612]
        public void SetMinHwsSetFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsSetFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsSetFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает нижнее значение максимальной границы системы отопления Y1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302, A3612, A3681, A3682, A3683, A3684, A2312, A3312]
        public void SetMinHsBorderFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHsBorderFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHsBorderFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает нижнее значение максимальной границы ГВС Y1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3612]
        public void SetMinHwsBorderFlowTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsBorderFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsBorderFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время повтора при регулировании насосов контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpIterationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpIterationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpIterationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время повтора при регулировании насосов контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetHwsPumpIterationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpIterationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpIterationTime(value), true);
            Wait();
        }


        /// <summary>
        /// Устанавливает длительность смены при регулировании насосов контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpChangePeriod(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpChangePeriod;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpChangePeriod(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает длительность смены при регулировании насосов контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetHwsPumpChangePeriod(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpChangePeriod;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpChangePeriod(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает час смены при регулировании насосов контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpChangeHour(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpChangeHour;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpChangeHour(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает час смены при регулировании насосов контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetHwsPumpChangeHour(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpChangeHour;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpChangeHour(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время стабилизации при регулировании насосов контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpStabilizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpStabilizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpStabilizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время стабилизации при регулировании насосов контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetHwsPumpStabilizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpStabilizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpStabilizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время переключения при регулировании насосов контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpSwitchingTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpSwitchingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpSwitchingTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время переключения при регулировании насосов контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetHwsPumpSwitchingTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpSwitchingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpSwitchingTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время профилактики насоса системы отопления
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684,A2601, A2301, A2302, A2661, A2662, A2669, A2311, A2312, A3311, A3312]
        public void SetHsPumpTrainingTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpTrainingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpTrainingTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время тестирования насоса подпитки контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsSupplyPumpTrainingTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsSupplyPumpTrainingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsSupplyPumpTrainingTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время тестирования насоса подпитки контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612]
        public void SetHwsSupplyPumpTrainingTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsSupplyPumpTrainingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsSupplyPumpTrainingTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает требуемое давление для системы подпитки контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpRequiredPressure(double value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpRequiredPressure;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpRequiredPressure(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает требуемое давление для системы подпитки контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612]
        public void SetHwsPumpRequiredPressure(double value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpRequiredPressure;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpRequiredPressure(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает разницу переключения давления для системы подпитки контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpSwitchingDiff(double value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpSwitchingDiff;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpSwitchingDiff(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает разницу переключения давления для системы подпитки контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612]
        public void SetHwsPumpSwitchingDiff(double value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpSwitchingDiff;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpSwitchingDiff(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает длительность долива для системы подпитки контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpToppingDuration(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpToppingDuration;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpToppingDuration(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает длительность долива для системы подпитки контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612]
        public void SetHwsPumpToppingDuration(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpToppingDuration;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpToppingDuration(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время ожидания перед открытием клапана
        /// </summary>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsWaitOpenValveTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsWaitOpenValveTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsWaitOpenValveTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время ожидания перед открытием клапана
        /// </summary>
        [ApplicationBase, A3611, A3612]
        public void SetHwsWaitOpenValveTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsWaitOpenValveTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsWaitOpenValveTime(value), true);
            Wait();
        }


        /// <summary>
        /// Устанавливает количество насосов
        /// </summary>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHsPumpCount(int value)
        {
            Transport.CurrentCommand = _commands.SetHsPumpCount;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsPumpCount(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает количество насосов, контур 2
        /// </summary>
        [ApplicationBase, A3611, A3612]
        public void SetHwsPumpCount(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpCount;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpCount(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает тип входного сигнала давления контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetEcl310PressureInputSignalTypeId(int value)
        {
            Transport.CurrentCommand = _commands.SetEcl310PressureInputSignalTypeId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetEcl310PressureInputSignalTypeId(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает тип входного сигнала давления контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3611, A3612]
        public void SetEcl310PressureInputSignalType2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetEcl310PressureInputSignalType2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetEcl310PressureInputSignalType2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время профилактики насоса ГВС
        /// </summary>
        [ApplicationBase, A2661, A3611, A3612, A3681, A3682, A3683, A3684, A2601, A2662, A2669]
        public void SetHwsPumpTrainingTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsPumpTrainingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPumpTrainingTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает количество насосов
        /// </summary>
        /// <param name="value">Новое значение</param>
        public void SetPumpCount(int value)
        {
            Transport.CurrentCommand = _commands.SetPumpCount;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPumpCount(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает температуру отключения отопления контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetHwsHeatingOffTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetHwsHeatingOffTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsHeatingOffTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает желаемую комнатную дневную температуру контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetHsComfortRoomTemperatureCircuit2(double value)
        {
            Transport.CurrentCommand = _commands.SetHsComfortRoomTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsComfortRoomTemperatureCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает желаемую комнатную ночную температуру контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetHsSavingRoomTemperatureCircuit2(double value)
        {
            Transport.CurrentCommand = _commands.SetHsSavingRoomTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsSavingRoomTemperatureCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальную температуру открытого воздуха контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetMaxHwsOpenAirTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHwsOpenAirTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHwsOpenAirTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальную температуру обратного трубопровода контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetMinHwsReverseTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsReverseTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальную температуру открытого воздуха контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetMinHwsOpenAirTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMinHwsOpenAirTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinHwsOpenAirTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальную температуру обратного трубопровода контура 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetMaxHwsReverseTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxHwsReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxHwsReverseTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает следует ли использовать внешний сигнал в контуре 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsExternalSignal(bool value)
        {
            Transport.CurrentCommand = _commands.SetHsExternalSignal;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsExternalSignal(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает ограничение температуры компенсации т.1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation1Temperature(int value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation1Temperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation1Temperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает ограничение температуры компенсации т.2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation2Temperature(int value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation2Temperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation2Temperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время оптимизации компенсации т.1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation1OptimizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation1OptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation1OptimizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время оптимизации компенсации т.2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation2OptimizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation2OptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation2OptimizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальное влияние компенсации т.1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation1MaxInfluence(double value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation1MaxInfluence;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation1MaxInfluence(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальное влияние компенсации т.2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation2MaxInfluence(double value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation2MaxInfluence;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation2MaxInfluence(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное влияние компенсации т.1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation1MinInfluence(double value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation1MinInfluence;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation1MinInfluence(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное влияние компенсации т.2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302]
        public void SetHsCompensation2MinInfluence(double value)
        {
            Transport.CurrentCommand = _commands.SetHsCompensation2MinInfluence;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsCompensation2MinInfluence(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает коэффициент максимального влияния ветра
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301]
        public void SetMaxHsWindInfluence(double value)
        {
            Transport.CurrentCommand = _commands.SetHsMaxWindInfluence;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsMaxWindInfluence(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает фильтр ветра
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301, A3143]
        public void SetHsWindFilter(int value)
        {
            Transport.CurrentCommand = _commands.SetHsWindFilter;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsWindFilter(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает ограничение ветра
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2301]
        public void SetHsWindLimit(double value)
        {
            Transport.CurrentCommand = _commands.SetHsWindLimit;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsWindLimit(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает ограничение температуры обратного трубопровода контура 1
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2302, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetHsLimitReverseTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetHsLimitReverseTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHsLimitReverseTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает заданную балансовую температуру
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetAdjustedBalanceTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetAdjustedBalanceTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAdjustedBalanceTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает коэффициент мертвой зоны
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetDeadBand(double value)
        {
            Transport.CurrentCommand = _commands.SetDeadBand;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetDeadBand(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает скорость адаптации комнатной температуры, контур 1
        /// </summary>
        [ApplicationBase, A2141, A2301, A2302, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2661, A2662]
        public void SetOptimizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает скорость адаптации комнатной температуры, контур 2
        /// </summary>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601]
        public void SetOptimizationTimeCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationTimeCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationTimeCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает предельную температуру замерзания
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetLimitFreezeTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetLimitFreezeTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetLimitFreezeTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает мин. влияние предельной безопасной температуры
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetMinLimitFreezeInfluence(double value)
        {
            Transport.CurrentCommand = _commands.SetMinLimitFreezeInfluence;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinLimitFreezeInfluence(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время оптимизации предельной безопасной температуры
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetLimitFreezeOptimizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetLimitFreezeOptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetLimitFreezeOptimizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время защиты двигателя
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2302, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMotorProtection(int value)
        {
            Transport.CurrentCommand = _commands.SetMotorProtection;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMotorProtection(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время защиты двигателя регулятора 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2144, A2145, A3141, A3142, A2601, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetMotorProtection2(int value)
        {
            Transport.CurrentCommand = _commands.SetMotorProtection2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMotorProtection2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает максимальное выходное напряжение
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3141, A3142]
        public void SetMaxOutputVoltage(int value)
        {
            Transport.CurrentCommand = _commands.SetMaxOutputVoltage;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMaxOutputVoltage(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальное выходное напряжение
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3141, A3142]
        public void SetMinOutputVoltage(int value)
        {
            Transport.CurrentCommand = _commands.SetMinOutputVoltage;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinOutputVoltage(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение реверса
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A3141, A3142]
        public void SetReverse(bool value)
        {
            Transport.CurrentCommand = _commands.SetReverse;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetReverse(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает задержку включения вентилятора
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetFanDelay(int value)
        {
            Transport.CurrentCommand = _commands.SetFanDelay;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFanDelay(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает задержку включения вспомогательного оборудования
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetPermissibleDelay(int value)
        {
            Transport.CurrentCommand = _commands.SetPermissibleDelay;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPermissibleDelay(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает функцию выхода вентилятора
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetFanOutputFunction(int value)
        {
            Transport.CurrentCommand = _commands.SetFanOutputFunction;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFanOutputFunction(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает функцию выхода вспомогательного оборудования
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetFlapOutputFunction(int value)
        {
            Transport.CurrentCommand = _commands.SetFlapOutputFunction;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlapOutputFunction(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает дополнительную функцию
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetRelay3Function(int value)
        {
            Transport.CurrentCommand = _commands.SetRelay3Function;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetRelay3Function(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает программу реле 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetRelay2Programm(int value)
        {
            Transport.CurrentCommand = _commands.SetRelay2Programm;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetRelay2Programm(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает коэффициент разницы заданных комнатных температур
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2143, A3143]
        public void SetRoomTemperaturesDiff(double value)
        {
            Transport.CurrentCommand = _commands.SetRoomTemperaturesDiff;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetRoomTemperaturesDiff(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает температуру защиты от замерзания
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFrostProtectionTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetFrostProtectionTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFrostProtectionTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает функцию вентилятора
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetFanFunction(bool value)
        {
            Transport.CurrentCommand = _commands.SetFanFunction;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFanFunction(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает значение фильтра S4
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2144, A3141]
        public void SetS4Filter(int value)
        {
            Transport.CurrentCommand = _commands.SetS4Filter;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetS4Filter(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает адрес ECA
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2143, A2145, A3142, A3143, A2601, A2301, A2302, A2661, A2662]
        public void SetEcaAddressId(int value)
        {
            Transport.CurrentCommand = _commands.SetEcaAddressId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetEcaAddressId(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает адрес ECA, контур 2
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2143, A2145, A3142, A3143, A2601]
        public void SetEcaAddressCircuit2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetEcaAddressCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetEcaAddressCircuit2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает флаг полного отключения, контур 1
        /// </summary>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetBlackout(bool value)
        {
            Transport.CurrentCommand = _commands.SetBlackout;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetBlackout(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает флаг полного отключения, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetBlackoutCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetBlackoutCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetBlackoutCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает время перехода между режимами
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2144, A2145, A3141, A3142]
        public void SetTransitionModeTime(int value)
        {
            Transport.CurrentCommand = _commands.SetTransitionModeTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetTransitionModeTime(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает температуру защиты от замерзания
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2144, A3141, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFrostProtectionTemperature2(int value)
        {
            Transport.CurrentCommand = _commands.SetFrostProtectionTemperature2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFrostProtectionTemperature2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает флаг выбора компенсационной температуры
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetSelectionCompensationTemperature(bool value)
        {
            Transport.CurrentCommand = _commands.SetSelectionCompensationTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetSelectionCompensationTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает внешний вход ECL 210, контур 1
        /// </summary>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2302, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetExternalInputEcl210(int value)
        {
            Transport.CurrentCommand = _commands.SetExternalInputEcl210;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetExternalInputEcl210(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает внешний вход ECL 210, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetExternalInputEcl210Circuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetExternalInputEcl210Circuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetExternalInputEcl210Circuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает режим внешней перенастройки, контур 1
        /// </summary>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2302, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetExternalOverrideModeId(int value)
        {
            Transport.CurrentCommand = _commands.SetExternalOverrideModeId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetExternalOverrideModeId(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает режим внешней перенастройки, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetExternalOverrideModeCircuit2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetExternalOverrideModeCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetExternalOverrideModeCircuit2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает флаг посылки заданной температуры
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetSendPredeterminedTemperature(bool value)
        {
            Transport.CurrentCommand = _commands.SetSendPredeterminedTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetSendPredeterminedTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает аварийную температуру S6
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetAccidentS6FreezingTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetAccidentS6FreezingTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentS6FreezingTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает аварийную температуру S5
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetAccidentS5FreezingTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetAccidentS5FreezingTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentS5FreezingTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает аварийное значение термостата замерзания
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143]
        public void SetAccidentFrostThermostat(bool value)
        {
            Transport.CurrentCommand = _commands.SetAccidentFrostThermostat;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentFrostThermostat(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает задержку аварии термостата замерзания
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2669]
        public void SetAccidentFrostThermostatDelay(int value)
        {
            Transport.CurrentCommand = _commands.SetAccidentFrostThermostatDelay;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentFrostThermostatDelay(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает аварийное значение термостата пожаробезопасности
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2669]
        public void SetAccidentFireSafetyThermostat(bool value)
        {
            Transport.CurrentCommand = _commands.SetAccidentFireSafetyThermostat;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentFireSafetyThermostat(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает задержку аварии термостата пожаробезопасности
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2141, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2669]
        public void SetAccidentFireSafetyThermostatDelay(int value)
        {
            Transport.CurrentCommand = _commands.SetAccidentFireSafetyThermostatDelay;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentFireSafetyThermostatDelay(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает верхнюю разницу температурного монитора, контур 1
        /// </summary>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetUpperDifferenceTemperatureMonitor(int value)
        {
            Transport.CurrentCommand = _commands.SetUpperDifferenceTemperatureMonitor;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetUpperDifferenceTemperatureMonitor(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает верхнюю разницу температурного монитора, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetUpperDifferenceTemperatureMonitorCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetUpperDifferenceTemperatureMonitorCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetUpperDifferenceTemperatureMonitorCircuit2(value), true);
            Wait();
        }


        /// <summary>
        /// Устанавливает нижнюю разницу температурного монитора, контур 1
        /// </summary>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetLowerDifferenceTemperatureMonitor(int value)
        {
            Transport.CurrentCommand = _commands.SetLowerDifferenceTemperatureMonitor;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetLowerDifferenceTemperatureMonitor(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает нижнюю разницу температурного монитора, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetLowerDifferenceTemperatureMonitorCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetLowerDifferenceTemperatureMonitorCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetLowerDifferenceTemperatureMonitorCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает паузу температурного монитора, контур 1
        /// </summary>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetPauseTemperatureMonitor(int value)
        {
            Transport.CurrentCommand = _commands.SetPauseTemperatureMonitor;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPauseTemperatureMonitor(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает паузу температурного монитора, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetPauseTemperatureMonitorCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetPauseTemperatureMonitorCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPauseTemperatureMonitorCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальную температуру температурного монитора, контур 1
        /// </summary>
        [ApplicationBase, A2142, A2143, A2144, A2145, A3141, A3142, A3143, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetMinTemperatureMonitor(int value)
        {
            Transport.CurrentCommand = _commands.SetMinTemperatureMonitor;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinTemperatureMonitor(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает минимальную температуру температурного монитора, контур 2
        /// </summary>
        [ApplicationBase, A2601,A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetMinTemperatureMonitorCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetMinTemperatureMonitorCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetMinTemperatureMonitorCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает приоритет ограничения температуры обратки
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetLimitReversePriority(bool value)
        {
            Transport.CurrentCommand = _commands.SetLimitReversePriority;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetLimitReversePriority(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает приоритет ограничения температуры обратки (контур 2)
        /// </summary>
        /// <param name="value">Новое значение</param>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetLimitReversePriorityCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetLimitReversePriorityCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetLimitReversePriorityCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает смещение
        /// </summary>
        [ApplicationBase, A2601, A2301, A2302, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetOffset(int value)
        {
            Transport.CurrentCommand = _commands.SetOffset;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOffset(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг тренировки клапана, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2302, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlapTrainingCircuit1(bool value)
        {
            Transport.CurrentCommand = _commands.SetFlapTrainingCirciut1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlapTrainingCurciut1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг тренировки клапана, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFlapTrainingCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetFlapTrainingCirciut2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlapTrainingCurciut2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг приоритета ГВС, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetHwsPriorityCircuit1(bool value)
        {
            Transport.CurrentCommand = _commands.SetHwsPriorityCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPriorityCurcuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг приоритета ГВС, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetHwsPriorityCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetHwsPriorityCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHwsPriorityCurcuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает температуру защиты от замерзания, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFrostProtectionTemperatureCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetFrostProtectionTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFrostProtectionTemperatureCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает температуру тепловой нагрузки, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetThermalLoadTemperatureCircuit1(int value)
        {
            Transport.CurrentCommand = _commands.SetThermalLoadTemperatureCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetThermalLoadTemperatureCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает температуру тепловой нагрузки, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetThermalLoadTemperatureCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetThermalLoadTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetThermalLoadTemperatureCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает требуемую температуру защиты от замерзания, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFrostProtectionTemperature2Circuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetFrostProtectionTemperature2Circuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFrostProtectionTemperature2Circuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает время оптимизации ограничения расхода, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2302, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationOptimizationTime(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationOptimizationTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationOptimizationTime(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает время оптимизации ограничения расхода, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFlowLimitationOptimizationTimeCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationOptimizationTimeCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationOptimizationTimeCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает фильтр ввода ограничения расхода, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2302, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationInputFilter(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationInputFilter;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationInputFilter(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает фильтр ввода ограничения расхода, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFlowLimitationInputFilterCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationInputFilterCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationInputFilterCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение импульса ограничения расхода, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301,A2302, A2661, A2662, A3681, A3682, A3683, A3684]
        public void SetFlowLimitationImpulseWeight(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationImpulseWeight;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationImpulseWeight(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение импульса ограничения расхода, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662]
        public void SetFlowLimitationImpulseWeightCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationImpulseWeightCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationImpulseWeightCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает единицу измерения ограничения расхода, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2302, A2661, A2662, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationUnitId(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationUnitId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationUnitId(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает единицу измерения ограничения расхода, словарь 2, контур 1
        /// </summary>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFlowLimitationUnitDict2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationUnitId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationUnitId(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает единицу измерения ограничения расхода, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662]
        public void SetFlowLimitationUnitCircuit2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationUnitCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationUnitCircuit2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает единицу измерения ограничения расхода, словарь 2, контур 2
        /// </summary>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFlowLimitationUnitDict2Circuit2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationUnitCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationUnitCircuit2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает макс. расход обратки Y2, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationMaxReverseRate(double value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMaxReverseRate;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMaxReverseRate(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает макс. расход обратки Y2, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetFlowLimitationMaxReverseRateCircuit2(double value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMaxReverseRateCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMaxReverseRateCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает мин. расход обратки Y2, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationMinReverseRate(double value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMinReverseRate;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMinReverseRate(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает мин. расход обратки Y2, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetFlowLimitationMinReverseRateCircuit2(double value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMinReverseRateCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMinReverseRateCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает мин. нар. температуру X2, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationMinOpenAirTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMinOpenAirTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMinOpenAirTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает мин. нар. температуру X2, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetFlowLimitationMinOpenAirTemperatureCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMinOpenAirTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMinOpenAirTemperatureCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает макс. нар. температуру X1, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationMaxOpenAirTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMaxOpenAirTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMaxOpenAirTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает макс. нар. температуру X1, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetFlowLimitationMaxOpenAirTemperatureCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationMaxOpenAirTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationMaxOpenAirTemperatureCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает тип входа ограничения расхода, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2302, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetFlowLimitationInputTypeId(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationInputTypeId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationInputTypeId(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает тип входа ограничения расхода, словарь 2, контур 1
        /// </summary>
        [ApplicationBase, A3611, A3612]
        public void SetFlowLimitationInputTypeDict2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationInputTypeId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationInputTypeId(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает тип входа ограничения расхода, контур 2
        /// </summary>
        [ApplicationBase, A2601, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetFlowLimitationInputTypeCircuit2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationInputTypeCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationInputTypeCircuit2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает тип входа ограничения расхода, словарь 2, контур 2
        /// </summary>
        [ApplicationBase, A3611, A3612]
        public void SetFlowLimitationInputTypeDict2Circuit2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationInputTypeCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationInputTypeCircuit2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает температуру автоотключения, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetOptimizationAutoPowerOffTemperature(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationAutoPowerOffTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationAutoPowerOffTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает температуру автоотключения, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetOptimizationAutoPowerOffTemperatureCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationAutoPowerOffTemperatureCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationAutoPowerOffTemperatureCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает натоп, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetOptimizationBoost(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationBoost;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationBoost(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает натоп, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetOptimizationBoostCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationBoostCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationBoostCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает время натопа, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetOptimizationBoostTime(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationBoostTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationBoostTime(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает время натопа, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetOptimizationBoostTimeCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationBoostTimeCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationBoostTimeCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает оптимизатор, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A2669, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetOptimizationOptimum(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationOptimum;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationOptimum(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает оптимизатор, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetOptimizationOptimumCircuit2(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationOptimumCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationOptimumCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг задержки отключения, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetOptimizationOffDelay(bool value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationOffDelay;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationOffDelay(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг задержки отключения, контур 2
        /// </summary>
        [ApplicationBase, A2601, A3611, A3612]
        public void SetOptimizationOffDelayCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationOffDelayCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationOffDelayCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает базис оптимизации, контур 1
        /// </summary>
        [ApplicationBase, A2601, A2301, A2661, A2662]
        public void SetOptimizationBasisId(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationBasisId;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationBasisId(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает базис оптимизации, контур 2
        /// </summary>
        [ApplicationBase, A2601]
        public void SetOptimizationBasisCircuit2Id(int value)
        {
            Transport.CurrentCommand = _commands.SetOptimizationBasisCircuit2Id;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetOptimizationBasisCircuit2Id(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает требуемую температуру подачи в режиме комфорт
        /// </summary>
        [ApplicationBase, A2302]
        public void SetRequiredComfortFlowTemperature(double value)
        {
            Transport.CurrentCommand = _commands.SetRequiredComfortFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetRequiredComfortFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает требуемую температуру подачи в режиме эконом
        /// </summary>
        [ApplicationBase, A2302]
        public void SetRequiredEconomyFlowTemperature(double value)
        {
            Transport.CurrentCommand = _commands.SetRequiredEconomyFlowTemperature;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetRequiredEconomyFlowTemperature(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает предельное значение ограничения расхода
        /// </summary>
        [ApplicationBase, A2302]        
        public void SetFlowLimitationLimit(double value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationLimit;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationLimit(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает предельное значение ограничения расхода, контур 2
        /// </summary>
        [ApplicationBase, A2661, A2662, A3681, A3682, A3683, A3684]
        public void SetFlowLimitationLimitCircuit2(double value)
        {
            Transport.CurrentCommand = _commands.SetFlowLimitationLimitCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetFlowLimitationLimitCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает нагрузку охлаждения, контур 1
        /// </summary>
        [ApplicationBase, A2302]
        public void SetCoolingLoadTemperatureCircuit1(int value)
        {
            Transport.CurrentCommand = _commands.SetCoolingLoadTemperatureCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetCoolingLoadTemperatureCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает температуру в режиме ожидания, контур 1 
        /// </summary>
        [ApplicationBase, A2302]
        public void SetExpectationFlowTemperatureCircuit1(int value)
        {
            Transport.CurrentCommand = _commands.SetExpectationFlowTemperatureCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetExpectationFlowTemperatureCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает коэффициент параллельной работы, контур 1
        /// </summary>
        [ApplicationBase, A2661, A2662, A3681, A3682, A3683, A3684]
        public void SetParallelOperationCircuit1(int value)
        {
            Transport.CurrentCommand = _commands.SetParallelOperationCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetParallelOperationCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг автонастройки, контур 2
        /// </summary>
        [ApplicationBase, A2661]
        public void SetAutotuningCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetAutotuningCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAutotuningCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает температуру подачи сигнализации, контур 1
        /// </summary>
        [ApplicationBase, A2662, A2669]
        public void SetSignalizationFlowTemperatureCircuit1(int value)
        {
            Transport.CurrentCommand = _commands.SetSignalizationFlowTemperatureCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetSignalizationFlowTemperatureCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает паузу сигнализации, контур 1
        /// </summary>
        [ApplicationBase, A2662, A2669]
        public void SetSignalizationPauseCircuit1(int value)
        {
            Transport.CurrentCommand = _commands.SetSignalizationPauseCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetSignalizationPauseCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Запись верхней аварийной границы, контур 1
        /// </summary>
        [ApplicationBase, A2669]
        public void SetAccidentTopLimit(double value)
        {
            Transport.CurrentCommand = _commands.SetAccidentTopLimit;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentTopLimit(value), true);
            Wait();
        }

        /// <summary>
        /// Запись нижней аварийной границы, контур 1
        /// </summary>
        [ApplicationBase, A2669]
        public void SetAccidentBottomLimit(double value)
        {
            Transport.CurrentCommand = _commands.SetAccidentBottomLimit;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentBottomLimit(value), true);
            Wait();
        }

        /// <summary>
        /// Запись нижн. X, контур 1
        /// </summary>
        [ApplicationBase, A2669]
        public void SetPressureBottomXCircuit1(double value)
        {
            Transport.CurrentCommand = _commands.SetPressureBottomXCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPressureBottomXCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Запись верхн. X, контур 1
        /// </summary>
        [ApplicationBase, A2669]
        public void SetPressureTopXCircuit1(double value)
        {
            Transport.CurrentCommand = _commands.SetPressureTopXCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPressureTopXCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Запись нижн. Y, контур 1
        /// </summary>
        [ApplicationBase, A2669]
        public void SetPressureBottomYCircuit1(double value)
        {
            Transport.CurrentCommand = _commands.SetPressureBottomYCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPressureBottomYCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Запись верхн. Y, контур 1
        /// </summary>
        [ApplicationBase, A2669]
        public void SetPressureTopYCircuit1(double value)
        {
            Transport.CurrentCommand = _commands.SetPressureTopYCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPressureTopYCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг сброса аварии насосов, контур 1
        /// </summary>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetAccidentPumpsCircuit1(bool value)
        {
            Transport.CurrentCommand = _commands.SetAccidentPumpsCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentPumpsCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг сброса аварии насосов, контур 2
        /// </summary>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684]
        public void SetAccidentPumpsCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetAccidentPumpsCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentPumpsCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг сброса аварии подпитки, контур 1
        /// </summary>
        [ApplicationBase, A3611, A3612, A3681, A3682, A3683, A3684, A2311, A2312, A3311, A3312]
        public void SetAccidentMakeupCircuit1(bool value)
        {
            Transport.CurrentCommand = _commands.SetAccidentMakeupCircuit1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentMakeupCircuit1(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает флаг сброса аварии подпитки, контур 2
        /// </summary>
        [ApplicationBase, A3611, A3612]
        public void SetAccidentMakeupCircuit2(bool value)
        {
            Transport.CurrentCommand = _commands.SetAccidentMakeupCircuit2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetAccidentMakeupCircuit2(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает угол наклона температурного графика, контур 1
        /// </summary>
        [ApplicationBase, A2661, A2311, A2312, A3311, A3312]
        public void SetHeatCurveAngle(double value)
        {
            Transport.CurrentCommand = _commands.SetHeatCurveAngle;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetHeatCurveAngle(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11173
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11173(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11173;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11173(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11094
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11094(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11094;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11094(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11095
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11095(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11095;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11095(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11096
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11096(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11096;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11096(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11097
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11097(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11097;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11097(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11076
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11076(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11076;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11076(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11040
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11040(int value)
        {
            Transport.CurrentCommand = _commands.SetPnu11040;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11040(value), true);
            Wait();
        }

        /// <summary>
        /// Записывает значение PNU 11190
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11190(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11190;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11190(value), true);
            Wait();
        }

        // <summary>
        /// Записывает значение PNU 11191
        /// </summary>
        /// <param name="value"></param>
        [ApplicationBase]
        public void SetPnu11191(double value)
        {
            Transport.CurrentCommand = _commands.SetPnu11191;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.SetPnu11191(value), true);
            Wait();
        }
    }
}

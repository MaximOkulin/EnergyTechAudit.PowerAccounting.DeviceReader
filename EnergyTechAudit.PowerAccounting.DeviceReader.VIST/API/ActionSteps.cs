using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VIST.API
{
    internal sealed class ActionSteps : ActionStepsBase
    {

        private readonly Functions _functions;
        private readonly int _deviceAddress;
        private readonly Commands _commands;

        public ActionSteps(DeviceTransport connection, ManualResetEvent autoEvent, int deviceAddress)
            : base(connection, autoEvent)
        {
            _functions = new Functions(deviceAddress);
            _deviceAddress = deviceAddress;
            _commands = new Commands();
        }

        /// <summary>
        /// Чтение версии программного обеспечения прибора
        /// </summary>
        public void GetFirmware()
        {
            Transport.CurrentCommand = _commands.GetFirmware;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение заводского номера прибора
        /// </summary>
        public void GetFactoryNumber()
        {
            Transport.CurrentCommand = _commands.GetFactoryNumber;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFactoryNumber(), true);
            Wait();
        }

        /// <summary>
        /// Чтение отчетного времени прибора
        /// </summary>
        public void GetReportingTime()
        {
            Transport.CurrentCommand = _commands.GetReportingTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetReportingTime(), true);
            Wait();
        }

        /// <summary>
        /// Чтение структуры изменяемых параметров т/с №1 прибора
        /// </summary>
        public void GetSettingsHeatSys1()
        {
            Transport.CurrentCommand = _commands.GetSettingsHeatSys1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSettingsHeatSys1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение структуры изменяемых параметров т/с №2 прибора
        /// </summary>
        public void GetSettingsHeatSys2()
        {
            Transport.CurrentCommand = _commands.GetSettingsHeatSys2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSettingsHeatSys2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение структуры изменяемых параметров т/с №3 прибора
        /// </summary>
        public void GetSettingsHeatSys3()
        {
            Transport.CurrentCommand = _commands.GetSettingsHeatSys3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSettingsHeatSys3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение количества теплосистем в приборе
        /// </summary>
        public void GetSystemsCount()
        {
            Transport.CurrentCommand = _commands.GetSystemsCount;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetSystemsCount(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих даты и времени прибора
        /// </summary>
        public void GetDeviceTime()
        {
            Transport.CurrentCommand = _commands.GetDeviceTime;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetDeviceTime(), true);
            Wait();
        }

        /// <summary>
        /// Чтение спецификации архивного файла теплосистемы
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetArchiveHeaderSystem(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetArchiveHeaderSystem1();
                    break;
                case 2:
                    GetArchiveHeaderSystem2();
                    break;
                case 3:
                    GetArchiveHeaderSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение спецификации архивного файла теплосистемы №1
        /// </summary>
        private void GetArchiveHeaderSystem1()
        {
            Transport.CurrentCommand = _commands.GetArchiveHeaderSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetArchiveHeaderSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение спецификации архивного файла теплосистемы №2
        /// </summary>
        private void GetArchiveHeaderSystem2()
        {
            Transport.CurrentCommand = _commands.GetArchiveHeaderSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetArchiveHeaderSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение спецификации архивного файла теплосистемы №3
        /// </summary>
        private void GetArchiveHeaderSystem3()
        {
            Transport.CurrentCommand = _commands.GetArchiveHeaderSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetArchiveHeaderSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение набора измеряемых текущих параметров теплосистемы
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetInstantParamsSet(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetInstantParamsSetSystem1();
                    break;
                case 2:
                    GetInstantParamsSetSystem2();
                    break;
                case 3:
                    GetInstantParamsSetSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение набора измеряемых текущих параметров теплосистемы №1
        /// </summary>
        private void GetInstantParamsSetSystem1()
        {
            Transport.CurrentCommand = _commands.GetInstantParamsSetSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantParamsSetSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение набора измеряемых текущих параметров теплосистемы №2
        /// </summary>
        private void GetInstantParamsSetSystem2()
        {
            Transport.CurrentCommand = _commands.GetInstantParamsSetSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantParamsSetSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение набора измеряемых текущих параметров теплосистемы №3
        /// </summary>
        private void GetInstantParamsSetSystem3()
        {
            Transport.CurrentCommand = _commands.GetInstantParamsSetSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantParamsSetSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение точности по расходу и тепловой мощности
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetInstantParamsPrecisions(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetInstantParamsPrecisionsSystem1();
                    break;
                case 2:
                    GetInstantParamsPrecisionsSystem2();
                    break;
                case 3:
                    GetInstantParamsPrecisionsSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение точности по расходу и тепловой мощности теплосистемы №1
        /// </summary>
        private void GetInstantParamsPrecisionsSystem1()
        {
            Transport.CurrentCommand = _commands.GetInstantParamsPrecisionsSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantParamsPrecisionsSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение точности по расходу и тепловой мощности теплосистемы №2
        /// </summary>
        private void GetInstantParamsPrecisionsSystem2()
        {
            Transport.CurrentCommand = _commands.GetInstantParamsPrecisionsSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantParamsPrecisionsSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение точности по расходу и тепловой мощности теплосистемы №3
        /// </summary>
        private void GetInstantParamsPrecisionsSystem3()
        {
            Transport.CurrentCommand = _commands.GetInstantParamsPrecisionsSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantParamsPrecisionsSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих температур
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetInstantTemperatures(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetInstantTemperaturesSystem1();
                    break;
                case 2:
                    GetInstantTemperaturesSystem2();
                    break;
                case 3:
                    GetInstantTemperaturesSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение текущих температур теплосистемы №1
        /// </summary>
        private void GetInstantTemperaturesSystem1()
        {
            Transport.CurrentCommand = _commands.GetInstantTemperaturesSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantTemperaturesSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих температур теплосистемы №2
        /// </summary>
        private void GetInstantTemperaturesSystem2()
        {
            Transport.CurrentCommand = _commands.GetInstantTemperaturesSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantTemperaturesSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих температур теплосистемы №3
        /// </summary>
        private void GetInstantTemperaturesSystem3()
        {
            Transport.CurrentCommand = _commands.GetInstantTemperaturesSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantTemperaturesSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих объемных расходов теплосистем
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetInstantVolumeFlows(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetInstantVolumeFlowsSystem1();
                    break;
                case 2:
                    GetInstantVolumeFlowsSystem2();
                    break;
                case 3:
                    GetInstantVolumeFlowsSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение текущих объемных расходов теплосистемы №1
        /// </summary>
        private void GetInstantVolumeFlowsSystem1()
        {
            Transport.CurrentCommand = _commands.GetInstantVolumeFlowsSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantVolumeFlowsSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих объемных расходов теплосистемы №2
        /// </summary>
        private void GetInstantVolumeFlowsSystem2()
        {
            Transport.CurrentCommand = _commands.GetInstantVolumeFlowsSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantVolumeFlowsSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих объемных расходов теплосистемы №3
        /// </summary>
        private void GetInstantVolumeFlowsSystem3()
        {
            Transport.CurrentCommand = _commands.GetInstantVolumeFlowsSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantVolumeFlowsSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих массовых расходов
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetInstantMassFlows(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetInstantMassFlowsSystem1();
                    break;
                case 2:
                    GetInstantMassFlowsSystem2();
                    break;
                case 3:
                    GetInstantMassFlowsSystem3();
                    break;
            }
        }


        /// <summary>
        /// Чтение текущих массовых расходов теплосистемы №1
        /// </summary>
        private void GetInstantMassFlowsSystem1()
        {
            Transport.CurrentCommand = _commands.GetInstantMassFlowsSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantMassFlowsSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих массовых расходов теплосистемы №2
        /// </summary>
        private void GetInstantMassFlowsSystem2()
        {
            Transport.CurrentCommand = _commands.GetInstantMassFlowsSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantMassFlowsSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих массовых расходов теплосистемы №3
        /// </summary>
        private void GetInstantMassFlowsSystem3()
        {
            Transport.CurrentCommand = _commands.GetInstantMassFlowsSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantMassFlowsSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих давлений теплосистем
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetInstantPressures(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetInstantPressureSystem1();
                    break;
                case 2:
                    GetInstantPressureSystem2();
                    break;
                case 3:
                    GetInstantPressureSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение текущих давлений теплосистемы №1
        /// </summary>
        private void GetInstantPressureSystem1()
        {
            Transport.CurrentCommand = _commands.GetInstantPressureSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantPressureSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих давлений теплосистемы №2
        /// </summary>
        private void GetInstantPressureSystem2()
        {
            Transport.CurrentCommand = _commands.GetInstantPressureSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantPressureSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущих давлений теплосистемы №3
        /// </summary>
        private void GetInstantPressureSystem3()
        {
            Transport.CurrentCommand = _commands.GetInstantPressureSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantPressureSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущей тепловой мощности
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetInstantThermalPowers(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetInstantThermalPowerSystem1();
                    break;
                case 2:
                    GetInstantThermalPowerSystem2();
                    break;
                case 3:
                    GetInstantThermalPowerSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение текущей тепловой мощности теплосистемы №1
        /// </summary>
        private void GetInstantThermalPowerSystem1()
        {
            Transport.CurrentCommand = _commands.GetInstantThermalPowerSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantThermalPowerSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущей тепловой мощности теплосистемы №2
        /// </summary>
        private void GetInstantThermalPowerSystem2()
        {
            Transport.CurrentCommand = _commands.GetInstantThermalPowerSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantThermalPowerSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение текущей тепловой мощности теплосистемы №3
        /// </summary>
        private void GetInstantThermalPowerSystem3()
        {
            Transport.CurrentCommand = _commands.GetInstantThermalPowerSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetInstantThermalPowerSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение набора накапливаемых текущих параметров теплосистемы
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetFinalInstantParamsSet(int systemNumber)
        {
            switch (systemNumber)
            {
                case 1:
                    GetFinalInstantParamsSetSystem1();
                    break;
                case 2:
                    GetFinalInstantParamsSetSystem2();
                    break;
                case 3:
                    GetFinalInstantParamsSetSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение набора накапливаемых текущих параметров теплосистемы №1
        /// </summary>
        private void GetFinalInstantParamsSetSystem1()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantParamsSetSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFinalInstantParamsSetSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение набора накапливаемых текущих параметров теплосистемы №2
        /// </summary>
        private void GetFinalInstantParamsSetSystem2()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantParamsSetSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFinalInstantParamsSetSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение набора накапливаемых текущих параметров теплосистемы №3
        /// </summary>
        private void GetFinalInstantParamsSetSystem3()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantParamsSetSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFinalInstantParamsSetSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение точности по объему и тепловой энергии
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetFinalInstantParamsPrecisions(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetFinalInstantParamsPrecisionsSystem1();
                    break;
                case 2:
                    GetFinalInstantParamsPrecisionsSystem2();
                    break;
                case 3:
                    GetFinalInstantParamsPrecisionsSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение точности по объему и тепловой энергии теплосистемы №1
        /// </summary>
        private void GetFinalInstantParamsPrecisionsSystem1()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantParamsPrecisionsSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFinalInstantParamsPrecisionsSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение точности по объему и тепловой энергии теплосистемы №2
        /// </summary>
        private void GetFinalInstantParamsPrecisionsSystem2()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantParamsPrecisionsSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFinalInstantParamsPrecisionsSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение точности по объему и тепловой энергии теплосистемы №3
        /// </summary>
        private void GetFinalInstantParamsPrecisionsSystem3()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantParamsPrecisionsSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetFinalInstantParamsPrecisionsSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение объемов за текущий час
        /// </summary>
        /// <param name="systemNumber"></param>
        public void GetVolumesForHour(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetVolumesForHourSystem1();
                    break;
                case 2:
                    GetVolumesForHourSystem2();
                    break;
                case 3:
                    GetVolumesForHourSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение объемов за текущий час теплосистемы №1
        /// </summary>
        private void GetVolumesForHourSystem1()
        {
            Transport.CurrentCommand = _commands.GetVolumesForHourSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetVolumesForHourSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение объемов за текущий час теплосистемы №2
        /// </summary>
        private void GetVolumesForHourSystem2()
        {
            Transport.CurrentCommand = _commands.GetVolumesForHourSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetVolumesForHourSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение объемов за текущий час теплосистемы №3
        /// </summary>
        private void GetVolumesForHourSystem3()
        {
            Transport.CurrentCommand = _commands.GetVolumesForHourSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetVolumesForHourSystem3(), true);
            Wait();
        }

        public void GetMassesForHour(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetMassesForHourSystem1();
                    break;
                case 2:
                    GetMassesForHourSystem2();
                    break;
                case 3:
                    GetMassesForHourSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение масс за текущий час теплосистемы №1
        /// </summary>
        private void GetMassesForHourSystem1()
        {
            Transport.CurrentCommand = _commands.GetMassesForHourSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMassesForHourSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение масс за текущий час теплосистемы №2
        /// </summary>
        private void GetMassesForHourSystem2()
        {
            Transport.CurrentCommand = _commands.GetMassesForHourSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMassesForHourSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение масс за текущий час теплосистемы №3
        /// </summary>
        private void GetMassesForHourSystem3()
        {
            Transport.CurrentCommand = _commands.GetMassesForHourSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetMassesForHourSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение тепловой энергии за текущий час
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetHeatForHour(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetHeatForHourSystem1();
                    break;
                case 2:
                    GetHeatForHourSystem2();
                    break;
                case 3:
                    GetHeatForHourSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение тепловой энергии за текущий час теплосистемы №1
        /// </summary>
        private void GetHeatForHourSystem1()
        {
            Transport.CurrentCommand = _commands.GetHeatForHourSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatForHourSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение тепловой энергии за текущий час теплосистемы №2
        /// </summary>
        private void GetHeatForHourSystem2()
        {
            Transport.CurrentCommand = _commands.GetHeatForHourSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatForHourSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение тепловой энергии за текущий час теплосистемы №3
        /// </summary>
        private void GetHeatForHourSystem3()
        {
            Transport.CurrentCommand = _commands.GetHeatForHourSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetHeatForHourSystem3(), true);
            Wait();
        }

        /// <summary>
        /// Чтение времени наработки за текущий час
        /// </summary>
        /// <param name="systemNumber">Номер теплосистемы</param>
        public void GetTimeNormalForHour(int systemNumber)
        {
            switch(systemNumber)
            {
                case 1:
                    GetTimeNormalForHourSystem1();
                    break;
                case 2:
                    GetTimeNormalForHourSystem2();
                    break;
                case 3:
                    GetTimeNormalForHourSystem3();
                    break;
            }
        }

        /// <summary>
        /// Чтение времени наработки за текущий час теплосистемы №1
        /// </summary>
        private void GetTimeNormalForHourSystem1()
        {
            Transport.CurrentCommand = _commands.GetTimeNormalForHourSystem1;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetTimeNormalForHourSystem1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение времени наработки за текущий час теплосистемы №2
        /// </summary>
        private void GetTimeNormalForHourSystem2()
        {
            Transport.CurrentCommand = _commands.GetTimeNormalForHourSystem2;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetTimeNormalForHourSystem2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение времени наработки за текущий час теплосистемы №3
        /// </summary>
        private void GetTimeNormalForHourSystem3()
        {
            Transport.CurrentCommand = _commands.GetTimeNormalForHourSystem3;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetTimeNormalForHourSystem3(), true);
            Wait();
        }


        /// <summary>
        /// Чтение структуры заголовка архивного файла и текущих итоговых теплосистемы
        /// </summary>
        /// <param name="systemNumber"></param>
        public void GetArchiveStructureAndFinalInstantSystem(int systemNumber)
        {
            Transport.CurrentCommand = _commands.GetArchiveStructureAndFinalInstantSystem;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.GetArchiveStructureAndFinalInstantSystem(systemNumber), true);
            Wait();
        }

        /// <summary>
        /// Чтение архивной записи по её индексу
        /// </summary>
        /// <param name="systemNumber"></param>
        /// <param name="recordNumber"></param>
        /// <param name="recordLength"></param>
        public void ReadArchiveByIndex(int systemNumber, ushort recordNumber, ushort recordLength)
        {
            Transport.CurrentCommand = _commands.ReadArchiveByIndex;
            Transport.CurrentCommand.NetworkAddress = _deviceAddress;
            Transport.Send(_functions.ReadArchiveByIndex(systemNumber, recordNumber, recordLength), true);
            Wait();
        }
    }
}

using System;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Modbus;
using EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.API
{
    /// <summary>
    /// Класс, реализующий шаги действий при взаимодействий с прибором
    /// </summary>
    internal sealed class ActionSteps : ActionStepsBase
    {
        private readonly Functions _functions;
        private readonly Commands _commands;
        private readonly ModbusMode _modbusMode;

        public ActionSteps(DeviceTransport tv7Connection, ManualResetEvent autoEvent, int deviceAddress)
            :base(tv7Connection, autoEvent)
        {
            _modbusMode = ModbusMode.RTU;
            var connection = tv7Connection as Tv7Connection;
            if (connection != null)
            {
                _modbusMode = connection.ModbusMode;
            }

            _functions = new Functions(deviceAddress, _modbusMode);
            _commands = new Commands();
        }

        /// <summary>
        /// Получает серийный номер прибора
        /// </summary>
        public void GetFactoryNumber()
        {
            Transport.CurrentCommand = _commands.GetFactoryNumber;
            Transport.Send(_functions.GetFactoryNumber(), true);
            Wait();
        }

        /// <summary>
        /// Получает информацию об устройстве
        /// </summary>
        public void GetDeviceInfo()
        {
            Transport.CurrentCommand = _commands.GetDeviceInfo;
            Transport.Send(_functions.GetDeviceInfo(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущее приборное время
        /// </summary>
        public void GetDeviceTime()
        {
            Transport.CurrentCommand = _commands.GetDeviceTime;
            Transport.Send(_functions.GetDeviceTime(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные температуры и давления
        /// </summary>
        public void GetInstantTemperaturesAndPressures()
        {
            Transport.CurrentCommand = _commands.GetInstantTemperaturesAndPressures;
            Transport.Send(_functions.GetInstantTemperaturesAndPressures(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные температуры и давления (новая прошивка)
        /// </summary>
        public void GetInstantTemperaturesAndPressuresNewFirmware()
        {
            Transport.CurrentCommand = _commands.GetInstantTemperaturesAndPressuresNewFirmware;
            Transport.Send(_functions.GetInstantTemperaturesAndPressuresNewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные объемные и массовые расходы
        /// </summary>
        public void GetInstantFlows()
        {
            Transport.CurrentCommand = _commands.GetInstantFlows;
            Transport.Send(_functions.GetInstantFlows(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные объемные и массовые расходы (новая прошивка)
        /// </summary>
        public void GetInstantFlowsNewFirmware()
        {
            Transport.CurrentCommand = _commands.GetInstantFlowsNewFirmware;
            Transport.Send(_functions.GetInstantFlowsNewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные тепловые потоки и энтальпии (удельные теплосодержания) по трубопробоводам
        /// </summary>
        public void GetInstantThermalPowersAndEnthalpiesPipes()
        {
            Transport.CurrentCommand = _commands.GetInstantThermalPowersAndEnthalpiesPipes;
            Transport.Send(_functions.GetInstantThermalPowersAndEnthalpiesPipes(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные тепловые потоки и энтальпии (удельные теплосодержания) по трубопробоводам (новая прошивка)
        /// </summary>
        public void GetInstantThermalPowersAndEnthalpiesPipesNewFirmware()
        {
            Transport.CurrentCommand = _commands.GetInstantThermalPowersAndEnthalpiesPipesNewFirmware;
            Transport.Send(_functions.GetInstantThermalPowersAndEnthalpiesPipesNewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные тепловые потоки, энтальпии и расход по доп.каналу
        /// </summary>
        public void GetInstantThermalPowersAndEnthalpiesHeatInput()
        {
            Transport.CurrentCommand = _commands.GetInstantThermalPowersAndEnthalpiesHeatInput;
            Transport.Send(_functions.GetInstantThermalPowersAndEnthalpiesHeatInput(), true);
            Wait();
        }

        /// <summary>
        /// Получает мгновенные значения температур и давлений по тепловым вводам
        /// </summary>
        public void GetInstantHeatInputParameters()
        {
            Transport.CurrentCommand = _commands.GetInstantHeatInputParameters;
            Transport.Send(_functions.GetInstantHeatInputParameters(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по трубе 1 ТВ1
        /// </summary>
        public void GetFinalInstantTv1Pipe1()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv1Pipe1;
            Transport.Send(_functions.GetFinalInstantTv1Pipe1(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по трубе 2 ТВ1
        /// </summary>
        public void GetFinalInstantTv1Pipe2()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv1Pipe2;
            Transport.Send(_functions.GetFinalInstantTv1Pipe2(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по трубе 3 ТВ1
        /// </summary>
        public void GetFinalInstantTv1Pipe3()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv1Pipe3;
            Transport.Send(_functions.GetFinalInstantTv1Pipe3(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по трубе 1 ТВ2
        /// </summary>
        public void GetFinalInstantTv2Pipe1()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv2Pipe1;
            Transport.Send(_functions.GetFinalInstantTv2Pipe1(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по трубе 2 ТВ2
        /// </summary>
        public void GetFinalInstantTv2Pipe2()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv2Pipe2;
            Transport.Send(_functions.GetFinalInstantTv2Pipe2(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по трубе 3 ТВ2
        /// </summary>
        public void GetFinalInstantTv2Pipe3()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv2Pipe3;
            Transport.Send(_functions.GetFinalInstantTv2Pipe3(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по ТВ1
        /// </summary>
        public void GetFinalInstantTv1()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv1;
            Transport.Send(_functions.GetFinalInstantTv1(), true);
            Wait();
        }

        /// <summary>
        /// Получает текущие итоговые по ТВ2
        /// </summary>
        public void GetFinalInstantTv2()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantTv2;
            Transport.Send(_functions.GetFinalInstantTv2(), true);
            Wait();
        }

        /// <summary>
        /// Получает отчетное время
        /// </summary>
        public void GetReportingTime()
        {
            Transport.CurrentCommand = _commands.GetReportingTime;
            Transport.Send(_functions.GetReportingTime(), true);
            Wait();
        }

        /// <summary>
        /// Получает информацию о датах начала/конца архивов
        /// </summary>
        public void GetArchiveDatesInfo()
        {
            Transport.CurrentCommand = _commands.GetArchiveDatesInfo;
            Transport.Send(_functions.GetArchiveDatesInfo(), true);
            Wait();
        }

        /// <summary>
        /// Устанавливает дату и тип читаемого архива
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="tv7PeriodType"></param>
        public byte[] SetArchiveDate(DateTime dateTime, PeriodType tv7PeriodType)
        {
            Transport.CurrentCommand = _commands.SetArchiveDate;
            Transport.Send(_functions.SetArchiveDate(dateTime, tv7PeriodType), true);
            Wait();
            return _functions.SetArchiveDate(dateTime, tv7PeriodType);
        }

        /// <summary>
        /// Выполняет ускоренное чтение архивной записи
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="tv7PeriodType"></param>
        /// <returns>Возвращает два контрольных байта для последующей проверке</returns>
        public byte[] SpeedReadArchive(DateTime dateTime, PeriodType tv7PeriodType)
        {
            Transport.CurrentCommand = _commands.SpeedReadArchive;
            var package = _functions.SpeedReadArchive(dateTime, tv7PeriodType);

            byte[] rtuPackage = null;
            if (_modbusMode == ModbusMode.ASCII)
            {
                rtuPackage = ModbusProtocol.ConvertToRtuFormat(package, _modbusMode);
            }
            else
            {
                rtuPackage = package;
            }

            Transport.Send(package, true);
            Wait();

            return new byte[] { rtuPackage[12], rtuPackage[13] };
        }

        /// <summary>
        /// Выполняет ускоренное чтение итоговой архивной записи
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="tv7PeriodType"></param>
        /// <returns>Возвращает два контрольных байта для последующей проверке</returns>
        public byte[] SpeedReadFinalArchive(DateTime dateTime)
        {
            Transport.CurrentCommand = _commands.SpeedReadFinalArchive;
            var package = _functions.SpeedReadFinalArchive(dateTime);

            byte[] rtuPackage = null;
            if (_modbusMode == ModbusMode.ASCII)
            {
                rtuPackage = ModbusProtocol.ConvertToRtuFormat(package, _modbusMode);
            }
            else
            {
                rtuPackage = package;
            }

            Transport.Send(package, true);
            Wait();

            return new byte[] { rtuPackage[12], rtuPackage[13] };
        }

        /// <summary>
        /// Устанавливает номер записи асинхронного архива
        /// </summary>
        /// <param name="index">Индекс записи</param>
        public void SetAsyncArchiveIndex(int index)
        {
            Transport.CurrentCommand = _commands.SetAsyncArchiveIndex;
            Transport.Send(_functions.SetAsyncArchiveIndex(index), true);
            Wait();
        }

        /// <summary>
        /// Получает дату архивной записи
        /// </summary>
        public byte[] ReadArchiveTime()
        {
            Transport.CurrentCommand = _commands.ReadArchiveTime;
            Transport.Send(_functions.ReadArchiveTime(), true);
            Wait();
            return _functions.ReadArchiveTime();
        }

        /// <summary>
        /// Получает архив по трубе
        /// </summary>
        /// <param name="pipeNumber">Номер трубы</param>
        public void ReadArchivePipe(int pipeNumber)
        {
            Command cmd = null;
            byte[] package = null;

            switch (pipeNumber)
            {
                case 1:
                    cmd = _commands.ReadArchivePipe1;
                    package = _functions.ReadArchivePipe1();
                    break;
                case 2:
                    cmd = _commands.ReadArchivePipe2;
                    package = _functions.ReadArchivePipe2();
                    break;
                case 3:
                    cmd = _commands.ReadArchivePipe3;
                    package = _functions.ReadArchivePipe3();
                    break;
                case 4:
                    cmd = _commands.ReadArchivePipe4;
                    package = _functions.ReadArchivePipe4();
                    break;
                case 5:
                    cmd = _commands.ReadArchivePipe5;
                    package = _functions.ReadArchivePipe5();
                    break;
                case 6:
                    cmd = _commands.ReadArchivePipe6;
                    package = _functions.ReadArchivePipe6();
                    break;
            }

            Transport.CurrentCommand = cmd;
            Transport.Send(package, true);
            Wait();
        }

        /// <summary>
        /// Получает архив по тепловому вводу
        /// </summary>
        /// <param name="inputNumber">Номер теплового ввода</param>
        public void ReadArchiveHeatInput(int inputNumber)
        {
            Command cmd = null;
            byte[] package = null;

            switch (inputNumber)
            {
                case 1:
                    cmd = _commands.ReadArchiveHeatInput1;
                    package = _functions.ReadArchiveHeatInput1();
                    break;
                case 2:
                    cmd = _commands.ReadArchiveHeatInput2;
                    package = _functions.ReadArchiveHeatInput2();
                    break;
            }

            Transport.CurrentCommand = cmd;
            Transport.Send(package, true);
            Wait();
        }

        /// <summary>
        /// Получает текущее итоговое значение по доп. параметру
        /// </summary>
        public void GetFinalInstantAdditionalParameter()
        {
            Transport.CurrentCommand = _commands.GetFinalInstantAdditionalParameter;
            Transport.Send(_functions.GetFinalInstantAdditionalParameter(), true);
            Wait();
        }

        /// <summary>
        /// Получает архивное значение по доп. параметру
        /// </summary>
        public void ReadArchiveAdditionalParameter()
        {
            Transport.CurrentCommand = _commands.ReadArchiveAdditionalParameter;
            Transport.Send(_functions.ReadArchiveAdditionalParameter(), true);
            Wait();
        }

        /// <summary>
        /// Получает дату итоговой архивной записи
        /// </summary>
        public void ReadFinalArchiveTime()
        {
            Transport.CurrentCommand = _commands.ReadFinalArchiveTime;
            Transport.Send(_functions.ReadFinalArchiveTime(), true);
            Wait();
        }

        /// <summary>
        /// Получает итоговый архив по трубе
        /// </summary>
        /// <param name="pipeNumber">Номер трубы</param>
        public void ReadFinalArchivePipe(int pipeNumber)
        {
            Command cmd = null;
            byte[] package = null;

            switch (pipeNumber)
            {
                case 1:
                    cmd = _commands.ReadFinalArchivePipe1;
                    package = _functions.ReadFinalArchivePipe1();
                    break;
                case 2:
                    cmd = _commands.ReadFinalArchivePipe2;
                    package = _functions.ReadFinalArchivePipe2();
                    break;
                case 3:
                    cmd = _commands.ReadFinalArchivePipe3;
                    package = _functions.ReadFinalArchivePipe3();
                    break;
                case 4:
                    cmd = _commands.ReadFinalArchivePipe4;
                    package = _functions.ReadFinalArchivePipe4();
                    break;
                case 5:
                    cmd = _commands.ReadFinalArchivePipe5;
                    package = _functions.ReadFinalArchivePipe5();
                    break;
                case 6:
                    cmd = _commands.ReadFinalArchivePipe6;
                    package = _functions.ReadFinalArchivePipe6();
                    break;
            }

            Transport.CurrentCommand = cmd;
            Transport.Send(package, true);
            Wait();
        }

        /// <summary>
        /// Получает итоговый архив по тепловому вводу
        /// </summary>
        /// <param name="inputNumber">Номер теплового ввода</param>
        public void ReadFinalArchiveHeatInput(int inputNumber)
        {
            Command cmd = null;
            byte[] package = null;

            switch (inputNumber)
            {
                case 1:
                    cmd = _commands.ReadFinalArchiveHeatInput1;
                    package = _functions.ReadFinalArchiveHeatInput1();
                    break;
                case 2:
                    cmd = _commands.ReadFinalArchiveHeatInput2;
                    package = _functions.ReadFinalArchiveHeatInput2();
                    break;
            }

            Transport.CurrentCommand = cmd;
            Transport.Send(package, true);
            Wait();
        }

        /// <summary>
        /// Получает итоговое архивное значение под доп. параметру
        /// </summary>
        public void ReadFinalArchiveAdditionalParameter()
        {
            Transport.CurrentCommand = _commands.ReadFinalArchiveAdditionalParameter;
            Transport.Send(_functions.ReadFinalArchiveAdditionalParameter(), true);
            Wait();
        }

        /// <summary>
        /// Читает информацию об архивах изменений БД
        /// </summary>
        public void ReadDatabaseChangesArchivesInfo()
        {
            Transport.CurrentCommand = _commands.ReadDatabaseChangesArchivesInfo;
            Transport.Send(_functions.ReadDatabaseChangesArchivesInfo(), true);
            Wait();
        }

        /// <summary>
        /// Читает информацию об архивах событий
        /// </summary>
        public void ReadEventsArchivesInfo()
        {
            Transport.CurrentCommand = _commands.ReadEventsArchivesInfo;
            Transport.Send(_functions.ReadEventsArchivesInfo(), true);
            Wait();
        }

        /// <summary>
        /// Читает информацию о диагностическом архиве
        /// </summary>
        public void ReadDiagnosticArchivesInfo()
        {
            Transport.CurrentCommand = _commands.ReadDiagnosticArchivesInfo;
            Transport.Send(_functions.ReadDiagnosticArchivesInfo(), true);
            Wait();
        }

        /// <summary>
        /// Читает архивную запись изменений базы данных
        /// </summary>
        public void ReadDatabaseChangesArchive()
        {
            Transport.CurrentCommand = _commands.ReadDatabaseChangesArchive;
            Transport.Send(_functions.ReadDatabaseChangesArchive(), true);
            Wait();
        }

        /// <summary>
        /// Читает запись архива событий
        /// </summary>
        public void ReadEventsArchive()
        {
            Transport.CurrentCommand = _commands.ReadEventsArchive;
            Transport.Send(_functions.ReadEventsArchive(), true);
            Wait();
        }

        /// <summary>
        /// Читает запись диагностического архива
        /// </summary>
        public void ReadDiagnosticArchive()
        {
            Transport.CurrentCommand = _commands.ReadDiagnosticArchive;
            Transport.Send(_functions.ReadDiagnosticArchive(), true);
            Wait();
        }

        /// <summary>
        /// Читает системные настройки
        /// </summary>
        public void GetSystemSettings()
        {
            Transport.CurrentCommand = _commands.GetSystemSettings;
            Transport.Send(_functions.GetSystemSettings(), true);
            Wait();
        }

        /// <summary>
        /// Читает системные настройки (новая прошивка)
        /// </summary>
        public void GetSystemSettingsNewFirmware()
        {
            Transport.CurrentCommand = _commands.GetSystemSettingsNewFirmware;
            Transport.Send(_functions.GetSystemSettingsNewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Читает активную БД
        /// </summary>
        public void GetActiveDatabase()
        {
            Transport.CurrentCommand = _commands.GetActiveDatabase;
            Transport.Send(_functions.GetActiveDatabase(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, трубы 0-2) БД1
        /// </summary>
        private void GetPipesSettingsControlPipes_Db1_0_2()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db1_0_2;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db1_0_2(), true);
            Wait();
        }

        public void GetPipesSettingsControlPipes_0_2(int dbNumber)
        {
            if (dbNumber == 1)
                GetPipesSettingsControlPipes_Db1_0_2();
            else if (dbNumber == 2)
                GetPipesSettingsControlPipes_Db2_0_2();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, трубы 0-2) БД1 (новая прошивка)
        /// </summary>
        private void GetPipesSettingsControlPipes_Db1_0_2NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db1_0_2NewFirmware;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db1_0_2NewFirmware(), true);
            Wait();
        }

        public void GetPipesSettingsControlPipes_0_2NewFirmware(int dbNumber)
        {
            if (dbNumber == 1)
                GetPipesSettingsControlPipes_Db1_0_2NewFirmware();
            else if (dbNumber == 2)
                GetPipesSettingsControlPipes_Db2_0_2NewFirmware(); 
        }

        public void GetPipesSettingsControlPipes_3_5(int dbNumber)
        {
            if (dbNumber == 1)
                GetPipesSettingsControlPipes_Db1_3_5();
            else if (dbNumber == 2)
                GetPipesSettingsControlPipes_Db2_3_5();
        }
        /// <summary>
        /// Чтение настроек труб (контроль, трубы 3-5) БД1
        /// </summary>
        private void GetPipesSettingsControlPipes_Db1_3_5()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db1_3_5;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db1_3_5(), true);
            Wait();
        }

        public void GetPipesSettingsControlPipes_3_5NewFirmware(int dbNumber)
        {
            if (dbNumber == 1)
                GetPipesSettingsControlPipes_Db1_3_5NewFirmware();
            else if (dbNumber == 2)
                GetPipesSettingsControlPipes_Db2_3_5NewFirmware();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, трубы 3-5) БД1 (новая прошивка)
        /// </summary>
        private void GetPipesSettingsControlPipes_Db1_3_5NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db1_3_5NewFirmware;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db1_3_5NewFirmware(), true);
            Wait();
        }

        public void GetPipesSettingsControlPipe_6(int dbNumber)
        {
            if (dbNumber == 1)
                GetPipesSettingsControlPipe_Db1_6();
            else if (dbNumber == 2)
                GetPipesSettingsControlPipe_Db2_6();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, труба 6) БД1
        /// </summary>
        private void GetPipesSettingsControlPipe_Db1_6()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipe_Db1_6;
            Transport.Send(_functions.GetPipesSettingsControlPipe_Db1_6(), true);
            Wait();
        }

        public void GetPipesSettingsControlPipe_6NewFirmware(int dbNumber)
        {
            if (dbNumber == 1)
                GetPipesSettingsControlPipe_Db1_6NewFirmware();
            else if (dbNumber == 2)
                GetPipesSettingsControlPipe_Db2_6NewFirmware();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, труба 6) БД1 (новая прошивка)
        /// </summary>
        private void GetPipesSettingsControlPipe_Db1_6NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipe_Db1_6NewFirmware;
            Transport.Send(_functions.GetPipesSettingsControlPipe_Db1_6NewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, трубы 0-2) БД2
        /// </summary>
        private void GetPipesSettingsControlPipes_Db2_0_2()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db2_0_2;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db2_0_2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, трубы 0-2) БД2 (новая прошивка)
        /// </summary>
        private void GetPipesSettingsControlPipes_Db2_0_2NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db2_0_2NewFirmware;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db2_0_2NewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, трубы 3-5) БД2
        /// </summary>
        private void GetPipesSettingsControlPipes_Db2_3_5()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db2_3_5;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db2_3_5(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, трубы 3-5) БД2 (новая прошивка)
        /// </summary>
        private void GetPipesSettingsControlPipes_Db2_3_5NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipes_Db2_3_5NewFirmware;
            Transport.Send(_functions.GetPipesSettingsControlPipes_Db2_3_5NewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, труба 6) БД2
        /// </summary>
        private void GetPipesSettingsControlPipe_Db2_6()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipe_Db2_6;
            Transport.Send(_functions.GetPipesSettingsControlPipe_Db2_6(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек труб (контроль, труба 6) БД2 (новая прошивка)
        /// </summary>
        private void GetPipesSettingsControlPipe_Db2_6NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetPipesSettingsControlPipe_Db2_6NewFirmware;
            Transport.Send(_functions.GetPipesSettingsControlPipe_Db2_6NewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек тепловых вводов БД1
        /// </summary>
        public void GetTvSettings_Db1()
        {
            Transport.CurrentCommand = _commands.GetTvSettings_Db1;
            Transport.Send(_functions.GetTvSettings_Db1(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек тепловых вводов БД1 (новая прошивка)
        /// </summary>
        public void GetTvSettings_Db1NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetTvSettings_Db1NewFirmware;
            Transport.Send(_functions.GetTvSettings_Db1NewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек тепловых вводов БД2
        /// </summary>
        public void GetTvSettings_Db2()
        {
            Transport.CurrentCommand = _commands.GetTvSettings_Db2;
            Transport.Send(_functions.GetTvSettings_Db2(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек тепловых вводов БД2 (новая прошивка)
        /// </summary>
        public void GetTvSettings_Db2NewFirmware()
        {
            Transport.CurrentCommand = _commands.GetTvSettings_Db2NewFirmware;
            Transport.Send(_functions.GetTvSettings_Db2NewFirmware(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек дополнительного импульсного входа
        /// </summary>
        public void GetImpulseInputSettings()
        {
            Transport.CurrentCommand = _commands.GetImpulseInputSettings;
            Transport.Send(_functions.GetImpulseInputSettings(), true);
            Wait();
        }

        /// <summary>
        /// Чтение настроек дополнительного импульсного входа (новая прошивка)
        /// </summary>
        public void GetImpulseInputSettingsNewFirmware()
        {
            Transport.CurrentCommand = _commands.GetImpulseInputSettingsNewFirmware;
            Transport.Send(_functions.GetImpulseInputSettingsNewFirmware(), true);
            Wait();
        }
    }
}

using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.Device;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Tv7.API
{
    /// <summary>
    /// Мета-описание API-команд ТВ-7
    /// </summary>
    internal sealed class Commands
    {
        // КОМАНДЫ ЧТЕНИЯ
        // "Чтение серийного номера прибора" (0x0005)
        public Command GetFactoryNumber = new Command { CommandName = "GetFactoryNumber", CommandType = CommandType.Read, Code = 5, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFactoryNumber };
        
        // "Чтение информации об устройстве" (0x0000)        
        public Command GetDeviceInfo = new Command { CommandName = "GetDeviceInfo", CommandType = CommandType.Read, Code = 0, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetDeviceInfo };

        // "Чтение текущего приборного времени" (0x0DD4)
        public Command GetDeviceTime = new Command { CommandName = "GetDeviceTime", CommandType = CommandType.Read, Code = 3540, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 3, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetDeviceTime };

        // "Чтение мгновенных температур и давлений" (0x0DD7)
        public Command GetInstantTemperaturesAndPressures = new Command { CommandName = Tv7Resources.GetInstantTemperaturesAndPressures, CommandType = CommandType.Read, Code = 3543, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 24, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantTemperaturesAndPressures };
        /// <summary>
        /// "Чтение мгновенных температур и давлений" (новая прошивка)
        /// </summary>
        public Command GetInstantTemperaturesAndPressuresNewFirmware = new Command { CommandName = Tv7Resources.GetInstantTemperaturesAndPressuresNewFirmware, CommandType = CommandType.Read, Code = 7819, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 28, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantTemperaturesAndPressuresNewFirmware };

        // "Чтение мгновенных объемных и массовых расходов" (0x0DEF)
        public Command GetInstantFlows = new Command { CommandName = Tv7Resources.GetInstantFlows, CommandType = CommandType.Read, Code = 3567, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 24, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantFlows };
        /// <summary>
        /// "Чтение мгновенных объемных и массовых расходов" (новая прошивка)
        /// </summary>
        public Command GetInstantFlowsNewFirmware = new Command { CommandName = Tv7Resources.GetInstantFlowsNewFirmware, CommandType = CommandType.Read, Code = 7847, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 28, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantFlowsNewFirmware };

        // "Чтение мгновенных тепловых потоков и энтальпий по трубопроводам" (0x0E07)
        public Command GetInstantThermalPowersAndEnthalpiesPipes = new Command { CommandName = Tv7Resources.GetInstantThermalPowersAndEnthalpiesPipes, CommandType = CommandType.Read, Code = 3591, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 24, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantThermalPowersAndEnthalpiesPipes };
        // "Чтение мгновенных тепловых потоков и энтальпий по трубопроводам" (новая прошивка)
        public Command GetInstantThermalPowersAndEnthalpiesPipesNewFirmware = new Command { CommandName = Tv7Resources.GetInstantThermalPowersAndEnthalpiesPipesNewFirmware, CommandType = CommandType.Read, Code = 7875, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 28, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantThermalPowersAndEnthalpiesPipesNewFirmware };

        // "Чтение мгновенных тепловых потоков, энтальпий и расхода под доп.каналу" (0x0E1F)
        public Command GetInstantThermalPowersAndEnthalpiesHeatInput = new Command { CommandName = "GetInstantThermalPowersAndEnthalpiesHeatInput", CommandType = CommandType.Read, Code = 3615, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 10, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantThermalPowersAndEnthalpiesHeatInput };

        // "Чтение мгновенных значений температур и давлений по тепловым вводам" (0x0E31)
        public Command GetInstantHeatInputParameters = new Command { CommandName = "GetInstantHeatInputParameters", CommandType = CommandType.Read, Code = 3633, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 16, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetInstantHeatInputParameters };

        // "Чтение текущих итоговых по трубе 1 ТВ1" (0x0D57)
        public Command GetFinalInstantTv1Pipe1 = new Command { CommandName = "GetFinalInstantTv1Pipe1", CommandType = CommandType.Read, Code = 3415, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv1Pipe1 };

        // "Чтение текущих итоговых по трубе 2 ТВ1" (0x0D5F)
        public Command GetFinalInstantTv1Pipe2 = new Command { CommandName = "GetFinalInstantTv1Pipe2", CommandType = CommandType.Read, Code = 3423, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv1Pipe2 };

        // "Чтение текущих итоговых по трубе 3 ТВ1" (0x0D67)
        public Command GetFinalInstantTv1Pipe3 = new Command { CommandName = "GetFinalInstantTv1Pipe3", CommandType = CommandType.Read, Code = 3431, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv1Pipe3 };

        // "Чтение текущих итоговых по трубе 1 ТВ2" (0x0D6F)
        public Command GetFinalInstantTv2Pipe1 = new Command { CommandName = "GetFinalInstantTv2Pipe1", CommandType = CommandType.Read, Code = 3439, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv2Pipe1 };

        // "Чтение текущих итоговых по трубе 2 ТВ2" (0x0D77)
        public Command GetFinalInstantTv2Pipe2 = new Command { CommandName = "GetFinalInstantTv2Pipe2", CommandType = CommandType.Read, Code = 3447, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv2Pipe2 };

        // "Чтение текущих итоговых по трубе 3 ТВ2" (0x0D7F)
        public Command GetFinalInstantTv2Pipe3 = new Command { CommandName = "GetFinalInstantTv2Pipe3", CommandType = CommandType.Read, Code = 3455, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv2Pipe3 };

        // "Чтение текущих итоговых по ТВ1" (0x0D87)
        public Command GetFinalInstantTv1 = new Command { CommandName = "GetFinalInstantTv1", CommandType = CommandType.Read, Code = 3463, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 23, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv1 };

        // "Чтение текущих итоговых по ТВ2" (0x0D9E)
        public Command GetFinalInstantTv2 = new Command { CommandName = "GetFinalInstantTv2", CommandType = CommandType.Read, Code = 3486, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 23, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantTv2};

        // "Чтение текущего итогового значения по дополнительному параметру" (0x0DB5)
        public Command GetFinalInstantAdditionalParameter = new Command { CommandName = "GetFinalInstantAdditionalParameter", CommandType = CommandType.Read, Code = 3509, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetFinalInstantAdditionalParameter };

        // "Чтение отчетного времени" (0x0069)
        public Command GetReportingTime = new Command { CommandName = "GetReportingTime", CommandType = CommandType.Read, Code = 105, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetReportingTime };

        // "Чтение информации о датах начала/конца архивов" (0x0A74)
        public Command GetArchiveDatesInfo = new Command { CommandName = "GetArchiveDatesInfo", CommandType = CommandType.Read, Code = 2676, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 27, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetArchiveDatesInfo };
        
        // "Чтение даты архивной записи" (0x0AB4)
        public Command ReadArchiveTime = new Command { CommandName = "ReadArchiveTime", CommandType = CommandType.Read, Code = 2740, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchiveTime};

        // "Чтение архива по трубе 1" (0x0AB6)
        public Command ReadArchivePipe1 = new Command { CommandName = "ReadArchivePipe1", CommandType = CommandType.Read, Code = 2742, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchivePipe1 };

        // "Чтение архива по трубе 2" (0x0ABE)
        public Command ReadArchivePipe2 = new Command { CommandName = "ReadArchivePipe2", CommandType = CommandType.Read, Code = 2750, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchivePipe2 };

        // "Чтение архива по трубе 3" (0x0AC6)
        public Command ReadArchivePipe3 = new Command { CommandName = "ReadArchivePipe3", CommandType = CommandType.Read, Code = 2758, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchivePipe3 };

        // "Чтение архива по трубе 4" (0x0ACE)
        public Command ReadArchivePipe4 = new Command { CommandName = "ReadArchivePipe4", CommandType = CommandType.Read, Code = 2766, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchivePipe4 };

        // "Чтение архива по трубе 5" (0x0AD6)
        public Command ReadArchivePipe5 = new Command { CommandName = "ReadArchivePipe5", CommandType = CommandType.Read, Code = 2774, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchivePipe5 };

        // "Чтение архива по трубе 6" (0x0ADE)
        public Command ReadArchivePipe6 = new Command { CommandName = "ReadArchivePipe6", CommandType = CommandType.Read, Code = 2782, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchivePipe6 };

        // "Чтение архива по тепловому вводу 1" (0x0AE6)
        public Command ReadArchiveHeatInput1 = new Command { CommandName = "ReadArchiveHeatInput1", CommandType = CommandType.Read, Code = 2790, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchiveHeatInput1 };

        // "Чтение архива по тепловому вводу 2" (0x0AF8)
        public Command ReadArchiveHeatInput2 = new Command { CommandName = "ReadArchiveHeatInput2", CommandType = CommandType.Read, Code = 2808, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchiveHeatInput2 };

        // "Чтение архивного значения  по доп. параметру" (0x0B0A)
        public Command ReadArchiveAdditionalParameter = new Command { CommandName = "ReadArchiveAdditionalParameter", CommandType = CommandType.Read, Code = 2826, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadArchiveAdditionalParameter };

        // ЧТЕНИЕ ИТОГОВОГО АРХИВА
        // "Чтение даты итоговой архивной записи" (0x0B34)
        public Command ReadFinalArchiveTime = new Command { CommandName = "ReadFinalArchiveTime", CommandType = CommandType.Read, Code = 2868, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 2, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchiveTime };

        // "Чтение итогового архива по трубе 1" (0x0B36)
        public Command ReadFinalArchivePipe1 = new Command { CommandName = "ReadFinalArchivePipe1", CommandType = CommandType.Read, Code = 2870, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchivePipe1 };

        // "Чтение итогового архива по трубе 2" (0x0B3E)
        public Command ReadFinalArchivePipe2 = new Command { CommandName = "ReadFinalArchivePipe2", CommandType = CommandType.Read, Code = 2878, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchivePipe2 };

        // "Чтение итогового архива по трубе 3" (0x0B46)
        public Command ReadFinalArchivePipe3 = new Command { CommandName = "ReadFinalArchivePipe3", CommandType = CommandType.Read, Code = 2886, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchivePipe3 };

        // "Чтение итогового архива по трубе 4" (0x0B4E)
        public Command ReadFinalArchivePipe4 = new Command { CommandName = "ReadFinalArchivePipe4", CommandType = CommandType.Read, Code = 2894, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchivePipe4};

        // "Чтение итогового архива по трубе 5" (0x0B56)
        public Command ReadFinalArchivePipe5 = new Command { CommandName = "ReadFinalArchivePipe5", CommandType = CommandType.Read, Code = 2902, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchivePipe5 };

        // "Чтение итогового архива по трубе 6" (0x0B5E)
        public Command ReadFinalArchivePipe6 = new Command { CommandName = "ReadFinalArchivePipe6", CommandType = CommandType.Read, Code = 2910, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchivePipe6 };

        // "Чтение итогового архива по тепловому вводу 1" (0x0B66)
        public Command ReadFinalArchiveHeatInput1 = new Command { CommandName = "ReadFinalArchiveHeatInput1", CommandType = CommandType.Read, Code = 2918, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 23, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchiveHeatInput1 };

        // "Чтение итогового архива по тепловому вводу 2" (0x0B7D)
        public Command ReadFinalArchiveHeatInput2 = new Command { CommandName = "ReadFinalArchiveHeatInput2", CommandType = CommandType.Read, Code = 2941, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 23, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchiveHeatInput2 };

        // "Чтение итогового архивного значения по доп. параметру" (0x0B94)
        public Command ReadFinalArchiveAdditionalParameter = new Command { CommandName = "ReadFinalArchiveAdditionalParameter", CommandType = CommandType.Read, Code = 2964, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadFinalArchiveAdditionalParameter};

        // "Чтение информации об архивах изменений БД (АИБД)"
        public Command ReadDatabaseChangesArchivesInfo = new Command { CommandName = "ReadDatabaseChangesArchivesInfo", CommandType = CommandType.Read, Code = 2996, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadDatabaseChangesArchivesInfo };
        // "Чтение информации об архивах событий" (ААС)
        public Command ReadEventsArchivesInfo = new Command { CommandName = "ReadEventsArchivesInfo", CommandType = CommandType.Read, Code = 3000, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadEventsArchivesInfo };
        // "Чтение информации о диагностическом архиве" (АД)
        public Command ReadDiagnosticArchivesInfo = new Command { CommandName = "ReadDiagnosticArchivesInfo", CommandType = CommandType.Read, Code = 3004, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 4, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadDiagnosticArchivesInfo };

        // "Чтение архивной записи изменений базы данных"
        public Command ReadDatabaseChangesArchive = new Command { CommandName = "ReadDatabaseChangesArchive", CommandType = CommandType.Read, Code = 3028, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadDatabaseChangesArchivesInfo };
        // "Чтение записи архива событий"
        public Command ReadEventsArchive = new Command { CommandName = "ReadEventsArchive", CommandType = CommandType.Read, Code = 3156, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadEventsArchive };
        // "Чтение записи диагностического архива"
        public Command ReadDiagnosticArchive = new Command { CommandName = "ReadDiagnosticArchive", CommandType = CommandType.Read, Code = 3284, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 8, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.ReadDiagnosticArchive };
        /// <summary>
        /// "Ускоренное чтение архивной записи"
        /// </summary>
        public Command SpeedReadArchive = new Command { CommandName = Tv7Resources.SpeedReadArchive, ErrorMessage = Tv7ErrorMessages.SpeedReadArchive, ModbusFunctionCode = ModbusFunction.UserDefined, CommandType = CommandType.Read, ResponseLengthType = LengthType.Fixed, TimeOutBeforeSend = 2, ResponseLength = 184 };
        /// <summary>
        /// "Ускоренное чтение итоговой архивной записи"
        /// </summary>
        public Command SpeedReadFinalArchive = new Command { CommandName = Tv7Resources.SpeedReadFinalArchive, ErrorMessage = Tv7ErrorMessages.SpeedReadFinalArchive, ModbusFunctionCode = ModbusFunction.UserDefined, CommandType = CommandType.Read, ResponseLengthType = LengthType.Fixed, TimeOutBeforeSend = 2, ResponseLength = 208 };

        // КОМАНДЫ ЗАПИСИ
        // "Установка типа читаемых данных" (0x0063)
        public Command SetArchiveDate = new Command { CommandName = "SetArchiveDate", CommandType = CommandType.Write, Code = 99, ModbusFunctionCode = ModbusFunction.PresetMultipleRegisters, RegistersCount = 5, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.SetArchiveDate};
        // "Установка номера записи асинхронного архива"
        public Command SetAsyncArchiveIndex = new Command { CommandName = "SetArchiveIndex", CommandType = CommandType.Write, Code = 103, ModbusFunctionCode = ModbusFunction.PresetMultipleRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.SetAsyncArchiveIndex };


        // НАСТРОЙКИ ПРИБОРА
        // "Системные настройки"
        public Command GetSystemSettings = new Command { CommandName = Tv7Resources.GetSystemSettings, CommandType = CommandType.Read, Code = 105, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetSystemSettings };
        // "Системные настройки (новая прошивка)"
        public Command GetSystemSettingsNewFirmware = new Command { CommandName = Tv7Resources.GetSystemSettingsNewFirmware, CommandType = CommandType.Read, Code = 5000, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetSystemSettingsNewFirmware };
        /// <summary>
        /// "Активная БД"
        /// </summary>
        public Command GetActiveDatabase = new Command { CommandName = Tv7Resources.GetActiveDatabase, CommandType = CommandType.Read, Code = 2670, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 1, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetActiveDatabase };
        /// <summary>
        /// "Настройки труб (контроль, трубы 0-2) БД1"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db1_0_2 = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db1_0_2, CommandType = CommandType.Read, Code = 113, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 51, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db1_0_2 };
        /// <summary>
        /// "Настройки труб (контроль, трубы 0-2) БД1 (новая прошивка)"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db1_0_2NewFirmware = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db1_0_2NewFirmware, CommandType = CommandType.Read, Code = 5008, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 54, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db1_0_2NewFirmware };
        /// <summary>
        /// "Настройки труб (контроль, трубы 3-5) БД1"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db1_3_5 = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db1_3_5, CommandType = CommandType.Read, Code = 164, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 51, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db1_3_5 };
        /// <summary>
        /// "Настройки труб (контроль, трубы 3-5) БД1 (новая прошивка)"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db1_3_5NewFirmware = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db1_3_5NewFirmware, CommandType = CommandType.Read, Code = 5062, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 54, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db1_3_5NewFirmware };
        /// <summary>
        /// "Настройки труб (контроль, труба 6) БД1"
        /// </summary>
        public Command GetPipesSettingsControlPipe_Db1_6 = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipe_Db1_6, CommandType = CommandType.Read, Code = 215, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 17, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipe_Db1_6 };
        /// <summary>
        /// "Настройки труб (контроль, труба 6) БД1 (новая прошивка)"
        /// </summary>
        public Command GetPipesSettingsControlPipe_Db1_6NewFirmware = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipe_Db1_6NewFirmware, CommandType = CommandType.Read, Code = 5116, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipe_Db1_6NewFirmware };

        /// <summary>
        /// "Настройки труб (контроль, трубы 0-2) БД2"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db2_0_2 = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db2_0_2, CommandType = CommandType.Read, Code = 233, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 51, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db2_0_2 };
        /// <summary>
        /// "Настройки труб (контроль, трубы 0-2) БД2 (новая прошивка)"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db2_0_2NewFirmware = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db2_0_2NewFirmware, CommandType = CommandType.Read, Code = 5161, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 54, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db2_0_2NewFirmware };
        /// <summary>
        /// "Настройки труб (контроль, трубы 3-5) БД2"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db2_3_5 = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db2_3_5, CommandType = CommandType.Read, Code = 284, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 51, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db2_3_5 };
        /// <summary>
        /// "Настройки труб (контроль, трубы 3-5) БД2 (новая прошивка)"
        /// </summary>
        public Command GetPipesSettingsControlPipes_Db2_3_5NewFirmware = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipes_Db2_3_5NewFirmware, CommandType = CommandType.Read, Code = 5215, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 54, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipes_Db2_3_5NewFirmware };
        /// <summary>
        /// "Настройки труб (контроль, труба 6) БД2"
        /// </summary>
        public Command GetPipesSettingsControlPipe_Db2_6 = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipe_Db2_6, CommandType = CommandType.Read, Code = 335, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 17, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipe_Db2_6 };
        /// <summary>
        /// "Настройки труб (контроль, труба 6) БД2 (новая прошивка)"
        /// </summary>
        public Command GetPipesSettingsControlPipe_Db2_6NewFirmware = new Command { CommandName = Tv7Resources.GetPipesSettingsControlPipe_Db2_6NewFirmware, CommandType = CommandType.Read, Code = 5269, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetPipesSettingsControlPipe_Db2_6NewFirmware };
        /// <summary>
        /// "Настройки тепловых вводов БД1"
        /// </summary>
        public Command GetTvSettings_Db1 = new Command { CommandName = Tv7Resources.GetTvSettings_Db1, CommandType = CommandType.Read, Code = 215, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetTvSettings_Db1 };
        /// <summary>
        /// "Настройки тепловых вводов БД1 (новая прошивка)"
        /// </summary>
        public Command GetTvSettings_Db1NewFirmware = new Command { CommandName = Tv7Resources.GetTvSettings_Db1NewFirmware, CommandType = CommandType.Read, Code = 5134, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetTvSettings_Db1NewFirmware };
        /// <summary>
        /// "Настройки тепловых вводов БД2"
        /// </summary>
        public Command GetTvSettings_Db2 = new Command { CommandName = Tv7Resources.GetTvSettings_Db2, CommandType = CommandType.Read, Code = 335, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetTvSettings_Db2 };
        /// <summary>
        /// "Настройки тепловых вводов БД2 (новая прошивка)"
        /// </summary>
        public Command GetTvSettings_Db2NewFirmware = new Command { CommandName = Tv7Resources.GetTvSettings_Db2NewFirmware, CommandType = CommandType.Read, Code = 5287, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 18, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetTvSettings_Db2NewFirmware };
        /// <summary>
        /// "Настройки дополнительного импульсного входа"
        /// </summary>
        public Command GetImpulseInputSettings = new Command { CommandName = Tv7Resources.GetImpulseInputSettings, CommandType = CommandType.Read, Code = 353, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetImpulseInputSettings };

        /// <summary>
        /// "Настройки дополнительного импульсного входа (новая прошивка)"
        /// </summary>
        public Command GetImpulseInputSettingsNewFirmware = new Command { CommandName = Tv7Resources.GetImpulseInputSettingsNewFirmware, CommandType = CommandType.Read, Code = 5314, ModbusFunctionCode = ModbusFunction.ReadHoldingRegisters, RegistersCount = 7, ResponseLengthType = LengthType.Calculated, TimeOutBeforeSend = 2, ErrorMessage = Tv7ErrorMessages.GetImpulseInputSettingsNewFirmware };
    }
}

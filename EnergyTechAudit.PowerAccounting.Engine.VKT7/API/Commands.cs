using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API
{
    /// <summary>
    /// Мета-описание API-команд ВКТ-7
    /// </summary>
    internal sealed class Commands
    {
        // КОМАНДЫ ЧТЕНИЯ
        // "Чтение перечня активных элементов данных" (0x3FFC)
        public Command GetActiveElementsList = new Command { CommandName = "GetActiveElementsList", CommandType = CommandType.Read, Code = 16380, ResponseLengthType = LengthType.Calculated, ErrorMessage = Vkt7ErrorMessages.GetActiveElementsList };
        // "Чтение данных" (0x3FFE) 
        public Command GetData = new Command { CommandName = "GetData", CommandType = CommandType.Read, Code = 16382, ResponseLengthType = LengthType.Calculated };
        // "Чтение интервала дат" (0x3FF6)
        public Command GetDateInterval = new Command { CommandName = "GetDateInterval", CommandType = CommandType.Read, Code = 16374, ResponseLengthType = LengthType.Fixed, ResponseLength = 17, ErrorMessage = Vkt7ErrorMessages.GetDateInterval };
        // "Чтение номера схемы измерения для Тв1" (0x3ECD)
        public Command GetMeasurementSchemaNumberTB1 = new Command { CommandName = "GetMeasurementSchemaNumberTB1", RegistersCount = 1, CommandType = CommandType.Read, Code = 16077, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Чтение номера схемы измерения для Тв2" (0x3F5B)
        public Command GetMeasurementSchemaNumberTB2 = new Command { CommandName = "GetMeasurementSchemaNumberTB2", RegistersCount = 1, CommandType = CommandType.Read, Code = 16219, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Чтение номера активной базы данных" (0x3FE9)
        public Command GetActiveDBNumber = new Command { CommandName = "GetActiveDBNumber", CommandType = CommandType.Read, RegistersCount = 1, Code = 16361, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Чтение настройки Идентификатор абонента" (0x3EA6)
        public Command GetDeviceIdentifier = new Command { CommandName = "GetDeviceIdentifier", CommandType = CommandType.Read, RegistersCount = 8, Code = 16038, ResponseLengthType = LengthType.Calculated, ErrorMessage = Vkt7ErrorMessages.GetDeviceIdentifier };
        // "Чтение служебной информации" (0x3FF9)
        public Command GetServiceInformation = new Command { CommandName = "GetServiceInformation", CommandType = CommandType.Read, Code = 16377, ResponseLengthType = LengthType.Calculated, ErrorMessage = Vkt7ErrorMessages.GetServiceInformation };
        // "Чтение состояний дискретных выходов" (0x3FEE)
        public Command GetDiscreteOutputsStates = new Command { CommandName = "GetDiscreteOutputsStates", CommandType = CommandType.Read, Code = 16366, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };

        public Command GetTime = new Command { CommandName = "GetTime", CommandType = CommandType.Read, Code = 16379, ResponseLengthType = LengthType.Fixed, ResponseLength = 13 };

        // КОМАНДЫ ЗАПИСИ
        // "Начало сеанса связи" (0x3FFF)
        public Command StartSession = new Command { CommandName = "StartSession", CommandType = CommandType.Write, Code = 16383, ResponseLengthType = LengthType.Fixed, ResponseLength = 8, ErrorMessage = Vkt7ErrorMessages.StartSession };
        // "Запись перечня элементов для чтения" (0x3FFF)
        public Command SetReadElementsList = new Command { CommandName = "SetReadElementsList", CommandType = CommandType.Write, Code = 16383, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись перечня элементов для чтения" (0x3FFF)
        public Command SetPropertiesElementsList = new Command { CommandName = "SetPropertiesElementsList", CommandType = CommandType.Write, Code = 16383, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запиcь типа значений" (0x3FFD)
        public Command SetValueTypes = new Command { CommandName = "SetValueTypes", CommandType = CommandType.Write, Code = 16381, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
        // "Запись даты" (0x3FFB)
        public Command SetArchiveDate = new Command { CommandName = "SetArchiveDate", CommandType = CommandType.Write, Code = 16379, ResponseLengthType = LengthType.Fixed, ResponseLength = 8 };
    }
}

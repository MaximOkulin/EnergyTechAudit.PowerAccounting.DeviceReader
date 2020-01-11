using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Moxa
{
    internal sealed class Commands
    {
        // КОМАНДЫ ЗАПИСИ
        // "Установка настроек порта"
        public Command SetSettings = new Command { CommandName = "SetSettings", CommandType = CommandType.Write, Code = 0, ResponseLengthType = LengthType.Fixed, ResponseLength = 3 };
        // "Посылка команды начала Telnet-сессии"
        public Command StartTelnetSession = new Command { CommandName = "StartTelnetSession", CommandType = CommandType.Write, Code = 0, ResponseLengthType = LengthType.Fixed, ResponseLength = 500 };
        // "Получение текущих параметров сервера"
        public Command ExamineServerSettings = new Command { CommandName = "ExamineServerSettings", CommandType = CommandType.Write, Code = 0, ResponseLengthType = LengthType.Fixed, ResponseLength = 600 };
    }
}

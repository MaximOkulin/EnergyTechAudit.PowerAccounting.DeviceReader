using System;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types
{ 
    /// <summary>
    /// Статус подключения
    /// </summary>
    public enum StatusConnection
    {
        /// <summary>
        /// Статус неизвестен
        /// </summary>
        Unknown = 1,
        /// <summary>
        /// Соединение успешно установлено
        /// </summary>
        Success = 2,
        /// <summary>
        /// Соединение неуспешно
        /// </summary>
        Fail = 3,
        /// <summary>
        /// Соединение установлено, но при передаче данных возникла ошибка
        /// </summary>
        Loss = 4,
        /// <summary>
        /// Неверные настройки
        /// </summary>
        WrongSettings = 5,
        /// <summary>
        /// Архив отсутствует в памяти контроллера
        /// </summary>
        EmptyArchives = 6
    }

    /// <summary>
    /// Тип длины пакета ответного пакета
    /// </summary>
    public enum LengthType
    {
        /// <summary>
        /// Фиксированный
        /// </summary>
        Fixed,
        /// <summary>
        /// Вычислимый
        /// </summary>
        Calculated,
        /// <summary>
        /// Имеет определенный формат
        /// </summary>
        Format
    }

    public enum CommandType
    {
        Read,
        Write
    }

    public enum CanBeSkip
    {
        No,
        Yes
    }

    /// <summary>
    /// Структура описания команды запроса к устройству
    /// </summary>
    public class Command
    {
        public string CommandName;
        public CommandType CommandType;
        public ModbusFunctionCode ModbusFunctionCode;
        public int NetworkAddress;
        public int RegistersCount;
        public bool IsGenerateErrorResponseException;
        public int Code;
        public LengthType ResponseLengthType;
        public int ResponseLength;
        public int RequestLength;
        public CanBeSkip CanBeSkip;
        public object Tag;
        public Func<byte[], object> CustomCheck;
        /// <summary>
        /// Команда записи, без последующего чтения данных
        /// </summary>
        public bool IsWriteWithoutRead;
        /// <summary>
        /// Команда чтения, без предварительной записи
        /// </summary>
        public bool IsReadWithoutWrite;

        public int TimeOutBeforeSend = 0;
        public int TimeOutBerforeReceive = 0;
        public string ErrorMessage;
        public Func<Command, string> ErrorMessageCreator;
        public bool HasResponseOneByte;
        public byte[] FakeResponse;
    }

    /// <summary>
    /// Модель электросчетчика Меркурий
    /// </summary>
    public enum MercuryModel
    {
        Mercury200 = 0,
        Mercury206 = 1
    }

    /// <summary>
    /// Вид электрической энергии
    /// </summary>
    public enum EnergyType
    {
        /// <summary>
        /// Активная
        /// </summary>
        Active = 0,
        /// <summary>
        /// Реактивная
        /// </summary>
        Reactive = 1
    }

    /// <summary>
    /// Типы транспортов
    /// </summary>
    public enum TransportTypes
    {
        Direct = 1, // прямое подключение через COM-порт
        CSD = 2, // с использованием технологии CSD
        Ethernet = 3, // через локальную сеть Ethernet
        Http= 4 // через Http
    }

    /// <summary>
    /// Коды ошибок, возникающие во время приёма и обработки данных
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Отсутствует
        /// </summary>
        None,
        /// <summary>
        /// Пакет нулевых байтов
        /// </summary>
        NullBytesPackage,
        /// <summary>
        /// Cхема измерения была изменена
        /// </summary>
        MeasurementSchemaChanged,
        /// <summary>
        /// Архивная запись отсутствует
        /// </summary>
        ArchiveDataNotAvailable,
        /// <summary>
        /// Архивная запись ещё не создана
        /// </summary>
        ArchiveDataNotYetBeenCreated,
        /// <summary>
        /// Дискретные выходы не являются управляемыми дистанционно
        /// </summary>
        DigitalOutputsDisabled,
        /// <summary>
        /// Связь с хостом утеряна
        /// </summary>
        LossConnection,
        /// <summary>
        /// Ошибка возникла, но неопределена
        /// </summary>
        Undefined,
        /// <summary>
        /// Неверный пароль
        /// </summary>
        WrongPassword,
        /// <summary>
        /// Неверный код запроса
        /// </summary>
        InvalidRequest,
        /// <summary>
        /// Парольная сессия закрыта счетчиком
        /// </summary>
        SessionClosed,
        /// <summary>
        /// Парольная сессия не открыта
        /// </summary>
        SessionNotOpened,
        /// <summary>
        /// Ошибка при записи параметра в прибор
        /// </summary>
        WriteError,
        /// <summary>
        /// Ошибка чтения
        /// </summary>
        ReadError,
        /// <summary>
        /// Неверный сетевой адрес
        /// </summary>
        WrongNetworkAddress,
        /// <summary>
        /// Отсутствует запрашиваемый код функции
        /// </summary>
        PulsarAbsentRequestedFunctionCode,
        /// <summary>
        /// Ошибка в битовой маске запроса
        /// </summary>
        PulsarBitmaskRequestError,
        /// <summary>
        /// Ошибочная длина запроса
        /// </summary>
        PulsarRequestLengthError,
        /// <summary>
        /// Отсутствует параметр
        /// </summary>
        PulsarAbsentParameter,
        /// <summary>
        /// Запись заблокирована, требуется авторизация
        /// </summary>
        PulsarRecordBlocked,
        /// <summary>
        /// Записываемое значение (параметр) находится вне заданного диапазона
        /// </summary>
        PulsarParameterOutOfRange,
        /// <summary>
        /// Отсутствует запрашиваемый тип архива
        /// </summary>
        PulsarAbsentArchiveType,
        /// <summary>
        /// Превышение максимального количества архивных значений за один пакет
        /// </summary>
        PulsarMaxArchiveCountOverflow,
        /// <summary>
        /// Недопустимая команда или параметр
        /// </summary>
        Mercury230WrongCommand,
        /// <summary>
        /// Внутренняя ошибка счетчика
        /// </summary>
        Mercury230InternalError,
        /// <summary>
        /// Не достаточен уровень доступа для удовлетворения запроса
        /// </summary>
        Mercury230InadequateAccessLevel,
        /// <summary>
        /// Внутренние часы счетчика уже корректировались в течение текущих суток
        /// </summary>
        Mercury230InternalClockCorrectedYet,
        /// <summary>
        /// Не открыт канал связи
        /// </summary>
        Mercury230ConnectionChannelClosed,
        /// <summary>
        /// Недопустимая команда
        /// </summary>
        ForbiddenCommand,
        /// <summary>
        /// Проигнорированная команда
        /// </summary>
        IgnoreCommand,
        /// <summary>
        /// Неправильный код команды в ответе прибора
        /// </summary>
        EskoMtr06WrongResponseCommand,
        /// <summary>
        /// Ошибка в ответе ECL 200/300
        /// </summary>
        Ecl300ErrorResponse,
        /// <summary>
        /// Ошибка записи параметра в память ECL 200/300
        /// </summary>
        Ecl300WriteError,
        /// <summary>
        /// Ошибка выполнения команды Modbus
        /// </summary>
        ModbusErrorResponse,
        /// <summary>
        /// Команда не поддерживается
        /// </summary>
        UnsupportedCommand,
        /// <summary>
        /// Недоступная Modbus-функция
        /// </summary>
        IllegalModbusFunction,
        /// <summary>
        /// Ошибка получения дат начала и конца архивов ВКТ-7
        /// </summary>
        VKT_GetDateIntervalError,
        /// <summary>
        /// Нет значения
        /// </summary>
        NoValue
    }

    public enum LogEntityType
    {
        MeasurementDevice,
        DeviceReader
    }

    public enum DeviceMode
    {
        Single,
        Multiple
    }

    /// <summary>
    /// Статус конфигурирования транспортного сервера
    /// </summary>
    public enum TransportServerConfigurationStatus
    {
        /// <summary>
        /// Успешно сконфигурирован
        /// </summary>
        SuccessfullyConfigured,
        /// <summary>
        /// Сбой конфигурирования
        /// </summary>
        FailureConfiguration,
        /// <summary>
        /// Потеря связи при конфигурировании
        /// </summary>
        LostConnection,
        /// <summary>
        /// Нет соединения
        /// </summary>
        NoConnection
    }

    /// <summary>
    /// Таймауты (в сек.)
    /// </summary>
    public enum TimeOuts
    {
        /// <summary>
        /// Ожидание изменения настроек порта
        /// </summary>
        PortCfg = 5
    }

    /// <summary>
    /// Режимы работы Ecl Comfort 210/310 (Dictionaries.Ecl310OperatingMode)
    /// </summary>
    public enum Ecl310OperatingMode
    {
        Manual = 1,
        Auto = 2,
        Comfort = 3,
        Night = 4,
        FrostProtection = 5
    }

    public enum TelnetPortStatus
    {
        Open = 1,
        Close = 2
    }

    public enum ControllerAdress
    {
        /// <summary>
        /// Прямое подключение через коммуникационный преобразователь
        /// (Moxa, Maestro) 
        /// </summary>
        DirectPolling = 255
    }

    public class ModbusFunctionCode
    {
        /// <summary>
        /// Код запроса
        /// </summary>
        public int RequestCode;
        /// <summary>
        /// Ответ на запрос, в случае возникновения ошибки
        /// </summary>
        public byte WrongResponseCode;
        /// <summary>
        /// Правильный ответ на запрос
        /// </summary>
        public byte GoodResponseCode;
    }

    /// <summary>
    /// Коды функций, поддерживаемые протоколом Modbus
    /// </summary>
    public class ModbusFunction
    {
        public static ModbusFunctionCode ReadCoilStatus = new ModbusFunctionCode { RequestCode = 0x01, WrongResponseCode = 0x81 };
        public static ModbusFunctionCode ReadDiscreteInputs = new ModbusFunctionCode { RequestCode = 0x02, WrongResponseCode = 0x82 };
        /// <summary>
        /// 0x03
        /// </summary>
        public static ModbusFunctionCode ReadHoldingRegisters = new ModbusFunctionCode { RequestCode = 0x03, WrongResponseCode = 0x83 };
        /// <summary>
        /// 0x04
        /// </summary>
        public static ModbusFunctionCode ReadInputRegisters = new ModbusFunctionCode { RequestCode = 0x04, WrongResponseCode = 0x84 };
        public static ModbusFunctionCode ForceSingleCoil = new ModbusFunctionCode { RequestCode = 0x05, WrongResponseCode = 0x85 };
        /// <summary>
        /// 0x06
        /// </summary>
        public static ModbusFunctionCode PresetSingleRegister = new ModbusFunctionCode { RequestCode = 0x06, WrongResponseCode = 0x86 };
        public static ModbusFunctionCode ReadExceptionStatus = new ModbusFunctionCode { RequestCode = 0x07, WrongResponseCode = 0x87 };
        public static ModbusFunctionCode Diagnostic = new ModbusFunctionCode { RequestCode = 0x08, WrongResponseCode = 0x88 };
        public static ModbusFunctionCode GetComEventCounter = new ModbusFunctionCode { RequestCode = 0x0B, WrongResponseCode = 0x8B };
        public static ModbusFunctionCode GetComEventLog = new ModbusFunctionCode { RequestCode = 0x0C, WrongResponseCode = 0x8C };
        public static ModbusFunctionCode ForceMultipleCoils = new ModbusFunctionCode { RequestCode = 0x0F, WrongResponseCode = 0x8F };
        /// <summary>
        /// 0x10
        /// </summary>
        public static ModbusFunctionCode PresetMultipleRegisters = new ModbusFunctionCode { RequestCode = 0x10, WrongResponseCode = 0x90 };
        public static ModbusFunctionCode ReportSlaveId = new ModbusFunctionCode { RequestCode = 0x11, WrongResponseCode = 0x91 };
        public static ModbusFunctionCode ReadFileRecord = new ModbusFunctionCode { RequestCode = 0x14, WrongResponseCode = 0x94 };
        public static ModbusFunctionCode WriteFileRecord = new ModbusFunctionCode { RequestCode = 0x15, WrongResponseCode = 0x95 };
        public static ModbusFunctionCode MaskWriteRegister = new ModbusFunctionCode { RequestCode = 0x16, WrongResponseCode = 0x96 };
        public static ModbusFunctionCode ReadFifoQueue = new ModbusFunctionCode { RequestCode = 0x18, WrongResponseCode = 0x98 };
        public static ModbusFunctionCode EncapsulatedInterfaceTransport = new ModbusFunctionCode { RequestCode = 0x2B, WrongResponseCode = 0xAB };
        public static ModbusFunctionCode UserDefined = new ModbusFunctionCode { RequestCode = 0x46, WrongResponseCode = 0xC6 };

        public static ModbusFunctionCode GetModbusFunction(int code)
        {
            ModbusFunctionCode modbusFunctionCode = null;
            switch (code)
            {
                case 2:
                    modbusFunctionCode = ReadDiscreteInputs;
                    break;
                case 3:
                    modbusFunctionCode = ReadHoldingRegisters;
                    break;
                case 5:
                    modbusFunctionCode = ReadInputRegisters;
                    break;
            }

            return modbusFunctionCode;
        }
    }

    /// <summary>
    /// Набор данных, необходимых для формирования пакета Modbus
    /// </summary>
    public class ModbusFunctionData
    {
        public int DeviceAddress;
        public ModbusFunctionCode Function;
        public int StartingAddress;
        public int RegistersCount;
        public byte[] Data;
        public byte[] ArbitraryData;
    }

    /// <summary>
    /// Идентификаторы каналов в БД
    /// </summary>
    public class ChannelsIds
    {
        public int ChannelOneId = -1;
        public int ChannelTwoId = -1;
        public int ChannelThreeId = -1;

        public int this[int channelNumber]
        {
            get
            {
                if (channelNumber == 1)
                    return ChannelOneId;
                if (channelNumber == 2)
                    return ChannelTwoId;
                if (channelNumber == 3)
                    return ChannelThreeId;
                return -1;
            }
        }

        /// <summary>
        /// Возвращает номер канала по его идентификатору в БД
        /// </summary>
        public int GetChannelNumberById(int id)
        {
            if (id != -1 && id == ChannelOneId)
                return 1;
            if (id != -1 && id == ChannelTwoId)
                return 2;
            if (id != -1 && id == ChannelThreeId)
                return 3;

            return -1;
        }
    }
}

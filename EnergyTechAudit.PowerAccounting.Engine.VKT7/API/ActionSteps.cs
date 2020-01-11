using System;
using System.Collections.Generic;
using System.Threading;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Base;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Transport;
using EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources.ErrorMessages;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.API
{
    /// <summary>
    /// Класс, реализующий шаги действий при взаимодействии с прибором
    /// </summary>
    internal sealed class ActionSteps : ActionStepsBase
    {
        private readonly Functions _functions;
        private readonly Commands _commands;
        private readonly int _timeOutBeforeSend;
        

        public ActionSteps(DeviceTransport vktConnection, ManualResetEvent autoEvent, int deviceAddress, int timeOutBeforeSend)
            :base(vktConnection, autoEvent)
        {
            _functions = new Functions(deviceAddress);
            _commands = new Commands();
            _timeOutBeforeSend = timeOutBeforeSend;
        }

        /// <summary>
        /// Начинает сессию работы с прибором
        /// </summary>
        public void StartSession()
        {
            Transport.CurrentCommand = _commands.StartSession;
            Transport.Send(_functions.StartSession(), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Получает заводской номер устройства
        /// </summary>
        public void GetDeviceIdentifier()
        {
            Transport.CurrentCommand = _commands.GetDeviceIdentifier;
            Transport.Send(_functions.GetDeviceIdentifier(), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Получает номер версии ПО прибора
        /// </summary>
        public void GetServiceInformation()
        {
            Transport.CurrentCommand = _commands.GetServiceInformation;
            Transport.Send(_functions.GetServiceInformation(), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Получает даты архивов и текущую дату прибора
        /// </summary>
        public void GetDateInterval()
        {
            Transport.CurrentCommand = _commands.GetDateInterval;
            Transport.Send(_functions.GetDateInterval(), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Получает текущие дату и время прибора
        /// (для версии ПО 2.7 и выше)
        /// </summary>
        public void GetTime()
        {
            Transport.CurrentCommand = _commands.GetTime;
            Transport.Send(_functions.GetTime(), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Получает тип сервера
        /// </summary>
        public void GetData(DataType dataType)
        {
            Transport.CurrentCommand = _commands.GetData;
            if (dataType == DataType.ServerType)
            {
                Transport.CurrentCommand.ErrorMessage = Vkt7ErrorMessages.ReadServerType;
            }
            else if (dataType == DataType.Archive)
            {
                Transport.CurrentCommand.ErrorMessage = Vkt7ErrorMessages.ReadArchive;
            }

            Transport.Send(_functions.GetData(), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Возвращает список активных элементов текущей измерительной схемы
        /// </summary>
        /// <param name="collection">Список всех доступных параметров ВКТ</param>
        public Dictionary<Parameter, int> GetReadParameters(ParametersCollection collection)
        {
            Transport.CurrentCommand = _commands.GetActiveElementsList;
            Transport.Send(_functions.GetActiveElementsList(), true, null, _timeOutBeforeSend);
            Wait();
            return Parser.ParseActiveElementsList(Transport.Buffer, collection);
        }

        /// <summary>
        /// Получает список единиц измерений и кол-ва точек после запятой
        /// </summary>
        public void GetProperties()
        {
            // a) устанавливаем в устройстве тип значений для считывания - Свойства
            Transport.CurrentCommand = _commands.SetValueTypes;
            Transport.CurrentCommand.ErrorMessage = Vkt7ErrorMessages.GetProperties;
            Transport.Send(_functions.SetValueTypes(ValueTypes.Properties), true, null, _timeOutBeforeSend);
            Wait();

            // б) посылаем в устройство список параметров, для которых хотим получить
            // единицы измерений и кол-во точек после запятой
            Transport.CurrentCommand = _commands.SetPropertiesElementsList;
            Transport.CurrentCommand.ErrorMessage = Vkt7ErrorMessages.GetProperties;
            Transport.Send(_functions.SetPropertiesElementsList(), true, null, _timeOutBeforeSend);
            Wait();

            // в) получаем  данные из устройства
            Transport.CurrentCommand = _commands.GetData;
            Transport.CurrentCommand.ErrorMessage = Vkt7ErrorMessages.GetProperties;
            Transport.Send(_functions.GetData(), true, null, _timeOutBeforeSend);
            Wait();
        }

        public void SetValueType(ValueTypes valueType)
        {
            Transport.CurrentCommand = _commands.SetValueTypes;
            Transport.CurrentCommand.ErrorMessage = string.Format(Vkt7ErrorMessages.SetValueType, valueType);
            Transport.Send(_functions.SetValueTypes(valueType), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Устанавливает в приборе дату, на которую необходимо получить архивную запись
        /// </summary>
        /// <param name="date">Дата</param>
        public void SetArchiveDate(DateTime date)
        {
            Transport.CurrentCommand = _commands.SetArchiveDate;
            Transport.CurrentCommand.ErrorMessage = string.Format(Vkt7ErrorMessages.SetArchiveDate, date);
            Transport.Send(_functions.SetArchiveDate(date), true, null, _timeOutBeforeSend);
            Wait();
        }

        /// <summary>
        /// Устанавливает список параметров, которые необходимо прочитать
        /// </summary>
        /// <param name="paramsToRead">Словарь параметров</param>
        public void SetReadElementsList(Dictionary<Parameter, int> paramsToRead)
        {
            Transport.CurrentCommand = _commands.SetReadElementsList;
            Transport.Send(_functions.SetReadElementsList(paramsToRead), true, null, _timeOutBeforeSend);
            Wait();
        }

        public void GetDiscreteOutputsStates()
        {
            Transport.CurrentCommand = _commands.GetDiscreteOutputsStates;
            Transport.Send(_functions.GetDiscreteOutputsStates(), true, null, _timeOutBeforeSend);
            Wait();
        }
    }
}

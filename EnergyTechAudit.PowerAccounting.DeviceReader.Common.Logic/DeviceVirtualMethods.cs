using System.Collections.Generic;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic
{
    public partial class Device
    {
        /// <summary>
        /// Выполняет произвольное действие
        /// (используется для осуществления вспомогательных операций с приборами)
        /// </summary>
        protected virtual void ExecuteCustomAction()
        {

        }

        /// <summary>
        /// Выполняет опрос прибора
        /// (должен быть реализован индивидуально каждым прибором)
        /// </summary>
        protected virtual void Polling()
        {

        }

        /// <summary>
        /// Инициализирует транспортное подключение и шаги выполнения действий
        /// (должен быть реализован индивидуально каждым прибором)
        /// </summary>
        protected virtual void InitTransport()
        {

        }

        /// <summary>
        /// Возвращает наличие связи с прибором
        /// (должен быть реализован индивидуально каждым прибором)
        /// </summary>
        /// <returns>Описание результата подключения</returns>
        protected virtual Dictionary<string, string> GetConnectionExistence()
        {
            var result = new Dictionary<string, string>();

            result.Add(CommandsKeys.CheckConnectionExistenceNotImplementedKey, DeviceMessages.CheckConnectionExistenceNotImplemented);

            return result; 
        }

        protected virtual Dictionary<string, string> GetCurrents()
        {
            var result = new Dictionary<string, string>();

            result.Add(CommandsKeys.GetCurrentsNotImplementedKey, DeviceMessages.GetCurrentsNotImplemented);

            return result;
        }

        protected virtual Dictionary<string, string> ExecuteExtensionCommand(string commandName)
        {
            var result = new Dictionary<string, string>();

            result.Add(CommandsKeys.ExecuteExtensionCommandKey, DeviceMessages.ExecuteExtensionCommandNotImplemented);

            return result;
        }

        /// <summary>
        /// Выполняет действия, реализуемые конкретной моделью прибора после опроса
        /// </summary>
        protected virtual void DevicePostPollingActions()
        {

        }

        /// <summary>
        /// Чтение данных в режиме реального времени
        /// </summary>
        protected virtual void ReadRealTimeData()
        {

        }
    }
}

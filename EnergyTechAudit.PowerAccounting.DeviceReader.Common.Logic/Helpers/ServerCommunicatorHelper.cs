using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;
using EnergyTechAudit.PowerAccounting.IISInteraction;
using EnergyTechAudit.PowerAccounting.LightDataAccess.Business;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Logic.Helpers
{
    /// <summary>
    /// Класс, облегчающий работу с классом ServerCommunicator
    /// </summary>
    public class ServerCommunicatorHelper
    {
        private readonly ServerCommunicator _serverCommunicator;

        /// <summary>
        /// Результирующий словарь для команды "Мгновенные данные обновлены"
        /// </summary>
        private static Dictionary<string, string> _updateInstantDataResult = new Dictionary<string, string>
        {
             { DeviceMessages.ServerCommunicatorCommandKey, DeviceMessages.DeviceReaderGetInstantDataCommand }
        };


        public ServerCommunicatorHelper(ServerCommunicatorSettings settings)
        {
            _serverCommunicator = new ServerCommunicator(settings);
        }



        /// <summary>
        /// Отправляет IIS-серверу сигнал о том, что мгновенные данные были обновлены
        /// </summary>
        /// <param name="measurementDevice">Объект измерительного устройства с обновленным полем LastTimeSignatureId</param>
        public void SendUpdateInstantDataSignal(MeasurementDevice measurementDevice)
        {
            _serverCommunicator.SendCallback(string.Empty, _updateInstantDataResult, new MeasurementDevice
            {
                Id = measurementDevice.Id,
                LastTimeSignatureId = measurementDevice.LastTimeSignatureId
            });
        }

        /// <summary>
        /// Отправляет IIS-серверу сигнал со считанными мгновенными данными для обновления мнемосхемы
        /// </summary>
        /// <param name="measurementDeviceId"></param>
        /// <param name="parameters"></param>
        public void SendUpdateMnemoschemeDataSignal(int measurementDeviceId, MnemoschemeParametersInfo info)
        {
            var result = new Dictionary<string, string>
            {
                { DeviceMessages.ServerCommunicatorCommandKey, DeviceMessages.DeviceReaderGetInstantDataCommand },
                { CommandsKeys.ParametersListKey, JsonConvert.SerializeObject(info) }
            };

            _serverCommunicator.SendCallback(string.Empty, result, new MeasurementDevice
            {
                Id = measurementDeviceId
            });
        }

        public void SendParamsForPartialUpdateMnemoscheme(int measurementDeviceId, MnemoschemeParametersInfo info)
        {
            var result = new Dictionary<string, string>
            {
                { DeviceMessages.ServerCommunicatorCommandKey, DeviceMessages.DeviceReaderGetInstantDataCommand },
                { CommandsKeys.ParametersListKey, JsonConvert.SerializeObject(info) }
            };

            _serverCommunicator.SendMnemoschemeParamsForOnlyUpdates(string.Empty, result, new MeasurementDevice
            {
                Id = measurementDeviceId
            });
        }

        /// <summary>
        /// Отправляет IIS-серверу сигнал о том, что метеоданные были обновлены
        /// </summary>
        /// <param name="meteoDataJson">Метеоданные в формате JSON</param>
        public void SendMeteoDataToDashboard(string meteoDataJson)
        {
            var result = new Dictionary<string, string>
            {
                { DeviceMessages.ServerCommunicatorCommandKey, DeviceMessages.DeviceReaderGetMeteoDataCommand }
            };

            _serverCommunicator.SendCallback(string.Empty, result, new MeasurementDevice { Id = 1 });
        }
    }
}

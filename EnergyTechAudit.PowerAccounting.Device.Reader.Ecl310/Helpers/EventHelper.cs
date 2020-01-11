using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers;
using EnergyTechAudit.PowerAccounting.DeviceReader.Common.Types.Proxy;
using EnergyTechAudit.PowerAccounting.DeviceReader.Resources;

namespace EnergyTechAudit.PowerAccounting.Device.Reader.Ecl310.Helpers
{
    internal sealed class EventHelper : EventHelperBase
    {
        public EventHelper(int deviceId): base(deviceId)
        {
            
        }
        /// <summary>
        /// Фиксирует событие смены ключа приложения
        /// </summary>
        public void CreateKeyChangedEvent()
        {
            CreateEvent(EventParameter.Ecl310KeyChanged);
            SaveEvents();
        }
    }
}

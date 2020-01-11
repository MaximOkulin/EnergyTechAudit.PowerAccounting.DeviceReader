using System;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.CommonTypes
{
    public sealed class CurrentArchiveDateInfo
    {
        public int DiffDeviceParameterId { get; set; }
        public DateTime? Date { get; set; }
    }
}

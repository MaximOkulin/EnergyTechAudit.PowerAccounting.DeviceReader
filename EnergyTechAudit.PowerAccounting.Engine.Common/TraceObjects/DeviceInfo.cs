using System;
using System.Xml.Serialization;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.TraceObjects
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class DeviceInfo
    {
        public DateTime Time { get; set; }

        public QueueType QueueType { get; set; }

        public string Text { get; set; }

        public int DeviceId { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }
}

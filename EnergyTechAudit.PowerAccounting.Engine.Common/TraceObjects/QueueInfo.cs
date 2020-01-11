using System;
using System.Xml;
using System.Xml.Serialization;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.TraceObjects
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class QueueInfo
    {
        public DateTime Time { get; set; }

        public QueueType QueueType { get; set; }

        [XmlArrayItem("QueueItem")]
        public QueueItem[] QueueItems { get; set; }

        public string ThreadCount { get; set; }
    }

    public class QueueItem
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }

        [XmlElement(ElementName = "StartTime")]
        public DateTime XmlStartTime
        {
            get { return Convert.ToDateTime(XmlConvert.ToString(StartTime, XmlDateTimeSerializationMode.RoundtripKind)); }
        }

        public string Description { get; set; }
        public string PlacementDescription { get; set; }
    }
}

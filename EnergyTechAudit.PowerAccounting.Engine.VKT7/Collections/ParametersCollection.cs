using System.IO;
using System.Xml.Serialization;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections
{
    public class ParametersCollection
    {
        [XmlElement("Parameter")]
        public Parameter[] Parameters { get; set; }

        /// <summary>
        /// Десериализует XML-описание параметров в объект-коллекцию
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ParametersCollection GetParametersCollection()
        {
            ParametersCollection collection;

            var serializer = new XmlSerializer(typeof(ParametersCollection));
            using (var stringReader = new StringReader(Resources.Device.Vkt7Resources.ParametersCollectionXml))
            {
                collection = (ParametersCollection)serializer.Deserialize(stringReader);
            }

            return collection;
        }
    }

    public class Parameter
    {
        public string Name { get; set; }

        public byte Id { get; set; }

        public string DeviceParameterCode { get; set; }

        public string IntegrationDeviceParameterCode { get; set; }

        public string DecimalCode { get; set; }

        public string ParseType { get; set; }

        public string HeatInput { get; set; }

        [XmlAttribute()]
        public bool BeInstant { get; set; }

        [XmlAttribute()]
        public bool BeFinal { get; set; }

        [XmlAttribute()]
        public bool BeFinalInstant { get; set; }

        [XmlAttribute()]
        public bool BeHourly { get; set; }

        [XmlAttribute()]
        public bool BeDaily { get; set; }

        [XmlAttribute()]
        public bool BeMonthly { get; set; }
    }
}


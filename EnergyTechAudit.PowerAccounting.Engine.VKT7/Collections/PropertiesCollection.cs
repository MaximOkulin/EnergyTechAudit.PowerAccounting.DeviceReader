using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.VKT7.Collections
{
    public class PropertiesCollection
    {
        [XmlElement("Property")]
        public Property[] Properties { get; set; }

        /// <summary>
        /// Десериализует XML-описание свойств в объект-коллекцию
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PropertiesCollection GetParametersCollection(string path)
        {
            var locker = new ReaderWriterLockSlim();
            PropertiesCollection collection;
            try
            {
                locker.EnterReadLock();
                var serializer = new XmlSerializer(typeof(PropertiesCollection));
                var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                collection = (PropertiesCollection)serializer.Deserialize(fs);
            }
            finally
            {
                locker.ExitReadLock();
            }
            return collection;
        }
    }

    public class Property
    {
        public string Name { get; set; }

        public string MeasurementUnitCode { get; set; }

        public string DimensionCode { get; set; }
    }
}

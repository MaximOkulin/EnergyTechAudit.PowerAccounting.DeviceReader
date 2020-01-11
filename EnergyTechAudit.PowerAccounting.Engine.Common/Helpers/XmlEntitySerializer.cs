using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public static class XmlEntitySerializer
    {
        /// <summary>
        /// Выполняет десериализацию объекта из XML
        /// </summary>
        /// <param name="xml">Строковое представление XML</param>
        /// <returns>Объект TEntity</returns>
        public static TEntity Parse<TEntity>(string xml) where TEntity : class
        {
            var serializer = new XmlSerializer(typeof(TEntity));

            TEntity entity = null;

            using (TextReader reader = new StringReader(xml))
            {
                entity = (TEntity)serializer.Deserialize(reader);
            }
            return entity;
        }

        /// <summary>
        /// Выполняет сериализацию объекта в XML
        /// </summary>
        /// <typeparam name="TEntity">Класс сериализуемого объекта</typeparam>
        /// <param name="entity">Объект</param>
        /// <param name="rootName"></param>
        /// <param name="withFormat"></param>
        /// <returns>XML</returns>
        public static string Serialize<TEntity>(TEntity entity, string rootName = null, bool withFormat = false) where TEntity : class
        {
            string result;

            try
            {
                var settings = withFormat
                    ? new XmlWriterSettings
                    {
                        Indent = true,
                        IndentChars = "\t"
                    }
                    : new XmlWriterSettings();

                StringWriter stringWriter = null;

                try
                {
                    stringWriter = new StringWriter();
                    using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        var xmlSerializer = !string.IsNullOrEmpty(rootName)
                            ? new XmlSerializer(typeof(TEntity), new XmlRootAttribute(rootName))
                            : new XmlSerializer(typeof(TEntity));

                        xmlSerializer.Serialize(xmlWriter, entity);
                        result = stringWriter.ToString();
                    }
                }
                finally
                {
                    if (stringWriter != null)
                    {
                        stringWriter.Dispose();
                    }
                }

            }
            catch
            {
                result = null;
            }

            return result;
        }
    }
}

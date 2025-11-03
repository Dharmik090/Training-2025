using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingestion.Pipeline.Writers
{
    /// <summary>
    /// Creates directory if not exists for given path
    /// Uses XmlSerializer to write objects of type T into .xml file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class XmlReportWriter<T> : IReportWriter<T>
    {
        // Sealed because this class provides a complete implementation.
        // If you need different XML behavior, create a new class.

        public void WriteReport(IEnumerable<T> items, string outputPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
            {
                serializer.Serialize(fileStream, items);
            }
        }
    }

}

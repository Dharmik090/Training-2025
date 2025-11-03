using Ingestion.Pipeline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Writers
{

    /// <summary>
    /// Writes report data to a human-readable text file.
    /// </summary>
    public sealed class TextReportWriter<T> : IReportWriter<T>
    {
        // Marked sealed because we don’t expect extension via inheritance.
        // Future customization should use composition instead.

        /// <summary>
        /// Creates directory if not exists for given path
        /// Uses StreamWriter to write objects of type T into .txt file
        /// </summary>
        /// <param name="items"></param>
        /// <param name="outputPath"></param>
        public void WriteReport(IEnumerable<T> items, string outputPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                //writer.WriteLine($"Report generated at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                //writer.WriteLine($"Total books: {items.Count()}");
                //writer.WriteLine();

                foreach (T item in items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
    }

}

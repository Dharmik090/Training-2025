using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Writers
{
    /// <summary>
    /// Defines a common interface for writing reports of a given type.
    /// </summary>
    public interface IReportWriter<T>
    {
        /// <summary>
        /// Writes a report for the given data to the specified output path.
        /// </summary>
        void WriteReport(IEnumerable<T> items, string outputPath);
    }
}

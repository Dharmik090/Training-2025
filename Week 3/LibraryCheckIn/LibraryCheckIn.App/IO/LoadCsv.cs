using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckIn.App.IO
{
    internal class LoadCsv : IFileToDataTable
    {
        public DataTable ToDataTable(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Input file not found: {filePath}");

            DataTable dt = new DataTable();

            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                foreach (var header in values)
                {
                    dt.Columns.Add(header);
                }

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    values = line.Split(',');
                    
                    var row = dt.NewRow();
                    for (int i = 0; i < values.Length; i++)
                    {
                        row[i] = values[i];
                    }
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }
    }
}

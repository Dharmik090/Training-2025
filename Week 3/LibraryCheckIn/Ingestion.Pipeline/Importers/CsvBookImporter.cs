using Ingestion.Pipeline.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importers
{
    /// <summary>
    /// Read .csv file using File.ReadAllLines <br></br>
    /// Create DataTable from lines <br></br>
    /// Convert DataTable to List of Book objects <br></br>
    /// </summary>
    public sealed class CsvBookImporter : FileImporter<Book>, IDataTableToObject<Book>
    {
        /// <summary>
        /// Read .csv file using File.ReadAllLines
        /// Create DataTable from these lines
        /// ToObject(DataTable) : Convert DataTable to List of Book objects
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public override List<Book> Import(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Input file not found: {filePath}");

            string[] lines = File.ReadAllLines(filePath);

            // Create DataTable from lines
            DataTable objDt = new DataTable();

            foreach (string columns in lines[0].Split(','))
            { 
                objDt.Columns.Add(columns);
            }

            foreach (string line in lines.Skip(1))
            {
                string[] value = line.Split(',');

                DataRow row = objDt.NewRow();
                for (int i = 0; i < value.Length; i++)
                    row[i] = value[i];
                
                objDt.Rows.Add(row);
            }

            // Convert DataTable to List of Book objects
            List<Book> books = ToObject(objDt);

            return books;
        }


        /// <summary>
        /// Converts DataTable to List of Book objects
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Book> ToObject(DataTable dt)
        { 
            List<Book> books = new List<Book>();

            // using DataRow.Field<T> extension method
            foreach (DataRow row in dt.Rows)
            {
                Book objBook = new Book
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Title = row.Field<string>("Title"),
                    Author = row.Field<string>("Author"),
                    Condition = Enum.Parse<BookCondition>(row["Condition"].ToString(), true)
                };

                books.Add(objBook);
            }
            
            /*
            // using simple manual conversion
            //foreach (DataRow row in dt.Rows)
            //{
            //    Book book = new Book
            //    {
            //        Id = int.Parse(row["Id"].ToString()),
            //        Title = row["Title"].ToString(),
            //        Author = row["Author"].ToString(),
            //        Condition = (BookCondition)Enum.Parse(typeof(BookCondition), row["Condition"].ToString())
            //    };
            //    books.Add(book);
            //}

            //using LINQ-based approach
            //List<Book> books = dt.AsEnumerable()
            //.Select(row => new Book
            //{
            //    Id = row.Field<int>("Id"),
            //    Title = row.Field<string>("Title"),
            //    Author = row.Field<string>("Author"),
            //    Condition = (BookCondition)Enum.Parse(typeof(BookCondition), row["Condition"].ToString())
            //})
            //.ToList();

            // using Json serialization
            //string json = JsonSerializer.Serialize(dt);

            //List<Book>? books = JsonSerializer.Deserialize<List<Book>>(json);
            */
            
            return books;
        }
    }
}

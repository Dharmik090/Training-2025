// See https://aka.ms/new-console-template for more information
using LibraryCheckIn.App.IO;
using LibraryCheckIn.App.Models;
using System.Data;
using System.Text.Json;

namespace LibraryCheckIn.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "returns_20250401.csv";

            Console.WriteLine($"Reading file: {filePath}");

            var dt = new IO.LoadCsv().ToDataTable(filePath);


            // Convert DataTable to List of objects

            List<Book> books = new List<Book>();

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

            // using DataRow.Field<T> extension methdo
            foreach (DataRow row in dt.Rows)
            {
                Book book = new Book
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Title = row.Field<string>("Title"),
                    Author = row.Field<string>("Author"),
                    Condition = Enum.Parse<BookCondition>(row["Condition"].ToString(), true)
                };
                books.Add(book);
            }
            
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

            Report.GenerateReport(books);



            Console.ReadLine();

        }
    }
}

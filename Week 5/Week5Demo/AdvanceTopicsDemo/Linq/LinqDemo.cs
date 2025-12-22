using AdvanceTopicsDemo.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTopicsDemo.Linq
{
    internal class LinqDemo
    {
        private static DataTable table = new DataTable();

        public static void InitializeDataTable()
        {
            Console.WriteLine("=== Creating DataTable ===");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Grade", typeof(string));

            // Insert data
            table.Rows.Add(1, "Alice", 20, "A");
            table.Rows.Add(2, "Bob", 22, "B");
            table.Rows.Add(3, "Charlie", 23, "C");
            table.Rows.Add(4, "John", 20, "A");
        }

        public static void QueryDataTable()
        {
            Console.WriteLine("=== Querying DataTable with LINQ ===");


            // Students with Grade = 'A'
            var gradeAStudents = table.AsEnumerable()
                .Where(row => row.Field<string>("Grade") == "A")
                .Select(row => new
                {
                    Name = row.Field<string>("Name"),
                    Age = row.Field<int>("Age")
                });

            Console.WriteLine("Students with Grade = 'A':");
            foreach (var s in gradeAStudents)
                Console.WriteLine($" - {s.Name} ({s.Age} yrs)");


            // Sort students by Age ascending
            var sortedByAge = table.AsEnumerable()
                .OrderBy(row => row.Field<int>("Age"));

            Console.WriteLine("\nStudents sorted by Age:");
            foreach (var r in sortedByAge)
                Console.WriteLine($" - {r.Field<string>("Name")} ({r.Field<int>("Age")} yrs)");


            // Find average age
            var avgAge = table.AsEnumerable()
                .Average(row => row.Field<int>("Age"));
            Console.WriteLine($"\nAverage Age = {avgAge:F1}");


            // Group by Grade
            var groupedByGrade = table.AsEnumerable()
                .GroupBy(row => row.Field<string>("Grade"))
                .Select(gradeGroup => new
                {
                    Grade = gradeGroup.Key,
                    Count = gradeGroup.Count(),
                    Names = string.Join(", ", gradeGroup.Select(r => r.Field<string>("Name")))
                });

            Console.WriteLine("\nGrouped by Grade:");
            foreach (var g in groupedByGrade)
                Console.WriteLine($"Grade {g.Grade}: {g.Count} students ({g.Names})");
        }

        //public static void QueryList()
        //{
        //    List<Book> books = new List<Book>
        //    {
        //        new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin" },
        //        new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt" },
        //        new Book { Id = 3, Title = "C# in Depth", Author = "Jon Skeet" },
        //        new Book { Id = 4, Title = "Refactoring", Author = "Martin Fowler" },
        //        new Book { Id = 5, Title = "Clean Architecture", Author = "Robert C. Martin" }
        //    };

        //    Console.WriteLine("=== LINQ with List<Book> ===\n");

        //    // Filter books by author
        //    IEnumerable<object> martinBooks = books
        //        .Where(b => b.Na.Contains("Martin"))
        //        .Select(b => new { b.Title, b.Author });

        //    Console.WriteLine("Books written by 'Martin':");
        //    foreach (Book b in martinBooks)
        //        Console.WriteLine($" - {b.Title} ({b.Author})");


        //    // Sort books alphabetically by Title
        //    IEnumerable<Book> sortedBooks = books
        //        .OrderBy(b => b.Title);

        //    Console.WriteLine("\nBooks sorted by Title:");
        //    foreach (var b in sortedBooks)
        //        Console.WriteLine($" - {b.Title}");


        //    // Get total number of books
        //    int total = books.Count();
        //    Console.WriteLine($"\nTotal Books = {total}");


        //    // Group books by Author
        //    var groupedByAuthor = books
        //        .GroupBy(b => b.Author)
        //        .Select(g => new
        //        {
        //            Author = g.Key,
        //            Count = g.Count(),
        //            Titles = string.Join(", ", g.Select(x => x.Title))
        //        });

        //    Console.WriteLine("\nGrouped by Author:");
        //    foreach (var g in groupedByAuthor)
        //        Console.WriteLine($"{g.Author}: {g.Count} books ({g.Titles})");


        //    // Get first book that starts with 'C'
        //    Book firstCBook = books.FirstOrDefault(b => b.Title.StartsWith("C"));
            
        //    if (firstCBook != null)
        //        Console.WriteLine($"\nFirst book starting with 'C': {firstCBook.Title} by {firstCBook.Author}");


        //    // Convert to Dictionary (Id, Title)
        //    Dictionary<int, string> bookDict = books.ToDictionary(b => b.Id, b => b.Title);
            
        //    Console.WriteLine("\nDictionary (Id, Title):");
            
        //    foreach (KeyValuePair<int,string> kvp in bookDict)
        //        Console.WriteLine($" {kvp.Key}: {kvp.Value}");
        //}
    }
}

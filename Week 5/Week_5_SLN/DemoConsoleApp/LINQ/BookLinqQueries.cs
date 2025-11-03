using DemoConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.LINQ
{
    internal class BookLinqQueries
    {
        public static void ShowBooksByAuthor(DataTable table, string author)
        {
            //IEnumerable<object> books = from row in table.AsEnumerable()
            //            where row.Field<string>("Author") == author
            //            select row;

            IEnumerable<DataRow> books = table.AsEnumerable()
                             .Where(row => row.Field<string>("Author") == author);

            Console.WriteLine($"=== Books by {author} ===");
            foreach (DataRow book in books)
            {
                Console.WriteLine($"{book["Title"]} by {book["Author"]}");
            }
            Console.WriteLine();
        }

        public static void ShowBooksSortedByTitle(DataTable table)
        {
            //IEnumerable<DataRow> sortedBooks = from row in table.AsEnumerable()
            //                  orderby row.Field<string>("Title")
            //                  select row;

            IEnumerable<DataRow> sortedBooks = table.AsEnumerable()
                .OrderBy(row => row.Field<string>("Title"));

            Console.WriteLine("=== Books Sorted by Title ===");
            foreach (DataRow book in sortedBooks)
            {
                Console.WriteLine($"{book["Title"]}");
            }
            Console.WriteLine();
        }

        public static void ShowTitlesAndAuthors(DataTable table)
        {
            //var titles = from row in table.AsEnumerable()
            //                             select new
            //                             {
            //                                 Title = row.Field<string>("Title"),
            //                                 Author = row.Field<string>("Author")
            //                             };

            var titles = table.AsEnumerable().Select(row => new
            {
                Title = row.Field<string>("Title"),
                Author = row.Field<string>("Author")
            });

            Console.WriteLine("=== Titles and Authors ===");
            foreach (var item in titles)
            {
                Console.WriteLine($"{item.Title} - {item.Author}");
            }
            Console.WriteLine();
        }

        public static void ShowBooksGroupedByAuthor(DataTable table)
        {
            IEnumerable<IGrouping<string, DataRow>> groups = table.AsEnumerable().GroupBy(row => row.Field<string>("Author"));

            Console.WriteLine("=== Books Grouped by Author ===");
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} book(s)");
            }
            Console.WriteLine();
        }

        public static void ShowFirstBookByAuthor(DataTable table, string author)
        {
            DataRow book = table.AsEnumerable()
                            .FirstOrDefault(b => b.Field<string>("Author") == author);

            Console.WriteLine($"=== First Book by {author} ===");
            if (book != null)
                Console.WriteLine($"{book["Title"]} by {book["Author"]}");
            else
                Console.WriteLine("No book found.");
            Console.WriteLine();
        }

        public static void ShowTotalBookCount(DataTable table)
        {
            int count = table.AsEnumerable().Count();
            Console.WriteLine($"Total books in table: {count}");
            Console.WriteLine();
        }

    }
}

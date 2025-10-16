using LibraryCheckIn.App.Domain;
using LibraryCheckIn.App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckIn.App.IO
{
    internal class Report
    {
        public static void GenerateReport(List<Book> books) 
        {
            string time = DateTime.Now.ToString("yyyyMMdd");
            string fileName = $"daily_summary_{time}.txt";

            // Count by book condition
            var conditionCount = new Dictionary<BookCondition, int>();
            foreach(BookCondition con in Enum.GetValues(typeof(BookCondition)))
                conditionCount[con] = 0;

            foreach (Book b in books)
                conditionCount[b.Condition]++;


            // Write to Report
            using (var writer = new StreamWriter(fileName))
            {
                // Header
                writer.WriteLine($"Date/time processed: {time}");
                writer.WriteLine();
                
                // Count by condition
                writer.WriteLine("Count by condition:");
                foreach (var kv in conditionCount)
                    writer.WriteLine($"  {kv.Key}: {kv.Value}");

                // Book Details
                writer.WriteLine();
                writer.WriteLine("Book Penalties:");
                foreach (var book in books)
                {
                    int score = book.Condition switch
                    {
                        BookCondition.Good => 0,
                        BookCondition.Worn => 3,
                        BookCondition.Damaged => 10,
                        BookCondition => -1
                    };

                    writer.WriteLine($"\"{book.Title}\" by {book.Author} — Penalty: {score}");
                }
            }

            Console.WriteLine($"Report generated");
        }
    }
}

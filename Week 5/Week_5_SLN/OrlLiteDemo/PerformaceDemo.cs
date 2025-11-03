using ServiceStack.OrmLite.SqlServer;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace OrlLiteDemo
{
    /// <summary>
    /// Demonstrates performance comparison between OrmLite and raw SQL queries.
    /// </summary>
    internal class PerformaceDemo
    {
        // Database connection string
        private static readonly string connectionString =
            //"Data Source=(localdb)\\MSSQLLocalDB;Database=OrmDb;Integrated Security=True;Encrypt=True";
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrmDb;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>
        /// Compares SELECT query performance between OrmLite and raw SQL.
        /// </summary>
        public static void ComparePerformance()
        {
            Console.WriteLine("=== *SELECT* Performance Comparison ===");

            int iterations = 1000;

            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(
                connectionString, SqlServerOrmLiteDialectProvider.Instance);

            // Measure OrmLite performance
            Stopwatch ormWatch = Stopwatch.StartNew();
            using (IDbConnection db = dbFactory.Open())
            {
                // Select query using OrmLite
                List<Book> books = db.Select<Book>();

                foreach (Book b in books)
                {
                    string title = b.Title;
                    string author = b.Author;
                    Console.WriteLine(title + " by " + author);
                }
            }
            ormWatch.Stop();

            // Measure raw SQL performance
            Stopwatch sqlWatch = Stopwatch.StartNew();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Select query using raw SQL
                SqlCommand selectCmd = new SqlCommand("SELECT Title, Author FROM Book", conn);
                using (SqlDataReader reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader["Title"].ToString();
                        string author = reader["Author"].ToString();
                        Console.WriteLine(title + " by " + author);
                    }
                }

                conn.Close();
            }
            sqlWatch.Stop();

            // Display results
            Console.WriteLine($"OrmLite select: {ormWatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Raw SQL select: {sqlWatch.ElapsedMilliseconds} ms");

            Console.WriteLine("\n=== Comparison Completed ===");
        }
    }
}

using ServiceStack.OrmLite.SqlServer;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;

namespace OrlLiteDemo
{
    /// <summary>
    /// Demonstrates basic CRUD operations using ServiceStack.OrmLite.
    /// </summary>
    internal class OrmCrud
    {
        // Database connection string
        private static readonly string connectionString =
            //"Data Source=(localdb)\\MSSQLLocalDB;Database=OrmDb;User Id=ormdemo;Password=123456;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrmDb;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>
        /// Runs a demo showing create, read, update, and delete operations with OrmLite.
        /// </summary>
        public static void OrmLiteDemo()
        {
            Console.WriteLine("=== OrmLite Demo ===");

            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(
                connectionString, SqlServerOrmLiteDialectProvider.Instance);

            using (IDbConnection db = dbFactory.Open())
            {
                // Create table if not exists
                db.CreateTableIfNotExists<Book>();

                // Insert sample records
                db.Insert(new Book { Title = "Alchemist", Author = "Paulo Coelho" });
                db.Insert(new Book { Title = "Harry Potter", Author = "J. K. Rowling" });

                // Insert All
                List<Book> newBooks = new List<Book>
                {
                    new Book { Title = "The Hobbit", Author = "J. R. R. Tolkien" },
                    new Book { Title = "1984", Author = "George Orwell" }
                };
                db.InsertAll(newBooks);

                // Get by Id
                Book book = db.SingleById<Book>(1);

                // Select with filter
                List<Book> coelhoBooks = db.Select<Book>(b => b.Author == "Paulo Coelho");

                // Get Book with Author name start with "Paulo"
                Book firstCoelhoBook = db.Single<Book>(b => b.Author.StartsWith("Paulo"));


                // Read and display all books
                List<Book> books = db.Select<Book>();
                Console.WriteLine("Books in DB:");
                foreach (Book b in books)
                    Console.WriteLine($"{b.Id}: {b.Title} - {b.Author}");

                // Update a book record
                Book objAlchemist = db.Single<Book>(b => b.Title == "Alchemist");
                objAlchemist.Title = "The Alchemist";
                db.Update(objAlchemist);

                // Delete a record
                db.Delete<Book>(b => b.Author == "J. K. Rowling");
            }

            Console.WriteLine("=== Demo Completed ===\n");
        }
    }
}

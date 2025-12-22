using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using ServiceStack.OrmLite.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTopicsDemo.OrmLite
{
    /// <summary>
    /// Demonstrates basic CRUD operations using ServiceStack.OrmLite.
    /// </summary>
    internal class OrmLiteDemo
    {
        // Database connection string
        private static readonly string connectionString =
                //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrmDb;Integrated Security=True;TrustServerCertificate=True;";
                "Server=127.0.0.1;Port=3306;Database=OrmDb;Uid=root;Pwd=;SslMode=none;";

        /// <summary>
        /// Runs a demo showing create, read, update, and delete operations with OrmLite.
        /// </summary>
        public static void DbCrud()
        {
            Console.WriteLine("=== OrmLite Demo ===");

            //OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(
            //    connectionString, SqlServerOrmLiteDialectProvider.Instance);

            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(
                connectionString, ServiceStack.OrmLite.MySqlConnectorDialect.Provider);


            using (IDbConnection db = dbFactory.Open())
            {
                Console.WriteLine("\nCreating Tables:");

                // Create table if not exists
                db.CreateTableIfNotExists<Author>();
                db.CreateTableIfNotExists<Book>();

                
                // Insert sample records
                Author a1 = new Author() { Name = "Paulo Coelho", Age = 75 };
                int id = (int)db.Insert(a1, selectIdentity: true);
                
                List<Book> books1 = new List<Book>()
                {
                    new Book { Title = "The Alchemist", AuthorId = id },
                    new Book { Title = "Brida", AuthorId = id },
                };

                db.Insert(books1[0]);
                db.Insert(books1[1]);

                // InsertAll
                //List<Author> authorList = new List<Author>()
                //{
                //    new Author { Name = "James Clear", Age = 45 },
                //    new Author { Name = "J. K. Rowling", Age = 57 },
                //};

                //db.InsertAll(authorList);


                db.Save(new Book
                {
                    Title = "Harry Potter",
                    Author = new Author { Name = "J. K. Rowling", Age = 57 }
                }, references: true);


                // Save with referenced entity
                db.Save(new Book {
                    Title = "Think and Grow Rich",
                    Author = new Author {
                        Name = "Napoleon Hill",
                        Age = 87
                    }
                }, references: true); 
                


                // Select
                List<Book> allBooks = db.Select<Book>();

                foreach (Book b in allBooks) {
                    // Load Reference
                    db.LoadReferences(b);

                    Console.WriteLine($"- {b.Title} by {b.Author.Name} (Age: {b.Author.Age})");
                }

                // select n rows
                List<Author> top2Authors = db.Select<Author>(a => a.Limit(2));

                // Select with filter
                List<Book> coelhoBooks = db.Select<Book>(b => b.Author.Name == "Paulo Coelho");

                // Get by Id
                Book book = db.SingleById<Book>(1);

                // Get Single with condition
                Book firstOfNapoleon = db.Single<Book>(b => b.Author.Name == "Napoleon Hill");

                // Get Book with Author name start with "Paulo"
                Book firstCoelhoBook = db.Single<Book>(b => b.Author.Name.StartsWith("Paulo"));

                // Select only titles
                List<string> bookTitles = db.Column<string>(
                    db.From<Book>()
                        .Select(b => b.Title)
                );

                // Join Books with Authors where Author Age > 40
                SqlExpression<Book> joinQuery = db.From<Book>()
                  .Join<Author>()
                  .Where<Author>(a => a.Age > 40);

                List<Book> results = db.LoadSelect<Book>(joinQuery);



                // Count authors under 50
                int peopleUnder50 = (int)db.Count<Author>(x => x.Age < 50);



                // Update with object
                Author authorToUpdate = db.Single<Author>(a => a.Name == "J. K. Rowling");
                authorToUpdate.Age = 58;
                db.Update(authorToUpdate);

                // UpdateOnly
                db.UpdateOnly(() => new Author { Age = 76 },
                    where: a => a.Name == "Paulo Coelho");

                // UpdateOnlyFields
                db.UpdateOnlyFields(new Author { Age = 46 },
                    onlyFields: x => x.Age,
                    where: x => x.Name == "J. K. Rowling");



                //// Delete
                //db.Delete<Book>(b => b.Title == "Brida");

                //db.DeleteById<Author>(1);

                //SqlExpression<Author> authorToDelete = db.From<Author>()
                //    .Where(a => a.Age > 50);

                //db.Delete(authorToDelete);

                //db.Delete<Author>("Age = @age", new { age = 50 });

            }

            Console.WriteLine("=== Demo Completed ===\n");
        }
    }

}

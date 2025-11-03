using DemoConsoleApp.EFCore;
using DemoConsoleApp.LINQ;
using DemoConsoleApp.Model;
using DemoConsoleApp.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace DemoConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (BookDbContext context = new BookDbContext())
            {
                Console.WriteLine(context.Database.GetDbConnection().ConnectionString);
                Console.WriteLine(context.Database.EnsureCreated());
                Console.ReadLine();
            }



            /**************************************************************/
            Console.WriteLine();
            Console.WriteLine("DataTable:");

            DataTable bookTable = BookDataTable.CreateBookDataTable();

            // Add sample data
            BookDataTable.AddBookToDataTable(bookTable, new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet" });
            BookDataTable.AddBookToDataTable(bookTable, new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin" });
            BookDataTable.AddBookToDataTable(bookTable, new Book { Id = 3, Title = "The Pragmatic Programmer", Author = "Andrew Hunt" });

            // Display all books
            Console.WriteLine("All Books:");
            BookDataTable.DisplayDataTable(bookTable);

            // Update a book
            Console.WriteLine("\nUpdating Book with Id = 2...");
            BookDataTable.UpdateBookInDataTable(bookTable, 2, "Clean Code (Updated)", "Robert C. Martin");

            // Delete a book
            Console.WriteLine("\nDeleting Book with Id = 1...");
            BookDataTable.DeleteBookFromDataTable(bookTable, 1);

            // Filter books by author
            Console.WriteLine("\nBooks by 'Robert C. Martin':");
            BookDataTable.FilterBooksByAuthor(bookTable, "Robert C. Martin");



            /**************************************************************/
            Console.WriteLine();
            Console.WriteLine("Linq:");

            BookLinqQueries.ShowBooksByAuthor(bookTable, "John Doe");
            BookLinqQueries.ShowBooksSortedByTitle(bookTable);
            BookLinqQueries.ShowTitlesAndAuthors(bookTable);
            BookLinqQueries.ShowBooksGroupedByAuthor(bookTable);
            BookLinqQueries.ShowFirstBookByAuthor(bookTable, "Jane Smith");
            BookLinqQueries.ShowTotalBookCount(bookTable);



            /***************************************************************/
            Console.WriteLine();
            Console.WriteLine("Database:");

            BookRepository repo = new BookRepository();

            // Add some books
            repo.AddBook(new Book { Title = "C# Basics", Author = "John Doe" });
            repo.AddBook(new Book { Title = "EF Core Guide", Author = "Jane Smith" });

            Console.WriteLine("=== All Books ===");
            foreach (Book b in repo.GetAllBooks())
                Console.WriteLine($"{b.Id}: {b.Title} - {b.Author}");

            Console.WriteLine();

            // Update a book
            repo.UpdateBook(1, "C# Advanced", "John Doe");

            // Filter by author
            repo.ShowBooksByAuthor("John Doe");

            // Delete a book
            repo.DeleteBook(2);

            Console.WriteLine("\n=== Final List ===");
            foreach (Book b in repo.GetAllBooks())
                Console.WriteLine($"{b.Id}: {b.Title} - {b.Author}");



            /****************************************************************/
            dynamic a = 5;
            var x = "hello";
            object c = 10.29;

            a = 10;
            a = "abc";

            //x = 10; // error
            x = "world";

            c = "test";
            c = 20;


            Console.WriteLine("VAR:");
            var number = 10;    
            var text = "Dharmik";           
            var list = new List<string>() { "C#", "Java" };

            Console.WriteLine($"number type: {number.GetType()}");
            Console.WriteLine($"text type: {text.GetType()}");
            Console.WriteLine($"list type: {list.GetType()}\n");

            //number = "Hello";
            Console.WriteLine($"Upper: {text.ToUpper()}"); 


            Console.WriteLine("OBJECT:");
            object objNum = 25;
            object objStr = "Hello";

            Console.WriteLine($"objNum type: {objNum.GetType()}");
            Console.WriteLine($"objStr type: {objStr.GetType()}");

            //int res = objNum + 5; 
            int res = (int)objNum + 5;  // Explicit cast
            Console.WriteLine($"After casting: {x}");

            // Explicit cast before using specific members
            Console.WriteLine($"Uppercase string: {((string)objStr).ToUpper()}\n");


            Console.WriteLine("DYNAMIC:");
            dynamic dynVal = 50;
            Console.WriteLine($"dynVal type: {dynVal.GetType()}");
            Console.WriteLine($"dynVal + 10 = {dynVal + 10}"); 

            dynVal = "Hello World";
            Console.WriteLine($"dynVal type now: {dynVal.GetType()}");
            Console.WriteLine($"dynVal.ToUpper() = {dynVal.ToUpper()}");  

            dynVal.NonExist();

            Console.WriteLine();



            Console.WriteLine("json with dynamic");
            string json = "{ \"name\": \"John\", \"skills\": [\"C#\", \"AI\", \"Robotics\"] }";

            object data = JsonConvert.DeserializeObject<object>(json);
            Console.WriteLine($"Name: {data.name}");
            Console.WriteLine($"First Skill: {data.skills[0]}\n");



            Console.ReadLine();

        }
    }
}
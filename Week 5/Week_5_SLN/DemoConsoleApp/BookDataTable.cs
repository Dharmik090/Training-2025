using System;
using System.Data;
using DemoConsoleApp.Model;

namespace DemoConsoleApp
{
    /// <summary>
    /// Provides basic operations for managing books in a DataTable.
    /// </summary>
    internal class BookDataTable
    {
        /// <summary>
        /// Creates and returns a DataTable for storing books.
        /// </summary>
        public static DataTable CreateBookDataTable()
        {
            DataTable table = new DataTable("Books");

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Author", typeof(string));

            table.PrimaryKey = new DataColumn[] { table.Columns["Id"] };

            return table;
        }

        /// <summary>
        /// Adds a new book to the DataTable.
        /// </summary>
        public static void AddBookToDataTable(DataTable table, Book book)
        {
            DataRow row = table.NewRow();
            row["Id"] = book.Id;
            row["Title"] = book.Title;
            row["Author"] = book.Author;
            table.Rows.Add(row);
        }

        /// <summary>
        /// Updates an existing book in the DataTable by Id.
        /// </summary>
        public static void UpdateBookInDataTable(DataTable table, int id, string newTitle, string newAuthor)
        {
            DataRow row = table.Rows.Find(id);
            if (row != null)
            {
                row["Title"] = newTitle;
                row["Author"] = newAuthor;
            }
            else
            {
                Console.WriteLine($"Book with Id = {id} not found.");
            }
        }

        /// <summary>
        /// Deletes a book from the DataTable by Id.
        /// </summary>
        public static void DeleteBookFromDataTable(DataTable table, int id)
        {
            DataRow row = table.Rows.Find(id);
            if (row != null)
            {
                table.Rows.Remove(row);
            }
            else
            {
                Console.WriteLine($"Book with Id = {id} not found.");
            }
        }

        /// <summary>
        /// Displays books by a specific author.
        /// </summary>
        public static void FilterBooksByAuthor(DataTable table, string author)
        {
            DataRow[] rows = table.Select($"Author = '{author}'");
            foreach (DataRow row in rows)
            {
                Console.WriteLine($"Id: {row["Id"]}, Title: {row["Title"]}, Author: {row["Author"]}");
            }
        }

        /// <summary>
        /// Displays all books in the DataTable.
        /// </summary>
        public static void DisplayDataTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Id: {row["Id"]}, Title: {row["Title"]}, Author: {row["Author"]}");
            }
        }
    }
}

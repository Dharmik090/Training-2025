using DemoConsoleApp.EFCore;
using DemoConsoleApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoConsoleApp.Repository
{
    internal class BookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository()
        {
            _context = new BookDbContext();
            _context.Database.EnsureCreated(); // create DB if not exists
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(int id, string newTitle, string newAuthor)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                _context.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public void ShowBooksByAuthor(string author)
        {
            var books = _context.Books
                                .Where(b => b.Author == author)
                                .ToList();

            Console.WriteLine($"=== Books by {author} ===");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}: {book.Title}");
            }
        }
    }
}

using DemoConsoleApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.EFCore
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options){ }

        public BookDbContext() { }

        public DbSet<Book> Books { get; set; }

        // Connecting to database within the DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Connect to Database Server
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True");

                // Connect to specific database of Database Server
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=DemoDatabase_5;Integrated Security=True");
            }
        }
    }
}

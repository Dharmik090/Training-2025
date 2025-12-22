using ServiceStack;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTopicsDemo.OrmLite
{
    /// <summary>
    /// Represents a book entity in the library system.
    /// This class is used to store and retrieve book records from the database.
    /// </summary>
    [Alias("Books")]
    internal class Book
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [References(typeof(Author))]
        public int AuthorId { get; set; }


        [Reference]
        public Author Author { get; set; }

    }

}
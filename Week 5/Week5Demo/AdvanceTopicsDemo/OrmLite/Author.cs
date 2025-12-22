using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTopicsDemo.OrmLite
{
    /// <summary>
    /// Represents an author entity with Id, Name, and Age properties.
    /// Used for ORM mapping with ServiceStack OrmLite.
    /// </summary>
    internal class Author
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }
    }
}

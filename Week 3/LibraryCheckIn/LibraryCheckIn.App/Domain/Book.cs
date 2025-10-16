using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckIn.App.Models
{
    /// <summary>
    /// BookCondition as Enum type <br></br>
    /// Book class with Id, Title, Author, BookCondition members <br></br>
    /// 
    /// Id: int
    /// Title: string
    /// Author: string
    /// BookCondtion: enum, { New, Good, Worn, Damaged}
    /// </summary>
    public enum BookCondition { 
        New, 
        Good, 
        Worn, 
        Damaged 
    };

    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookCondition Condition { get; set;} 
    }
}

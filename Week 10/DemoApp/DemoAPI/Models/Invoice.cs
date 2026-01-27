using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Invoice { 
        public int Id { get; set; } 
        public string Number { get; set; }
        public decimal Total { get; set; }
    }
}
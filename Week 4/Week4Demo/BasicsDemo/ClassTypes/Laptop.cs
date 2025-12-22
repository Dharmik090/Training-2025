using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo.ClassTypes
{
    internal class Laptop : Computer
    {
        public Laptop(string brand) : base(brand)
        {
        }

        public override void Start()
        {
            Console.WriteLine($"Starting laptop computer of brand {Brand}");
        }

        public override void temp()
        {
            Console.WriteLine("Laptop temp method implementation");
        }
    }
}

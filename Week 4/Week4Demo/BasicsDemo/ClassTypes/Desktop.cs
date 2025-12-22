using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo.ClassTypes
{
    internal class Desktop : Computer
    {
        public Desktop(string brand) : base(brand)
        {
        }

        public override void Start()
        {
            Console.WriteLine($"Starting desktop computer of brand {Brand}");
        }
    }
}

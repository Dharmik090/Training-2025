using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo.ClassTypes
{
    internal abstract class Computer
    {
        public string Brand { get; set; }
        protected int Storage { get; set; }
        public Computer(string brand)
        {
            Brand = brand;
        }

        // Abstract method, must be implemented
        public abstract void Start();

        // Non-abstract method
        public void Terminal()
        {
            Console.WriteLine("Opening terminal");
        }

        public virtual void temp() {
            Console.WriteLine("Computer temp method implementation");
        }
    }
}

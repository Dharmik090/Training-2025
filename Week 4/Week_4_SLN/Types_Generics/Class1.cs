using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Types_Generics
{
    internal class Class1
    {
        public static void DemoMethd() {
            Console.WriteLine("Hello");
        }

        public void simpleMethod() { }
    }

    internal class Class2
    {
        public Class1 obj;
        public Class2() { 
            Class1.DemoMethd();
            obj = new Class1();
            obj.simpleMethod();

            obj.DemoMethd();
        }

    }
}

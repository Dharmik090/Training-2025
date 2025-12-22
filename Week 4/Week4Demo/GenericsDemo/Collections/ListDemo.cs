using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    internal class ListDemo
    {
        public static void Demo()
        {
            List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };
            fruits.Add("Mango");

            Console.WriteLine("\nList<T> Example:");

            fruits.ForEach(f => Console.WriteLine(f));
        }
    }
}

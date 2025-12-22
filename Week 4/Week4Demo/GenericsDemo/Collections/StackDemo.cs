using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Collections
{
    internal class StackDemo
    {
        public static void Demo()
        {
            Stack<int> numbers = new Stack<int>();

            numbers.Push(10);
            numbers.Push(20);
            numbers.Push(30);

            Console.WriteLine(numbers.Peek());
            Console.WriteLine($"Contains 20? {numbers.Contains(20)}.");

            while (numbers.Count > 0)
            {
                Console.WriteLine($"Popped element: {numbers.Pop()}");
            }


        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Collections
{
    internal class QueueDemo
    {
        public static void Demo()
        {
            Queue<string> tasks = new Queue<string>();
            
            tasks.Enqueue("Task 1");
            tasks.Enqueue("Task 2");
            tasks.Enqueue("Task 3");
            
            while (tasks.Count > 0)
            {
                Console.WriteLine($"Processed: {tasks.Dequeue()}");
            }
        }
    }
}

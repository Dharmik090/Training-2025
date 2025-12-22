using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.Collections
{
    internal class DictionaryDemo
    {
        public static void Demo()
        {
            Dictionary<int, string> studentMap = new Dictionary<int, string>
            {
                { 1, "Alice" },
                { 2, "Bob" },
                { 3, "Charlie" }
            };

            Console.WriteLine("\nDictionary<TKey, TValue> Example:");
            
            foreach (KeyValuePair<int, string> kvp in studentMap)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
            }

            // Lookup example
            if (studentMap.ContainsKey(2))
                Console.WriteLine($"Student with ID 2: {studentMap[2]}");

        }
    }
}

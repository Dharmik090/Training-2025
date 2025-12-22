using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BasicsDemo
{
    internal class MyString
    {
        public static void Demo()
        {
            // string => shorthand for System.String
            string name = "Dharmik";
            int age = 21;
            Console.WriteLine($"Interpolated: My name is {name} and I am {age} years old.");

            // ToUpper and ToLower
            Console.WriteLine($"Upper: {name.ToUpper()}");
            Console.WriteLine($"Lower: {name.ToLower()}");

            // Length
            Console.WriteLine($"Length: {name.Length}");

            // Substring
            Console.WriteLine($"Substring (0-5): {name.Substring(0, 5)}");

            // Replace
            string newText = name.Replace("Dharmik", "John");
            Console.WriteLine($"Replace: {newText}");

            // Split
            string text = "Name, Age, Gender";

            string[] words = text.Split(',');
            Console.WriteLine("Split:");
            foreach (string word in words)
            {
                Console.WriteLine($"  -> {word.Trim()}");
            }

            // String.Format
            string formatted = string.Format("Today is {0:D}", DateTime.Now);
            Console.WriteLine($"Formatted: {formatted}");

            // StringBuilder
            StringBuilder sb = new StringBuilder();

            sb.Append("Hello");
            sb.Append(", ");
            sb.Append("World");

            Console.WriteLine(sb.ToString());

            Console.WriteLine($"\nStringBuilder Length: {sb.Length}");
            Console.WriteLine($"StringBuilder Capacity: {sb.Capacity}");

        }
    }
}

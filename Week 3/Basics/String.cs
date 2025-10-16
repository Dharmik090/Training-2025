// Demonstrates various string operations in C#
// Example: Length, Substring, Replace, Split, ToUpper, ToLower

using System;

class StringExample
{
    static void Main()
    {
        string text = "Hello, World!";

        stringBuilder sb = new stringBuilder();

        String str = new String();

        // Length of string
        Console.WriteLine($"Length: {text.Length}");

        // Substring
        Console.WriteLine($"Substring (0-5): {text.Substring(0, 5)}");

        // Replace
        string newText = text.Replace("World", "C#");
        Console.WriteLine($"Replace: {newText}");

        // Split
        string[] words = text.Split(',');
        Console.WriteLine("Split:");
        foreach (var word in words)
        {
            Console.WriteLine(word.Trim());
        }

        // ToUpper and ToLower
        Console.WriteLine($"Upper: {text.ToUpper()}");
        Console.WriteLine($"Lower: {text.ToLower()}");
    }
}

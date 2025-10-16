// Demonstrates various mathematical functions in C#
// Example: Absolute value, rounding, power, square root, and trigonometry

using System;

class MathExample
{
    static void Main()
    {
        double number = -15.7;
        double pi = Math.PI;

        // Absolute value
        Console.WriteLine($"Absolute: {Math.Abs(number)}");

        Convert.ToInt32(number);
        Convert.ToDouble(number);
        
        // Rounding
        Console.WriteLine($"Round: {Math.Round(number)}");
        Console.WriteLine($"Ceiling: {Math.Ceiling(number)}");
        Console.WriteLine($"Floor: {Math.Floor(number)}");

        // Power and square root
        Console.WriteLine($"2^3: {Math.Pow(2, 3)}");
        Console.WriteLine($"Sqrt(16): {Math.Sqrt(16)}");

        // Trigonometry
        Console.WriteLine($"Sin(PI/2): {Math.Sin(pi / 2)}");
    }
}

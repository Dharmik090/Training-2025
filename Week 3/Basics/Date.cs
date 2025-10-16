// Demonstrates various date and time operations in C#
// Example: Current date/time, formatting, adding days/months, difference between dates

using System;

class DateExample
{
    static void Main()
    {
        DateTime now = DateTime.Now;
        Console.WriteLine($"Current Date and Time: {now}");

        Console.WriteLine($"{now.AddYears(-1)}");

        // Access parts
        // Console.WriteLine($"Year: {now.Year}, Month: {now.Month}, Day: {now.Day}");

        // // Add days, months
        // DateTime nextWeek = now.AddDays(7);
        // DateTime nextMonth = now.AddMonths(1);
        // Console.WriteLine($"Next Week: {nextWeek}");
        // Console.WriteLine($"Next Month: {nextMonth}");

        // // Formatting
        // Console.WriteLine($"Formatted: {now.ToString("dd-MM-yyyy HH:mm")}");

        // // Difference between dates "YYYY-MM-DD"
        // DateTime birthday = new DateTime(2000, 1, 1);
        // TimeSpan age = now - birthday;
        // Console.WriteLine($"Days since birthday: {age.Days}");
    }
}

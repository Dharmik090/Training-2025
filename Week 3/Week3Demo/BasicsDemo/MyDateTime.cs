using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo
{
    internal class MyDateTime
    {
        public static void Demo()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Current Date and Time: {now}");

            Console.WriteLine($"{now.AddYears(-1)}");

            Console.WriteLine($"Year: {now.Year}, Month: {now.Month}, Day: {now.Day}");

            // Add days, months
            DateTime nextWeek = now.AddDays(7);
            DateTime nextMonth = now.AddMonths(1);
            Console.WriteLine($"Next Week: {nextWeek}");
            Console.WriteLine($"Next Month: {nextMonth}");

            // Formatting
            Console.WriteLine($"Formatted: {now.ToString("dd-MM-yyyy HH:mm")}");

            // Difference between dates "YYYY-MM-DD"
            DateTime birthday = new DateTime(2000, 1, 1);

            // TimeSpan: represents a duration
            TimeSpan age = now - birthday;
            Console.WriteLine($"Days since birthday: {age.Days}");

            // DateTime arithmetic
            DateTime futureDate = now.Add(new TimeSpan(10, 5, 0, 0));
            Console.WriteLine($"Future Date (10 days, 5 hours later): {futureDate}");

            // Parsing
            string dateString = "2024-12-25";
            DateTime parsedDate = DateTime.Parse(dateString);

            // UTC vs Local Time
            Console.WriteLine($"Local Time: {DateTime.Now}");
            Console.WriteLine($"UTC Time: {DateTime.UtcNow}");

            DateTime localTime = DateTime.UtcNow.ToLocalTime();

            // Day of the week
            Console.WriteLine($"Today is: {now.DayOfWeek}");

            Console.WriteLine("Days of the week:");
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($" - {day}");
            }

        }
    }
}

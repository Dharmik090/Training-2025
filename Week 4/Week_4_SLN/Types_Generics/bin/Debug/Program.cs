using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types_Generics.DocumentProcessing;
using Types_Generics.Generics;
using Types_Generics.Generics.Serialization;

namespace Types_Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------------------------------------
            // Document Processing Example
            //TxtDocument txt = new TxtDocument("Sample File", "sample.txt");
            //txt.Load();
            //txt.Print();
            //txt.ToUpperCase();

            CsvDocument csv = new CsvDocument("Employee Salary csv", "employee.csv");
            csv.Load();
            csv.Print();
            csv.ConvertToJson();



            //-----------------------------------------------------------------
            // Example of Generics
            //ExampleWithoutGen obj = new ExampleWithoutGen();
            //obj.Value = 1;
            //obj.Value = "Hello World"; // valid, no error, not type safe
            //string x = (string)obj.Value;

            //ExampleWithGen<int> intObj = new ExampleWithGen<int>();
            //intObj.Value = 2;
            ////intObj.Value = "Hello World"; // error at compile time, type mismatch
            //int y = intObj.Value;

            //var dict = new Dictionary<int, string>
            //{
            //    { 1, "One" },
            //    { 2, "Two" }
            //};



            //-----------------------------------------------------------------
            // Serialization - Deserialization
            //var person = new Person
            //{
            //    Name = "Alice",
            //    Age = 28,
            //    City = "New York"
            //};

            //var converter = new FileConverter();

            //// JSON
            //converter.SaveAsJson(person, "person.json");
            //var jsonPerson = converter.LoadFromJson<Person>("person.json");
            //Console.WriteLine($"JSON Object: {jsonPerson.Name}, {jsonPerson.Age}, {jsonPerson.City}");

            //// XML
            //converter.SaveAsXml(person, "person.xml");
            //var xmlPerson = converter.LoadFromXml<Person>("person.xml");
            //Console.WriteLine($"XML Object: {xmlPerson.Name}, {xmlPerson.Age}, {xmlPerson.City}");



            //-----------------------------------------------------------------
            // Lambda Expressions Example
            //List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            //IEnumerable<int> even = numbers.Where(n => n % 2 == 0);

            //Console.WriteLine("Even numbers: " + string.Join(", ", even));



            //-----------------------------------------------------------------
            // String Extension Method
            string word = "hello";
            Console.WriteLine(word.ToTitleCase()); 



            //-----------------------------------------------------------------

            Console.ReadLine();
        }
    }
}

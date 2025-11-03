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
            //Person person = new Person
            //{
            //    Name = "Alice",
            //    Age = 28,
            //    City = "New York"
            //};

            //FileConverter converter = new FileConverter();

            //// JSON
            //converter.SaveAsJson(person, "person.json");
            //Person jsonPerson = converter.LoadFromJson<Person>("person.json");
            //Console.WriteLine($"JSON Object: {jsonPerson.Name}, {jsonPerson.Age}, {jsonPerson.City}");

            //// XML
            //converter.SaveAsXml(person, "person.xml");
            //Person xmlPerson = converter.LoadFromXml<Person>("person.xml");
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



            // ----------------------------------------------------------------
            List<string> names = new List<string>();
            names.Add("Alice");
            names.Add("Bob");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
            stack.Clear();


            Queue<double> queue = new Queue<double>();
            queue.Enqueue(1.1);
            queue.Enqueue(2.2);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            queue.Clear();


            Dictionary<int, string> students = new Dictionary<int, string>();
            students.Add(1, "Alice");
            students.Add(2, "Bob");

            foreach (KeyValuePair<int, string> kvp in students)
            {
                Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
            }

            HashSet<string> cities = new HashSet<string>();
            cities.Add("New York");
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("London"); // duplicate will be ignored

            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }


            //-----------------------------------------------------------------

            Console.ReadLine();
        }
    }
}

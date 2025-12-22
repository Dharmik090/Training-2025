// See https://aka.ms/new-console-template for more information
using SerializationDemo;
using SerializationDemo.Documents;
using SerializationDemo.SerializeDemo;


// ---------------------------------------------------------------------------------
// File processing
//TxtDocument txt = new TxtDocument("Sample File", "sample.txt");
//txt.Load();
//txt.Print();
//txt.ToUpperCase();

CsvDocument csv = new CsvDocument("Employee Salary csv", "employee.csv");
csv.Load();
csv.Print();
csv.ConvertToJson();



// ---------------------------------------------------------------------------------
// Serialization - Deserialization
Person person = new Person
{
    Name = "Alice",
    Age = 28,
    City = "New York"
};


// JSON
FileConverter.SaveAsJson(person, "person.json");

Person jsonPerson = FileConverter.LoadFromJson<Person>("person.json");

Console.WriteLine($"JSON Object: {jsonPerson.Name}, {jsonPerson.Age}, {jsonPerson.City}");

// XML
FileConverter.SaveAsXml(person, "person.xml");

Person xmlPerson = FileConverter.LoadFromXml<Person>("person.xml");

Console.WriteLine($"XML Object: {xmlPerson.Name}, {xmlPerson.Age}, {xmlPerson.City}");




// ---------------------------------------------------------------------------------
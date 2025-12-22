// See https://aka.ms/new-console-template for more information
using AdvanceTopicsDemo.Linq;
using AdvanceTopicsDemo.OrmLite;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

// ------------------------------------------------------------------------
// Linq Demo
//LinqDemo.InitializeDataTable();
//LinqDemo.QueryDataTable();
//LinqDemo.QueryList();


// ------------------------------------------------------------------------
// OrmLite Demo
OrmLiteDemo.DbCrud();



// ------------------------------------------------------------------------
// Dynamic Types Demo
//dynamic a = 5;
//var x = "hello";
//object c = 10.29;

//a = 10;
//a = "abc";

////x = 10; // error
//x = "world";

//c = "test";
//c = 20;


//Console.WriteLine("VAR:");
//var number = 10;
//var text = "Dharmik";
//var list = new List<string>() { "C#", "Java" };

//Console.WriteLine($"number type: {number.GetType()}");
//Console.WriteLine($"text type: {text.GetType()}");
//Console.WriteLine($"list type: {list.GetType()}\n");

////number = "Hello";
//Console.WriteLine($"Upper: {text.ToUpper()}");


//Console.WriteLine("OBJECT:");
//object objNum = 25;
//object objStr = "Hello";

//Console.WriteLine($"objNum type: {objNum.GetType()}");
//Console.WriteLine($"objStr type: {objStr.GetType()}");

////int res = objNum + 5; 
//int res = (int)objNum + 5;  // Explicit cast
//Console.WriteLine($"After casting: {x}");

//// Explicit cast before using specific members
//Console.WriteLine($"Uppercase string: {((string)objStr).ToUpper()}\n");


//Console.WriteLine("DYNAMIC:");
//dynamic dynVal = 50;
//Console.WriteLine($"dynVal type: {dynVal.GetType()}");
//Console.WriteLine($"dynVal + 10 = {dynVal + 10}");

//dynVal = "Hello World";
//Console.WriteLine($"dynVal type now: {dynVal.GetType()}");
//Console.WriteLine($"dynVal.ToUpper() = {dynVal.ToUpper()}");

//dynVal.NonExist();

//Console.WriteLine();


//Console.WriteLine("json with dynamic");
//string json = "{ \"name\": \"John\", \"skills\": [\"C#\", \"AI\", \"Robotics\"] }";

//object data = JsonSerializer.Serialize<object>(json);
////Console.WriteLine($"Name: {data.name}");
////Console.WriteLine($"First Skill: {data.skills[0]}\n");


//Console.ReadLine();

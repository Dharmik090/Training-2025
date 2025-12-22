// See https://aka.ms/new-console-template for more information
using GenericsDemo;
using GenericsDemo.Collections;

Console.WriteLine("Hello, World!");

// --------------------------------------------------------
// Generic Collections Demo
ListDemo.Demo();

StackDemo.Demo();

QueueDemo.Demo();

DictionaryDemo.Demo();



// --------------------------------------------------------
// Generic class & method
Box<string> stringBox = new Box<string>();
stringBox.Add("123");

int num = stringBox.ConvertTo<int>();


Box<int> intBox = new Box<int>();
intBox.Add(456);

string text = intBox.ConvertTo<string>();


Box<double> doubleBox = new Box<double>();
doubleBox.Add(3.1415);

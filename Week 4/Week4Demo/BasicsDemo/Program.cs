
using BasicsDemo;
using BasicsDemo.ClassTypes;

// -------------------------------------------------------------------
Console.WriteLine("=== Class Types Demo ===");

// Computer c = new Computer("HP"); // Compile-time error

// (reference type) = (object type)
Computer desktop = new Desktop("Dell");
Computer laptop = new Laptop("Lenovo");

// Abstract method call — runs derived implementation
desktop.Start(); 
laptop.Start();  

Console.WriteLine();

// Non-abstract method (defined in base class)
desktop.Terminal();
laptop.Terminal();

Console.WriteLine();

// Virtual method demo — overridden in Laptop, not in Desktop
desktop.temp(); // Base class implementation
laptop.temp();  // Overridden implementation

Console.WriteLine();

// Runtime polymorphism: same reference type, different behavior
Computer[] computers = { desktop, laptop };
foreach (Computer comp in computers)
{
    comp.Start(); // Abstract
    comp.temp();  // Virtual
    Console.WriteLine();
}



// -------------------------------------------------------------------
Console.WriteLine("\n=== Sealed Class Demo ===");

Logger logger = new Logger();
logger.Log("This is a simple log message.");



// -------------------------------------------------------------------
Console.WriteLine("\n=== Interface Demo ===");

Rectangle rect = new Rectangle(10.1, 5.2);
rect.PrintDetails();

// Interface reference
IShape shape = rect;
Console.WriteLine($"Area (via IShape): {shape.Area()}");

IPrintable printableShape = rect;
printableShape.PrintDetails();

// Cannot access printableShape.Area();



// -------------------------------------------------------------------
// Lambda Expressions Demo
int x = 25;
Func<int,int> square = x => x * x; // delegate type
                                   // <T1, T2,...,T16, TResult>
                                   // T1-T16 input types, TResult return type
Console.WriteLine($"Square of {x} is {square}");

List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

IEnumerable<int> even = numbers.Where(n => n % 2 == 0);

Console.WriteLine("Even numbers: " + string.Join(", ", even));



// -------------------------------------------------------------------
// String Extension Demo
string word = "hello";
Console.WriteLine(word.ToTitleCase());

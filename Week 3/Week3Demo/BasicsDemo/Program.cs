// See https://aka.ms/new-console-template for more information
using BasicsDemo;
using BasicsDemo.AccessModifiers;
using BasicsDemo.Enums;

Console.WriteLine("Hello, World!");

// -------------------------------------------------------------------------
// Access Modifiers Demo
Console.WriteLine ("================ Access Modifiers Demo ================");

Person person = new Person();
person.ShowData();

Employee employee = new Employee();
employee.DisplayEmployeeData();

Console.WriteLine("\nAccessing from Program (non-derived):");

Console.WriteLine(person.PublicName);

//Console.WriteLine(person.PrivateId);
// Console.WriteLine(person.ProtectedInfo);      

Console.WriteLine(person.InternalData); 
Console.WriteLine(person.ProtectedInternalData);



// -------------------------------------------------------------------------
// Enum Demo
Console.WriteLine("================ Enum Demo ================");

// 1. Using [Flags] enum
Permissions userPermissions = Permissions.Read | Permissions.Write;

Console.WriteLine($"User permissions: {userPermissions}");

if (userPermissions.HasFlag(Permissions.Read))
{
    Console.WriteLine("User has read permission.");
}


// 2. Using standard enum
Status currentStatus = Status.InProgress;

Console.WriteLine($"Current Status: {currentStatus} ({(int)currentStatus})");
Console.WriteLine(typeof(Status));
Console.WriteLine("\nAll Status values:");
foreach (Status s in Enum.GetValues(typeof(Status)))
{
    Console.WriteLine($"- {s} = {(int)s}");
}

Console.WriteLine("\nStatus names:");
foreach (string name in Enum.GetNames(typeof(Status)))
{
    Console.WriteLine(name);
}


// 3. Using enum with specific underlying type
BigNumbers bigValue = BigNumbers.Large;
Console.WriteLine($"Big Value: {bigValue} ({(long)bigValue})");



// -------------------------------------------------------------------------
// Math Demo
Console.WriteLine("================ Math Demo ================");

MyMath.Demo();



// -------------------------------------------------------------------------
// String Demo
Console.WriteLine("================ String Demo ================");
MyString.Demo();



// -------------------------------------------------------------------------
// DateTime Demo
Console.WriteLine("================ DateTime Demo ================");
MyDateTime.Demo();

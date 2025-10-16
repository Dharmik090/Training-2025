using System;

[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,      // 0001
    ReadWrite = Read | Write, // 0011,
    Xyz = 011,
    Write = 2,     // 0010
    Execute = 4,   // 0100
    Admin = Read | Write | Execute // 0111
}


enum Status
{
    None = 0,
    Started = 1,
    InProgress = 2,
    Completed = 3,
    Done = 3
}


enum BigNumbers : long
{
    Small = 1000L,
    Large = 1000000L
}



public class EnumExample
{
    public static void Main(string[] args)
    {
        // 1. Using Flags enum
        Permissions userPermissions = Permissions.Read | Permissions.Write;

        Console.WriteLine($"User permissions: {userPermissions}");

        if (userPermissions.HasFlag(Permissions.Read))
        {
            Console.WriteLine("User has read permission.");
        }


        // 2. Using standard enum
        Status currentStatus = Status.InProgress;

        Console.WriteLine($"Current Status: {currentStatus} ({(int)currentStatus})");

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

    }
}
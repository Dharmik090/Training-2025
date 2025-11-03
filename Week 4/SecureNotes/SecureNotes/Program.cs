using SecureNotes.Service;
using System;

namespace SecureNotes
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Create Note");
                Console.WriteLine("2. Read Note");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1": NoteService.CreateNote(); break;
                    case "2": NoteService.ReadNote(); break;
                    case "3": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
        }
    }
}
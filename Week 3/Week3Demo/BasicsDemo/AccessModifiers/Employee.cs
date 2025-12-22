using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo.AccessModifiers
{
    public class Employee : Person
    {
        public void DisplayEmployeeData()
        {
            Console.WriteLine("\nInside Employee (derived) class:");
            Console.WriteLine(PublicName);
            // Console.WriteLine(PrivateId);              
            Console.WriteLine(ProtectedInfo);
            Console.WriteLine(InternalData);
            Console.WriteLine(ProtectedInternalData);
        }

    }
}

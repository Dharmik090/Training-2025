using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo.AccessModifiers
{
    public class Person
    {
        // Accessible anywhere
        public string PublicName = "Public Name";

        // Accessible only inside this class
        private string PrivateId = "Private ID";

        // Accessible inside this class and derived classes
        protected string ProtectedInfo = "Protected Info";

        // Accessible within the same assembly
        internal string InternalData = "Internal Data";

        // Accessible in derived classes OR same assembly
        protected internal string ProtectedInternalData = "Protected Internal Data";

        public void ShowData()
        {
            Console.WriteLine("Inside Person class:");
            Console.WriteLine(PublicName);
            Console.WriteLine(PrivateId);
            Console.WriteLine(ProtectedInfo);
            Console.WriteLine(InternalData);
            Console.WriteLine(ProtectedInternalData);
        }

    }
}

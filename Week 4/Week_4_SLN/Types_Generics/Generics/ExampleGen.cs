using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types_Generics.Generics
{
    internal class ExampleWithoutGen
    {
        public object Value { get; set; }
    }
    
    internal class ExampleWithGen<T> 
    {
        public T Value { get; set; }
    }
}

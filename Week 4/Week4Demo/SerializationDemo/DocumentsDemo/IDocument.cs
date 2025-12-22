using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo.Documents
{
    internal interface IDocument
    {
        string FileName { get; set; }
        string FilePath { get; set; }
        void Load();
        void Save();
        void Print();

    }
}

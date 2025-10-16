using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types_Generics.DocumentProcessing
{
    abstract class Document
    {
        public string FileName { get; set; }

        public Document(string FileName)
        {
            this.FileName = FileName;
        }

        public abstract void Load();
        public abstract void Save();
        public abstract void Print();

        public void ShowFileInfo() {
            Console.WriteLine($"File name: {FileName}");
        }
    }
}

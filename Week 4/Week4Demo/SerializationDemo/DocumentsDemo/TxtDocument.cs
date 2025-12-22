using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo.Documents
{
    internal sealed class TxtDocument : IDocument, IConvertToUpperCase
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Content { get; set; } = "";

        public TxtDocument(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
        }

        public void Load()
        {
            Console.WriteLine($"Loading text file: {FileName}");

            Content = File.ReadAllText(FilePath);

            Console.WriteLine("Loaded text file");
            Console.WriteLine("-------------------------------------");
        }

        public void Print()
        {
            Console.WriteLine($"Content of {FileName}:\n{Content}");
            Console.WriteLine("-------------------------------------");
        }

        public void Save()
        {
            Console.WriteLine($"Saving text file: {FileName}");

            File.WriteAllText(FilePath, Content);

            Console.WriteLine("Saved text file");
            Console.WriteLine("-------------------------------------");
        }

        public void ToUpperCase()
        {
            Console.WriteLine("Converting content to upper case...");

            File.WriteAllText("output.txt", Content.ToUpper());

            Console.WriteLine("Converted content to upper case");
            Console.WriteLine("-------------------------------------");
        }
    }
}

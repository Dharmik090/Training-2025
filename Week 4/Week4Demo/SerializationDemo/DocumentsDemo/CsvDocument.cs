using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;

namespace SerializationDemo.Documents
{
    internal sealed class CsvDocument : IDocument, IConvertToJson
    {

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public List<Dictionary<string, string>> Content { get; set; }

        public CsvDocument(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
            Content = new List<Dictionary<string, string>>();
        }

        public void Load()
        {
            Console.WriteLine($"Loading CSV document: {FileName}");

            string[] lines = File.ReadAllLines(FilePath);

            if (lines.Length == 0) return;

            string[] headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                string[] record = lines[i].Split(',');

                var dict = new Dictionary<string, string>();

                for (int j = 0; j < headers.Length; j++)
                {
                    dict[headers[j]] = record[j];
                }

                Content.Add(dict);
            }

            Console.WriteLine("Loaded CSV document");
            Console.WriteLine("-------------------------------------");
        }

        public void Print()
        {
            Console.WriteLine($"Printing CSV document: {FileName}");
            foreach (var record in Content)
            {
                Console.WriteLine(string.Join(" | ", record));
            }

            Console.WriteLine("-------------------------------------");
        }

        public void Save()
        {
            Console.WriteLine($"Saving CSV document: {FileName}");

            if (Content.Count == 0) return;

            string headers = string.Join(",", Content[0].Keys);

            List<string> lines = new List<string> { headers };

            foreach (Dictionary<string, string> record in Content)
            {
                string line = string.Join(",", record.Values);
                lines.Add(line);
            }

            File.WriteAllLines(FilePath, lines);

            Console.WriteLine("Saved CSV document");
            Console.WriteLine("-------------------------------------");
        }

        public void ConvertToJson()
        {
            // Convert File Content to JSON
            Console.WriteLine($"Converting CSV document to JSON: {FileName}");

            // Using newtonsoft.json
            string json = JsonConvert.SerializeObject(Content);

            // Using System.Text.Json
            //string json = JsonSerializer.Serialize(Content, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("output.json", json);
            Console.WriteLine("-------------------------------------");
        }
    }
}

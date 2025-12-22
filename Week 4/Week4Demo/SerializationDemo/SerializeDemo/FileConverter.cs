using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDemo.SerializeDemo
{
    internal static class FileConverter
    {
        // ---------- JSON ----------

        // Serialize object to JSON file
        public static void SaveAsJson<T>(T obj, string filePath)
        {
            string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
            
            File.WriteAllText(filePath, json);
            Console.WriteLine($"JSON Saved to {filePath}");
        }

        // Deserialize JSON file to object
        public static T LoadFromJson<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            
            T obj = JsonSerializer.Deserialize<T>(json);
            
            Console.WriteLine($"JSON Loaded from {filePath}");
            return obj;
        }

        // ---------- XML ----------

        // Serialize object to XML file
        public static void SaveAsXml<T>(T obj, string filePath)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                xml.Serialize(fs, obj);
            }

            Console.WriteLine($"XML Saved to {filePath}");
        }

        // Deserialize XML file to object
        public static T LoadFromXml<T>(string filePath)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                T obj = (T)xml.Deserialize(fs);
                
                Console.WriteLine($"XML Loaded from {filePath}");
                return obj;
            }
        }

    }
}

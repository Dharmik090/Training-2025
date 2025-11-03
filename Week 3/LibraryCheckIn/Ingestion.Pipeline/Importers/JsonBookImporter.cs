using Ingestion.Pipeline.Domain;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importers
{
    /// <summary>
    /// Read .json file as string using File.ReadAllText <br></br>
    /// Convert string into List<Book> <br></br>
    /// If the file is empty, return an empty list <br></br>
    /// </summary>
    public sealed class JsonBookImporter : FileImporter<Book>
    {
        /// <summary>
        /// Read .json file using File.ReadAllText
        /// Deserialize string to List of Book objects0
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public override List<Book> Import(string filePath) 
        {

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Input file not found: {filePath}");


            // Converting "Good" to appropriate enum value
            // if file contains "Condition": 1 , no need for this
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            // Import json file
            string jsonContent = File.ReadAllText(filePath);

            // Convert using System.Text.Json
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonContent, options) ?? new List<Book>();

            // Convert using Newtonsoft.Json
            //List<Book> books = JsonConvert.DeserializeObject<List<Book>>(jsonContent) ?? new List<Book>();

            return books;
        }
    }
}

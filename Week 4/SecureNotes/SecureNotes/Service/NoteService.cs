using SecureNotes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecureNotes.Service
{
    public class NoteService
    {
        public static void CreateNote()
        {
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Body: ");
            string body = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            CryptoFields cryptoFields = CryptoService.Encrypt(body, password);

            Note note = new Note
            {
                Id = Guid.NewGuid(),
                Title = title,
                CryptoFields = cryptoFields,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            string jsonContent = JsonSerializer.Serialize(note, new JsonSerializerOptions { WriteIndented = true });

            string vaultPath = Path.Combine(Directory.GetCurrentDirectory(), "SecureVault");
            Directory.CreateDirectory(vaultPath);

            string filePath = Path.Combine(vaultPath, $"{note.Id}.json");
            
            File.WriteAllText(filePath, jsonContent);
        }

        public static void ReadNote()
        { 
            Console.WriteLine("Note ID: ");
            string id = Console.ReadLine();

            string vaultPath = Path.Combine(Directory.GetCurrentDirectory(), "SecureVault");
            string filePath = Path.Combine(vaultPath, $"{id}.json");

            if(!File.Exists(filePath))
            {
                Console.WriteLine("Note not found.");
                return;
            }

            Note note = JsonSerializer.Deserialize<Note>(File.ReadAllText(filePath));
            
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            try
            {
                string decrypted = CryptoService.Decrypt(note.CryptoFields, password);

                var output = new
                {
                    Id = note.Id,
                    Title = note.Title,
                    Body = decrypted,
                    CreatedAt = note.CreatedAt,
                    UpdatedAt = note.UpdatedAt
                };

                // Serialize it to JSON and display
                string jsonOutput = JsonSerializer.Serialize(output, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(jsonOutput);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to decrypt note. " + ex.Message);
            }
        }
    }
}

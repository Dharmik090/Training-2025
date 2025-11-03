using Ingestion.Pipeline.Domain;
using Ingestion.Pipeline.Importers;
using Ingestion.Pipeline.Writers;

namespace Ingestion.Cli
{
    /// <summary>
    /// Ingestion CLI Tool:
    /// 1. Takes ./in and ./out folder paths.
    /// 2. Stops if ./in does not exist.
    /// 3. Reads .csv & .json files using respective importers.
    /// 4. If --dry-run flag is provided, only displays summary (no output files generated).
    /// 5. If not in dry-run, generates text report in ./out folder.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            bool dryRun = args.Contains("--dry-run");

            Console.WriteLine("Enter input folder path (./in): ");
            string? inFolderPath = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(inFolderPath) || !Directory.Exists(inFolderPath))
            {
                Console.WriteLine("Input folder does not exist.");
                return;
            }

            Console.WriteLine("Enter output folder path (e.g., ./out): ");
            string? outFolderPath = Console.ReadLine();

            if (!dryRun && (string.IsNullOrWhiteSpace(outFolderPath) || !Directory.Exists(outFolderPath)))
            {
                Console.WriteLine("Output folder does not exist.");
                return;
            }

            CsvBookImporter csvImporter = new CsvBookImporter();
            JsonBookImporter jsonImporter = new JsonBookImporter();

            List<Book> allBooks = new List<Book>();

            string[] csvFiles = Directory.GetFiles(inFolderPath, "*.csv", SearchOption.AllDirectories);
            foreach (string csvFile in csvFiles)
            {
                try
                {
                    List<Book> books = csvImporter.Import(csvFile).ToList();
                    allBooks.AddRange(books);
                    Console.WriteLine($"Imported {books.Count} books from CSV: {Path.GetFileName(csvFile)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error importing {Path.GetFileName(csvFile)}: {ex.Message}");
                }
            }

            string[] jsonFiles = Directory.GetFiles(inFolderPath, "*.json", SearchOption.AllDirectories);
            foreach (string jsonFile in jsonFiles)
            {
                try
                {
                    List<Book> books = jsonImporter.Import(jsonFile).ToList();
                    allBooks.AddRange(books);
                    Console.WriteLine($"Imported {books.Count} books from JSON: {Path.GetFileName(jsonFile)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error importing {Path.GetFileName(jsonFile)}: {ex.Message}");
                }
            }

            if (allBooks.Count == 0)
            {
                Console.WriteLine("No books imported.");
                return;
            }

            // dry run mode
            if (dryRun)
            {
                Console.WriteLine("\nDry Run Mode Enabled — No output files will be generated.");
                Console.WriteLine($"Total books imported: {allBooks.Count}");
                Console.WriteLine("Sample (first 5):");

                foreach (var book in allBooks.Take(5))
                {
                    Console.WriteLine($" - {book.Title} by {book.Author}");
                }

                Console.WriteLine("\nDry run completed successfully.");
                return;
            }

            // No dry run
            Console.WriteLine("\nGenerating reports...");

            TextReportWriter<Book> textWriter = new TextReportWriter<Book>();
            //XmlReportWriter<Book> xmlWriter = new XmlReportWriter<Book>(); 

            string txtOutputFile = Path.Combine(outFolderPath!, $"daily_summary_{DateTime.Now:yyyyMMdd}.txt");
            textWriter.WriteReport(allBooks, txtOutputFile);

            // string xmlOutputFile = Path.Combine(outFolderPath!, $"daily_summary_{DateTime.Now:yyyyMMdd}.xml");
            // xmlWriter.WriteReport(allBooks, xmlOutputFile);

            Console.WriteLine($"Report generated at: {txtOutputFile}");
            Console.WriteLine("Process completed successfully.");

            Console.ReadLine();
        }
    }
}

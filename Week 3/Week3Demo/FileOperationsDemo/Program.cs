using System.Text;

Console.WriteLine("=== FILE OPERATIONS DEMO ===\n");

string folderPath = Path.Combine(Environment.CurrentDirectory, "DemoFiles");
string filePath = Path.Combine(folderPath, "example.txt");
string encodedFile = Path.Combine(folderPath, "encoded_file.txt");
string copyPath = Path.Combine(folderPath, "example_copy.txt");

// Create a directory
if (!Directory.Exists(folderPath))
    Directory.CreateDirectory(folderPath);


// Create and write text to file
File.WriteAllText(filePath, "Hello, C# File Handling!\nThis is the second line.");

// Using file encoding
File.WriteAllText(encodedFile, "This is encoded file.", Encoding.UTF8);

Console.WriteLine($"Files created");


// Read the entire text file
string content = File.ReadAllText(filePath);
Console.WriteLine("\n=== File Content ===");
Console.WriteLine(content);


// Read file line by line
Console.WriteLine("\nReading line by line:");
string[] lines = File.ReadAllLines(filePath);
foreach (string line in lines)
    Console.WriteLine($" - {line}");


// Copy and move files
File.Copy(filePath, copyPath, true);
Console.WriteLine($"File copied to: {copyPath}");


string movedPath = Path.Combine(folderPath, "moved_example.txt");
File.Move(copyPath, movedPath, true);
Console.WriteLine($"Copied file moved to: {movedPath}");


// Read file using StreamReader
Console.WriteLine("\nReading using StreamReader:");
using (StreamReader reader = new StreamReader(filePath))
{
    string line = string.Empty;
    while ((line = reader.ReadLine()) != null)
        Console.WriteLine(line);
}

// Write to file using StreamWriter
string newFile = Path.Combine(folderPath, "streamwriter_demo.txt");
using (StreamWriter writer = new StreamWriter(newFile))
{
    writer.WriteLine("This file was written using StreamWriter.");
    writer.WriteLine($"Current Time: {DateTime.Now}");
}
Console.WriteLine($"\nNew file written using StreamWriter: {newFile}");


// Binary file write/read
string binaryFile = Path.Combine(folderPath, "binary_demo.bin");
using (BinaryWriter bw = new BinaryWriter(File.Open(binaryFile, FileMode.Create)))
{
    bw.Write(101);        // int
    bw.Write(99.99);      // double
    bw.Write("Binary data"); // string
}

using (BinaryReader br = new BinaryReader(File.Open(binaryFile, FileMode.Open)))
{
    int id = br.ReadInt32();
    double val = br.ReadDouble();
    string msg = br.ReadString();

    Console.WriteLine($"Int: {id}, Double: {val}, String: {msg}");
}

// List all files in folder
Console.WriteLine("\n=== Files in Folder ===");
foreach (string file in Directory.GetFiles(folderPath))
    Console.WriteLine(Path.GetFileName(file));

// Delete a file
//File.Delete(movedPath);
//Console.WriteLine($"\nDeleted file: {movedPath}");

Console.ReadLine();
// DataTables.cs
// Demonstrates the use of DataTable in C#
// Example: Creating a DataTable, adding columns and rows, and displaying data

using System;
using System.Data;

class DataTableExample
{
    static void Main()
    {
        // Create a new DataTable
        DataTable table = new DataTable("Students");

        // Define columns
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Age", typeof(int));

        // Add rows
        table.Rows.Add(1, "Alice", 20);
        table.Rows.Add(2, "Bob", 22);
        table.Rows.Add(3, "Charlie", 23);

        // Display data
        Console.WriteLine("ID\tName\tAge");
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"{row["ID"]}\t{row["Name"]}\t{row["Age"]}");
        }
    }
}
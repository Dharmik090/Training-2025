// See https://aka.ms/new-console-template for more information
using System.Data;

namespace DataTableDemo;

public class Program
{
    public static void Main(string[] args)
    {
        DataTable table = new DataTable("Students");


        // Define Schema
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Age", typeof(int));
        table.Columns.Add("Grade", typeof(string));


        // Insert data
        table.Rows.Add(1, "Alice", 20, "A");
        table.Rows.Add(2, "Bob", 22, "B");
        table.Rows.Add(3, "Charlie", 23, "C");
        DataRow newRow = table.NewRow();
        newRow["ID"] = 4;
        newRow["Name"] = "John";
        newRow["Age"] = 20;
        newRow["Grade"] = "A";

        // Display all data
        Console.WriteLine("Original Data:");
        DisplayTable(table);


        // Access specific cell value
        Console.WriteLine($"\nName of first student: {table.Rows[0]["Name"]}");


        // Update a value
        table.Rows[1]["Grade"] = "A";


        // Delete a row
        table.Rows[2].Delete(); 
        Console.WriteLine("\nAfter deleting:");
        DisplayTable(table);


        // Accept changes (commit deletion)
        table.AcceptChanges();


        // Filter data using Select()
        Console.WriteLine("\nStudents with Grade = 'A':");

        DataRow[] gradeAStudents = table.Select("Grade = 'A'");
        foreach (DataRow row in gradeAStudents)
            Console.WriteLine($" - {row["Name"]} ({row["Age"]} yrs)");

        
        // Sort data (ascending by Age)
        Console.WriteLine("\nStudents sorted by Age:");

        DataRow[] sortedRows = table.Select("", "Age ASC");
        foreach (DataRow row in sortedRows)
            Console.WriteLine($" - {row["Name"]} ({row["Age"]})");

        
        // Search by Primary Key
        table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };

        DataRow? foundRow = table.Rows.Find(4);
        if (foundRow != null)
            Console.WriteLine($"\nFound by ID=4 → {foundRow["Name"]}");

        // Navigate through rows
        Console.WriteLine("\nNavigating rows manually:");
        for (int i = 0; i < table.Rows.Count; i++)
        {
            Console.WriteLine($"Row {i + 1}: {table.Rows[i]["Name"]} ({table.Rows[i]["Grade"]})");
        }

        // Use DataView for filtering + sorting combined
        Console.WriteLine("\nDataView Demo (Filter: Age > 20, Sort by Name):");
        DataView view = new DataView(table)
        {
            RowFilter = "Age > 20",
            Sort = "Name ASC"
        };

        foreach (DataRowView rowView in view)
        {
            Console.WriteLine($" - {rowView["Name"]} ({rowView["Age"]})");
        }


        // Remove a column
        table.Columns.Remove("Grade");
        Console.WriteLine("\nAfter removing 'Grade' column:");
        DisplayTable(table);
    }

    static void DisplayTable(DataTable table)
    {
        foreach (DataColumn col in table.Columns)
            Console.Write($"{col.ColumnName}\t");
        Console.WriteLine("\n---------------------------");

        foreach (DataRow row in table.Rows)
        {
            if (row.RowState != DataRowState.Deleted)
            {
                foreach (var item in row.ItemArray)
                    Console.Write($"{item}\t");
                Console.WriteLine();
            }
        }
    }
}
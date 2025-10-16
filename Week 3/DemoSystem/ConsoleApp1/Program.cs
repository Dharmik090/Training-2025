using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string connectionString = "YourConnectionStringHere";

            string selectQuery = "SELECT CustomerID, CompanyName, ContactName FROM Customers";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))

                {

                    DataTable customersTable = new DataTable();

                    adapter.Fill(customersTable);

                    // Now 'customersTable' contains the data from the Customers table

                    // You can iterate through rows, filter, etc.

                    foreach (DataRow row in customersTable.Rows)

                    {

                        Console.WriteLine($"Customer ID: {row["CustomerID"]}, Company: {row["CompanyName"]}");

                    }

                }

            }

        }
    }
}

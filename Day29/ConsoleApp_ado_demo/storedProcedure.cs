using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        // Connection string: Update with your actual server and database
           string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=wiprojuly;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("✅ Connection opened successfully.");

                // Create command to call stored procedure
                SqlCommand cmd = new SqlCommand("dispallrecs_emp", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameter
                cmd.Parameters.AddWithValue("@empid", 1001);

                // Execute and read results
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("📋 Employee Details:");
                Console.WriteLine("---------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["empid"]}, Name: {reader["empname"]}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("🔒 Connection closed.");
            }
        }

        Console.WriteLine("✅ Program finished.");
    }
}

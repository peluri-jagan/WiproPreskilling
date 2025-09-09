// using System;
// using Microsoft.Data.SqlClient;

// namespace adodemo1
// {
//     class Program1
//     {
//         static void Main(string[] args)
//         {
//             string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=wiprojuly;Integrated Security=True";

//             using (SqlConnection connection = new SqlConnection(connectionString))
//             {
//                 connection.Open();
//                 Console.WriteLine("Connection opened successfully.");

//                 // INSERT query
//                 string insertQuery = "INSERT INTO employee (empid, empname, city, salary) VALUES (@empid, @empname, @city, @salary)";
//                 using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
//                 {
//                     insertCmd.Parameters.AddWithValue("@empid", 1006);
//                     insertCmd.Parameters.AddWithValue("@empname", "Ravi");
//                     insertCmd.Parameters.AddWithValue("@city", "Vizag");
//                     insertCmd.Parameters.AddWithValue("@salary", 52000);

//                     int rowsInserted = insertCmd.ExecuteNonQuery();
//                     Console.WriteLine($"{rowsInserted} row inserted successfully.");
//                 }

//                 connection.Close();
//                 Console.WriteLine("Connection closed.");
//             }
//         }
//     }
// }

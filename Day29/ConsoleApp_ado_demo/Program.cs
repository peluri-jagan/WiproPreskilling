// using System;
// using System.Data;

// //using System.Data.SqlClient; //  Required for SqlConnection
// using Microsoft.Data.SqlClient;
// namespace adodemo1
// {
//     class Program  // get connection
//     {
//         static void Main(string[] args)
//         {
//            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=wiprojuly;Integrated Security=True";


//             using (SqlConnection connection = new SqlConnection(connectionString))
//             {
//                 connection.Open();
//                 Console.WriteLine("Connection opened successfully.");

//         DataTable t1 = new DataTable("customers");
//         t1.Columns.Add("custid", typeof(int));
//         t1.Columns.Add("custname", typeof(string));
//         t1.Columns.Add("balance", typeof(int));

//         // Add rows to customers table
//         t1.Rows.Add(101, "John", 5000);
//         t1.Rows.Add(102, "Jane", 6000);
//         t1.Rows.Add(103, "Doe", 7000);

//         // Create second DataTable: orders
//         DataTable t2 = new DataTable("orders");
//         t2.Columns.Add("orderid", typeof(int));
//         t2.Columns.Add("custid", typeof(int));
//         t2.Columns.Add("orderdate", typeof(DateTime));

//         // Add rows to orders table
//         t2.Rows.Add(1, 101, DateTime.Now);
//         t2.Rows.Add(2, 102, DateTime.Now.AddDays(-1));
//         t2.Rows.Add(3, 103, DateTime.Now.AddDays(-2));
//         t2.Rows.Add(4, 101, DateTime.Now.AddDays(-3));
//         t2.Rows.Add(5, 102, DateTime.Now.AddDays(-4));

//         // Create DataSet and add both tables
//         DataSet ds = new DataSet();
//         ds.Tables.Add(t1);
//         ds.Tables.Add(t2);

//         // Display data from customers table
//         Console.WriteLine("Customers:");
//         foreach (DataRow row in ds.Tables["customers"].Rows)
//         {
//             Console.WriteLine($"ID: {row["custid"]}, Name: {row["custname"]}, Balance: {row["balance"]}");
//         }

//         // Display data from orders table
//         Console.WriteLine("\nOrders:");
//         foreach (DataRow row in ds.Tables["orders"].Rows)
//         {
//             Console.WriteLine($"OrderID: {row["orderid"]}, CustomerID: {row["custid"]}, Date: {row["orderdate"]}");
//         }
//                 connection.Close();
//                 Console.WriteLine("Connection closed.");
//             }
//         }
//     }
// }

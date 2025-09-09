using System.Data;
using Microsoft.Data.SqlClient;
namespace MVC_ADO_Demo.Data;

public class ProductsRepository
{
    private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    private readonly IDbConnection _dbConnection;

    public ProductsRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        // above line allows us to use _dbConnection in our repository methods
    }

    // Insert :
    // step1: creating the connection

    // step 2: creating the command object
    // step 3: Opening the connection
    // step 4 : Executing the command
    // step 5: Closing the connection
    public int InsertProduct(string name, decimal price)
    {
        //Insert OPerations : 
        //Step 1: Creating the connection 
        using var connection = _dbConnection;
        //Step 2: Creating the command Object
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Products (Name, Price) VALUES (@name, @price); SELECT SCOPE_IDENTITY();";
        command.Parameters.Add(new SqlParameter("@name", name));
        command.Parameters.Add(new SqlParameter("@price", price));
        //opening the connection
        connection.Open();
        //Step 3: Executing the command
        var result = command.ExecuteScalar(); // This will return the newly inserted product ID
        //Step 4: Closing the connection
        connection.Close();
        return Convert.ToInt32(result);
    }
    //Filling Dataset snapshot( Adapter manages Open/Close)

    public DataSet GetProducts()
    {
        var dataSet = new DataSet(); // dataset is used to hold the result set
        using var connection = _dbConnection;
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Products"; // Selecting all products
        using var adapter = new SqlDataAdapter((SqlCommand)command);
        //using Adapter with DataSet helps us to open/close automatically
        adapter.Fill(dataSet); // Filling the dataset with the result set
        return dataSet;
    }// we can also have data table as return type

    //filling dataset snapshot (optional)
    public void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Products WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
}
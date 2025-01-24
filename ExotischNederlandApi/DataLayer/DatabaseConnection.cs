using MySql.Data.MySqlClient;

public class DatabaseConnection
{
    private readonly string _connectionString = @"Server=48.209.60.187;Database=ExNed-Ruwdata;User ID=root;Password=ExotischNederlandDB123";


    protected MySqlConnection CreateOpenConnection()
    {
        var connection = new MySqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    protected void InitializeDatabase()
    {
        CreateOpenConnection();
    }
}
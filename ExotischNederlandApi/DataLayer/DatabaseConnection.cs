using MySql.Data.MySqlClient;

public class DatabaseConnection
{
    private readonly string _connectionString = @"Server=4.231.112.184;Database=ExotischNederland;User ID=root;Password=ExotischNederland!";


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
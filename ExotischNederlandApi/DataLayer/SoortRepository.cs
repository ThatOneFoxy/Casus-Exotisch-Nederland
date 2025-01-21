using MySql.Data.MySqlClient;

internal class SoortRepository: DatabaseConnection
{
    public SoortRepository()
    {
        InitializeDatabase();
    }

    public void VoegSoortToe(Soort soort)
    {
        var connection = CreateOpenConnection();

        string insertQuery = @"
            INSERT INTO SOORT (SoortNaam, SoortLatijnseNaam, SoortZeldzaamheid, SoortStatus)
            VALUES (@SoortNaam, @SoortLatijnseNaam, @SoortZeldzaamheid, @SoortStatus);";

        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@SoortNaam", soort.naam);
        command.Parameters.AddWithValue("@SoortLatijnseNaam", soort.latijnseNaam);
        command.Parameters.AddWithValue("@SoortZeldzaamheid", soort.zeldzaamheid);
        command.Parameters.AddWithValue("@SoortStatus", soort.status);

        command.ExecuteNonQuery();
    }

    public List<Soort> HaalAlleSoortenOp()
    {
        var connection = CreateOpenConnection();

        var soorten = new List<Soort>();
        string selectQuery = @"
            SELECT * FROM SOORT;";
        using var command = new MySqlCommand(selectQuery, connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string naam = reader.GetString(1);
            string latijnseNaam = reader.GetString(2);
            string zeldzaamheid = reader.GetString(3);
            string status = reader.GetString(4);
            soorten.Add(new Soort(id, naam, latijnseNaam, zeldzaamheid, status));
        }

        return soorten;
    }

    public void VeranderSoort(Soort soort)
    {
        var connection = CreateOpenConnection();

        string updateQuery = @"
        UPDATE SOORT
        SET SoortLatijnseNaam = @SoortLatijnseNaam,
            SoortZeldzaamheid = @SoortZeldzaamheid,
            SoortStatus = @SoortStatus
        WHERE SoortNaam = @SoortNaam;";

        using var command = new MySqlCommand(updateQuery, connection);
        command.Parameters.AddWithValue("@SoortNaam", soort.naam);
        command.Parameters.AddWithValue("@SoortLatijnseNaam", soort.latijnseNaam);
        command.Parameters.AddWithValue("@SoortZeldzaamheid", soort.zeldzaamheid);
        command.Parameters.AddWithValue("@SoortStatus", soort.status);

        command.ExecuteNonQuery();
    }

    public void VerwijderSoort(string naam)
    {
        using var connection = CreateOpenConnection();

        string deleteQuery = @"
        DELETE FROM SOORT
        WHERE SoortNaam = @SoortNaam;";

        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@SoortNaam", naam);

        command.ExecuteNonQuery();
    }
}
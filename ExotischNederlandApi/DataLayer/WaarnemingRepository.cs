using MySql.Data.MySqlClient;

internal class WaarnemingRepository : DatabaseConnection
{
    public WaarnemingRepository()
    {
        InitializeDatabase();
    }
    private string TableName = "Waarnemingen";

    public void VoegWaarnemingToe(Waarneming waarneming)
    {
        var connection = CreateOpenConnection();
        string insertQuery = $@"
            INSERT INTO {TableName} (Tijd, Datum, AantalIndividuen, Geslacht, IsGevalideerd, WaarnemingLinks, SoortID)
            VALUES (@Tijd, @Datum, @AantalIndividuen, @Geslacht, @IsGevalideerd, @WaarnemingLinks, @SoortID);";
        using var command = new MySqlCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Tijd", waarneming.tijd);
        command.Parameters.AddWithValue("@Datum", waarneming.datum);
        command.Parameters.AddWithValue("@AantalIndividuen", waarneming.aantalIndividuen);
        command.Parameters.AddWithValue("@Geslacht", waarneming.geslacht);
        command.Parameters.AddWithValue("@IsGevalideerd", waarneming.isGevalideerd);
        command.Parameters.AddWithValue("@WaarnemingLinks", waarneming.waarnemingLinks);
        command.Parameters.AddWithValue("@SoortID", waarneming.soortId);
        command.ExecuteNonQuery();
    }

    public List<Waarneming> HaalAlleWaarnemingenOp()
    {
        var connection = CreateOpenConnection();
        var waarnemingen = new List<Waarneming>();
        string selectQuery = $@"
            SELECT * FROM {TableName};";
        using var command = new MySqlCommand(selectQuery, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            TimeSpan tijd = reader.GetTimeSpan(1);
            DateTime datum = reader.GetDateTime(2);
            int aantalIndividuen = reader.GetInt32(3);
            string geslacht = reader.GetString(4);
            bool isGevalideerd = reader.GetBoolean(5);
            string waarnemingLinks = reader.GetString(6);
            int soortId = reader.GetInt32(7);
            waarnemingen.Add(new Waarneming(id, tijd, datum, aantalIndividuen, geslacht, isGevalideerd, waarnemingLinks, soortId));
        }
        return waarnemingen;
    }

    public void VeranderWaarneming(int waarnemingId, Waarneming waarneming)
    {
        var connection = CreateOpenConnection();
        string updateQuery = $@"
            UPDATE {TableName}
            SET Tijd = @Tijd,
                Datum = @Datum,
                AantalIndividuen = @AantalIndividuen,
                Geslacht = @Geslacht,
                IsGevalideerd = @IsGevalideerd,
                WaarnemingLinks = @WaarnemingLinks,
                SoortID = @SoortID
            WHERE WaarnemingID = @WaarnemingID;";
        using var command = new MySqlCommand(updateQuery, connection);
        command.Parameters.AddWithValue("@WaarnemingID", waarnemingId);
        command.Parameters.AddWithValue("@Tijd", waarneming.tijd);
        command.Parameters.AddWithValue("@Datum", waarneming.datum);
        command.Parameters.AddWithValue("@AantalIndividuen", waarneming.aantalIndividuen);
        command.Parameters.AddWithValue("@Geslacht", waarneming.geslacht);
        command.Parameters.AddWithValue("@IsGevalideerd", waarneming.isGevalideerd);
        command.Parameters.AddWithValue("@WaarnemingLinks", waarneming.waarnemingLinks);
        command.Parameters.AddWithValue("@SoortID", waarneming.soortId);
        command.ExecuteNonQuery();
    }

    public void VerwijderWaarneming(int waarnemingId)
    {
        using var connection = CreateOpenConnection();
        string deleteQuery = $@"
            DELETE FROM {TableName}
            WHERE WaarnemingID = @WaarnemingID;";
        using var command = new MySqlCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@WaarnemingID", waarnemingId);
        command.ExecuteNonQuery();
    }
}
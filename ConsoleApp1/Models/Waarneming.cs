using ConsoleApp1.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Waarneming : API {
    // ==== Properties ====
    [JsonPropertyName("id")]
    public int WaarnemingID { get; set; }

    [JsonPropertyName("soortId")]
    public int SoortID { get; set; }

    [JsonPropertyName("datum")]
    public DateTime Datum { get; set; }

    [JsonPropertyName("tijd")]
    public TimeSpan Tijd { get; set; }

    [JsonPropertyName("aantalIndividuen")]
    public int AantalIndividuen { get; set; }

    [JsonPropertyName("geslacht")]
    public string Geslacht { get; set; }

    [JsonPropertyName("isGevalideerd")]
    public bool IsGevalideerd { get; set; }

    [JsonPropertyName("waarnemingLinks")]
    public string WaarnemingLinks { get; set; }

    // ==== Methods ====
    public async Task<List<Waarneming>> GetWaarnemingen() {
        var data = await this.GetDataFromAPI(this.GetAPIURL());

        if (data != null) {
            List<Waarneming> waarnemingen = JsonSerializer.Deserialize<List<Waarneming>>(data);
            return waarnemingen;
        }
        return new List<Waarneming>();
    }

    public async Task PostWaarneming(Waarneming waarneming) {
        // Making it into a good json
        string jsonString = JsonSerializer.Serialize(waarneming);
        Console.WriteLine(jsonString);

        bool requestResult = await this.PostDataToAPI(this.GetAPIURL(), jsonString);

        if (requestResult) {
            Console.WriteLine("Waarneming toegevoegd.");
        }
        else {
            Console.WriteLine("Er is iets fout gegaan bij het toevoegen van de waarneming.");
        }
    }

    // ==== Constructor ====
    public Waarneming() : base(apiURL: "https://localhost:5001/api/Waarneming") {
        this.WaarnemingID = 0;
        this.SoortID = 0;
        this.Datum = new DateTime();
        this.Tijd = new TimeSpan();
        this.AantalIndividuen = 0;
        this.Geslacht = "";
        this.IsGevalideerd = false;
        this.WaarnemingLinks = "";
    }

    public Waarneming(int waarnemingID, int soortID, DateTime datum, TimeSpan tijd, int aantalIndividuen, string geslacht, bool isGevalideerd, string waarnemingLinks)
        : base(apiURL: "https://localhost:5001/api/Waarneming") {
        this.WaarnemingID = waarnemingID;
        this.SoortID = soortID;
        this.Datum = datum;
        this.Tijd = tijd;
        this.AantalIndividuen = aantalIndividuen;
        this.Geslacht = geslacht;
        this.IsGevalideerd = isGevalideerd;
        this.WaarnemingLinks = waarnemingLinks;
    }
}
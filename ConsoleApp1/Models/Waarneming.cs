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
    public void ToonWaarnemingDetails() {
        Console.WriteLine($"Soort ID: {this.SoortID}");
        Console.WriteLine($"Datum: {this.Datum}");
        Console.WriteLine($"Tijd: {this.Tijd}");
        Console.WriteLine($"Aantal individuen: {this.AantalIndividuen}");
        Console.WriteLine($"Geslacht: {this.Geslacht}");
        Console.WriteLine($"Is gevalideerd: {this.IsGevalideerd}");
        Console.WriteLine($"Waarneming links: {this.WaarnemingLinks}\n");
    }

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

        bool requestResult = await this.PostDataToAPI(jsonString);

        if (requestResult) {
            Console.WriteLine("Waarneming toegevoegd.");
        }
        else {
            Console.WriteLine("Er is iets fout gegaan bij het toevoegen van de waarneming.");
        }
    }

    public async Task UpdateWaarneming(Waarneming waarneming) {
        // Checking if the soortID exists
        

        // Making it into a good json
        string jsonString = JsonSerializer.Serialize(waarneming);
        bool requestResult = await this.PUTDataToAPI(waarneming.WaarnemingID.ToString(), jsonString);

        if (requestResult) {
            Console.WriteLine("Waarneming bijgewerkt.");
        }
        else {
            Console.WriteLine("Er is iets fout gegaan bij het bijwerken van de waarneming.");
        }
    }

    public async Task DeleteWaarneming(int waarnemingID) {
        bool requestResult = await this.DELToAPI(waarnemingID.ToString());

        if (requestResult) {
            Console.WriteLine("Waarneming verwijderd.\n");
        }
        else {
            Console.WriteLine("Er is iets fout gegaan bij het verwijderen van de waarneming.");
        }
    }

    public Waarneming WaarnemingPrompt() {
        // ==== Declaring Variables ====
        int soortID, aantalIndividuen;
        string geslacht;
        bool isGevalideerd;
        TimeSpan tijd;
        DateTime datum;

        while (true) {
            Console.WriteLine("SoortID:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out soortID)) { break; }
            Console.WriteLine("Ongeldige invoer. Voer een getal in.");
        }

        while (true) {
            Console.WriteLine("Tijd:");
            string input = Console.ReadLine();
            if (TimeSpan.TryParse(input, out tijd)) { break; }
            Console.WriteLine("Ongeldige invoer. Voer een tijd in.");
        }

        while (true) {
            Console.WriteLine("Datum:");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out datum)) { break; }
            Console.WriteLine("Ongeldige invoer. Voer een datum in.");
        }

        while (true) {
            Console.WriteLine("Aantal individuen:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out aantalIndividuen)) { break; }
            Console.WriteLine("Ongeldige invoer. Voer een getal in.");
        }

        while (true) {
            Console.WriteLine("Geslacht:");
            geslacht = Console.ReadLine();

            if (geslacht != null) { break; }
            Console.WriteLine("Ongeldige invoer. Voer een geslacht in.");
        }

        while (true) {
            Console.WriteLine("Is de waarneming gevalideerd (ja/nee)?:");
            string input = Console.ReadLine();
            if (input is "ja" or "nee") { isGevalideerd = input == "ja" ? true : false; break; }
            Console.WriteLine("Ongeldige invoer. Voer ja of nee in.");
        }

        // ==== Start of Function ====
        Waarneming newWaarneming = new Waarneming {
            SoortID = soortID,
            Tijd = tijd,
            Datum = datum,
            AantalIndividuen = aantalIndividuen,
            Geslacht = geslacht,
            IsGevalideerd = isGevalideerd,
            WaarnemingLinks = ""
        };
        return newWaarneming;
    }

    // ==== Constructor ====
    public Waarneming() : base(apiURL: "http://48.209.56.82:5001/api/Waarneming") {
        this.WaarnemingID = 0;
        this.SoortID = 0;
        this.Datum = new DateTime();
        this.Tijd = new TimeSpan();
        this.AantalIndividuen = 0;
        this.Geslacht = "";
        this.IsGevalideerd = false;
        this.WaarnemingLinks = "";
    }

    public Waarneming(int waarnemingID, int soortID, DateTime datum, TimeSpan tijd, int aantalIndividuen, string geslacht, bool isGevalideerd, string waarnemingLinks) : base(apiURL: "http://48.209.56.82:5001/api/Waarneming") {
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
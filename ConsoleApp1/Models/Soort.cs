using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1.Models;

public class Soort : API {
    // ==== Properties ====
    [JsonPropertyName("id")]
    public int SoortID { get; set; }

    [JsonPropertyName("naam")]
    public string Naam { get; set; }

    [JsonPropertyName("latijnseNaam")]
    public string Beschrijving { get; set; }

    [JsonPropertyName("zeldzaamheid")]
    public string Zeldzaamheid { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    // ==== Methods ====
    public void ToonSoortDetails() {
        Console.WriteLine($"Soort ID: {this.SoortID}");
        Console.WriteLine($"Naam: {this.Naam}");
        Console.WriteLine($"Latijnse Naam: {this.Beschrijving}");
        Console.WriteLine($"Zeldzaamheid: {this.Zeldzaamheid}");
        Console.WriteLine($"Status: {this.Status}\n");
    }

    public async Task<List<Soort>> GetSoorten() {
        var data = await this.GetDataFromAPI(this.GetAPIURL());

        if (data != null) {
            List<Soort> soorten = JsonSerializer.Deserialize<List<Soort>>(data);
            return soorten;
        }
        return new List<Soort>();
    }

    public async Task<bool> GetSoort(int soortID)
    {
        var data = await this.GetDataFromAPI(this.GetAPIURL(), soortID);

        if (data != null) {
            Soort soort = JsonSerializer.Deserialize<Soort>(data);
            if (soort != null) {
                return true;
            }
        }
        return false;
    }

    public async Task PostSoort(Soort soort) {
        string jsonString = JsonSerializer.Serialize(soort);

        bool requestResult = await this.PostDataToAPI(jsonString);

        if (requestResult) {
            Console.WriteLine("Soort toegevoegd.");
        }
        else {
            Console.WriteLine("Er is iets fout gegaan bij het toevoegen van de soort.");
        }
    }

    public async Task UpdateSoort(Soort soort) {
        string jsonString = JsonSerializer.Serialize(soort);

        bool requestResult = await this.PUTDataToAPI(soort.SoortID.ToString(), jsonString);

        if (requestResult) {
            Console.WriteLine("Soort bijgewerkt.");
        }
        else {
            Console.WriteLine("Er is iets fout gegaan bij het bijwerken van de soort.");
        }
    }

    public async Task DeleteSoort(int soortID) {
        bool requestResult = await this.DELToAPI(soortID.ToString());

        if (requestResult) {
            Console.WriteLine("Soort verwijderd.\n");
        }
        else {
            Console.WriteLine("Er is iets fout gegaan bij het verwijderen van de soort.");
        }
    }

    public Soort SoortPrompt() {
        // ==== Declaring Variables ====
        string naam, beschrijving, zeldzaamheid, status;

        Console.WriteLine("Naam:");
        naam = Console.ReadLine();

        Console.WriteLine("Latijnse Naam:");
        beschrijving = Console.ReadLine();

        Console.WriteLine("Zeldzaamheid:");
        zeldzaamheid = Console.ReadLine();

        Console.WriteLine("Status:");
        status = Console.ReadLine();

        // ==== Start of Function ====
        Soort newSoort = new Soort {
            Naam = naam,
            Beschrijving = beschrijving,
            Zeldzaamheid = zeldzaamheid,
            Status = status
        };
        return newSoort;
    }

    // ==== Constructor ====
    public Soort() : base(apiURL: "https://localhost:5001/api/Soorten") {
        this.SoortID = 0;
        this.Naam = "";
        this.Beschrijving = "";
        this.Zeldzaamheid = "";
        this.Status = "";
    }

    public Soort(int soortID, string naam, string beschrijving, string zeldzaamheid, string status)
        : base(apiURL: "https://localhost:5001/api/Soorten") {
        this.SoortID = soortID;
        this.Naam = naam;
        this.Beschrijving = beschrijving;
        this.Zeldzaamheid = zeldzaamheid;
        this.Status = status;
    }
}

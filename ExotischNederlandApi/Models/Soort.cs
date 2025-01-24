public class Soort
{
    public int id { get; set; }
    public string naam {  get; set; }
    public string latijnseNaam { get; set; }
    public string zeldzaamheid { get; set; }
    public string status {  get; set; }

    public Soort(int id, string naam, string latijnseNaam, string zeldzaamheid, string status)
    {
        this.id = id;
        this.naam = naam;
        this.latijnseNaam = latijnseNaam;
        this.zeldzaamheid = zeldzaamheid;
        this.status = status;
    }
}
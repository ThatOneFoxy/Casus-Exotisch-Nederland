namespace ConsoleApp1.Models;

public class Leefomgeving: Organisme {
    // ==== Properties ====
    private string naam {get; set;}
    private List<Organisme> organismen {get; set;}

    // ==== Getters ====


    // ==== Methods ====
    public void ToonOrganismen() {
        foreach (Organisme organisme in this.organismen) {
            Console.WriteLine(organisme.VerkrijgBeschrijving());
        }
    }
    public void VoegOrganismeToe(Organisme organisme) {
        this.organismen.Add(organisme);
    }

    // ==== Constructor ====
    public Leefomgeving(string naam) {
        this.naam = naam;
        this.organismen = new List<Organisme>();
    }
}
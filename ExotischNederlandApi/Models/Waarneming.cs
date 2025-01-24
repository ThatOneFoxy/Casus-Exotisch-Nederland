public class Waarneming
{
    public int id { get; set; }
    public TimeSpan tijd { get; set; }
    public DateTime datum { get; set; }
    public int aantalIndividuen { get; set; }
    public string geslacht { get; set; }
    public bool isGevalideerd { get; set; }
    public string waarnemingLinks { get; set; }
    public int soortId { get; set; }

    public Waarneming(int id, TimeSpan tijd, DateTime datum, int aantalIndividuen,
        string geslacht, bool isGevalideerd, string waarnemingLinks, int soortId)
    {
        this.id = id;
        this.tijd = tijd;
        this.datum = datum;
        this.aantalIndividuen = aantalIndividuen;
        this.geslacht = geslacht;
        this.isGevalideerd = isGevalideerd;
        this.waarnemingLinks = waarnemingLinks;
        this.soortId = soortId;
    }
}
namespace ConsoleApp1.Models {
    public class Plant: Organisme {
        // ==== Properties ====
        private string leefgebied {get; set;}
        private double hoogteInMeters {get; set;}

        // ==== Getters ====
        public override string VerkrijgBeschrijving() {
            return $"De {name} is een {origin} {type} en groeit in {leefgebied} en is {hoogteInMeters} meter hoog";
        }

        // ==== Constructor ====
        public Plant(string name, string origin, string leefgebied, double hoogteInMeters) {
            this.type = "plant";

            this.name = name;
            this.origin = origin;
            this.leefgebied = leefgebied;
            this.hoogteInMeters = hoogteInMeters;
        }
    }
}
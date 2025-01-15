namespace ConsoleApp1.Models {
    public class Dier: Organisme {
        // ==== Properties ====
        private string leefgebied {get; set;}

        // ==== Getters ====
        public override string GetDescription() {
            return $"De {name} is een {origin} {type} en leeft in {leefgebied}";
        }

        // ==== Constructor ====
        public Dier(string name, string origin, string leefgebied) {
            this.type = "dier";

            this.name = name;
            this.origin = origin;
            this.leefgebied = leefgebied;
        }
    }
}

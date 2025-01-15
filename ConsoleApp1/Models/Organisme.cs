namespace ConsoleApp1.Models {
    public class Organisme {
        // ==== Properties ====
        public string name {get; set;}
        public string type {get; set;}
        public string origin {get; set;}

        // ==== Getters ====
        public virtual string GetDescription()
        {
            return $"De {name} is een {origin} {type}";
        }
    }
}
// ======== Imports ========
using System.Text.Json;
using ConsoleApp1.Models;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

// ======== Namespace ========
namespace ConsoleApp1
{
    internal class Program
    {
        // ======== Functions ========
        private static async Task DisplayWaarnemingen() {
            Waarneming waarnemingInstance = new Waarneming();
            List<Waarneming> waarnemingen = await waarnemingInstance.GetWaarnemingen();

            Console.WriteLine("Alle waarnemingen:");
            foreach (Waarneming waarneming in waarnemingen) {
                Console.WriteLine($"Soort ID: {waarneming.SoortID}");
                Console.WriteLine($"Datum: {waarneming.Datum}");
                Console.WriteLine($"Tijd: {waarneming.Tijd}");
                Console.WriteLine($"Aantal individuen: {waarneming.AantalIndividuen}");
                Console.WriteLine($"Geslacht: {waarneming.Geslacht}");
                Console.WriteLine($"Is gevalideerd: {waarneming.IsGevalideerd}");
                Console.WriteLine($"Waarneming links: {waarneming.WaarnemingLinks}\n");
            }
        }

        private static async Task AddWaarneming() {
            // ==== Declaring Variables ====
            int soortID, aantalIndividuen;
            string geslacht;
            bool isGevalideerd;
            TimeSpan tijd;
            DateTime datum;


            Waarneming waarnemingInstance = new Waarneming();

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

            await waarnemingInstance.PostWaarneming(newWaarneming);
        }

        private static async Task UpdateWaarneming() {
            // ==== Declaring Variables ====
            string input;

            Waarneming waarnemingInstance = new Waarneming();
            List<Waarneming> waarnemingen = await waarnemingInstance.GetWaarnemingen();

            // ==== Start of Function ====
            Console.WriteLine("\nWelke waarneming zou je willen aanpassen?");

            for (int i = 0; i < waarnemingen.Count; i++) {
                Console.WriteLine($"{i + 1}. Soort ID: {waarnemingen[i].SoortID}, Datum: {waarnemingen[i].Datum}");
            }

            while (true) {
                input = Console.ReadLine();
                if (int.TryParse(input, out int choice)) {
                    if (choice >= 1 && choice <= waarnemingen.Count) {
                        break;
                    }
                    Console.WriteLine($"Ongeldige keuze. Kies een nummer tussen 1 en {waarnemingen.Count}.");
                }
            }


        }
        // ======== Main ========
        static async Task Main(string[] args)
        {
            // ==== Start of Main ====
            while (true) {
                Console.Write(""""
                              "Wat wil je doen binnen de applicatie?
                              
                              === Waarnemingen ===
                              1. Bekijk alle waarnemingen
                              2. Waarneming toevoegen
                              3. Waarneming veranderen
                              4. Waarneming verwijderen
                              
                              === Soorten ===
                              5. Bekijk alle soorten
                              6. Soort toevoegen
                              7. Soort veranderen
                              8. Soort verwijderen
                              
                              """");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice)) {
                    if (choice is < 1 or > 5) { Console.WriteLine("Ongeldige keuze. Kies een nummer tussen 1 en 5."); continue; }

                    switch (choice) {
                        case 1:
                            await DisplayWaarnemingen();
                            break;
                        case 2:
                            await AddWaarneming();
                            break;
                        case 3:
                            await UpdateWaarneming();
                            break;
                        case 7:
                            return;
                    }
                }
            }
        }
    }
}

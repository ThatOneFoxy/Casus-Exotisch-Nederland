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
                waarneming.ToonWaarnemingDetails();
            }
        }

        private static async Task AddWaarneming()
        {
            Waarneming waarnemingInstance = new Waarneming();
            Waarneming newWaarneming = waarnemingInstance.WaarnemingPrompt();

            await waarnemingInstance.PostWaarneming(newWaarneming);
        }

        private static async Task UpdateWaarneming() {
            // ==== Declaring Variables ====
            string input;
            int choice; ;

            Waarneming waarnemingInstance = new Waarneming();
            List<Waarneming> waarnemingen = await waarnemingInstance.GetWaarnemingen();

            // ==== Start of Function ====
            Console.WriteLine("\nWelke waarneming zou je willen aanpassen?");

            for (int i = 0; i < waarnemingen.Count; i++) {
                Console.WriteLine($"{i + 1}. Soort ID: {waarnemingen[i].SoortID}, Datum: {waarnemingen[i].Datum}");
            }

            while (true) {
                input = Console.ReadLine();

                if (int.TryParse(input, out choice)) {
                    if (choice >= 1 && choice <= waarnemingen.Count) {
                        break;
                    }
                    Console.WriteLine($"Ongeldige keuze. Kies een nummer tussen 1 en {waarnemingen.Count}.");
                }
            }

            Waarneming waarneming = waarnemingen[choice-1];
            waarneming.ToonWaarnemingDetails();

            Console.WriteLine("\nWelk detail moet aangepast worden?\n1. SoortID\n2. Datum\n3. Tijd\n4. Aantal Individuen\n5. Geslacht\n6. Is Gevalideerd\n7. Waarneming Links");
            
            input = Console.ReadLine();
            switch (input) {
                case "1":
                    Console.WriteLine("Nieuwe SoortID:");
                    if (int.TryParse(Console.ReadLine(), out int newSoortID)) {
                        waarneming.SoortID = newSoortID;
                    }
                    break;
                case "2":
                    Console.WriteLine("Nieuwe Datum:");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newDatum)) {
                        waarneming.Datum = newDatum;
                    }
                    break;
                case "3":
                    Console.WriteLine("Nieuwe Tijd:");
                    if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newTijd)) {
                        waarneming.Tijd = newTijd;
                    }
                    break;
                case "4":
                    Console.WriteLine("Nieuw Aantal Individuen:");
                    if (int.TryParse(Console.ReadLine(), out int newAantalIndividuen)) {
                        waarneming.AantalIndividuen = newAantalIndividuen;
                    }
                    break;
                case "5":
                    Console.WriteLine("Nieuw Geslacht:");
                    waarneming.Geslacht = Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("Is Gevalideerd (ja/nee):");
                    string isGevalideerdInput = Console.ReadLine();
                    waarneming.IsGevalideerd = isGevalideerdInput.ToLower() == "ja";
                    break;
                case "7":
                    Console.WriteLine("Nieuwe Waarneming Links:");
                    waarneming.WaarnemingLinks = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ongeldige keuze.");
                    break;
            }

            await waarnemingInstance.UpdateWaarneming(waarneming);
        }

        private static async Task DeleteWaarneming() {
            // ==== Declaring Variables ====
            string input;
            int choice; ;

            Waarneming waarnemingInstance = new Waarneming();
            List<Waarneming> waarnemingen = await waarnemingInstance.GetWaarnemingen();

            // ==== Start of Function ====
            Console.WriteLine("\nWelke waarneming zou je willen verwijderen?");

            for (int i = 0; i < waarnemingen.Count; i++) {
                Console.WriteLine($"{i + 1}. Soort ID: {waarnemingen[i].SoortID}, Datum: {waarnemingen[i].Datum}");
            }

            while (true) {
                input = Console.ReadLine();

                if (int.TryParse(input, out choice)) {
                    if (choice >= 1 && choice <= waarnemingen.Count) {
                        break;
                    }
                    Console.WriteLine($"Ongeldige keuze. Kies een nummer tussen 1 en {waarnemingen.Count}.");
                }
            }

            await waarnemingInstance.DeleteWaarneming(choice);
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
                        case 4:
                            await DeleteWaarneming();
                            break;
                        case 7:
                            return;
                    }
                }
            }
        }
    }
}

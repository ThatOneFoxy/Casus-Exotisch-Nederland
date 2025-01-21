﻿// ======== Imports ========
using ConsoleApp1.Models;

// ======== Namespace ========
namespace ConsoleApp1
{
    internal class Program
    {
        // ======== Functions ========
        private static void DisplayOrganismen(List<Organisme> organismen)
        {
            if (organismen.Count == 0)
            {
                Console.WriteLine("Er zijn geen organismen toegevoegd.\n");
            }
            else
            {
                foreach (Organisme organisme in organismen)
                {
                    Console.WriteLine(organisme.VerkrijgBeschrijving() + "\n");
                }
            }
        }

        private static void VoegOrganismenToe(List<Organisme> organismen, Leefomgeving leefomgeving = null)
        {
            // ==== Declaring Variables ====
            string? type, origin, leefgebied, name;
            double hoogteInMeters;

            while (true)
            {
                Console.WriteLine("Watvoor soort organisme wil je toevoegen? (Dier/Plant)"); type = Console.ReadLine()?.ToLower();
                if (type is not "dier" and not "plant")
                {
                    Console.WriteLine("Ongeldige keuze. Kies tussen Dier of Plant.");
                    continue;
                }

                while (true)
                {
                    Console.WriteLine("Oorsprong (Inheems/Exoot):"); origin = Console.ReadLine().ToLower();
                    if (origin is not "inheems" and not "exoot")
                    {
                        Console.WriteLine("Ongeldige keuze. Kies tussen Inheems of Exoot.");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("Naam:"); name = Console.ReadLine();
                Console.WriteLine("Leefgebied:"); leefgebied = Console.ReadLine();

                if (type == "dier")
                {
                    var dier = new Dier(name, origin, leefgebied);
                    organismen.Add(dier);
                    if (leefomgeving != null)
                    {
                        leefomgeving.VoegOrganismeToe(dier);
                    }
                    break;
                }
                if (type == "plant")
                {
                    Console.WriteLine("Hoogte in meters:"); hoogteInMeters = Convert.ToDouble(Console.ReadLine());
                    var plant = new Plant(name, origin, leefgebied, hoogteInMeters);
                    organismen.Add(plant);
                    if (leefomgeving != null)
                    {
                        leefomgeving.VoegOrganismeToe(plant);
                    }
                    break;
                }
            }
            Console.WriteLine("\n");
        }

        private static void FilterPerType(List<Organisme> organismen)
        {
            Console.WriteLine("Op welk type wil je filteren? (Dier/Plant)"); string? type = Console.ReadLine()?.ToLower();
            if (type is not "dier" and not "plant")
            {
                Console.WriteLine("Ongeldige keuze. Kies tussen Dier of Plant.");
                return;
            }

            var filteredPerType = organismen.Where(organisme => organisme.type == type).ToList();
            if (filteredPerType.Count == 0)
            {
                Console.WriteLine($"Er zijn geen organismen van het type {type}.");
            }
            foreach (Organisme organisme in filteredPerType)
            {
                Console.WriteLine(organisme.VerkrijgBeschrijving());
            }
        }

        private static void FilterPerOorsprong(List<Organisme> organismen)
        {
            Console.WriteLine("Op welke oorsprong wil je filteren? (Inheems/Exoot)"); string? origin = Console.ReadLine()?.ToLower();
            if (origin is not "inheems" and not "exoot")
            {
                Console.WriteLine("Ongeldige keuze. Kies tussen Inheems of Exoot.");
                return;
            }

            var filteredPerOorsprong = organismen.Where(organisme => organisme.origin == origin).ToList();
            if (filteredPerOorsprong.Count == 0)
            {
                Console.WriteLine($"Er zijn geen organismen van de oorsprong {origin}.");
            }
            foreach (Organisme organisme in filteredPerOorsprong)
            {
                Console.WriteLine(organisme.VerkrijgBeschrijving());
            }
        }

        // ======== Main ========
        static void Main(string[] args)
        {
            // ==== Declaring Variables ====
            List<Organisme> organismen = new List<Organisme>();
            Leefomgeving bos = new Leefomgeving("Bos");

            // ==== Start of Main ====
            while (true)
            {
                Console.WriteLine("Wat wil je doen binnen de applicatie?\n1. Bekijk alle organismen\n2. Nieuw organisme toevoegen\n3. Filteren op type (Dier/Plant\n4. Filteren op oorsprong (Inheems/Exoot\n5. Voeg organisme toe aan het bos\n6. Bekijk organismen in het bos \n7. Afsluiten\n\n");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    if (choice is < 1 or > 5) { Console.WriteLine("Ongeldige keuze. Kies een nummer tussen 1 en 5."); continue; }

                    switch (choice)
                    {
                        case 1:
                            DisplayOrganismen(organismen);
                            break;
                        case 2:
                            VoegOrganismenToe(organismen);
                            break;
                        case 3:
                            FilterPerType(organismen);
                            break;
                        case 4:
                            FilterPerOorsprong(organismen);
                            break;
                        case 5:
                            return;
                    }
                }
            }
        }
    }
}

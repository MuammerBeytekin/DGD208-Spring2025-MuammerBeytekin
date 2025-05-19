using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public class Game
    {
        private bool isRunning = true;

        // Aletlerin listesi
        private readonly List<Pet> garage = new();

        // Loop
        public void Start()
        {
            while (isRunning)
            {
                Menu.ShowMainMenu();
                Console.Write("\n=> Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdoptMotorcycle();
                        break;
                    case "2":
                        ShowStats();
                        break;
                    case "3":
                        UseItem();
                        break;
                    case "4":
                        ShowCreatorInfo();
                        break;
                    case "5":
                        ExitGame();
                        break;
                    default:
                        Console.WriteLine("That option doesn’t exist. Try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // Menü seçimleri
        private void AdoptMotorcycle()
        {
            Console.Write("Name your new ride: ");
            string name = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Pet moto = new Pet(name, PetType.Motorcycle);
            garage.Add(moto);
            Console.WriteLine($"{name} is now in your garage with all stats at 50.");
        }

        private void ShowStats()
        {
            if (garage.Count == 0)
            {
                Console.WriteLine("Your garage is empty. Adopt a motorcycle first.");
                return;
            }

            Console.WriteLine("\nNAME                FUEL  IGN  RIDE");
            Console.WriteLine("---------------------------------------");
            foreach (var m in garage)
                Console.WriteLine($"{m.Name,-18} {m.Fuel,4}  {m.Ignition,4}  {m.RideQuality,4}");
        }

        private void UseItem()
        {
            if (garage.Count == 0)
            {
                Console.WriteLine("No motorcycles available.");
                return;
            }

            // Sahiplenme
            Console.WriteLine("Select a motorcycle:");
            for (int i = 0; i < garage.Count; i++)
                Console.WriteLine($"{i + 1}. {garage[i].Name}");
            Console.Write("=> ");
            if (!int.TryParse(Console.ReadLine(), out int motoIndex) ||
                motoIndex < 1 || motoIndex > garage.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Pet selected = garage[motoIndex - 1];

            // Item list
            Console.WriteLine("Available items:");
            for (int i = 0; i < ItemDatabase.Items.Count; i++)
            {
                var it = ItemDatabase.Items[i];
                Console.WriteLine($"{i + 1}. {it.Name} (+{it.Amount} {it.AffectedStat}) ≈{it.Seconds}s");
            }
            Console.Write("=> ");
            if (!int.TryParse(Console.ReadLine(), out int itemIndex) ||
                itemIndex < 1 || itemIndex > ItemDatabase.Items.Count)
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            var item = ItemDatabase.Items[itemIndex - 1];
            Console.WriteLine($"{item.Name} is being applied...");
            item.ApplyTo(selected).GetAwaiter().GetResult(); 
        }

        private void ShowCreatorInfo()
        {
            Console.WriteLine("Project Creator");
            Console.WriteLine("Student Name : Muammer Beytekin");
            Console.WriteLine("Student No   : 2305041024");
        }

        private void ExitGame()
        {
            Console.WriteLine("Shutting down. See you next time.");
            isRunning = false;
        }
    }
}

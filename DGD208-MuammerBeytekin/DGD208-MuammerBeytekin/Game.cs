using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public static class Game
    {
        private static List<Pet> pets = new List<Pet>();
        private static List<Item> items = ItemDatabase.GetAllItems();
        private static string playerName = "Muammer Beytekin";
        private static string studentId = "2305041024";

        public static void Start()
        {
            bool playing = true;

            while (playing)
            {
                Console.Clear();
                Console.WriteLine("=== GARAGE BUDDY ===");
                Console.WriteLine("1. Adopt a new ride");
                Console.WriteLine("2. View my rides");
                Console.WriteLine("3. Use an item");
                Console.WriteLine("4. Show creator info");
                Console.WriteLine("5. Exit");
                Console.Write("Pick something: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AdoptPet();
                        break;
                    case "2":
                        ShowStats();
                        break;
                    case "3":
                        UseItem();
                        break;
                    case "4":
                        Console.WriteLine($"Made by (Muammer Beytekin) - {2305041024}");
                        Console.ReadKey();
                        break;
                    case "5":
                        playing = false;
                        break;
                }
            }
        }

        private static void AdoptPet()
        {
            Console.Clear();
            Console.Write("Name your new ride: ");
            string name = Console.ReadLine();

            Console.WriteLine("Pick a style:");
            Array types = Enum.GetValues(typeof(PetType));
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {types.GetValue(i)}");
            }

            if (int.TryParse(Console.ReadLine(), out int petTypeIndex) && petTypeIndex > 0 && petTypeIndex <= types.Length)
            {
                Pet newPet = new Pet(name, (PetType)types.GetValue(petTypeIndex - 1));
                pets.Add(newPet);
                Console.WriteLine($"{name} is ready to roll!");
            }
            else
            {
                Console.WriteLine("Not a valid option.");
            }

            Console.ReadKey();
        }

        private static void ShowStats()
        {
            Console.Clear();
            if (pets.Count == 0)
            {
                Console.WriteLine("You got no rides!");
            }
            else
            {
                foreach (var pet in pets)
                {
                    Console.WriteLine($"{pet.Name} [{pet.Type}] - Fuel: {pet.Hunger}, Engine Rest: {pet.Sleep}, Thrill: {pet.Fun}");
                }
            }
            Console.ReadKey();
        }

        private static async void UseItem()
        {
            Console.Clear();
            if (pets.Count == 0)
            {
                Console.WriteLine("You have no rides to upgrade!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Pick a ride:");
            for (int i = 0; i < pets.Count; i++)
            {
                Console.WriteLine($"{i} - {pets[i].Name} [{pets[i].Type}]");
            }

            if (!int.TryParse(Console.ReadLine(), out int petIndex) || petIndex < 0 || petIndex >= pets.Count)
            {
                Console.WriteLine("Invalid ride!");
                Console.ReadKey();
                return;
            }

            Pet chosenPet = pets[petIndex];

            Console.WriteLine("Pick an item to use:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i} - {items[i].Name} (+{items[i].Value} to {items[i].Type})");
            }

            if (!int.TryParse(Console.ReadLine(), out int itemIndex) || itemIndex < 0 || itemIndex >= items.Count)
            {
                Console.WriteLine("Invalid item!");
                Console.ReadKey();
                return;
            }

            await items[itemIndex].Use(chosenPet);
            Console.ReadKey();
        }

        public static void RemovePet(Pet pet)
        {
            pets.Remove(pet);
        }
    }
}


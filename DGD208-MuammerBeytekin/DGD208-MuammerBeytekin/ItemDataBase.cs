using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public static class ItemDatabase
    {
        public static List<Item> Items = new List<Item>
        {
            new Item("Fuel Can", PetStat.Fuel, 20, 3),
            new Item("Ignition Switch", PetStat.Ignition, 15, 2),
            new Item("Ride Tuner", PetStat.RideQuality, 25, 4)
        };
    }

    public enum PetStat
    {
        Fuel,
        Ignition,
        RideQuality
    }

    public class Item
    {
        public string Name { get; }
        public PetStat AffectedStat { get; }
        public int Amount { get; }
        public int Seconds { get; }

        public Item(string name, PetStat stat, int amount, int seconds)
        {
            Name = name;
            AffectedStat = stat;
            Amount = amount;
            Seconds = seconds;
        }

        public async Task ApplyTo(Pet pet)
        {
            await Task.Delay(Seconds * 1000);

            switch (AffectedStat)
            {
                case PetStat.Fuel:
                    pet.Fuel = Math.Min(100, pet.Fuel + Amount);
                    break;
                case PetStat.Ignition:
                    pet.Ignition = Math.Min(100, pet.Ignition + Amount);
                    break;
                case PetStat.RideQuality:
                    pet.RideQuality = Math.Min(100, pet.RideQuality + Amount);
                    break;
            }

            Console.WriteLine($"{Name} applied. {AffectedStat} increased by {Amount}.");
        }
    }
}

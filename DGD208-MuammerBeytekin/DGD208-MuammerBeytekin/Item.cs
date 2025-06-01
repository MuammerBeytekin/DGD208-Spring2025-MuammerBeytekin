using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value { get; set; }
        public int Duration { get; set; } 

        public Item(string name, ItemType type, int value, int duration)
        {
            Name = name;
            Type = type;
            Value = value;
            Duration = duration;
        }

        public async Task Use(Pet pet)
        {
            Console.WriteLine($"Using {Name} on {pet.Name}...");
            await Task.Delay(Duration);
            pet.AdjustStat(Type.ToStat(), Value);
            Console.WriteLine($"{Name} used!");
        }
    }
}
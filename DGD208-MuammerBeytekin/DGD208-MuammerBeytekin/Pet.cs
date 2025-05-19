using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public enum PetType
    {
        Motorcycle
    }

    public class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }

        public int Fuel { get; set; }
        public int Ignition { get; set; }
        public int RideQuality { get; set; }

        public Pet(string name, PetType type)
        {
            Name = name;
            Type = type;
            Fuel = 50;
            Ignition = 50;
            RideQuality = 50;
        }
    }
}
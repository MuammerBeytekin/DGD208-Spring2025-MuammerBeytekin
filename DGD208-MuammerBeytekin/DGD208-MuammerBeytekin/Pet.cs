using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public class Pet
    {
        private readonly System.Timers.Timer decayTimer;
        private const int decayRate = 1;
        private const int decayInterval = 5000;

        public string Name { get; private set; }
        public PetType Type { get; private set; }
        public int Hunger { get; private set; }
        public int Sleep { get; private set; }
        public int Fun { get; private set; }

        public Pet(string name, PetType type)
        {
            Name = name;
            Type = type;
            Hunger = 50;
            Sleep = 50;
            Fun = 50;

            decayTimer = new System.Timers.Timer(decayInterval);
            decayTimer.Elapsed += (s, e) => DecayStats();
            decayTimer.Start();
        }
        //DED
        private void DecayStats()
        {
            Hunger -= decayRate;
            Sleep -= decayRate;
            Fun -= decayRate;

            if (Hunger <= 0 || Sleep <= 0 || Fun <= 0)
            {
                Console.WriteLine($"{Name} broke down and was towed away...");
                decayTimer.Stop();
                Game.RemovePet(this);
            }
        }

        public void AdjustStat(PetStat stat, int amount)
        {
            switch (stat)
            {
                case PetStat.Hunger:
                    Hunger = Math.Min(100, Hunger + amount);
                    break;
                case PetStat.Sleep:
                    Sleep = Math.Min(100, Sleep + amount);
                    break;
                case PetStat.Fun:
                    Fun = Math.Min(100, Fun + amount);
                    break;
            }
        }
    }
}

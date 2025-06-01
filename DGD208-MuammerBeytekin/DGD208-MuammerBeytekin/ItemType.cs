using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public enum ItemType
    {
        Fuel,
        EngineRest,
        FunRide
    }

    public static class ItemTypeExtensions
    {
        public static PetStat ToStat(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Fuel:
                    return PetStat.Hunger;
                case ItemType.EngineRest:
                    return PetStat.Sleep;
                case ItemType.FunRide:
                    return PetStat.Fun;
                default:
                    return PetStat.Fun;
            }
        }
    }
}
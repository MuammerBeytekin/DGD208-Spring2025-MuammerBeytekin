using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DGD208_MuammerBeytekin
{
    public static class ItemDatabase
    {
        public static List<Item> GetAllItems()
        {
            return new List<Item>
            {
                new Item("Premium Fuel", ItemType.Fuel, 25, 3000),
                new Item("Engine Coolant", ItemType.EngineRest, 20, 3000),
                new Item("Ride the bike", ItemType.FunRide, 30, 5000)
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD208_MuammerBeytekin
{
    public class Menu
    {
        private readonly List<string> options;

        public Menu(List<string> options)
        {
            this.options = options;
        }

        public int Display()
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.Write("Select an option: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                choice -= 1;
                if (choice >= 0 && choice < options.Count)
                    return choice;
            }

            Console.WriteLine("Invalid option. Try again.");
            return Display();
        }
    }
}



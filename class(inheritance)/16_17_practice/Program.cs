using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_17_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal bear = new Bear()
            {
                Name = "Bear",
                Age = 12,
                Weight = 117,
                Skin = "fur",
            };
            Animal[] zoo = new Animal[]
            {
                bear,
                new Frog{ Name = "Frog", Age = 3, Weight = 0.450, Skin = "frog skin" },
                new Dolphin{ Name = "Dolphin", Age = 30, Weight = 230, Skin = "frog skin" },
                new Carp{ Name = "Carp", Age = 6, Weight = 1, Skin = "scales" },
                new Eagle{ Name = "Eagle", Age = 17, Weight = 3, Skin = "feathers" },
            };
            Console.WriteLine("\n\t* WELCOME TO THE ZOO *\n");
            foreach (var x in zoo)
            {
                Console.WriteLine(x);
                Console.WriteLine("\n\t##################################\n");
            }
            Console.WriteLine();
        }
    }
}

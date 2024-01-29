using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace hw_events_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car rcar = new RaceCar("Audi R8", "Racing cars", 0);
            Car truck = new Truck("Ford F-150", "Trucks", 0);
            Car moto = new Motorcycle("Honda SP", "Motorcycles", 0);
            Car van = new Van("Kia Carnival", "Vans", 0);

            Game game = new Game(rcar, truck, moto, van);
            game.Start();

            Console.WriteLine();
        }
    }
}

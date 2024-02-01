using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_events_
{

    public delegate void Del(string text);
    abstract class Car
    {
        const int FINISH = 100;
        public string Model { get; set; }
        public string Category { get; set; }
        public double Speed { get; set; }

        public event Del Finish;

        public Car(string model, string category, double speed)
        {
            Model = model;
            Category = category;
            Speed = speed;
        }
        public virtual void IsWinner(string message)
        {
            Finish?.Invoke(message);
        }
        public bool Finished()
        {
            return Speed >= FINISH;
        }
        public override string ToString()
        {
            return $"{Model}";
        }
    }

    class Truck : Car
    {
        public Truck(string model, string category, double speed)
            : base(model, category, speed) { }
        public override void IsWinner(string message) => base.IsWinner(message);
    }
    class Van : Car
    {
        public Van(string model, string category, double speed)
            : base(model, category, speed) { }
        public override void IsWinner(string message) => base.IsWinner(message);
    }
    class RaceCar : Car
    {
        public RaceCar(string model, string category, double speed)
            : base(model, category, speed) { }
        public override void IsWinner(string message) => base.IsWinner(message);
    }
    class Motorcycle : Car
    {
        public Motorcycle(string model, string category, double speed)
            : base(model, category, speed) { }
        public override void IsWinner(string message) => base.IsWinner(message);
    }

    class Game
    {
        List<Car> cars = new List<Car>();
        public Game(params Car[] cars)
        {
            this.cars.AddRange(cars);
        }
        public void Start()
        {
            Console.WriteLine("\n\t\t<<<<< THE RACE HAS STARTED >>>>>\n");
            foreach (var car in cars)
            {
                car.Finish += EndRace;
            }

            while (true)
            {
                var rnd = new Random();
                for (int i = 0; i < cars.Count; i++)
                {
                    cars[i].Speed += rnd.Next(1, 10);
                }

                Console.WriteLine(String.Join("\t", cars.Select
                    (i => $"  {i.Model} ({i.Speed} km/h)")));

                foreach (var car in cars)
                {
                    if (car.Finished())
                    {
                        car.IsWinner($"{car} is the WINNER in the '{car.Category}' category");
                        return;
                    }
                }
            }
        }
        private void EndRace(string message)
        {
            Console.WriteLine($"\n\t\t*** {message} ***");
        }
    }

}
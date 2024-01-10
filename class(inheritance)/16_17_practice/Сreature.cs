using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _16_17_practice
{
    abstract public class Сreature
    {
        private string name;
        private double age;
        public double Age
        {
            get => age;
            set => age = value > 0 ? value : throw new Exception ("no age");
        }
        public string Name { get=>name; set=> name = value ?? "no name"; }

        public override string ToString()
        {
            return $"\tName: {Name}\n\tAge: {Age} y.o.";
        }

    }
}












//public abstract void fly();
//public abstract void swim();
//public abstract void makeSound();
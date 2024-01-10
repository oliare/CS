using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _16_17_practice
{
    //b
    enum HabitatZone
    {
        SWAMP = 1, RESERVOIR = 2, DESERT = 3, FOREST = 4, STEPPE = 5, MOUNTAINS = 6
    }
    internal class Animal : Сreature
    {
        private double weight;
        public virtual string Thermoregulation { get => "ectotherm"; }
        public virtual string Feeding { get => "omnivorous"; }
        public double Weight
        {
            get => weight;
            set => weight = value > 0 ? value : throw new Exception("wrong weight");
        }
        private string skin;
        public virtual string Skin
        {
            get => skin;
            set => skin = String.IsNullOrWhiteSpace(value) ? "no skin" : value;
        }
        public override string ToString()
        {
            return base.ToString() + $"\n\tWeight: {Weight} kg\n\tSkin: {Skin}" +
                $"\n\tFeeding type: {Feeding}\n\tThermoregulation: {Thermoregulation}";
        }
    }
    //c
    internal class Reptile : Animal
    {
        public override string Thermoregulation { get => "ectotherm"; }
        public override string Feeding { get => "omnivorous"; }
    }
    internal class Mammal : Animal
    {
        public override string Thermoregulation { get => "endotherm"; }
        public override string Feeding { get => "omnivorous"; }
    }

    internal class Bird : Animal
    {
        public override string Thermoregulation { get => "endotherm"; }
        public override string Feeding { get => "omnivorous"; }
    }

    internal class Fish : Animal
    {
        public override string Thermoregulation { get => "ectotherm"; }
        public override string Feeding { get => "carnivorous"; }
    }

    //d
    internal class Bear : Mammal
    {
        public override string Feeding { get => "omnivorous"; }
        public override string ToString()
        {
            return base.ToString() + $"\n\tHabitat zone: {HabitatZone.FOREST}";
        }
    }

    internal class Frog : Reptile
    {
        public override string Feeding { get => "omnivorous"; }
        public override string ToString()
        {
            return base.ToString() + $"\n\tHabitat zone: {HabitatZone.SWAMP}, {HabitatZone.RESERVOIR}";
        }
    }

    internal class Dolphin : Mammal
    {
        public override string Feeding { get => "carnivorous"; }
        public override string Thermoregulation { get => "endotherm"; }
        public override string ToString()
        {
            return base.ToString() + $"\n\tHabitat zone: {HabitatZone.RESERVOIR}";
        }
    }

    internal class Carp : Fish
    {
        public override string Feeding { get => "herbivorous"; }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    internal class Eagle : Bird
    {
        public override string Feeding { get => "carnivorous"; }
        public override string ToString()
        {
            return base.ToString() + $"\n\tHabitat zone: {HabitatZone.MOUNTAINS}, {HabitatZone.STEPPE}";
        }
    }

}

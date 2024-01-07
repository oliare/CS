using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_class_
{
    internal class Magazine
    {
        private string name;
        private string year;
        private string description;
        private string phone;
        private string email;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid name\n");
                    value = "empty";
                }
                name = value;
            }
        }
        public string Year
        {
            get { return year; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid year\n");
                    value = "empty";
                }
                year = value;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid description \n");
                    value = "empty";
                }
                description = value;
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid phone\n");
                    value = "empty";
                }
                phone = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid email\n");
                    value = "empty";
                }
                email = value;
            }
        }
        public void input()
        {
            Console.WriteLine("\n\tEntering data about the Magazine");
            Console.Write("The name of the magazine: ");
            Name = Console.ReadLine();

            Console.Write("The year of the magazine: ");
            Year = Console.ReadLine();

            Console.Write("The phone of the magazine: ");
            Phone = Console.ReadLine();
            
            Console.Write("The email of the magazine: ");
            Email = Console.ReadLine();

            Console.Write("The description of the magazine: ");
            Description = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"Name : {name}\nYear : {year}\nPhone: {phone}" +
                $"\nEmail: {email}\nDescription: {description}";
        }

    }
}

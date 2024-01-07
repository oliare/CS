using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_class_
{
    internal class Shop
    {
        private string name;
        private string address;
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
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid address\n");
                    value = "empty";
                }
                address = value;
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
            Console.WriteLine("\n\tEntering data about the Shop");
            Console.Write("The name of the shop: ");
            Name = Console.ReadLine();

            Console.Write("The address of the shop: ");
            Address = Console.ReadLine();

            Console.Write("The phone of the shop: ");
            Phone = Console.ReadLine();

            Console.Write("The email of the shop: ");
            Email = Console.ReadLine();

            Console.Write("The description of the shop: ");
            Description = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"Name : {name}\nPhone: {phone}\nEmail: {email}" +
                $"\nAddress: {address}\nDescription: {description}";
        }
    }
}

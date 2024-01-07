using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace hw_class_
{
    internal class Website
    {
        private string name;
        private string url;
        private string description;
        private string ip;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid Name\n");
                    value = "empty";
                }
                name = value;
            }
        }
        public string Url
        {
            get { return url; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid URL\n");
                    value = "empty";
                }
                url = value;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid Description \n");
                    value = "empty";
                }
                description = value;
            }
        }
        public string Ip
        {
            get { return ip; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("- invalid IP\n");
                    value = "empty";
                }
                ip = value;
            }
        }
        public void input()
        {
            Console.WriteLine("\n\tEntering data about the Website");
            Console.Write("The name of the website: ");
            Name = Console.ReadLine();

            Console.Write("The url of the website: ");
            Url = Console.ReadLine();

            Console.Write("The description of the website: ");
            Description = Console.ReadLine();

            Console.Write("The IP of the website: ");
            Ip = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"Name: {name}\nURL : {url}\nIP  : {ip}" +
                $"\nDescription: {description}";
        }

    }

}

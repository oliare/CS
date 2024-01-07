using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace hw_class_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            Website w = new Website();
            w.input();

            w.Description = "This is where all the resources for your CS50 classroom will live for your classroom." +
                " With this model, you have complete control over what content is displayed as well as how it is displayed.";
            w.Url = "https://cs50.readthedocs.io/site/";

            Console.WriteLine("\n\t* Website data *");
            Console.WriteLine(w.ToString());
            Console.WriteLine();
            // 2
            Magazine m = new Magazine();
            m.input();
            m.Name = "test";
            Console.WriteLine("\n\t* Magazine data *");
            Console.WriteLine(m.ToString());
            Console.WriteLine();
            // 3
            Shop s = new Shop();
            s.input();
            s.Phone = "+(380)63-123-11-00";
     
            Console.WriteLine("\n\t* Shop data *");
            Console.WriteLine(s.ToString());
            Console.WriteLine();
        }
    }
}

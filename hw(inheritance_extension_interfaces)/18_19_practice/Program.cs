using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comp comp = new Comp(4, 2);

            DVD dvd = new DVD("DVD", 4500); 
            CD cd = new CD("CD", 500);      
            HDD hdd = new HDD("HDD", 2000); 
            Flash flash = new Flash("Flash", 32);
            comp.AddDisk(0, dvd);
            comp.AddDisk(1, cd);
            comp.AddDisk(2, hdd);
            comp.AddDisk(3, flash);

            Printer p = new Printer();
            Monitor m = new Monitor();
            comp.AddDevice(0, p);
            comp.AddDevice(1, m);

            Console.WriteLine(comp.ToString());

            comp.ShowPrintDevice();

            Console.WriteLine();
            p.Print("prints information - ");
            m.Print("displays information - ");

            comp.ShowDisk();

            Console.Write("\n\tRead Information:");
            comp.ReadInfo(dvd.ToString());
            comp.ReadInfo(cd.ToString());
            comp.ReadInfo(hdd.ToString());
            comp.ReadInfo(flash.ToString());

            Console.WriteLine("\n\n\tCheck Disk:");
            string disk = "Flash";
            Console.WriteLine(comp.CheckDisk(disk) 
                ? $"{disk} - exists" : $"{disk} - doesn`t exist");

            Console.WriteLine("\n\tPrint Information:");
            comp.PrintInfo("DVDs offer significantly higher storage capacity" +
                " than compact discs (CD) while having the same dimensions", "DVD");
           
            comp.WriteInfo("\nInformation is written to a file", "about HDD");
            Console.WriteLine();
            cd.Write("here you can write information about "+ cd.GetName());
            hdd.Write("here you can write information about " + flash.GetName());

            Console.WriteLine("\n\tInsert Reject:");
            comp.InsertReject("DVD", true);
            comp.InsertReject("dvd", false);
            comp.InsertReject("DVD", false);

            Console.WriteLine("\n");
        }
    }
}

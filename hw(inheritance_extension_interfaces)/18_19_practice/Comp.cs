using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class Comp
    {
        private int countDisk;
        private int countPrintDevice;
        private Disk[] disks;
        private IPrintInformation[] printDevice;

        public void AddDevice(int index, IPrintInformation si)
        {
            if (index >= 0 && index < countPrintDevice)
            {
                printDevice[index] = si;
                Console.WriteLine("\tdevice added !");
            }
            else
            {
                Console.WriteLine("! invalid device index");
            }
        }
        public void AddDisk(int index, Disk d)
        {
            if (index >= 0 && index < countDisk)
            {
                disks[index] = d;
                Console.WriteLine("\tdisk added !");
            }
            else
            {
                Console.WriteLine("! invalid disk index");
            }
        }
        public bool CheckDisk(string device)
        {
            return disks.Any(i => i.GetName() == device);
        }
        public Comp(int d, int pd)
        {
            countDisk = d;
            disks = new Disk[countDisk];
            countPrintDevice = pd;
            printDevice = new IPrintInformation[countPrintDevice];
        }
        public void InsertReject(string device, bool b)
        {
            Disk disk = Array.Find(disks, x => x.GetName() == device);
            if (disk != null && disk is IRemoveableDisk)
            {
                if (b)
                {
                    (disk as IRemoveableDisk).Insert();
                }
                else
                {
                    (disk as IRemoveableDisk).Reject();
                }
            }
            else
            {
                Console.WriteLine($"-- no {device} to reject");
            }
        }
        public bool PrintInfo(string text, string device)
        {
            if (CheckDisk(device))
            {
                Console.WriteLine($"{text} >>> {device}");
                return true;
            }
            Console.WriteLine($"-- device '{device}' not found");
            return false;
        }
        public string ReadInfo(string device)
        {
            if (device != null)
                Console.Write(device);
            return device;
        }
        public void ShowDisk()
        {
            Console.WriteLine("\n\n\tShow Disks:");
            foreach (var item in disks)
            {
                if (item != null)
                {
                    Console.WriteLine(item.GetName());
                }
            }
        }
        public void ShowPrintDevice()
        {
            Console.WriteLine("\n\tShow Print Devices:");
            foreach (var item in printDevice)
            {
                if (item != null)
                {
                    Console.WriteLine(item.GetName());
                }
            }
        }
        public bool WriteInfo(string text, string showDevice)
        {    
            Disk disk = new Disk();
            if (disk != null)
            {
                // запис інформації
                Console.WriteLine($"{text} >>> {showDevice}");
                return true;
            }
            Console.WriteLine($"-- device '{showDevice}' not found");
            return false;
        }
        public override string ToString()
        {
            return $"\nCount of Disks: {countDisk}" +
                $"\nCount of Print Devices: {countPrintDevice}";
        }
    }
}
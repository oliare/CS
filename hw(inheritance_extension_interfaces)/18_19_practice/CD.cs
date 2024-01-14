using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class CD : Disk, IRemoveableDisk
    {
        private bool hasDisk = true;
        public bool HasDisk => hasDisk;
        public CD(string memory, int memSize) : base(memory, memSize)
        {
        }
        public void Insert()
        {
            Console.WriteLine($"{Memory} inserted");
        }
        public void Reject()
        {
            Console.WriteLine($"{Memory} rejected");
        }
        public string GetName()
        {
            return "CD";
        }
        public override string ToString()
        {
            return base.ToString() + $"\tHas Disk: {HasDisk}";
        }
    }

}

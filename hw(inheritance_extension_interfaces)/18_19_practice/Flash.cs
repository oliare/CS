using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class Flash : Disk, IRemoveableDisk
    {
        private bool hasDisk = false;
        public Flash(string memory, int memSize) : base(memory, memSize)
        {
        }
        public bool HasDisk { get => hasDisk; }
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
            return "Flash";
        }
        public override string ToString()
        {
            return base.ToString() + $"\t\tHas Disk: {HasDisk}";
        }
    }

}

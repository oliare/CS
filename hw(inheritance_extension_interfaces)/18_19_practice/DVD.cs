using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class DVD : Disk, IRemoveableDisk
    {
        private bool hasDisk = false;
        public DVD(string memory, int memSize) : base(memory, memSize)
        {
        }
        public bool HasDisk
        {
            get { return hasDisk; }
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
            return "DVD";
        }
        public override string ToString()
        {
            return base.ToString() + $"\tHas Disk: {HasDisk}";
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class HDD : Disk
    {
        public HDD(string memory, int memSize) : base(memory, memSize)
        {
        }
        public string GetName()
        {
            return "HDD";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

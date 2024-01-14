using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class Disk : IDisk
    {
        public string Memory { get; set; }
        public int MemSize { get; set; }
        public Disk()
        {
        }
        public Disk(string memory, int memSize)
        {
            Memory = memory;
			MemSize = memSize;
        }
        public string GetName()
		{
			return Memory;
		}
		public string Read()
		{
			return $"\nName: {GetName(),-10}Memory Size: {MemSize}";
		}
        public void Write(string text)
        {
            Console.WriteLine($"Method Write --> {text} ");
        }
        public override string ToString()
        {
           return Read();
        }

    }
}

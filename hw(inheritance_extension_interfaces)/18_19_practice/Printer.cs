using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal class Printer : IPrintInformation
    {
        public string GetName()
        {
            return "Printer";
        }
        public void Print(string str)
        {
            Console.WriteLine($"Print: {str + GetName()}");
        }
        public override string ToString()
        {
            return GetName();
        }
    }
}

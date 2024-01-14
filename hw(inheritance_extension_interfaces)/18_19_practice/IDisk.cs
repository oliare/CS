using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_19_practice
{
    internal interface IDisk
    {
        string Read();
        void Write(string text);
    }

}

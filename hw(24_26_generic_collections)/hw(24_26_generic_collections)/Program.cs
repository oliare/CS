using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hw_24_26_generic_collections_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            Employee e1 = new Employee("Marchuk Denis Viktorovych", "data scientist", 4800, "den@gmail.com");
            Employee e2 = new Employee("Paray Dmytro Serhiyovych", "software engineer", 3100, "parayd@gmail.com");
            Employee e3 = new Employee("Bondar Roman Volodymyrovych", "UI/UX designer", 2700, "bonrom@gmail.com");

            Methods m = new Methods(list);
            m.AddEmp(e1);
            m.AddEmp(e2);
            m.AddEmp(e3);
            Print(list, "\t>>>>>>> DATA BASE <<<<<<<");
            
            m.SortBySalary();
            Print(list, "\t>>>>>>> DATA BASE <<<<<<<");
            
            m.ChangeEmp(e3, "Bondarenko Vitaliy Viktorovych", "c# developer", 3500, "vitaliy@gmail.com");
            Print(list, "\t>>>>>>> DATA BASE <<<<<<<");
            
            m.SearchByName("Paray Dmytro Serhiyovych");

            m.RemoveEmp("Marchuk Denis Viktorovych");
            Print(list, "\t>>>>>>> DATA BASE <<<<<<<");
            
            Console.WriteLine();
        }
        static void Print<T>(IEnumerable<T> list, string prompt = "")
        {
            Console.WriteLine("\n" + prompt + "\n");
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("\t------------------------");
            }
            Console.WriteLine();

        }

    }
}

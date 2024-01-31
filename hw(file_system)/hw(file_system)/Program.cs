using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_file_system_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path: ");
            var path = Console.ReadLine();
            Console.WriteLine();
            try
            {
                if (Directory.Exists(path))
                    getData(path, "");
                else 
                    throw new Exception($"'{path}' does not exist ...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            Console.WriteLine();
        }
        static void getData(string path, string main)
        {
            string current = Path.GetFileName(path);

            if (!string.IsNullOrEmpty(main))
                Console.WriteLine($"\tSubfolder '{current}' (in '{main}')");
            else
                Console.WriteLine($"\t\tSubfolder '{current}'");

            string[] files = Directory.GetFiles(path);
            foreach (var item in files)
            {
                Console.WriteLine($"\t\t\t- File: {Path.GetFileName(item)}");
            }

            string[] folders = Directory.GetDirectories(path);
            foreach (var item in folders)
            {
                getData(item, current);
            }
        }
    }
}

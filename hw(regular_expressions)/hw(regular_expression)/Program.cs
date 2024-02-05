using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hw_regular_expression_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            {
                var numbers = new[] { 18, 253, 1111, 12345, 1234, 7, 4567, 857, 43657 };
                List<int> res = new List<int>();
                string pattern = @"\b[0-9]{4}\b";
                foreach (var number in numbers)
                {
                    if (Regex.IsMatch(number.ToString(), pattern))
                        res.Add(number);
                }
                Console.WriteLine($"Four-digit numbers: {String.Join(", ", res)}\n");
            }

            // 2
            {
                var words = new[] { "3n7m", "456top", "amd144dna003", "test321", "www321cpu321" };
                string pattern = @"\w{3}\d{3}\w{3}\d{3}";
                var regex = words.Where(i => Regex.IsMatch(i, pattern)).ToList();
                Console.WriteLine($"Matched words: {String.Join(", ", regex)}\n");
                
            }

            // 3
            {
                string text = "You can download files in different formats," +
                    " for example: PDF, RTF and others." +
                    " You can also save bitmap images in BMP format.";
                var pattern = @"\b[A-Z]+\b";

                MatchCollection mc = Regex.Matches(text, pattern);
                Console.WriteLine($"ABBR: {String.Join(", ", mc.Cast<Match>().Select(match => match.Value))}\n");
            }

            // 4
            {
                var years = "1089 1900 2010 2099 2100";
                var pattern = @"(19|20)\d{2}";
                MatchCollection mc = Regex.Matches(years, pattern);
                Console.WriteLine($"1900-2099: {String.Join(", ", mc.Cast<Match>().Select(match => match.Value))}\n");
            }

            // 5
            {
                var pattern = @"\+38-0\d{2}-\d{3}-\d{2}-23";
                var phone = "+38-067-363-12-23";
                var regex = Regex.IsMatch(phone, pattern);
                Console.WriteLine(regex ? $"'{phone}' is matched" 
                    : $"'{phone}' not matched");
                Console.WriteLine();
            }
        }

    }
}

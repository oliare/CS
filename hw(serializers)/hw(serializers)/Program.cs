using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace hw_serializers_
{
    class Currency
    {
        public string Ccy { get; set; }
        public string BaseCurrency { get => "UAH"; }
        public double Buy { get; set; }
        public double Sale { get; set; }

        public override string ToString()
        {
            return $"Currency: {Ccy,-7}Base currency: {BaseCurrency,-7}" +
                $"Buy: {Buy,-7}Sale: {Sale}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string json = wc.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");

            List<Currency> list = JsonConvert.DeserializeObject<List<Currency>>(json);

            while (true)
            {
                Console.Write("\nEnter the currency code >>\n\t1 - EUR \n\t2 - USD\n> ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int choice) && choice >= 1
                    && choice <= list.Count)
                {
                    Currency chosen = list[choice - 1];
                    Console.WriteLine(chosen.ToString());
                    break;
                }
                else
                    Console.WriteLine($"> '{choice}' wrong choice");
            }

            Console.WriteLine();
        }

    }
}



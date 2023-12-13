using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_01_intro_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1();
            //task2();
            //task3();
            //task4();
            //task5();
            //task6();
            //task7();
        }

        //1
        static void task1()
        {
            Console.WriteLine("Enter value between 1-100");
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                if (n >= 1 && n <= 100)
                {
                    if (n % 5 == 0 && n % 3 == 0)
                    {
                        Console.WriteLine("Fizz Buzz");
                    }
                    else if (n % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if (n % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine("> " + n);
                    }
                }
                else
                {
                    Console.WriteLine("!invalid value, try again! ");
                }
            }
        }
        //2
        static void task2()
        {
            Console.Write("Enter value: ");
            double val = double.Parse(Console.ReadLine());
            Console.Write("Enter  %   : ");
            double perc = double.Parse(Console.ReadLine());
            double res = (val * perc) / 100;
            Console.WriteLine($"Result: {res}");
        }
        //3
        static void task3()
        {
            Console.WriteLine("Enter 4 digits");
            string value = "";
            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"{i} number: ");
                value += Console.ReadLine();
            }
            int res = int.Parse(value);
            Console.WriteLine("Your number is " + res);
        }
        //4
        static void task4()
        {
            Console.Write("Enter 6-digits number: ");
            string data = Console.ReadLine();

            if (data.Length != 6)
            {
                Console.WriteLine("!uncorrect entered data!");
            }

            Console.Write("Enter positions to swap (1-6):");
            int pos1 = int.Parse(Console.ReadLine());
            int pos2 = int.Parse(Console.ReadLine());

            if (pos1 < 1 || pos1 > 6 || pos2 < 1 || pos2 > 6)
            {
                Console.WriteLine("!uncorrect entered positions!");
            }

            char[] digits = data.ToCharArray();
            char tmp = digits[pos1 - 1];
            digits[pos1 - 1] = digits[pos2 - 1];
            digits[pos2 - 1] = tmp;

            string res = new string(digits);
            Console.WriteLine($"Swapped digits: {res}");
        }
        //5
        static void task5()
        {
            Console.Write("Enter a date (dd.mm.yyyy): ");
            string info = Console.ReadLine();

            string[] splitDate = info.Split('.');

            if (splitDate.Length == 3 &&
                int.TryParse(splitDate[0], out int day) &&
                int.TryParse(splitDate[1], out int month) &&
                int.TryParse(splitDate[2], out int year))
            {
                if (month < 3)
                {
                    year -= 1;
                }

                int d = (month < 3) ? month + 10 : month - 2;
                int m = year % 100;
                int y = year / 100;
                int weekDay = (day + (13 * d + 2) / 5 + m + m / 4 + y / 4 - 2 * y) % 7;

                if (weekDay < 0)
                {
                    weekDay += 7;
                }

                string[] days = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
                string dayOfWeek = days[weekDay];

                string season = Seasons(month);
                Console.WriteLine($"day: {dayOfWeek}\tseason: {season}");
            }
            else
            {
                Console.WriteLine("invalid date");
            }
            Console.WriteLine();
        }

        static string Seasons(int month)
        {
            switch (month)
            {
                case 1:
                case 2:
                case 12:
                    return "Winter";
                case 3:
                case 4:
                case 5:
                    return "Spring";
                case 6:
                case 7:
                case 8:
                    return "Summer";
                case 9:
                case 10:
                case 11:
                    return "Autumn";
                default:
                    return "? season";
            }
        }

        // 6
        static void task6()
        {
            Console.Write("Enter the temperature: ");
            double val = double.Parse(Console.ReadLine());

            Console.Write("Enter the 'FROM'  (1 - C, 2 - F): ");
            int from = int.Parse(Console.ReadLine());

            Console.Write("Enter the 'TO'  (1 - C, 2 - F): ");
            int to = int.Parse(Console.ReadLine());

            double res = calcTemp(from, to, val);
            res = Math.Round(res, 2);
            Console.WriteLine($"Result: {res}*\n ");
        }
        static double calcTemp(int from, int to, double value)
        {
            if (from == 1 && to == 2)
            {
                return value * 9 / 5 + 32;
            }
            else if (from == 2 && to == 1)
            {
                return (value - 32) * 5 / 9;
            }
            else
            {
                return value;
            }
        }
        // 7
        static void task7()
        {
            Console.Write("Enter begin number: ");
            int begin = int.Parse(Console.ReadLine());

            Console.Write("Enter end number  : ");
            int end = int.Parse(Console.ReadLine());

            if (begin > end)
            {
                int tmp = begin;
                begin = end;
                end = tmp;
            }

            for (int i = begin; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }


}

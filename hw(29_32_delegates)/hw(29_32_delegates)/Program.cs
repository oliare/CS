using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace hw_29_32_delegates_
{

    delegate void DelShape(uint height, ConsoleColor color, char s);
    class Draw
    {
        public static void DrawSquare(uint height, ConsoleColor color, char s)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void DrawTriangle(uint height, ConsoleColor color, char s)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
    //
    class Calculator
    {
        public enum Operation { add, sub, mult, div }
        Func<double, double, double> func;
        public void SetOperation(Operation op)
        {
            if (op == Operation.add)
                func = (a, b) => a + b;
            else if (op == Operation.sub)
                func = (a, b) => a - b;
            else if (op == Operation.mult)
                func = (a, b) => a * b;
            else if (op == Operation.div)
                func = (a, b) => a / b;
            else
                throw new NotImplementedException();
        }
        public double Calculate(double a, double b)
        {
            return func(a, b);
        }
    }
    internal class Program
    {
        static void Sort<T>(T[] arr, Comparison<T> comp)
        {
            int size = arr.Length;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (comp(arr[j], arr[j + 1]) > 0)
                    {
                        var tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // Task 1
            //DelShape shapes = Draw.DrawSquare;
            //shapes += Draw.DrawTriangle;
            //shapes(7, ConsoleColor.Magenta, '*');

            // Task 2
            //Calculator calculator = new Calculator();
            //calculator.SetOperation(Calculator.Operation.add);
            //double add = calculator.Calculate(22, 6);

            //calculator.SetOperation(Calculator.Operation.sub);
            //double sub = calculator.Calculate(7, -3);

            //calculator.SetOperation(Calculator.Operation.mult);
            //double mult = calculator.Calculate(2, 4);

            //calculator.SetOperation(Calculator.Operation.div);
            //double div = calculator.Calculate(216, 8);

            //Console.WriteLine("Addition       : " + add);
            //Console.WriteLine("Subtraction    : " + sub);
            //Console.WriteLine("Division       : " + div);
            //Console.WriteLine("Multiplication : " + mult);

            //Console.WriteLine();

            // Task 3
            string[] products = { "strawberry", "kiwi", "grape", "pineapple", "pea", "garlic", "cauliflower" };
            Comparison<string> comp = (s1, s2) => s1.Length.CompareTo(s2.Length);
            Sort(products, comp);
            Console.WriteLine("Sorted by growth: ");
            foreach (var item in products)
            {
                Console.WriteLine($"> {item}");
            }
            Console.WriteLine("\nSorted by abc: ");
            Sort(products, (s1, s2) => s1.CompareTo(s2));
            foreach (var item in products)
            {
                Console.WriteLine($"> {item}");
            }

            Console.WriteLine();
        }
    }
}


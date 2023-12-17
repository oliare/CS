using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_arrays_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Part I

            //1
            Console.Write("Created Array: ");
            printArray(CreateArr(10));
            //2
            int[] arr = new int[10];
            FillRandArr(arr, 1, 30);
            //3
            printArray(arr, "\nRandom Array: ");
            // 4
            Console.Write("\nBefore swap: ");
            printArray(arr);
            SwapArray(ref arr);
            Console.Write("\nAfter swap: ");
            printArray(arr);
            //5
            int item = Array.Find(arr, i => i > 0);
            Console.WriteLine(item > 0 ? "\nFirst positive number: " + item :
                "\nHere is not positive numbers");
            //6
            int countPos = arr.Count(i => i % 2 == 0);
            Console.WriteLine($"Count of EVEN numbers: {countPos}");
            //7
            int firstIndexMultOf7 = Array.FindIndex(arr, i => i % 7 == 0);
            Console.WriteLine("Index of the first multiple of seven: " + firstIndexMultOf7);
            Console.WriteLine();

            // Part II
            int[] arr2 = new int[10];
            FillRandArr(arr2, -15, 15);
            printArray(arr2, "\nNew Array: ");
            int[] x = Array.FindAll(arr2, i => i > 0);
            int[] y = Array.FindAll(arr2, i => i <= 0);
            int[] res = y.Concat(x).ToArray();
            printArray(res, "\nRearranged Array: ");
            Console.WriteLine();

            // Part III
            Console.Write("\nEnter the array size: ");
            string size = Console.ReadLine();

            if (int.TryParse(size, out int number))
            {
                int[] arr3 = new int[number];
                FillRandArr(arr3, 10, 25);
                printArray(arr3);
                Console.Write("\nEnter the value: ");
                string value = Console.ReadLine();
                if (int.TryParse(value, out int n))
                {
                    int count = arr3.Count(i => i == n);
                    Console.WriteLine($"The number of occurrences '{value}' in the array: {count}");
                }
                else
                { Console.WriteLine("!an incorrect number was entered!"); }
            }
            else
            { Console.WriteLine("!an incorrect number was entered!"); }
            Console.WriteLine();

        }
        static int[] CreateArr(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i + 1;
            }
            return arr;
        }

        static void FillRandArr(int[] arr, int begin, int end)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(begin, end + 1);
            }
        }
        static void printArray(int[] arr, string text = "")
        {
            Console.WriteLine(text);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("\t{0}", arr[i]);
            }
            Console.WriteLine();
        }
        static void Swap(ref int[] arr, int begin, int end)
        {
            var tmp = arr[begin];
            arr[begin] = arr[end];
            arr[end] = tmp;
        }

        static void SwapArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                Swap(ref arr, i, i + 1);
            }
        }

    }
}

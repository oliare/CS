using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw_04_08_
{
    internal class Program
    {
        static void Main(string[] args)
        {
    // Mult/Jugged ARRAYS

            int[][] arr = createJArray(4, 3);
            fillJArray(arr, 1, 30);
            printJArray(arr);

            int[] newRow = new int[3];
            addRow(ref arr, newRow);
            printJArray(arr, "\nArray after adding the row to the end: ");
            //delRowByIndex(arr, 3);
            printJArray(arr, "\nArray after deleting the row by index: ");

            Up(arr, 3);
            Console.WriteLine("\nІhifting the rows of the matrix up");
            printJArray(arr);
            Console.WriteLine("\nAfter shifting matrix rows down");
            Down(arr, 3);
            printJArray(arr);

    // METHODS

            int[][] res = findMinMax(arr);
            Console.WriteLine("Min: " + res[0][0]);
            Console.WriteLine("Max: " + res[1][0]);

    // STRINGS
            // 1
            Console.Write("Enter some text: ");
            string line = Console.ReadLine();
            Console.Write("Enter symbol to find: ");
            char symbol = char.Parse(Console.ReadLine());

            bool found = false;
            string newLine = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == symbol)
                {
                    Console.WriteLine($"'{symbol}' was found at index: {i}");
                    found = true;
                    newLine += char.ToUpper(symbol);
                }
                else newLine += line[i];
            }
            if (!found)
            {
                Console.WriteLine($"'{symbol}' wasn't found");
            }
            int remove = line.LastIndexOf(symbol);
            if (remove != -1)
            {
                newLine = newLine.Remove(remove);
            }
            Console.WriteLine($"The resulting line: {newLine}");
            Console.WriteLine();

            // 2
            string text = "Lorem ipsum dolor sit amet consectetur";
            text = removeSymbol(text, 't');
            Console.WriteLine($"Line: {text}");

            // 3
            string str = "I don’t know whether to delete this or rewrite it";
            string abc = "abcdefghijklmnopqrstuvwxyz";

            foreach (char c in abc)
            {
                int count = str.Count(i => char.ToLower(i) == c);
                if (count > 0)
                {
                    Console.Write($"{c} [{count}] ");
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }

            // 4
            //string program = @"
            //using System;

            //namespace test
            //{
            //    internal class Program
            //    {
            //        static void Main(string[] args)
            //        {
            //            Console.WriteLine(""Even numbers: "");
            //            for (int i = 0; i <= 20; i++)
            //            {
            //                if (i % 2 == 0)
            //                {
            //                    Console.Write(i + ""\t"");
            //                }
            //            }
            //        }
            //    }
            //}";

            //string[] words = { "using", "System", "while","namespace", "internal",
            //    "class", "static", "void", "string", "Console", "WriteLine", "for", 
            //    "int", "if", "Write", "Main" };
            //string[] splited = program.Split(new[]{ '.', ',', '\n', '\t', '(', ')', '{', '}', ';' });

            //int[] count = new int[words.Length];
            //for (int i = 0; i < words.Length; i++)
            //{
            //    count[i] = splited.Count(s => s == words[i]);
            //}

            //Array.Sort(count, words);

            //for (int i = 0; i < words.Length; i++)
            //{
            //    if (count[i] > 0)
            //    {
            //        Console.WriteLine($"{words[i]}: {count[i]}");
            //    }
            //}



        }
        static void fillJArray(int[][] arr, int begin, int end)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(begin, end + 1);
                }
            }
        }
        static void printJArray(int[][] arr, string text = "")
        {
            Console.WriteLine(text);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j],-8}");
                }
                Console.WriteLine();
            }
        }
        static int[][] createJArray(int row, int col)
        {
            int[][] arr = new int[row][];
            for (int i = 0; i < row; i++)
            {
                arr[i] = new int[col++];
            }
            return arr;
        }
        static void Up(int[][] arr, int count)
        {
            for (int j = 0; j < count; j++)
            {
                var tmp = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = tmp;
            }
        }

        static void Down(int[][] arr, int count)
        {
            for (int j = 0; j < count; j++)
            {
                var tmp = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[0] = tmp;
            }
        }
        static void addRow(ref int[][] matrix, int[] newRow)
        {
            Array.Resize(ref matrix, matrix.Length + 1);
            matrix[matrix.Length - 1] = newRow;

        }

        static void delRowByIndex(int[][] matrix, int index)
        {
            if (index >= 0 && index < matrix.Length)
            {
                int[][] tmp = new int[matrix.Length - 1][];
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (i < index)
                    {
                        tmp[i] = matrix[i];
                    }
                    else
                    {
                        tmp[i] = matrix[i + 1];
                    }
                }
                matrix = tmp;
            }

        }

        static int[][] findMinMax(int[][] arr)
        {
            int min = arr[0].Min();
            int max = arr[0].Max();
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i].Min())
                {
                    min = arr[i].Min();
                }
                if (max < arr[i].Max())
                {
                    max = arr[i].Max();
                }
            }
            int[][] res = new int[2][];
            res[0] = new int[] { min };
            res[1] = new int[] { max };

            return res;
        }
        static string removeSymbol(string line, params char[] letters)
        {
            foreach (char c in letters)
            {
                line = line.Replace(c.ToString(), "");
            }
            return line;
        }
    }
}

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
            // Mult/Jagged ARRAYS
            Console.WriteLine("\t\tMult/Jagged ARRAYS");
            int[][] arr = createJArray(4, 3);
            fillJArray(arr, 1, 30);
            printJArray(arr);

            int[] newRow = new int[3];
            addRow(ref arr, newRow);
            printJArray(arr, "\nArray after adding the row to the end: ");

            Up(arr, 3);
            printJArray(arr, "\nAfter shifting matrix rows UP");

            Down(arr, 3);
            printJArray(arr, "\nAfter shifting matrix rows DOWN");

            int index = 4;
            delRowByIndex(ref arr, index);
            printJArray(arr, $"\nArray after deleting the row by index [{index}] : ");

            // METHODS
            Console.WriteLine("\n\t\tMETHODS\nA method for finding the MIN and MAX in a jagged array ");
            int min = 0;
            int max = 0;
            findMinMax(arr, ref min, ref max);
            Console.WriteLine("Min: " + min + "\nMax: " + max);
            Console.WriteLine();

            int[][] arr2 = create3DArray(3, 4);
            fill3DArray(arr2);
            print3DArray(arr2, "Filled 3D array:");
            Console.WriteLine("\nThe sum of the elements of each subarray :");
            Sum(arr2);

            // STRINGS
            // 1
            Console.Write("\n\t\tSTRINGS\nEnter some text: ");
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
            Console.WriteLine($"Initial line: {text}");
            text = removeSymbol(text, 't');
            Console.WriteLine($"Line after removing the specified characters: \n\t{text}");
            Console.WriteLine();
            // 3
            string str = "I don’t know whether to delete this or rewrite it";
            Console.WriteLine("TEXT: " + str);
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
            string program = @"
            using System;

            namespace test
            {
                internal class Program
                {
                    static void Main(string[] args)
                    {
                        Console.WriteLine(""Even numbers: "");
                        for (int i = 0; i <= 20; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write(i + ""\t"");
                            }
                        }
                    }
                }
            }";

            string[] words = { "using", "System", "while","namespace", "internal",
                "class", "static", "void", "string", "Console", "WriteLine", "for",
                "int", "if", "Write", "Main" };
            string[] splitted = program.Split(' ', '.', ',', '\n', '\t', '(', ')', '{', '}', ';');

            Array.Sort(words);
            foreach (var word in words)
            {
                int count = splitted.Count(s => s == word);
                Console.WriteLine($"{word}: {count} times");
            }

            

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
        static void delRowByIndex(ref int[][] matrix, int index)
        {
            if (index >= 0 && index < matrix.Length)
            {
                int[][] tmp = new int[matrix.Length - 1][];
                for (int i = 0; i < tmp.Length; i++)
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
        //
        static void findMinMax(int[][] arr, ref int min, ref int max)
        {
            min = arr[0][0];
            max = arr[0][0];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] < min)
                    {
                        min = arr[i][j];
                    }
                    if (arr[i][j] > max)
                    {
                        max = arr[i][j];
                    }
                }
            }
        }
        static int[][] create3DArray(int row, int col)
        {
            int[][] arr = new int[row][];
            for (int i = 0; i < row; i++)
            {
                arr[i] = new int[col];
            }
            return arr;
        }
        static void fill3DArray(int[][] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = random.Next(1, 50);
                }
            }
        }
        static void print3DArray(int[][] arr, string text)
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
        static void Sum(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Sum in row {i + 1}: {arr[i].Sum()}");
            }
        }
        //
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

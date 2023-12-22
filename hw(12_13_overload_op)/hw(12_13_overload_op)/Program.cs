using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_12_13_overload_op_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter ROWS for the first matrix: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter COLS for the first matrix: ");
            int cols = int.Parse(Console.ReadLine());

            Matrix m1 = new Matrix(rows, cols);
            Console.WriteLine("\n\tInput the first matrix ");
            m1.inputMatrix();
            Console.WriteLine("MATRIX 1:");
            m1.printMatrix();

            // second matrix
            Console.Write("\nEnter ROWS for the second matrix: ");
            int rows2 = int.Parse(Console.ReadLine());
            Console.Write("Enter COLS for the second matrix: ");
            int cols2 = int.Parse(Console.ReadLine());

            Matrix m2 = new Matrix(rows2, cols2);
            Console.WriteLine("\n\tInput the second matrix");
            m2.inputMatrix();
            Console.WriteLine("MATRIX 2:");
            m2.printMatrix();
            
            Console.WriteLine();
            Console.WriteLine($"\nMIN in m1: {m1.min(), -5} MAX in m1: {m1.max()}");
            Console.WriteLine($"MIN in m2: {m2.min(), -5} MAX in m2: {m2.max()}");

            Matrix sum = m1 + m2;
            Console.WriteLine($"\n>>> m1 + m2");
            sum.printMatrix();

            Matrix difference = m2 - m1;
            Console.WriteLine($"\n>>> m2 - m1");
            difference.printMatrix();

            Matrix mult = m1 * m2;
            Console.WriteLine($"\n>>> m1 * m2");
            mult.printMatrix();

            int n = 2;
            Matrix multNum = m1 * n;
            Console.WriteLine($"\n>>> m1 * by {n}");
            multNum.printMatrix();

            bool equal = m1 == m2;
            Console.WriteLine($"\nm1 == m2 : {equal}");
            
            bool dif = m1 != m2;
            Console.WriteLine($"\nm1 != m2 : {dif}");
            Console.WriteLine();

        }
    }
}

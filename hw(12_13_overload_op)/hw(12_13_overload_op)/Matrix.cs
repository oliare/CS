using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_12_13_overload_op_
{
    internal class Matrix
    {
        private int[,] matrix;
        public int rows { get; set; }
        public int cols { get; set; }
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new int[rows, cols];
        }
        public Matrix(int[,] size)
        {
            matrix = size;
        }
        public void inputMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Enter [{i}][{j}]: ");
                    if (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("error input value");
                    }
                }
                Console.WriteLine();
            }
        }
        public void printMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }
        public int this[int r, int c]
        {
            get => matrix[r, c];
            set => matrix[r, c] = value;
        }
        public int min()
        {
            int min = matrix[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            return min;
        }
        public int max()
        {
            int max = matrix[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }
   
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.rows, m1.cols);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.cols; j++)
                {
                    res[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return res;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(m1.rows, m1.cols);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.cols; j++)
                {
                    res[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return res;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.cols != m2.rows)
            {
                throw new Exception("! the sizes of the matrices are different");
            }

            Matrix res = new Matrix(m1.rows, m2.cols);
            int calc = 0;
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m2.cols; j++)
                {
                    for (int k = 0; k < m1.cols; k++)
                    {
                        calc += m1.matrix[i, k] * m2.matrix[k, j];
                    }
                    res.matrix[i, j] = calc;
                }
            }
            return res;
        }
        public static Matrix operator *(Matrix m1, int value)
        {
            Matrix res = new Matrix(m1.rows, m1.cols);
            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.cols; j++)
                {
                    res[i, j] = m1[i, j] * value;
                }
            }
            return res;
        }
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (m1.rows != m2.rows || m1.cols != m2.cols)
            {
                return false;
            }

            for (int i = 0; i < m1.rows; i++)
            {
                for (int j = 0; j < m1.cols; j++)
                {
                    if (m1[i, j] != m2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }
        public override bool Equals(object obj)
        {
            Matrix matrix = obj as Matrix;
            if (obj == null)
            {
                return false;
            }
            return this == matrix;
        }

    }
}

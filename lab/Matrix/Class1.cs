using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array2D
{
    public class Matrix
    {
        private int[,] _data;

        public int Rows { get; }
        public int Columns { get; }

        // Конструктор, который принимает двухмерный массив
        public Matrix(int[,] data)
        {
            Rows = data.GetLength(0);
            Columns = data.GetLength(1);
            _data = data;
        }

        // Индексатор для доступа к элементам массива
        public int this[int i, int j]
        {
            get => _data[i, j];
            set => _data[i, j] = value;
        }

        // Оператор сложения для двух Matrix
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new ArgumentException("Размеры матриц не совпадают");
            }

            int[,] result = new int[a.Rows, a.Columns];
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return new Matrix(result);
        }

        // Оператор вычитания для двух Matrix
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new ArgumentException("Размеры матриц не совпадают");
            }

            int[,] result = new int[a.Rows, a.Columns];
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы.");
            }

            int[,] result = new int[a.Rows, b.Columns];

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    for (int k = 0; k < a.Columns; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return new Matrix(result);
        }

        // Метод для вывода матрицы
        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(_data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

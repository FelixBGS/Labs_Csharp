using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using array2D;

namespace lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            startConsoleApp(getMatrix(1), getMatrix(2));
        }

        static Matrix getMatrix(int number)
        {
            Console.WriteLine($"Введите количество строк матрицы {number}");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите количество столбцов матрицы {number}");
            int cols = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine($"Введите элемент [{i}, {j}] = ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            return new Matrix(matrix);
        }

        static void startConsoleApp(Matrix matrix1, Matrix matrix2)
        {
            bool isEnd = false;
            while (!isEnd)
            {
                Console.WriteLine("Меню".PadRight(28, ' ').PadLeft(60, ' '));
                Console.WriteLine("1. Умножить матрицы");
                Console.WriteLine("2. Сложить матрицы");
                Console.WriteLine("3. Вычесть матрицы");
                Console.WriteLine("0. Закончить работу");
                int answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        {
                            (matrix1 * matrix2).Print();
                            break;
                        }
                    case 2:
                        {
                            (matrix1 + matrix2).Print();
                            break;
                        }
                    case 3:
                        {
                            (matrix1 - matrix2).Print();
                            break;
                        }
                    case 0:
                        {
                            isEnd = true;
                            break;
                        }
                }
            }
        }
    }
}

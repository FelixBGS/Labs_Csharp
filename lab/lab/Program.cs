using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figure;

namespace lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            startConsoleApp(getTriangle());
        }

        static Triangle getTriangle()
        {
            Console.WriteLine("Введите X1 вершины");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Y1 вершины");
            int y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите X2 вершины");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Y2 вершины");
            int y2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите X3 вершины");
            int x3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Y3 вершины");
            int y3 = Convert.ToInt32(Console.ReadLine());

            Triangle triangle;

            try
            {
                triangle = new Triangle(x1, y1, x2, y2, x3, y3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Точки фигуры не соотвествуют треугольнику.");
                return getTriangle();
            }

            return triangle; 
        }
        
        static void startConsoleApp(Triangle triangle)
        {
            bool isEnd = false;
            while (!isEnd)
            {
                Console.WriteLine("Меню".PadRight(28, ' ').PadLeft(60, ' '));
                Console.WriteLine("1. Вычисилить длину стороны AB");
                Console.WriteLine("2. Вычислить длину стороны BC");
                Console.WriteLine("3. Вычислить длину стороны AC");
                Console.WriteLine("4. Вычислить площадь треугольника");
                Console.WriteLine("5. Вычислить периметр треугольника");
                Console.WriteLine("6. Проверить заданная точка находится внутри треугольника");
                Console.WriteLine("7. Проверить заданная точка находится вне треугольника");
                Console.WriteLine("8. Проверить заданная точка находится на границе треугольника");
                Console.WriteLine("9. Задать новый треугольник");
                Console.WriteLine("10. Закончить работу");
                int answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        {
                            Console.WriteLine("Сторона AB = " + triangle.AB);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Сторона ВС = " + triangle.BC);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Сторона AC = " + triangle.AC);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Площадь треугольника = " + triangle.getS());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"Периметр треугольника = {triangle.getPerimeter()}");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Введите точку x");
                            int x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите точку y");
                            int y = Convert.ToInt32(Console.ReadLine());
                            if (triangle.isPointInside(x, y))
                            {
                                Console.WriteLine("Точка находится внутри треугольника");
                            }
                            else
                            {
                                Console.WriteLine("Точка находится вне треугольника или на его границе");
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Введите точку x");
                            int x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите точку y");
                            int y = Convert.ToInt32(Console.ReadLine());
                            if (triangle.isPountOutside(x, y))
                            {
                                Console.WriteLine("Точка находится вне треугольника");
                            }
                            else
                            {
                                Console.WriteLine("Точка находится внутри треугольника или на его границе");
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Введите точку x");
                            int x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите точку y");
                            int y = Convert.ToInt32(Console.ReadLine());
                            if (triangle.isPountBoundary(x, y))
                            {
                                Console.WriteLine("Точка находится на границе треугольника");
                            }
                            else
                            {
                                Console.WriteLine("Точка находится внутри треугольника или вне его");
                            }
                            break;
                        }
                    case 9:
                        {
                            isEnd = true;
                            startConsoleApp(getTriangle());
                            break;
                        }
                    case 10:
                        {
                            isEnd = true;
                            break;
                        }
                }
            }
        }
    }
}


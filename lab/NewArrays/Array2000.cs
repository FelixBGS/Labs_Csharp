using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewArrays
{
    public class Array2000
    {
        private int[] array;
        public int arrayLength { get => array.Length; }

        public int this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }

        public Array2000(int[] array)
        {
            this.array = array;
        }

        static public Array2000 GetArray()
        {
            Console.WriteLine("Введите количество элементов массива: ");
            int userArrayLength = Convert.ToInt32(Console.ReadLine());
            int[] userArray = new int[userArrayLength];

            for (int i = 0; i < userArrayLength; i++)
            {
                Console.WriteLine($"Введите {i} элемент массива =");
                userArray.Append(Convert.ToInt32(Console.ReadLine()));
            }

            return new Array2000(userArray);
        }

        public override string ToString()
        {
            string numbers = "";
            foreach (int num in array)
            {
                numbers += " " + num;
            }
            return "[" + numbers + "]";
        }

        public int MaxElement(int start, int end)
        {
            int maxElement = array[start];
            for (int i = start + 1; start < end; start++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }
            return maxElement;
        }
        
        public int MaxElement()
        {
            int maxElement = array[0];
            for (int i = 1; i < arrayLength; i++)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
            }
            return maxElement;
        }

        public int MinElement(int start, int end)
        {
            int minElement = array[start];
            for (int i = start + 1; start < end; start++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }
            return minElement;
        }

        public int MinElement()
        {
            int minElement = array[0];
            for (int i = 1; i < arrayLength; i++)
            {
                if (minElement > array[i])
                {
                    minElement = array[i];
                }
            }
            return minElement;
        }

        public static Array2000 operator *(Array2000 a, Array2000 b)
        {
            if (a.arrayLength != b.arrayLength)
            {
                throw new ArgumentException("Массивы не одинакого размера");
            }

            int[] result = new int[a.arrayLength];

            for (int i = 0;  i < a.arrayLength; i++)
            {
                result.Append(a.array[i] * b.array[i]);
            }

            return new Array2000(result);
        }

        public static bool operator >(Array2000 a, Array2000 b)
        {
            if (a.arrayLength > b.arrayLength)
            {
                return true;
            } else if (a.arrayLength < b.arrayLength)
            {
                return false;
            } else
            {
                int countPositiveA = a.array.Count(n =>  n > 0);
                int countPositiveB = b.array.Count(n => n > 0);
                if (countPositiveA > countPositiveB)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public static bool operator <(Array2000 a, Array2000 b)
        {
            if (a.arrayLength < b.arrayLength)
            {
                return true;
            }
            else if (a.arrayLength > b.arrayLength)
            {
                return false;
            }
            else
            {
                int countPositiveA = a.array.Count(n => n > 0);
                int countPositiveB = b.array.Count(n => n > 0);
                if (countPositiveA < countPositiveB)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Triangle
    {
        int x1, x2, x3;
        int y1, y2, y3;

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            if (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2) == 0)
            {
                throw new ArgumentException("Треугольник из этих точек невозможно образовать.");
            }
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        private double calculateDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double AB => calculateDistance(x1, y1, x2, y2);
        public double AC => calculateDistance(x1, y1, x3, y3);
        public double BC => calculateDistance(x2, y2, x3, y3);

        public double getPerimeter()
        {
            return AB + AC + BC;
        }

        public double getS()
        {
            double s = (AB + AC + BC) / 2;
            return Math.Sqrt(s * (s - AB) * (s - AC) * (s - BC));
        }

        private double getD(int x, int y, int x1, int y1, int x2, int y2)
        {
            return (x - x1) * (y2 - y1) - (y - y1) * (x2 - x1);
        }

        public bool isPointInside(int x, int y)
        {
            double D1 = getD(x, y, x1, y1, x2, y2);
            double D2 = getD(x, y, x2, y2, x3, y3);
            double D3 = getD(x, y, x3, y3, x1, y1);

            if (D1 > 0 && D2 > 0 && D3 > 0 || D1 < 0 && D2 < 0 && D3 < 0)
                return true;
            else
                return false;
        }

        public bool isPountBoundary(int x, int y)
        {
            double D1 = getD(x, y, x1, y1, x2, y2);
            double D2 = getD(x, y, x2, y2, x3, y3);
            double D3 = getD(x, y, x3, y3, x1, y1);

            if (D1 == 0 || D2 == 0 || D3 == 0)
                return true;
            else 
                return false;
        }

        public bool isPountOutside(int x, int y)
        {
            return !isPointInside(x, y);
        }
    }
}

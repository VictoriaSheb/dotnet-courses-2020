using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class TriangleService
    {
        public Triangle triangle;

        public void AddNewTriangle(double a, double b, double c) 
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentException("Значения сторон треугольника не могут быть меньше нуля");
            }
            else
            {
                if (!(a < (b + c) && b < (a + c) && c < (a + b)))
                {
                    throw new Exception("Треугольник с такими сторонами не существует");
                }
                else 
                {
                    triangle = new Triangle(a, b, c);
                }
            } 

        }
    }
}

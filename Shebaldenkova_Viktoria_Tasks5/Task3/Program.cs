using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(5, 8, 3);
            Console.WriteLine("Периметр треугольника: " + triangle.GetPTriangle());
            Console.WriteLine("Площадь треугольника: " + triangle.GetSTriangle());
            triangle.sideA = 5;
            triangle.sideB = 4;
            triangle.sideC = 3;
            Console.WriteLine("Замена. Сторона b равна: " + triangle.sideB);
            Console.WriteLine("Периметр треугольника: " + triangle.GetPTriangle());
            Console.WriteLine("Площадь треугольника: " + triangle.GetSTriangle());
            Console.ReadLine();
        }
    }
}

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
            TriangleService triangleService = new TriangleService();
            //triangleService.AddNewTriangle(5, 8, 3);
            //Triangle triangle1 = triangleService.triangle;
            //Console.WriteLine("Периметр треугольника: " + triangle1.GetPerimeterTriangle());
            //Console.WriteLine("Площадь треугольника: " + triangle1.GetAreaTriangle());
            triangleService.AddNewTriangle(5, 4, 3);
            Triangle triangle2 = triangleService.triangle;
            Console.WriteLine("Периметр треугольника: " + triangle2.GetPerimeterTriangle());
            Console.WriteLine("Площадь треугольника: " + triangle2.GetAreaTriangle());
            Console.ReadLine();
        }
    }
}

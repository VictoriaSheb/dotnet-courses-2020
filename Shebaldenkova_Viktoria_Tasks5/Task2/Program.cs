using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round1 = new Round(0, 0, 5);
            Console.WriteLine("Длина окружности1: "+round1.Length);
            Console.WriteLine("Площадь окружности1: " + round1.Area);
            Console.WriteLine();
            Round round2 = new Round(0, 0, 3);
            Console.WriteLine("Длина окружности2: " + round2.Length);
            Console.WriteLine("Площадь окружности2: " + round2.Area);
            Console.WriteLine();
            Ring ring = new Ring(0, 0, 5, 3);
            Console.WriteLine("Длина кольца: " + ring.Length);
            Console.WriteLine("Площадь кольца: " + ring.Area);
            Console.ReadLine();

        }
    }
}

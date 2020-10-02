using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round(0,0,5);
            Console.WriteLine("Длина окружности: "+round.CRound);
            Console.WriteLine("Площадь окружности: " + round.SRound);
            round.radius = 22;
            Console.WriteLine("Замена. Радиус равен: " + round.radius);
            Console.WriteLine("Длина окружности: " + round.CRound);
            Console.WriteLine("Площадь окружности: " + round.SRound);
            Console.ReadLine();

        }
    }
}

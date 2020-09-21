using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N - число для формирования рисунка№2, треугольника из N строк:");
            Picture picture = new Picture();
            picture.Input();
        }
    }
}

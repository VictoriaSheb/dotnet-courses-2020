using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N - число для формирования рисунка№3 из N треугольников:");
            Picture picture = new Picture();
            picture.Input();
        }
    }
}

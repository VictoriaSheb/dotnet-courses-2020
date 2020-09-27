using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N - число для формирования рисунка№1:");
            Picture picture = new Picture();
            bool status = picture.Input();
            if (status==true)
                picture.Painting();
        }
    }
}

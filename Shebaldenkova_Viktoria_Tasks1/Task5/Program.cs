using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод на экран суммы всех чисел <1000 кратных 3 или 5");
            int Sum = 0;
            for (int i=1;i<1000;i++) 
            {
                if (i % 3 == 0 || i % 5 == 0)
                    Sum += i;
            }
            Console.WriteLine("Sum={0}",Sum);
            Console.ReadLine();

        }

        
    }
}

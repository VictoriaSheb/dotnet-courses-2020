using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cравнительный анализ скорости работы классов String и StringBuilder для операции сложения");
            Console.WriteLine();
            Console.WriteLine("{0,-20}{1,-20}{2,-20}"," ", "Время выполнения", "Время выполнения");
            Console.WriteLine("{0,-20}{1,-20}{2,-20}", "Класс", "в миллисекундах", "в тиках: ");
            Console.WriteLine();
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 200000;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            watch.Stop();//
            Console.WriteLine("{0,-20}{1,-20}{2,-20}", "String", watch.ElapsedMilliseconds , watch.ElapsedTicks);//
            watch.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            watch.Stop();
            Console.WriteLine("{0,-20}{1,-20}{2,-20}", "StringBuilder", watch.ElapsedMilliseconds, watch.ElapsedTicks);//
            Console.ReadLine();
        }
    }
}

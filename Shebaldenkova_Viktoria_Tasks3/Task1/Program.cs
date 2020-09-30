using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для подсчета средней длинны слова в ней");
            string line =Console.ReadLine();
            bool statusPreviousSymbol=default;
            double sumLetters = default;
            int words = default;
            foreach (char symbol in line) 
            {
                if (symbol == ('.') || symbol == (',') || symbol == (';') || symbol == (':') || symbol == ('-') || symbol == ('\"') || symbol == ('\'') || symbol == (' ') || symbol == ('!') || symbol == ('?'))
                {
                    if (statusPreviousSymbol==true)
                    {
                        words++;
                    }
                    statusPreviousSymbol = false;
                }
                else
                {
                    sumLetters++;
                    statusPreviousSymbol = true;
                }
            }
            Console.WriteLine("Длинна среднего слова="+(sumLetters/words));
            Console.WriteLine("Символы: "+sumLetters);
            Console.WriteLine("Слова: "+words);
            Console.ReadLine();
        }
    }
}

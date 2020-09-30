using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Пример: В 7:55 я встал, позавтракал и к 10:77 пошел на работу.
            Console.WriteLine("Введите текст для определения количества упоминаний времени:");
            string line = Console.ReadLine();
            string pattern = @"(?:(?:[0-2][0-3])|(?: [\d])):[0-5]\d ";
            Console.WriteLine("Время в тексте присутствует "+ Regex.Matches(line,pattern).Count + " раз");
            Console.ReadLine();
        }
    }
}

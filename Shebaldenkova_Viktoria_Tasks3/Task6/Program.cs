using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            string number = Console.ReadLine();
            string patternScientific = @"(-?[\d.]+e-?\d+)";
            string patternUsual = @"-?\d+(?:[.]?\d+)?";
            if (Regex.Match(number, patternScientific).Success)
                Console.WriteLine("Это число в научной нотации:" + Regex.Match(number, patternScientific).Value);
            else
            if (Regex.Match(number, patternUsual).Success)
                Console.WriteLine("Это число в обычной нотации: " + Regex.Match(number, patternUsual).Value);
            else
                Console.WriteLine("Это не число");

            Console.ReadLine();
        }
    }
}

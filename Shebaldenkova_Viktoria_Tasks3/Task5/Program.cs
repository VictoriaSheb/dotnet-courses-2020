using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "(<.+?>)";
            string line = "<b>Это</b> текст <i>с</i> <font color=”red”>HTML</font> кодами ";
            Console.WriteLine("Исходный текст: "+line);
            Console.WriteLine("После замены: "+Regex.Replace(line, pattern, "_"));
            Console.ReadLine();
        }
    }
}

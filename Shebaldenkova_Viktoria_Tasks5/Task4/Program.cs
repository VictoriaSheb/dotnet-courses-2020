using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString line1 = new MyString("0123456789");
            MyString line2 = new MyString("9999");
            Console.WriteLine("Сумма строк: "+ line1 +" + "+ line2 +" = "+ (line1+line2));
            MyString line3 = null;
            if (line1 == null) { }
            //Console.WriteLine("Разность строк: " + line1 + " - " + line3 + " = " + (line1 - line3));
            //Console.WriteLine("Разность строк: " + line1 + " - " + line2 + " = " + (line1 - line2));
            MyString line4 = null;
            Console.WriteLine("Сравнение строк: " + line4 + " == " + line3 + " => " + (line4==line3));
            Console.WriteLine("Сравнение строк: " + line1 + " == " + line2 + " => " + (line1 == line2));
            string str = line1.ToString();
            Console.WriteLine("ToString() результат: " + str);
            Console.ReadLine();
        }
    }
}

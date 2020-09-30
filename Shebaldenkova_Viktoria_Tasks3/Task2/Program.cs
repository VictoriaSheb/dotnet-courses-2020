using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку: ");
          //  string lineToChange = Console.ReadLine();
            string lineToChange =  "написать программу, которая";
            Console.WriteLine("Введите вторую строку: ");
        //    string lineToRepeat = Console.ReadLine();
            string lineToRepeat = "описание";
            StringBuilder lineResult = new StringBuilder();
            foreach (char symbol in lineToChange) 
            {
                lineResult.Append(symbol);
                foreach (char symbolRepeated in lineToRepeat) 
                {
                    if (symbolRepeated == symbol) 
                    {
                        lineResult.Append(symbol);
                        break;
                    }
                }
            }
            Console.WriteLine(lineResult);
            Console.ReadLine();
        }
    }
}

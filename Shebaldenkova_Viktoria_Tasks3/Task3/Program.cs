using System;
using System.Globalization;
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод на экран различий параметров культур:");
            OutputOfCulturalDifferences("ru","en");
            OutputOfCulturalDifferences("ru", "af");
            OutputOfCulturalDifferences("en", "ja");
            Console.ReadLine();

            void OutputOfCulturalDifferences(string culture1, string culture2) 
            {
                CultureInfo cultureFirst = new CultureInfo(culture1);
                CultureInfo cultureSecond = new CultureInfo(culture2);
                Console.WriteLine();
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", " ", cultureFirst.EnglishName, cultureSecond.EnglishName);
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", "Формат даты", cultureFirst.DateTimeFormat.ShortDatePattern, cultureSecond.DateTimeFormat.ShortDatePattern);
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", "Формат времени", cultureFirst.DateTimeFormat.LongTimePattern, cultureSecond.DateTimeFormat.LongTimePattern);
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", "Разделитель чисел", cultureFirst.NumberFormat.NumberDecimalSeparator, cultureSecond.NumberFormat.NumberDecimalSeparator);
            }
             
        }
    }
}

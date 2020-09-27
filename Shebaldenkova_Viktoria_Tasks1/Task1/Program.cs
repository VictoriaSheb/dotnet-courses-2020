using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidationFigureSide side = new ValidationFigureSide();
            int a;
            int b;
            Console.WriteLine("Данная программа считает площадь прямоугольника со сторонами a и b.");
            if (side.CheckInput(a = side.Input("a")) == false)
                Console.WriteLine("Eror");
            else
                if (side.CheckInput(b = side.Input("b")) == false)
                Console.WriteLine("Eror");
            else
                Console.WriteLine("Result: S={0}",(a*b)) ;
            Console.ReadLine();
        }
    }
}

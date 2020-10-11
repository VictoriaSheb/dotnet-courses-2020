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
            List<Figure> figures = new List<Figure>();
            figures.Add(new Line(0, 0, 1, 1));
            figures.Add(new Round(0, 0, 4, 2));
            figures.Add(new Circle(0, 0, 4, 2));
            figures.Add(new Ring(0, 0, 4, 2));
            foreach(var figure in figures)
            {
                figure.Draw();
            }
            Console.ReadLine();
        }


    }
    
}

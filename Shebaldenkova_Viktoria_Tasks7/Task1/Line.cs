using System;

namespace Task1
{
    class Line : Figure
    {
        public Line(int xStart, int yStart, int xEnd, int yEnd): base(xStart, yStart,  xEnd, yEnd)
        { }

        public override void Draw()
        {
            Console.Write("Линия: длина - " + (Math.Pow(XValue, 2)+ Math.Pow(YValue, 2)));
            Console.WriteLine("; координаты - ({0},{1});({2},{3})",X[0],Y[0],X[1],Y[1]);
        }



    }
}

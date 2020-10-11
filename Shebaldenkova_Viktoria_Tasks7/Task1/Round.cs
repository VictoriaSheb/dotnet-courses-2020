using System;

namespace Task1
{
    class Round : Circle
    {
        public virtual double Area
        {
            get
            {
                return Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
            }
        }
        public Round(int xStart, int yStart, int xEnd, int yEnd) : base(xStart, yStart, xEnd, yEnd)
        {
        }

        public override void Draw()
        {
            Console.Write("Круг: радиус - {0}, площадь - {1}, длина - {2}",Radius,Area, Length);
            Console.WriteLine("; координаты центра - ({0},{1})", XCenter, YCenter);
        }


    }
}

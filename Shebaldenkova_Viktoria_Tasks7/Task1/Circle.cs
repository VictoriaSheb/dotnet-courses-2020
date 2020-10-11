using System;

namespace Task1
{
    class Circle : Figure
    {
        public double XCenter { get; }
        public double YCenter { get; }
        public double Radius { protected set; get; }

        public virtual double Length
        {
            get
            {
                return Math.Round(2 * Math.PI * Radius, 2);
            }
        }

        public Circle(int xStart, int yStart, int xEnd, int yEnd) : base(xStart, yStart, xEnd, yEnd)
        {
            Radius = MinValue(XValue, YValue) / 2;
            XCenter = X[0] + Radius;
            YCenter = Y[0] + Radius;
        }

        protected int MinValue(int value1, int value2)
        {
            return (value1 < value2) ? value1 : value2;
        }

        public override void Draw()
        {
            Console.Write("Окружность: радиус - {0}, длина - {1}", Radius, Length);
            Console.WriteLine("; координаты центра - ({0},{1})", XCenter, YCenter);
        }


    }
}

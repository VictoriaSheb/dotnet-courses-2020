using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Ring : Round
    {
        Round RoundExternal;
        public override double Area
        {
            get
            {
                return RoundExternal.Area - base.Area;
            }
        }
        public override double Length
        {
            get
            {
                return RoundExternal.Length + base.Length;
            }
        }


        public Ring(int xStart, int yStart, int xEnd, int yEnd) : base(xStart, yStart, xEnd, yEnd)
        {
            RoundExternal = new Round(xStart, yStart, xEnd, yEnd);
            Radius *= 0.9;
        }

        public override void Draw()
        {
            Console.Write("Кольцо: радиус внешний - {0}, радиус внутренний - {1} , площадь - {2}, длина - {3}", RoundExternal.Radius, Radius, Area, Length);
            Console.WriteLine("; координаты центра - ({0},{1})", XCenter, YCenter);
        }



    }
}

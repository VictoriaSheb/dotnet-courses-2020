using System;
namespace Task2
{
    class Round
    {
        public double x { get; }
        public double y { get; }
        public double radius { get; }

        public double AreaRound 
        {
            get 
            {
                return Math.Round(Math.PI * Math.Pow(radius, 2),2);
            }
        }

        public double LengthRound
        {
            get
            {
                return Math.Round(2 *Math.PI *radius,2);
            }
        }

        public Round(double x, double y, double radius) 
        {
            this.radius = radius;
            this.x = x;
            this.y = y;
        }

    }
}

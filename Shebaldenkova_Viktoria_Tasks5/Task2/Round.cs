using System;
namespace Task2
{
    class Round
    {
        public double x { set; get; }
        public double y { set; get; }
        public double radius { get; set; }

        public double SRound 
        {
            get 
            {
                return Math.Round(Math.PI * Math.Pow(radius, 2),2);
            }
        }

        public double CRound
        {
            get
            {
                return Math.Round(2 *Math.PI *radius,2);
            }
        }

        public Round(double x, double y, double radius) 
        {
            if (radius < 0)
                radius = Math.Abs(radius);
            this.radius = radius;
            this.x = x;
            this.y = y;
        }

    }
}

using System;
namespace Task2
{
    class Round
    {
        public double X { get; }
        public double Y { get; }
        public double Radius { protected set;  get; }



        public virtual double Area
        {
            get 
            {
                return Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
            }
        }

        public virtual double Length
        {
            get
            {
                return Math.Round(2 *Math.PI *Radius,2);
            }
        }

        public Round(double x, double y, double radius) 
        {
            Radius = CheckRadius(radius);
            X = x;
            Y = y;
        }


        protected Round(double x, double y)
        {
            X = x;
            Y = y;
        }

        protected double CheckRadius(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Значение не может быть меньше нуля", $"{nameof(radius)}");
            }
            else
            {
                return radius;
            }
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Triangle
    {
        public double sideA { get; }
        public double sideB { get; }
        public double sideC { get; }

        public Triangle(double a, double b, double c) 
        {
            this.sideA = a;
            this.sideB = b;
            this.sideC = c;
        }

        public double GetPerimeterTriangle() 
        {
            return sideA + sideB + sideC;
        }

        public double GetAreaTriangle()
        {
            double p = GetPerimeterTriangle() / 2;
            return Math.Round(Math.Sqrt(p*(p-sideA) * (p - sideB) * (p - sideC)),2);
        }

    }
}

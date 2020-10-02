using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Triangle
    {
        public double sideA { set; get; }
        public double sideB { set; get; }
        public double sideC { set; get; }

        public Triangle(double a, double b, double c) 
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);
            if (!(a<(b +c) && b<(a+c) && c<(a+b))) 
            {
                Console.WriteLine("Такое соотношение сторон не возможно");
                this.sideA = 0;
                this.sideB = 0;
                this.sideC = 0;
            }
            else 
            {
                this.sideA = a;
                this.sideB = b;
                this.sideC = c;
            }
            
        }

        public double GetPTriangle() 
        {
            return sideA + sideB + sideC;
        }

        public double GetSTriangle()
        {
            double p = GetPTriangle() / 2;
            return Math.Round(Math.Sqrt(p*(p-sideA) * (p - sideB) * (p - sideC)),2);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class RoundService
    {
        public Round round;

        public void AddNewRound(double x, double y, double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Значение не может быть меньше нуля", $"{nameof(radius)}");
            }
            else 
            {
                round = new Round(x, y, radius);
            }
        }


    }
}

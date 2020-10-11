using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Bear : Monster
    {
        public Bear(int xPosition, int yPosition) : base(xPosition, yPosition)
        {
            Strength = 6;
            Health = 4;
            Step = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Wolf : Monster
    {
        public Wolf(int xPosition, int yPosition) : base(xPosition, yPosition)
        { 
            Strength = 3;
            Health = 2;
            Step = 2; 
        }
       
    }
}

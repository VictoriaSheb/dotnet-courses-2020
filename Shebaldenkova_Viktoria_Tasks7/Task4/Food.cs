using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Food
    {
        public int Bonus { get;}
        public bool Status { set; get; }

        public Food(int xPosition, int yPosition)
        {
            Random random = new Random();
            Bonus = random.Next(2);
            Status = true;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    abstract class Figure
    {
        public int[] X { private set; get; }
        public int[] Y { private set; get; }
        public int XValue 
        {
            get 
            {
                return X[1] - X[0];
            }
        }
        public int YValue
        {
            get
            {
                return Y[1] - Y[0];
            }
        }

        public Figure(int xStart, int yStart, int xEnd, int yEnd) 
        {
            X = new int[2];
            Y = new int[2];
            X[0] = xStart;
            X[1] = xEnd;
            Y[0] = yStart;
            Y[1] = yEnd;
        }
        abstract public void Draw();


    }
}

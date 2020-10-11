using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{

    public class Field
    {
        static int Height = 6;
        static int Widht = 6;
        string[,] ThisField = new string[Widht, Height];
        int XCursor;
        int YCursor;
        Monster[] monsters;
        Food[] foods;
        
        
        public Field() 
        {
            //постановка игрока в центр
            //расстановка 2 монстров с учетом места игрока 
            //расстановка бонусов
        }



        

    }
}

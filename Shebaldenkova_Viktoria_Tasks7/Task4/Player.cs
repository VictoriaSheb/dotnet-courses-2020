using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Player : CharacterList
    {
        public Player(int xPosition, int yPosition)
        {
            Strength = 5;
            Health = 10;
            Step = 1;
        }

        public void Eat(Food food) { }
        public void Hit(Obstacle obstacle) { }
        public void ToGo() { }
        public void Attack(Monster monster) { }

    }
}

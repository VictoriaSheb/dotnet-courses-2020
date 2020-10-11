using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    abstract class Monster : CharacterList
    {
        public Monster(int xPosition, int yPosition) { }

        public void ToGo(Player player) { }
        public void ToGo(Player player, Obstacle obstacle) { }
        public void Attack(Player player) { }
    }
}

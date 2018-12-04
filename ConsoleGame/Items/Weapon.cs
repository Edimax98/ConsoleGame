using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Weapon : Item
    {
        public int price
        {
            get
            {
                return 10;
            }
        }

        public Weapon() { }

        public int calculateBuffPoints()
        {
            Random rand = new Random();
            return rand.Next(1, 2);
        }
    }
}

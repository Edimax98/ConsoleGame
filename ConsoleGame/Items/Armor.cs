using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Armor : Item
    {
        public int price
        {
            get
            {
                return 5;
            }
        }

        public int calculateBuffPoints()
        {
            Random rand = new Random();
            return rand.Next(1, 2);
        }
    }
}

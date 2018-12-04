using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Potion : Item
    {
        public int price
        {
            get
            {
                return 3;
            }
        }

        public int calculateBuffPoints()
        {
            return 10;
        }
    }
}

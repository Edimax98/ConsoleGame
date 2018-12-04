using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface PurchaseEventHandler
    {
        void notEnoughMoneyFor(Item item);
        void couldNotBuy(string message);
        void itemWasBought();
    }
}

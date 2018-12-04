using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Medic : FriendlyNPC
    {

        private HashSet<Item> setOfItems;

        public HashSet<Item> items
        {
            get
            {
                return setOfItems;
            }
        }

        public Medic()
        {
            Potion healPotion = new Potion();
            setOfItems.Add(healPotion);
        }

        public string getInfo()
        {
            string info = "";

            foreach(Item item in setOfItems) {
                info = $"{item.GetType()} - {item.price} coin(s) \n";
            }

            return info;
        }
    }
}

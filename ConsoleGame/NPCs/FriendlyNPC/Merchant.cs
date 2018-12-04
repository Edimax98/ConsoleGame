using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Merchant : FriendlyNPC
    {

        private HashSet<Item> setOfItems = new HashSet<Item>();

        public HashSet<Item> items
        {
            get
            {
                return setOfItems;
            }
        }

        public Merchant() {
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            setOfItems.Add(weapon);
            setOfItems.Add(armor);
        }

        public string getInfo()
        {
            string info = "";

            foreach(Item item in setOfItems)
            {
               info += $"{item.GetType()} - {item.price} coin(s) \n";
            }
            return info;
        }
    }
}

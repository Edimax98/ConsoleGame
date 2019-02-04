using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface BattleEventsHandler
    {
        void HeroHasBeenKilled(Hero victim, Hero killer);
        void HeroHasBeenHurt(Hero victim, Hero attackingHero); 
    }
}

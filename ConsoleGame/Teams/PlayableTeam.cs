using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class PlayableTeam : Team, BattleEventsHandler
    {
        public PlayableTeam(string name, List<Hero> heroes): base(name,heroes)
        {
        }

        public void HeroHasBeenHurt(Hero victim, Hero attackingHero)
        {

        }

        public void HeroHasBeenKilled(Hero victim, Hero killer)
        {
            Heroes.Remove(victim);
        }
    }
}

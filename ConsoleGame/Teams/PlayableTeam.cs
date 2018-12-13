using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class PlayableTeam : ITeam, BattleEventsHandler
    {
        private string teamName;
        private List<IHero> heroes;

        public string Name 
        {
            get 
            {
                return teamName;
            }
            set 
            {
                teamName = value;
            }
        }

        public List<IHero> Heroes
        {
            get
            {
                return heroes;
            }
            set
            {
                if (value.Count < 3)
                {
                    //error;
                }
                else
                {
                    heroes = value;
                }
            }
        }

        public void HeroHasBeenHurt(IHero victim, IHero attackingHero)
        {

        }

        public void HeroHasBeenKilled(IHero victim, IHero killer)
        {
            heroes.Remove(victim);
        }
    }
}

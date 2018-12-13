using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ConsoleGame
{
    public class AiTeam : ITeam, BattleEventsHandler
    {
        private readonly string[] names = { "Human destroyers", "the best", "Team that never loses" };
        private string name;
        private List<IHero> heroes;

        public AiTeam()
        {
            name = GenerateRandomTeamName(names);
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
                    //error
                }
                else
                {
                    heroes = value;
                }
            }
        }

        private static string GenerateRandomTeamName(string[] possibleNames)
        {
            Contract.Requires(possibleNames != null);
            Random random = new Random();
            int index = random.Next(0, possibleNames.Length);
            string name = possibleNames[index];
            return name;
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

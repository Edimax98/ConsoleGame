using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ConsoleGame
{
    public class AiTeam : Team, BattleEventsHandler
    {
        private readonly string[] names = { "Human destroyers", "the best", "Team that never loses" };
                
        public AiTeam(string name, List<Hero> heroes): base(name,heroes)
        {
            Name = GenerateRandomTeamName(names);
            Heroes = heroes;
        }

        private static string GenerateRandomTeamName(string[] possibleNames)
        {
            Contract.Requires(possibleNames != null);
            Random random = new Random();
            int index = random.Next(0, possibleNames.Length);
            string name = possibleNames[index];
            return name;
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

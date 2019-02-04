using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
namespace ConsoleGame
{
    public abstract class Team
    {
        public ITeamEventHandler teamEventHandler;
        private const string DefaultName = "Unknown team";
        private const int MinCountOfHeroes = 3;
        public string Name { get; set; }
        public List<Hero> Heroes { get; protected set; }

        protected Team(string name, List<Hero> heroes)
        {
            if (name == "")
            {
                Name = DefaultName;
            }
            else
            {
                Name = name;
            }
            if (Heroes.Count < MinCountOfHeroes) 
            {
                teamEventHandler.NotEnoughHeroesInTeam();
            }
            Heroes = heroes;
        }

        public Hero FindHeroByIndex(int index)
        {
            for (int i = 0; i <= Heroes.Count - 1; i++)
            {
                if (index == i)
                {
                    return Heroes[index];
                }
            }

            throw new HeroNotFoundException();
        }
    }
}

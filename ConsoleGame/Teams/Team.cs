using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
namespace ConsoleGame
{
    public abstract class Team
    {
        public ITeamEventHandler teamEventHandler;
        private const int MinCountOfHeroes = 3;
        public string Name { get; set; }
        public List<Hero> Heroes { get; protected set; }

        protected Team(string name, List<Hero> heroes)
        {
            Contract.Requires(name != "");
            Contract.Requires(heroes.Count >= MinCountOfHeroes);
        }
    }
}

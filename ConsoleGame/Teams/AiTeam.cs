using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ConsoleGame
{
    public class AiTeam : ITeam
    {
        private readonly string[] names = {"Human destroyers", "the best", "Team that never loses"};
        private List<Hero> heroes;

        public string Name 
        {
            get 
            {
                return GenerateRandomTeamName(names);
            }
            set
            { 
            }
        }

        public List<Hero> Heroes
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
                } else 
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
     }
}

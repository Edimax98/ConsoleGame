using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    public class PlayableTeam : ITeam
    {
        private string teamName;
        private List<Hero> heroes;

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
                    //error;
                } else 
                {
                    heroes = value;
                }
            }
        }
    }
}

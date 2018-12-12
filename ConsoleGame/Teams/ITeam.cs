using System;
using System.Collections.Generic;
namespace ConsoleGame
{
    public interface ITeam
    {
        string Name { get; set; }
        List<IHero> Heroes { get; set; }
    }
}

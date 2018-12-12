using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public interface IHero
    {
        int Health { get; set; }
        string Name { get; }
        int BaseDamage { get; }
        int Damage { get; }

        int CalculateDamageBonus();
    }
}

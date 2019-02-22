using System;
namespace ConsoleGame
{
    public interface IEventListener
    {
        void HeroHasBeenKilled(Hero attacker, Hero victim);
        void HeroHasBeenHurt(Hero attacker, Hero victim);
    }
}

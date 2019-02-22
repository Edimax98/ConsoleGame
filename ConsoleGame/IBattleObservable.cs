using System;
namespace ConsoleGame
{
    public interface IBattleObservable
    {
        void Notify(EventType eventType, Hero attacker, Hero victim);
    }
}

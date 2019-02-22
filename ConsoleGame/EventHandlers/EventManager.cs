using System.Linq;
using System.Collections.Generic;
namespace ConsoleGame
{

    public enum EventType: int { heroDead = 0, heroHurt = 1 }

    public class EventManager: IBattleObservable
    {
        private Dictionary<int,HashSet<IEventListener>> listeners  = new Dictionary<int,HashSet<IEventListener>>();

        public void Subscribe(EventType eventType, IEventListener listener) 
        {
            if (listeners.ContainsKey((int)eventType))
            {
                HashSet<IEventListener> set = listeners[(int)eventType];
                set.Add(listener);
            }
            else
            {
                HashSet<IEventListener> set = new HashSet<IEventListener>
                {
                    listener
                };
                listeners.Add((int)eventType, set);
            }
        }

        public void Unsubscribe(EventType eventType, IEventListener listener)
        {
            listeners[(int)eventType].Remove(listener);
        }

        public void Notify(EventType eventType, Hero attacker, Hero victim)
        {
            HashSet<IEventListener> set = listeners[(int)eventType];
            foreach (var listener in set)
            {
                switch (eventType)
                {
                    case EventType.heroDead:
                        listener.HeroHasBeenKilled(attacker, victim); break;
                    case EventType.heroHurt: 
                        listener.HeroHasBeenHurt(attacker, victim); break;
                }
            }
        }
    }
}

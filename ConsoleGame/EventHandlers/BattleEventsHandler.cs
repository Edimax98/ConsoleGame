using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface BattleEventsHandler
    {
        void hostileNpcDead(HostileNPC hostileNpc);
        void playableCharacterDead(Playable player);
        void playableCharacterWasDefeatedBy(HostileNPC hostileNpc);
    }
}

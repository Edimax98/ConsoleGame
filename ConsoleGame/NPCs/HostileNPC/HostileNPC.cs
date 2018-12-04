using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface HostileNPC: NPC
    {
        int damageAmountAfterVictory { get; }
        int reward { get; }
    }
}

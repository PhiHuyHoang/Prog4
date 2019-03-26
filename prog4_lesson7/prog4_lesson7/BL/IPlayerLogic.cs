using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson7.BL
{
    interface IPlayerLogic
    {
        void AddPlayer(IList<Player> list);
        void ModPlayer(Player playerToModify);
        void DelPlayer(Player player, IList<Player> list);
        void AddToLine(IList<Player> team, IList<Player> line, Player player);
        void RemoveFromLine(IList<Player> team, IList<Player> line, Player player);

    }
}

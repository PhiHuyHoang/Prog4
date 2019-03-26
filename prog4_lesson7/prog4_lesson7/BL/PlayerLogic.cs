using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson7.BL
{
    class PlayerLogic : IPlayerLogic
    {
        public void AddPlayer(IList<Player> list)
        {
            EditorWindow win = new EditorWindow();
            if(win.ShowDialog() == true)
            {
                list.Add(win.Player);
            }
            // TODO EXTRACT INTO A SERVICE CALL
        }

        public void AddToLine(IList<Player> team, IList<Player> line, Player player)
        {
           if(team.Contains(player))
            {
                line.Add(player);
            }
        }

        public void DelPlayer(Player player, IList<Player> list)
        {
            list.Remove(player);
        }

        public void ModPlayer(Player playerToModify)
        {
            EditorWindow win = new EditorWindow(playerToModify);
            if (win.ShowDialog() == true)
            {
                // NOTHING TO DO CAN NOT CANCEL
                // TODO CREATE CLONE EDIT CLONECOPY CLONE INTO PLAYERtOmODIFY
            }
        }

        public void RemoveFromLine(IList<Player> team, IList<Player> line, Player player)
        {
            if (line.Contains(player))
            {
                line.Remove(player);
            }
        }
    }
}

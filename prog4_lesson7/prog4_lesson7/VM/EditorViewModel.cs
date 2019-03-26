using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson7
{
    class EditorViewModel: ViewModelBase
    {
        private Player player;

        public Player Player
        {
            get { return player; }
            set { Set(ref player, value); }
        }

        public Array PositionValues { get => Enum.GetValues(typeof(PositionType)); }
        public Array StatusValues { get => Enum.GetValues(typeof(StatusType)); } // Observation Collection if change

        public EditorViewModel()
        {
            player = new Player() { Name = "Wild Bill", Height = 205 };
        }

    }
}

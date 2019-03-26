using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using prog4_lesson7.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prog4_lesson7
{
    class MainViewModel: ViewModelBase
    {
        public ObservableCollection<Player> Team { get; private set; }
        public ObservableCollection<Player> Line { get; private set; }

        private Player teamSelected;
        private Player lineSelected;
        public Player TeamSelected { get => teamSelected; set => Set(ref teamSelected,value); }
        public Player LineSelected { get => lineSelected; set => Set(ref lineSelected, value); }

        public ICommand AddCmd { get; private set; }
        public ICommand DelCmd { get; private set; }
        public ICommand modCmd { get; private set; }
        public ICommand PromoteCmd { get; private set; }
        public ICommand RelegateCmd { get; private set; }

        IPlayerLogic logic
        {
            get { return ServiceLocator.Current.GetInstance<IPlayerLogic>(); }
        } // HIDDEN DEPENDENCY - > BAD SHOULD USE CTOR PARAM

        public MainViewModel()
        {
            Team = new ObservableCollection<Player>();
            Line = new ObservableCollection<Player>();
            if(IsInDesignMode)
            {
                Player p2 = new Player() { Name = "Will Bill 2" };
                Player p3 = new Player() { Name = "Will Bill 3" };
                Team.Add(p2);
                Line.Add(p3);
            }

            //CommandWpf namespace

            AddCmd = new RelayCommand(() => { logic.AddPlayer(Team); });
            DelCmd = new RelayCommand(() => { logic.DelPlayer(teamSelected, Team); });
            modCmd = new RelayCommand(() => { logic.ModPlayer(teamSelected); });

            PromoteCmd = new RelayCommand(() => { logic.AddToLine(Team, Line, teamSelected); });
            RelegateCmd = new RelayCommand(() => { logic.RemoveFromLine(Team, Line, lineSelected); });

        }


    }
}

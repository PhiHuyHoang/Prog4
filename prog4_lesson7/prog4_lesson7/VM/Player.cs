using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson7
{
    //Tools / Nuget package manager / Manage Nuget for solution // MvvnLightLibs (by GalaSoft)
    public class Player : ObservableObject
    {
        private string name;

        private int height;
        
        private PositionType position;

        private StatusType status;

        public string Name { get => name; set => Set(ref name,value); }

        public int Height { get => height; set => Set(ref height,value); }
        public PositionType Position { get => position; set => Set(ref position,value); }
        public StatusType Status { get => status; set => Set(ref status, value); }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson8
{
    class PongModel
    {
        public int Errors { get; set; }
        public MyShape Pad { get; set; }
        public MyShape Ball { get; set; }

        public PongModel()
        {
            Pad = new MyShape(Config.Width / 2, Config.Height - 20, 100, 20);
            Ball = new MyShape(Config.Width / 2, Config.Height / 2, 10, 10);

        }
    }
}

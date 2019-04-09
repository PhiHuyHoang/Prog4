using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog4_lesson8
{
    class PongLogic
    {
        PongModel model;
        public enum Direction { Left, Right, Up, Down }
        public event EventHandler RefeshScreen;

        public PongLogic(PongModel model)
        {
            this.model = model;
        }

        public void MovePad(Direction dir)
        {
            if (dir == Direction.Left)
            {
                model.Pad.ChangeX(-10);
            }
            else if(dir == Direction.Right)
            {
                model.Pad.ChangeX(10);
            }
            else if(dir == Direction.Up)
            {
                model.Pad.ChangeY(-10);
            }
            else
            {
                model.Pad.ChangeY(10);
            }
            RefeshScreen?.Invoke(this, EventArgs.Empty);
        }

        private bool MoveShape(MyShape shape)
        {
            bool faulted = false;
            shape.ChangeX(shape.Dx);
            shape.ChangeY(shape.Dy);

            if(shape.Area.Left < 0 ||shape.Area.Right > Config.Width)
            {
                shape.Dx = -shape.Dx;
            }
            if(shape.Area.Top < 0|| shape.Area.IntersectsWith(model.Pad.Area))
            {
                shape.Dy = -shape.Dy;
            }

            if(shape.Area.Top > Config.Height)
            {
                faulted = true;
                shape.SetXY(Config.Width / 2, Config.Height / 2);
            }

            RefeshScreen?.Invoke(this, EventArgs.Empty);
            return faulted;
        }

        public void MoveBall()
        {
            if (MoveShape(model.Ball)) model.Errors++;
            RefeshScreen?.Invoke(this, EventArgs.Empty);
        }
    }
}

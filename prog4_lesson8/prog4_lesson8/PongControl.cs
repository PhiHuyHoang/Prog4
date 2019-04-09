using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace prog4_lesson8
{
    class PongControl: FrameworkElement
    {
        PongDisplay display;
        PongModel model;
        PongLogic logic;
        DispatcherTimer moveTimer;

        public PongControl()
        {
            Loaded += PongControl_Loaded;
        }

        private void PongControl_Loaded(object sender, RoutedEventArgs e)
        {
            //create  model logic in load delegate void
            model = new PongModel();
            logic = new PongLogic(model);
            display = new PongDisplay(model);

            Window win = Window.GetWindow(this);
            if(win != null)
            {
                moveTimer = new DispatcherTimer();
                moveTimer.Interval = TimeSpan.FromMilliseconds(40);
                moveTimer.Tick += MoveTimer_Tick;
                moveTimer.Start();

                win.KeyDown += Win_KeyDown;
                logic.RefeshScreen += Logic_RefeshScreen;
            }
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if(display != null)
            {
                display.DrawThings(drawingContext);
            }
        }

        private void Logic_RefeshScreen(object sender, EventArgs e)
        {
            InvalidateVisual();
        }

        private void Win_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Left: logic.MovePad(PongLogic.Direction.Left);break;
                case Key.Right: logic.MovePad(PongLogic.Direction.Right);break;
                case Key.Up: logic.MovePad(PongLogic.Direction.Up); break;
                case Key.Down: logic.MovePad(PongLogic.Direction.Down); break;
                case Key.Space: moveTimer.IsEnabled = !moveTimer.IsEnabled; break;
            }
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            logic.MoveBall();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace prog4_lesson8
{
    class PongDisplay
    {
        PongModel model;

        public PongDisplay(PongModel model)
        {
            this.model = model;
        }

        public void DrawThings(DrawingContext ctx)
        {
            // TODO: OPTIMIZE THIS METHOD;
            // TODO: GET RID OF ALL POSSIBLE "NEW" INSTANCES;
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(new GeometryDrawing(Config.BgColor,
                new Pen(Config.BorderColor,Config.BorderThickness),
                new RectangleGeometry(new System.Windows.Rect(0,0,Config.Width,Config.Height))
                ));

            dg.Children.Add(new GeometryDrawing(Config.BallBackColor,
                new Pen(Config.BallLineColor, 1),
                new RectangleGeometry(model.Ball.Area)
                ));

            dg.Children.Add(new GeometryDrawing(Config.BorderColor,
                null,
                new RectangleGeometry(model.Pad.Area)
                ));

            FormattedText text = new FormattedText(model.Errors.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 15, Brushes.Red);

            dg.Children.Add(new GeometryDrawing(null, new Pen(Brushes.Red, 3), text.BuildGeometry(new Point(5, 5))));

            ctx.DrawDrawing(dg);
        }
    }
}

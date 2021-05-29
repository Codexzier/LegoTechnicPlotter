using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Presentation;
using System.Collections;

namespace LegoTechnicPlotter.Controls
{
    // TODO: Not ready
    public class PathPlotterBuilder
    {
        public Canvas CreatePathLine(IDictionary dictionary)
        {
            // TODO: Path aufbauen



            var canvas = new Canvas();

            var rect = new Rectangle(160, 120);
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.SetMargin(30, 30, 0, 0);

            rect.Fill = new SolidColorBrush(Colors.Green);
            canvas.Children.Add(rect);



            var dc = TopLeftButton();
            canvas.OnRender(dc);

            return canvas;
        }

        private DrawingContext TopLeftButton()
        {
            var dc = new DrawingContext(110, 40);

            var c = ColorUtility.ColorFromRGB(120, 136, 150);
            var pen = new Pen(c);
            pen.Thickness = (ushort)2;

            dc.DrawLine(pen, 0, 0, 100, 0);
            dc.DrawLine(pen, 100, 0, 70, 40);
            dc.DrawLine(pen, 70, 40, 0, 40);
            dc.DrawLine(pen, 0, 40, 0, 0);

            return dc;
        }
    }
}

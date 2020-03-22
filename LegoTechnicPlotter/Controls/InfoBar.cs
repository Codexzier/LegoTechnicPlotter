using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Styles;

namespace LegoTechnicPlotter.Controls
{
    /// <summary>
    /// Simple infobar.
    /// TODO: no information to show here
    /// </summary>
    public class InfoBar
    {
        public InfoBar(Panel content)
        {
            this.CreateGroundTop(content);
            this.CreateGroundBottom(content);
        }

        private void CreateGroundTop(Panel content)
        {
            Rectangle rec = new Rectangle(320, 15);
            rec.HorizontalAlignment = HorizontalAlignment.Stretch;
            rec.VerticalAlignment = VerticalAlignment.Top;
            rec.Fill = new SolidColorBrush(SquareBlueColors.LightBlue);

            content.Children.Add(rec);
        }

        private void CreateGroundBottom(Panel content)
        {
            Rectangle rec = new Rectangle(320, 5);
            rec.HorizontalAlignment = HorizontalAlignment.Stretch;
            rec.VerticalAlignment = VerticalAlignment.Bottom;
            rec.Fill = new SolidColorBrush(SquareBlueColors.LightBlue);

            content.Children.Add(rec);
        }
    }
}

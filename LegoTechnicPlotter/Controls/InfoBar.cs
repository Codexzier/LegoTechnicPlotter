using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Styles;
using LegoTechnicPlotter.Views.Base;

namespace LegoTechnicPlotter.Controls
{
    /// <summary>
    /// Simple infobar.
    /// TODO: no information to show here
    /// </summary>
    public class InfoBar
    {
        public InfoBar(BaseView view)
        {
            this.CreateGroundTop(view);
            this.CreateGroundBottom(view);
        }

        private void CreateGroundTop(BaseView view)
        {
            Rectangle rec = new Rectangle(320, 15);
            rec.HorizontalAlignment = HorizontalAlignment.Stretch;
            rec.VerticalAlignment = VerticalAlignment.Top;
            rec.Fill = new SolidColorBrush(SquareBlueColors.LightBlue);

            view.Add(rec);
        }

        private void CreateGroundBottom(BaseView view)
        {
            Rectangle rec = new Rectangle(320, 5);
            rec.HorizontalAlignment = HorizontalAlignment.Stretch;
            rec.VerticalAlignment = VerticalAlignment.Bottom;
            rec.Fill = new SolidColorBrush(SquareBlueColors.LightBlue);

            view.Add(rec);
        }
    }
}

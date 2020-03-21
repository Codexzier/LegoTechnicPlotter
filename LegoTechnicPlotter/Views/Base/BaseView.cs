using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;

namespace LegoTechnicPlotter.Views.Base
{
    public abstract class BaseView
    {
        private Canvas _view = new Canvas();

        protected virtual void InitializeComponent()
        {
            this.SetBackground();
        }

        protected void SetBackground()
        {
            Rectangle rec = new Rectangle(200, 100);
            rec.HorizontalAlignment = HorizontalAlignment.Left;
            rec.VerticalAlignment = VerticalAlignment.Top;
            rec.Fill = new SolidColorBrush(Colors.Green);

            this._view.Children.Add(rec);
        }
    }
}

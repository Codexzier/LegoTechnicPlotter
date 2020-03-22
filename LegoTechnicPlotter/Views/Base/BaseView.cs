using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Styles;

namespace LegoTechnicPlotter.Views.Base
{
    /// <summary>
    /// Base view. Draw a background with base color and has the reference of the panel.
    /// </summary>
    public abstract class BaseView
    {
        protected readonly Panel _content;

        public BaseView(Panel content)
        {
            this._content = content;
        }

        public virtual void InitializeComponent()
        {
            this.SetBackground();
        }

        protected void SetBackground()
        {
            Rectangle rec = new Rectangle(320, 240);
            rec.HorizontalAlignment = HorizontalAlignment.Left;
            rec.VerticalAlignment = VerticalAlignment.Top;
            rec.Fill = new SolidColorBrush(SquareBlueColors.DarkBlue);

            this._content.Children.Add(rec);
        }

        protected void Add(UIElement element)
        {
            this._content.Children.Add(element);
        }
    }
}

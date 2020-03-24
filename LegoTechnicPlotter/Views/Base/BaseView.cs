using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Styles;
using System.Collections;
using LegoTechnicPlotter.Controls;

namespace LegoTechnicPlotter.Views.Base
{
    /// <summary>
    /// Base view. Draw a background with base color and has the reference of the panel.
    /// </summary>
    public abstract class BaseView
    {
        private ArrayList _controls = new ArrayList();
        private readonly Panel _content;

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
            this._controls.Add(rec);
        }

        public void Add(UIElement element)
        {
            this._content.Children.Add(element);
            this._controls.Add(element);
        }

        public void Remove(UIElement element)
        {
            this._content.Children.Remove(element);
            this._controls.Remove(element);
        }

        public virtual void Show()
        {
            foreach (var item in this._controls)
            {
                if (this.IsSubElement(item))
                {
                    continue;
                }

                var element = item as UIElement;
                element.Visibility = Visibility.Visible;
            }
        }

        public virtual void Hide()
        {
            foreach (var item in this._controls)
            {
                if (this.IsSubElement(item))
                {
                    continue;
                }

                var element = item as UIElement;
                element.Visibility = Visibility.Collapsed;
            }
        }

        private bool IsSubElement(object item)
        {
            var control = item as IElementControl;

            if(control == null)
            {
                return false;
            }

            return control.IsSubElement;
        }
    }
}

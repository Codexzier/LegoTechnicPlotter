using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Styles;

namespace LegoTechnicPlotter.Controls
{
    public class IconButton : BaseButton
    {
        private IconButton _buttonPressEffect;

        private string _char = "X";

        public IconButton(BaseView view, int left, int top, Color colorChangeEffect) : this(left, top)
        {
            this._pen = new Pen(colorChangeEffect, 1);
            this._isEffect = true;
        }

        public IconButton(BaseView view, int left, int top, string content) : this(left, top)
        {
            Debug.Print(content);
            this._char = content;
            this._buttonPressEffect = new IconButton(view, left, top, SquareBlueColors.LightBluePress);
            this._buttonPressEffect.Visibility = Microsoft.SPOT.Presentation.Visibility.Collapsed;

            this.SetupTouch();

            view.Add(this);
            view.Add(this._buttonPressEffect);
        }

        private IconButton(int left, int top) : base(left, top)
        {
            this.Width = 42;
            this.Height = 42;
        }

        public override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            if (!this._isEffect)
            {
                dc.DrawRectangle(new SolidColorBrush(SquareBlueColors.DarkBlue),
                    new Pen(SquareBlueColors.DarkBlue),
                    0, 0, 252, 42);
            }

            dc.DrawLine(this._pen, 0, 0, 40, 0);
            dc.DrawLine(this._pen, 40, 0, 40, 40);
            dc.DrawLine(this._pen, 40, 40, 0, 40);
            dc.DrawLine(this._pen, 0, 40, 0, 0);

            int left, top, right, bottom;
            this.GetMargin(out left, out top, out right, out bottom);

            dc.DrawText(this._char,
                Resources.GetFont(Resources.FontResources.NinaB),
                this._isEffect ? SquareBlueColors.LightBluePress : SquareBlueColors.LightBlue,
                20,
                15);
        }

        protected override void SetPressEffect()
        {
            if (this._buttonPressEffect.Visibility == Microsoft.SPOT.Presentation.Visibility.Visible)
            {
                return;
            }

            base.SetPressEffect();
            this._buttonPressEffect.Visibility = Microsoft.SPOT.Presentation.Visibility.Visible;
        }

        protected override void SetPressEffectEnd()
        {
            base.SetPressEffectEnd();
            this._buttonPressEffect.Visibility = Microsoft.SPOT.Presentation.Visibility.Collapsed;
        }

        public override void MoveElementToLastLevel(BaseView view)
        {
            base.MoveElementToLastLevel(view, this._buttonPressEffect);
        }
    }
}

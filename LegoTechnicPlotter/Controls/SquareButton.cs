using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Styles;
using LegoTechnicPlotter.Views.Base;

namespace LegoTechnicPlotter.Controls
{
    /// <summary>
    /// Create instance to create a sqare button with touch effect.
    /// </summary>
    public class SquareButton : BaseButton
    {
        private SquareButton _buttonPressEffect;
        
        private string _text;

        public SquareButton(BaseView view, SquareButtonPosition position, string text)
            : this(view, 20, SquareButton.GetTopDistance(position), text)
        {
        }

        /// <summary>
        /// Create instance to create a sqare button with touch effect.
        /// </summary>
        /// <param name="content">Need the base panel</param>
        /// <param name="left">Left distance.</param>
        /// <param name="top">Top distance.</param>
        /// <param name="text">Set text for the button.</param>
        public SquareButton(BaseView view, int left, int top, string text)
            : this(left, top, text)
        {
            this._buttonPressEffect = new SquareButton(left, top, text, SquareBlueColors.LightBluePress);
            this._buttonPressEffect.Visibility = Visibility.Collapsed;

            this.SetupTouch();

            view.Add(this);
            view.Add(this._buttonPressEffect);
        }

        /// <summary>
        /// Only used for the effect of the button.
        /// </summary>
        /// <param name="content">Need the base panel</param>
        /// <param name="left">Left distance.</param>
        /// <param name="top">Top distance.</param>
        /// <param name="text">Set text for the button.</param>
        /// <param name="colorChangeEffect">Change color to.</param>
        private SquareButton(int left, int top, string text, Color colorChangeEffect)
            : this(left, top, text)
        {
            this._pen = new Pen(colorChangeEffect, 1);
            this._isEffect = true;
        }

        /// <summary>
        /// Practical base ctor.
        /// </summary>
        /// <param name="left">Left distance.</param>
        /// <param name="top">Top distance.</param>
        /// <param name="text">Set text for the button.</param>
        private SquareButton(int left, int top, string text) : base(left, top)
        {
            this.Width = 252;
            this.Height = 42;

            this._text = text;
        }

        /// <summary>
        /// It render the target content button with specialize border.
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            if (!this._isEffect)
            {
                dc.DrawRectangle(new SolidColorBrush(SquareBlueColors.DarkBlue),
                    new Pen(SquareBlueColors.DarkBlue),
                    0, 0, 252, 42);
            }

            dc.DrawLine(this._pen, 0, 0, 250, 0);
            dc.DrawLine(this._pen, 250, 0, 250, 20);
            dc.DrawLine(this._pen, 250, 20, 230, 40);
            dc.DrawLine(this._pen, 230, 40, 0, 40);
            dc.DrawLine(this._pen, 0, 40, 0, 0);

            //int left, top, right, bottom;
            //this.GetMargin(out left, out top, out right, out bottom);

            dc.DrawText(this._text,
                Resources.GetFont(Resources.FontResources.NinaB),
                this._isEffect ? SquareBlueColors.LightBluePress : SquareBlueColors.LightBlue,
                20,
                15);
        }

        /// <summary>
        /// Execute by user touch. Locked, if the touch schow the effect.
        /// </summary>
        protected override void SetPressEffect()
        {
            if (this._buttonPressEffect.Visibility == Microsoft.SPOT.Presentation.Visibility.Visible)
            {
                return;
            }

            base.SetPressEffect();
            this._buttonPressEffect.Visibility = Visibility.Visible;
        }

        protected override void SetPressEffectEnd()
        {
            base.SetPressEffectEnd();
            this._buttonPressEffect.Visibility = Visibility.Collapsed;
        }

        public override void MoveElementToLastLevel(BaseView view)
        {
            base.MoveElementToLastLevel(view, this._buttonPressEffect);
        }
    }
}

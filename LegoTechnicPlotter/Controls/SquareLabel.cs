using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Views.Base;
using LegoTechnicPlotter.Styles;

namespace LegoTechnicPlotter.Controls
{
    public class SquareLabel : Canvas, IElementControl
    {
        private Pen _pen1 = new Pen(ColorUtility.ColorFromRGB(192, 225, 255), 3);
        private Pen _pen2 = new Pen(ColorUtility.ColorFromRGB(192, 225, 255), 1);

        private string _text;


        public SquareLabel(BaseView view, string text, int left, int top)
        {
            this.Width = 252;
            this.Height = 42;

            this._text = text;

            this.SetMargin(left, top, 0, 0);
        }

        public override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            dc.DrawLine(this._pen1, 0, 0, 250, 0);
            dc.DrawLine(this._pen2, 0, 37, 250, 37);

            dc.DrawText(this._text,
                Resources.GetFont(Resources.FontResources.NinaB),
                SquareBlueColors.LightBluePress,
                20,
                15);
        }
    }
}

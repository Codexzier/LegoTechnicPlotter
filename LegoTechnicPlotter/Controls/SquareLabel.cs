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
        private Pen _pen2 = new Pen(ColorUtility.ColorFromRGB(192, 225, 255), 1);

        private string _text;


        public SquareLabel(BaseView view, string text, int left, int top)
        {
            this.Width = 320;
            this.Height = 42;

            this._text = text;

            this.HorizontalAlignment = Microsoft.SPOT.Presentation.HorizontalAlignment.Left;
            this.VerticalAlignment = Microsoft.SPOT.Presentation.VerticalAlignment.Top;
            this.SetMargin(left, top, 0, 0);

            view.Add(this);
        }

        public override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            dc.DrawLine(this._pen2, 0, 37, 320, 37);

            dc.DrawText(this._text,
                Resources.GetFont(Resources.FontResources.NinaB),
                SquareBlueColors.LightBluePress,
                20,
                15);
        }

        public bool IsSubElement
        {
            get { return true; }
        }
    }
}

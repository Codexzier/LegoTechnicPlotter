using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Gadgeteer;

namespace LegoTechnicPlotter.Controls
{
    public class SquarePhoto : Canvas
    {
        private Pen _pen = new Pen(ColorUtility.ColorFromRGB(120, 136, 150), 1);


        public SquarePhoto(Panel content, int left, int top)
        {
            content.Children.Add(this);
        }

        public void LoadPicture(Picture picture)
        {

        }
    }
}

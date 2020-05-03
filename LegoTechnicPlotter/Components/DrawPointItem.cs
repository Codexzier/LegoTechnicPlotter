using System;
using Microsoft.SPOT;

namespace LegoTechnicPlotter.Components
{
    public class DrawPointItem
    {
        private int _x;
        private int _y;
        private int _grayScaleValue;
        public DrawPointItem(int x, int y, int grayScaleValue)
        {
            this._x = x;
            this._y = y;
            this._grayScaleValue = grayScaleValue;
        }

        public int X { get { return this._x; } }

        public int Y { get { return this._y; } }

        public int GrayScaleValue { get { return this._grayScaleValue; } }
    }
}

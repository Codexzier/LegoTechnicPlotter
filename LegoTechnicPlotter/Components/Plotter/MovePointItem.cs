using System;
using Microsoft.SPOT;

namespace LegoTechnicPlotter.Components.Plotter
{
    public class MovePointItem
    {
        public int X { get; set; }

        public int Y { get; set; }

        public MovePointItem(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

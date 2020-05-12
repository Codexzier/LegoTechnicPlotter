using System;
using Microsoft.SPOT;

namespace LegoTechnicPlotter.Controls
{
    public static class SquareStyleHelper
    {
        public static int GetTopDistance(SquareButtonPosition position)
        {
            switch (position)
            {
                case SquareButtonPosition.Line_1:
                    return 30;
                case SquareButtonPosition.Line_2:
                    return 80;
                case SquareButtonPosition.Line_3:
                    return 130;
                case SquareButtonPosition.Line_4:
                    return 180;
                default:
                    break;
            }

            return 0;
        }
    }
}

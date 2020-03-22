
using Microsoft.SPOT.Presentation.Media;

namespace LegoTechnicPlotter.Styles
{
    /// <summary>
    /// Some base color for this program
    /// </summary>
    public static class SquareBlueColors
    {
        public static Color LightBlue
        {
            get 
            {
                return ColorUtility.ColorFromRGB(120, 136, 150);
            }
        }

        public static Color LightBluePress
        {
            get
            {
                return ColorUtility.ColorFromRGB(220, 236, 250);
            }
        }

        public static Color DarkBlue
        {
            get
            {
                return ColorUtility.ColorFromRGB(0, 23, 44);
            }
        }
    }
}

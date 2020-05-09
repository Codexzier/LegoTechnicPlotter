using System;
using Microsoft.SPOT;

namespace LegoTechnicPlotter.Components
{
    public static class TypeParseExtensions
    {
        public static int GetValue(this string str)
        {
            int resultValue = 0;
            if (!str.TryParse(out resultValue))
            {
                resultValue = 0;
            }
            return resultValue;
        }

        public static bool TryParse(this string str, out int value)
        {
            try
            {
                value = int.Parse(str);
                return true;
            }
            catch
            {
                value = 0;
            }

            return false;
        }

        public static int GetMin(this int value, int minValue = 10)
        {
            if (value <= minValue)
            {
                value = minValue;
            }

            return value;
        }
    }
}

using System;
using Microsoft.SPOT;

namespace LegoTechnicPlotter.Components
{
    public static class Logging
    {
        public static bool DebugPrintOn = true;

        public static void Log(string message)
        {
            if (DebugPrintOn)
            {
                Debug.Print(message);
            }
        }
    }
}

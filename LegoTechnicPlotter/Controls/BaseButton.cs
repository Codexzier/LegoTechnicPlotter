using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;

namespace LegoTechnicPlotter.Controls
{
    public class BaseButton : Canvas, IElementControl
    {
        private bool _isEffect = false;





        public bool IsSubElement { get { return this._isEffect; } }
    }
}

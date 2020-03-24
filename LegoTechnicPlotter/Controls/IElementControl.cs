using System;
using Microsoft.SPOT;

namespace LegoTechnicPlotter.Controls
{
    public interface IElementControl
    {
        bool IsSubElement { get; }
    }
}

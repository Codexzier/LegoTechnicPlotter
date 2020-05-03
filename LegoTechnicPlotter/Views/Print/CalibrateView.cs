using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Components;

namespace LegoTechnicPlotter.Views.Print
{
    public class CalibrateView : BaseView
    {
        private PlotterController _extender;

        public CalibrateView(Panel content, PlotterController controller)
            : base(content)
        {
            this._extender = controller;
        }
    }
}

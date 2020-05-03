using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Components;
using LegoTechnicPlotter.Components.Plotter;
using LegoTechnicPlotter.Controls;

namespace LegoTechnicPlotter.Views.Print
{
    public class CalibrateView : BaseView
    {
        private PlotterController _plotterController;

        private SquareButton _buttonLeft;

        public CalibrateView(Panel content, PlotterController controller)
            : base(content)
        {
            this._plotterController = controller;
        }
    }
}

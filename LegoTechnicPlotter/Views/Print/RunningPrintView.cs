using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Components.Plotter;
using System.Collections;
using LegoTechnicPlotter.Controls;

namespace LegoTechnicPlotter.Views.Print
{
    public class RunningPrintView : BaseView
    {
        private PlotterController _controller;

        private SquareButton _buttonRepeat;

        public RunningPrintView(IApplicationContext context, PlotterController controller)
            : base(context)
        {
            this._controller = controller;
            this._buttonRepeat = new SquareButton(this, SquareButtonPosition.Line_1, "Repeat");
            this._buttonRepeat.ButtonPressedEvent += this.Start;
        }


        public void Start()
        {
            ArrayList al = new ArrayList();

            al.Add(new MovePointItem(0, 0));

            al.Add(new MovePointItem(10, 0));

            al.Add(new MovePointItem(10, 10));

            al.Add(new MovePointItem(0, 10));

            al.Add(new MovePointItem(0, 0));

            this._controller.RunSequenz(al);
        }
    }
}

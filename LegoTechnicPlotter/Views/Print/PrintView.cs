using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Components;
using System.Collections;
using LegoTechnicPlotter.Components.Plotter;

namespace LegoTechnicPlotter.Views.Print
{
    public class PrintView : BaseView
    {
        private SquareButton _buttonCalibrate;
        private SquareButton _buttonRunningPrint;

        public PrintView(IApplicationContext context)
            : base(context)
        {
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonCalibrate = new SquareButton(this, SquareButtonPosition.Line_1, "Calibrate");


            this._buttonRunningPrint = new SquareButton(this, SquareButtonPosition.Line_2, "Start");
        }

        public SquareButton ButtonCalibrate { get { return this._buttonCalibrate; } }
        public SquareButton ButtonRunningPrint { get { return this._buttonRunningPrint; } }
    }
}

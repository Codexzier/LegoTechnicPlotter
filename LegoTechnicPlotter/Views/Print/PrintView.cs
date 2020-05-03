using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Components;

namespace LegoTechnicPlotter.Views.Print
{
    public class PrintView : BaseView
    {
        private PlotterController _extender;

        private SquareButton _buttonCalibrate;
        private SquareButton _buttonStart;

        public PrintView(Panel content, Gadgeteer.Modules.GHIElectronics.Extender extender)
            : base(content)
        {
            this._extender = PlotterController.GetInstance(extender);
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonCalibrate = new SquareButton(this, 20, 30, "Calibrate");


            this._buttonStart = new SquareButton(this, 20, 130, "Start");
            this._buttonStart.ButtonPressedEvent += this._buttonStart_ButtonPressedEvent;
        }

        private void _buttonStart_ButtonPressedEvent()
        {


            this._extender.Move(1000, Move.Left);
        }
    }
}

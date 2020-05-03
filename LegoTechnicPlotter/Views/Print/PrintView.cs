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
        private SquareButton _buttonStart;

        public PrintView(Panel content)
            : base(content)
        {
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonCalibrate = new SquareButton(this, SquareButtonPosition.Line_1, "Calibrate");


            this._buttonStart = new SquareButton(this, SquareButtonPosition.Line_2, "Start");
            this._buttonStart.ButtonPressedEvent += this._buttonStart_ButtonPressedEvent;
        }

        public SquareButton ButtonCalibrate { get { return this._buttonCalibrate; } }

        private void _buttonStart_ButtonPressedEvent()
        {
            ArrayList al = new ArrayList();

            al.Add(new MovePointItem(0, 0));

            
        }
    }
}

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
        public static PrintForm PrintFormToPlotter = PrintForm.Star;

        private PlotterController _controller;

        private SquareButton _buttonCalibrate;
        private SquareButton _buttonRunningPrint;

        public PrintView(IApplicationContext context, AppView fromApplicationView, PlotterController controller)
            : base(context, AppView.Print, fromApplicationView, "Print")
        {
            this._controller = controller;
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonCalibrate = new SquareButton(this, SquareButtonPosition.Line_2, "Calibrate");
            this._buttonCalibrate.ButtonPressedEvent += _buttonCalibrate_ButtonPressedEvent;

            this._buttonRunningPrint = new SquareButton(this, SquareButtonPosition.Line_3, "Start");
            this._buttonRunningPrint.ButtonPressedEvent += _buttonRunningPrint_ButtonPressedEvent;
        }

        

        private void _buttonCalibrate_ButtonPressedEvent()
        {
               
        }

        private void _buttonRunningPrint_ButtonPressedEvent()
        {
            switch (PrintView.PrintFormToPlotter)
            {
                case PrintForm.Star:
                    this.PrintStar();
                    break;
                case PrintForm.Tessaract:
                    this.Square();
                    break;
                default:
                    break;
            }
        }

        private void PrintStar()
        {
            // 17,32L 
            // 33,32L 
            // 38,18L 
            
            // 43,32L 
            // 59,32L 
            // 46,41L 
            
            // 51,56L 
            // 38,48L 
            // 26,56L 
            
            // 31,42L 
            // 17,32 
            
            ArrayList al = new ArrayList();

            al.Add(new MovePointItem(0, 0));
            
            al.Add(new MovePointItem(17, 32));
            al.Add(new MovePointItem(33, 32));
            al.Add(new MovePointItem(38, 18));

            al.Add(new MovePointItem(43, 32));
            al.Add(new MovePointItem(59, 32));
            al.Add(new MovePointItem(46, 41));
            
            al.Add(new MovePointItem(51, 56));
            al.Add(new MovePointItem(38, 48));
            al.Add(new MovePointItem(26, 56));
            
            al.Add(new MovePointItem(31, 42));
            al.Add(new MovePointItem(17, 32));
            
            al.Add(new MovePointItem(0, 0));

            this._controller.RunSequenz(al);
        }

        public void Square()
        {
            ArrayList al = new ArrayList();

            al.Add(new MovePointItem(0, 0));
            al.Add(new MovePointItem(10, 0));
            al.Add(new MovePointItem(10, 10));
            al.Add(new MovePointItem(0, 10));
            al.Add(new MovePointItem(0, 0));

            al.Add(new MovePointItem(10, 10));
            al.Add(new MovePointItem(0, 10));
            al.Add(new MovePointItem(10, 0));
            al.Add(new MovePointItem(0, 0));

            this._controller.RunSequenz(al);
        }
    }
}

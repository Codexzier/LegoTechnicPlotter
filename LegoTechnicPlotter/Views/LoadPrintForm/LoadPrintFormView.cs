using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Views.Print;

namespace LegoTechnicPlotter.Views.LoadPrintForm
{
    public class LoadPrintFormView : BaseView
    {
        private SquareButton _buttonPrintStar;
        private SquareButton _buttonPrintTessaract;

        public LoadPrintFormView(IApplicationContext context, AppView fromApplicationView)
            : base(context, AppView.RunningPrint, fromApplicationView, "Load print form")
        {
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonPrintStar = new SquareButton(this, SquareButtonPosition.Line_2, "Star");
            this._buttonPrintStar.ButtonPressedEvent += this._buttonPrintStar_ButtonPressedEvent;

            this._buttonPrintTessaract = new SquareButton(this, SquareButtonPosition.Line_3, "Tessaract");
            this._buttonPrintTessaract.ButtonPressedEvent += this._buttonPrintTessaract_ButtonPressedEvent;
        }
        
        private void _buttonPrintStar_ButtonPressedEvent()
        {
            PrintView.PrintFormToPlotter = PrintForm.Star;
            this.Context.Show(AppView.Print, this.ApplicationView);
        }

        private void _buttonPrintTessaract_ButtonPressedEvent()
        {
            PrintView.PrintFormToPlotter = PrintForm.Tessaract;
            this.Context.Show(AppView.Print, this.ApplicationView);
        }

        public override void Dispose()
        {
            base.Dispose();

            this._buttonPrintStar.ButtonPressedEvent -= _buttonPrintStar_ButtonPressedEvent;
            this._buttonPrintTessaract.ButtonPressedEvent -= _buttonPrintTessaract_ButtonPressedEvent;
        }
    }
}

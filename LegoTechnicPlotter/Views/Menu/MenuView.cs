

using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;

namespace LegoTechnicPlotter.Views.Menu
{
    /// <summary>
    /// Start menu of the program.
    /// Show Button option:
    /// - Create photo  => create a photo and show the result on new view.
    ///                    Open the photo result view. If the pictured finshed captured
    /// - Load photo    => show a list of pictures.
    ///                    Open the list view with a list of saved pitured from the sd card
    /// - Preview print => convert the picture to the print picture and show a preview.
    ///                    Open the preview view and show the convert result.
    /// - Print         => if not create by preview, it convert the picture and control the plotter.
    ///                    Open the status view with update every steps of the plotter process.
    /// </summary>
    public class MenuView : BaseView
    {
        //private SquareButton _buttonCreatePhoto;
        //private SquareButton _buttonLoadPhoto;
        private SquareButton _buttonLoadPrintForm;
        private SquareButton _buttonCalibrate;

        private InfoBar _infobar;

        public MenuView(IApplicationContext context)
            : base(context, AppView.Menu, AppView.NotSet, "Menu")
        {
            this.InitializeComponent();
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            //this._buttonCreatePhoto = new SquareButton(this, SquareButtonPosition.Line_2, "Create photo");
            //this._buttonCreatePhoto.ButtonPressedEvent += _buttonCreatePhoto_ButtonPressedEvent;

            //this._buttonLoadPhoto = new SquareButton(this, SquareButtonPosition.Line_3, "Load photo");

            this._buttonLoadPrintForm = new SquareButton(this, SquareButtonPosition.Line_3, "Load print form");
            this._buttonLoadPrintForm.ButtonPressedEvent += _buttonLoadPrintForm_ButtonPressedEvent;

            this._buttonCalibrate = new SquareButton(this, SquareButtonPosition.Line_4, "Calibrate");
            this._buttonCalibrate.ButtonPressedEvent += this._buttonCalibrate_ButtonPressedEvent;



            this._infobar = new InfoBar(this);
        }

        public void _buttonLoadPrintForm_ButtonPressedEvent()
        {
            this.Context.Show(AppView.LoadPrintForm, this.ApplicationView);
        }

        private void _buttonCreatePhoto_ButtonPressedEvent()
        {
            this.Context.Show(AppView.CreatePhoto, this.ApplicationView);
        }

        private void _buttonCalibrate_ButtonPressedEvent()
        {
            this.Context.Show(AppView.Calibrate, this.ApplicationView);
        }

        public override void Dispose()
        {
            base.Dispose();

            //this._buttonLoadPhoto = null;
            //this._buttonLoadPhoto = null;
            this._buttonCalibrate = null;
            this._infobar = null;
        }
    }

   
}

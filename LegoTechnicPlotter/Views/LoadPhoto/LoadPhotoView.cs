using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Controls;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Views.Base;

namespace LegoTechnicPlotter.Views.LoadPhoto
{
    // TODO: Not finish
    public class LoadPhotoView : BaseView
    {
        private SquareButton _buttonStart;

        public LoadPhotoView(IApplicationContext context, AppView fromApplicationView)
            : base(context, AppView.LoadPhoto, fromApplicationView, "Load photo")
        {
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonStart = new SquareButton(this, 20, 100, "Test");
            this._buttonStart.ButtonPressedEvent += this._buttonStart_ButtonPressedEvent;
        }

        private void _buttonStart_ButtonPressedEvent()
        {
            
        }

      
    }
}

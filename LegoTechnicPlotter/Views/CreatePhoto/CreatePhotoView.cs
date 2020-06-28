using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using Gadgeteer.Modules.GHIElectronics;
using LegoTechnicPlotter.Controls;

namespace LegoTechnicPlotter.Views.CreatePhoto
{
    public class CreatePhotoView : BaseView
    {
        public static Gadgeteer.Picture ActualPicture;
        private Camera _camera;
 

        private SquareButton _buttonTakePhoto;
        private SquareButton _buttonAccept;
        
        public CreatePhotoView(IApplicationContext context, AppView fromApplicationView, Camera camera)
            : base(context, AppView.CreatePhoto, fromApplicationView, "Create photo")
        {
            this._camera = camera;
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonTakePhoto = new SquareButton(this, SquareButtonPosition.Line_2, "Take photo");
            this._buttonTakePhoto.ButtonPressedEvent += _buttonTakePhoto_ButtonPressedEvent;

            this._buttonAccept = new SquareButton(this, SquareButtonPosition.Line_3, "Accept");
            this._buttonAccept.ButtonPressedEvent += _buttonAccept_ButtonPressedEvent;
        }

        private void _buttonAccept_ButtonPressedEvent()
        {
            this.Context.Show(AppView.PreviewForPrint, this.ApplicationView);
        }

        public void _buttonTakePhoto_ButtonPressedEvent()
        {
            this.Context.Show(AppView.WaitCameraShot, this.ApplicationView);
        }


        public override void Dispose()
        {
            base.Dispose();

            this._buttonTakePhoto.ButtonPressedEvent -= _buttonTakePhoto_ButtonPressedEvent;
        }
    }
}

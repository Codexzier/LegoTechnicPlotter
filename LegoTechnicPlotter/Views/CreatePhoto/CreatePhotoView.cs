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
        private SquareButton _buttonTakePhoto;
        private Camera _camera;
        public CreatePhotoView(Panel content, Camera camera)
            : base(content)
        {
            this._camera = camera;
            this._camera.PictureCaptured += this._camera_PictureCaptured;
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonTakePhoto = new SquareButton(this, SquareButtonPosition.Line_1, "Take photo");
            this._buttonTakePhoto.ButtonPressedEvent += _buttonTakePhoto_ButtonPressedEvent;
        }

        void _buttonTakePhoto_ButtonPressedEvent()
        {
            this._camera.TakePicture();
        }

        private void _camera_PictureCaptured(Camera sender, Gadgeteer.Picture picture)
        {
            Debug.Print("Was captured");
            //this._photoResult.LoadPicture(picture);
        }


    }
}

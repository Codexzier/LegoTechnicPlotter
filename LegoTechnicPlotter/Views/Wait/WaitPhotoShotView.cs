using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using LegoTechnicPlotter.Controls;
using Gadgeteer.Modules.GHIElectronics;
using LegoTechnicPlotter.Views.CreatePhoto;
using Microsoft.SPOT.Presentation.Controls;

namespace LegoTechnicPlotter.Views.Wait
{
    public class WaitPhotoShotView : BaseView
    {
        public static Gadgeteer.Picture ActualPicture;

        private Camera _camera;
        private Image _image;

        private IconButton _buttonRepeatTakePicture;

        public WaitPhotoShotView(IApplicationContext context, AppView fromApplicationView, Camera camera)
            : base(context, AppView.WaitCameraShot, fromApplicationView, "Take photo", backButtonText: "Accept")
        {
            this._camera = camera;

            this._camera.CurrentPictureResolution = new Camera.PictureResolution(Camera.PictureResolution.DefaultResolutions._160x120);

            this._camera.PictureCaptured += camera_PictureCaptured;
            this._camera.TakePicture();
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonRepeatTakePicture = new IconButton(this, 20, 80, "R");
            this._buttonRepeatTakePicture.ButtonPressedEvent += _buttonRepeatTakePicture_ButtonPressedEvent;
        }

        private void _buttonRepeatTakePicture_ButtonPressedEvent()
        {
            this.CleanUpImage();
            this._camera.TakePicture();
        }

        private void camera_PictureCaptured(Camera sender, Gadgeteer.Picture picture)
        {
            WaitPhotoShotView.ActualPicture = picture;
           
            if (WaitPhotoShotView.ActualPicture != null)
            {
                this.CleanUpImage();

                this._image = new Image(WaitPhotoShotView.ActualPicture.MakeBitmap());
                this._image.HorizontalAlignment = Microsoft.SPOT.Presentation.HorizontalAlignment.Left;
                this._image.VerticalAlignment = Microsoft.SPOT.Presentation.VerticalAlignment.Top;
                this._image.SetMargin(80, 55, 0, 0);
                this._image.Width = 160;
                this._image.Height = 120;
                this.Add(this._image);
            }
        }

        private void CleanUpImage()
        {
            if (this._image != null)
            {
                this.Remove(this._image);
                GC.SuppressFinalize(this._image);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            this._camera.PictureCaptured -= camera_PictureCaptured;

            this._buttonRepeatTakePicture.ButtonPressedEvent -= this._buttonRepeatTakePicture_ButtonPressedEvent;
        }
    }
}

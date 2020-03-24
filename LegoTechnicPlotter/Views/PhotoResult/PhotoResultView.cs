using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using Gadgeteer;
using LegoTechnicPlotter.Controls;

namespace LegoTechnicPlotter.Views.PhotoResult
{
    public class PhotoResultView : BaseView
    {
        private SquareButton _buttonBack;
        private Image _image;

        public PhotoResultView(Panel content)
            : base(content)
        {
            this.InitializeComponent();
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonBack = new SquareButton(this, 20, 180, "Back");
            
        }

        public void LoadPicture(Picture picture)
        {
            if (this._image != null)
            {
                this.Remove(this._image);
            }

            this._image = new Image(picture.MakeBitmap());
            this._image.SetMargin(0, 0, 0, 0);
            this.Add(this._image);

            this._buttonBack.MoveToLast(this);
        }

        public SquareButton Back { get { return this._buttonBack; } }
    }
}

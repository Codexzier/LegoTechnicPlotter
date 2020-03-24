using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT.Hardware;
using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Views.Base;
using LegoTechnicPlotter.Views.Menu;
using LegoTechnicPlotter.Views.PhotoResult;

namespace LegoTechnicPlotter
{
    public partial class Program
    {
        private MenuView _menu;
        private PhotoResultView _photoResult;

        void ProgramStarted()
        {
            this.InitialiseViews();

            this.Camera.PictureCaptured += Camera_PictureCaptured;
        }

        private void InitialiseViews()
        {
            var main = this.Display_T35.WPFWindow;

            var mainPanel = new Panel();

            // Menu content.
            this._menu = new MenuView(mainPanel);
            this._menu.CreatePhoto.ButtonPressedEvent += CreatePhoto_ButtonPressedEvent;

            this._photoResult = new PhotoResultView(mainPanel);
            this._photoResult.Back.ButtonPressedEvent += Back_ButtonPressedEvent;
            this._photoResult.Hide();

            main.Child = mainPanel;
        }



        private void Back_ButtonPressedEvent()
        {
            this._photoResult.Hide();
            this._menu.Show();
        }

        private void CreatePhoto_ButtonPressedEvent()
        {
             if (!this.Camera.CameraReady)
            {

            }

            this._menu.Hide();
            this._photoResult.Show();

            this.Camera.TakePicture();
        }

        /// <summary>
        /// Execute if the pictured was captured.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="picture"></param>
        private void Camera_PictureCaptured(Camera sender, GT.Picture picture)
        {
            Debug.Print("Was captured");
            this._photoResult.LoadPicture(picture);
        }
    }
}

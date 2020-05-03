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
using LegoTechnicPlotter.Components;
using LegoTechnicPlotter.Views.Print;

namespace LegoTechnicPlotter
{
    public partial class Program
    {
        private PlotterSettings _settings;
        private MenuView _menu;
        private PhotoResultView _photoResult;

        private PrintView _print;
       

        void ProgramStarted()
        {
            this._settings = PlotterSettings.GetInstance(SdCard);

            this.InitialiseViews();

            this.Camera.PictureCaptured += Camera_PictureCaptured;
        }

        private void InitialiseViews()
        {
            this.ShowMenu();
            //var main = this.Display_T35.WPFWindow;

            //var mainPanel = new Panel();

            //// Menu content.
            //this._menu = new MenuView(mainPanel);

            //this._menu.CreatePhoto.ButtonPressedEvent += this.CreatePhoto_ButtonPressedEvent;
            //this._photoResult = new PhotoResultView(mainPanel);
            //this._photoResult.Back.ButtonPressedEvent += this.Back_ButtonPressedEvent;
            //this._photoResult.Hide();

            //this._menu.Print.ButtonPressedEvent += this.Print_ButtonPressedEvent;

            //this._print = new PrintView(mainPanel, this.extender);
            //this._print.Back.ButtonPressedEvent += this.Back_ButtonPressedEvent;
            //this._print.Hide();


            //main.Child = mainPanel;
        }



        private void ShowMenu()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._menu = new MenuView(mainPanel);
            this._menu.Print.ButtonPressedEvent += this.ShowPrint;
            main.Child = mainPanel;
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


        private void ShowPrint()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._print = new PrintView(mainPanel, this.extender);
            this._print.Back.ButtonPressedEvent += this.ShowMenu;
            main.Child = mainPanel;
        }
    }
}

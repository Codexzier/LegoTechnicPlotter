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
using LegoTechnicPlotter.Components;
using LegoTechnicPlotter.Views.Print;
using LegoTechnicPlotter.Views.LoadPhoto;
using LegoTechnicPlotter.Views.PreviewPrint;
using LegoTechnicPlotter.Views.CreatePhoto;
using LegoTechnicPlotter.Components.Plotter;

namespace LegoTechnicPlotter
{
    public partial class Program
    {
        private ProgramSettings _settings;
        private MenuView _menu;
        private CreatePhotoView _createPhoto;
        private PhotoResultView _photoResult;
        private LoadPhotoView _loadPhoto;
        private PreviewPrintView _previewPrint;

        private PrintView _print;
        private CalibrateView _calibrate;

        void ProgramStarted()
        {
            this._settings = ProgramSettings.GetInstance(SdCard);

            this.ShowMenu();
        }

        #region Menu

        private void ShowMenu()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._menu = new MenuView(mainPanel);

            this._menu.CreatePhoto.ButtonPressedEvent += this.ShowCreatePhoto;
            this._menu.LoadPhoto.ButtonPressedEvent += this.ShowLoadPhoto;
            this._menu.PreviewPrint.ButtonPressedEvent += this.ShowPreviewPrint;
            this._menu.Print.ButtonPressedEvent += this.ShowPrint;

            main.Child = mainPanel;
        }

        private void RemoveMenuEvents()
        {
            if (this._menu == null)
            {
                return;
            }

            this._menu.CreatePhoto.ButtonPressedEvent -= this.ShowCreatePhoto;
            this._menu.LoadPhoto.ButtonPressedEvent -= this.ShowLoadPhoto;
            this._menu.PreviewPrint.ButtonPressedEvent -= this.ShowPreviewPrint;
            this._menu.Print.ButtonPressedEvent -= this.ShowPrint;
        }

        #endregion

        #region Create photo

        private void ShowCreatePhoto()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._createPhoto = new CreatePhotoView(mainPanel, this.Camera);

            this._photoResult.Back.ButtonPressedEvent += this.ShowMenu;

            main.Child = mainPanel;
        }

        private void RemovCreatePhotoEvents()
        {
            if (this._createPhoto == null)
            {
                return;
            }

            this._createPhoto.Back.ButtonPressedEvent -= this.ShowMenu;
        }

        #endregion

        private void ShowLoadPhoto()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._loadPhoto = new LoadPhotoView(mainPanel);

            this._loadPhoto.Back.ButtonPressedEvent += this.ShowMenu;

            main.Child = mainPanel;
        }

        private void ShowPreviewPrint()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._previewPrint = new PreviewPrintView(mainPanel);

            this._previewPrint.Back.ButtonPressedEvent += this.ShowMenu;

            main.Child = mainPanel;
        }

        private void ShowPrint()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._print = new PrintView(mainPanel);

            this._print.ButtonCalibrate.ButtonPressedEvent += this.ShowCalibrate;
            this._print.Back.ButtonPressedEvent += this.ShowMenu;

            main.Child = mainPanel;
        }
        
        private void ShowCalibrate()
        {
            var main = this.Display_T35.WPFWindow;
            var mainPanel = new Panel();
            this._calibrate = new CalibrateView(mainPanel, PlotterController.GetInstance(this.extender));
            this._print.Back.ButtonPressedEvent += this.ShowPrint;
            main.Child = mainPanel;
        }
    }
}

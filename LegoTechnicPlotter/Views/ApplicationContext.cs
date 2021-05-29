using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Components;
using Gadgeteer.Modules.GHIElectronics;
using LegoTechnicPlotter.Views.Menu;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Views.Print;
using LegoTechnicPlotter.Components.Plotter;
using LegoTechnicPlotter.Views.CreatePhoto;
using LegoTechnicPlotter.Views.Wait;
using LegoTechnicPlotter.Views.PreviewPrint;
using LegoTechnicPlotter.Views.LoadPrintForm;

namespace LegoTechnicPlotter.Views
{
    public class ApplicationContext : IApplicationContext
    {
        private ProgramSettings _settings;
        private SDCard _sdCard;
        private Display_T35 _display;
        private Extender _extener;
        private Camera _camera;

        private MenuView _menu;
        private CreatePhotoView _createPhoto;
        private WaitPhotoShotView _wait;

        private PreviewPrintView _previewForPrint;

        private LoadPrintFormView _loadPrintForm;
        private PrintView _print;

        private CalibrateView _calibrate;

        public ApplicationContext(
            SDCard sdCard,
            Display_T35 display,
            Extender extener,
            Camera camera)
        {
            this._settings = ProgramSettings.GetInstance(sdCard);
            this._sdCard = sdCard;
            this._display = display;
            this._extener = extener;
            this._camera = camera;
        }

        public void Show(AppView view, AppView from)
        {
            Debug.Print("Show" + view.ToString());
            //this.DestroyOpenInstance();

            var window = this._display.WPFWindow;

            switch (view)
            {
                case (AppView.Menu):
                    {
                        this._menu = new MenuView(this);
                        window.Child = this._menu.GetPanel();
                        break;
                    }
                case (AppView.CreatePhoto):
                    {
                        this._createPhoto = new CreatePhotoView(this, from, this._camera);
                        window.Child = this._createPhoto.GetPanel();
                        break;
                    }
                case (AppView.WaitCameraShot):
                    {
                        this._wait = new WaitPhotoShotView(this, from, this._camera);
                        window.Child = this._wait.GetPanel();
                        break;
                    }
                case (AppView.PreviewForPrint):
                    {
                        this._previewForPrint = new PreviewPrintView(this, from);
                        window.Child = this._previewForPrint.GetPanel();
                        break;
                    }
                case (AppView.LoadPrintForm):
                    {
                        this._loadPrintForm = new LoadPrintFormView(this, from);
                        window.Child = this._loadPrintForm.GetPanel();
                        break;
                    }
                case (AppView.Print):
                    {
                        this._print = new PrintView(this, from, PlotterController.GetInstance(this._extener, this._sdCard));
                        window.Child = this._print.GetPanel();
                        break;
                    }
                case (AppView.Calibrate):
                    {
                        this._calibrate = new CalibrateView(this, PlotterController.GetInstance(this._extener, this._sdCard), this._settings, from);
                        window.Child = this._calibrate.GetPanel();
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("This view ist not implemented for application context: " + view.ToString());
                    }
            }
        }

        private void DestroyOpenInstance()
        {
            if (this._menu != null)
            {
                this._menu.Dispose();
                this._menu = null;
            }

            if (this._calibrate != null)
            {
                this._calibrate.Dispose();
                this._calibrate = null;
            }
        }
    }
}

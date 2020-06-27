using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Components;
using Gadgeteer.Modules.GHIElectronics;
using LegoTechnicPlotter.Views.Menu;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Views.Print;
using LegoTechnicPlotter.Components.Plotter;

namespace LegoTechnicPlotter.Views
{
    public class ApplicationContext : IApplicationContext
    {
        private ProgramSettings _settings;
        private SDCard _sdCard;
        private Display_T35 _display;
        private Extender _extener;

        private MenuView _menu;

        private CalibrateView _calibrate;

        public ApplicationContext(
            SDCard sdCard, 
            Display_T35 display,
            Extender extener)
        {
            this._settings = ProgramSettings.GetInstance(sdCard);
            this._sdCard = sdCard;
            this._display = display;
            this._extener = extener;
        }

        public void Show(AppView view)
        {
            this.DestroyOpenInstance();

            var window = this._display.WPFWindow;

            switch(view)
            {
                case (AppView.Menu):
                    {
                    this._menu = new MenuView(this);
                    window.Child = this._menu.GetPanel();
                    break;
                }
                case (AppView.Calibrate):
                    {
                        this._calibrate = new CalibrateView(this, PlotterController.GetInstance(this._extener, this._sdCard), this._settings);
                        window.Child = this._calibrate.GetPanel();
                        break;
                    }
                default:
                    {
                        break;
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

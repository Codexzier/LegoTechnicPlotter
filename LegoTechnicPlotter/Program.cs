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

namespace LegoTechnicPlotter
{
    public partial class Program
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private bool _led0, _led1, _led2, _led3, _led4, _led5, _led6;

        private ArrayList _views = new ArrayList();

        void ProgramStarted()
        {
            this._timer.Interval = TimeSpan.FromTicks(TimeSpan.TicksPerSecond * 2);
            this._timer.Tick += _timer_Tick;
            this._timer.Start();

            var main = this.Display_T35.WPFWindow;

            var mainPanel = new Panel();

            MenuView menu = new MenuView(mainPanel);
            this._views.Add(menu);

            main.Child = mainPanel;
        }

        /// <summary>
        /// Show the activity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _timer_Tick(object sender, EventArgs e)
        {
            if(this._led0){ this.Led7R.TurnLightOn(0);} else { this.Led7R.TurnLightOff(0);}
            if (this._led1) { this.Led7R.TurnLightOn(1); } else { this.Led7R.TurnLightOff(1); }
            if (this._led2) { this.Led7R.TurnLightOn(2); } else { this.Led7R.TurnLightOff(2); }
            if (this._led3) { this.Led7R.TurnLightOn(3); } else { this.Led7R.TurnLightOff(3); }
            if (this._led4) { this.Led7R.TurnLightOn(4); } else { this.Led7R.TurnLightOff(4); }
            if (this._led5) { this.Led7R.TurnLightOn(5); } else { this.Led7R.TurnLightOff(5); }
            if (this._led6) { this.Led7R.TurnLightOn(6); } else { this.Led7R.TurnLightOff(6); }

            this._led0 = !this._led0;
            this._led1 = !this._led1 && !this._led0;
            this._led2 = !this._led0 && !this._led1 && !this._led2;
        }
    }
}

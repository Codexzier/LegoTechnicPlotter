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
using LegoTechnicPlotter.Views;

namespace LegoTechnicPlotter
{
    public partial class Program
    {
        private IApplicationContext _context;

        void ProgramStarted()
        {
            this._context = new ApplicationContext(
                this.SdCard,
                this.Display_T35,
                this.extender,
                this.Camera);


            this._context.Show(AppView.Menu, AppView.NotSet);
        }
    }
}

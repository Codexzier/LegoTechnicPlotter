using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;

namespace LegoTechnicPlotter.Views.Main
{
    public class MainView : BaseView
    {
        public MainView(IApplicationContext context, AppView fromApplicationView) 
            : base(context, AppView.Main, fromApplicationView, "Main")
        {
        }
    }
}
